package com.nejman.nsec.music_player.core.loaders;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.media.MediaFormat;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.nio.file.Files;

public class MediaFormatLoader implements IDataLoader {
    private final File mediaFormatFile = new File(MainActivity.dataPath + "/newtoneMediaType.data");

    @Override
    public void load() throws Throwable {
        if (mediaFormatFile.exists()) {
            String mediaFormat = new String(Files.readAllBytes(mediaFormatFile.toPath()));
            Global.mediaFormat = mediaFormat.equals("ogg") ? MediaFormat.ogg : MediaFormat.m4a;
        }
    }

    @Override
    public void save() throws Throwable {
        FileWriter fileWriter = new FileWriter(mediaFormatFile);
        BufferedWriter bufferedWriter = new BufferedWriter(fileWriter);
        bufferedWriter.write(Global.mediaFormat == MediaFormat.ogg ? "ogg" : "m4a");
        bufferedWriter.close();
        fileWriter.close();
    }
}
