using NSEC.Music_Player.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackListViewCell : ViewCell
    {
        public TrackListViewCell()
        {
            InitializeComponent();
        }

        private void CustomButton_Clicked(object sender, EventArgs e)
        {
            string trackpath = ((CustomButton)sender).Tag;

            TrackProcessing.Process(sender, null, MainPage.Instance);
        }
    }
}