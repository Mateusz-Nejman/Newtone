﻿using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
using Newtone.Desktop.Logic;
using Newtone.Desktop.Models;
using Newtone.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SyncPage.xaml
    /// </summary>
    public partial class SyncPage : UserControl, ITimerContent
    {
        #region Properties
        private SyncViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public SyncPage()
        {
            InitializeComponent();
            ViewModel = DataContext as SyncViewModel;
        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            ViewModel?.Tick(syncListView);
        }
        #endregion
        #region Private Methods
        private void SyncListView_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            int index = syncListView.SelectedIndex;

            if(index >= 0 && index < ViewModel?.Items.Count)
            {
                var menu = ContextMenuBuilder.BuildForSync(ViewModel?.Items[index].FilePath);
                menu.PlacementTarget = (UIElement)sender;
                menu.IsOpen = true;
            }
        }

        public void Appearing()
        {
            throw new NotImplementedException();
        }

        public void Disappearing()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
