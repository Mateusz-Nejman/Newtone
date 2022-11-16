package com.nejman.nsec.music_player.core.bluetooth;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.support.v4.media.MediaMetadataCompat;

import androidx.annotation.NonNull;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.media.MusicPlaybackService;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.file.Files;

public class BluetoothMediaSource {
    public String artist;
    public String title;
    public byte[] image;
    public byte[] fileData;
    public String fileName;
    public String id;
    public long duration;

    public static BluetoothMediaSource fromMediaSource(MediaSource source)
    {
        BluetoothMediaSource newSource = new BluetoothMediaSource();
        newSource.artist = source.artist;
        newSource.title = source.title;
        newSource.image = source.imageData;
        File file = new File(source.path);
        newSource.fileName = file.getName();
        newSource.id = source.id;
        newSource.duration = source.duration;
        try {
            newSource.fileData = Files.readAllBytes(file.toPath());
        } catch (IOException e) {
            e.printStackTrace();
        }
        return newSource;
    }

    public MediaSource toMediaSource()
    {
        try {
            FileOutputStream fos = new FileOutputStream(Global.musicPath+"/"+fileName);
            fos.write(fileData);
            fos.close();
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }

        return new MediaSource(Global.musicPath+"/"+fileName, artist, title, duration, image, id,"","");
    }
}
