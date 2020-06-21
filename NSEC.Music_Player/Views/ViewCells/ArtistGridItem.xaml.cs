using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Media;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Processing;
using NSEC.Music_Player.ViewModels.ViewCells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistGridItem : ContentView
    {
        #region Constructors
        public ArtistGridItem(string artistName)
        {
            InitializeComponent();
            BindingContext = new ArtistGridItemViewModel(artistName);
        }
        #endregion
    }
}