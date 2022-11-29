package com.nejman.nsec.music_player.ui;

import androidx.appcompat.app.ActionBar;
import androidx.fragment.app.Fragment;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;

public abstract class WrappedFragment extends Fragment {
    protected abstract String getTitle();

    @Override
    public void onResume() {
        super.onResume();
        ActionBar actionBar = MainActivity.instance.getSupportActionBar();
        if (actionBar != null) {
            actionBar.setDisplayHomeAsUpEnabled(MainActivity.instance.navigation != null && MainActivity.instance.navigation.getModalCount() >= 1);
            actionBar.setTitle(getTitle());
        }
    }

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

    protected void showBluetoothButton(boolean show) {
        showMenu(R.id.bluetoothButton, show);
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
}
