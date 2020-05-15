﻿using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Views.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SyncViewCell : ViewCell
    {
        public SyncViewCell()
        {
            InitializeComponent();
        }

        private void CustomImageButton_Clicked(object sender, EventArgs e)
        {
            ContextMenuBuilder.BuildForSyncList((View)sender, ((CustomImageButton)sender).Tag);

        }
    }
}