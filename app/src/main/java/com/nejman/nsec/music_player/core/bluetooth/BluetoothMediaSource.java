package com.nejman.nsec.music_player.core.bluetooth;

import com.nejman.nsec.music_player.Global;
import com.nejman.nsec.music_player.media.MediaSource;
import com.nejman.nsec3.CorruptedDataException;
import com.nejman.nsec3.DataExistsException;
import com.nejman.nsec3.DataNotFoundException;
import com.nejman.nsec3.InvalidNameException;
import com.nejman.nsec3.InvalidPasswordException;
import com.nejman.nsec3.NSEC3;
import com.nejman.nsec3.NSECMemoryStream;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.file.Files;

public class BluetoothMediaSource {
    public String artist;
    public String title;
    public byte[] image;
    public byte[] fileData;
    public String fileName;
    public String id;
    public long duration;

    public static BluetoothMediaSource fromMediaSource(MediaSource source)
    {
        BluetoothMediaSource newSource = new BluetoothMediaSource();
        newSource.artist = source.artist;
        newSource.title = source.title;
        newSource.image = source.imageData;
        File file = new File(source.path);
        newSource.fileName = file.getName();
        newSource.id = source.id;
        newSource.duration = source.duration;
        try {
            newSource.fileData = Files.readAllBytes(file.toPath());
        } catch (IOException e) {
            e.printStackTrace();
        }
        return newSource;
    }

    public static BluetoothMediaSource fromBytes(byte[] bytes)
    {
        NSEC3 nsec = new NSEC3("Newtone");
        NSECMemoryStream stream = new NSECMemoryStream(bytes);
        try {
            nsec.load(stream);
        } catch (CorruptedDataException | InvalidPasswordException e) {
            return null;
        }

        BluetoothMediaSource source = new BluetoothMediaSource();
        try {
            source.artist = nsec.getString("artist");
            source.title = nsec.getString("title");
            source.image = nsec.dataExists("imageExists") ? nsec.get("image") : null;
            source.id = nsec.getString("id");
            source.duration = Long.parseLong(nsec.getString("duration"));
            source.fileData = nsec.get("fileData");
            source.fileName = nsec.getString("fileName");
        } catch (DataNotFoundException | InvalidPasswordException e) {
            return null;
        }

        return source;
    }

    public byte[] toBytes()
    {
        NSEC3 nsec = new NSEC3("Newtone");
        byte[] data;
        try {
            nsec.add("artist","",artist);
            nsec.add("title", "",title);
            if(image != null)
            {
                nsec.add("imageExists","","imageExists");
                nsec.add("image","", image);
            }
            nsec.add("id","",id);
            nsec.add("duration","", Long.toString(duration));
            nsec.add("fileData","",fileData);
            nsec.add("fileName","",fileName);
            data = nsec.save();
        } catch (IOException | InvalidNameException | DataExistsException | DataNotFoundException | InvalidPasswordException e) {
            return null;
        }

        return data;
    }

    public MediaSource toMediaSource()
    {
        try {
            FileOutputStream fos = new FileOutputStream(Global.musicPath+"/"+fileName);
            fos.write(fileData);
            fos.close();
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }

        return new MediaSource(Global.musicPath+"/"+fileName, artist, title, duration, image, id,"","");
    }
}
