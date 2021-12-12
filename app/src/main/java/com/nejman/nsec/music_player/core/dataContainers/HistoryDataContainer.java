package com.nejman.nsec.music_player.core.dataContainers;

import com.nejman.nsec.music_player.core.YoutubeDownloadHelper;
import com.nejman.nsec.music_player.core.loaders.DataLoader;
import com.nejman.nsec.music_player.core.models.HistoryModel;

import java.util.HashMap;
import java.util.List;
import java.util.Locale;

public class HistoryDataContainer {
    private final List<HistoryModel> items;

    public HistoryDataContainer(List<HistoryModel> items) {
        this.items = items;
    }

    public List<HistoryModel> get() {
        return this.items;
    }

    public void add(String item) {
        HistoryModel model = new HistoryModel();
        model.query = item;
        add(model);
    }

    public void addIfNeeded(String item) {
        HistoryModel model = new HistoryModel();

        HashMap<YoutubeDownloadHelper.Query, String> queryType = YoutubeDownloadHelper.checkLink(item);

        if (queryType.containsKey(YoutubeDownloadHelper.Query.None) || queryType.containsKey(YoutubeDownloadHelper.Query.Search)) {
            model.query = item;
        } else if (queryType.containsKey(YoutubeDownloadHelper.Query.Playlist)) {
            model.query = "playlist:" + queryType.get(YoutubeDownloadHelper.Query.Playlist);
        } else if (queryType.containsKey(YoutubeDownloadHelper.Query.Video)) {
            model.query = "video:" + queryType.get(YoutubeDownloadHelper.Query.Video);
        }
        HistoryModel foundExists = items.stream().filter(historyModel -> historyModel.query.toLowerCase(Locale.ROOT).equals(model.query.toLowerCase(Locale.ROOT))).findFirst().orElse(null);

        if (foundExists != null) {
            return;
        }

        add(model);
        try {
            DataLoader.save();
        } catch (Throwable throwable) {
            throwable.printStackTrace();
        }
    }

    public void add(HistoryModel item) {
        this.items.add(item);
    }
}
