package com.nejman.nsec.music_player.core;

import android.provider.MediaStore;
import android.util.Log;

import com.github.kiulian.downloader.YoutubeDownloader;
import com.github.kiulian.downloader.downloader.YoutubeProgressCallback;
import com.github.kiulian.downloader.downloader.request.RequestPlaylistInfo;
import com.github.kiulian.downloader.downloader.request.RequestVideoFileDownload;
import com.github.kiulian.downloader.downloader.request.RequestVideoInfo;
import com.github.kiulian.downloader.downloader.response.Response;
import com.github.kiulian.downloader.model.playlist.PlaylistDetails;
import com.github.kiulian.downloader.model.playlist.PlaylistInfo;
import com.github.kiulian.downloader.model.playlist.PlaylistVideoDetails;
import com.github.kiulian.downloader.model.videos.VideoDetails;
import com.github.kiulian.downloader.model.videos.VideoInfo;
import com.github.kiulian.downloader.model.videos.formats.AudioFormat;
import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.MainActivity;
import com.nejman.nsec.music_player.media.MediaSource;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLDecoder;
import java.net.URLEncoder;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Locale;
import java.util.function.Consumer;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class YoutubeDownloadHelper {
    private static final YoutubeDownloader downloader = new YoutubeDownloader();

    public static AudioFormat getBestAudioFormat(String videoId) {
        RequestVideoInfo request = new RequestVideoInfo(videoId);
        Response<VideoInfo> response = downloader.getVideoInfo(request);
        VideoInfo video = response.data();

        if (video == null) {
            return null;
        }

        return video.bestAudioFormat();
    }

    public static void downloadAudio(String id, String filename, Consumer<? super File> onFinishedConsumer, Consumer<? super Integer> onProgressChanged) {
        //String directory = Environment.getExternalStorageDirectory().getAbsolutePath() + "/NSEC/Music_Player";
        AudioFormat format = getBestAudioFormat(id);
        RequestVideoFileDownload requestDownload = new RequestVideoFileDownload(format);
        requestDownload.saveTo(new File(Global.musicPath)).renameTo(filename).overwriteIfExists(true);
        System.out.println("Start");
        RequestVideoFileDownload request1 = requestDownload.callback(new YoutubeProgressCallback<File>() {
            @Override
            public void onDownloading(int progress) {
                onProgressChanged.accept(progress);
            }

            @Override
            public void onFinished(File data) {
                onFinishedConsumer.accept(data);
            }

            @Override
            public void onError(Throwable throwable) {
                System.out.println("onError");
                throwable.printStackTrace();
            }
        }).async();

        downloader.downloadVideoFile(request1);
    }

    public static MediaSource getVideoInfo(String id, String playlistId) {
        RequestVideoInfo request = new RequestVideoInfo(id);
        Response<VideoInfo> response = downloader.getVideoInfo(request);
        VideoInfo video = response.data();
        VideoDetails details = video.details();
        AudioFormat format = video.bestAudioFormat();
        return new MediaSource(format.url(), details.author(), details.title(), details.lengthSeconds() * 1000L, null, id, details.thumbnails().get(0), playlistId);
    }

    public static List<MediaSource> search(String keyword) {
        HashMap<Query, String> validators = checkLink(keyword);

        if (validators.containsKey(Query.Video)) {
            return new ArrayList<>(Collections.singletonList(getVideoInfo(validators.get(Query.Video), null)));
        }
        else if(validators.containsKey(Query.Search) || validators.containsKey(Query.None))
        {
            try {
                URL url = new URL("https://www.youtube.com/youtubei/v1/search?key=AIzaSyAO_FJ2SlqU8Q4STEHLGCilw_Y9_11qcW8");
                HttpURLConnection http = (HttpURLConnection) url.openConnection();
                http.setRequestMethod("POST");

                JSONObject postObject = new JSONObject();
                postObject.put("query", keyword);
                postObject.put("continuation", null);

                JSONObject postContext = new JSONObject();
                JSONObject postClient = new JSONObject();
                postClient.put("clientName", "WEB");
                postClient.put("clientVersion", "2.20210408.08.00");
                postClient.put("newVisitorCookie", true);
                postClient.put("hl", "en");
                postClient.put("gl", "US");
                postClient.put("utcOffsetMinutes", 0);
                JSONObject postUser = new JSONObject();
                postUser.put("lockedSafetyMode", false);
                postContext.put("client", postClient);
                postContext.put("user", postUser);
                postObject.put("context", postContext);

                http.setDoOutput(true);
                http.setRequestProperty("Content-Type", "application/json");
                byte[] out = postObject.toString().getBytes(StandardCharsets.UTF_8);
                System.out.println(postObject.toString());

                OutputStream stream = http.getOutputStream();
                stream.write(out);
                System.out.println(http.getResponseCode() + " " + http.getResponseMessage());

                InputStreamReader isr = new InputStreamReader(
                        http.getInputStream());
                BufferedReader reader = new BufferedReader(isr);
                StringBuilder sb = new StringBuilder();
                String line = "";
                while ((line = reader.readLine()) != null) {
                    sb.append(line).append("\n");
                }
                String response = sb.toString();
                isr.close();
                reader.close();
                http.disconnect();
                return getMediaSourcesFromYoutube(response);
            } catch (IOException | JSONException e) {
                e.printStackTrace();
                Log.e("HTTP GET:", e.toString());
                return new ArrayList<>();
            }
        }
        else if(validators.containsKey(Query.Playlist))
        {
            RequestPlaylistInfo request = new RequestPlaylistInfo(validators.get(Query.Playlist));
            Response<PlaylistInfo> response = downloader.getPlaylistInfo(request);
            PlaylistInfo playlistInfo = response.data();

            List<MediaSource> playlist = new ArrayList<>();

            for (PlaylistVideoDetails videoDetails : playlistInfo.videos())
            {
                if(!videoDetails.isPlayable())
                {
                    continue;
                }

                playlist.add(getVideoInfo(videoDetails.videoId(), validators.get(Query.Playlist)));
            }

            return playlist;
        }

        return new ArrayList<>();
    }

    public static HashMap<Query, String> checkLink(String link) {
        HashMap<Query, String> returnDict = new HashMap<>();

        if (link == null) {
            returnDict.put(Query.None, link);
            return returnDict;
        }

        String searchValue = "";

        String videoId = tryParseVideoId(link);
        String playlistId = tryParsePlaylistId(link);

        boolean searchValid = link.contains("search_query=");
        boolean videoValid = videoId != null;
        boolean playlistValid = playlistId != null;

        String trimmed = link.trim();

        if (trimmed.toLowerCase(Locale.ROOT).startsWith("video:")) {
            String temp = trimmed.substring(6);

            if (temp.length() == 11) {
                videoId = temp;
                videoValid = true;
            }
        }

        if (trimmed.toLowerCase(Locale.ROOT).startsWith("playlist")) {
            String temp = trimmed.substring(9);

            if (temp.length() == 11) {
                playlistId = temp;
                playlistValid = true;
            }
        }

        if (searchValid) {
            try {
                searchValue = URLDecoder.decode(link.substring(link.indexOf("search_query=") + 13), StandardCharsets.UTF_8.toString());
            } catch (UnsupportedEncodingException e) {
                e.printStackTrace();
            }
        }

        if (videoValid) {
            returnDict.put(Query.Video, videoId);
        }

        if (playlistValid) {
            returnDict.put(Query.Playlist, playlistId);
        }

        if (searchValid) {
            returnDict.put(Query.Search, searchValue);
        }

        if (returnDict.size() == 0) {
            returnDict.put(Query.None, link);
        }

        return returnDict;
    }

    private static List<MediaSource> getMediaSourcesFromYoutube(String json) throws JSONException {
        List<MediaSource> mediaSources = new ArrayList<>();
        JSONObject jsonObject = new JSONObject(json);

        List<JSONObject> jsonObjects = findAllElements("videoRenderer", jsonObject);

        for (JSONObject object : jsonObjects) {
            String videoId = object.getString("videoId");
            String thumbnail = "";
            int thumbnailWidth = 0;

            JSONArray thumbnails = object.getJSONObject("thumbnail").getJSONArray("thumbnails");

            for (int a = 0; a < thumbnails.length(); a++) {
                JSONObject currentThumbnail = thumbnails.getJSONObject(a);

                if (currentThumbnail.getInt("width") > thumbnailWidth) {
                    thumbnailWidth = currentThumbnail.getInt("width");
                    thumbnail = currentThumbnail.getString("url");
                }
            }

            System.out.println(object.toString());
            String title = object.getJSONObject("title").getJSONArray("runs").getJSONObject(0).getString("text");
            String author = object.getJSONObject("longBylineText").getJSONArray("runs").getJSONObject(0).getString("text");
            JSONObject _lengthText = object.optJSONObject("lengthText");

            if (_lengthText == null) {
                System.out.println(object.toString());
            }
            String lengthText = _lengthText == null ? "0:00" : _lengthText.getString("simpleText");
            String[] durationItems = lengthText.split(":");

            long duration = 0;
            int hourCount = durationItems.length == 3 ? Integer.parseInt(durationItems[durationItems.length - 1 - 2]) : -1;
            int minutesCount = durationItems.length > 1 ? Integer.parseInt(durationItems[durationItems.length - 1 - 1]) : -1;
            int secondsCount = Integer.parseInt(durationItems[durationItems.length - 1]);

            if (hourCount > 0) {
                duration += (long) hourCount * 60 * 60 * 1000;
            }

            if (minutesCount > 0) {
                duration += (long) minutesCount * 60 * 1000;
            }

            duration += secondsCount;

            if (duration > 0) {
                mediaSources.add(new MediaSource(videoId, author, title, duration, null, videoId, thumbnail, null));
            }
        }

        System.out.println("jsonObjects count: " + jsonObjects.size());
        System.out.println("Searched media sources: " + mediaSources.size());
        return mediaSources;
    }

    private static List<JSONObject> findAllElements(String name, JSONObject jsonObject) throws JSONException {
        List<JSONObject> objects = new ArrayList<>();

        if (jsonObject.has(name)) {
            objects.add(jsonObject.getJSONObject(name));
        } else {
            for (Iterator<String> it = jsonObject.keys(); it.hasNext(); ) {
                String key = it.next();

                JSONObject object = jsonObject.optJSONObject(key);

                if (object != null) {
                    objects.addAll(findAllElements(name, object));
                }

                JSONArray array = jsonObject.optJSONArray(key);

                if (array != null) {
                    for (int a = 0; a < array.length(); a++) {
                        JSONObject arrayObject = array.optJSONObject(a);

                        if (arrayObject == null) {
                            continue;
                        }

                        objects.addAll(findAllElements(name, arrayObject));
                    }
                }
            }
        }

        return objects;
    }

    private static String tryParsePlaylistId(String playlistUrl) {
        String[] patterns = new String[]{
                "youtube\\..+?/playlist.*?list=(.*?)(?:&|/|$)",
                "youtube\\..+?/watch.*?list=(.*?)(?:&|/|$)",
                "youtu\\.be/.*?/.*?list=(.*?)(?:&|/|$)",
                "youtube\\..+?/embed/.*?/.*?list=(.*?)(?:&|/|$)"
        };

        for (String _pattern : patterns) {
            Pattern pattern = Pattern.compile(_pattern);

            Matcher matcher = pattern.matcher(playlistUrl);

            if (!matcher.find()) {
                continue;
            }

            if (!validatePlaylistId(matcher.group(1))) {
                continue;
            }

            return matcher.group(1);
        }

        return null;
    }

    private static String tryParseVideoId(String videoUrl) {
        String[] patterns = new String[]{
                "youtube\\..+?/watch.*?v=(.*?)(?:&|/|$)",
                "youtu\\.be/(.*?)(?:\\?|&|/|$)",
                "youtube\\..+?/embed/(.*?)(?:\\?|&|/|$)"
        };

        for (String _pattern : patterns) {
            Pattern pattern = Pattern.compile(_pattern);

            Matcher matcher = pattern.matcher(videoUrl);

            if (!matcher.find()) {
                continue;
            }

            if (!validateVideoId(matcher.group(1))) {
                continue;
            }

            return matcher.group(1);
        }

        return null;
    }

    private static boolean validatePlaylistId(String playlistId) {
        if (playlistId == null) {
            return false;
        }

        if (playlistId.equals("WL")) {
            return true;
        }

        if (!playlistId.startsWith("PL") &&
                !playlistId.startsWith("RD") &&
                !playlistId.startsWith("UL") &&
                !playlistId.startsWith("UU") &&
                !playlistId.startsWith("PU") &&
                !playlistId.startsWith("OL") &&
                !playlistId.startsWith("LL") &&
                !playlistId.startsWith("FL")) {
            return false;
        }

        if (playlistId.length() < 13 || playlistId.length() > 42) {
            return false;
        }

        Pattern pattern = Pattern.compile("[^0-9a-zA-Z_\\-]");

        return pattern.matcher(playlistId).find();
    }

    private static boolean validateVideoId(String videoId) {
        if (videoId == null) {
            return false;
        }

        if (videoId.length() != 11) {
            return false;
        }

        Pattern pattern = Pattern.compile("[^0-9a-zA-Z_\\-]");

        return pattern.matcher(videoId).find();
    }

    public enum Query {
        None,
        Video,
        Channel,
        Playlist,
        Search
    }
}
