package com.nejman.nsec.music_player.ui;

import androidx.viewpager2.widget.ViewPager2;

import com.google.android.material.tabs.TabLayout;
import com.google.android.material.tabs.TabLayoutMediator;
import com.nejman.nsec.music_player.R;

public class MainFragmentManager {
    private final int[] icons = new int[]{R.drawable.track_icon, R.drawable.artist_icon, R.drawable.playlist_icon};

    public MainFragmentManager(TabLayout tabLayout, ViewPager2 viewPager) {
        TabLayoutMediator mediator = new TabLayoutMediator(tabLayout, viewPager, (tab, position) -> {
            tab.setIcon(icons[position]);
        });
        mediator.attach();
    }
}
