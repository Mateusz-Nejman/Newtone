package com.nejman.nsec.music_player.media;

import android.media.AudioAttributes;
import android.media.MediaPlayer;
import android.support.v4.media.session.MediaSessionCompat;
import android.support.v4.media.session.PlaybackStateCompat;
import android.widget.Toast;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class NewtoneMediaPlayer {
    public static NewtoneMediaPlayer instance;

    public static NewtoneMediaPlayer getInstance() {
        if (instance == null) {
            instance = new NewtoneMediaPlayer();
        }
        return instance;
    }

    private final MediaPlayer player;
    private final IPlayerController webPlayerController;
    private final IPlayerController localPlayerController;
    private final List<Integer> randomIndexes;
    private final Random random;
    private boolean prepared = false;

    public NewtoneMediaPlayer() {
        this.random = new Random();
        this.randomIndexes = new ArrayList<>();
        this.webPlayerController = new WebPlayerController();
        this.localPlayerController = new LocalPlayerController();
        this.player = new MediaPlayer();
        this.player.setAudioAttributes(
                new AudioAttributes.Builder()
                        .setContentType(AudioAttributes.CONTENT_TYPE_MUSIC)
                        .setUsage(AudioAttributes.USAGE_MEDIA)
                        .build()
        );
        this.player.setOnPreparedListener(mp -> {
            prepared = true;
            MediaPlayerHelper.play();
            seek(0);
        });
        this.player.setOnCompletionListener(mp -> {
            if (player.getCurrentPosition() > 0 && prepared) {
                MediaPlayerHelper.next();
            }
        });
        this.player.setOnInfoListener((mp, what, extra) -> {
            if (what == MediaPlayer.MEDIA_INFO_BUFFERING_START) {
                setPlaybackState(PlaybackStateCompat.STATE_PAUSED, player.getCurrentPosition(), 0);
                MusicPlaybackService.instance.updateNotification(false);
            }
            if (what == MediaPlayer.MEDIA_INFO_BUFFERING_END) {
                updateMetadata();
            }
            return true;
        });
    }

    private IPlayerController getController(String path) {
        if (path.length() == 11 || path.startsWith("https://")) {
            return this.webPlayerController;
        }

        return this.localPlayerController;
    }

    private void load(String path) {
        try {
            pause();
            player.reset();
            getController(path).load(player, path);
            getController(path).loaded(player);
            prepared = false;
            player.prepareAsync();
            MainActivity.instance.navigationView.getMenu().findItem(R.id.navigation_player).setVisible(true);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void load(MediaSource source) {
        load(source.path);
        Global.currentSource = source;

        try {
            MainActivity.instance.updatePlayerSource(source);
        } catch (Exception ignore) {

        }
    }

    public void loadPlaylist(List<MediaSource> playlist, int startIndex) {
        Global.currentPlaylist.clear();
        Global.currentPlaylist.addAll(playlist);
        Global.currentPlaylistPosition = startIndex;

        load(Global.currentPlaylist.get(startIndex));
        updateMetadata();
    }

    private void setPlaybackState(int state, long position, float playbackSpeed) {
        MediaSessionCompat mediaSession = MusicPlaybackService.mediaSession;
        mediaSession.setPlaybackState(
                MusicPlaybackService.stateBuilder.setState(
                        state,
                        position,
                        playbackSpeed).build());
    }

    private void updateMetadata() {
        if (Global.currentSource == null) {
            return;
        }
        MediaSessionCompat mediaSession = MusicPlaybackService.mediaSession;
        mediaSession.setMetadata(Global.currentSource.toMetaData());
        System.out.println("Current position " + player.getCurrentPosition());
        setPlaybackState(PlaybackStateCompat.STATE_NONE,
                player.getCurrentPosition(),
                1.0f);
        setPlaybackState(player.isPlaying() ? PlaybackStateCompat.STATE_PLAYING : PlaybackStateCompat.STATE_PAUSED,
                player.getCurrentPosition(),
                player.isPlaying() ? 1.0f : 0);

        MusicPlaybackService.instance.updateNotification(player.isPlaying());
    }

    public void play() {
        this.player.start();
        updateMetadata();

        try {
            MainActivity.instance.updatePlayerState(true);
        } catch (Exception ignore) {

        }
    }

    public void prev() {
        if (Global.currentPlaylist.size() == 0) {
            return;
        }

        int nextPosition = Global.currentPlaylistPosition;

        if (Global.playbackMode == PlaybackMode.All) {
            nextPosition--;

            if (nextPosition < 0) {
                nextPosition = Global.currentPlaylist.size() - 1;
            }
        } else if (Global.playbackMode == PlaybackMode.Random) {
            if (randomIndexes.size() == 0) {
                for (int a = 0; a < Global.currentPlaylist.size(); a++) {
                    randomIndexes.add(a);
                }
            }

            int randomIndex = random.nextInt(randomIndexes.size());

            if (randomIndex >= Global.currentPlaylist.size()) {
                randomIndex = Global.currentPlaylist.size() - 1;
            }

            if (randomIndex < 0) {
                randomIndex = 0;
            }

            nextPosition = randomIndexes.get(randomIndex);
            randomIndexes.remove(randomIndex);
        }

        MediaSource source = Global.currentPlaylist.get(nextPosition);

        if (source.isLocal && !new File(source.path).exists()) {
            Toast.makeText(MainActivity.instance, MainActivity.instance.getString(R.string.snack_file_exists), Toast.LENGTH_SHORT).show();
            prev();
            return;
        }

        Global.currentPlaylistPosition = nextPosition;
        load(source);
        updateMetadata();
    }

    public void next() {
        if (Global.currentPlaylist.size() == 0) {
            return;
        }

        int nextPosition = Global.currentPlaylistPosition;

        if (Global.playbackMode == PlaybackMode.All) {
            nextPosition++;

            if (nextPosition >= Global.currentPlaylist.size()) {
                nextPosition = 0;
            }
        } else if (Global.playbackMode == PlaybackMode.Random) {
            if (randomIndexes.size() == 0) {
                for (int a = 0; a < Global.currentPlaylist.size(); a++) {
                    randomIndexes.add(a);
                }
            }

            int randomIndex = random.nextInt(randomIndexes.size());

            if (randomIndex >= Global.currentPlaylist.size()) {
                randomIndex = Global.currentPlaylist.size() - 1;
            }

            if (randomIndex < 0) {
                randomIndex = 0;
            }

            nextPosition = randomIndexes.get(randomIndex);
            randomIndexes.remove(randomIndex);
        }

        MediaSource source = Global.currentPlaylist.get(nextPosition);

        if (source.isLocal && !new File(source.path).exists()) {
            Toast.makeText(MainActivity.instance, MainActivity.instance.getString(R.string.snack_file_exists), Toast.LENGTH_SHORT).show();
            next();
            return;
        }

        Global.currentPlaylistPosition = nextPosition;
        load(source);
        updateMetadata();
    }

    public void pause() {
        this.player.pause();
        updateMetadata();

        try {
            MainActivity.instance.updatePlayerState(false);
        } catch (Exception ignore) {

        }
    }

    public void seek(long seek) {
        this.player.seekTo(seek, MediaPlayer.SEEK_PREVIOUS_SYNC);
        updateMetadata();
    }

    public void setVolume(float volume) {
        this.player.setVolume(volume, volume);
    }

    public boolean isPlaying() {
        return this.player.isPlaying();
    }

    public int getDuration() {
        return this.player.getDuration();
    }

    public int getCurrentPosition() {
        return this.player.getCurrentPosition();
    }
}
