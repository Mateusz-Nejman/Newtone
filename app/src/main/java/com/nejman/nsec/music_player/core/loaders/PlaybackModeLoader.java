package com.nejman.nsec.music_player.core.loaders;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.media.PlaybackMode;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.nio.file.Files;

public class PlaybackModeLoader implements IDataLoader {
    private final File playbackModeFile = new File(MainActivity.dataPath + "/newtonePlaybackMode.data");

    @Override
    public void load() throws Throwable {
        if (playbackModeFile.exists()) {
            String playbackModeData = new String(Files.readAllBytes(playbackModeFile.toPath()));
            Global.playbackMode = PlaybackMode.valueOf(playbackModeData);
        }
    }

    @Override
    public void save() throws Throwable {
        FileWriter fileWriter = new FileWriter(playbackModeFile);
        BufferedWriter bufferedWriter = new BufferedWriter(fileWriter);
        bufferedWriter.write(Global.playbackMode.toString());
        bufferedWriter.close();
        fileWriter.close();
    }
}
