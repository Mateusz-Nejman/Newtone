package com.nejman.nsec.music_player.ui;

import android.content.Context;
import android.database.Cursor;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CursorAdapter;
import android.widget.TextView;

import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.models.HistoryModel;

import java.util.List;

public class SearchAdapter extends CursorAdapter {

    private final List<HistoryModel> items;

    private TextView text;

    public SearchAdapter(Context context, Cursor cursor, List<HistoryModel> items) {
        super(context, cursor, false);
        this.items = items;

    }

    public String get(int index) {
        return items.get(index).query;
    }

    @Override
    public void bindView(View view, Context context, Cursor cursor) {
        text.setText(items.get(cursor.getPosition()).query);
    }

    @Override
    public View newView(Context context, Cursor cursor, ViewGroup parent) {
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View view = inflater.inflate(R.layout.search_item, parent, false);
        text = view.findViewById(R.id.searchItem);

        return view;

    }
}