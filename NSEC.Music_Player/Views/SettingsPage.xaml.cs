using Android.Content;
using Newtone.Core;
using Newtone.Core.Media;
using Newtone.Core.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Views.Custom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtone.Core.Models;
using NSEC.Music_Player.ViewModels;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentView
    {
        #region Properties
        private SettingsViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public SettingsPage()
        {
            InitializeComponent();

            ViewModel = BindingContext as SettingsViewModel;
        }
        #endregion
        #region Private Methods
        private async void SettingsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await ViewModel?.Item_Selected(sender, e);
        }
        #endregion
    }
}