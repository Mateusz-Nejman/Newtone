package com.nejman.nsec.music_player.media;

import android.content.Context;
import android.content.Intent;
import android.view.KeyEvent;

import androidx.media.session.MediaButtonReceiver;

public class NotificationButtonReceiver extends MediaButtonReceiver {
    @Override
    public void onReceive(Context context, Intent intent) {
        if(intent == null)
        {
            return;
        }

        KeyEvent ev = (KeyEvent) intent.getParcelableExtra(Intent.EXTRA_KEY_EVENT);

        if(ev == null)
        {
            return;
        }

        if(ev.getAction() == KeyEvent.ACTION_DOWN)
        {
            System.out.println("down");
            if(ev.getKeyCode() == KeyEvent.KEYCODE_MEDIA_PLAY)
            {
                MediaPlayerHelper.play();
            }
            else if(ev.getKeyCode() == KeyEvent.KEYCODE_MEDIA_PAUSE)
            {
                System.out.println("ev.getKeyCode() == KeyEvent.KEYCODE_MEDIA_PAUSE");
                MediaPlayerHelper.pause();
            }
            else if(ev.getKeyCode() == KeyEvent.KEYCODE_MEDIA_PREVIOUS)
            {
                MediaPlayerHelper.prev();
            }
            else if(ev.getKeyCode() == KeyEvent.KEYCODE_MEDIA_NEXT)
            {
                MediaPlayerHelper.next();
            }
        }
    }
}
