package com.nejman.nsec.music_player;

import android.content.pm.PackageManager;

public class PermissionHelper {
    public static boolean checkPermissions(String[] permissions) {
        for (String permission : permissions) {
            if (MainActivity.instance.checkSelfPermission(permission) != PackageManager.PERMISSION_GRANTED) {
                return false;
            }
        }

        return true;
    }

    public static boolean checkPermission(String permission) {
        return checkPermissions(new String[]{permission});
    }

    public static void requestPermissions(String[] permissions, int requestCode) {
        MainActivity.instance.requestPermissions(permissions, requestCode);
    }

    public static void requestPermission(String permission, int requestCode) {
        MainActivity.instance.requestPermissions(new String[]{permission}, requestCode);
    }

}
