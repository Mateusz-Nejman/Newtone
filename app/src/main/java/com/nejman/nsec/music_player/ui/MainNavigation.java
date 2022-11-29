package com.nejman.nsec.music_player.ui;

import android.os.Bundle;

import androidx.navigation.fragment.NavHostFragment;

public class MainNavigation {
    private final NavHostFragment navHostFragment;

    public MainNavigation(NavHostFragment navHostFragment) {
        this.navHostFragment = navHostFragment;
    }

    public void navigate(int resId) {
        navHostFragment.getNavController().navigate(resId);
    }

    public void navigate(int resId, Bundle bundle) {
        navHostFragment.getNavController().navigate(resId, bundle);
    }

    public int getModalCount() {
        return navHostFragment.getChildFragmentManager().getBackStackEntryCount();
    }
}
