using System.ComponentModel;
using Xamarin.Forms;

namespace NSEC.Music_Player.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            this.Appearing += AboutPage_Appearing;
        }

        private void AboutPage_Appearing(object sender, System.EventArgs e)
        {
            playerPanel.Refresh();
        }
    }
}