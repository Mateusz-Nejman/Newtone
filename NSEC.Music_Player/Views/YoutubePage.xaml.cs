using NSEC.Music_Player.Logic;
using System;
using Xam.Plugin.WebView.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YoutubePage : ContentPage
    {
        private string currentUrl = "";
        private FormsWebView WebView;
        public YoutubePage()
        {
            InitializeComponent();

            WebView = new FormsWebView();
            WebView.BaseUrl = "https://youtube.com";
            WebView.Source = "https://youtube.com";
            WebView.OnNavigationStarted += WebView_OnNavigationStarted;
            webViewGrid.Children.Add(WebView);
            this.Appearing += YoutubePage_Appearing;

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
                currentUrl = url.Substring(0, url.IndexOf('&'));
                Console.WriteLine("ONS: " + currentUrl);
            }

        }

        private async void youtubeButton_Clicked(object sender, EventArgs e)
        {
            //youtubeButton.Text = "Downloading";
            youtubeButton.IsEnabled = false;
            await YoutubeProcessing.Download(currentUrl, youtubeButton, progressBar, progressLabel);
        }

        private void youtubeWebview_Navigating(object sender, WebNavigatingEventArgs e)
        {
            Console.WriteLine("Change url to " + e.Url);
            currentUrl = e.Url;

        }

        private void youtubeWebview_Navigated(object sender, WebNavigatedEventArgs e)
        {
            Console.WriteLine("Change navigated url to " + e.Url);
            currentUrl = e.Url;
        }

        private void prevButton_Clicked(object sender, EventArgs e)
        {
            if (WebView.CanGoBack)
                WebView.GoBack();
        }
    }
}