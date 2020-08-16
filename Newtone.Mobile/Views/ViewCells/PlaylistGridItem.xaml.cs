using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Mobile.Logic;
using Newtone.Mobile.Media;
using Newtone.Mobile.Processing;
using Newtone.Mobile.ViewModels.ViewCells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.Views.ViewCells
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