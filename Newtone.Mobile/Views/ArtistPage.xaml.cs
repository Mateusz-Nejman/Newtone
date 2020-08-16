using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Mobile.Views.ViewCells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistPage : ContentView, IVisibleContent
    {
        #region Constructors
        public ArtistPage()
        {
            InitializeComponent();
        }
        #endregion
        #region Public Methods
        public void Appearing()
        {
            Init();
        }

        public void Disappearing()
        {
            //throw new NotImplementedException();
        }
        public void Init()
        {
            List<string> beforeSort = new List<string>();
            string unknown = null;

            foreach (string artist in GlobalData.Artists.Keys)
            {
                if (artist == Localization.UnknownArtist)
                    unknown = artist;
                else
                    beforeSort.Add(artist);
            }

            List<string> afterSort = beforeSort.OrderBy(o => o).ToList();

            if (unknown != null)
                afterSort.Add(unknown);

            trackGrid.Children.Clear();

            int pos = 0;
            string model0 = null;
            foreach (string artist in afterSort)
            {
                if (pos == 0)
                {
                    model0 = artist;
                    pos = 1;
                }
                else
                {
                    Xamarin.Forms.RelativeLayout layout = new Xamarin.Forms.RelativeLayout();
                    layout.Children.Add(new ArtistGridItem(this, model0), null, null, Constraint.RelativeToParent(parent => parent.Width * 0.5), Constraint.Constant(150));
                    layout.Children.Add(new ArtistGridItem(this, artist), Constraint.RelativeToParent(parent => parent.Width * 0.5), null, Constraint.RelativeToParent(parent => parent.Width * 0.5), Constraint.Constant(150));
                    trackGrid.Children.Add(layout);
                    pos = 0;
                }

            }

            if (pos == 1)
            {
                Xamarin.Forms.RelativeLayout layout = new Xamarin.Forms.RelativeLayout();
                layout.Children.Add(new ArtistGridItem(this, model0), null, null, Constraint.RelativeToParent(parent => parent.Width), Constraint.Constant(200));
                trackGrid.Children.Add(layout);
            }
        }
        #endregion
    }
}