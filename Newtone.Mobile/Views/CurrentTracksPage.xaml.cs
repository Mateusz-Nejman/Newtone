﻿using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Mobile.Media;
using Newtone.Mobile.Models;
using Newtone.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentTracksPage : ContentView, ITimerContent
    {
        #region Properties
        private CurrentTracksViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public CurrentTracksPage(List<string> tracks, string playlistName)
        {
            InitializeComponent();

            BindingContext = ViewModel = new CurrentTracksViewModel(tracks, playlistName);

        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            ViewModel?.Tick();

        }
        #endregion
        #region Private Methods
        private void TrackListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel?.TrackListView_ItemSelected(sender, e);
        }

        public void Appearing()
        {
            throw new NotImplementedException();
        }

        public void Disappearing()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}