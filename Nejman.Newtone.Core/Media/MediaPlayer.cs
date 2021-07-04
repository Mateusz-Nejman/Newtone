using Nejman.Newtone.Core.Implementations;
using Nejman.Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Common;

using Local = Nejman.Newtone.Core.Localization.Localization;

namespace Nejman.Newtone.Core.Media
{
    public class MediaPlayer
    {
        private readonly IPlayerController webController;
        private readonly IPlayerController deviceController;
        private readonly IList<int> randomIndexes;

        public bool IsPlaying => MediaPlayerImplementation.Current.GetIsPlaying();
        public double Duration => MediaPlayerImplementation.Current.GetDuration();
        public double CurrentPosition => MediaPlayerImplementation.Current.GetCurrentPosition();
        public bool IsLoading { get; internal set; }
        public bool IsLocal => CurrentController is DevicePlayerController;
        public IPlayerController CurrentController { get; private set; }

        public MediaPlayer()
        {
            randomIndexes = new List<int>();
            webController = new WebPlayerController();
            deviceController = new DevicePlayerController();
        }

        public async Task LoadPlaylist(string playlistUrl, int startIndex = 0)
        {
            CoreGlobal.CurrentPlaylist.Clear();
            CoreGlobal.CurrentPlaylistPosition = startIndex;
            YoutubeClient client = new YoutubeClient();
            WebClient webClient = new WebClient();
            var playlist = await client.Playlists.GetVideosAsync(playlistUrl).CollectAsync(20);

            foreach(var playlistItem in playlist)
            {
                byte[] thumbnail = await webClient.DownloadDataTaskAsync(playlistItem.Thumbnails.First().Url);
                CoreGlobal.CurrentPlaylist.Add(new MediaSource(playlistItem.Id, playlistItem.Author.Title, playlistItem.Title, playlistItem.Duration ?? TimeSpan.Zero, thumbnail, playlistItem.Id));
            }

            webClient.Dispose();
        }

        public async Task LoadPlaylist(IList<string> playlist, int startIndex = 0)
        {
            await LoadPlaylist(CoreGlobal.Audios.Where(keyPair => playlist.Contains(keyPair.Key) && File.Exists(keyPair.Key)).Select(source => source.Value).ToList(), startIndex);
        }

        public async Task LoadPlaylist(IList<PlaylistItemModel> playlist, int startIndex = 0)
        {
            await LoadPlaylist(playlist.Where(playlistItem => CoreGlobal.Audios.ContainsKey(playlistItem.Path)).Select(source => CoreGlobal.Audios[source.Path]).ToList(), startIndex);
        }

        public async Task LoadPlaylist(IList<ArtistItemModel> playlist, int startIndex = 0)
        {
            await LoadPlaylist(playlist.Where(artistItem => CoreGlobal.Audios.ContainsKey(artistItem.Path)).Select(source => CoreGlobal.Audios[source.Path]).ToList(), startIndex);
        }

        public async Task LoadPlaylist(IList<MediaSource> playlist, int startIndex = 0)
        {
            CoreGlobal.CurrentPlaylist.Clear();
            CoreGlobal.CurrentPlaylist.AddRange(playlist);
            CoreGlobal.CurrentPlaylistPosition = startIndex;

            await Load(CoreGlobal.CurrentPlaylist[CoreGlobal.CurrentPlaylistPosition]);
            MediaPlayerImplementation.Current.AfterNext();
            NotificationImplementation.Current.Show(CoreGlobal.CurrentSource, IsPlaying);
        }


        public async Task Load(MediaSource source)
        {
            await Load(source.Path);
            CoreGlobal.CurrentSource = source;
        }
        public async Task Load(string path)
        {
            MediaPlayerImplementation.Current.Reset();

            if(path.Length == 11)
            {
                var savedPaths = CoreGlobal.Audios.Values.Where(source => source.ID == path).ToArray();

                if(savedPaths.Length == 0)
                {
                    CurrentController = webController;
                }
                else
                {
                    CurrentController = deviceController;
                    path = savedPaths[0].Path;
                }
            }
            else if(path.StartsWith("https://"))
            {
                CurrentController = webController;
            }
            else
            {
                CurrentController = deviceController;
            }

            await CurrentController.Load(this, path);
            await CurrentController.Loaded(this);
            MediaPlayerImplementation.Current.Prepare();
        }

        public async Task Next()
        {
            if(CoreGlobal.CurrentPlaylist.Count > 0)
            {
                int nextPosition = CoreGlobal.CurrentPlaylistPosition;

                if(CoreGlobal.PlaybackMode == PlaybackMode.All)
                {
                    nextPosition++;

                    if(nextPosition >= CoreGlobal.CurrentPlaylist.Count)
                    {
                        nextPosition = 0;
                    }
                }
                else if(CoreGlobal.PlaybackMode == PlaybackMode.Random)
                {
                    if(randomIndexes.Count == 0)
                    {
                        for(int a = 0; a < CoreGlobal.CurrentPlaylist.Count; a++)
                        {
                            randomIndexes.Add(a);
                        }
                    }

                    int randomIndex = Utils.GetRandom(randomIndexes.Count);

                    if(randomIndex >= CoreGlobal.CurrentPlaylist.Count)
                    {
                        randomIndex = CoreGlobal.CurrentPlaylist.Count - 1;
                    }
                    if(randomIndex < 0)
                    {
                        randomIndex = 0;
                    }

                    nextPosition = randomIndexes[randomIndex];
                    randomIndexes.RemoveAt(randomIndex);
                }

                var source = CoreGlobal.CurrentPlaylist[nextPosition];

                if(source.IsLocal && !File.Exists(source.Path))
                {
                    SnackbarImplementation.Current.Show(Local.SnackFileExists);
                    await Next();
                    return;
                }

                CoreGlobal.CurrentPlaylistPosition = nextPosition;
                await Load(source);
                MediaPlayerImplementation.Current.AfterNext();
                NotificationImplementation.Current.Show(source, IsPlaying);
            }
        }

        public async Task Prev()
        {
            if (CoreGlobal.CurrentPlaylist.Count > 0)
            {
                int nextPosition = CoreGlobal.CurrentPlaylistPosition;

                if (CoreGlobal.PlaybackMode == PlaybackMode.All)
                {
                    nextPosition--;

                    if (nextPosition < 0)
                    {
                        nextPosition = CoreGlobal.CurrentPlaylist.Count -1;
                    }
                }
                else if (CoreGlobal.PlaybackMode == PlaybackMode.Random)
                {
                    if (randomIndexes.Count == 0)
                    {
                        for (int a = 0; a < CoreGlobal.CurrentPlaylist.Count; a++)
                        {
                            randomIndexes.Add(a);
                        }
                    }

                    int randomIndex = Utils.GetRandom(randomIndexes.Count);

                    if (randomIndex >= CoreGlobal.CurrentPlaylist.Count)
                    {
                        randomIndex = CoreGlobal.CurrentPlaylist.Count - 1;
                    }
                    if (randomIndex < 0)
                    {
                        randomIndex = 0;
                    }

                    nextPosition = randomIndexes[randomIndex];
                    randomIndexes.RemoveAt(randomIndex);
                }

                var source = CoreGlobal.CurrentPlaylist[nextPosition];

                if (source.IsLocal && !File.Exists(source.Path))
                {
                    SnackbarImplementation.Current.Show(Local.SnackFileExists);
                    await Prev();
                    return;
                }

                CoreGlobal.CurrentPlaylistPosition = nextPosition;
                await Load(source);
                MediaPlayerImplementation.Current.AfterPrev();
                NotificationImplementation.Current.Show(source, IsPlaying);
            }
        }

        public void Play()
        {
            MediaPlayerImplementation.Current.Play();
            NotificationImplementation.Current.Show(CoreGlobal.CurrentSource, IsPlaying);
        }

        public void Pause()
        {
            MediaPlayerImplementation.Current.Pause();
            NotificationImplementation.Current.Show(CoreGlobal.CurrentSource, IsPlaying);
        }

        public void Reset()
        {
            MediaPlayerImplementation.Current.Reset();
        }

        public void Seek(double value)
        {
            MediaPlayerImplementation.Current.Seek(value);
        }

        public void SetVolume(float value)
        {
            MediaPlayerImplementation.Current.SetVolume(value);
        }
    }
}
