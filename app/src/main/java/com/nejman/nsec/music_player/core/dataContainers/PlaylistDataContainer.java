package com.nejman.nsec.music_player.core.dataContainers;

import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.models.PlaylistModel;
import com.nejman.nsec.music_player.media.MediaSource;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.Hashtable;
import java.util.List;
import java.util.stream.Collectors;

import io.reactivex.rxjava3.annotations.NonNull;
import io.reactivex.rxjava3.annotations.Nullable;
import io.reactivex.rxjava3.core.Observer;
import io.reactivex.rxjava3.disposables.Disposable;
import io.reactivex.rxjava3.functions.Consumer;
import io.reactivex.rxjava3.subjects.PublishSubject;
import io.reactivex.rxjava3.subjects.Subject;

public class PlaylistDataContainer {
    private final Hashtable<String, PlaylistModel> items;
    private final Subject<String> playlistEdited;
    private final Subject<String> playlistRemoved;
    private final Subject<String> playlistAdded;

    public PlaylistDataContainer(Hashtable<String, PlaylistModel> items) {
        this.items = items;
        this.playlistAdded = PublishSubject.create();
        this.playlistEdited = PublishSubject.create();
        this.playlistRemoved = PublishSubject.create();
    }

    public PlaylistModel get(String index) {
        return this.items.get(index);
    }

    public List<PlaylistModel> getAll()
    {
        return items.values().stream().sorted(Comparator.comparing(playlistModel -> playlistModel.name)).collect(Collectors.toList());
    }

    public int count() {
        return this.items.size();
    }

    public boolean exists(String playlistName)
    {
        return this.items.containsKey(playlistName);
    }

    public boolean contains(String playlistName, String track)
    {
        if(!exists(playlistName))
        {
            return false;
        }

        return this.items.get(playlistName).items.contains(track);
    }

    public void forEach(Consumer<? super String> consumer) throws Throwable {
        for (String key : items.keySet()) {
            consumer.accept(key);
        }
    }

    public Disposable addOnPlaylistAdded(Consumer<? super String> consumer) {
        return this.playlistAdded.subscribe(consumer);
    }

    public Disposable addOnPlaylistEdited(Consumer<? super String> consumer) {
        return this.playlistEdited.subscribe(consumer);
    }

    public Disposable addOnPlaylistRemoved(Consumer<? super String> consumer) {
        return this.playlistRemoved.subscribe(consumer);
    }

    public void addPlaylist(String playlistName, PlaylistModel playlistModel) {
        items.put(playlistName, playlistModel);
        this.playlistAdded.onNext(playlistName);
    }

    public void addToPlaylist(String playlistName, String filepath) {
        PlaylistModel model = items.get(playlistName);

        if (model == null) {
            return;
        }

        if (model.items.contains(filepath)) {
            return;
        }

        model.items.add(filepath);

        MediaSource source = DataContainer.getInstance().getMediaSources().get(filepath);
        if (model.image == null && source.image != null) {
            model.image = source.image;
        }

        editPlaylist(playlistName, model);
    }

    public void removePlaylist(String name) {
        this.items.remove(name);
        this.playlistRemoved.onNext(name);
    }

    public void editPlaylist(String name, PlaylistModel playlistModel) {
        this.items.put(name, playlistModel);
        this.playlistEdited.onNext(name);
    }
}
