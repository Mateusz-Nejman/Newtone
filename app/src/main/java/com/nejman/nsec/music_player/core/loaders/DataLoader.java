package com.nejman.nsec.music_player.core.loaders;


import android.content.SharedPreferences;
import android.os.Environment;

import androidx.preference.PreferenceManager;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.data.Tracks;
import com.nejman.nsec.music_player.media.MediaFormat;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.media.MediaSourceTag;

import org.jaudiotagger.audio.AudioFile;
import org.jaudiotagger.audio.AudioFileIO;
import org.jaudiotagger.audio.exceptions.CannotReadException;
import org.jaudiotagger.audio.exceptions.InvalidAudioFrameException;
import org.jaudiotagger.audio.exceptions.NullBoxIdException;
import org.jaudiotagger.audio.exceptions.ReadOnlyFileException;
import org.jaudiotagger.tag.FieldKey;
import org.jaudiotagger.tag.Tag;
import org.jaudiotagger.tag.TagException;
import org.jaudiotagger.tag.images.Artwork;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Hashtable;
import java.util.List;

public class DataLoader {
    private final static PlaylistLoader playlistLoader = new PlaylistLoader();
    private final static PlaybackModeLoader playbackModeLoader = new PlaybackModeLoader();
    private final static HistoryLoader historyLoader = new HistoryLoader();
    private final static IgnoreLoader ignoreLoader = new IgnoreLoader();
    private final static MediaFormatLoader mediaFormatLoader = new MediaFormatLoader();
    public final static PlayerStateLoader playerStateLoader = new PlayerStateLoader();

    public static void loadAudioFiles() {
        if (DataContainer.getInstance().getMediaSources().count() > 0) {
            return;
        }

        String musicDirectory = Environment.getExternalStorageDirectory().getAbsolutePath() + "/Music";
        String directory = musicDirectory + "/Newtone";
        File directoryFile = new File(directory);

        File musicDirectoryFile = new File(musicDirectory);

        File[] files = musicDirectoryFile.listFiles(pathname -> {
            List<String> validExtensions = new ArrayList<>();
            validExtensions.add("mp3");
            validExtensions.add("m4a");
            validExtensions.add("ogg");
            validExtensions.add("webm");
            validExtensions.add("weba");
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
            validExtensions.add("webm");
            validExtensions.add("weba");
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

        for (File scannedFile : scannedFiles) {
            Tracks.add(getSource(scannedFile));
        }
    }

    public static void loadTags() throws IOException {
        File tagsFile = new File(MainActivity.dataPath + "/newtoneTags.data");

        if (!tagsFile.exists()) {
            return;
        }

        List<String> tags = Files.readAllLines(tagsFile.toPath());

        for (String tagItem : tags) {
            String[] values = tagItem.split(Global.separator);
            String imagePath = values[3];

            MediaSourceTag tag = new MediaSourceTag();
            tag.path = values[0];
            tag.author = values[1];
            tag.title = values[2];
            tag.id = values[4];
            tag.duration = Long.parseLong(values[5]);

            File imageFile = new File(MainActivity.dataPath + "/" + imagePath);
            if (imageFile.exists() && imageFile.isFile()) {
                byte[] image = Files.readAllBytes(imageFile.toPath());

                if (image.length != 0) {
                    tag.image = image;
                }
            }

            DataContainer.getInstance().getMediaSourceTags().add(tag);
        }
    }

    public static void saveTags() throws IOException {
        String dataPath = MainActivity.dataPath;
        File tagsFile = new File(MainActivity.dataPath + "/newtoneTags.data");

        if (DataContainer.getInstance().getMediaSourceTags().count() == 0) {
            return;
        }

        int counter = 0;
        List<String> buffer = new ArrayList<>();

        Hashtable<String, MediaSourceTag> items = DataContainer.getInstance().getMediaSourceTags().get();

        for (String filepath : items.keySet()) {
            MediaSourceTag mediaSource = items.get(filepath);

            if (mediaSource == null) {
                continue;
            }

            String imageName = null;

            if (mediaSource.image != null && mediaSource.image.length > 0) {
                imageName = "image" + counter;
                File imageFile = new File(dataPath + "/" + imageName);

                Files.write(imageFile.toPath(), mediaSource.image);
                counter++;
            }

            String bufferItem = filepath + Global.separator +
                    mediaSource.author + Global.separator +
                    mediaSource.title + Global.separator +
                    (imageName == null ? "" : imageName) + Global.separator +
                    mediaSource.id + Global.separator + mediaSource.duration;

            buffer.add(bufferItem);
        }

        FileWriter fileWriter = new FileWriter(tagsFile);
        BufferedWriter bufferedWriter = new BufferedWriter(fileWriter);
        bufferedWriter.write(String.join("\n", buffer));
        bufferedWriter.close();
        fileWriter.close();
    }

    public static void load() throws Throwable {
        playlistLoader.load();
        playbackModeLoader.load();
        historyLoader.load();
        ignoreLoader.load();
        mediaFormatLoader.load();

        SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(MainActivity.instance);

        if (preferences == null) {
            return;
        }

        SharedPreferences.Editor editor = preferences.edit();

        editor.putBoolean("ignoreBroadcast", Global.ignoreAutoFocus);
        editor.putString("mediaFormat", Global.mediaFormat == MediaFormat.ogg ? "ogg" : "m4a");
        editor.apply();
    }

    public static void save() throws Throwable {
        playlistLoader.save();
        playbackModeLoader.save();
        historyLoader.save();
        ignoreLoader.save();
        mediaFormatLoader.save();
        playerStateLoader.save();
    }

    public static MediaSource getSource(File file) {
        String title;
        String artist;
        byte[] image = null;
        long duration = 0;
        String id = null;

        try {
            AudioFile audioFile = AudioFileIO.read(file);
            Tag tag = audioFile.getTag();
            title = tag.getFirst(FieldKey.TITLE).equals("") ? file.getName() : tag.getFirst(FieldKey.TITLE);
            artist = tag.getFirst(FieldKey.ARTIST).equals("") ? MainActivity.instance.getString(R.string.unknown_artist) : tag.getFirst(FieldKey.ARTIST);

            for (Artwork artwork : tag.getArtworkList()) {
                image = artwork.getBinaryData();
                break;
            }

            duration = audioFile.getAudioHeader().getTrackLength() * 1000L;
        } catch (CannotReadException | IOException | TagException | ReadOnlyFileException | InvalidAudioFrameException | NullBoxIdException e) {
            title = file.getName();
            artist = MainActivity.instance.getString(R.string.unknown_artist);
        }

        Hashtable<String, MediaSourceTag> tags = DataContainer.getInstance().getMediaSourceTags().get();

        if (tags.containsKey(file.getAbsolutePath())) {
            MediaSourceTag newTag = tags.get(file.getAbsolutePath());

            if (newTag != null) {
                artist = newTag.author;
                title = newTag.title;
                image = image == null ? newTag.image : image;

                if (duration == 0) {
                    duration = newTag.duration;
                }

                if (newTag.id != null && !newTag.id.equals("") && !Global.downloadedIds.contains(newTag.id)) {
                    Global.downloadedIds.add(newTag.id);
                    id = newTag.id;
                }
            }
        }

        return new MediaSource(file.getAbsolutePath(), artist, title, duration, image, id, null, null);
    }
}
