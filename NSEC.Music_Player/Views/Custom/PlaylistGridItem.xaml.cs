using Android.Support.Design.Widget;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistGridItem : ContentView
    {
        private string PlaylistName { get; set; }
        public PlaylistGridItem(PlaylistListModel model)
        {
            InitializeComponent();
            playlistLabel.Text = model.Name;
            tracksLabel.Text = model.TrackElem;
            Console.WriteLine("PlaylistGridItem " + model.Name);
            PlaylistName = model.Name;

            foreach (string filePath in Global.Playlists[model.Name])
            {
                Media.MediaSource source = Global.Audios[filePath];
                if (source.Picture != null)
                {
                    image.Source = ImageSource.FromStream(() => new MemoryStream(source.Picture));
                    break;
                }
            }
        }

        private void LongPressed(object sender, EventArgs e)
        {
            PopupMenu popupMenu = new PopupMenu(Global.Context, layout, Localization.PlaylistPlay, Localization.TrackMenuEdit, Localization.TrackMenuDelete);
            popupMenu.OnSelect += PopupMenu_OnSelect;
            popupMenu.Show();
        }

        private async void PopupMenu_OnSelect(string item)
        {
            if(item == Localization.PlaylistPlay)
            {
                if (!PlayerPage.Showed)
                {
                    List<string> playlistTracks = new List<string>(Global.Playlists[PlaylistName]);
                    List<Media.MediaSource> playlist = new List<Media.MediaSource>();

                    foreach (string track in playlistTracks)
                    {
                        if (Global.Audios.ContainsKey(track))
                            playlist.Add(Global.Audios[track]);
                    }

                    if(playlist.Count > 0)
                        await Navigation.PushModalAsync(new PlayerPage(playlist[0], playlist, 0));
                }
            }
            else if(item == Localization.TrackMenuEdit)
            {
                //string userArtist = await View.DisplayPromptAsync(Localization.Artist, artist, "OK", Localization.Cancel, artist, -1, null, artist);

                string newPlaylistName = await MainPage.Instance.DisplayPromptAsync(Localization.Playlist, PlaylistName, "OK", Localization.Cancel, PlaylistName, -1, null, PlaylistName);

                if(PlaylistName != newPlaylistName && !string.IsNullOrWhiteSpace(newPlaylistName) && !Global.Playlists.ContainsKey(newPlaylistName))
                {
                    Global.Playlists.Add(newPlaylistName, new List<string>(Global.Playlists[PlaylistName]));
                    Global.Playlists.Remove(PlaylistName);
                    PlaylistName = newPlaylistName;
                    Global.SaveConfig();
                }
            }
            else if(item == Localization.TrackMenuDelete)
            {
                bool delete = await MainPage.Instance.DisplayAlert(Localization.Question, Localization.QuestionDeletePlaylist + " " + PlaylistName + "?", Localization.Yes, Localization.No);

                if(delete)
                {
                    if (Global.Playlists.ContainsKey(PlaylistName))
                        Global.Playlists.Remove(PlaylistName);

                    Global.SaveConfig();
                    SnackbarBuilder.Show(Localization.Ready);
                }
            }
        }

        private async void Pressed(object sender, EventArgs e)
        {
            await MainPage.NavigationInstance.PushAsync(new TrackListPage(Global.Playlists[PlaylistName], PlaylistName, true));
        }
    }
}