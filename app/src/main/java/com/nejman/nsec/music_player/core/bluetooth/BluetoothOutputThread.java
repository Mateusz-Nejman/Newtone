package com.nejman.nsec.music_player.core.bluetooth;

import android.Manifest;
import android.bluetooth.BluetoothSocket;
import android.content.pm.PackageManager;

import androidx.core.app.ActivityCompat;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.media.MediaSource;

import java.io.IOException;

import io.reactivex.rxjava3.disposables.Disposable;
import io.reactivex.rxjava3.functions.Consumer;
import io.reactivex.rxjava3.subjects.PublishSubject;
import io.reactivex.rxjava3.subjects.Subject;

public class BluetoothOutputThread extends Thread {
    private final BluetoothSocket socket;
    private final BluetoothDeviceModel deviceModel;
    private final MediaSource mediaSource;
    private final Subject<BluetoothDeviceModel> onDeviceConnected;
    private final Subject<Exception> onDeviceError;
    private final Subject<MediaSource> onFileSent;

    public BluetoothOutputThread(BluetoothDeviceModel deviceModel, MediaSource mediaSource) {
        BluetoothSocket temp = null;
        this.deviceModel = deviceModel;

        try {
            if (ActivityCompat.checkSelfPermission(MainActivity.instance, Manifest.permission.BLUETOOTH_CONNECT) == PackageManager.PERMISSION_GRANTED) {
                temp = this.deviceModel.device.createRfcommSocketToServiceRecord(BluetoothManager.UUID);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        this.socket = temp;
        this.mediaSource = mediaSource;
        onDeviceConnected = PublishSubject.create();
        onDeviceError = PublishSubject.create();
        onFileSent = PublishSubject.create();
    }

    public Disposable addOnDeviceConnected(Consumer<? super BluetoothDeviceModel> consumer) {
        return onDeviceConnected.subscribe(consumer);
    }

    public Disposable addOnDeviceError(Consumer<? super Exception> consumer) {
        return onDeviceError.subscribe(consumer);
    }

    public Disposable addOnFileSent(Consumer<? super MediaSource> consumer) {
        return onFileSent.subscribe(consumer);
    }

    public void run() {
        try {
            if (ActivityCompat.checkSelfPermission(MainActivity.instance, Manifest.permission.BLUETOOTH_SCAN) != PackageManager.PERMISSION_GRANTED) {
                return;
            }
            MainActivity.bluetoothManager.getAdapter().cancelDiscovery();

            try {
                this.socket.connect();
            } catch (IOException connectException) {
                onDeviceError.onNext(connectException);
                try {
                    this.socket.close();
                } catch (IOException closeException) {
                    closeException.printStackTrace();
                }
                return;
            }

            onDeviceConnected.onNext(this.deviceModel);
            BluetoothSender sender = new BluetoothSender(socket, BluetoothMediaSource.fromMediaSource(this.mediaSource));
            sender.start();
            sender.join();
            onFileSent.onNext(mediaSource);
            sender.cancel();
            this.socket.close();
        } catch (IOException | InterruptedException e) {
            e.printStackTrace();
            onDeviceError.onNext(e);
        }
    }

    // Closes the connect socket and causes the thread to finish.
    public void cancel() {
        try {
            if (this.socket != null) {
                this.socket.close();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}