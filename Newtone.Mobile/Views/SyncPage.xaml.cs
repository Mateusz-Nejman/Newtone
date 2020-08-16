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
using Newtone.Mobile.Logic;
using Newtone.Mobile.ViewModels;

namespace Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SyncPage : ContentView, ITimerContent
    {
        #region Constructors
        public SyncPage()
        {
            InitializeComponent();
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
        #region Public Methods
        public void Tick()
        {
            (BindingContext as SyncViewModel)?.Tick();
        }
        #endregion
    }
}