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

            if (url.StartsWith("https://m.youtube.com/watch?v="))
            {
                currentUrl = url.Substring(0, url.IndexOf('&') >= 0 ? url.IndexOf('&') : url.Length);
                Console.WriteLine("ONS: " + currentUrl);
            }

        }

        private async void YoutubeButton_Clicked(object sender, EventArgs e)
        {
            //youtubeButton.Text = "Downloading";
            //youtubeButton.IsEnabled = false;
            if (!Global.Downloads.ContainsKey(currentUrl))
                await YoutubeProcessing.Download(currentUrl, youtubeButton, progressBar, progressLabel);
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
    }
}