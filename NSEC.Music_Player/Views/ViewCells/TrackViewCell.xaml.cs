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
    public partial class TrackViewCell : ViewCell
    {
        #region Constructors
        public TrackViewCell()
        {
            InitializeComponent();
        }
        #endregion
    }
}