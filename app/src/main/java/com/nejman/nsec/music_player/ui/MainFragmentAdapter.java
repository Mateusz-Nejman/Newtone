package com.nejman.nsec.music_player.ui;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.viewpager2.adapter.FragmentStateAdapter;

import com.nejman.nsec.music_player.ui.artists.ArtistsFragment;
import com.nejman.nsec.music_player.ui.playlists.PlaylistsFragment;
import com.nejman.nsec.music_player.ui.tracks.TracksFragment;

public class MainFragmentAdapter extends FragmentStateAdapter {

    public MainFragmentAdapter(@NonNull FragmentActivity fragmentActivity) {
        super(fragmentActivity);
    }

    @NonNull
    @Override
    public Fragment createFragment(int position) {
        System.out.println("createFragment " + position);
        switch (position) {
            case 1:
                return new ArtistsFragment();
            case 2:
                return new PlaylistsFragment();
            default:
                return new TracksFragment(true);
        }
    }

    @Override
    public int getItemCount() {
        return 3;
    }
}
