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
        public async static Task LoadArtistsOnce(object instance, AuthorsTabModel model)
        {
            if (model.DataStore.Count() == 0)
            {
                Track unknownAuthor = null;
                List<Models.Track> artistsBeforeSort = new List<Models.Track>();
                foreach (string artist in Global.Audios.Keys)
                {
                    if(artist == "Nieznany")
                        unknownAuthor = new Models.Track { Id = artist, Text = artist, Description = "Utworów: " + Global.Audios[artist].Count };
                    else
                        artistsBeforeSort.Add(new Models.Track { Id = artist, Text = artist, Description = "Utworów: " + Global.Audios[artist].Count });
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

        public async static Task ReloadArtists(object instance, AuthorsTabModel model)
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
                foreach (string artist in Global.Audios.Keys)
                {
                    foreach (MP3Processing.Container container in Global.Audios[artist])
                    {
                        tracksBeforeSort.Add(new Models.Track { Id = artist + container.Title, Text = container.Title, Description = container.Author + " * "+container.Duration, Container = container, Tag = container.FilePath });
                    }
                    //await model.DataStore.AddItemAsync(new Models.Artist { Id = artist, Text = artist });
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
                    playlistsBeforeSort.Add(new Track() { Id = playlist, Text = playlist, Description = "Utworów: "+tracks.Count});
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


            if (Global.Audios.Count == 0)
            {
                List<string> listed = new List<string>();
                MP3Processing.Container[] files = await FileProcessing.ListFiles(Global.Directories, listed);
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

        public static void AddTrack(MP3Processing.Container container)
        {
            if (!Global.Audios.ContainsKey(container.Author.Trim()))
            {
                //File.AppendAllText(App.debugPath + "/debug.txt", "Create list for " + files[a].Author.Trim() + "\n");
                Global.Audios.Add(container.Author.Trim(), new List<MP3Processing.Container>());
            }

            //File.AppendAllText(App.debugPath + "/debug.txt", "Add " + files[a] + " to " + files[a].Author.Trim() + "\n");
            Global.Audios[container.Author.Trim()].Add(container);
        }

        public static RelativeLayout GeneratePlayerPanel()
        {
            RelativeLayout relativeLayout = new RelativeLayout()
            {
                VerticalOptions = LayoutOptions.End,
                HeightRequest = 72,
                BackgroundColor = Color.White,

            };
            return relativeLayout;
        }

        public static Track FindTrackByTag(ObservableCollection<Track> Items, string tag)
        {
            foreach(Track track in Items)
            {
                if (track.Tag == tag)
                    return track;
            }
            return null;
        }

        public static void RemoveTrack(string path, params ObservableCollection<Track>[] tracks)
        {
            RemoveTrack(path, false, tracks);
        }

        public static void RemoveTrack(string path, bool onlyPlaylist, params ObservableCollection<Track>[] tracks)
        {
            
            if(!onlyPlaylist)
            {
                bool toBreak = false;
                foreach (string author in Global.Audios.Keys)
                {
                    foreach (MP3Processing.Container container in Global.Audios[author])
                    {
                        if (container.FilePath == path)
                        {
                            Global.Audios[author].Remove(container);
                            toBreak = true;
                            break;
                        }
                    }

                    if (toBreak)
                        break;
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
    }
}
