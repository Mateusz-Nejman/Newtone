package com.nejman.nsec.music_player.core.data;

import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.media.MediaSource;

public class Artists {

    public static void add(MediaSource source) {
        DataContainer.getInstance().getArtists().add(source);
    }

    public static void remove(String artist, MediaSource track) {
        DataContainer.getInstance().getArtists().remove(artist, track);
    }

    public static void remove(String artist) {
        DataContainer.getInstance().getArtists().remove(artist);
    }
}
