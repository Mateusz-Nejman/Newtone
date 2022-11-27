package com.nejman.nsec.music_player.core.bluetooth;

import android.bluetooth.BluetoothSocket;

import com.nejman.nsec.music_player.media.MediaSource;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;

public class BluetoothReceiver extends Thread {
    private final BluetoothSocket socket;
    private final InputStream stream;
    private boolean error = false;
    private boolean completed = false;
    private MediaSource receivedMediaSource;

    public BluetoothReceiver(BluetoothSocket socket) throws IOException {
        this.socket = socket;
        this.stream = socket.getInputStream();
    }

    public boolean isCompleted() {
        return completed;
    }

    public boolean isError() {
        return error;
    }

    public MediaSource getMediaSource() {
        return receivedMediaSource;
    }

    @Override
    public void run() {
        byte[] buffer = new byte[1024];
        int byteCount;
        ByteArrayOutputStream byteStream = new ByteArrayOutputStream();
        BluetoothMediaSource bluetoothMediaSource;

        while (true) {
            try {
                byteCount = stream.read(buffer);
                byteStream.write(buffer, 0, byteCount);
            } catch (IOException e) {
                e.printStackTrace();
                byte[] data = byteStream.toByteArray();
                completed = true;
                bluetoothMediaSource = BluetoothMediaSource.fromBytes(data);
                error = bluetoothMediaSource == null;
                break;
            }
        }

        if (bluetoothMediaSource != null) {
            receivedMediaSource = bluetoothMediaSource.toMediaSource();

            if (receivedMediaSource == null) {
                error = true;
            }
        }
    }

    public void cancel() {
        try {
            stream.close();
            socket.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
