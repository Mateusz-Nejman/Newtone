using NSEC.Music_Player.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomTitleView : ContentView
    {
        public static readonly BindableProperty TitleProperty =
  BindableProperty.Create("Title", typeof(string), typeof(CustomTitleView), null);
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty IsBackButtonProperty = BindableProperty.Create("IsBackButton", typeof(bool), typeof(CustomTitleView), false);
        public bool IsBackButton
        {
            get
            {
                return (bool)GetValue(IsBackButtonProperty);
            }
            set
            {
                SetValue(IsBackButtonProperty, value);
            }
        }

        public static readonly BindableProperty TransparentBackgroundProperty = BindableProperty.Create("TransparentBackground", typeof(bool), typeof(CustomTitleView), false);
        public bool TransparentBackground
        {
            get
            {
                return (bool)GetValue(TransparentBackgroundProperty);
            }
            set
            {
                SetValue(TransparentBackgroundProperty, value);
            }
        }

        public static readonly BindableProperty IsDownloadButtonProperty = BindableProperty.Create("IsDownloadButton", typeof(bool), typeof(CustomTitleView), true);
        public bool IsDownloadButton
        {
            get
            {
                return (bool)GetValue(IsDownloadButtonProperty);
            }
            set
            {
                SetValue(IsDownloadButtonProperty, value);
            }
        }
        public CustomTitleView()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromMilliseconds(300), Refresh);
        }

        private bool Refresh()
        {
            rootGrid.BackgroundColor = TransparentBackground ? Color.Transparent : Colors.ColorPrimary;
            backButton.IsVisible = IsBackButton;
            titleLabel.Text = Title;
            downloadButtonLayout.IsVisible = IsDownloadButton;

            downloadLabel.Text = DownloadProcessing.BadgeCount < 10 ? DownloadProcessing.BadgeCount.ToString() : "9+";
            return true;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            MainPage.NavigationInstance.PopAsync();
        }

        private void DownloadButton_Clicked(object sender, EventArgs e)
        {
            MainPage.NavigationInstance.PushAsync(new DownloadPage());
        }
    }
}