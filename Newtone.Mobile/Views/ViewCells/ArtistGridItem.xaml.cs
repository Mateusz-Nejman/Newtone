using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Media;
using Newtone.Mobile.Media;
using Newtone.Mobile.Processing;
using Newtone.Mobile.ViewModels.ViewCells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistGridItem : ContentView
    {
        #region Properties
        public ArtistPage Page { get; private set; }
        #endregion
        #region Constructors
        public ArtistGridItem(ArtistPage page, string artistName)
        {
            InitializeComponent();
            Page = page;
            BindingContext = new ArtistGridItemViewModel(artistName, this);
        }
        #endregion
    }
}