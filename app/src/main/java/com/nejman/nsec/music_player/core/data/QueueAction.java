package com.nejman.nsec.music_player.core.data;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.media.MediaSource;

import java.util.List;

public class QueueAction {
    public static void add(MediaSource track) {
        if (Global.currentPlaylist.size() == 0 || !DataContainer.getInstance().getMediaSources().exists(track.path)) {
            return;
        }

        if (Global.queuePosition < Global.currentPlaylistPosition || Global.queuePosition > Global.currentPlaylist.size()) {
            Global.queuePosition = Global.currentPlaylistPosition;
        }

        Global.currentPlaylist.add(Global.queuePosition + 1, track);
        Global.queuePosition++;
    }

    public static void add(String track) {
        add(DataContainer.getInstance().getMediaSources().get(track));
    }

    public static void add(List<String> tracks) {
        for (String track : tracks) {
            add(track);
        }
    }
}
