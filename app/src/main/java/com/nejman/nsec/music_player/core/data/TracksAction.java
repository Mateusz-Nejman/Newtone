package com.nejman.nsec.music_player.core.data;

import android.widget.Toast;

import androidx.fragment.app.DialogFragment;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.ui.AlertDialogFragment;
import com.nejman.nsec.music_player.ui.PromptDialogFragment;

public class TracksAction {
    public static void remove(MediaSource track) {
        remove(track.path);
    }

    public static void remove(String path) {
        DialogFragment dialog = new AlertDialogFragment(MainActivity.getResString(R.string.question_delete) + "?", MainActivity.getResString(R.string.question_delete) + " " + path + "?", MainActivity.getResString(R.string.yes), MainActivity.getResString(R.string.no), confirm -> {
            Tracks.remove(path);
        });
        dialog.show(MainActivity.instance.getSupportFragmentManager(), "remove");
    }

    public static void edit(String track) {
        if (!DataContainer.getInstance().getMediaSources().exists(track)) {
            return;
        }

        edit(DataContainer.getInstance().getMediaSources().get(track));
    }

    public static void edit(MediaSource track) {
        PromptDialogFragment artistPrompt = new PromptDialogFragment(MainActivity.getResString(R.string.artist), track.artist, MainActivity.getResString(R.string.save), MainActivity.getResString(R.string.cancel), track.artist, newArtist -> {
            if (newArtist == null) {
                return;
            }

            PromptDialogFragment tracksPrompt = new PromptDialogFragment(MainActivity.getResString(R.string.title), track.title, MainActivity.getResString(R.string.save), MainActivity.getResString(R.string.cancel), track.title, newTitle -> {
                if (newTitle == null) {
                    return;
                }

                Tracks.edit(track, newArtist, newTitle);
            });
            tracksPrompt.show(MainActivity.instance.getSupportFragmentManager(), "track");
        });
        artistPrompt.show(MainActivity.instance.getSupportFragmentManager(), "artist");
    }
}
