package com.nejman.nsec.music_player.ui.bluetooth;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.bluetooth.BluetoothInputThread;
import com.nejman.nsec.music_player.databinding.FragmentBluetoothBinding;
import com.nejman.nsec.music_player.ui.WrappedFragment;

import io.reactivex.rxjava3.disposables.Disposable;

public class BluetoothFragment extends WrappedFragment {
    private FragmentBluetoothBinding binding;
    private BluetoothInputThread inputThread;
    private Disposable onConnected;
    private Disposable onError;
    private Disposable onReceived;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        binding = FragmentBluetoothBinding.inflate(inflater, container, false);
        View root = binding.getRoot();
        showBluetoothButton(false);
        inputThread = MainActivity.bluetoothManager.getInputThread();
        onConnected = inputThread.addOnDeviceConnected(deviceModel -> MainActivity.instance.runOnUiThread(() -> {
            binding.selectedDeviceText.setText(deviceModel.name);
            binding.statusText.setText(R.string.bluetooth_status_connected);
        }));
        onError = inputThread.addOnDeviceError(error -> {
            error.printStackTrace();
            MainActivity.toast(R.string.bluetooth_status_error);
        });
        onReceived = inputThread.addOnFileReceived(source -> MainActivity.toast(MainActivity.getResString(R.string.bluetooth_status_received) + " " + source.artist + " - " + source.title));
        inputThread.start();
        return root;
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        showDownloadButton(true);
        binding = null;

        if (onConnected != null) {
            onConnected.dispose();
        }

        if (onError != null) {
            onError.dispose();
        }

        if (onReceived != null) {
            onReceived.dispose();
        }

        if (this.inputThread != null && this.inputThread.isAlive()) {
            inputThread.cancel();
            inputThread = null;
        }

        onConnected = null;
        onError = null;
        onReceived = null;
    }

    @Override
    protected String getTitle() {
        return MainActivity.getResString(R.string.bluetooth);
    }
}
