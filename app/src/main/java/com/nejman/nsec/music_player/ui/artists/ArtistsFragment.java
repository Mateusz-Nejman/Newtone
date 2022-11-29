package com.nejman.nsec.music_player.ui.artists;

import android.content.Context;
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
import com.nejman.nsec.music_player.core.models.ArtistModel;
import com.nejman.nsec.music_player.databinding.FragmentArtistsBinding;
import com.nejman.nsec.music_player.ui.ContextMenuBuilder;
import com.nejman.nsec.music_player.ui.MainFragment;
import com.nejman.nsec.music_player.ui.WrappedFragment;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

import io.reactivex.rxjava3.disposables.Disposable;

public class ArtistsFragment extends WrappedFragment {
    private FragmentArtistsBinding binding;
    private ArtistsAdapter adapter;
    private Disposable artistAdded;
    private Disposable artistEdited;
    private Disposable artistRemoved;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        binding = FragmentArtistsBinding.inflate(inflater, container, false);
        View root = binding.getRoot();
        adapter = new ArtistsAdapter(this.requireContext());
        binding.gridView.setAdapter(adapter);
        artistAdded = DataContainer.getInstance().getArtists().addOnArtistAdded(model -> adapter.addItem(model));
        artistEdited = DataContainer.getInstance().getArtists().addOnArtistEdited(model -> adapter.editItem(model));
        artistRemoved = DataContainer.getInstance().getArtists().addOnArtistRemoved(model -> adapter.removeItem(model));
        return root;
    }

    @Override
    public void onResume() {
        super.onResume();
        adapter.removeAllItems();
        adapter.addItems(DataContainer.getInstance().getArtists().getAll());
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
        artistAdded.dispose();
        artistEdited.dispose();
        artistRemoved.dispose();
        artistAdded = null;
        artistEdited = null;
        artistRemoved = null;
    }

    @Override
    protected String getTitle() {
        MainFragment.instance.fragmentTitle = MainActivity.getResString(R.string.artists);
        return MainFragment.instance.fragmentTitle;
    }

    private class ArtistsAdapter extends BaseAdapter implements View.OnClickListener, View.OnLongClickListener {
        private List<ArtistModel> items = new ArrayList<>();
        private final LayoutInflater layoutInflater;

        public ArtistsAdapter(Context context) {
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

        public void addItem(ArtistModel artist) {
            items.add(artist);

            items = items.stream().sorted(Comparator.comparing(artistModel -> artistModel.name)).collect(Collectors.toList());
            MainActivity.instance.runOnUiThread(this::notifyDataSetChanged);
            updateColumnStretchMode();
        }

        public void addItems(List<ArtistModel> artists) {
            items.addAll(artists);
            items = items.stream().sorted(Comparator.comparing(artistModel -> artistModel.name)).collect(Collectors.toList());
            MainActivity.instance.runOnUiThread(this::notifyDataSetChanged);
            updateColumnStretchMode();
        }

        public void removeItem(ArtistModel artist) {
            int index = items.indexOf(artist);

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

        public void editItem(ArtistModel item) {
            int index = items.indexOf(item);

            removeItem(index);
            addItem(item);
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            ArtistModel item = items.get(position);
            if (convertView == null) {
                convertView = layoutInflater.inflate(R.layout.playlist_item, null);
                convertView.setOnClickListener(this);
                convertView.setOnLongClickListener(this);
            }

            convertView.setTag(String.valueOf(position));

            ((TextView) convertView.findViewById(R.id.textView)).setText(item.name);
            ImageView imageView = convertView.findViewById(R.id.imageView);
            imageView.setImageBitmap(item.image == null ? BitmapFactory.decodeResource(MainActivity.getRes(), R.drawable.empty_track) : item.image);

            return convertView;
        }

        @Override
        public void onClick(View v) {
            int position = Integer.parseInt(v.getTag().toString());
            onItemSelected(position);
        }

        public void onItemSelected(int position) {
            ArtistModel model = items.get(position);
            Bundle bundle = new Bundle();
            bundle.putString("artist", model.name);
            NavHostFragment.findNavController(ArtistsFragment.this).navigate(R.id.navigate_to_tracks, bundle);
        }

        @Override
        public boolean onLongClick(View view) {
            int position = Integer.parseInt(view.getTag().toString());
            ContextMenuBuilder.buildForArtist(view, items.get(position).name);
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
