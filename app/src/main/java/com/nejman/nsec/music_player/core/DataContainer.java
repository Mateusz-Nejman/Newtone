package com.nejman.nsec.music_player.core;

import com.nejman.nsec.music_player.core.dataContainers.ArtistDataContainer;
import com.nejman.nsec.music_player.core.dataContainers.DownloadDataContainer;
import com.nejman.nsec.music_player.core.dataContainers.HistoryDataContainer;
import com.nejman.nsec.music_player.core.dataContainers.MediaSourceDataContainer;
import com.nejman.nsec.music_player.core.dataContainers.MediaSourceTagsDataContainer;
import com.nejman.nsec.music_player.core.dataContainers.PlaylistDataContainer;

import java.util.ArrayList;
import java.util.Hashtable;

public class DataContainer {
    private static DataContainer instance;

    public static DataContainer getInstance() {
        if (instance == null) {
            instance = new DataContainer();
        }

        return instance;
    }

    private final PlaylistDataContainer playlistDataContainer;
    private final HistoryDataContainer historyDataContainer;
    private final MediaSourceDataContainer mediaSourceDataContainer;
    private final MediaSourceTagsDataContainer mediaSourceTagsDataContainer;
    private final DownloadDataContainer downloadDataContainer;
    private final ArtistDataContainer artistDataContainer;

    public DataContainer() {
        playlistDataContainer = new PlaylistDataContainer(new Hashtable<>());
        historyDataContainer = new HistoryDataContainer(new ArrayList<>());
        mediaSourceDataContainer = new MediaSourceDataContainer();
        mediaSourceTagsDataContainer = new MediaSourceTagsDataContainer();
        downloadDataContainer = new DownloadDataContainer();
        artistDataContainer = new ArtistDataContainer();
    }

    public PlaylistDataContainer getPlaylists() {
        return playlistDataContainer;
    }

    public HistoryDataContainer getHistory() {
        return historyDataContainer;
    }

    public MediaSourceDataContainer getMediaSources() {
        return mediaSourceDataContainer;
    }

    public MediaSourceTagsDataContainer getMediaSourceTags() {
        return mediaSourceTagsDataContainer;
    }

    public DownloadDataContainer getDownloads() {
        return downloadDataContainer;
    }

    public ArtistDataContainer getArtists() {
        return artistDataContainer;
    }
}
