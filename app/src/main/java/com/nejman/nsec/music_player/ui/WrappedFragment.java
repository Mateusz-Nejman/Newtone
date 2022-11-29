package com.nejman.nsec.music_player.ui;

import android.os.Bundle;
import android.view.View;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.ActionBar;
import androidx.fragment.app.Fragment;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;

public abstract class WrappedFragment extends Fragment {
    protected abstract String getTitle();

    @Override
    public void onResume() {
        super.onResume();
        System.out.println("onResume");
        ActionBar actionBar = MainActivity.instance.getSupportActionBar();
        if (actionBar != null) {
            if (MainActivity.instance.navigation != null) {
                System.out.println(MainActivity.instance.navigation.getModalCount());
            }
            actionBar.setDisplayHomeAsUpEnabled(MainActivity.instance.navigation != null && MainActivity.instance.navigation.getModalCount() >= 1);
            actionBar.setTitle(getTitle());
            System.out.println("Title " + getTitle());
        }
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        ActionBar actionBar = MainActivity.instance.getSupportActionBar();
        System.out.println("onViewCreated");

        /*if (actionBar != null) {
            if (MainActivity.instance.navigation != null) {
                System.out.println(MainActivity.instance.navigation.getModalCount());
            }
            actionBar.setDisplayHomeAsUpEnabled(MainActivity.instance.navigation != null && MainActivity.instance.navigation.getModalCount() >= 1);
            actionBar.setTitle(fragmentTitle);
        }*/
        /*System.out.println("onViewCreated");
        view.setOnTouchListener(new OnSwipeListener(requireContext()) {
            @Override
            public void onSwipeLeft() {
                super.onSwipeLeft();
                FragmentManager fragmentManager = MainActivity.instance.getSupportFragmentManager();
                NavHostFragment host = NavHostFragment.create(R.navigation.mobile_navigation);
                fragmentManager.beginTransaction()
                        .setCustomAnimations(
                                R.anim.slide_in_left,  // enter
                                R.anim.slide_out_left // exit
                        )
                        .replace(R.id.nav_host_fragment,
                                new SettingsFragment()).addToBackStack(null).commit(); //TODO navigation
            }

            @Override
            public void onSwipeRight() {
                super.onSwipeRight();
            }
        });*/
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

    protected void showNavigationView(boolean show) {
        //if (show) {
        //    MainActivity.instance.navigationView.setVisibility(View.VISIBLE);
        //} else {
        //    MainActivity.instance.navigationView.setVisibility(View.GONE);
        //}
    }
}
