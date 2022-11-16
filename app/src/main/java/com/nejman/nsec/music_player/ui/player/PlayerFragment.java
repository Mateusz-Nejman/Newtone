package com.nejman.nsec.music_player.ui.player;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.graphics.drawable.ClipDrawable;
import android.graphics.drawable.Drawable;
import android.graphics.drawable.GradientDrawable;
import android.graphics.drawable.LayerDrawable;
import android.os.Bundle;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.SeekBar;

import androidx.annotation.NonNull;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.loaders.DataLoader;
import com.nejman.nsec.music_player.databinding.FragmentPlayerBinding;
import com.nejman.nsec.music_player.media.MediaPlayerHelper;
import com.nejman.nsec.music_player.media.NewtoneMediaPlayer;
import com.nejman.nsec.music_player.media.PlaybackMode;
import com.nejman.nsec.music_player.ui.BlurBuilder;
import com.nejman.nsec.music_player.ui.ContextMenuBuilder;
import com.nejman.nsec.music_player.ui.WrappedFragment;

import java.util.Objects;
import java.util.Timer;
import java.util.TimerTask;

public class PlayerFragment extends WrappedFragment {
    private FragmentPlayerBinding binding;
    private Timer timer;
    private String playedTrack;
    private boolean isPlayImage = true;
    private PlaybackMode playerMode = PlaybackMode.All;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        Global.inFullscreenPlayer = true;
        binding = FragmentPlayerBinding.inflate(inflater, container, false);
        View root = binding.getRoot();
        binding.titleView.setSelected(true);
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
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
        showActionBar(true);
        showNavigationView(true);
        Global.inFullscreenPlayer = false;
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
            return;
        }

        if (!playedTrack.equals(Global.currentSource.path)) {
            setTrackImage(binding.trackBackground, Global.currentSource.image, true);
            setTrackImage(binding.trackImage, Global.currentSource.image);
            playedTrack = Global.currentSource.path;
        }

        if (isPlayImage && NewtoneMediaPlayer.getInstance().isPlaying()) {
            binding.playButton.setImageResource(R.drawable.pause_icon_blue);
            isPlayImage = false;
        }

        if (!isPlayImage && !NewtoneMediaPlayer.getInstance().isPlaying()) {
            binding.playButton.setImageResource(R.drawable.play_icon_blue);
            isPlayImage = true;
        }

        binding.positionBox.setText(getDurationString(NewtoneMediaPlayer.getInstance().getCurrentPosition()));
        binding.durationBox.setText(getDurationString(NewtoneMediaPlayer.getInstance().getDuration()));

        String oldTitle = binding.titleView.getText().toString();
        if(!Objects.equals(Global.currentSource.title, oldTitle))
        {
            binding.titleView.setText(Global.currentSource.title);
        }
        binding.artistView.setText(Global.currentSource.artist);
        binding.positionSlider.setMax((int) Global.currentSource.duration);
        binding.positionSlider.setProgress(NewtoneMediaPlayer.getInstance().getCurrentPosition(), true);
        binding.progressBar.setMax((int) Global.currentSource.duration);
        binding.progressBar.setProgress(NewtoneMediaPlayer.getInstance().getCurrentPosition(), true);

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

    private void setTrackImage(ImageView imageView, Bitmap image, boolean blur)
    {
        if(image == null)
        {
            image = BitmapFactory.decodeResource(getResources(), R.drawable.empty_track);
        }

        if(blur)
        {
            image = BlurBuilder.blur(getContext(), image);
        }

        imageView.setImageBitmap(image);
    }

    private void setTrackImage(ImageView imageView, Bitmap image)
    {
        setTrackImage(imageView, image, false);
    }
}
