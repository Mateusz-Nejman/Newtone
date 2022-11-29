package com.nejman.nsec.music_player.ui.playlists;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.navigation.fragment.NavHostFragment;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.models.PlaylistModel;
import com.nejman.nsec.music_player.databinding.FragmentPlaylistsBinding;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.ui.ContextMenuBuilder;
import com.nejman.nsec.music_player.ui.MainFragment;
import com.nejman.nsec.music_player.ui.WrappedFragment;

import java.util.ArrayList;
import java.util.List;

import io.reactivex.rxjava3.disposables.Disposable;

public class PlaylistsFragment extends WrappedFragment {
    private FragmentPlaylistsBinding binding;
    private PlaylistsAdapter adapter;
    private Disposable playlistEdited;
    private Disposable playlistAdded;
    private Disposable playlistRemoved;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        binding = FragmentPlaylistsBinding.inflate(inflater, container, false);
        View root = binding.getRoot();
        adapter = new PlaylistsAdapter(this.requireContext());
        binding.gridView.setAdapter(adapter);
        playlistAdded = DataContainer.getInstance().getPlaylists().addOnPlaylistAdded(item -> adapter.addItem(item));
        playlistEdited = DataContainer.getInstance().getPlaylists().addOnPlaylistEdited(item -> adapter.editItem(item));
        playlistRemoved = DataContainer.getInstance().getPlaylists().addOnPlaylistRemoved(item -> adapter.removeItem(item));
        return root;
    }

    @Override
    public void onResume() {
        super.onResume();

        adapter.removeAllItems();
        adapter.addItems(DataContainer.getInstance().getPlaylists().getAll());
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
        playlistAdded.dispose();
        playlistEdited.dispose();
        playlistRemoved.dispose();

        playlistAdded = null;
        playlistEdited = null;
        playlistRemoved = null;
    }

    @Override
    protected String getTitle() {
        MainFragment.instance.fragmentTitle = MainActivity.getResString(R.string.playlists);
        return MainFragment.instance.fragmentTitle;
    }

    private class PlaylistsAdapter extends BaseAdapter implements View.OnClickListener, View.OnLongClickListener {
        private final ArrayList<PlaylistModel> items = new ArrayList<>();
        private final LayoutInflater layoutInflater;

        public PlaylistsAdapter(Context context) {
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

        public void addItem(String playlistName) {
            PlaylistModel model = DataContainer.getInstance().getPlaylists().get(playlistName);
            items.add(model);
            MainActivity.instance.runOnUiThread(this::notifyDataSetChanged);
            updateColumnStretchMode();
        }

        public void addItems(List<PlaylistModel> playlists) {
            items.addAll(playlists);
            MainActivity.instance.runOnUiThread(this::notifyDataSetChanged);
            updateColumnStretchMode();
        }

        public void removeItem(String item) {
            PlaylistModel model = items.stream().filter(_item -> _item.name.equals(item)).findFirst().orElse(null);
            int index = items.indexOf(model);

            if (index == -1) {
                return;
            }

            removeItem(index);
        }

        public void removeItem(int index) {
            items.remove(index);
            MainActivity.instance.runOnUiThread(this::notifyDataSetChanged);
            updateColumnStretchMode();
        }

        public void removeAllItems() {
            items.clear();
            MainActivity.instance.runOnUiThread(this::notifyDataSetChanged);
            updateColumnStretchMode();
        }

        public void editItem(String item) {
            PlaylistModel model = DataContainer.getInstance().getPlaylists().get(item);
            int index = items.indexOf(model);
            items.set(index, model);

            MainActivity.instance.runOnUiThread(this::notifyDataSetChanged);
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            PlaylistModel item = items.get(position);
            if (convertView == null) {
                convertView = layoutInflater.inflate(R.layout.playlist_item, null);
                convertView.setOnClickListener(this);
                convertView.setOnLongClickListener(this);
            }

            convertView.setTag(String.valueOf(position));

            ((TextView) convertView.findViewById(R.id.textView)).setText(item.name);
            ImageView imageView = convertView.findViewById(R.id.imageView);

            Bitmap imageNull = BitmapFactory.decodeResource(MainActivity.getRes(), R.drawable.empty_track);

            for (String filepath : item.items) {
                MediaSource source = DataContainer.getInstance().getMediaSources().get(filepath);

                if (source.image != null) {
                    imageNull = source.image;
                    break;
                }
            }
            imageView.setImageBitmap(item.image == null ? imageNull : item.image);

            return convertView;
        }

        @Override
        public void onClick(View v) {
            int position = Integer.parseInt(v.getTag().toString());
            onItemSelected(position);
        }

        public void onItemSelected(int position) {
            PlaylistModel model = items.get(position);

            Bundle bundle = new Bundle();
            bundle.putString("playlist", model.name);

            NavHostFragment.findNavController(PlaylistsFragment.this).navigate(R.id.navigate_to_tracks, bundle);
        }

        @Override
        public boolean onLongClick(View view) {
            int position = Integer.parseInt(view.getTag().toString());
            PlaylistModel model = items.get(position);
            ContextMenuBuilder.buildForPlaylist(view, model.name);
            return true;
        }

        private void updateColumnStretchMode() {
            if (MainActivity.isCarUiMode()) {
                return;
            }

            if (items.size() < 2) {
                binding.gridView.setStretchMode(GridView.NO_STRETCH);
            } else {
                binding.gridView.setStretchMode(GridView.STRETCH_COLUMN_WIDTH);
            }
        }
    }
}
