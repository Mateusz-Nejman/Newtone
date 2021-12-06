package com.nejman.nsec.music_player.media;

import android.media.AudioManager;

public class AudioFocusListener implements AudioManager.OnAudioFocusChangeListener {
    @Override
    public void onAudioFocusChange(int focusChange) {
        //TODO break when TV

        if(focusChange == AudioManager.AUDIOFOCUS_LOSS && NewtoneMediaPlayer.getInstance().getCurrentPosition() > 10000)
        {
            System.out.println("AudioManager.AUDIOFOCUS_LOSS_TRANSIENT focusChange");
            //MediaPlayerHelper.pause();
        }

        if(focusChange == AudioManager.AUDIOFOCUS_LOSS_TRANSIENT_CAN_DUCK)
        {
            NewtoneMediaPlayer.getInstance().setVolume(0.1f);
        }

        if(focusChange == AudioManager.AUDIOFOCUS_GAIN)
        {
            NewtoneMediaPlayer.getInstance().setVolume(1.0f);

            if(!NewtoneMediaPlayer.getInstance().isPlaying())
            {
                NewtoneMediaPlayer.getInstance().play();
            }
        }

        if(focusChange == AudioManager.AUDIOFOCUS_LOSS_TRANSIENT)
        {
            System.out.println("AudioManager.AUDIOFOCUS_LOSS_TRANSIENT");
            MediaPlayerHelper.pause();
        }
    }
}
