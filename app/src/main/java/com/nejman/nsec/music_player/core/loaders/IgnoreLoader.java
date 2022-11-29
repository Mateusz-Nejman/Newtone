package com.nejman.nsec.music_player.core.loaders;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.nio.file.Files;

public class IgnoreLoader implements IDataLoader {
    private final File ignoreFile = new File(MainActivity.dataPath + "/newtoneIgnore.data");

    @Override
    public void load() throws Throwable {
        if (ignoreFile.exists()) {
            String ignoreData = new String(Files.readAllBytes(ignoreFile.toPath()));
            Global.ignoreAutoFocus = Boolean.getBoolean(ignoreData);
        }
    }

    @Override
    public void save() throws Throwable {
        FileWriter fileWriter = new FileWriter(ignoreFile);
        BufferedWriter bufferedWriter = new BufferedWriter(fileWriter);
        bufferedWriter.write(Boolean.toString(Global.ignoreAutoFocus));
        bufferedWriter.close();
        fileWriter.close();
    }
}
