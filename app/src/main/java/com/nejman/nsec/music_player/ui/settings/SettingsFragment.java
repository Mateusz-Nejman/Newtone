package com.nejman.nsec.music_player.ui.settings;

import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.os.Bundle;

import androidx.appcompat.app.ActionBar;
import androidx.preference.ListPreference;
import androidx.preference.Preference;
import androidx.preference.PreferenceFragmentCompat;
import androidx.preference.PreferenceManager;
import androidx.preference.SwitchPreference;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.R;
import com.nejman.nsec.music_player.core.loaders.DataLoader;
import com.nejman.nsec.music_player.media.MediaFormat;

import java.util.Objects;

public class SettingsFragment extends PreferenceFragmentCompat {
    @Override
    public void onCreatePreferences(Bundle savedInstanceState, String rootKey) {
        ActionBar actionBar = MainActivity.instance.getSupportActionBar();
        if (actionBar != null) {
            actionBar.setDisplayHomeAsUpEnabled(true);
            actionBar.setTitle(R.string.settings);
        }
        setPreferencesFromResource(R.xml.settings_list, rootKey);
        SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(this.requireContext());
        Preference about = findPreference("about");
        try {
            Objects.requireNonNull(about).setTitle("Newtone Lightning " + requireActivity().getPackageManager().getPackageInfo(MainActivity.instance.getPackageName(), 0).versionName);
        } catch (PackageManager.NameNotFoundException e) {
            e.printStackTrace();
        }

        SwitchPreference ignore = findPreference("ignoreBroadcast");
        ListPreference mediaType = findPreference("mediaFormat");
        Objects.requireNonNull(ignore).setChecked(Global.ignoreAutoFocus);
        Objects.requireNonNull(mediaType).setValue(Global.mediaFormat == MediaFormat.ogg ? "ogg" : "m4a");

        preferences.registerOnSharedPreferenceChangeListener((sharedPreferences, key) -> {
            if (key.equals("ignoreBroadcast")) {
                Global.ignoreAutoFocus = sharedPreferences.getBoolean("ignoreBroadcast", false);
                try {
                    DataLoader.save();
                } catch (Throwable throwable) {
                    throwable.printStackTrace();
                }
            }
            else if(key.equals("mediaFormat"))
            {
                ListPreference preference = findPreference("mediaFormat");
                assert preference != null;
                Global.mediaFormat = Objects.equals(preference.getValue(), "ogg") ? MediaFormat.ogg : MediaFormat.m4a;
            }
        });
    }
}
