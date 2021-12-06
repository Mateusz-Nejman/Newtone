package com.nejman.nsec.music_player.ui.artists;

import android.content.Context;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.BaseAdapter;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBar;
import androidx.fragment.app.Fragment;
import androidx.navigation.Navigation;
import androidx.navigation.fragment.NavHostFragment;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.YoutubeDownloadHelper;
import com.nejman.nsec.music_player.core.models.ArtistModel;
import com.nejman.nsec.music_player.databinding.FragmentArtistsBinding;
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
import java.util.Comparator;
import java.util.List;
import java.util.Objects;
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
        binding.listView.setAdapter(adapter);

        adapter.addItems(DataContainer.getInstance().getArtists().getAll());
        artistAdded = DataContainer.getInstance().getArtists().addOnArtistAdded(model -> adapter.addItem(model));
        artistEdited = DataContainer.getInstance().getArtists().addOnArtistEdited(model -> adapter.editItem(model));
        artistRemoved = DataContainer.getInstance().getArtists().addOnArtistRemoved(model -> adapter.removeItem(model));

        return root;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        System.out.println("onOptionsItemSelected " + item.getTitle());
        return super.onOptionsItemSelected(item);
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

    private class ArtistsAdapter extends BaseAdapter implements View.OnClickListener {
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
        }

        public void addItems(List<ArtistModel> artists) {
            items.addAll(artists);
            items = items.stream().sorted(Comparator.comparing(artistModel -> artistModel.name)).collect(Collectors.toList());
            MainActivity.instance.runOnUiThread(this::notifyDataSetChanged);
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
            notifyDataSetChanged();
        }

        public void editItem(ArtistModel item) {
            System.out.println("Edit item");
            int index = items.indexOf(item);

            removeItem(index);
            addItem(item);
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            ArtistModel item = items.get(position);
            if (convertView == null) {
                convertView = layoutInflater.inflate(R.layout.single_text_item, null);
                convertView.setOnClickListener(this);
            }

            convertView.setTag(String.valueOf(position));

            ((TextView) convertView.findViewById(R.id.textView)).setText(item.name);
            convertView.findViewById(R.id.menuButton).setOnClickListener(v -> {
                System.out.println("show menu");
                ContextMenuBuilder.buildForArtist(v, item.name);
            });
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
    }
}
