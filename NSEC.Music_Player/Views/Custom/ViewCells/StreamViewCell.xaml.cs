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
    public partial class StreamViewCell : ViewCell
    {
        public StreamViewCell()
        {
            InitializeComponent();

            TapGestureRecognizer buttonTap = new TapGestureRecognizer();
            buttonTap.Tapped += CustomButton_Clicked;
            button.GestureRecognizers.Add(buttonTap);
        }

        private void CustomButton_Clicked(object sender, EventArgs e)
        {
            CustomButton button = (CustomButton)sender;
            string[] data = button.Tag.Split(Global.SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
            string url = $"https://youtube.com/watch?v={button.Tag}";

            DownloadProcessing.GetDownloadInterface(url).AddToDownload("", data[1],data);
        }
    }
}