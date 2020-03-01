using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Nio;
using NSEC.Music_Player.Languages;
using Xamarin.Forms;

namespace NSEC.Music_Player.Media
{
    class MediaProcessing
    {
        private const int DEFAULT_BUFFER_SIZE = 1 * 1024 * 1024;
        private const int MINIMUM_TRACK_DURATION = 10;
        public static MediaSource GetSource(string filePath)
        {
            MediaSource container = new MediaSource
            {
                FilePath = filePath
            };

            try
            {
                ATL.Track audioFile = new ATL.Track(filePath);

                if (audioFile.DurationMs < MINIMUM_TRACK_DURATION * 1000)
                    return null;
                container.Title = audioFile.Title == "" || audioFile.Title == null ? new FileInfo(filePath).Name : audioFile.Title;
                Console.WriteLine(container.Title);

                container.Artist = audioFile.Artist == "" ? Localization.UnknownArtist : audioFile.Artist;


                for (int a = 0; a < audioFile.EmbeddedPictures.Count; a++)
                {
                    if (audioFile.EmbeddedPictures[a] != null && audioFile.EmbeddedPictures[a].PictureData.Length > 0)
                    {
                        container.Picture = audioFile.EmbeddedPictures[a].PictureData;
                        break;
                    }
                }

            }
            catch
            {
                container.Title = new FileInfo(filePath).Name;
                container.Artist = Localization.UnknownArtist;
            }

            if (Global.AudioTags.ContainsKey(filePath))
            {
                MediaSourceTag newTags = Global.AudioTags[filePath];

                container.Artist = newTags.Author;
                container.Title = newTags.Title;
                container.Picture ??= newTags.ImageSource;
            }
            return container;
        }

        public static MediaOutputType GetAudio(string input, string output)
        {
            return Parse(input, output, -1, -1, true, false);
        }

        private static MediaOutputType Parse(string srcPath, string dstPath, int startMs, int endMs, bool useAudio, bool useVideo)
        {
            MediaOutputType outputType = MediaOutputType.mp4;
            // Set up MediaExtractor to read from the source.
            using MediaExtractor extractor = new MediaExtractor();
            using MediaMuxer muxer = new MediaMuxer(dstPath, MuxerOutputType.Mpeg4);
            extractor.SetDataSource(srcPath);
            int trackCount = extractor.TrackCount;
            // Set up MediaMuxer for the destination.
            // Set up the tracks and retrieve the max buffer size for selected
            // tracks.
            Dictionary<int, int> indexMap = new Dictionary<int, int>(trackCount);
            int bufferSize = -1;
            for (int i = 0; i < trackCount; i++)
            {
                using MediaFormat format = extractor.GetTrackFormat(i);
                string mime = format.GetString(MediaFormat.KeyMime);
                bool selectCurrentTrack = false;
                if (mime.StartsWith("audio/") && useAudio)
                {
                    Console.WriteLine("MP4Parser: " + mime);
                    if (mime == MediaFormat.MimetypeAudioAac)
                        outputType = MediaOutputType.m4a;
                    else if (mime == MediaFormat.MimetypeAudioMpeg)
                        outputType = MediaOutputType.mp3;
                    selectCurrentTrack = true;
                }
                else if (mime.StartsWith("video/") && useVideo)
                {
                    selectCurrentTrack = true;
                }
                if (selectCurrentTrack)
                {
                    extractor.SelectTrack(i);
                    int dstIndex = muxer.AddTrack(format);
                    if (indexMap.ContainsKey(i))
                        indexMap[i] = dstIndex;
                    else
                        indexMap.Add(i, dstIndex);
                    if (format.ContainsKey(MediaFormat.KeyMaxInputSize))
                    {
                        int newSize = format.GetInteger(MediaFormat.KeyMaxInputSize);
                        bufferSize = newSize > bufferSize ? newSize : bufferSize;
                    }
                }

            }
            if (bufferSize < 0)
            {
                bufferSize = DEFAULT_BUFFER_SIZE;
            }
            // Set up the orientation and starting time for extractor.

            if (startMs > 0)
            {
                extractor.SeekTo(startMs * 1000, MediaExtractorSeekTo.ClosestSync);
            }
            // Copy the samples from MediaExtractor to MediaMuxer. We will loop
            // for copying each sample and stop when we get to the end of the source
            // file or exceed the end time of the trimming.
            int offset = 0;
            ByteBuffer dstBuf = ByteBuffer.Allocate(bufferSize);
            MediaCodec.BufferInfo bufferInfo = new MediaCodec.BufferInfo();
            muxer.Start();
            while (true)
            {
                bufferInfo.Offset = offset;
                bufferInfo.Size = extractor.ReadSampleData(dstBuf, offset);
                if (bufferInfo.Size < 0)
                {
                    Console.WriteLine("Saw input EOS.");
                    bufferInfo.Size = 0;
                    break;
                }
                else
                {
                    bufferInfo.PresentationTimeUs = extractor.SampleTime;
                    if (endMs > 0 && bufferInfo.PresentationTimeUs > (endMs * 1000))
                    {
                        Console.WriteLine("The current sample is over the trim end time.");
                        break;
                    }
                    else
                    {
                        bufferInfo.Flags = (MediaCodecBufferFlags)extractor.SampleFlags;
                        int trackIndex = extractor.SampleTrackIndex;
                        muxer.WriteSampleData(indexMap[trackIndex], dstBuf, bufferInfo);
                        extractor.Advance();
                    }
                }
            }
            muxer.Stop();
            muxer.Release();
            return outputType;
        }
    }
}