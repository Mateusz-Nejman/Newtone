using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Desktop.Logic;
using Newtone.Desktop.Processing;
using Newtone.Desktop.ViewModels;
using Newtone.Desktop.Views.Custom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy FullScreenWindow.xaml
    /// </summary>
    public partial class FullScreenWindow : UserControl, IWindowContent
    {
        #region Properties
        private FullScreenViewModel ViewModel { get; set; }
        public static Dispatcher MainDispatcher { get; private set; }
        #endregion
        #region Constructors
        public FullScreenWindow()
        {
            InitializeComponent();
            MainDispatcher = Dispatcher;
            ViewModel = DataContext as FullScreenViewModel;
            trackSlider.ValueChanged += TrackSlider_ValueChanged;
        }
        #endregion
        #region Private Methods
        private void TrackSlider_ValueChanged(object sender, AudioSliderControl.ValueChangedArgs e)
        {
            if (GlobalData.Current.MediaPlayer.IsPlaying)
            {
                
                GlobalData.Current.MediaPlayer.Seek(e.Value);
            }
        }
        #endregion
        #region Public Methods
        public void ChangeMaximizeIcon(ImageSource newSource)
        {
            ViewModel.MaximizeIcon = newSource;
        }
        #endregion
    }
}
