using Android.App;
using Android.Support.Design.Widget;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Services;
using NSEC.Music_Player.ViewModels.Tabs;
using NSEC.Music_Player.Views.CustomViews;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Xam.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistsTab : ContentPage, IAsyncEndListener, IInvokePage
    {
        readonly PlaylistsTabModel model;

        public event EventHandler AsyncEnded;
        private string PlaylistName { get; set; }

        public PlaylistsTab()
        {
            InitializeComponent();
            Appearing += PlaylistsTab_Appearing;

            BindingContext = model = new PlaylistsTabModel();
            Global.asyncEndController.Add("playliststab", this);

            /*if (model.DataStore.Count() == 0)
            {
                File.AppendAllText(App.debugPath + "/authorsTab.txt", "Artist count " + Global.Audios.Count + "\n");
                foreach (string artist in Global.Audios.Keys)
                {
                    var item = new Artist() { Id = artist, Text = artist, Description = "Utworów: " + Global.Audios[artist].Count };
                    model.Items.Add(item);
                    Task.Run(() => model.DataStore.AddItemAsync(item));
                    //MenuItems.Add();
                    File.AppendAllText(App.debugPath + "/authorsTab.txt", "Add artist " + artist + "\n");
                }

                
            }*/

            AsyncEnded += PlaylistsTab_AsyncEnded;
            Task.Run(() => PlaylistsTab_AsyncEnded(this, null));

        }

        private async void PlaylistsTab_Appearing(object sender, EventArgs e)
        {
            playerPanel.Refresh();
            await Helpers.ReloadPlaylists(this, model);
        }

        private async void PlaylistsTab_AsyncEnded(object sender, EventArgs e)
        {
            //File.AppendAllText(App.debugPath + "/debugAutorsTab.txt", "Count = " + Global.Audios.Count + "\n");
            await Helpers.LoadPlaylistsOnce(this, model);
            model.LoadItemsCommand.Execute(this);
        }

        private async void OnPlaylistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Console.WriteLine("OnAuthorSelected: " + (item == null));
            if (!(PlaylistsListView.SelectedItem is Track item))
                return;

            for (int a = 0; a < model.Items.Count; a++)
            {
                model.Items[a].Selected(e.SelectedItemIndex == a);
            }

            await Navigation.PushAsync(new PlaylistPage(item.Text));

            if (e.SelectedItemIndex >= 0)
                model.Items[e.SelectedItemIndex].Selected(false);
            PlaylistsListView.SelectedItem = null;
        }

        public void AsyncEnd()
        {
            AsyncEnded.Invoke(this, new EventArgs());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CustomButton button = (CustomButton)sender;
            Console.WriteLine("BUTTON TAG: " + button.Tag);
            PlaylistName = button.Tag;

            PopupMenu menu = new PopupMenu(Global.Context, (View)sender, Localization.Play, Localization.TrackMenuDelete);
            menu.OnSelect += Menu_OnItemSelected;
            menu.Show();
        }

        private async void Menu_OnItemSelected(string item)
        {
            if(item == Localization.Play)
            {
                if(Global.Playlists[PlaylistName].Count > 0)
                {
                    if (Global.MediaPlayer != null)
                        Global.MediaPlayer.Stop();

                    bool files = false;
                    for(int a = 0; a < Global.Playlists[PlaylistName].Count; a++)
                    {
                        if(File.Exists(Global.Playlists[PlaylistName][a].Container.FilePath))
                        {
                            Global.AudioPlayerTrack = Global.Playlists[PlaylistName][a].Container.FilePath;
                            Global.CurrentTrack = Global.Playlists[PlaylistName][a].Container;
                            Global.CurrentPlaylist = Global.Playlists[PlaylistName];
                            Global.CurrentPlaylistPosition = 0;
                            Global.MediaPlayer.Load(FileProcessing.GetStreamFromFile(Global.CurrentTrack.FilePath), Global.CurrentTrack.FilePath);
                            Global.MediaPlayer.Play();
                            files = true;
                            break;
                        }
                    }

                    if (!files)
                        SnackbarBuilder.Show(Localization.PlaylistCorrupted);
                    
                }
                
            }
            else if(item == Localization.TrackMenuDelete)
            {
                bool answer = await DisplayAlert(Localization.Question, Localization.QuestionDelete+" "+PlaylistName+"?", Localization.Yes, Localization.No);

                if(answer)
                {
                    Global.Playlists.Remove(PlaylistName);
                    await Helpers.ReloadPlaylists(this, model);
                    Global.SaveConfig();

                    SnackbarBuilder.Show(Localization.SnackDelete);
                }
            }
        }

        public void PageInvoke()
        {
            PlaylistsTab_Appearing(null, null);
        }
    }
}