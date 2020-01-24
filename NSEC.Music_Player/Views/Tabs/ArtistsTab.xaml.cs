using NSEC.Music_Player.Models;
using NSEC.Music_Player.Services;
using NSEC.Music_Player.ViewModels.Tabs;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistsTab : ContentPage, IAsyncEndListener
    {
        readonly ArtistsTabModel model;

        public event EventHandler AsyncEnded;

        public ArtistsTab()
        {
            InitializeComponent();
            this.Appearing += AuthorsTab_Appearing;
            this.LayoutChanged += ArtistsTab_LayoutChanged;

            BindingContext = model = new ArtistsTabModel();
            Global.asyncEndController.Add("authorstab", this);

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

            AsyncEnded += AuthorsTab_AsyncEnded;
            Task.Run(() => AuthorsTab_AsyncEnded(this, null));

        }

        private async void ArtistsTab_LayoutChanged(object sender, EventArgs e)
        {
            playerPanel.Refresh();
            await Helpers.ReloadArtists(this, model);
        }

        private async void AuthorsTab_Appearing(object sender, EventArgs e)
        {
            playerPanel.Refresh();
            await Helpers.ReloadArtists(this, model);
        }

        private async void AuthorsTab_AsyncEnded(object sender, EventArgs e)
        {
            //File.AppendAllText(App.debugPath + "/debugAutorsTab.txt", "Count = " + Global.Audios.Count + "\n");
            await Helpers.LoadArtistsOnce(this, model);
            model.LoadItemsCommand.Execute(this);
        }

        private async void OnAuthorSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Console.WriteLine("OnAuthorSelected: " + (item == null));
            if (!(AuthorListView.SelectedItem is Track item))
                return;

            for (int a = 0; a < model.Items.Count; a++)
            {
                model.Items[a].Selected(e.SelectedItemIndex == a);
            }

            await Navigation.PushAsync(new ArtistPage(item.Text));

            if (e.SelectedItemIndex >= 0)
                model.Items[e.SelectedItemIndex].Selected(false);
            AuthorListView.SelectedItem = null;
        }

        public void AsyncEnd()
        {
            AsyncEnded.Invoke(this, new EventArgs());
        }
    }
}