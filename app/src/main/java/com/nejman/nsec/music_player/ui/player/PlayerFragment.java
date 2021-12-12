package com.nejman.nsec.music_player.ui.player;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.graphics.drawable.ClipDrawable;
import android.graphics.drawable.Drawable;
import android.graphics.drawable.GradientDrawable;
import android.graphics.drawable.LayerDrawable;
import android.os.Bundle;
import android.renderscript.Allocation;
import android.renderscript.RenderScript;
import android.renderscript.ScriptIntrinsic;
import android.renderscript.ScriptIntrinsicBlur;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.SeekBar;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBar;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.loaders.DataLoader;
import com.nejman.nsec.music_player.core.models.ArtistModel;
import com.nejman.nsec.music_player.core.models.DownloadModel;
import com.nejman.nsec.music_player.core.models.PlaylistModel;
import com.nejman.nsec.music_player.databinding.FragmentPlayerBinding;
import com.nejman.nsec.music_player.databinding.FragmentPlaylistsBinding;
import com.nejman.nsec.music_player.media.MediaPlayerHelper;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.media.NewtoneMediaPlayer;
import com.nejman.nsec.music_player.media.PlaybackMode;
import com.nejman.nsec.music_player.ui.ContextMenuBuilder;
import com.nejman.nsec.music_player.ui.WrappedFragment;
import com.nejman.nsec.music_player.ui.artists.ArtistsFragment;

import java.util.ArrayList;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;

import io.reactivex.rxjava3.disposables.Disposable;

public class PlayerFragment extends WrappedFragment {
    private FragmentPlayerBinding binding;
    private Timer timer;
    private String playedTrack;
    private boolean isPlayImage = true;
    private PlaybackMode playerMode = PlaybackMode.All;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        binding = FragmentPlayerBinding.inflate(inflater, container, false);
        View root = binding.getRoot();
        showPlayer(false);
        showActionBar(false);
        showNavigationView(false);
        playedTrack = "";

        binding.positionSlider.setPadding(0, 0, 0, 0);
        GradientDrawable g = new GradientDrawable();
        g.setColor(Color.rgb(50, 130, 184));
        ClipDrawable progress = new ClipDrawable(g, Gravity.START, ClipDrawable.HORIZONTAL);
        GradientDrawable background = new GradientDrawable();
        background.setColor(Color.rgb(26, 26, 26));
        LayerDrawable ld = new LayerDrawable(new Drawable[]{background, progress});
        binding.positionSlider.setProgressDrawableTiled(ld);

        binding.positionSlider.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                if (fromUser) {
                    NewtoneMediaPlayer.getInstance().seek(progress);
                }
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {

            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {

            }
        });

        binding.modeButton.setOnClickListener(v -> {
            if (Global.playbackMode == PlaybackMode.All) {
                Global.playbackMode = PlaybackMode.Single;
            } else if (Global.playbackMode == PlaybackMode.Single) {
                Global.playbackMode = PlaybackMode.Random;
            } else {
                Global.playbackMode = PlaybackMode.All;
            }

            try {
                DataLoader.save();
            } catch (Throwable throwable) {
                throwable.printStackTrace();
            }
        });

        binding.playButton.setOnClickListener(v -> {
            if (Global.currentSource == null) {
                return;
            }

            if (NewtoneMediaPlayer.getInstance().isPlaying()) {
                MediaPlayerHelper.pause();
            } else {
                MediaPlayerHelper.play();
            }
        });

        binding.backButton.setOnClickListener(v -> MainActivity.instance.onBackPressed());

        binding.menuButton.setOnClickListener(v -> ContextMenuBuilder.buildForTrack(v, Global.currentSource.path + Global.separator));

        binding.nextButton.setOnClickListener(v -> {
            MediaPlayerHelper.next();

            if (!isPlayImage) {
                MediaPlayerHelper.play();
            }
        });

        binding.prevButton.setOnClickListener(v -> {
            MediaPlayerHelper.prev();

            if (!isPlayImage) {
                MediaPlayerHelper.play();
            }
        });

        timer = new Timer();
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                MainActivity.instance.runOnUiThread(PlayerFragment.this::refreshView);
            }
        }, 0, 500);

        refreshView();

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
        showActionBar(true);
        showNavigationView(true);
        showPlayer(true);

        timer.cancel();
    }

    private String getDurationString(long duration) {
        int hours = (int) (duration / 3600000);
        int minutes = (int) ((duration - (hours * 3600000)) / 60000);
        int seconds = (int) ((duration - (hours * 3600000) - (minutes * 60000))) / 1000;

        String durationString = "";

        if (hours > 0) {
            durationString += hours + ":";
        }

        durationString += String.format("%1$" + 2 + "s", minutes).replace(' ', '0') + ":";
        durationString += String.format("%1$" + 2 + "s", seconds).replace(' ', '0');

        return durationString;
    }

    private void refreshView() {
        if (Global.currentSource == null) {
            System.out.println("currentSource null");
            return;
        }

        if (!playedTrack.equals(Global.currentSource.path)) {
            boolean visibility = Global.currentSource.image != null;
            binding.trackBackground.setVisibility(visibility ? View.VISIBLE : View.GONE);

            if (visibility) {
                binding.trackBackground.setImageBitmap(Global.currentSource.image);
                binding.trackImage.setImageBitmap(Global.currentSource.image);
            } else {
                binding.trackImage.setImageBitmap(Global.currentSource.image);
            }

            playedTrack = Global.currentSource.path;
        }

        if (isPlayImage && NewtoneMediaPlayer.getInstance().isPlaying()) {
            binding.playButton.setImageResource(R.drawable.pause_icon);
            isPlayImage = false;
        }

        if (!isPlayImage && !NewtoneMediaPlayer.getInstance().isPlaying()) {
            binding.playButton.setImageResource(R.drawable.play_icon);
            isPlayImage = true;
        }

        binding.positionBox.setText(getDurationString(NewtoneMediaPlayer.getInstance().getCurrentPosition()));
        binding.durationBox.setText(getDurationString(NewtoneMediaPlayer.getInstance().getDuration()));
        binding.titleView.setText(Global.currentSource.title);
        binding.artistView.setText(Global.currentSource.artist);
        binding.positionSlider.setMax((int) Global.currentSource.duration);
        binding.positionSlider.setProgress(NewtoneMediaPlayer.getInstance().getCurrentPosition(), true);

        if (Global.playbackMode != playerMode) {
            if (Global.playbackMode == PlaybackMode.All) {
                binding.modeButton.setImageResource(R.drawable.repeat_icon);
            } else if (Global.playbackMode == PlaybackMode.Single) {
                binding.modeButton.setImageResource(R.drawable.repeat_one_icon);
            } else {
                binding.modeButton.setImageResource(R.drawable.random_icon);
            }

            playerMode = Global.playbackMode;
        }
    }
}
