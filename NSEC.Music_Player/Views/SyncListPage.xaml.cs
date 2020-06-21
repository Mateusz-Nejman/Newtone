using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.ViewModels;
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
    public partial class SyncListPage : ContentView, ITimerContent
    {
        #region Properties
        private SyncListViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public SyncListPage()
        {
            InitializeComponent();
            ViewModel = BindingContext as SyncListViewModel;
        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            ViewModel?.Tick();
        }
        #endregion
    }
}