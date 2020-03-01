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
    public partial class HomeTrackSectionItem : ContentView
    {
        private readonly string FilePath;
        public HomeTrackSectionItem(string title, string author, string filePath, ImageSource imageSource = null)
        {
            InitializeComponent();

            titleLabel.Text = title;
            authorLabel.Text = author;
            FilePath = filePath;
            if (imageSource != null)
                image.Source = imageSource;

            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;

            GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
        }
    }
}