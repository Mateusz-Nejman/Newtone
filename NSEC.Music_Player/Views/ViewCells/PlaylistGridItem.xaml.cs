using Newtone.Core;
using Newtone.Core.Languages;
using NSEC.Music_Player.Logic;
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
    public partial class PlaylistGridItem : ContentView
    {
        #region Properties
        public PlaylistPage Page { get; private set; }
        #endregion
        #region Constructors
        public PlaylistGridItem(PlaylistPage page, string playlistName)
        {
            InitializeComponent();
            Page = page;
            BindingContext = new PlaylistGridItemViewModel(playlistName, this);
        }
        #endregion
    }
}