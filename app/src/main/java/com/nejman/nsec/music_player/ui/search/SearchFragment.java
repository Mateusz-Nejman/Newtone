package com.nejman.nsec.music_player.ui.search;

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
import androidx.appcompat.app.ActionBar;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.YoutubeDownloadHelper;
import com.nejman.nsec.music_player.databinding.FragmentSearchBinding;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.media.NewtoneMediaPlayer;
import com.nejman.nsec.music_player.ui.ContextMenuBuilder;
import com.nejman.nsec.music_player.ui.WrappedFragment;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

public class SearchFragment extends WrappedFragment {
    private FragmentSearchBinding binding;
    private SearchAdapter adapter;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        binding = FragmentSearchBinding.inflate(inflater, container, false);
        View root = binding.getRoot();
        this.showSearch(false);
        adapter = new SearchAdapter(this.requireContext());
        binding.listView.setAdapter(adapter);

        if (getArguments() == null) {
            return root;
        }

        String query = getArguments().getString("query");
        ActionBar actionBar = MainActivity.instance.getSupportActionBar();

        if (actionBar == null) {
            return root;
        }
        actionBar.setTitle(query);

        Thread searchThread = new Thread(() -> {
            List<MediaSource> searchResult = YoutubeDownloadHelper.search(query);

            for (MediaSource source : searchResult) {
                adapter.addItem(source);
            }
        });
        searchThread.start();

        return root;
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        this.showSearch(true);
        binding = null;
    }

    private static class SearchAdapter extends BaseAdapter implements View.OnClickListener {
        private final ArrayList<MediaSource> items = new ArrayList<>();
        private final LayoutInflater layoutInflater;

        public SearchAdapter(Context context) {
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
            items.add(mediaSource);
            MainActivity.instance.runOnUiThread(this::notifyDataSetChanged);
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            MediaSource item = items.get(position);
            if (convertView == null) {
                convertView = layoutInflater.inflate(R.layout.base_track_item, null);
                convertView.setOnClickListener(this);
            }

            convertView.setTag(String.valueOf(position));

            ((TextView) convertView.findViewById(R.id.titleView)).setText(item.title);
            ((TextView) convertView.findViewById(R.id.authorView)).setText(item.artist);
            ((TextView) convertView.findViewById(R.id.durationView)).setText(item.getDurationString());
            convertView.findViewById(R.id.menuButton).setOnClickListener(v -> ContextMenuBuilder.buildForSearchResult(v, item.title + Global.separator + item.id + Global.separator + item.playlistId));
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
            MediaSource clickedSource = (MediaSource) getItem(position);
            Global.currentPlaylist.clear();
            Global.currentPlaylist.addAll(items);
            Global.currentPlaylistPosition = position;
            NewtoneMediaPlayer.getInstance().load(clickedSource);
            NewtoneMediaPlayer.getInstance().play();
        }
    }
}
