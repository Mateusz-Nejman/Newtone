package com.nejman.nsec.music_player.core.bluetooth;

import android.Manifest;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.pm.PackageManager;

import androidx.core.app.ActivityCompat;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.media.MediaSource;

import java.util.ArrayList;
import java.util.List;
import java.util.Set;

public class BluetoothManager {
    public static final java.util.UUID UUID = java.util.UUID.fromString("c81d4e2e-bcf2-11e6-869b-7df92533d2db");
    private final BluetoothAdapter adapter;
    private final boolean sendFlag;

    public BluetoothManager(android.bluetooth.BluetoothManager manager) {
        this.adapter = manager.getAdapter();
        this.sendFlag = this.adapter != null;
    }

    public BluetoothInputThread getInputThread() {
        return new BluetoothInputThread();
    }

    public BluetoothOutputThread getOutputThread(BluetoothDeviceModel deviceModel, MediaSource mediaSource) {
        return new BluetoothOutputThread(deviceModel, mediaSource);
    }

    public BluetoothAdapter getAdapter() {
        return this.adapter;
    }

    public boolean canSend() {
        return sendFlag;
    }

    public List<BluetoothDeviceModel> getPairedDevices() {
        List<BluetoothDeviceModel> models = new ArrayList<>();
        if (ActivityCompat.checkSelfPermission(MainActivity.instance, Manifest.permission.BLUETOOTH_CONNECT) != PackageManager.PERMISSION_GRANTED) {
            return models;
        }
        Set<BluetoothDevice> devices = adapter.getBondedDevices();

        for (BluetoothDevice device : devices) {
            BluetoothDeviceModel model = new BluetoothDeviceModel();
            model.name = device.getName();
            model.address = device.getAddress();
            model.device = device;

            models.add(model);
        }

        return models;
    }
}
