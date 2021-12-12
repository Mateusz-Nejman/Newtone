package com.nejman.nsec.music_player.ui;

import android.app.Dialog;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.fragment.app.DialogFragment;

import java.util.function.Consumer;

public class AlertDialogFragment extends DialogFragment {
    private final String title;
    private final String message;
    private final String yes;
    private final String no;
    private final Consumer<? super Boolean> consumer;

    public AlertDialogFragment(String title, String message, String yes, String no, Consumer<? super Boolean> consumer) {
        this.title = title;
        this.message = message;
        this.yes = yes;
        this.no = no;
        this.consumer = consumer;
    }

    @NonNull
    @Override
    public Dialog onCreateDialog(@Nullable Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(this.requireActivity());
        builder.setTitle(title).setMessage(message)
                .setPositiveButton(yes, (dialog, id) -> consumer.accept(true))
                .setNegativeButton(no, (dialog, id) -> consumer.accept(false));
        // Create the AlertDialog object and return it
        return builder.create();
    }
}
