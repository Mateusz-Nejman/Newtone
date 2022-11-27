package com.nejman.nsec.music_player.core.bluetooth;

import android.bluetooth.BluetoothSocket;

import java.io.IOException;
import java.io.OutputStream;

public class BluetoothSender extends Thread {
    private final BluetoothSocket socket;
    private final OutputStream stream;
    private final BluetoothMediaSource mediaSource;
    private boolean error = false;

    public BluetoothSender(BluetoothSocket socket, BluetoothMediaSource mediaSource) throws IOException {
        this.socket = socket;
        this.stream = socket.getOutputStream();
        this.mediaSource = mediaSource;
    }

    public boolean isError() {
        return error;
    }

    @Override
    public void run() {
        try {
            stream.write(this.mediaSource.toBytes());
            cancel();
        } catch (IOException e) {
            error = true;
            e.printStackTrace();
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
