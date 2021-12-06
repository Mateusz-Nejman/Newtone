package com.nejman.nsec.music_player;

import android.os.Environment;

import com.nejman.nsec.music_player.media.AudioFocusListener;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.media.PlaybackMode;

import java.util.ArrayList;
import java.util.Dictionary;
import java.util.Hashtable;
import java.util.List;

public class Global {
    public static final String musicPath = Environment.getExternalStorageDirectory().getAbsolutePath() + "/Music/Newtone";
    public static final String separator = "NSEC_SEPARATOR";
    public static final List<String> downloadedIds = new ArrayList<>();
    public static final List<MediaSource> currentPlaylist = new ArrayList<>();
    public static int currentPlaylistPosition = 0;
    public static int queuePosition = 0;
    public static MediaSource currentSource;
    public static PlaybackMode playbackMode = PlaybackMode.All;
    public static final AudioFocusListener audioFocusListener = new AudioFocusListener();
    public static boolean ignoreAutoFocus = false;
}
