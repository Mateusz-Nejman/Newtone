package com.nejman.nsec.music_player.core.models;

import android.graphics.Bitmap;

import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.media.MediaSource;

import java.util.ArrayList;
import java.util.List;

public class PlaylistModel {
    public String name;
    public Bitmap image;
    public List<String> items;

    public PlaylistModel(String name, Bitmap image, List<String> items)
    {
        this.name = name;
        this.image = image;
        this.items = items;
    }

    public List<MediaSource> getSources()
    {
        List<MediaSource> sources = new ArrayList<>();

        for(String filepath : items)
        {
            sources.add(DataContainer.getInstance().getMediaSources().get(filepath));
        }

        return sources;
    }
}
