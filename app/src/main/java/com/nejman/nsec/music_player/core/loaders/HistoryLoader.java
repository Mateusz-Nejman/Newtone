package com.nejman.nsec.music_player.core.loaders;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.models.HistoryModel;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.nio.file.Files;
import java.util.ArrayList;
import java.util.List;

public class HistoryLoader implements IDataLoader {
    private final File historyFile = new File(MainActivity.dataPath + "/newtoneHistory.data");

    @Override
    public void load() throws Throwable {
        if (historyFile.exists()) {
            List<String> historyTemp = Files.readAllLines(historyFile.toPath());
            List<String> history = new ArrayList<>();

            for (String historyItem : historyTemp) {
                if (!history.contains(historyItem)) {
                    history.add(historyItem);
                }
            }

            for (String historyItem : history) {
                DataContainer.getInstance().getHistory().add(historyItem);
            }
        }
    }

    @Override
    public void save() throws Throwable {
        List<HistoryModel> historyTemp = DataContainer.getInstance().getHistory().get();
        List<String> history = new ArrayList<>();

        for (HistoryModel model : historyTemp) {
            if (!history.contains(model.query)) {
                history.add(model.query);
            }
        }

        String buffer = String.join("\n", history);
        FileWriter fileWriter = new FileWriter(historyFile);
        BufferedWriter bufferedWriter = new BufferedWriter(fileWriter);
        bufferedWriter.write(buffer);
        bufferedWriter.close();
        fileWriter.close();
    }
}
