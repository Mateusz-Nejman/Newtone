using System.Linq;
using System.Windows.Input;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Mobile.UI.Logic;
using Newtone.Mobile.UI.Processing;
using Newtone.Mobile.UI.Views;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.ViewModels.ViewCells
{
    public class PlaylistGridItemViewModel : PropertyChangedBase
    {
        #region Fields
        private string playlistName;
        private string tracksText;
        private string playlistUrl;
        private ImageSource image;
        #endregion
        #region Properties
        private Xamarin.Forms.View View { get; set; }

        public string PlaylistName
        {
            get => playlistName;
            set
            {
                playlistName = value;
                OnPropertyChanged();
            }
        }

        public string PlaylistUrl
        {
            get => playlistUrl;
            set
            {
                playlistUrl = value;
                OnPropertyChanged();
            }
        }

        public string TracksText
        {
            get => tracksText;
            set
            {
                tracksText = value;
                OnPropertyChanged();
            }
        }

        public ImageSource Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        private ICommand longPressedCommand;
        public ICommand LongPressedCommand
        {
            get
            {
                if (longPressedCommand == null)
                    longPressedCommand = new ActionCommand(parameter =>
                    {
                        if (string.IsNullOrEmpty(PlaylistUrl))
                            ContextMenuBuilder.BuildForPlaylist(View, PlaylistName);
                    });

                return longPressedCommand;
            }
        }

        private ICommand pressedCommand;
        public ICommand PressedCommand
        {
            get
            {
                if (pressedCommand == null)
                    pressedCommand = new ActionCommand(async (parameter) =>
                    {
                        if (string.IsNullOrEmpty(PlaylistUrl))
                        {
                            await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new CurrentTracksPage(GlobalData.Current.Playlists[PlaylistName], PlaylistName), PlaylistName));
                        }
                        else
                        {
                            await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new SearchResultPage(PlaylistUrl), PlaylistName));
                        }
                    });
                return pressedCommand;
            }
        }
        #endregion
        #region Constructors
        public PlaylistGridItemViewModel(string playlistName, Xamarin.Forms.View view)
        {
            View = view;
            Image = ImageSource.FromFile("EmptyTrack.png");

            if (playlistName.StartsWith("https:"))
            {
                PlaylistName = GlobalData.Current.RecomendedPlaylists.Keys.First(item => GlobalData.Current.RecomendedPlaylists[item] == playlistName);
                PlaylistUrl = playlistName;
            }
            else
            {
                PlaylistName = playlistName;
                TracksText = Localization.Tracks + ": " + GlobalData.Current.Playlists[playlistName].Count;

                foreach (string filePath in GlobalData.Current.Playlists[playlistName])
                {
                    var source = GlobalData.Current.Audios[filePath];
                    if (source.Image != null)
                    {
                        Image = ImageProcessing.FromArray(source.Image);
                        break;
                    }
                }
            }
        }
        #endregion
    }
}
