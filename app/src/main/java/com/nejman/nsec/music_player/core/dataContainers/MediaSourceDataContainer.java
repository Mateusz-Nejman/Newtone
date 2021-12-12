package com.nejman.nsec.music_player.core.dataContainers;

import com.nejman.nsec.music_player.core.data.Artists;
import com.nejman.nsec.music_player.media.MediaSource;

import java.util.ArrayList;
import java.util.Hashtable;
import java.util.List;

import io.reactivex.rxjava3.disposables.Disposable;
import io.reactivex.rxjava3.functions.Consumer;
import io.reactivex.rxjava3.subjects.PublishSubject;
import io.reactivex.rxjava3.subjects.Subject;

public class MediaSourceDataContainer {
    private final Hashtable<String, MediaSource> items;
    private final Subject<MediaSource> sourceAdded;
    private final Subject<MediaSource> sourceRemoved;
    private final Subject<MediaSource[]> sourceEdited;

    public MediaSourceDataContainer() {
        this.items = new Hashtable<>();
        this.sourceAdded = PublishSubject.create();
        this.sourceRemoved = PublishSubject.create();
        this.sourceEdited = PublishSubject.create();
    }

    public List<MediaSource> getAll() {
        return new ArrayList<>(this.items.values());
    }

    public MediaSource get(String path) {
        return this.items.get(path);
    }

    public int count() {
        return this.items.size();
    }

    public void add(MediaSource item) {
        this.items.put(item.path, item);
        this.sourceAdded.onNext(item);
    }

    public boolean exists(MediaSource item) {
        return exists(item.path);
    }

    public boolean exists(String path) {
        return this.items.containsKey(path);
    }

    public void remove(String path) {
        MediaSource item = this.items.get(path);

        if (item == null) {
            return;
        }
        this.items.remove(path);
        this.sourceRemoved.onNext(item);
    }

    public void edit(MediaSource newItem) {
        MediaSource oldItem = this.items.get(newItem.path);

        if (oldItem == null) {
            return;
        }
        this.items.put(oldItem.path, newItem);

        System.out.println("edit " + (!oldItem.artist.equals(newItem.artist)) + " " + oldItem.artist + " " + newItem.artist);
        if (!oldItem.artist.equals(newItem.artist)) {
            Artists.remove(oldItem.artist, oldItem);
            Artists.add(newItem);
            System.out.println(oldItem.artist + " " + newItem.artist);
        }
        this.sourceEdited.onNext(new MediaSource[]{oldItem, newItem});
    }

    public Disposable addOnSourceAdded(Consumer<MediaSource> consumer) {
        return this.sourceAdded.subscribe(consumer);
    }

    public Disposable addOnSourceRemoved(Consumer<MediaSource> consumer) {
        return this.sourceRemoved.subscribe(consumer);
    }

    public Disposable addOnSourceEdited(Consumer<MediaSource[]> consumer) {
        return this.sourceEdited.subscribe(consumer);
    }
}
