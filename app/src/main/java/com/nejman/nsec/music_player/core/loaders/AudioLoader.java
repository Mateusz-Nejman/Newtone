package com.nejman.nsec.music_player.core.loaders;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Environment;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.media.MediaSourceTag;

import org.jaudiotagger.audio.AudioFile;
import org.jaudiotagger.audio.AudioFileIO;
import org.jaudiotagger.audio.exceptions.CannotReadException;
import org.jaudiotagger.audio.exceptions.InvalidAudioFrameException;
import org.jaudiotagger.audio.exceptions.ReadOnlyFileException;
import org.jaudiotagger.tag.FieldKey;
import org.jaudiotagger.tag.Tag;
import org.jaudiotagger.tag.TagException;
import org.jaudiotagger.tag.images.Artwork;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class AudioLoader {

    public static List<File> list()
    {
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

            if(!name.contains("."))
            {
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

            if(!name.contains("."))
            {
                return false;
            }

            String extension = name.substring(name.lastIndexOf(".") + 1);
            return validExtensions.contains(extension);
        });

        List<File> scannedFiles = new ArrayList<>();
        if(files != null)
        {
            scannedFiles.addAll(Arrays.asList(files));
        }

        if(newtoneFiles != null)
        {
            scannedFiles.addAll(Arrays.asList(newtoneFiles));
        }

        return scannedFiles;
    }

    public static MediaSource mediaSourceFromTags(File file)
    {
        try {
            AudioFile audioFile = AudioFileIO.read(file);
            Tag tag = audioFile.getTag();

            String artist = tag.getFirst(FieldKey.ARTIST);
            String title = tag.getFirst(FieldKey.TITLE);
            long duration = audioFile.getAudioHeader().getTrackLength();
            Bitmap thumbnail = null;

            List<Artwork> artworks = tag.getArtworkList();

            if(artworks.size() > 0)
            {
                Artwork artwork = artworks.get(0);
                byte[] binary = artwork.getBinaryData();
                thumbnail = BitmapFactory.decodeByteArray(binary, 0, binary.length);
            }

            return new MediaSource(file.getAbsolutePath(),artist,title,duration,thumbnail,null,null,null);
        } catch (CannotReadException | IOException | TagException | InvalidAudioFrameException | ReadOnlyFileException e) {
            return null;
        }
    }

    public static void loadTags() throws IOException {
        File tagsFile = new File(MainActivity.dataPath+"/newtoneTags.data");

        if(!tagsFile.exists())
        {
            return;
        }

        List<String> tags = Files.readAllLines(tagsFile.toPath());

        for(String tagItem : tags)
        {
            String[] values = tagItem.split(Global.separator);
            String imagePath = values[3];

            MediaSourceTag tag = new MediaSourceTag();
            tag.path = values[0];
            tag.author = values[1];
            tag.title = values[2];
            tag.id = values[4];
            tag.duration = Long.parseLong(values[5]);

            File imageFile = new File(MainActivity.dataPath+"/"+imagePath);
            if(imageFile.exists() && imageFile.isFile())
            {
                byte[] image = Files.readAllBytes(imageFile.toPath());

                if(image.length != 0)
                {
                    tag.image = image;
                }
            }

            DataContainer.getInstance().getMediaSourceTags().add(tag);
        }
    }
}
