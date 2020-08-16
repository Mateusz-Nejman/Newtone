using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Media.Session;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
using Newtone.Mobile.Models;
using Newtone.Mobile.Views;
using YoutubeExplode.Playlists;

namespace Newtone.Mobile.Media
{
    public class MediaSessionCallback:MediaSessionCompat.Callback
    {
        #region Fields
        private static Task searchTask;
        #endregion
        #region Public Methods
        public override void OnPlay()
        {
            ConsoleDebug.WriteLine("[Android Media] MeSeCa OnPlay");
            AudioManager am = (AudioManager)MainActivity.Instance.GetSystemService(Context.AudioService);

            AudioAttributes attrs = new AudioAttributes.Builder()
                .SetContentType(AudioContentType.Music).Build();

            Global.AudioFocusRequest = new AudioFocusRequestClass.Builder(AudioFocus.Gain)
                .SetOnAudioFocusChangeListener(Global.AudioFocusListener)
                .SetAudioAttributes(attrs)
                .Build();

            AudioFocusRequest result = am.RequestAudioFocus(Global.AudioFocusRequest);
            Console.Write("OnPlay result " + result);
            if(result == AudioFocusRequest.Granted)
            {
                MainActivity.Instance.StartService(new Intent(MainActivity.Instance, Java.Lang.Class.FromType(typeof(MediaPlayerService))));
                Global.MediaSession.Active = true;
                GlobalData.MediaPlayer.Play();
                MediaPlayerService.Instance.StartForeground(0, MediaPlayerService.Instance?.GetNotification());
            }
                
        }

        public override void OnPlayFromSearch(string query, Bundle extras)
        {
            ProcessSearch(query);
        }
        public override void OnPlayFromUri(Android.Net.Uri uri, Bundle extras)
        {
            Console.WriteLine("Assitst Uri " + uri);
        }

        public override void OnStop()
        {
            ConsoleDebug.WriteLine("[Android Media] MeSeCa OnStop");
            AudioManager am = (AudioManager)MainActivity.Instance.GetSystemService(Context.AudioService);
            if(Global.AudioFocusRequest != null)
                am.AbandonAudioFocusRequest(Global.AudioFocusRequest);

            MediaPlayerService.Instance.StopSelf();
            Global.MediaSession.Active = false;
            GlobalData.MediaPlayer.Stop();
            MediaPlayerService.Instance.StopForeground(false);
        }

        public override void OnPause()
        {
            ConsoleDebug.WriteLine("[Android Media] MeSeCa OnPause");
            GlobalData.MediaPlayer.Pause();
            MediaPlayerService.Instance.StopForeground(false);
        }

        public override void OnSkipToNext()
        {
            ConsoleDebug.WriteLine("[Android Media] OnSkipToNext");
            GlobalData.MediaPlayer.Next();
        }

        public override void OnSkipToPrevious()
        {
            ConsoleDebug.WriteLine("[Android Media] OnSkipToPrev");
            GlobalData.MediaPlayer.Prev();
        }

        public override bool OnMediaButtonEvent(Intent mediaButtonEvent)
        {
            KeyEvent ev = (KeyEvent)mediaButtonEvent.GetParcelableExtra(Intent.ExtraKeyEvent);

            ConsoleDebug.WriteLine("[Android Media] OnMediaButtonEvent " + ev.Action);

            if(ev.Action == KeyEventActions.Up)
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

        public override void OnPrepare()
        {
            Console.WriteLine("Assist OnPrepare");
        }

        public override void OnPrepareFromSearch(string query, Bundle extras)
        {
            Console.WriteLine("Assist Search " + query);
        }

        public override void OnPrepareFromUri(Android.Net.Uri uri, Bundle extras)
        {
            Console.WriteLine("Assists Uri " + uri);
        }

        public static void ProcessSearch(string query)
        {
            if(searchTask == null)
            {
                searchTask = new Task(async () =>
                {
                    while(!MainActivity.Loaded)
                    {
                        await Task.Delay(200);
                    }
                    query = query.ToLowerInvariant();
                    Console.WriteLine("Assist " + query);

                    bool played = false;
                    foreach (var playlistName in GlobalData.Playlists.Keys)
                    {
                        string checkedString = CyrylicToUnicode.IsCyrylic(playlistName) ? CyrylicToUnicode.Convert(playlistName) : playlistName;
                        double similiarity = SearchProcessing.CalculateSimilarity(query, playlistName);
                        if (playlistName.ToLowerInvariant().Contains(query) || query.Contains(playlistName.ToLowerInvariant()) || similiarity >= 0.8)
                        {
                            Console.WriteLine(query + " similiar to playlist " + playlistName);
                            if (GlobalData.Playlists[playlistName].Count > 0)
                            {
                                GlobalData.CurrentPlaylist.Clear();

                                GlobalData.Playlists[playlistName].ForEach(track => GlobalData.CurrentPlaylist.Add(GlobalData.Audios[track]));

                                GlobalData.PlaylistPosition = 0;
                                GlobalData.MediaPlayer.Load(GlobalData.CurrentPlaylist[0].FilePath);
                                GlobalData.MediaSource = GlobalData.CurrentPlaylist[0];
                                MediaPlayerHelper.Play();
                                played = true;
                                break;
                            }
                        }
                    }

                    if (!played)
                    {
                        foreach (var artistName in GlobalData.Artists.Keys)
                        {
                            string checkedString = CyrylicToUnicode.IsCyrylic(artistName) ? CyrylicToUnicode.Convert(artistName) : artistName;
                            double similiarity = SearchProcessing.CalculateSimilarity(query, artistName);
                            if (checkedString.ToLowerInvariant().Contains(query) || query.Contains(checkedString.ToLowerInvariant()) || similiarity >= 0.8)
                            {
                                Console.WriteLine(query + " similiar to artist " + checkedString);
                                if (GlobalData.Artists[artistName].Count > 0)
                                {
                                    GlobalData.CurrentPlaylist.Clear();
                                    GlobalData.Artists[artistName].ForEach(track => GlobalData.CurrentPlaylist.Add(GlobalData.Audios[track]));

                                    GlobalData.PlaylistPosition = 0;
                                    GlobalData.MediaPlayer.Load(GlobalData.CurrentPlaylist[0].FilePath);
                                    GlobalData.MediaSource = GlobalData.CurrentPlaylist[0];
                                    MediaPlayerHelper.Play();
                                    played = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (!played)
                    {
                        List<TrackModel> beforeSort = new List<TrackModel>();
                        foreach (var track in GlobalData.Audios.Values)
                        {
                            beforeSort.Add(new TrackModel(track).CheckChanges());
                        }
                        var afterSort = new List<TrackModel>(beforeSort.OrderBy(item => item.TrackString));

                        for (int a = 0; a < afterSort.Count; a++)
                        {
                            var source = afterSort[a];
                            string trackText = source.Artist + " " + source.Title;

                            if (trackText.ToLowerInvariant().Contains(query) || query.Contains(trackText.ToLowerInvariant()))
                            {
                                Console.WriteLine(query + " similiar to track " + trackText);
                                GlobalData.CurrentPlaylist.Clear();
                                afterSort.ForEach(track => GlobalData.CurrentPlaylist.Add(GlobalData.Audios[track.FilePath]));

                                GlobalData.PlaylistPosition = a;
                                GlobalData.MediaPlayer.Load(GlobalData.CurrentPlaylist[a].FilePath);
                                GlobalData.MediaSource = GlobalData.CurrentPlaylist[a];
                                MediaPlayerHelper.Play();
                                played = true;
                                break;
                            }
                        }
                    }

                    if (!played)
                    {
                        //ConsoleDebug.WriteLine("Start task");
                        //Items.Clear();
                        //RawItems.Clear();
                        //ConsoleDebug.WriteLine("await");
                        var rawItems = new ObservableBridge<Newtone.Core.Models.SearchResultModel>();
                        await SearchProcessing.Search(query, rawItems);
                        //ConsoleDebug.WriteLine("Searched");
                        var items = new List<Models.SearchResultModel>();

                        foreach (var item in rawItems.GetItems())
                            items.Add(new SearchResultModel(item));

                        GlobalData.CurrentPlaylist.Clear();

                        for (int a = 0; a < items.Count; a++)
                        {
                            using WebClient webClient = new WebClient();

                            byte[] data = webClient.DownloadData(items[a].ThumbUrl);
                            //ConsoleDebug.WriteLine("Thumb for " + Items[a].Title + " " + (data == null || data.Length == 0 ? "null" : ""));
                            items[a].Image = data;
                            items[a].CheckChanges();

                            GlobalData.CurrentPlaylist.Add(items[a]);

                            if (a == 0)
                            {
                                GlobalData.PlaylistPosition = 0;
                                GlobalData.MediaSource = GlobalData.CurrentPlaylist[0];
                                GlobalData.MediaPlayer.Load(GlobalData.CurrentPlaylist[0].FilePath);
                                MediaPlayerHelper.Play();
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