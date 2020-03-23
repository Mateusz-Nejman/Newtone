using NSEC.Music_Player.Loaders;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistPage : ContentPage
    {
        public ArtistPage()
        {
            InitializeComponent();
            Appearing += ArtistPage_Appearing;
        }

        private void ArtistPage_Appearing(object sender, EventArgs e)
        {
            ArtistLoader.LoadGrid(ref trackGrid);
        }
    }
}