package com.nejman.nsec.music_player.core.bluetooth;

import android.Manifest;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothServerSocket;
import android.bluetooth.BluetoothSocket;
import android.content.pm.PackageManager;

import androidx.core.app.ActivityCompat;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.core.data.Tracks;
import com.nejman.nsec.music_player.media.MediaSource;

import java.io.IOException;

import io.reactivex.rxjava3.disposables.Disposable;
import io.reactivex.rxjava3.functions.Consumer;
import io.reactivex.rxjava3.subjects.PublishSubject;
import io.reactivex.rxjava3.subjects.Subject;

public class BluetoothInputThread extends Thread {
    private final BluetoothServerSocket socket;
    private final Subject<BluetoothDeviceModel> onDeviceConnected;
    private final Subject<Exception> onDeviceError;
    private final Subject<MediaSource> onFileReceived;

    public BluetoothInputThread() {
        onDeviceConnected = PublishSubject.create();
        onDeviceError = PublishSubject.create();
        onFileReceived = PublishSubject.create();

        BluetoothServerSocket temp = null;
        try {
            if (ActivityCompat.checkSelfPermission(MainActivity.instance, Manifest.permission.BLUETOOTH_CONNECT) == PackageManager.PERMISSION_GRANTED) {
                temp = MainActivity.bluetoothManager.getAdapter().listenUsingInsecureRfcommWithServiceRecord("Newtone", BluetoothManager.UUID);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        this.socket = temp;
    }

    public Disposable addOnDeviceConnected(Consumer<? super BluetoothDeviceModel> consumer) {
        return onDeviceConnected.subscribe(consumer);
    }

    public Disposable addOnDeviceError(Consumer<? super Exception> consumer) {
        return onDeviceError.subscribe(consumer);
    }

    public Disposable addOnFileReceived(Consumer<? super MediaSource> consumer) {
        return onFileReceived.subscribe(consumer);
    }

    public void run() {
        BluetoothSocket socket;
        while (true) {
            try {
                socket = this.socket.accept();
            } catch (IOException e) {
                e.printStackTrace();
                this.onDeviceError.onNext(e);
                break;
            }

            if (socket != null) {
                try {
                    BluetoothReceiver receiver = new BluetoothReceiver(socket);
                    receiver.start();
                    receiver.join();
                    if (receiver.isCompleted() && !receiver.isError()) {
                        MediaSource mediaSource = receiver.getMediaSource();
                        Tracks.add(mediaSource);
                        onFileReceived.onNext(mediaSource);
                    }
                    this.socket.close();
                } catch (IOException | InterruptedException e) {
                    e.printStackTrace();
                    onDeviceError.onNext(e);
                }
                break;
            }
        }
    }

    // Closes the client socket and causes the thread to finish.
    public void cancel() {
        try {
            this.socket.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}