package com.nejman.nsec.music_player.media;

import android.media.AudioManager;

import com.nejman.nsec.music_player.Global;

public class AudioFocusListener implements AudioManager.OnAudioFocusChangeListener {
    private boolean previousPlaying = false;
    @Override
    public void onAudioFocusChange(int focusChange) {
        if (Global.ignoreAutoFocus) {
            return;
        }
        //TODO break when TV

        if (focusChange == AudioManager.AUDIOFOCUS_LOSS && NewtoneMediaPlayer.getInstance().getCurrentPosition() > 10000) {
            previousPlaying = NewtoneMediaPlayer.getInstance().isPlaying();
            MediaPlayerHelper.pause();
        }

        if (focusChange == AudioManager.AUDIOFOCUS_LOSS_TRANSIENT_CAN_DUCK) {
            NewtoneMediaPlayer.getInstance().setVolume(0.1f);
        }

        if (focusChange == AudioManager.AUDIOFOCUS_GAIN) {
            NewtoneMediaPlayer.getInstance().setVolume(1.0f);

            if (!NewtoneMediaPlayer.getInstance().isPlaying() && previousPlaying) {
                NewtoneMediaPlayer.getInstance().play();
            }
        }

        if (focusChange == AudioManager.AUDIOFOCUS_LOSS_TRANSIENT) {
            previousPlaying = NewtoneMediaPlayer.getInstance().isPlaying();
            MediaPlayerHelper.pause();
        }
    }
}
