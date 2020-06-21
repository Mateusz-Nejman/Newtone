using Newtone.Core.Logic;
using Newtone.Core.Processing;
using Newtone.Core.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtone.Core;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.ViewModels;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SyncPage : ContentView, ITimerContent
    {
        #region Constructors
        public SyncPage()
        {
            InitializeComponent();
        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            (BindingContext as SyncViewModel)?.Tick();
        }
        #endregion
    }
}