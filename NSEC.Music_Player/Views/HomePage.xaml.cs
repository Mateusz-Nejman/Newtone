using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Views.Custom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentView, IViewPage, IAsyncEndListener
    {
        public event EventHandler Appearing;
        public event EventHandler Disappearing;
        public event EventHandler AsyncEnded;
        private bool stopTimer = false;

        public HomePage()
        {
            InitializeComponent();
            Appearing += HomePage_Appearing;
            Disappearing += HomePage_Disappearing;
            AsyncEnded += HomePage_AsyncEnded;
            Global.AsyncEndController.Add("homepage", this);
            mostTracks.IsVisible = Global.MostTracks.Length > 0;
            lastTracks.IsVisible = Global.LastTracks.Length > 0;

            Device.StartTimer(TimeSpan.FromSeconds(1), Refresh);
        }

        private void HomePage_Disappearing(object sender, EventArgs e)
        {
            stopTimer = true;
        }

        private bool Refresh()
        {
            mostTracks.IsVisible = Global.MostTracks.Length > 0;
            lastTracks.IsVisible = Global.LastTracks.Length > 0;

            mostTracks.Clear();

            for (int a = 0; a < Global.MostTracks.Length; a++)
            {
                TrackCounter counter = Global.MostTracks[a];
                mostTracks.AddItem(counter.Media.Title, counter.Media.Artist, counter.Media.FilePath, a, true, counter.Media.Picture == null ? Global.EmptyTrack : ImageSource.FromStream(() => new MemoryStream(counter.Media.Picture)));
            }

            lastTracks.Clear();

            for (int a = 0; a < Global.LastTracks.Length; a++)
            {
                TrackCounter counter = Global.LastTracks[a];
                lastTracks.AddItem(counter.Media.Title, counter.Media.Artist, counter.Media.FilePath, a, false, counter.Media.Picture == null ? Global.EmptyTrack : ImageSource.FromStream(() => new MemoryStream(counter.Media.Picture)));
            }


            return false;
        }

        private void HomePage_AsyncEnded(object sender, EventArgs e)
        {
            Refresh();
        }

        private void HomePage_Appearing(object sender, EventArgs e)
        {
            if(stopTimer)
            {
                stopTimer = false;
                Device.StartTimer(TimeSpan.FromSeconds(1), Refresh);
            }
        }

        public void InvokeD(object sender)
        {
            Disappearing?.Invoke(sender, null);
        }

        public void InvokeA(object sender)
        {
            Appearing?.Invoke(sender, null);
        }

        public void SetTitleView(CustomTitleView titleView)
        {
            titleView.Title = Localization.MainPage;
            titleView.IsBackButton = false;
        }

        public void AsyncEnd()
        {
            HomePage_Appearing(null, null);
        }
    }
}