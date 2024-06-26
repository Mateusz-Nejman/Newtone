package com.nejman.nsec.music_player.core.dataContainers;

import com.nejman.nsec.music_player.core.models.ArtistModel;
import com.nejman.nsec.music_player.media.MediaSource;

import java.util.ArrayList;
import java.util.Hashtable;
import java.util.List;
import java.util.Objects;

import io.reactivex.rxjava3.disposables.Disposable;
import io.reactivex.rxjava3.functions.Consumer;
import io.reactivex.rxjava3.subjects.PublishSubject;
import io.reactivex.rxjava3.subjects.Subject;

public class ArtistDataContainer {
    private final Hashtable<String, ArtistModel> items;
    private final Subject<ArtistModel> artistAdded;
    private final Subject<ArtistModel> artistRemoved;
    private final Subject<ArtistModel> artistEdited;

    public ArtistDataContainer() {
        this.items = new Hashtable<>();
        this.artistAdded = PublishSubject.create();
        this.artistRemoved = PublishSubject.create();
        this.artistEdited = PublishSubject.create();
    }

    public void createIfNotExists(String artist) {
        if (this.items.containsKey(artist)) {
            return;
        }

        this.items.put(artist, new ArtistModel(artist, new ArrayList<>()));
        this.artistAdded.onNext(Objects.requireNonNull(this.items.get(artist)));
    }

    public void add(MediaSource source) {
        createIfNotExists(source.artist);

        ArtistModel model = this.items.get(source.artist);

        if (model == null) {
            return;
        }

        if (model.image == null && source.image != null) {
            model.image = source.image;
        }

        if (!model.items.contains(source.path)) {
            model.items.add(source.path);
        }

        this.items.put(source.artist, model);
        this.artistAdded.onNext(model);
    }

    public List<ArtistModel> getAll() {
        return new ArrayList<>(this.items.values());
    }

    public ArtistModel get(String artist) {
        return this.items.get(artist);
    }

    public void remove(String artist) {
        ArtistModel model = this.items.get(artist);

        if (model == null) {
            return;
        }
        this.items.remove(artist);
        this.artistRemoved.onNext(model);
    }

    public void remove(MediaSource source) {
        remove(source.artist, source);
    }

    public void remove(String artist, MediaSource source) {
        if (!this.items.containsKey(artist)) {
            return;
        }

        ArtistModel model = items.get(artist);

        if (model == null) {
            return;
        }
        model.items.remove(source.path);

        if (model.items.size() == 0) {
            remove(artist);
        }
    }

    public Disposable addOnArtistAdded(Consumer<? super ArtistModel> consumer) {
        return this.artistAdded.subscribe(consumer);
    }

    public Disposable addOnArtistEdited(Consumer<? super ArtistModel> consumer) {
        return this.artistEdited.subscribe(consumer);
    }

    public Disposable addOnArtistRemoved(Consumer<? super ArtistModel> consumer) {
        return this.artistRemoved.subscribe(consumer);
    }
}
