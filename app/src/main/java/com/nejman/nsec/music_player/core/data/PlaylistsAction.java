package com.nejman.nsec.music_player.core.data;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.loaders.DataLoader;
import com.nejman.nsec.music_player.core.models.PlaylistModel;
import com.nejman.nsec.music_player.ui.AlertDialogFragment;
import com.nejman.nsec.music_player.ui.ListDialogFragment;
import com.nejman.nsec.music_player.ui.PromptDialogFragment;

import java.util.ArrayList;
import java.util.List;
import java.util.function.Consumer;

public class PlaylistsAction {
    public static void add(String playlistName, List<String> tracks) {
        add(playlistName, tracks, true);
    }

    public static void add(String playlistName, List<String> tracks, boolean save) {
        for (String track : tracks) {
            Playlists.add(playlistName, track);
        }

        if (save) {
            try {
                DataLoader.save();
            } catch (Throwable throwable) {
                throwable.printStackTrace();
            }
        }
    }

    public static void add(List<String> tracks) {
        selectPlaylist(selected -> {
            add(selected, tracks);
            MainActivity.toast(R.string.ready);
        });
    }

    public static void add(String track) {
        selectPlaylist(selected -> {
            Playlists.add(selected, track);
            try {
                DataLoader.save();
            } catch (Throwable throwable) {
                throwable.printStackTrace();
            }
            MainActivity.toast(R.string.ready);
        });
    }

    public static void remove(String playlistName) {
        if (!DataContainer.getInstance().getPlaylists().exists(playlistName)) {
            return;
        }

        AlertDialogFragment alert = new AlertDialogFragment(MainActivity.getResString(R.string.question_delete_playlist), MainActivity.getResString(R.string.question_delete_playlist) + " " + playlistName + "?", MainActivity.getResString(R.string.yes), MainActivity.getResString(R.string.no), selected -> {
            if (!selected) {
                return;
            }
            Playlists.remove(playlistName);
            MainActivity.toast(R.string.ready);
        });
        alert.show(MainActivity.instance.getSupportFragmentManager(), "alert");
    }

    public static void remove(String playlistName, String track) {
        if (!DataContainer.getInstance().getPlaylists().exists(playlistName)) {
            return;
        }

        Playlists.remove(playlistName, track);
        MainActivity.toast(R.string.ready);
    }

    public static void changeName(String playlistName) {
        PromptDialogFragment prompt = new PromptDialogFragment(MainActivity.getResString(R.string.change_name), playlistName, "OK", MainActivity.getResString(R.string.cancel), playlistName, newName -> {
            if (DataContainer.getInstance().getPlaylists().exists(newName)) {
                MainActivity.toast(R.string.playlist_exists);
                return;
            }

            Playlists.changeName(playlistName, newName);
            MainActivity.toast(R.string.ready);
        });

        prompt.show(MainActivity.instance.getSupportFragmentManager(), "prompt");
    }

    private static void selectPlaylist(Consumer<? super String> selected) {
        selectPlaylist("", selected);
    }

    public static void selectPlaylist(String newPlatylistDefaultName, Consumer<? super String> selected) {
        List<String> positions = new ArrayList<>();
        positions.add(MainActivity.getResString(R.string.new_playlist));

        for (PlaylistModel playlist : DataContainer.getInstance().getPlaylists().getAll()) {
            positions.add(playlist.name);
        }

        ListDialogFragment dialog = new ListDialogFragment(MainActivity.getResString(R.string.choose_playlist), positions, selectedInternal -> {
            if (selectedInternal.equals(MainActivity.getResString(R.string.new_playlist))) {
                PromptDialogFragment prompt = new PromptDialogFragment(MainActivity.getResString(R.string.new_playlist), MainActivity.getResString(R.string.new_playlist_hint), MainActivity.getResString(R.string.add), MainActivity.getResString(R.string.cancel), newPlatylistDefaultName.equals("") ? MainActivity.getResString(R.string.new_playlist) : newPlatylistDefaultName, selectedPlaylist -> {
                    Playlists.createIfNotExists(selectedPlaylist);
                    selected.accept(selectedPlaylist);
                });
                prompt.show(MainActivity.instance.getSupportFragmentManager(), "prompt");
            } else {
                selected.accept(selectedInternal);
            }
        });
        dialog.show(MainActivity.instance.getSupportFragmentManager(), "dialog");
    }
}
