using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Support.V4.Media.Session;
using Android.Views;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Processing;
using Newtone.Mobile.Droid.Logic;
using Newtone.Mobile.UI.Models;

namespace Newtone.Mobile.Droid.Media
{
    public class MediaSessionCallback : MediaSessionCompat.Callback
    {
        #region Fields
        private static Task searchTask;
        #endregion
        #region Public Methods
        public override void OnPlay()
        {
            AudioManager am = (AudioManager)MainActivity.Instance.GetSystemService(Context.AudioService);

            AudioAttributes attrs = new AudioAttributes.Builder()
                .SetContentType(AudioContentType.Music).Build();

            Global.AudioFocusRequest = new AudioFocusRequestClass.Builder(AudioFocus.Gain)
                .SetOnAudioFocusChangeListener(Global.AudioFocusListener)
                .SetAudioAttributes(attrs)
                .Build();

            AudioFocusRequest result = am.RequestAudioFocus(Global.AudioFocusRequest);
            if (result == AudioFocusRequest.Granted)
            {
                try
                {
                    if (MediaPlayerService.Instance == null)
                        MainActivity.Instance.ApplicationContext.StartForegroundServiceCompat<MediaPlayerService>();
                    Global.MediaSession.Active = true;
                    GlobalData.Current.MediaPlayer.Play();
                }
                catch (System.Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("MediaSessionCallback OnPlay Exception " + e);
                    StreamWriter streamWriter = new StreamWriter(GlobalData.Current.MusicPath + "/log.txt", true);
                    streamWriter.WriteLine("ERROR from MediaSessionCallback " + DateTime.Now.ToString());
                    streamWriter.WriteLine("Exception: " + e.Message);
                    streamWriter.WriteLine("StackTrace: " + e.StackTrace);
                    streamWriter.WriteLine("Source: " + e.Source);
                    streamWriter.WriteLine("ERROR END");
                    streamWriter.Close();
                }
            }

        }

        public override void OnPlayFromSearch(string query, Bundle extras)
        {
            ProcessSearch(query);
        }

        public override void OnStop()
        {
            AudioManager am = (AudioManager)MainActivity.Instance.GetSystemService(Context.AudioService);
            if (Global.AudioFocusRequest != null)
                am.AbandonAudioFocusRequest(Global.AudioFocusRequest);

            Global.MediaSession.Active = false;
            GlobalData.Current.MediaPlayer.Stop();
        }

        public override void OnPause()
        {
            GlobalData.Current.MediaPlayer.Pause();
        }

        public override void OnSkipToNext()
        {
            GlobalData.Current.MediaPlayer.Next();
        }

        public override void OnSkipToPrevious()
        {
            GlobalData.Current.MediaPlayer.Prev();
        }

        public override bool OnMediaButtonEvent(Intent mediaButtonEvent)
        {
            KeyEvent ev = (KeyEvent)mediaButtonEvent.GetParcelableExtra(Intent.ExtraKeyEvent);

            if (ev.Action == KeyEventActions.Up)
            {
                if (ev.KeyCode == Keycode.MediaPlay)
                {
                    MediaPlayerHelper.Play();
                }
                else if (ev.KeyCode == Keycode.MediaPause)
                {
                    MediaPlayerHelper.Pause();
                }
                else if (ev.KeyCode == Keycode.MediaPrevious)
                {
                    MediaPlayerHelper.Prev();
                }
                else if (ev.KeyCode == Keycode.MediaNext)
                {
                    MediaPlayerHelper.Next();
                }
            }

            return true;
        }

        public static void ProcessSearch(string query)
        {
            if (searchTask == null)
            {
                searchTask = new Task(async () =>
                {
                    while (!Newtone.Mobile.UI.Global.Loaded)
                    {
                        await Task.Delay(200);
                    }
                    query = query.ToLowerInvariant();

                    bool played = false;
                    foreach (var playlistName in GlobalData.Current.Playlists.Keys)
                    {
                        double similiarity = SearchProcessing.CalculateSimilarity(query, playlistName);
                        if ((playlistName.ToLowerInvariant().Contains(query) || query.Contains(playlistName.ToLowerInvariant()) || similiarity >= 0.8) && GlobalData.Current.Playlists[playlistName].Count > 0)
                        {
                            GlobalData.Current.MediaPlayer.LoadPlaylist(GlobalData.Current.Playlists[playlistName], 0, true, true);
                            played = true;
                            break;
                        }
                    }

                    if (!played)
                    {
                        foreach (var artistName in GlobalData.Current.Artists.Keys)
                        {
                            string checkedString = CyrylicToUnicode.IsCyrylic(artistName) ? CyrylicToUnicode.Convert(artistName) : artistName;
                            double similiarity = SearchProcessing.CalculateSimilarity(query, artistName);
                            if ((checkedString.ToLowerInvariant().Contains(query) || query.Contains(checkedString.ToLowerInvariant()) || similiarity >= 0.8) && GlobalData.Current.Artists[artistName].Count > 0)
                            {
                                GlobalData.Current.MediaPlayer.LoadPlaylist(GlobalData.Current.Artists[artistName], 0, true, true);
                                played = true;
                                break;
                            }
                        }
                    }

                    if (!played)
                    {
                        List<TrackModel> beforeSort = new List<TrackModel>();
                        foreach (var track in GlobalData.Current.Audios.Values)
                        {
                            beforeSort.Add(new TrackModel(track).CheckChanges());
                        }
                        var afterSort = new List<TrackModel>(beforeSort.OrderBy(item => item.TrackString));
                        List<string> afterSortPaths = new List<string>(afterSort.Select(item => item.FilePath));

                        for (int a = 0; a < afterSort.Count; a++)
                        {
                            var source = afterSort[a];
                            string trackText = source.Artist + " " + source.Title;

                            if (trackText.ToLowerInvariant().Contains(query) || query.Contains(trackText.ToLowerInvariant()))
                            {
                                GlobalData.Current.MediaPlayer.LoadPlaylist(afterSortPaths, a, true, true);
                                played = true;
                                break;
                            }
                        }
                    }

                    if (!played)
                    {
                        var rawItems = new ObservableBridge<Newtone.Core.Models.SearchResultModel>();
                        await SearchProcessing.Search(query, rawItems);
                        var items = new List<SearchResultModel>();

                        foreach (var item in rawItems.GetItems())
                            items.Add(new SearchResultModel(item));

                        GlobalData.Current.CurrentPlaylist.Clear();

                        using (WebClient webClient = new WebClient())
                        {
                            for (int a = 0; a < items.Count; a++)
                            {
                                byte[] data = webClient.DownloadData(items[a].ThumbUrl);
                                items[a].Image = data;
                                items[a].CheckChanges();

                                GlobalData.Current.CurrentPlaylist.Add(items[a].ToMediaSource());

                                if (a == 0)
                                {
                                    GlobalData.Current.PlaylistPosition = 0;
                                    GlobalData.Current.MediaSource = GlobalData.Current.CurrentPlaylist[0];
                                    GlobalData.Current.MediaPlayer.Load(GlobalData.Current.CurrentPlaylist[0].FilePath);
                                    MediaPlayerHelper.Play();
                                }
                            }
                        }
                    }
                    searchTask = null;
                });
                searchTask.Start();
            }
        }
        #endregion
    }
}