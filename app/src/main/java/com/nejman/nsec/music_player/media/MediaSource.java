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
    public final long duration;
    public Bitmap image;
    public final byte[] imageData;
    public final String path;
    public final String id;
    public final String imageUrl;
    public final String playlistId;
    public final boolean isLocal;

    public MediaSource(String path, String artist, String title, long duration, byte[] image, String id, String imageUrl, String playlistId) {
        this.artist = artist;
        this.title = title;
        this.duration = duration;
        this.imageData = image;

        if (image != null) {
            this.image = BitmapFactory.decodeByteArray(image, 0, image.length);
        }

        this.path = path;
        this.id = id;
        this.imageUrl = imageUrl;
        this.playlistId = playlistId;
        this.isLocal = !path.startsWith("https://") && path.length() > 11;
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
        return new MediaSource(path, artist, title, duration, imageData, id, imageUrl, playlistId);
    }
}
