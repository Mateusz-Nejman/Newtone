using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
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

        public HomePage()
        {
            InitializeComponent();
            Appearing += HomePage_Appearing;
            AsyncEnded += HomePage_AsyncEnded;
            Global.AsyncEndController.Add("homepage", this);
            mostTracks.IsVisible = Global.MostTracks.Length > 0;
            lastTracks.IsVisible = Global.LastTracks.Length > 0;
        }

        private void HomePage_AsyncEnded(object sender, EventArgs e)
        {
            HomePage_Appearing(null, null);
        }

        private void HomePage_Appearing(object sender, EventArgs e)
        {
            mostTracks.IsVisible = Global.MostTracks.Length > 0;
            lastTracks.IsVisible = Global.LastTracks.Length > 0;
            mostTracks.Clear();

            foreach(var counter in Global.MostTracks)
            {
                mostTracks.AddItem(counter.Media.Title, counter.Media.Artist, counter.Media.FilePath, counter.Media.Picture == null ? Global.EmptyTrack : ImageSource.FromStream(() => new MemoryStream(counter.Media.Picture)));
            }

            lastTracks.Clear();

            foreach (var counter in Global.LastTracks)
            {
                lastTracks.AddItem(counter.Media.Title, counter.Media.Artist, counter.Media.FilePath, counter.Media.Picture == null ? Global.EmptyTrack : ImageSource.FromStream(() => new MemoryStream(counter.Media.Picture)));
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