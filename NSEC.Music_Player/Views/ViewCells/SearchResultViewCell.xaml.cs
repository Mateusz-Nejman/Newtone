﻿using Newtone.Core;
using Newtone.Core.Processing;
using Newtone.Core.Languages;
using NSEC.Music_Player.Views.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode;

namespace NSEC.Music_Player.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultViewCell : ViewCell
    {
        #region Constructors
        public SearchResultViewCell()
        {
            InitializeComponent();
        }
        #endregion
    }
}