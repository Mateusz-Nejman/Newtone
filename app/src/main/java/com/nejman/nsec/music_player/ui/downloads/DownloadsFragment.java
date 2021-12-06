package com.nejman.nsec.music_player.ui.downloads;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.models.ArtistModel;
import com.nejman.nsec.music_player.core.models.DownloadModel;
import com.nejman.nsec.music_player.core.models.PlaylistModel;
import com.nejman.nsec.music_player.databinding.FragmentDownloadsBinding;
import com.nejman.nsec.music_player.databinding.FragmentPlaylistsBinding;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.ui.ContextMenuBuilder;
import com.nejman.nsec.music_player.ui.WrappedFragment;
import com.nejman.nsec.music_player.ui.artists.ArtistsFragment;

import java.util.ArrayList;
import java.util.List;

import io.reactivex.rxjava3.disposables.Disposable;

public class DownloadsFragment extends WrappedFragment {
    private FragmentDownloadsBinding binding;
    private DownloadsAdapter adapter;
    private Disposable downloadEdited;
    private Disposable downloadAdded;
    private Disposable downloadRemoved;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        binding = FragmentDownloadsBinding.inflate(inflater, container, false);
        View root = binding.getRoot();
        showDownloadButton(false);
        adapter = new DownloadsAdapter(this.requireContext());
        binding.listView.setAdapter(adapter);

        adapter.addItems(DataContainer.getInstance().getDownloads().getAll());
        downloadAdded = DataContainer.getInstance().getDownloads().addOnDownloadAdded(item -> adapter.addItem(item));
        downloadEdited = DataContainer.getInstance().getDownloads().addOnDownloadEdited(item -> MainActivity.instance.runOnUiThread(() -> adapter.editItem(item)));
        downloadRemoved = DataContainer.getInstance().getDownloads().addOnDownloadRemoved(item -> MainActivity.instance.runOnUiThread(() -> adapter.removeItem(item)));

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
        showDownloadButton(true);
        binding = null;
        downloadAdded.dispose();
        downloadEdited.dispose();
        downloadRemoved.dispose();

        downloadAdded = null;
        downloadEdited = null;
        downloadRemoved = null;
    }

    private static class DownloadsAdapter extends BaseAdapter
    {
        private final ArrayList<DownloadModel> items = new ArrayList<>();
        private final LayoutInflater layoutInflater;
        public DownloadsAdapter(Context context) {
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

        public void addItem(String id)
        {
            DownloadModel model = DataContainer.getInstance().getDownloads().get(id);
            items.add(model);
            notifyDataSetChanged();
        }

        public void addItems(List<DownloadModel> models)
        {
            items.addAll(models);
            notifyDataSetChanged();
        }

        public void removeItem(String id) {
            DownloadModel model = items.stream().filter(_item -> _item.id.equals(id)).findFirst().orElse(null);
            int index = items.indexOf(model);

            if (index == -1) {
                return;
            }

            removeItem(index);
        }

        public void removeItem(int index)
        {
            items.remove(index);
            notifyDataSetChanged();
        }

        public void editItem(String id)
        {
            DownloadModel model = DataContainer.getInstance().getDownloads().get(id);
            int index = items.indexOf(model);
            items.set(index, model);

            notifyDataSetChanged();
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            DownloadModel item = items.get(position);
            if(convertView == null)
            {
                convertView = layoutInflater.inflate(R.layout.download_item, null);
            }

            convertView.setTag(String.valueOf(position));

            ((TextView)convertView.findViewById(R.id.textView)).setText(item.title);
            ((TextView)convertView.findViewById(R.id.progressView)).setText(Integer.valueOf(item.progress)+"%");

            return convertView;
        }
    }
}
