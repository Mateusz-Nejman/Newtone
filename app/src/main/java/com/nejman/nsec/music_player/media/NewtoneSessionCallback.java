package com.nejman.nsec.music_player.media;

import android.content.Context;
import android.content.Intent;
import android.media.AudioAttributes;
import android.media.AudioFocusRequest;
import android.media.AudioManager;
import android.os.Bundle;
import android.support.v4.media.session.MediaSessionCompat;
import android.view.KeyEvent;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;

public class NewtoneSessionCallback extends MediaSessionCompat.Callback {
    private final Context context;

    private final MusicNoisyReceiver musicNoisyReceiver = new MusicNoisyReceiver();
    private final MediaSessionCompat mediaSession;
    private final MusicPlaybackService service;
    private final NewtoneMediaPlayer player;
    private AudioFocusRequest audioFocusRequest;

    public NewtoneSessionCallback(MusicPlaybackService service) {
        this.context = service.getBaseContext();
        this.service = service;
        mediaSession = MusicPlaybackService.mediaSession;
        player = NewtoneMediaPlayer.getInstance();
    }


    @Override
    public void onPlay() {
        AudioManager am = (AudioManager) context.getSystemService(Context.AUDIO_SERVICE);
        // Request audio focus for playback, this registers the audioFocusRequest
        AudioAttributes attrs = new AudioAttributes.Builder()
                .setContentType(AudioAttributes.CONTENT_TYPE_MUSIC)
                .build();
        audioFocusRequest = new AudioFocusRequest.Builder(AudioManager.AUDIOFOCUS_GAIN)
                .setOnAudioFocusChangeListener(Global.audioFocusListener)
                .setAudioAttributes(attrs)
                .build();
        int result = am.requestAudioFocus(audioFocusRequest);

        if (result == AudioManager.AUDIOFOCUS_REQUEST_GRANTED) {
            if (MusicPlaybackService.instance == null) {
                MainActivity.instance.getApplicationContext().startForegroundService(new Intent(context, MusicPlaybackService.class));
            }
            mediaSession.setActive(true);
            player.play();
            //service.registerReceiver(musicNoisyReceiver, intentFilter);
            service.updateNotification(true);
        }
    }

    @Override
    public void onStop() {
        AudioManager am = (AudioManager) context.getSystemService(Context.AUDIO_SERVICE);
        if (audioFocusRequest != null) {
            am.abandonAudioFocusRequest(audioFocusRequest);
        }

        service.unregisterReceiver(musicNoisyReceiver);
        service.stopSelf();
        mediaSession.setActive(false);
        player.pause();
        service.stopForeground(false);
    }


    @Override
    public void onPlayFromSearch(String query, Bundle extras) {
        super.onPlayFromSearch(query, extras); //TODO
    }

    @Override
    public void onPause() {
        player.pause();
        service.updateNotification(false);
    }

    @Override
    public void onSkipToNext() {
        player.next();
    }

    @Override
    public void onSkipToPrevious() {
        player.prev();
    }

    @Override
    public boolean onMediaButtonEvent(Intent mediaButtonEvent) {
        KeyEvent ev = mediaButtonEvent.getParcelableExtra(Intent.EXTRA_KEY_EVENT);

        if (ev.getAction() == KeyEvent.ACTION_UP) {
            if (ev.getKeyCode() == KeyEvent.KEYCODE_MEDIA_PLAY) {
                MediaPlayerHelper.play();
            } else if (ev.getKeyCode() == KeyEvent.KEYCODE_MEDIA_PAUSE) {
                MediaPlayerHelper.pause();
            } else if (ev.getKeyCode() == KeyEvent.KEYCODE_MEDIA_PREVIOUS) {
                MediaPlayerHelper.prev();
            } else if (ev.getKeyCode() == KeyEvent.KEYCODE_MEDIA_NEXT) {
                MediaPlayerHelper.next();
            }
        }

        return true;
    }
}
