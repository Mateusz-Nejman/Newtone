package com.nejman.nsec.music_player.media;

import android.media.MediaPlayer;
import android.widget.Toast;

import com.github.kiulian.downloader.model.videos.formats.AudioFormat;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.YoutubeDownloadHelper;

import java.io.IOException;
import java.util.concurrent.atomic.AtomicReference;

public class WebPlayerController implements IPlayerController{

    @Override
    public void load(MediaPlayer mediaPlayer, String path) throws IOException {
        mediaPlayer.reset();

        AtomicReference<String> url = new AtomicReference<>(path);
        if(!url.get().startsWith("https://"))
        {
            Thread urlThread = new Thread(() -> {
                AudioFormat format = YoutubeDownloadHelper.getBestAudioFormat(path);

                if(format == null)
                {
                    MainActivity.instance.runOnUiThread(()-> Toast.makeText(MainActivity.instance, MainActivity.instance.getString(R.string.snack_file_exists), Toast.LENGTH_SHORT).show());
                    return;
                }

                url.set(format.url());
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

    @Override
    public void prepared(MediaPlayer mediaPlayer) {

    }

    @Override
    public void completed(MediaPlayer mediaPlayer) {

    }
}
