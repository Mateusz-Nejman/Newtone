package com.nejman.nsec.music_player.ui.tracks;

import android.content.Context;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.Utils;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.models.ArtistModel;
import com.nejman.nsec.music_player.core.models.PlaylistModel;
import com.nejman.nsec.music_player.databinding.FragmentTracksBinding;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.media.NewtoneMediaPlayer;
import com.nejman.nsec.music_player.ui.ContextMenuBuilder;
import com.nejman.nsec.music_player.ui.MainFragment;
import com.nejman.nsec.music_player.ui.WrappedFragment;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.stream.Collectors;

import io.reactivex.rxjava3.disposables.Disposable;

public class TracksFragment extends WrappedFragment {
    private FragmentTracksBinding binding;
    private TracksAdapter adapter;
    private String playlist;
    private Disposable trackAdded;
    private Disposable trackEdited;
    private Disposable trackRemoved;
    private String fragmentTitle;
    private final boolean mainFragment;

    public TracksFragment(boolean main) {
        this.mainFragment = main;
    }

    public TracksFragment() {
        this.mainFragment = false;
    }

    @Override
    public void onResume() {
        super.onResume();

        if (!mainFragment) {
            return;
        }

        adapter.removeAllItems();
        adapter.addItems(DataContainer.getInstance().getMediaSources().getAll());
    }

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        binding = FragmentTracksBinding.inflate(inflater, container, false);
        View root = binding.getRoot();
        adapter = new TracksAdapter(this.requireContext());
        binding.listView.setAdapter(adapter);
        Bundle arguments = getArguments();

        fragmentTitle = MainActivity.getResString(R.string.tracks);
        if (arguments == null) {
            adapter.addItems(DataContainer.getInstance().getMediaSources().getAll());
        } else {
            String artist = arguments.getString("artist");
            playlist = arguments.getString("playlist");

            if (artist != null) {
                fragmentTitle = artist;

                ArtistModel artistModel = DataContainer.getInstance().getArtists().get(artist);

                List<MediaSource> sources = new ArrayList<>();

                for (String path : artistModel.items) {
                    sources.add(DataContainer.getInstance().getMediaSources().get(path));
                }

                adapter.addItems(sources);
            } else if (playlist != null) {
                fragmentTitle = playlist;

                PlaylistModel playlistModel = DataContainer.getInstance().getPlaylists().get(playlist);

                List<MediaSource> sources = new ArrayList<>();

                for (String path : playlistModel.items) {
                    sources.add(DataContainer.getInstance().getMediaSources().get(path));
                }

                adapter.addItems(sources);
            }
        }

        trackAdded = DataContainer.getInstance().getMediaSources().addOnSourceAdded(source -> adapter.addItem(source));
        trackEdited = DataContainer.getInstance().getMediaSources().addOnSourceEdited(sources -> adapter.editItem(sources[0], sources[1]));
        trackRemoved = DataContainer.getInstance().getMediaSources().addOnSourceRemoved(source -> adapter.removeItem(source));

        return root;
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
        trackAdded.dispose();
        trackEdited.dispose();
        trackRemoved.dispose();
        trackAdded = null;
        trackEdited = null;
        trackRemoved = null;
    }

    @Override
    protected String getTitle() {
        MainFragment.instance.fragmentTitle = fragmentTitle;
        return MainFragment.instance.fragmentTitle;
    }

    private class TracksAdapter extends BaseAdapter implements View.OnClickListener, View.OnLongClickListener {
        private List<MediaSource> items = new ArrayList<>();
        private final LayoutInflater layoutInflater;

        public TracksAdapter(Context context) {
            layoutInflater = LayoutInflater.from(context);
        }

        @Override
        public int getCount() {
            return items.size();
        }

        @Override
        public Object getItem(int position) {
            return items.get(position);
        }

        @Override
        public long getItemId(int position) {
            return position;
        }

        public void addItem(MediaSource mediaSource) {
            MainActivity.instance.runOnUiThread(() -> {
                items.add(mediaSource);

                if (playlist == null) {
                    items = items.stream().sorted((first, second) -> {
                        String firstC = first.artist + " - " + first.title;
                        String secondC = second.artist + " - " + second.title;

                        return firstC.compareTo(secondC);
                    }).collect(Collectors.toList());
                }
                notifyDataSetChanged();
            });
        }

        public void addItems(List<MediaSource> sources) {
            MainActivity.instance.runOnUiThread(() -> {
                if (playlist == null) {
                    items = sources.stream().sorted((first, second) -> {
                        String firstC = first.artist + " - " + first.title;
                        String secondC = second.artist + " - " + second.title;

                        return firstC.compareTo(secondC);
                    }).collect(Collectors.toList());
                } else {
                    items = new ArrayList<>(sources);
                }

                notifyDataSetChanged();
            });
        }

        public void removeItem(MediaSource mediaSource) {
            int index = items.indexOf(mediaSource);

            if (index == -1) {
                return;
            }

            removeItem(index);
        }

        public void removeItem(int index) {
            items.remove(index);
            notifyDataSetChanged();
        }

        public void removeAllItems() {
            items.clear();
            notifyDataSetChanged();
        }

        public void editItem(MediaSource oldItem, MediaSource newItem) {
            int index = items.indexOf(oldItem);
            items.set(index, newItem);
            items = items.stream().sorted((first, second) -> {
                String firstC = first.artist + " - " + first.title;
                String secondC = second.artist + " - " + second.title;

                return firstC.compareTo(secondC);
            }).collect(Collectors.toList());

            notifyDataSetChanged();
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            MediaSource item = items.get(position);
            if (convertView == null) {
                convertView = layoutInflater.inflate(R.layout.track_item, null);
                convertView.setOnClickListener(this);
                convertView.setOnLongClickListener(this);
            }

            convertView.setTag(String.valueOf(position));

            ((TextView) convertView.findViewById(R.id.titleView)).setText(item.title);
            ((TextView) convertView.findViewById(R.id.authorView)).setText(item.artist);
            ((TextView) convertView.findViewById(R.id.durationView)).setText(Utils.getDurationStringMilliseconds(item.duration));
            ((TextView) convertView.findViewById(R.id.typeView)).setText(getFormatString(item.path));

            convertView.findViewById(R.id.menuButton).setOnClickListener(v -> ContextMenuBuilder.buildForTrack(v, item.path + Global.separator + (playlist == null ? "" : playlist)));
            ImageView imageView = convertView.findViewById(R.id.imageView);

            if (item.image == null) {
                imageView.setImageBitmap(BitmapFactory.decodeResource(MainActivity.instance.getResources(), R.drawable.empty_track));

                if (item.imageUrl != null && !Objects.equals(item.imageUrl, "")) {
                    Thread imageDownloadThread = new Thread(() -> {
                        String _url = item.imageUrl;

                        try {
                            URL url = new URL(_url);
                            HttpURLConnection http = (HttpURLConnection) url.openConnection();
                            int responseCode = http.getResponseCode();

                            if (responseCode == HttpURLConnection.HTTP_OK) {
                                InputStream inputStream = http.getInputStream();
                                ByteArrayOutputStream outputStream = new ByteArrayOutputStream();

                                int bytesRead;
                                byte[] buffer = new byte[4096];
                                while ((bytesRead = inputStream.read(buffer)) != -1) {
                                    outputStream.write(buffer, 0, bytesRead);
                                }

                                byte[] imageRaw = outputStream.toByteArray();
                                item.image = BitmapFactory.decodeByteArray(imageRaw, 0, imageRaw.length);
                                MainActivity.instance.runOnUiThread(() -> imageView.setImageBitmap(item.image));
                                outputStream.close();
                                inputStream.close();
                            } else {
                                item.image = BitmapFactory.decodeResource(MainActivity.instance.getResources(), R.drawable.empty_track);
                                MainActivity.instance.runOnUiThread(() -> imageView.setImageBitmap(item.image));
                            }

                            http.disconnect();
                        } catch (IOException ignored) {

                        }
                    });
                    imageDownloadThread.start();
                }
            } else {
                imageView.setImageBitmap(item.image);
            }

            return convertView;
        }

        @Override
        public void onClick(View v) {
            int position = Integer.parseInt(v.getTag().toString());
            onItemSelected(position);
        }

        public void onItemSelected(int position) {
            NewtoneMediaPlayer.getInstance().loadPlaylist(items, position);
        }

        @Override
        public boolean onLongClick(View view) {
            int position = Integer.parseInt(view.getTag().toString());
            MediaSource item = items.get(position);
            ContextMenuBuilder.buildForTrack(view, item.path + Global.separator + (playlist == null ? "" : playlist));
            return true;
        }

        private String getFormatString(String path) {
            if (path.endsWith(".m4a")) {
                return "m4a";
            } else if (path.endsWith(".ogg")) {
                return "ogg";
            } else if (path.endsWith(".mp3")) {
                return "mp3";
            } else {
                return "web";
            }
        }
    }
}
