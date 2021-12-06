package com.nejman.nsec.music_player.core.dataContainers;

import android.provider.MediaStore;

import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.media.MediaSourceTag;

import java.util.ArrayList;
import java.util.Hashtable;
import java.util.List;

import io.reactivex.rxjava3.disposables.Disposable;
import io.reactivex.rxjava3.functions.Consumer;
import io.reactivex.rxjava3.subjects.PublishSubject;
import io.reactivex.rxjava3.subjects.Subject;

public class MediaSourceTagsDataContainer {
    private Hashtable<String, MediaSourceTag> items;
    private final Subject<MediaSourceTag> sourceAdded;
    private final Subject<MediaSourceTag> sourceRemoved;
    private final Subject<MediaSourceTag[]> sourceEdited;

    public MediaSourceTagsDataContainer()
    {
        this.items = new Hashtable<>();
        this.sourceAdded = PublishSubject.create();
        this.sourceRemoved = PublishSubject.create();
        this.sourceEdited = PublishSubject.create();
    }

    public int count()
    {
        return this.items.size();
    }

    public Hashtable<String, MediaSourceTag> get()
    {
        return this.items;
    }

    public void add(MediaSourceTag item)
    {
        this.items.put(item.path, item);
        this.sourceAdded.onNext(item);
    }

    public void remove(String index)
    {
        MediaSourceTag item = this.items.get(index);
        this.items.remove(index);
        this.sourceRemoved.onNext(item);
    }

    public MediaSourceTag get(String path)
    {
        return this.items.get(path);
    }

    public boolean exists(String path)
    {
        return this.items.containsKey(path);
    }
    public String findPathById(String id)
    {
        for (String key : items.keySet())
        {
            MediaSourceTag tag = items.get(key);

            if(tag == null)
            {
                continue;
            }

            if(tag.id.equals(id))
            {
                return key;
            }
        }

        return null;
    }

    public void edit(MediaSourceTag oldItem, MediaSourceTag newItem)
    {
        this.items.put(oldItem.path,newItem);
        this.sourceEdited.onNext(new MediaSourceTag[]{oldItem,newItem});
    }

    public Disposable addOnSourceAdded(Consumer<MediaSourceTag> consumer)
    {
        return this.sourceAdded.subscribe(consumer);
    }

    public Disposable addOnSourceRemoved(Consumer<MediaSourceTag> consumer)
    {
        return this.sourceRemoved.subscribe(consumer);
    }

    public Disposable addOnSourceEdited(Consumer<MediaSourceTag[]> consumer)
    {
        return this.sourceEdited.subscribe(consumer);
    }
}
