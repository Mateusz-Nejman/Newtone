using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Plugin.WebView.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YoutubeTab : ContentPage
    {
        private string currentUrl = "";
        private readonly FormsWebView WebView;

        public YoutubeTab()
        {
            InitializeComponent();
            WebView = new FormsWebView
            {
                BaseUrl = "https://youtube.com",
                Source = "https://youtube.com"
            };
            WebView.OnNavigationStarted += WebView_OnNavigationStarted;
            webViewGrid.Children.Add(WebView);
            Appearing += YoutubePage_Appearing;
            Disappearing += YoutubeTab_Disappearing;

            Device.StartTimer(TimeSpan.FromSeconds(0.5), Refresh);
        }

        private void YoutubeTab_Disappearing(object sender, EventArgs e)
        {
            WebView.Source = "https://youtube.com";
            WebView.BaseUrl = "https://youtube.com";
        }

        private void YoutubePage_Appearing(object sender, EventArgs e)
        {
            playerPanel.Refresh();
        }

        private void WebView_OnNavigationStarted(object sender, Xam.Plugin.WebView.Abstractions.Delegates.DecisionHandlerDelegate e)
        {
            var url = e.Uri;

            if (url.Contains("watch?v=") || url.Contains("list="))
            {
                currentUrl = url;
                Console.WriteLine("ONS: " + currentUrl);
            }

        }

        private void YoutubeButton_Clicked(object sender, EventArgs e)
        {
            //youtubeButton.Text = "Downloading";
            //youtubeButton.IsEnabled = false;

            YoutubeProcessing.Page = this;
            progressLabel.Text = Localization.YoutubeStart;
            YoutubeProcessing.Download(currentUrl);
        }

        private void YoutubeWebview_Navigating(object sender, WebNavigatingEventArgs e)
        {
            Console.WriteLine("Change url to " + e.Url);
            if (!e.Url.Contains("youtube.com"))
                e.Cancel = true;
            else
                currentUrl = e.Url;



        }

        private void YoutubeWebview_Navigated(object sender, WebNavigatedEventArgs e)
        {
            Console.WriteLine("Change navigated url to " + e.Url);
            currentUrl = e.Url;
        }

        private void PrevButton_Clicked(object sender, EventArgs e)
        {
            if (WebView.CanGoBack)
                WebView.GoBack();
        }

        private async void ListButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DownloadPage());
        }

        private bool Refresh()
        {
            if(DownloadProcessing.GetGlobalProgress() != "")
            {
                progressLabel.Text = $"{Localization.YoutubeDownloadFiles} {DownloadProcessing.GetGlobalProgress()}";
            }

            if (DownloadProcessing.AllCompleted)
                progressLabel.Text = Localization.YoutubeReady;
            
            return true;
        }
    }
}