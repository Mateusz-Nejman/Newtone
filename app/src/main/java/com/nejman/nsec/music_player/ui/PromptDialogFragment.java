package com.nejman.nsec.music_player.ui;

import android.app.Dialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AlertDialog;
import androidx.fragment.app.DialogFragment;

import com.nejman.nsec.music_player.R;

import java.util.Objects;
import java.util.function.Consumer;

public class PromptDialogFragment extends DialogFragment {

    private final String title;
    private final String message;
    private final String yes;
    private final String no;
    private final Consumer<? super String> consumer;
    private final String defaultValue;

    public PromptDialogFragment(String title, String message, String yes, String no, String defaultValue, Consumer<? super String> consumer)
    {
        this.title = title;
        this.message = message;
        this.yes = yes;
        this.no = no;
        this.consumer = consumer;
        this.defaultValue = defaultValue;
    }

    @NonNull
    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(requireActivity());
        LayoutInflater inflater = requireActivity().getLayoutInflater();

        View view = inflater.inflate(R.layout.input_dialog, null);
        ((TextView)view.findViewById(R.id.inputTitle)).setText(message);
        EditText input = (EditText)view.findViewById(R.id.inputBox);
        input.setText(defaultValue);
        builder.setView(view).setTitle(title)
                // Add action buttons
                .setPositiveButton(yes, (dialog, id) -> {
                    consumer.accept(input.getText().toString());
                })
                .setNegativeButton(no, (dialog, id) -> {
                    consumer.accept(input.getText().toString());
                    Objects.requireNonNull(PromptDialogFragment.this.getDialog()).cancel();
                });
        return builder.create();
    }
}
