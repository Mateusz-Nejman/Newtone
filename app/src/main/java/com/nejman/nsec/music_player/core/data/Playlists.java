package com.nejman.nsec.music_player.core.data;

import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.loaders.DataLoader;
import com.nejman.nsec.music_player.core.models.PlaylistModel;
import com.nejman.nsec.music_player.media.MediaSource;

import java.util.ArrayList;

public class Playlists {
    public static void createIfNotExists(String playlistName) {
        if (DataContainer.getInstance().getPlaylists().exists(playlistName)) {
            return;
        }

        DataContainer.getInstance().getPlaylists().addPlaylist(playlistName, new PlaylistModel(playlistName, null, new ArrayList<>()));
    }

    public static void add(String playlistName, MediaSource track) {
        add(playlistName, track.path);
    }

    public static void add(String playlistName, String track) {
        createIfNotExists(playlistName);

        if (DataContainer.getInstance().getPlaylists().contains(playlistName, track)) {
            return;
        }

        DataContainer.getInstance().getPlaylists().addToPlaylist(playlistName, track);
    }

    public static void remove(String playlistName) {
        if (!DataContainer.getInstance().getPlaylists().exists(playlistName)) {
            return;
        }

        DataContainer.getInstance().getPlaylists().removePlaylist(playlistName);
        try {
            DataLoader.save();
        } catch (Throwable throwable) {
            throwable.printStackTrace();
        }
    }

    public static void remove(String playlistName, MediaSource track) {
        remove(playlistName, track.path);
    }

    public static void remove(String playlistName, String filepath) {
        if (!DataContainer.getInstance().getPlaylists().exists(playlistName)) {
            return;
        }

        PlaylistModel model = DataContainer.getInstance().getPlaylists().get(playlistName);
        model.items.remove(filepath);
        DataContainer.getInstance().getPlaylists().editPlaylist(playlistName, model);
        try {
            DataLoader.save();
        } catch (Throwable throwable) {
            throwable.printStackTrace();
        }
    }

    public static void changeName(String oldName, String newName) {
        if (!DataContainer.getInstance().getPlaylists().exists(oldName)) {
            return;
        }

        if (DataContainer.getInstance().getPlaylists().exists(newName)) {
            return;
        }

        PlaylistModel model = DataContainer.getInstance().getPlaylists().get(oldName);
        model.name = newName;

        DataContainer.getInstance().getPlaylists().addPlaylist(newName, model);
        DataContainer.getInstance().getPlaylists().removePlaylist(oldName);
        try {
            DataLoader.save();
        } catch (Throwable throwable) {
            throwable.printStackTrace();
        }
    }
}
