package com.github.kiulian.downloader.model.videos;

public class Thumbnail {
    public final int width;
    public final int height;
    public final String url;

    public Thumbnail(int width, int height, String url)
    {
        this.width = width;
        this.height = height;
        this.url = url;
    }
}
