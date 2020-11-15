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
    public class ArtistModel : NListViewItem
    {
        #region Fields
        private string name;
        private int trackCount;
        private ImageSource image;
        #endregion
        #region Properties
        public Xamarin.Forms.View View { get; set; }
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
                return string.Concat(Localization.Tracks, ": ", GlobalData.Current.Artists[name].Count);
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
                        ContextMenuBuilder.BuildForArtist(View, Name);
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
                        await Global.NavigationInstance.PushModalAsync(new ModalPage(new CurrentTracksPage(GlobalData.Current.Artists[Name], ""), Name));
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
