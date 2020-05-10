﻿using Newtone.Core;
using NSEC.Music_Player.Views.ViewCells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistPage : ContentView
    {
        public PlaylistPage()
        {
            InitializeComponent();

            trackGrid.Children.Clear();

            int pos = 0;
            string model0 = null;

            foreach (string playlist in GlobalData.Playlists.Keys)
            {
                if (pos == 0)
                {
                    model0 = playlist;
                    pos = 1;
                }
                else
                {
                    Xamarin.Forms.RelativeLayout layout = new Xamarin.Forms.RelativeLayout();
                    layout.Children.Add(new PlaylistGridItem(model0), null, null, Constraint.RelativeToParent(parent => parent.Width * 0.5), Constraint.RelativeToParent(parent => parent.Width * 0.5));
                    layout.Children.Add(new PlaylistGridItem(playlist), Constraint.RelativeToParent(parent => parent.Width * 0.5), null, Constraint.RelativeToParent(parent => parent.Width * 0.5), Constraint.RelativeToParent(parent => parent.Width * 0.5));
                    trackGrid.Children.Add(layout);
                    pos = 0;
                }
            }

            if (pos == 1)
            {
                Xamarin.Forms.RelativeLayout layout = new Xamarin.Forms.RelativeLayout();
                layout.Children.Add(new PlaylistGridItem(model0), null, null, Constraint.RelativeToParent(parent => parent.Width * 0.5), Constraint.RelativeToParent(parent => parent.Width * 0.5));
                trackGrid.Children.Add(layout);
            }
        }
    }
}