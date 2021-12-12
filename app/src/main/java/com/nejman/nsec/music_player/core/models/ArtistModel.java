package com.nejman.nsec.music_player.core.models;

import android.graphics.Bitmap;

import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.media.MediaSource;

import java.util.ArrayList;
import java.util.List;

public class ArtistModel {
    public String name;
    public List<String> items;
    public Bitmap image;

    public ArtistModel(String name, List<String> items) {
        this.name = name;
        this.items = items;
    }

    public List<MediaSource> getSources() {
        List<MediaSource> sources = new ArrayList<>();

        for (String filepath : items) {
            sources.add(DataContainer.getInstance().getMediaSources().get(filepath));
        }

        return sources;
    }
}
