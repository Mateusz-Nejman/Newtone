using Android.Media;
using Java.Nio;
using System;
using System.Collections.Generic;

namespace NSEC.Music_Player.Logic
{
    public class MP4Parser
    {
        private const int DEFAULT_BUFFER_SIZE = 1 * 1024 * 1024;
        public void ToMP3(string input, string output)
        {
            //genVideoUsingMuxer(videoFile, originalAudio, -1, -1, true, false);
            Parse(input, output, -1, -1, true, false);
        }

        private void Parse(string srcPath, string dstPath, int startMs, int endMs, bool useAudio, bool useVideo)
        {
            // Set up MediaExtractor to read from the source.
            MediaExtractor extractor = new MediaExtractor();
            extractor.SetDataSource(srcPath);
            int trackCount = extractor.TrackCount;
            // Set up MediaMuxer for the destination.
            MediaMuxer muxer;
            muxer = new MediaMuxer(dstPath, MuxerOutputType.Mpeg4);
            // Set up the tracks and retrieve the max buffer size for selected
            // tracks.
            Dictionary<int, int> indexMap = new Dictionary<int, int>(trackCount);
            int bufferSize = -1;
            for (int i = 0; i < trackCount; i++)
            {
                MediaFormat format = extractor.GetTrackFormat(i);
                string mime = format.GetString(MediaFormat.KeyMime);
                bool selectCurrentTrack = false;
                if (mime.StartsWith("audio/") && useAudio)
                {
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
            MediaMetadataRetriever retrieverSrc = new MediaMetadataRetriever();
            retrieverSrc.SetDataSource(srcPath);
            string degreesString = retrieverSrc.ExtractMetadata(MetadataKey.VideoRotation);
            if (degreesString != null)
            {
                int degrees = int.Parse(degreesString);
                if (degrees >= 0)
                {
                    muxer.SetOrientationHint(degrees);
                }
            }
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
            return;
        }
    }
}
