package com.nejman.nsec.music_player;

public class Utils {
    public static String getDurationStringSeconds(long duration) {
        return getDurationStringMilliseconds(duration * 1000);
    }

    public static String getDurationStringMilliseconds(long duration) {
        int hours = (int) (duration / 3600000);
        int minutes = (int) ((duration - (hours * 3600000)) / 60000);
        int seconds = (int) ((duration - (hours * 3600000) - (minutes * 60000))) / 1000;

        String durationString = "";

        if (hours > 0) {
            durationString += hours + ":";
        }

        durationString += String.format("%1$" + 2 + "s", minutes).replace(' ', '0') + ":";
        durationString += String.format("%1$" + 2 + "s", seconds).replace(' ', '0');

        return durationString;
    }
}
