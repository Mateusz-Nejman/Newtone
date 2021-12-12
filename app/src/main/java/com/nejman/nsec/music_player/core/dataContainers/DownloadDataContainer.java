package com.nejman.nsec.music_player.core.dataContainers;

import android.widget.Toast;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.YoutubeDownloadHelper;
import com.nejman.nsec.music_player.core.data.Playlists;
import com.nejman.nsec.music_player.core.data.PlaylistsAction;
import com.nejman.nsec.music_player.core.data.Tracks;
import com.nejman.nsec.music_player.core.loaders.DataLoader;
import com.nejman.nsec.music_player.core.models.DownloadModel;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.media.MediaSourceTag;
import com.nejman.nsec.music_player.ui.AlertDialogFragment;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.List;
import java.util.Objects;

import io.reactivex.rxjava3.disposables.Disposable;
import io.reactivex.rxjava3.functions.Consumer;
import io.reactivex.rxjava3.subjects.PublishSubject;
import io.reactivex.rxjava3.subjects.Subject;

public class DownloadDataContainer {
    private final Hashtable<String, DownloadModel> items;
    private final Subject<String> onDownloadAdded;
    private final Subject<String> onDownloadEdited;
    private final Subject<String> onDownloadRemoved;

    public DownloadDataContainer() {
        items = new Hashtable<>();
        onDownloadAdded = PublishSubject.create();
        onDownloadEdited = PublishSubject.create();
        onDownloadRemoved = PublishSubject.create();
    }

    public DownloadModel get(String id) {
        return items.get(id);
    }

    public List<DownloadModel> getAll() {
        return new ArrayList<>(items.values());
    }

    public void setProgress(String name, int progress) {
        Objects.requireNonNull(items.get(name)).progress = progress;
        onDownloadEdited.onNext(name);
    }

    public void add(String elementsBuffer) {
        String[] elements = elementsBuffer.split(Global.separator);

        HashMap<YoutubeDownloadHelper.Query, String> urlType = YoutubeDownloadHelper.checkLink(elements[elements.length == 2 ? 1 : 2]);
        System.out.println(elementsBuffer);
        String id = elements[1];
        String title = elements[0];
        String url = elements[1];

        if (urlType.containsKey(YoutubeDownloadHelper.Query.Playlist) && urlType.containsKey(YoutubeDownloadHelper.Query.Video)) {
            AlertDialogFragment alert = new AlertDialogFragment(MainActivity.getResString(R.string.question), MainActivity.getResString(R.string.playlist_or_track), MainActivity.getResString(R.string.track), MainActivity.getResString(R.string.playlist), selected -> {
                if (selected) {
                    add(id, title, url, "", "");
                } else {
                    String playlistId = urlType.get(YoutubeDownloadHelper.Query.Playlist);
                    AlertDialogFragment alertCreatePlaylist = new AlertDialogFragment(MainActivity.getResString(R.string.question), MainActivity.instance.getString(R.string.playlist_download), MainActivity.getResString(R.string.yes), MainActivity.getResString(R.string.no), create -> {
                        if (create) {
                            PlaylistsAction.selectPlaylist(YoutubeDownloadHelper.lastPlaylistName, newPlaylistName -> {
                                String playlistName = (newPlaylistName == null || newPlaylistName.equals(" ") || newPlaylistName.equals("")) ? "" : newPlaylistName;
                                new Thread(() -> add(YoutubeDownloadHelper.search("https://www.youtube.com/playlist?list=" + playlistId), playlistName, playlistId)).start();
                            });
                        } else {
                            new Thread(() -> add(YoutubeDownloadHelper.search("https://www.youtube.com/playlist?list=" + playlistId), "", playlistId)).start();
                        }
                    });

                    alertCreatePlaylist.show(MainActivity.instance.getSupportFragmentManager(), "alertCreatePlaylist");
                }
            });

            alert.show(MainActivity.instance.getSupportFragmentManager(), "alert");
        } else {
            add(id, url, title, "", "");
        }
    }

    private void add(List<MediaSource> sources, String playlist, String playlistId) {
        for (MediaSource source : sources) {
            add(source.id, source.title, source.path, playlistId, playlist);
        }
    }

    private void add(String id, String url, String title, String playlistId, String playlistName) {
        if (items.containsKey(id)) {
            return;
        }

        if (Global.downloadedIds.contains(id)) {
            String filename = DataContainer.getInstance().getMediaSourceTags().findPathById(id);

            if (playlistName != null && !playlistName.equals("")) {
                DataContainer.getInstance().getPlaylists().addToPlaylist(playlistName, filename);
            }

            return;
        }

        DownloadModel model = new DownloadModel();
        model.id = id;
        model.url = url;
        model.title = title;
        model.playlistName = playlistName;
        model.playlistId = playlistId;

        items.put(id, model);
        onDownloadAdded.onNext(id);

        Thread thread = new Thread(() -> {
            System.out.println("start downloading " + id);
            MediaSource source = YoutubeDownloadHelper.getVideoInfo(id, null);
            String filename = source.title
                    .replace('/', '_')
                    .replace('\\', '_')
                    .replace(':', '_')
                    .replace('*', '_')
                    .replace('"', '_')
                    .replace('<', '_')
                    .replace('>', '_')
                    .replace('|', '_');

            YoutubeDownloadHelper.downloadAudio(id, filename, file -> {
                items.remove(id);
                onDownloadRemoved.onNext(id);

                String[] splitted = source.title.split("-");
                String _artist = (splitted.length == 1 ? source.artist : splitted[0]).trim();
                String _title = (splitted[splitted.length == 1 ? 0 : 1]).trim();

                byte[] image = null;

                try {
                    URL _url = new URL(source.imageUrl);
                    HttpURLConnection http = (HttpURLConnection) _url.openConnection();
                    int responseCode = http.getResponseCode();

                    if (responseCode == HttpURLConnection.HTTP_OK) {
                        InputStream inputStream = http.getInputStream();
                        ByteArrayOutputStream outputStream = new ByteArrayOutputStream();

                        int bytesRead;
                        byte[] buffer = new byte[4096];
                        while ((bytesRead = inputStream.read(buffer)) != -1) {
                            outputStream.write(buffer, 0, bytesRead);
                        }

                        image = outputStream.toByteArray();
                        outputStream.close();
                        inputStream.close();
                    }

                    http.disconnect();
                } catch (IOException ignored) {

                }

                if (DataContainer.getInstance().getMediaSourceTags().exists(file.getAbsolutePath())) {
                    String filepath = file.getAbsolutePath();
                    MediaSourceTag tag = DataContainer.getInstance().getMediaSourceTags().get(filepath);
                    tag.author = _artist;
                    tag.title = title;
                    tag.image = image;
                    tag.id = source.id;
                    tag.duration = source.duration;

                    DataContainer.getInstance().getMediaSourceTags().edit(tag, tag);
                } else {
                    MediaSourceTag tag = new MediaSourceTag();
                    tag.author = _artist;
                    tag.title = _title;
                    tag.image = image;
                    tag.id = source.id;
                    tag.duration = source.duration;
                    tag.path = file.getAbsolutePath();

                    DataContainer.getInstance().getMediaSourceTags().add(tag);
                }

                MediaSource container = DataLoader.getSource(file);
                Tracks.add(container);
                try {
                    DataLoader.save();
                    DataLoader.saveTags();
                } catch (Throwable throwable) {
                    throwable.printStackTrace();
                }

                MainActivity.instance.runOnUiThread(() -> Toast.makeText(MainActivity.instance, MainActivity.instance.getString(R.string.file_downloaded) + " " + _artist + " " + _title, Toast.LENGTH_SHORT).show());

                if (model.playlistName != null && !model.playlistName.equals("")) {
                    Playlists.add(model.playlistName, file.getAbsolutePath());
                }
            }, progress -> {
                setProgress(id, progress);
                System.out.println("Downloading " + id + ": " + progress);
            });
        });
        thread.start();
    }

    public Disposable addOnDownloadAdded(Consumer<? super String> consumer) {
        return onDownloadAdded.subscribe(consumer);
    }

    public Disposable addOnDownloadEdited(Consumer<? super String> consumer) {
        return onDownloadEdited.subscribe(consumer);
    }

    public Disposable addOnDownloadRemoved(Consumer<? super String> consumer) {
        return onDownloadRemoved.subscribe(consumer);
    }
}
