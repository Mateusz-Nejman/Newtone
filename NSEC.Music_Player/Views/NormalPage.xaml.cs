using Newtone.Core;
using Newtone.Core.Loaders;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
using Newtone.Core.Languages;
using NSEC.Music_Player.Processing;
using NSEC.Music_Player.Views.Images;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NSEC.Music_Player.ViewModels;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NormalPage : ContentPage
    {
        #region Properties
        private NormalViewModel ViewModel { get; set; }
        public static NormalPage Instance { get; set; }
        public static INavigation NavigationInstance
        {
            get
            {
                return Instance.Navigation;
            }
        }
        #endregion
        #region Constructors
        public NormalPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new NormalViewModel(container, playerPanel);
            Instance = this;
            Appearing += PageAppearing;
            Disappearing += PageDisappearing;

            ViewModel.GotoTracks.Execute(null);
        }
        #endregion
        #region Protected Methods
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        }
        #endregion
        #region Private Methods
        private void PageDisappearing(object sender, EventArgs e)
        {
            ViewModel?.Disappearing();
        }

        private void PageAppearing(object sender, EventArgs e)
        {
            ViewModel?.Appearing();
        }
        #endregion
    }
}