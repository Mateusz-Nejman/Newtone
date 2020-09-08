using Newtone.Core;
using System.Windows.Controls;

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
            if (GlobalData.Current.MediaPlayer.IsPlaying)
            {
                GlobalData.Current.MediaPlayer.Seek(e.Value);
            }
        }
        #endregion
    }
}
