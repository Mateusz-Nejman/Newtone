package com.nejman.nsec.music_player.ui;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.core.content.ContextCompat;

import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.databinding.FragmentMainBinding;

public class MainFragment extends WrappedFragment {
    private FragmentMainBinding binding;
    private MainFragmentManager manager;
    public static MainFragment instance;
    public String fragmentTitle;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        binding = FragmentMainBinding.inflate(inflater, container, false);
        instance = this;
        System.out.println("MainFragment onCreateView");
        View root = binding.getRoot();
        binding.tabLayout.setTabTextColors(ContextCompat.getColor(MainActivity.instance, R.color.white), ContextCompat.getColor(MainActivity.instance, R.color.blue));
        binding.viewPager.setAdapter(new MainFragmentAdapter(MainActivity.instance));
        manager = new MainFragmentManager(binding.tabLayout, binding.viewPager);
        return root;
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

    @Override
    protected String getTitle() {
        if (fragmentTitle == null) {
            return MainFragment.instance.getString(R.string.app_name);
        }
        return fragmentTitle;
    }
}
