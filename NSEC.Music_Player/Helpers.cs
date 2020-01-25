using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Services;
using NSEC.Music_Player.ViewModels;
using NSEC.Music_Player.ViewModels.Tabs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NSEC.Music_Player
{
    public static class Helpers
    {
        public async static Task LoadArtistsOnce(object instance, ArtistsTabModel model)
        {
            if (model.DataStore.Count() == 0)
            {
                Track unknownAuthor = null;
                List<Models.Track> artistsBeforeSort = new List<Models.Track>();
                foreach (string artist in Global.Authors.Keys)
                {
                    if(artist == "Nieznany")
                        unknownAuthor = new Models.Track { Id = artist, Text = artist, Description = Localization.TracksCount+": " + Global.Authors[artist].Count };
                    else
                        artistsBeforeSort.Add(new Models.Track { Id = artist, Text = artist, Description = Localization.TracksCount + ": " + Global.Authors[artist].Count });
                    //model.Items.Add();
                    //await model.DataStore.AddItemAsync(new Models.Track { Id = artist, Text = artist, Description = "Utworów: " + Global.Audios[artist].Count });
                }

                List<Models.Track> artistsAfterSort = artistsBeforeSort.OrderBy(o => o.Text).ToList();
                if (unknownAuthor != null)
                    artistsAfterSort.Add(unknownAuthor);

                foreach (Models.Track track in artistsAfterSort)
                {
                    model.Items.Add(track);
                    await model.DataStore.AddItemAsync(track);
                }
            }

            model.LoadItemsCommand.Execute(instance);
        }

        public async static Task ReloadArtists(object instance, ArtistsTabModel model)
        {
            model.DataStore.Clear();
            model.Items.Clear();
            await LoadArtistsOnce(instance, model);
        }

        public async static Task LoadTracksOnce(object instance, TracksTabModel model)
        {
            if (model.DataStore.Count() == 0)
            {
                List<Models.Track> tracksBeforeSort = new List<Models.Track>();
                foreach (string filepath in Global.Audios.Keys)
                {
                    MediaProcessing.MediaTag container = Global.Audios[filepath];
                    tracksBeforeSort.Add(new Models.Track { Id = container.FilePath, Text = container.Title, Description = container.Artist, Container = container, Tag = container.FilePath });
                }

                List<Models.Track> tracksAfterSort = tracksBeforeSort.OrderBy(o => o.Text).ToList();

                foreach (Models.Track track in tracksAfterSort)
                {
                    model.Items.Add(track);
                    await model.DataStore.AddItemAsync(track);
                }

            }
            model.LoadItemsCommand.Execute(instance);
        }

        public async static Task ReloadTracks(object instance, TracksTabModel model)
        {
            model.DataStore.Clear();
            model.Items.Clear();

            await LoadTracksOnce(instance, model);
        }

        public async static Task LoadPlaylistsOnce(object instance, PlaylistsTabModel model)
        {
            if (model.DataStore.Count() == 0)
            {
                List<Models.Track> playlistsBeforeSort = new List<Models.Track>();

                foreach(string playlist in Global.Playlists.Keys)
                {
                    List<Track> tracks = Global.Playlists[playlist];
                    playlistsBeforeSort.Add(new Track() { Id = playlist, Text = playlist, Description = Localization.TracksCount + ": " + tracks.Count});
                }

                List<Models.Track> playlistsAfterSort = playlistsBeforeSort.OrderBy(o => o.Text).ToList();

                foreach (Models.Track track in playlistsAfterSort)
                {
                    model.Items.Add(track);
                    await model.DataStore.AddItemAsync(track);
                }
            }

            model.LoadItemsCommand.Execute(instance);
        }

        public async static Task ReloadPlaylists(object instance, PlaylistsTabModel model)
        {
            model.DataStore.Clear();
            model.Items.Clear();
            await LoadPlaylistsOnce(instance, model);
        }

        public async static Task LoadGlobalsOnce()
        {
            Global.CurrentQueue = new List<Track>();
            Global.CurrentQueuePosition = 0;

            if (Global.Audios.Count == 0)
            {
                List<string> listed = new List<string>();
                MediaProcessing.MediaTag[] files = await FileProcessing.ListFiles(Global.Directories, listed);
                for (int a = 0; a < files.Length; a++)
                {
                    AddTrack(files[a]);

                }
                //File.AppendAllText(App.debugPath + "/debug.txt", "\n[][][][]\n\n");
            }

            Global.asyncEndController.Invoke("authorstab");
            Global.asyncEndController.Invoke("trackstab");
            Global.asyncEndController.Invoke("playliststab");

        }

        public static void AddTrack(MediaProcessing.MediaTag container)
        {
            if (!Global.Audios.ContainsKey(container.FilePath) && File.Exists(container.FilePath))
            {
                //File.AppendAllText(App.debugPath + "/debug.txt", "Create list for " + files[a].Author.Trim() + "\n");
                Global.Audios.Add(container.FilePath, container);

                if (!Global.Authors.ContainsKey(container.Artist))
                    Global.Authors.Add(container.Artist, new List<string>());

                Global.Authors[container.Artist].Add(container.FilePath);
            }

            //File.AppendAllText(App.debugPath + "/debug.txt", "Add " + files[a] + " to " + files[a].Author.Trim() + "\n");
        }

        public static Track FindTrackByTag(ObservableCollection<Track> Items, string tag)
        {
            foreach(Track track in Items)
            {
                if (File.Exists(track.Container.FilePath) && track.Container.FilePath == tag)
                {
                    track.Text = track.Container.Title;
                    return track;
                }
                    
            }
            return null;
        }

        public static void RemoveTrack(string path, bool onlyPlaylist, params ObservableCollection<Track>[] tracks)
        {
            
            if(!onlyPlaylist)
            {
                foreach (string filepath in Global.Audios.Keys)
                {
                    MediaProcessing.MediaTag container = Global.Audios[filepath];
                    if (container.FilePath == path)
                    {
                        Global.Audios.Remove(filepath);
                        break;
                    }
                }
            }

            foreach (ObservableCollection<Track> trackList in tracks)
            {
                foreach (Track track in trackList)
                {
                    if (track.Container.FilePath == path)
                    {
                        trackList.Remove(track);
                        break;
                    }
                }
            }
        }

        public static void AddToCounter(string filepath, int count)
        {
            List<TrackCounter> tracks = new List<TrackCounter>(Global.MostTracks);
            int index = tracks.FindIndex(o => o.Track == filepath);

            if (index == -1)
                tracks.Add(new TrackCounter(filepath, count));
            else
                tracks[index].Count += count;

            Global.MostTracks = tracks.ToArray();

            Global.SaveConfig();
        }

        public static void AddToLast(string filepath)
        {
            List<TrackCounter> tracks = new List<TrackCounter>(Global.LastTracks);

            int index = tracks.FindIndex(o => o.Track == filepath);
            if (index >= 0)
                tracks.RemoveAt(index);
            tracks.Reverse();


            tracks.Add(new TrackCounter(filepath, 0));
            tracks.Reverse();
            if(tracks.Count > 5)
                tracks.RemoveAt(tracks.Count - 1);

            Global.LastTracks = tracks.ToArray();
            Global.SaveConfig();
        }
    }
}
