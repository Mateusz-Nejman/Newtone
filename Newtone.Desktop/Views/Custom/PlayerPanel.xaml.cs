using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Desktop.Media;
using Newtone.Desktop.Processing;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Newtone.Desktop.Views.Custom
{
    /// <summary>
    /// Logika interakcji dla klasy PlayerPanel.xaml
    /// </summary>
    public partial class PlayerPanel : UserControl
    {
        
        #region Constructors
        public PlayerPanel()
        {
            InitializeComponent();

            trackSlider.ValueChanged += TrackSlider_ValueChanged;
        }
        #endregion
        #region Private Methods
        private void TrackSlider_ValueChanged(object sender, AudioSliderControl.ValueChangedArgs e)
        {
            ConsoleDebug.WriteLine("TrackSlider ValueChanged");
            if (GlobalData.Current.MediaPlayer.IsPlaying)
            {
                GlobalData.Current.MediaPlayer.Seek(e.Value);
            }
        }
        #endregion
    }
}
