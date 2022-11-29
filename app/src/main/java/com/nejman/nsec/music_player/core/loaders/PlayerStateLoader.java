package com.nejman.nsec.music_player.core.loaders;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.media.NewtoneMediaPlayer;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.nio.file.Files;
import java.util.ArrayList;
import java.util.List;

public class PlayerStateLoader implements IDataLoader {
    private final File playlistStateFile = new File(MainActivity.dataPath + "/newtoneIgnore.data");

    @Override
    public void load() throws Throwable {
        if (!playlistStateFile.exists()) {
            return;
        }
        List<String> stateItems = Files.readAllLines(playlistStateFile.toPath());

        if (stateItems.size() != 2) {
            return;
        }

        List<MediaSource> playlist = new ArrayList<>();

        String currentPlaylistBuffer = stateItems.get(0);
        String currentPositionBuffer = stateItems.get(1);

        String[] playlistItems = currentPlaylistBuffer.split(Global.separator);

        for (String playlistItem :
                playlistItems) {
            if (DataContainer.getInstance().getMediaSources().exists(playlistItem)) {
                playlist.add(DataContainer.getInstance().getMediaSources().get(playlistItem));
            }
        }

        if (playlist.size() == 0) {
            return;
        }

        NewtoneMediaPlayer.getInstance().loadPlaylist(playlist, Integer.parseInt(currentPositionBuffer));
    }

    @Override
    public void save() throws Throwable {
        StringBuilder currentPlaylistBuffer = new StringBuilder();
        String playlistPosition = Integer.toString(Global.currentPlaylistPosition);

        for (int a = 0; a < Global.currentPlaylist.size(); ++a) {
            currentPlaylistBuffer.append(Global.currentPlaylist.get(a).path);

            if (a < Global.currentPlaylist.size() - 1) {
                currentPlaylistBuffer.append(Global.separator);
            }
        }

        FileWriter fileWriter = new FileWriter(playlistStateFile);
        BufferedWriter bufferedWriter = new BufferedWriter(fileWriter);
        bufferedWriter.write(currentPlaylistBuffer.append("\n").append(playlistPosition).toString());
        bufferedWriter.close();
        fileWriter.close();
    }
}
