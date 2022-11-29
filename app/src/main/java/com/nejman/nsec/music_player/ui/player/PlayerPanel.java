package com.nejman.nsec.music_player.ui.player;

import android.content.Context;
import android.graphics.BitmapFactory;
import android.util.AttributeSet;
import android.view.View;
import android.widget.FrameLayout;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.widget.AppCompatButton;
import androidx.constraintlayout.widget.ConstraintLayout;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.media.NewtoneMediaPlayer;

import io.reactivex.rxjava3.disposables.Disposable;

public class PlayerPanel extends ConstraintLayout {
    private ImageView playerViewBackground;
    private FrameLayout playerViewBackgroundDarker;
    private ImageButton playerViewImage;
    private TextView playerViewTitle;
    private TextView playerViewArtist;
    private ImageButton playerViewPlayButton;

    private Disposable stateChanged;
    private Disposable mediaSourceChanged;

    public PlayerPanel(@NonNull Context context) {
        super(context);
        init();
    }

    public PlayerPanel(@NonNull Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
        init();
    }

    public PlayerPanel(@NonNull Context context, @Nullable AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        init();
    }

    public PlayerPanel(@NonNull Context context, @Nullable AttributeSet attrs, int defStyleAttr, int defStyleRes) {
        super(context, attrs, defStyleAttr, defStyleRes);
        init();
    }

    protected void finalize() {
        stateChanged.dispose();
        mediaSourceChanged.dispose();
    }

    private void init() {
        inflate(getContext(), R.layout.player_layout, this);
        playerViewBackground = findViewById(R.id.playerViewBackground);
        playerViewBackgroundDarker = findViewById(R.id.playerViewBackgroundDarker);
        playerViewImage = findViewById(R.id.playerViewImage);
        playerViewTitle = findViewById(R.id.playerViewTitle);
        playerViewArtist = findViewById(R.id.playerViewArtist);
        AppCompatButton playerViewButton = findViewById(R.id.playerViewButton);
        playerViewPlayButton = findViewById(R.id.playerViewPlayButton);
        setAlpha(0.0f);
        setVisibility(GONE);
        playerViewTitle.setSelected(true);

        playerViewPlayButton.setOnClickListener(v -> {
            if (NewtoneMediaPlayer.getInstance().isPlaying()) {
                NewtoneMediaPlayer.getInstance().pause();
            } else {
                NewtoneMediaPlayer.getInstance().play();
            }
        });

        playerViewButton.setOnClickListener(v -> MainActivity.instance.navigation.navigate(R.id.navigate_to_player));

        setMediaSource(Global.currentSource);

        stateChanged = NewtoneMediaPlayer.getInstance().addOnStateChanged(this::updatePlayerState);
        mediaSourceChanged = NewtoneMediaPlayer.getInstance().addOnMediaSourceChanged(this::setMediaSource);
    }

    public void setMediaSource(MediaSource mediaSource) {
        MainActivity.instance.runOnUiThread(() -> {
            if (mediaSource == null) {
                setVisibility(GONE);
                return;
            }

            setVisibility(Global.inFullscreenPlayer ? GONE : VISIBLE);
            animate().setDuration(500).alpha(1.0f);

            playerViewTitle.setText(mediaSource.title);
            playerViewArtist.setText(mediaSource.artist);

            if (mediaSource.image == null) {
                playerViewBackground.setVisibility(View.GONE);
                playerViewBackgroundDarker.setVisibility(View.GONE);
                playerViewImage.setImageBitmap(BitmapFactory.decodeResource(getResources(), R.drawable.empty_track));
            } else {
                playerViewBackground.setVisibility(View.VISIBLE);
                playerViewBackgroundDarker.setVisibility(View.VISIBLE);
                playerViewBackground.setImageBitmap(mediaSource.image);
                playerViewImage.setImageBitmap(mediaSource.image);
            }
        });
    }

    public void updatePlayerState(boolean isPlaying) {
        MainActivity.instance.runOnUiThread(() -> playerViewPlayButton.setImageResource(isPlaying ? R.drawable.pause_icon : R.drawable.play_icon));
    }
}
