package com.nejman.nsec.music_player.ui;

import android.view.View;

import androidx.appcompat.app.ActionBar;
import androidx.fragment.app.Fragment;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;

public class WrappedFragment extends Fragment {
    protected void showMenu(int id, boolean show) {
        if (MainActivity.instance.menu == null) {
            return;
        }

        MainActivity.instance.menu.findItem(id).setVisible(show);
    }

    protected void showSearch(boolean show) {
        showMenu(R.id.search, show);
    }

    protected void showDownloadButton(boolean show) {
        showMenu(R.id.downloadButton, show);
    }

    protected void showPlayer(boolean show) {
        MainActivity.instance.showPlayerPanel(show);
    }

    protected void showActionBar(boolean show) {
        ActionBar actionBarCompat = MainActivity.instance.getSupportActionBar();
        android.app.ActionBar actionBar = MainActivity.instance.getActionBar();

        if (actionBarCompat == null) {
            if (actionBar == null) {
                return;
            }

            if (show) {
                actionBar.show();
            } else {
                actionBar.hide();
            }
        } else {
            if (show) {
                actionBarCompat.show();
            } else {
                actionBarCompat.hide();
            }
        }
    }

    protected void showNavigationView(boolean show) {
        if (show) {
            MainActivity.instance.navigationView.setVisibility(View.VISIBLE);
        } else {
            MainActivity.instance.navigationView.setVisibility(View.GONE);
        }
    }
}
