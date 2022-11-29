package com.nejman.nsec.music_player.media;

import static androidx.media.MediaBrowserServiceCompat.BrowserRoot.EXTRA_RECENT;

import android.app.Notification;
import android.app.PendingIntent;
import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.os.IBinder;
import android.support.v4.media.MediaBrowserCompat;
import android.support.v4.media.MediaDescriptionCompat;
import android.support.v4.media.MediaMetadataCompat;
import android.support.v4.media.session.MediaControllerCompat;
import android.support.v4.media.session.MediaSessionCompat;
import android.support.v4.media.session.PlaybackStateCompat;

import androidx.annotation.NonNull;
import androidx.core.app.NotificationCompat;
import androidx.media.MediaBrowserServiceCompat;
import androidx.media.session.MediaButtonReceiver;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class MusicPlaybackService extends MediaBrowserServiceCompat {
    private static final String RECENT_ROOT = "recent_root";
    private static final String BROWSABLE_ROOT = "browsable_root";
    public static MediaSessionCompat mediaSession;
    public static PlaybackStateCompat.Builder stateBuilder;
    public static MediaMetadataCompat.Builder metadataBuilder;
    public static MusicPlaybackService instance;

    @Override
    public void onCreate() {
        super.onCreate();
        instance = this;
        // Create a MediaSessionCompat
        mediaSession = new MediaSessionCompat(this.getBaseContext(), "Newtone Lightning");

        Intent intent = new Intent(getBaseContext(), MainActivity.class);
        PendingIntent pendingIntent = PendingIntent.getActivity(getBaseContext(), 99, intent, PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_IMMUTABLE);
        mediaSession.setSessionActivity(pendingIntent);
        mediaSession.setFlags(MediaSessionCompat.FLAG_HANDLES_QUEUE_COMMANDS);

        metadataBuilder = new MediaMetadataCompat.Builder();
        // Set an initial PlaybackState with ACTION_PLAY, so media buttons can start the player
        stateBuilder = new PlaybackStateCompat.Builder()
                .setActions(
                        PlaybackStateCompat.ACTION_PLAY |
                                PlaybackStateCompat.ACTION_PLAY_FROM_SEARCH |
                                PlaybackStateCompat.ACTION_PLAY_FROM_URI |
                                PlaybackStateCompat.ACTION_PLAY_FROM_MEDIA_ID |
                                PlaybackStateCompat.ACTION_PREPARE |
                                PlaybackStateCompat.ACTION_PREPARE_FROM_MEDIA_ID |
                                PlaybackStateCompat.ACTION_PREPARE_FROM_SEARCH |
                                PlaybackStateCompat.ACTION_PREPARE_FROM_URI);
        mediaSession.setPlaybackState(stateBuilder.build());

        // MySessionCallback() has methods that handle callbacks from a media controller
        mediaSession.setCallback(new NewtoneSessionCallback(this));

        // Set the session's token so that client activities can communicate with it.
        setSessionToken(mediaSession.getSessionToken());

        updateNotification(false);
    }

    @Override
    public BrowserRoot onGetRoot(@NonNull String clientPackageName, int clientUid,
                                 Bundle rootHints) {
        Bundle rootExtras = new Bundle();
        rootExtras.putBoolean("android.media.browse.SEARCH_SUPPORTED", true);
        rootExtras.putBoolean("android.media.browse.CONTENT_STYLE_SUPPORTED", true);
        rootExtras.putInt("android.media.browse.CONTENT_STYLE_BROWSABLE_HINT", 2);
        rootExtras.putInt("android.media.browse.CONTENT_STYLE_PLAYABLE_HINT", 1);

        boolean current = true;

        if (rootHints != null) {
            current = rootHints.getBoolean(EXTRA_RECENT, false);
        }

        return new BrowserRoot(current ? RECENT_ROOT : BROWSABLE_ROOT, rootExtras);
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        MediaButtonReceiver.handleIntent(mediaSession, intent);

        return Service.START_STICKY;
    }

    @Override
    public void onLoadChildren(@NonNull final String parentMediaId,
                               @NonNull final Result<List<MediaBrowserCompat.MediaItem>> result) {
        if (parentMediaId.equals(RECENT_ROOT)) {
            if (Global.currentSource != null) {
                result.sendResult(Collections.singletonList(Global.currentSource.toMediaItem()));
            }
        } else if (parentMediaId.equals(BROWSABLE_ROOT)) {
            List<MediaBrowserCompat.MediaItem> items = new ArrayList<>();

            for (MediaSource source : Global.currentPlaylist) {
                items.add(source.toMediaItem());
            }

            result.sendResult(items);
        }
        result.sendResult(null);
    }

    @Override
    public IBinder onBind(Intent intent) {
        return super.onBind(intent);
    }

    public void updateNotification(boolean isPlaying) {
        Context context = this.getBaseContext();

        MediaControllerCompat controller = mediaSession.getController();
        MediaMetadataCompat mediaMetadata = controller.getMetadata();

        if (mediaMetadata == null) {
            return;
        }
        MediaDescriptionCompat description = mediaMetadata.getDescription();
        NotificationCompat.Builder builder = new NotificationCompat.Builder(context, "Newtone Lightning");

        builder
                .setContentTitle(description.getTitle())
                .setContentText(description.getSubtitle())
                .setSubText(description.getSubtitle())

                .setContentIntent(controller.getSessionActivity())

                .setDeleteIntent(MediaButtonReceiver.buildMediaButtonPendingIntent(context,
                        PlaybackStateCompat.ACTION_STOP))

                .setVisibility(NotificationCompat.VISIBILITY_PUBLIC)
                .setSmallIcon(R.drawable.play_icon_notification)
                .setOngoing(true)
                .setLargeIcon(description.getIconBitmap())

                // Add a pause button
                .addAction(
                        new NotificationCompat.Action(
                                R.drawable.prev_icon_notification,
                                "prev",
                                MediaButtonReceiver.buildMediaButtonPendingIntent(context, PlaybackStateCompat.ACTION_SKIP_TO_PREVIOUS
                                )
                        )
                )
                .addAction(
                        new NotificationCompat.Action(
                                isPlaying ? R.drawable.pause_icon_notification : R.drawable.play_icon_notification,
                                "pause",
                                MediaButtonReceiver.buildMediaButtonPendingIntent(context, isPlaying ? PlaybackStateCompat.ACTION_PAUSE : PlaybackStateCompat.ACTION_PLAY
                                )
                        )
                )
                .addAction(
                        new NotificationCompat.Action(
                                R.drawable.next_icon_notification,
                                "next",
                                MediaButtonReceiver.buildMediaButtonPendingIntent(context, PlaybackStateCompat.ACTION_SKIP_TO_NEXT
                                )
                        )
                )

                // Take advantage of MediaStyle features
                .setStyle(new androidx.media.app.NotificationCompat.MediaStyle()
                        .setMediaSession(mediaSession.getSessionToken())
                        .setShowActionsInCompactView(0, 1, 2)

                        // Add a cancel button
                        .setShowCancelButton(true)
                        .setCancelButtonIntent(MediaButtonReceiver.buildMediaButtonPendingIntent(context,
                                PlaybackStateCompat.ACTION_STOP)));

        mediaSession.setMetadata(Global.currentSource == null ? null : Global.currentSource.toMetaData());
        stateBuilder.setState(isPlaying ? PlaybackStateCompat.STATE_PLAYING : PlaybackStateCompat.STATE_PAUSED, NewtoneMediaPlayer.getInstance().getCurrentPosition(), isPlaying ? 1.0f : 0.0f);
        mediaSession.setPlaybackState(stateBuilder.build());
        Notification notification = builder.build();
        startForeground(1, notification);
        MainActivity.notificationManager.notify(1, notification);
    }
}