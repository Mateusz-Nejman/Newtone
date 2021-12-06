package com.nejman.nsec.music_player.core.models;

import android.widget.ImageButton;
import android.widget.ImageView;

public class TrackModel {
    public String artist;
    public String title;
    public String path;

    public TrackModel(String artist, String title, String path)
    {
        this.artist = artist;
        this.title = title;
        this.path = path;
    }
}
