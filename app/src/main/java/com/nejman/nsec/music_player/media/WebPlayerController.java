package com.nejman.nsec.music_player.media;

import android.media.MediaPlayer;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.YoutubeDownloadHelper;

import java.io.IOException;
import java.util.concurrent.atomic.AtomicReference;

public class WebPlayerController implements IPlayerController {

    @Override
    public void load(MediaPlayer mediaPlayer, String path) throws IOException {
        mediaPlayer.reset();

        AtomicReference<String> url = new AtomicReference<>(path);
        if (!url.get().startsWith("https://")) {
            Thread urlThread = new Thread(() -> {
                String format = YoutubeDownloadHelper.getAudioUrl(path);
                if (format == null) {
                    MainActivity.toast(R.string.snack_file_exists);
                    return;
                }

                url.set(format);
            });
            urlThread.start();
            try {
                urlThread.join();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        mediaPlayer.setDataSource(url.get());
    }

    @Override
    public void loaded(MediaPlayer mediaPlayer) {

    }
}
