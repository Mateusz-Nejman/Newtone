﻿using Newtone.Mobile.UI.ViewModels.ViewCells;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistWebGridItem : ContentView
    {
        #region Properties
        public PlaylistPage Page { get; private set; }
        #endregion
        #region Constructors
        public PlaylistWebGridItem(PlaylistPage page, string playlistName)
        {
            InitializeComponent();
            Page = page;
            BindingContext = new PlaylistGridItemViewModel(playlistName, this);
        }
        #endregion
    }
}