package com.nejman.nsec.music_player.core.data;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.loaders.DataLoader;
import com.nejman.nsec.music_player.media.MediaSource;

import java.util.ArrayList;

public class Artists {
    public static void createIfNotExists(String artist)
    {
        DataContainer.getInstance().getArtists().createIfNotExists(artist);
    }

    public static void add(String artist, MediaSource source)
    {
        System.out.println(source.artist+" -> "+source.title);
        DataContainer.getInstance().getArtists().add(source);
    }

    public static void remove(String artist, MediaSource track)
    {
        DataContainer.getInstance().getArtists().remove(artist, track);
    }

    public static void remove(String artist)
    {
        DataContainer.getInstance().getArtists().remove(artist);
    }
}
