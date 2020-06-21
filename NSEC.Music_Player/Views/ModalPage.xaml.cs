using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
using Newtone.Core.Languages;
using NSEC.Music_Player.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NSEC.Music_Player.ViewModels;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPage : ContentPage
    {
        #region Properties
        private ModalViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public ModalPage(ContentView content, string title, bool topPanelVisible = true)
        {
            InitializeComponent();
            BindingContext = ViewModel = new ModalViewModel(container, title, topPanelVisible, playerPanel);
            container.Children.Add(content);

            Appearing += PageAppearing;
            Disappearing += PageDisappearing;

            
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