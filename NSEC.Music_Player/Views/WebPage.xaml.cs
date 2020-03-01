using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebPage : ContentPage
    {
        public WebPage(string url)
        {
            InitializeComponent();
            titleView.Title = url.Contains("youtube") ? "Youtube" : "Soundcloud";
            WebView webView = new WebView
            {
                Source = url,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            stackLayout.Children.Add(webView);

            
        }
    }
}