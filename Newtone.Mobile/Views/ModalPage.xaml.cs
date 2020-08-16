using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
using Newtone.Core.Languages;
using Newtone.Mobile.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtone.Mobile.ViewModels;

namespace Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPage : ContentPage, INavigationContainer
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

        public void Block()
        {
            blocker.IsVisible = true;
        }

        public void Unblock()
        {
            blocker.IsVisible = false;
        }

        public bool IsBlocked()
        {
            return blocker.IsVisible;
        }

        public Type GetContentType()
        {
            return container.Children.Count == 0 ? null : container.Children[0].GetType();
        }
        #endregion
    }
}