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

            TapGestureRecognizer buttonTap = new TapGestureRecognizer();
            buttonTap.Tapped += CustomButton_Clicked;
            button.GestureRecognizers.Add(buttonTap);
        }

        private void CustomButton_Clicked(object sender, EventArgs e)
        {
            string[] arr = ((IconView)sender).Tag.Split(Global.SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
            string trackpath = arr[1];

            string name = "";

            if (arr.Length > 2)
                name = arr[2];



            TrackProcessing.Process(sender, null, MainPage.Instance, trackpath == "true",name);
        }
    }
}