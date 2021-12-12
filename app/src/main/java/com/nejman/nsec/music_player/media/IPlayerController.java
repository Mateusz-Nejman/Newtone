package com.nejman.nsec.music_player.media;

import android.media.MediaPlayer;

import java.io.IOException;

public interface IPlayerController {
    void load(MediaPlayer mediaPlayer, String path) throws IOException;

    void loaded(MediaPlayer mediaPlayer);
}
