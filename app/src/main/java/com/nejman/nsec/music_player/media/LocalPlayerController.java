package com.nejman.nsec.music_player.media;

import android.media.MediaPlayer;

import com.nejman.nsec.music_player.core.loaders.DataLoader;

import java.io.IOException;

public class LocalPlayerController implements IPlayerController {
    @Override
    public void load(MediaPlayer mediaPlayer, String path) throws IOException {
        mediaPlayer.setDataSource(path);
    }

    @Override
    public void loaded(MediaPlayer mediaPlayer) {
        try {
            DataLoader.playerStateLoader.save();
        } catch (Throwable e) {
            e.printStackTrace();
        }
    }
}
