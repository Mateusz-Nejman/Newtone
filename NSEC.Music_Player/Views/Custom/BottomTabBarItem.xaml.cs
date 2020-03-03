﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomTabBarItem : ContentView
    {
        public IconView IconView
        {
            get
            {
                return iconView;
            }
        }
        public BottomTabBarItem()
        {
            InitializeComponent();
        }
    }
}