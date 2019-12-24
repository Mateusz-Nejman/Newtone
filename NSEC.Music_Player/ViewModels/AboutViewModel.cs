using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NSEC.Music_Player.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "O apce";

            OpenWebCommand = new Command(() => Launcher.OpenAsync("https://mateusz-nejman.pl/"));
        }

        public ICommand OpenWebCommand { get; }
    }
}