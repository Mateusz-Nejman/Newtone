package com.nejman.nsec.music_player;

import android.Manifest;
import android.annotation.SuppressLint;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.SearchManager;
import android.content.ComponentName;
import android.content.pm.PackageManager;
import android.content.res.Resources;
import android.database.MatrixCursor;
import android.graphics.BitmapFactory;
import android.media.AudioFocusRequest;
import android.media.AudioManager;
import android.os.Bundle;
import android.os.Environment;
import android.os.Handler;
import android.support.v4.media.MediaBrowserCompat;
import android.support.v4.media.MediaMetadataCompat;
import android.support.v4.media.session.MediaControllerCompat;
import android.support.v4.media.session.MediaSessionCompat;
import android.support.v4.media.session.PlaybackStateCompat;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.SearchView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.app.AppCompatDelegate;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;

import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.loaders.DataLoader;
import com.nejman.nsec.music_player.core.models.HistoryModel;
import com.nejman.nsec.music_player.databinding.ActivityMainBinding;
import com.nejman.nsec.music_player.media.MediaPlayerHelper;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec.music_player.media.MusicPlaybackService;
import com.nejman.nsec.music_player.media.NewtoneMediaPlayer;
import com.nejman.nsec.music_player.ui.SearchAdapter;

import java.io.File;
import java.io.IOException;
import java.util.List;
import java.util.Locale;
import java.util.stream.Collectors;

public class MainActivity extends AppCompatActivity {

    public static MediaBrowserCompat mediaBrowser;
    private ActivityMainBinding binding;
    public Menu menu;
    public static NotificationManager notificationManager;
    public static MainActivity instance;
    public static String dataPath;
    public static String musicPath;
    public BottomNavigationView navigationView;
    private boolean backPressed = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_YES);
        System.out.println("onCreate");
        instance = this;

        binding = ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        binding.playerViewPlayButton.setOnClickListener(v -> {
            if (NewtoneMediaPlayer.getInstance().isPlaying()) {
                NewtoneMediaPlayer.getInstance().pause();
            } else {
                NewtoneMediaPlayer.getInstance().play();
            }
        });

        navigationView = findViewById(R.id.nav_view);
        navigationView.getMenu().findItem(R.id.navigation_player).setVisible(false);
        // Passing each menu ID as a set of Ids because each
        // menu should be considered as top level destinations.
        AppBarConfiguration appBarConfiguration = new AppBarConfiguration.Builder(
                R.id.navigation_player, R.id.navigation_artists, R.id.navigation_tracks, R.id.navigation_playlists, R.id.navigation_settings)
                .build();
        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_activity_main);
        NavigationUI.setupActionBarWithNavController(this, navController, appBarConfiguration);
        NavigationUI.setupWithNavController(binding.navView, navController);

        initialize();
        mediaBrowser = new MediaBrowserCompat(this,
                new ComponentName(this, MusicPlaybackService.class),
                connectionCallbacks,
                null); // optional Bundle
    }

    public void updatePlayerSource(MediaSource source) {
        if (source == null) {
            return;
        }

        runOnUiThread(() -> {
            System.out.println("sourceChanged");
            binding.playerView.setVisibility(View.VISIBLE);

            binding.playerViewTitle.setText(source.title);
            binding.playerViewArtist.setText(source.artist);

            if (source.image == null) {
                binding.playerViewBackground.setVisibility(View.GONE);
                binding.playerViewBackgroundDarker.setVisibility(View.GONE);
                binding.playerViewImage.setImageBitmap(BitmapFactory.decodeResource(getResources(), R.drawable.empty_track));
            } else {
                binding.playerViewBackground.setVisibility(View.VISIBLE);
                binding.playerViewBackgroundDarker.setVisibility(View.VISIBLE);
                binding.playerViewBackground.setImageBitmap(source.image);
                binding.playerViewImage.setImageBitmap(source.image);
            }
        });
    }

    public void updatePlayerState(boolean isPlaying) {
        runOnUiThread(() -> binding.playerViewPlayButton.setImageResource(isPlaying ? R.drawable.pause_icon : R.drawable.play_icon));
    }

    @Override
    public void onStart() {
        super.onStart();
        try {
            mediaBrowser.connect();
        } catch (Exception e) {
            System.out.println("mediaBrowser.connect exception");
            e.printStackTrace();
        }
    }

    @Override
    public boolean onSearchRequested() {
        System.out.println("onSearchRequested");
        return super.onSearchRequested();
    }

    @Override
    public void onResume() {
        super.onResume();
        setVolumeControlStream(AudioManager.STREAM_MUSIC);
    }

    @Override
    protected void onPause() {
        super.onPause();
    }

    @Override
    public void onStop() {
        super.onStop();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();

        if (MediaControllerCompat.getMediaController(MainActivity.this) != null) {
            MediaControllerCompat.getMediaController(MainActivity.this).unregisterCallback(controllerCallback);
        }
        mediaBrowser.disconnect();
        MediaPlayerHelper.stop();

        try {
            MusicPlaybackService.instance.stopForeground(true);
        } catch (Exception ignore) {

        }
    }

    @Override
    public void onBackPressed() {
        if (getSupportFragmentManager().getBackStackEntryCount() > 0) {
            getSupportFragmentManager().popBackStack();
        } else if (!backPressed) {
            this.backPressed = true;
            Toast.makeText(this, R.string.back_pressed, Toast.LENGTH_SHORT).show();

            new Handler().postDelayed(() -> backPressed = false, 2000);
        } else {
            super.onBackPressed();
        }
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        if (item.getItemId() == android.R.id.home) {
            onBackPressed();
            return true;
        } else if (item.getItemId() == R.id.downloadButton) {
            System.out.println("download button pressed");
            Navigation.findNavController(MainActivity.this, R.id.nav_host_fragment_activity_main).navigate(R.id.navigate_to_downloads);
        }

        return super.onOptionsItemSelected(item);
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        System.out.println("onKeyDown " + keyCode);
        return super.onKeyDown(keyCode, event);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        this.menu = menu;
        getMenuInflater().inflate(R.menu.action_menu, menu);

        SearchManager searchManager = (SearchManager) getSystemService(SEARCH_SERVICE);
        SearchView search = (SearchView) menu.findItem(R.id.search).getActionView();
        search.setSearchableInfo(searchManager.getSearchableInfo(getComponentName()));

        search.setOnSuggestionListener(new SearchView.OnSuggestionListener() {
            @Override
            public boolean onSuggestionSelect(int position) {
                System.out.println("onSuggestionSelect");
                search.setQuery(((SearchAdapter) search.getSuggestionsAdapter()).get(position), true);
                return true;
            }

            @Override
            public boolean onSuggestionClick(int position) {
                System.out.println("onSuggestionClick " + position);
                search.setQuery(((SearchAdapter) search.getSuggestionsAdapter()).get(position), true);
                return false;
            }
        });

        search.setOnQueryTextListener(new SearchView.OnQueryTextListener() {

            @Override
            public boolean onQueryTextSubmit(String query) {
                System.out.println("onQueryTextSubmit " + query);
                Bundle searchBundle = new Bundle();
                searchBundle.putString("query", query);

                DataContainer.getInstance().getHistory().addIfNeeded(query);
                Navigation.findNavController(MainActivity.this, R.id.nav_host_fragment_activity_main).navigate(R.id.navigate_to_search, searchBundle);
                return true;
            }

            @Override
            public boolean onQueryTextChange(String query) {

                String[] columns = new String[]{"_id", "text"};
                Object[] temp = new Object[]{0, "default"};

                MatrixCursor cursor = new MatrixCursor(columns);

                List<HistoryModel> items = DataContainer.getInstance().getHistory().get().stream().filter(item -> item.query.toLowerCase(Locale.ROOT).contains(query.toLowerCase(Locale.ROOT))).collect(Collectors.toList());

                for (int i = 0; i < items.size(); i++) {

                    temp[0] = i;
                    temp[1] = items.get(i);

                    cursor.addRow(temp);

                }

                final SearchView search = (SearchView) menu.findItem(R.id.search).getActionView();
                search.setQueryHint(getResString(R.string.search_tip));

                search.setSuggestionsAdapter(new SearchAdapter(MainActivity.this, cursor, items));

                return true;

            }

        });

        return true;
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        if (requestCode == 111) {
            initializePermissionGained();
        }
    }

    public void showPlayerPanel(boolean show) {
        binding.playerView.setVisibility(show ? View.VISIBLE : View.GONE);
    }

    public static String getResString(int resId) {
        return instance.getString(resId);
    }

    public static void toast(String text) {
        instance.runOnUiThread(() -> Toast.makeText(instance, text, Toast.LENGTH_SHORT).show());
    }

    public static void toast(int resId) {
        toast(getResString(resId));
    }

    public static Resources getRes() {
        return instance.getResources();
    }

    private void initialize() {
        notificationManager = (NotificationManager) getSystemService(NOTIFICATION_SERVICE);
        @SuppressLint("WrongConstant") NotificationChannel notificationChannel = new NotificationChannel("Newtone Lightning", "Newtone Lightning", NotificationManager.IMPORTANCE_MAX);
        notificationChannel.setShowBadge(true);
        notificationManager.createNotificationChannel(notificationChannel);
        AudioFocusRequest audioFocusRequest = new AudioFocusRequest.Builder(AudioManager.AUDIOFOCUS_GAIN_TRANSIENT).setOnAudioFocusChangeListener(Global.audioFocusListener).build();
        ((AudioManager) getSystemService(AUDIO_SERVICE)).requestAudioFocus(audioFocusRequest);

        if (!checkPermissions(new String[]{Manifest.permission.MANAGE_EXTERNAL_STORAGE, Manifest.permission.WRITE_EXTERNAL_STORAGE, Manifest.permission.READ_EXTERNAL_STORAGE})) {
            requestPermissions(new String[]{Manifest.permission.MANAGE_EXTERNAL_STORAGE, Manifest.permission.WRITE_EXTERNAL_STORAGE, Manifest.permission.READ_EXTERNAL_STORAGE}, 111);
            return;
        }

        initializePermissionGained();
    }

    private void initializePermissionGained() {
        dataPath = getFilesDir().getAbsolutePath();
        musicPath = Environment.getExternalStorageDirectory().getAbsolutePath() + "/Music";
        String directory = musicPath + "/Newtone";
        File directoryFile = new File(directory);
        boolean canCheck = true;
        if (!directoryFile.exists()) {
            canCheck = directoryFile.mkdirs();
        }

        if (!canCheck) {
            return;
        }

        Thread audioLoader = new Thread(() -> {
            try {
                DataLoader.load();
                DataLoader.loadTags();
                DataLoader.loadAudioFiles();
            } catch (IOException e) {
                e.printStackTrace();
            }
        });
        audioLoader.start();
    }

    private boolean checkPermissions(String[] permissions) {
        for (String permission : permissions) {
            if (checkSelfPermission(permission) != PackageManager.PERMISSION_GRANTED) {
                return false;
            }
        }

        return true;
    }

    private final MediaBrowserCompat.ConnectionCallback connectionCallbacks =
            new MediaBrowserCompat.ConnectionCallback() {
                @Override
                public void onConnected() {
                    System.out.println("MediaBrowser Connection onConnected");
                    MediaSessionCompat.Token token = mediaBrowser.getSessionToken();
                    MediaControllerCompat mediaController =
                            new MediaControllerCompat(MainActivity.this, token);

                    MediaControllerCompat.setMediaController(MainActivity.this, mediaController);
                    mediaController.registerCallback(controllerCallback);
                }

                @Override
                public void onConnectionSuspended() {
                    // The Service has crashed. Disable transport controls until it automatically reconnects
                }

                @Override
                public void onConnectionFailed() {
                    // The Service has refused our connection
                }
            };

    MediaControllerCompat.Callback controllerCallback =
            new MediaControllerCompat.Callback() {
                @Override
                public void onMetadataChanged(MediaMetadataCompat metadata) {
                    super.onMetadataChanged(metadata);
                }

                @Override
                public void onPlaybackStateChanged(PlaybackStateCompat state) {
                    super.onPlaybackStateChanged(state);
                }
            };
}