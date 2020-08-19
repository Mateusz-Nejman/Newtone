﻿using Newtone.Core;
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
    public partial class PlaylistPage : ContentView, IVisibleContent, ITimerContent
    {
        #region Fields
        private static IList<View> generatedChildrens;
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
            if(generatedChildrens == null)
            {
                generatedChildrens = new List<View>();
                int pos = 0;
                string model0 = null;

                foreach (string playlist in GlobalData.Current.Playlists.Keys)
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

                trackGrid.Children.Clear();
                generatedChildrens.ForEach(trackGrid.Children.Add);
            }
            else
            {
                if (trackGrid.Children.Count == 0 && generatedChildrens?.Count > 0)
                {
                    generatedChildrens.ForEach(trackGrid.Children.Add);
                }
            }
            
        }
        public void Appearing()
        {
        }

        public void Disappearing()
        {
            //throw new NotImplementedException();
        }

        public void Tick()
        {
            if (GlobalData.Current.PlaylistsNeedRefresh)
            {
                Console.WriteLine("PlaylistPage NeedRefresh");
                if (generatedChildrens != null)
                    generatedChildrens = null;

                Device.BeginInvokeOnMainThread(Init);
                GlobalData.Current.PlaylistsNeedRefresh = false;
            }
        }
        #endregion
    }
}