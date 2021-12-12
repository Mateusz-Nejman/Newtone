package com.nejman.nsec.music_player.ui;

import android.view.View;
import android.widget.PopupMenu;
import android.widget.Toast;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.data.PlaylistsAction;
import com.nejman.nsec.music_player.core.data.QueueAction;
import com.nejman.nsec.music_player.core.data.TracksAction;
import com.nejman.nsec.music_player.core.models.ArtistModel;
import com.nejman.nsec.music_player.core.models.PlaylistModel;
import com.nejman.nsec.music_player.media.NewtoneMediaPlayer;

import java.util.ArrayList;
import java.util.List;
import java.util.function.Consumer;

public class ContextMenuBuilder {
    public static void buildForSearchResult(View sender, String modelInfo) {
        List<String> elements = new ArrayList<>();
        elements.add(MainActivity.instance.getString(R.string.download));
        build(sender, elements, item -> {
            if (item.equals(MainActivity.instance.getString(R.string.download))) {
                DataContainer.getInstance().getDownloads().add(modelInfo);
            }
        });
    }

    public static void buildForPlaylist(View sender, String playlistName) {
        List<String> elements = new ArrayList<>();
        elements.add(MainActivity.getResString(R.string.playlist_play));
        elements.add(MainActivity.getResString(R.string.track_menu_playlist));
        elements.add(MainActivity.getResString(R.string.track_menu_queue));
        elements.add(MainActivity.getResString(R.string.change_name));
        elements.add(MainActivity.getResString(R.string.track_menu_delete));

        build(sender, elements, item -> {
            if (item.equals(MainActivity.getResString(R.string.playlist_play))) {
                PlaylistModel model = DataContainer.getInstance().getPlaylists().get(playlistName);

                if (model.items.size() > 0) {
                    NewtoneMediaPlayer.getInstance().loadPlaylist(model.getSources(), 0);
                }
            } else if (item.equals(MainActivity.getResString(R.string.track_menu_playlist))) {
                PlaylistModel model = DataContainer.getInstance().getPlaylists().get(playlistName);
                PlaylistsAction.add(model.items);
            } else if (item.equals(MainActivity.getResString(R.string.change_name))) {
                PlaylistsAction.changeName(playlistName);
            } else if (item.equals(MainActivity.getResString(R.string.track_menu_delete))) {
                PlaylistsAction.remove(playlistName);
            } else if (item.equals(MainActivity.getResString(R.string.track_menu_queue))) {
                PlaylistModel model = DataContainer.getInstance().getPlaylists().get(playlistName);
                QueueAction.add(model.items);
                Toast.makeText(MainActivity.instance, MainActivity.getResString(R.string.snack_queue), Toast.LENGTH_SHORT).show();
            }
        });
    }

    public static void buildForTrack(View sender, String modelInfo) {
        String[] elems = modelInfo.split(Global.separator);
        String filePath = elems[0];
        String playlistName = elems.length == 2 ? elems[1] : "";
        List<String> elements = new ArrayList<>();
        elements.add(MainActivity.getResString(R.string.track_menu_edit));
        elements.add(MainActivity.getResString(R.string.track_menu_playlist));
        elements.add(MainActivity.getResString(R.string.track_menu_queue));
        elements.add(MainActivity.getResString(R.string.track_menu_delete));
        build(sender, elements, item -> {
            if (filePath.length() == 11) {
                MainActivity.toast(R.string.snack_file_exists);
                return;
            }

            if (item.equals(MainActivity.getResString(R.string.track_menu_edit))) {
                TracksAction.edit(DataContainer.getInstance().getMediaSources().get(filePath));
            } else if (item.equals(MainActivity.getResString(R.string.track_menu_playlist))) {
                PlaylistsAction.add(filePath);
            } else if (item.equals(MainActivity.getResString(R.string.track_menu_delete))) {
                if (playlistName.equals("")) {
                    TracksAction.remove(filePath);
                } else {
                    PlaylistsAction.remove(playlistName, filePath);
                }
            } else if (item.equals(MainActivity.getResString(R.string.track_menu_queue))) {
                QueueAction.add(filePath);
                Toast.makeText(MainActivity.instance, MainActivity.getResString(R.string.snack_queue), Toast.LENGTH_SHORT).show();
            }
        });
    }

    public static void buildForArtist(View sender, String artistName) {
        List<String> elements = new ArrayList<>();
        elements.add(MainActivity.getResString(R.string.playlist_play));
        elements.add(MainActivity.getResString(R.string.track_menu_playlist));
        elements.add(MainActivity.getResString(R.string.track_menu_queue));

        build(sender, elements, item -> {
            if (item.equals(MainActivity.getResString(R.string.playlist_play))) {
                ArtistModel model = DataContainer.getInstance().getArtists().get(artistName);

                if (model.items.size() > 0) {
                    NewtoneMediaPlayer.getInstance().loadPlaylist(model.getSources(), 0);
                }
            } else if (item.equals(MainActivity.getResString(R.string.track_menu_playlist))) {
                ArtistModel model = DataContainer.getInstance().getArtists().get(artistName);
                PlaylistsAction.add(model.items);
            } else if (item.equals(MainActivity.getResString(R.string.track_menu_queue))) {
                ArtistModel model = DataContainer.getInstance().getArtists().get(artistName);
                QueueAction.add(model.items);
                Toast.makeText(MainActivity.instance, MainActivity.getResString(R.string.snack_queue), Toast.LENGTH_SHORT).show();
            }
        });
    }

    private static void build(View anchor, List<String> elements, Consumer<? super String> action) {
        PopupMenu menu = new PopupMenu(MainActivity.instance.getApplicationContext(), anchor);

        for (String element : elements) {
            menu.getMenu().add(element);
        }
        menu.setOnMenuItemClickListener(item -> {
            action.accept(item.getTitle().toString());
            return true;
        });
        menu.show();
    }
}
