package com.nejman.nsec.music_player.ui.bluetooth;

import android.annotation.SuppressLint;
import android.app.Dialog;
import android.os.Bundle;
import android.util.ArrayMap;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.RadioGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.widget.AppCompatRadioButton;
import androidx.core.content.ContextCompat;
import androidx.fragment.app.DialogFragment;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.bluetooth.BluetoothDeviceModel;
import com.nejman.nsec.music_player.core.bluetooth.BluetoothOutputThread;
import com.nejman.nsec.music_player.media.MediaSource;

import java.util.List;
import java.util.Objects;

import io.reactivex.rxjava3.disposables.Disposable;

public class BluetoothSendFragment extends DialogFragment {
    private BluetoothOutputThread outputThread;
    private MediaSource mediaSource;
    private Disposable onConnected;
    private Disposable onError;
    private Disposable onSent;
    private ArrayMap<Integer, BluetoothDeviceModel> devices;
    private RadioGroup radioGroup;
    private TextView selectedDevice;
    private TextView statusText;

    public BluetoothSendFragment(MediaSource mediaSource) {
        this.mediaSource = mediaSource;
    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setStyle(DialogFragment.STYLE_NORMAL, android.R.style.Theme_Translucent_NoTitleBar);
        devices = new ArrayMap<>();
    }

    @NonNull
    @Override
    public Dialog onCreateDialog(@Nullable Bundle savedInstanceState) {
        Bundle arguments = getArguments();
        View view = getLayoutInflater().inflate(R.layout.fragment_bluetooth_send, null);
        view.setLayoutParams(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.MATCH_PARENT));
        this.selectedDevice = view.findViewById(R.id.selected_device_text);
        this.statusText = view.findViewById(R.id.status_text);
        this.radioGroup = view.findViewById(R.id.devices_group);
        // creating the fullscreen dialog
        final Dialog dialog = new Dialog(getActivity());
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setContentView(view);
        dialog.getWindow().setLayout(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.MATCH_PARENT);
        assert arguments != null;
        String mediaSourcePath = arguments.getString("mediaSourcePath");
        mediaSource = DataContainer.getInstance().getMediaSources().get(mediaSourcePath);
        showDeviceButtons();
        return dialog;
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();

        if (outputThread != null && outputThread.isAlive()) {
            outputThread.cancel();
            outputThread = null;
        }

        if (onError != null) {
            onError.dispose();
        }

        if (onSent != null) {
            onSent.dispose();
        }

        if (onConnected != null) {
            onConnected.dispose();
        }
    }

    @SuppressLint("ResourceAsColor")
    private void showDeviceButtons() {
        List<BluetoothDeviceModel> bluetoothDevices = MainActivity.bluetoothManager.getPairedDevices();
        devices.clear();
        radioGroup.removeAllViews();

        for (BluetoothDeviceModel device :
                bluetoothDevices) {
            int id = View.generateViewId();
            devices.put(id, device);
            AppCompatRadioButton radioButton = new AppCompatRadioButton(requireContext());
            radioButton.setText(device.name);
            radioButton.setId(id);
            radioButton.setTextColor(ContextCompat.getColor(requireContext(), R.color.white));
            radioButton.setOnClickListener(view -> {
                if (devices.containsKey(id)) {
                    selectDevice(Objects.requireNonNull(devices.get(id)));
                }
            });
            radioGroup.addView(radioButton);
        }
    }

    private void selectDevice(BluetoothDeviceModel model) {
        this.selectedDevice.setText(model.name);
        this.statusText.setText(R.string.bluetooth_status_waiting);
        if (this.outputThread != null && this.outputThread.isAlive()) {
            this.outputThread.cancel();
        }
        this.outputThread = MainActivity.bluetoothManager.getOutputThread(model, this.mediaSource);
        onConnected = this.outputThread.addOnDeviceConnected(deviceModel -> MainActivity.instance.runOnUiThread(() -> {
            selectedDevice.setText(deviceModel.name);
            statusText.setText(R.string.bluetooth_status_sending);
        }));
        onError = this.outputThread.addOnDeviceError(error -> {
            error.printStackTrace();
            MainActivity.toast(R.string.bluetooth_status_error);
            dismiss();
        });
        onSent = this.outputThread.addOnFileSent(source -> {
            MainActivity.toast(MainActivity.getResString(R.string.bluetooth_status_sent) + " " + source.artist + " - " + source.title);
            dismiss();
        });

        this.outputThread.start();
    }
}
