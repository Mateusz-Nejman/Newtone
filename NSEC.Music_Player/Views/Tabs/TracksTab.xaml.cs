using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Services;
using NSEC.Music_Player.ViewModels.Tabs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xam.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TracksTab : ContentPage, IAsyncEndListener
    {
        readonly TracksTabModel model;

        public event EventHandler AsyncEnded;

        public TracksTab()
        {
            InitializeComponent();
            this.Appearing += TracksTab_Appearing;


            BindingContext = model = new TracksTabModel();
            Global.asyncEndController.Add("trackstab", this);

            AsyncEnded += TracksTab_AsyncEnded;
            Task.Run(() => TracksTab_AsyncEnded(this, null));

            RelativeLayout relativeLayout = new RelativeLayout()
            {
                HeightRequest = 64,
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.End

            };

        }

        private async void TracksTab_Appearing(object sender, EventArgs e)
        {
            playerPanel.Refresh();
            await Helpers.ReloadTracks(this, model);
            TrackListView.SelectedItem = null;
            //throw new NotImplementedException();
        }

        private async void TracksTab_AsyncEnded(object sender, EventArgs e)
        {
            await Helpers.LoadTracksOnce(this, model);
            this.model.LoadItemsCommand.Execute(this);
        }

        async void OnTrackSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(TrackListView.SelectedItem is Track item))
                return;

            for (int a = 0; a < model.Items.Count; a++)
            {
                model.Items[a].Selected(args.SelectedItemIndex == a);
            }

            Global.CurrentQueue = new List<Track>();
            Global.CurrentQueuePosition = 0;
            await Navigation.PushAsync(new PlayerPage(item, model.Items.ToList(), args.SelectedItemIndex));

            if (args.SelectedItemIndex >= 0)
                model.Items[args.SelectedItemIndex].Selected(false);
            TrackListView.SelectedItem = null;
        }

        public void AsyncEnd()
        {
            AsyncEnded.Invoke(this, new EventArgs());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            TrackProcessing.Process(sender, model.Items, this);
        }
    }
}