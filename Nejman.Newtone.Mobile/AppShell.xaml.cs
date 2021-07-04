using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Localization;
using Nejman.Newtone.Mobile.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nejman.Newtone
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TracksListPage), typeof(TracksListPage));
            Routing.RegisterRoute(nameof(PlayerPage), typeof(PlayerPage));
            Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));
            Routing.RegisterRoute(nameof(DownloadsPage), typeof(DownloadsPage));

            Task.Run(async () =>
            {
                await CoreGlobal.LoadData();
                tracksPage.Title = Localization.Tracks;
                artistsPage.Title = Localization.Artists;
                playlistsPage.Title = Localization.Playlists;
                settingsPage.Title = Localization.Settings;
            });
        }

    }
}
