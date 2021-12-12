package com.nejman.nsec.music_player.ui;

import android.app.Dialog;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.fragment.app.DialogFragment;

import java.util.List;
import java.util.function.Consumer;

public class ListDialogFragment extends DialogFragment {
    private final List<String> elements;
    private final Consumer<? super String> selected;
    private final String title;

    public ListDialogFragment(String title, List<String> elements, Consumer<? super String> selected) {
        this.elements = elements;
        this.selected = selected;
        this.title = title;
    }

    @NonNull
    @Override
    public Dialog onCreateDialog(@Nullable Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(requireActivity());
        builder.setTitle(title);
        builder.setItems(elements.toArray(new String[0]), (dialog, which) -> selected.accept(elements.get(which)));
        return builder.create();
    }
}
