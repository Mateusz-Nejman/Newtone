package com.nejman.nsec.music_player.core.loaders;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.models.PlaylistModel;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.nio.file.Files;
import java.util.ArrayList;
import java.util.List;

public class PlaylistLoader implements IDataLoader {
    private final File playlistsFile = new File(MainActivity.dataPath + "/newtonePlaylists.data");

    public void load() throws Throwable {

        if (playlistsFile.exists()) {
            List<String> playlists = Files.readAllLines(playlistsFile.toPath());

            for (String playlistBuffer : playlists) {
                List<String> playlist = new ArrayList<>();
                String[] parts = playlistBuffer.split(Global.separator);
                String name = parts[0];
                String[] items = parts[1].split(";");

                for (String filepath : items) {
                    File file = new File(filepath);

                    if (file.exists() || filepath.length() == 11) {
                        playlist.add(filepath);
                    }
                }

                DataContainer.getInstance().getPlaylists().addPlaylist(name, new PlaylistModel(name, null, playlist));
            }
        }
    }

    public void save() throws Throwable {
        if (DataContainer.getInstance().getPlaylists().count() > 0) {
            List<String> buffer = new ArrayList<>();
            DataContainer.getInstance().getPlaylists().forEach(key -> {
                PlaylistModel playlist = DataContainer.getInstance().getPlaylists().get(key);

                if (playlist.items.size() > 0) {
                    StringBuilder playlistItem = new StringBuilder(key + Global.separator);

                    for (String item : playlist.items) {
                        playlistItem.append(item).append(";");
                    }

                    buffer.add(playlistItem.toString());
                }
            });

            FileWriter fileWriter = new FileWriter(playlistsFile);
            BufferedWriter bufferedWriter = new BufferedWriter(fileWriter);
            bufferedWriter.write(String.join("\n", buffer));
            bufferedWriter.close();
            fileWriter.close();
        }
    }
}
