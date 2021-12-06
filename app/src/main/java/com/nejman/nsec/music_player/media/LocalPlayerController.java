package com.nejman.nsec.music_player.media;

import android.media.MediaPlayer;

import java.io.IOException;

public class LocalPlayerController implements IPlayerController{
    @Override
    public void load(MediaPlayer mediaPlayer, String path) throws IOException {
        mediaPlayer.setDataSource(path);
    }

    @Override
    public void loaded(MediaPlayer mediaPlayer) {

    }

    @Override
    public void prepared(MediaPlayer mediaPlayer) {
        NewtoneMediaPlayer.getInstance().play();
    }

    @Override
    public void completed(MediaPlayer mediaPlayer) {
        NewtoneMediaPlayer.getInstance().next();
    }
}
