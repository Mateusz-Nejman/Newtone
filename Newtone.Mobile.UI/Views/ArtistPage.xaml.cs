using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.Views.ViewCells;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistPage : ContentView, IVisibleContent, ITimerContent
    {
        #region Fields
        private static IList<View> generatedChildrens;
        private bool isInitializing = false;
        #endregion
        #region Constructors
        public ArtistPage()
        {
            InitializeComponent();
            Init();
        }
        #endregion
        #region Public Methods
        public void Appearing()
        {
            //Not implemented
        }

        public void Disappearing()
        {
            //Not implemented
        }
        public void Init()
        {
            isInitializing = true;
            if (generatedChildrens == null)
            {
                generatedChildrens = new List<View>();
                List<string> beforeSort = new List<string>();
                string unknown = null;

                foreach (string artist in GlobalData.Current.Artists.Keys.ToList())
                {
                    if (artist == Localization.UnknownArtist)
                        unknown = artist;
                    else
                        beforeSort.Add(artist);
                }

                List<string> afterSort = beforeSort.OrderBy(o => o).ToList();

                if (unknown != null)
                    afterSort.Add(unknown);

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
                        generatedChildrens.Add(layout);
                        pos = 0;
                    }

                }

                if (pos == 1)
                {
                    Xamarin.Forms.RelativeLayout layout = new Xamarin.Forms.RelativeLayout();
                    layout.Children.Add(new ArtistGridItem(this, model0), null, null, Constraint.RelativeToParent(parent => parent.Width), Constraint.Constant(200));
                    generatedChildrens.Add(layout);
                }

                Device.BeginInvokeOnMainThread(() =>
                {
                    trackGrid.Children.Clear();
                    generatedChildrens.ForEach(trackGrid.Children.Add);
                });
            }
            else
            {
                if (trackGrid.Children.Count == 0 && generatedChildrens?.Count > 0)
                {
                    Device.BeginInvokeOnMainThread(() => generatedChildrens.ForEach(trackGrid.Children.Add));
                }
            }
            isInitializing = false;
        }

        public void Tick()
        {
            if (GlobalData.Current.ArtistsNeedRefresh && !isInitializing && Global.Loaded)
            {
                generatedChildrens = null;

                Init();
                GlobalData.Current.ArtistsNeedRefresh = false;
            }
        }
        #endregion
    }
}