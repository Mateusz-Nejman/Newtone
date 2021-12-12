package com.nejman.nsec.music_player.core.data;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.loaders.DataLoader;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.media.MediaSourceTag;

import java.io.File;
import java.io.IOException;

public class Tracks {
    public static void add(MediaSource source) {
        if (!DataContainer.getInstance().getMediaSources().exists(source) && source.isLocal && new File(source.path).exists()) {
            DataContainer.getInstance().getMediaSources().add(source);
            System.out.println(source.artist);
            Artists.add(source);
        }
    }

    public static void remove(String track) {
        if (!DataContainer.getInstance().getMediaSources().exists(track)) {
            return;
        }

        remove(DataContainer.getInstance().getMediaSources().get(track));
    }

    public static void remove(MediaSource source) {
        if (!DataContainer.getInstance().getMediaSources().exists(source.path) || !new File(source.path).exists()) {
            return;
        }

        DataContainer.getInstance().getMediaSources().remove(source.path);
        DataContainer.getInstance().getMediaSourceTags().remove(source.path);
        Artists.remove(source.artist, source);

        if (!new File(source.path).delete()) {
            return;
        }

        if (source.id != null) {
            Global.downloadedIds.remove(source.id);
        }
        try {
            DataLoader.save();
        } catch (Throwable throwable) {
            throwable.printStackTrace();
        }
    }

    public static void edit(MediaSource source, String artist, String title) {
        if (!DataContainer.getInstance().getMediaSources().exists(source.path)) {
            return;
        }

        String oldArtist = source.artist;

        if (!oldArtist.equals(artist)) {
            Artists.remove(oldArtist, source);
            Artists.add(source);
        }

        if (!DataContainer.getInstance().getMediaSourceTags().exists(source.path)) {
            MediaSourceTag tag = new MediaSourceTag();
            tag.path = source.path;
            tag.title = title;
            tag.author = artist;

            DataContainer.getInstance().getMediaSourceTags().add(tag);
        }

        MediaSourceTag tag = DataContainer.getInstance().getMediaSourceTags().get(source.path);
        tag.author = artist;
        tag.title = title;
        DataContainer.getInstance().getMediaSourceTags().edit(tag, tag);
        MediaSource newSource = source.clone();
        newSource.artist = artist;
        newSource.title = title;
        DataContainer.getInstance().getMediaSources().edit(newSource);

        try {
            DataLoader.saveTags();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
