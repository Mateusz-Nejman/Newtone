package com.nejman.nsec.music_player.core.loaders;

import android.os.Environment;

import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class AudioLoader {

    public static List<File> list() {
        String musicDirectory = Environment.getExternalStorageDirectory().getAbsolutePath() + "/Music";
        String directory = musicDirectory + "/Newtone";
        File directoryFile = new File(directory);

        File musicDirectoryFile = new File(musicDirectory);

        File[] files = musicDirectoryFile.listFiles(pathname -> {
            List<String> validExtensions = new ArrayList<>();
            validExtensions.add("mp3");
            validExtensions.add("m4a");
            validExtensions.add("ogg");
            String name = pathname.getName();

            if (!name.contains(".")) {
                return false;
            }

            String extension = name.substring(name.lastIndexOf(".") + 1);
            return validExtensions.contains(extension);
        });

        File[] newtoneFiles = directoryFile.listFiles(pathname -> {
            List<String> validExtensions = new ArrayList<>();
            validExtensions.add("mp3");
            validExtensions.add("m4a");
            validExtensions.add("ogg");
            String name = pathname.getName();

            if (!name.contains(".")) {
                return false;
            }

            String extension = name.substring(name.lastIndexOf(".") + 1);
            return validExtensions.contains(extension);
        });

        List<File> scannedFiles = new ArrayList<>();
        if (files != null) {
            scannedFiles.addAll(Arrays.asList(files));
        }

        if (newtoneFiles != null) {
            scannedFiles.addAll(Arrays.asList(newtoneFiles));
        }

        return scannedFiles;
    }
}
