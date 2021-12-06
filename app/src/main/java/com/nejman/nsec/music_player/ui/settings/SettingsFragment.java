package com.nejman.nsec.music_player.ui.settings;

import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.os.Bundle;

import androidx.preference.Preference;
import androidx.preference.PreferenceFragmentCompat;
import androidx.preference.PreferenceManager;
import androidx.preference.SwitchPreference;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.loaders.DataLoader;

import java.util.Objects;

public class SettingsFragment extends PreferenceFragmentCompat {
    @Override
    public void onCreatePreferences(Bundle savedInstanceState, String rootKey) {
        setPreferencesFromResource(R.xml.settings_list, rootKey);
        SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(this.requireContext());
        Preference about = findPreference("about");
        try {
            Objects.requireNonNull(about).setTitle("Newtone Lightning "+getActivity().getPackageManager().getPackageInfo(MainActivity.instance.getPackageName(), 0).versionName);
        } catch (PackageManager.NameNotFoundException e) {
            e.printStackTrace();
        }

        SwitchPreference ignore = findPreference("ignoreBroadcast");
        Objects.requireNonNull(ignore).setChecked(Global.ignoreAutoFocus);

        preferences.registerOnSharedPreferenceChangeListener((sharedPreferences, key) -> {
            if(key.equals("ignoreBroadcast"))
            {
                Global.ignoreAutoFocus = sharedPreferences.getBoolean("ignoreBroadcast", false);
                try {
                    DataLoader.save();
                } catch (Throwable throwable) {
                    throwable.printStackTrace();
                }
            }
        });
    }
}
