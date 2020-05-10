﻿using Newtone.Core.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Newtone.Core.Media
{
    public class MediaProcessing
    {
        private const int MINIMUM_TRACK_DURATION = 10;
        public static MediaSource GetSource(string filePath)
        {
            ConsoleDebug.WriteLine("GS: " + filePath);
            MediaSource container = new MediaSource
            {
                FilePath = filePath
            };

            //ConsoleDebug.WriteLine(filePath);

            try
            {
                ATL.Track audioFile = new ATL.Track(filePath);

                //ConsoleDebug.WriteLine(audioFile.Duration);
                if (audioFile.DurationMs < MINIMUM_TRACK_DURATION * 1000)
                    return null;
                container.Title = audioFile.Title == "" || audioFile.Title == null ? new FileInfo(filePath).Name : audioFile.Title;

                container.Artist = audioFile.Artist == "" ? GlobalData.LanguageUnknownArtist : audioFile.Artist;


                for (int a = 0; a < audioFile.EmbeddedPictures.Count; a++)
                {
                    if (audioFile.EmbeddedPictures[a] != null && audioFile.EmbeddedPictures[a].PictureData.Length > 0)
                    {
                        container.Image = audioFile.EmbeddedPictures[a].PictureData;
                        break;
                    }
                }

                container.Duration = TimeSpan.FromSeconds(audioFile.Duration);

            }
            catch
            {
                container.Title = new FileInfo(filePath).Name;
                container.Artist = GlobalData.LanguageUnknownArtist;
            }

            if (GlobalData.AudioTags.ContainsKey(filePath))
            {
                MediaSourceTag newTags = GlobalData.AudioTags[filePath];

                container.Artist = newTags.Author;
                container.Title = newTags.Title;
                container.Image ??= newTags.Image;
            }
            return container;
        }
    }
}