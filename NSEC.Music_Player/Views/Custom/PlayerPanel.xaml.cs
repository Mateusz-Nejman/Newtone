using Newtone.Core.Logic;
using NSEC.Music_Player.ViewModels.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPanel : ContentView, ITimerContent
    {
        #region Properties
        private PlayerPanelViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public PlayerPanel()
        {
            InitializeComponent();
            ViewModel = BindingContext as PlayerPanelViewModel;
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