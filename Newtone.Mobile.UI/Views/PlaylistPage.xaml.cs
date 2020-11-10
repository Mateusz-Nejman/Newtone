using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Mobile.UI.Views.ViewCells;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistPage : ContentView, IVisibleContent, ITimerContent
    {
        #region Fields
        private static IList<View> generatedChildrens;
        private bool isInitializing = false;
        #endregion
        #region Constructors
        public PlaylistPage()
        {
            InitializeComponent();
            Init();
        }
        #endregion
        #region Public Methods
        public void Init()
        {
            isInitializing = true;
            if (generatedChildrens == null)
            {
                List<string> beforeSort = new List<string>();

                foreach (string playlist in GlobalData.Current.Playlists.Keys.ToList())
                {
                    beforeSort.Add(playlist);
                }

                List<string> afterSort = beforeSort.OrderBy(o => o).ToList();

                generatedChildrens = new List<View>();
                int pos = 0;
                string model0 = null;

                foreach (string playlist in afterSort)
                {
                    if (pos == 0)
                    {
                        model0 = playlist;
                        pos = 1;
                    }
                    else
                    {
                        Xamarin.Forms.RelativeLayout layout = new Xamarin.Forms.RelativeLayout();
                        layout.Children.Add(new PlaylistGridItem(this, model0), null, null, Constraint.RelativeToParent(parent => parent.Width * 0.5), Constraint.Constant(150));
                        layout.Children.Add(new PlaylistGridItem(this, playlist), Constraint.RelativeToParent(parent => parent.Width * 0.5), null, Constraint.RelativeToParent(parent => parent.Width * 0.5), Constraint.Constant(150));

                        generatedChildrens.Add(layout);
                        pos = 0;
                    }
                }

                if (pos == 1)
                {
                    Xamarin.Forms.RelativeLayout layout = new Xamarin.Forms.RelativeLayout();
                    layout.Children.Add(new PlaylistGridItem(this, model0), null, null, Constraint.RelativeToParent(parent => parent.Width), Constraint.Constant(200));
                    generatedChildrens.Add(layout);
                }

                GenerateRecomended();

                Device.BeginInvokeOnMainThread(() =>
                {
                    trackGrid.Children.Clear();
                    foreach (var item in generatedChildrens.ToList())
                    {
                        trackGrid.Children.Add(item);
                    }
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
        public void Appearing()
        {
            //Not implemented
        }

        public void Disappearing()
        {
            //Not implemented
        }

        public void Tick()
        {
            if (GlobalData.Current.PlaylistsNeedRefresh && !isInitializing && Global.Loaded)
            {
                if (generatedChildrens != null)
                    generatedChildrens = null;

                Init();
                GlobalData.Current.PlaylistsNeedRefresh = false;
            }
        }
        #endregion
        #region Private Methods
        private void GenerateRecomended()
        {
            if (Global.Application.HasInternet())
            {
                GlobalData.Current.RecomendedPlaylists = RecomendedPlaylists.GetRecomendedPlaylists();
            }

            int pos = 0;
            string model0 = null;

            foreach (var key in GlobalData.Current.RecomendedPlaylists.Keys)
            {
                if (pos == 0)
                {
                    model0 = GlobalData.Current.RecomendedPlaylists[key];
                    pos = 1;
                }
                else
                {
                    Xamarin.Forms.RelativeLayout layout = new Xamarin.Forms.RelativeLayout();
                    layout.Children.Add(new PlaylistWebGridItem(this, model0), null, null, Constraint.RelativeToParent(parent => parent.Width * 0.5), Constraint.Constant(150));
                    layout.Children.Add(new PlaylistWebGridItem(this, GlobalData.Current.RecomendedPlaylists[key]), Constraint.RelativeToParent(parent => parent.Width * 0.5), null, Constraint.RelativeToParent(parent => parent.Width * 0.5), Constraint.Constant(150));

                    generatedChildrens.Add(layout);
                    pos = 0;
                }
            }

            if (pos == 1)
            {
                Xamarin.Forms.RelativeLayout layout = new Xamarin.Forms.RelativeLayout();
                layout.Children.Add(new PlaylistWebGridItem(this, model0), null, null, Constraint.RelativeToParent(parent => parent.Width), Constraint.Constant(200));
                generatedChildrens.Add(layout);
            }
        }
        #endregion
    }
}