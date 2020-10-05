using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtone.Mobile.ViewModels;
using System.Reactive.Linq;
using Newtone.Mobile.Logic;
using YoutubeExplode;

namespace Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NormalPage : ContentPage, INavigationContainer
    {
        #region Properties
        private NormalViewModel ViewModel { get; set; }
        public static NormalPage Instance { get; set; }
        public static NavigationWrapper NavigationInstance
        {
            get
            {
                return new NavigationWrapper(Instance.Navigation);
            }
        }
        #endregion
        #region Constructors
        public NormalPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new NormalViewModel(container, playerPanel);
            Instance = this;
            Appearing += PageAppearing;
            Disappearing += PageDisappearing;

            ViewModel.GotoTracks.Execute(null);

            if(GlobalData.Current.AutoDownload && MainActivity.IsInternet())
            {
                new Task(async() =>
                {
                    YoutubeClient client = new YoutubeClient();
                    foreach(var key in GlobalData.Current.WebToLocalPlaylists.Keys)
                    {
                        foreach (var video in await client.Playlists.GetVideosAsync(key))
                        {
                            DownloadProcessing.Add(video.Id, video.Title, video.Url, GlobalData.Current.WebToLocalPlaylists[key]);
                        }
                    }
                    
                }).Start();
            }
        }
        #endregion
        #region Protected Methods
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        }
        #endregion
        #region Private Methods
        private void PageDisappearing(object sender, EventArgs e)
        {
            ViewModel?.Disappearing();
        }

        private void PageAppearing(object sender, EventArgs e)
        {
            ViewModel?.Appearing();
        }

        public void Block()
        {
            blocker.IsVisible = true;
        }

        public void Unblock()
        {
            blocker.IsVisible = false;
        }
        public bool IsBlocked()
        {
            return blocker.IsVisible;
        }
        #endregion

        private void Entry_Completed(object sender, EventArgs e)
        {
            foreach(var children in container.Children)
            {
                if (children is SearchPage page)
                    page?.SearchEntry_Completed(ViewModel?.EntryText);
            }
        }
        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            foreach (var children in container.Children)
            {
                if (children is SearchPage page)
                    page?.Entry_Focused();
            }
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            foreach (var children in container.Children)
            {
                if (children is SearchPage page)
                    page?.Entry_Unfocused();
            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (var children in container.Children)
            {
                if (children is SearchPage page)
                    page?.SetSearchText(ViewModel?.EntryText);
            }
        }
    }
}