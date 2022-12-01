package com.nejman.nsec.music_player;

import android.Manifest;
import android.annotation.SuppressLint;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.SearchManager;
import android.app.UiModeManager;
import android.content.ComponentName;
import android.content.Context;
import android.content.res.Configuration;
import android.content.res.Resources;
import android.database.MatrixCursor;
import android.media.AudioFocusRequest;
import android.media.AudioManager;
import android.os.Bundle;
import android.os.Environment;
import android.support.v4.media.MediaBrowserCompat;
import android.support.v4.media.MediaMetadataCompat;
import android.support.v4.media.session.MediaControllerCompat;
import android.support.v4.media.session.MediaSessionCompat;
import android.support.v4.media.session.PlaybackStateCompat;
import android.view.Menu;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.SearchView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.app.AppCompatDelegate;
import androidx.navigation.fragment.NavHostFragment;

import com.nejman.nsec.music_player.core.DataContainer;
import com.nejman.nsec.music_player.core.bluetooth.BluetoothManager;
import com.nejman.nsec.music_player.core.loaders.DataLoader;
import com.nejman.nsec.music_player.core.models.HistoryModel;
import com.nejman.nsec.music_player.databinding.ActivityMainBinding;
import com.nejman.nsec.music_player.media.MediaPlayerHelper;
import com.nejman.nsec.music_player.media.MusicPlaybackService;
import com.nejman.nsec.music_player.media.NewtoneMediaPlayer;
import com.nejman.nsec.music_player.ui.MainNavigation;
import com.nejman.nsec.music_player.ui.SearchAdapter;
import com.nejman.nsec.music_player.ui.SwipeController;

import java.io.File;
import java.util.List;
import java.util.Locale;
import java.util.Objects;
import java.util.stream.Collectors;

import io.reactivex.rxjava3.disposables.Disposable;

public class MainActivity extends AppCompatActivity {
    public static MediaBrowserCompat mediaBrowser;
    private ActivityMainBinding binding;
    public Menu menu;
    public static NotificationManager notificationManager;
    public static MainActivity instance;
    public static String dataPath;
    public static String musicPath;
    public static BluetoothManager bluetoothManager;
    public MainNavigation navigation;
    private SwipeController swipeController;
    private Disposable swipedLeft;
    private Disposable swipedRight;

    public MainActivity() {
        AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_YES);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        instance = this;
        binding = ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());
        navigation = new MainNavigation((NavHostFragment) Objects.requireNonNull(getSupportFragmentManager().findFragmentById(R.id.nav_host_fragment)));

        initialize();
        mediaBrowser = new MediaBrowserCompat(this,
                new ComponentName(this, MusicPlaybackService.class),
                connectionCallbacks,
                null); // optional Bundle

        swipeController = new SwipeController();

        swipedLeft = swipeController.addOnSwipeLeft(state -> {
            if (Global.inFullscreenPlayer) {
                NewtoneMediaPlayer.getInstance().next();
            } else {
                onBackPressed();
            }
        });
        swipedRight = swipeController.addOnSwipeRight(state -> {
            if (Global.inFullscreenPlayer) {
                NewtoneMediaPlayer.getInstance().prev();
            } else {
                onBackPressed();
            }
        });
    }

    @Override
    public void onStart() {
        super.onStart();
        if (!mediaBrowser.isConnected()) {
            try {
                mediaBrowser.connect();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    @Override
    public void onResume() {
        try {
            super.onResume();
            setVolumeControlStream(AudioManager.STREAM_MUSIC);
        } catch (Exception e) {
            e.printStackTrace();
        }
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

        swipedLeft.dispose();
        swipedRight.dispose();
    }

    @Override
    public void onBackPressed() {
        if (getSupportFragmentManager().getBackStackEntryCount() > 0) {
            getSupportFragmentManager().popBackStack();
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
            navigation.navigate(R.id.navigate_to_downloads);
        } else if (item.getItemId() == R.id.bluetoothButton) {
            if (MainActivity.bluetoothManager.canSend()) {
                navigation.navigate(R.id.navigate_to_bluetooth);
            } else {
                toast(R.string.bluetooth_no_device);
            }
        } else if (item.getItemId() == R.id.settingsButton) {
            navigation.navigate(R.id.navigate_to_settings);
        }

        return super.onOptionsItemSelected(item);
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
                search.setQuery(((SearchAdapter) search.getSuggestionsAdapter()).get(position), true);
                return true;
            }

            @Override
            public boolean onSuggestionClick(int position) {
                search.setQuery(((SearchAdapter) search.getSuggestionsAdapter()).get(position), true);
                return false;
            }
        });

        search.setOnSearchClickListener(view -> {
            String[] columns = new String[]{"_id", "text"};
            Object[] temp = new Object[]{0, "default"};
            MatrixCursor cursor = new MatrixCursor(columns);
            List<HistoryModel> items = DataContainer.getInstance().getHistory().get();

            for (int i = 0; i < items.size(); i++) {
                temp[0] = i;
                temp[1] = items.get(i);
                cursor.addRow(temp);
            }
            search.setQueryHint(getResString(R.string.search_tip));
            search.setSuggestionsAdapter(new SearchAdapter(MainActivity.this, cursor, items));
            search.setQuery("", false);
        });

        search.setOnQueryTextListener(new SearchView.OnQueryTextListener() {

            @Override
            public boolean onQueryTextSubmit(String query) {
                Bundle searchBundle = new Bundle();
                searchBundle.putString("query", query);

                DataContainer.getInstance().getHistory().addIfNeeded(query);
                navigation.navigate(R.id.navigate_to_search, searchBundle);
                closeKeyboard();
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

    @Override
    public boolean dispatchTouchEvent(MotionEvent event) {
        if (navigation.getModalCount() >= 1 && swipeController.dispatchTouchEvent(event)) {
            return true;
        }

        return super.dispatchTouchEvent(event);
    }

    public void showPlayerPanel(boolean show) {
        binding.playerView.setVisibility((show && !Global.inFullscreenPlayer) ? View.VISIBLE : View.GONE);
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
        notificationChannel.enableVibration(false);
        notificationManager.createNotificationChannel(notificationChannel);
        AudioFocusRequest audioFocusRequest = new AudioFocusRequest.Builder(AudioManager.AUDIOFOCUS_GAIN_TRANSIENT).setOnAudioFocusChangeListener(Global.audioFocusListener).build();
        ((AudioManager) getSystemService(AUDIO_SERVICE)).requestAudioFocus(audioFocusRequest);

        String[] permissions = new String[]{Manifest.permission.MANAGE_EXTERNAL_STORAGE, Manifest.permission.WRITE_EXTERNAL_STORAGE, Manifest.permission.READ_EXTERNAL_STORAGE, Manifest.permission.BLUETOOTH_CONNECT, Manifest.permission.BLUETOOTH_SCAN, Manifest.permission.BLUETOOTH};
        if (!PermissionHelper.checkPermissions(permissions)) {
            PermissionHelper.requestPermissions(permissions, 111);
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
                DataLoader.playerStateLoader.load();
            } catch (Throwable e) {
                e.printStackTrace();
            }
        });
        audioLoader.start();
        bluetoothManager = new BluetoothManager(getSystemService(android.bluetooth.BluetoothManager.class));
    }

    private void closeKeyboard() {
        View view = this.getCurrentFocus();

        if (view != null) {
            InputMethodManager manager
                    = (InputMethodManager)
                    getSystemService(
                            Context.INPUT_METHOD_SERVICE);
            manager
                    .hideSoftInputFromWindow(
                            view.getWindowToken(), 0);
        }
    }

    public static boolean isCarUiMode() {
        UiModeManager uiModeManager = (UiModeManager) instance.getSystemService(Context.UI_MODE_SERVICE);
        return uiModeManager.getCurrentModeType() == Configuration.UI_MODE_TYPE_CAR;
    }

    private final MediaBrowserCompat.ConnectionCallback connectionCallbacks =
            new MediaBrowserCompat.ConnectionCallback() {
                @Override
                public void onConnected() {
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