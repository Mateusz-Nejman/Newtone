using Nejman.Xamarin.FocusLibrary;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.Logic;
using Newtone.Mobile.UI.Views.TV;
using System.Windows.Input;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.Models
{
    public class PlaylistModel : NListViewItem
    {
        #region Fields
        private ImageSource image;
        private string name;
        private int trackCount;
        private string webUrl;
        #endregion

        #region Properties
        public ImageSource Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
                OnPropertyChanged(() => TrackElem);
            }
        }
        public int TrackCount
        {
            get => trackCount;
            set
            {
                trackCount = value;
                OnPropertyChanged();
                OnPropertyChanged(() => TrackElem);
            }
        }
        public string TrackElem
        {
            get
            {
                return string.Concat(Localization.Tracks, ": ", GlobalData.Current.Playlists[name].Count);
            }
        }
        public string WebUrl
        {
            get => webUrl;
            set
            {
                webUrl = value;
                OnPropertyChanged();
            }
        }

        public View View { get; set; }
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
                        if (string.IsNullOrEmpty(WebUrl))
                            ContextMenuBuilder.BuildForPlaylist(View, Name);
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
                        if (string.IsNullOrEmpty(WebUrl))
                        {
                            await Global.NavigationInstance.PushModalAsync(new ModalPage(new CurrentTracksPage(GlobalData.Current.Playlists[Name], Name), Name));
                        }
                        else
                        {
                            await Global.NavigationInstance.PushModalAsync(new ModalPage(new SearchResultPage(WebUrl), Name));
                        }
                    });
                return pressedCommand;
            }
        }
        #endregion
        #region Public Methods
        public override void FocusAction()
        {
            PressedCommand.Execute(null);
        }

        public override void LongFocusAction()
        {
            LongPressedCommand.Execute(null);
        }
        #endregion
    }
}
