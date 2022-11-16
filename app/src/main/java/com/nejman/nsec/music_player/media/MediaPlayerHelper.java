package com.nejman.nsec.music_player.media;

import android.app.Activity;
import android.support.v4.media.session.MediaControllerCompat;

import com.nejman.nsec.music_player.MainActivity;

public class MediaPlayerHelper {
    public static void play() {
        if (cantBeUsed()) {
            return;
        }

        MediaControllerCompat.TransportControls transportControls = getTransportControls();

        if (transportControls != null) {
            transportControls.play();
        }
    }

    public static void pause() {
        if (cantBeUsed()) {
            return;
        }

        MediaControllerCompat.TransportControls transportControls = getTransportControls();

        if (transportControls != null) {
            transportControls.pause();
        }
    }

    public static void stop() {
        if (cantBeUsed()) {
            return;
        }

        MediaControllerCompat.TransportControls transportControls = getTransportControls();

        if (transportControls != null) {
            transportControls.stop();
        }
    }

    public static void prev() {
        if (cantBeUsed()) {
            return;
        }

        MediaControllerCompat.TransportControls transportControls = getTransportControls();

        if (transportControls != null) {
            transportControls.skipToPrevious();
        }
    }

    public static void next() {
        if (cantBeUsed()) {
            return;
        }

        MediaControllerCompat.TransportControls transportControls = getTransportControls();

        if (transportControls != null) {
            transportControls.skipToNext();
        }
    }

    private static boolean cantBeUsed() {
        return MainActivity.instance == null && MusicPlaybackService.instance == null;
    }

    private static Activity getActivity() {
        if (MainActivity.instance != null) {
            return MainActivity.instance;
        }

        return (Activity) MusicPlaybackService.instance.getApplicationContext();
    }

    private static MediaControllerCompat.TransportControls getTransportControls() {
        Activity activity = getActivity();

        if (activity == null) {
            return null;
        }

        MediaControllerCompat mediaController = MediaControllerCompat.getMediaController(activity);

        if (mediaController == null) {
            return null;
        }

        return mediaController.getTransportControls();
    }
}
