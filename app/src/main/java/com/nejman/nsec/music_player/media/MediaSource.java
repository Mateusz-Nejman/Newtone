package com.nejman.nsec.music_player.media;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.support.v4.media.MediaMetadataCompat;

import androidx.annotation.NonNull;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;


public class MediaSource {
    public String artist;
    public String title;
    public long duration;
    public Bitmap image;
    public String path;
    public String id;
    public String imageUrl;
    public String playlistId;
    public boolean isLocal;

    public MediaSource(String path, String artist, String title, long duration, Bitmap image, String id, String imageUrl, String playlistId) {
        this.artist = artist;
        this.title = title;
        this.duration = duration;
        this.image = image;
        this.path = path;
        this.id = id;
        this.imageUrl = imageUrl;
        this.playlistId = playlistId;
        this.isLocal = !path.startsWith("https://") && path.length() > 11;
    }

    public String getDurationString() {
        int hours = (int) (duration / 3600000);
        int minutes = (int) ((duration - (hours * 3600000)) / 60000);
        int seconds = (int) ((duration - (hours * 3600000) - (minutes * 60000))) / 1000;

        String durationString = "";

        if (hours > 0) {
            durationString += hours + ":";
        }

        durationString += String.format("%1$" + 2 + "s", minutes).replace(' ', '0') + ":";
        durationString += String.format("%1$" + 2 + "s", seconds).replace(' ', '0');

        return durationString;
    }

    public MediaMetadataCompat toMetaData() {

        return MusicPlaybackService.metadataBuilder
                .putString(MediaMetadataCompat.METADATA_KEY_TITLE, this.title)
                .putString(MediaMetadataCompat.METADATA_KEY_ARTIST, this.artist)
                .putLong(MediaMetadataCompat.METADATA_KEY_DURATION, this.duration)
                .putBitmap(MediaMetadataCompat.METADATA_KEY_ART, this.image == null ? BitmapFactory.decodeResource(MainActivity.instance.getResources(), R.drawable.empty_track) : this.image)
                .putString(MediaMetadataCompat.METADATA_KEY_MEDIA_ID, this.id).build();
    }

    @NonNull
    @Override
    public MediaSource clone() {
        return new MediaSource(path, artist, title, duration, image, id, imageUrl, playlistId);
    }
}
