package com.nejman.nsec.music_player.core.dataContainers;

import com.nejman.nsec.music_player.core.loaders.DataLoader;
import com.nejman.nsec.music_player.core.models.HistoryModel;

import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

public class HistoryDataContainer {
    private final List<HistoryModel> items;

    public HistoryDataContainer(List<HistoryModel> items)
    {
        this.items = items;
    }

    public List<HistoryModel> get()
    {
        return this.items;
    }

    public void add(String item)
    {
        HistoryModel model = new HistoryModel();
        model.query = item;
        add(model);
    }

    public void addIfNeeded(String item)
    {
        HistoryModel foundExists = items.stream().filter(historyModel -> historyModel.query.toLowerCase(Locale.ROOT).equals(item.toLowerCase(Locale.ROOT))).findFirst().orElse(null);

        if(foundExists != null)
        {
            return;
        }

        add(item);
        try {
            DataLoader.save();
        } catch (Throwable throwable) {
            throwable.printStackTrace();
        }
    }

    public void add(HistoryModel item)
    {
        this.items.add(item);
    }
}
