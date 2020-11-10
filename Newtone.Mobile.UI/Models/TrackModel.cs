using System.Windows.Input;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.Logic;
using Newtone.Mobile.UI.Processing;
using Newtone.Mobile.UI.Views.Custom;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.Models
{
    public class TrackModel : Newtone.Core.Models.TrackModel
    {
        #region Fields
        private bool isVisible;
        private string trackString;
        private string playlistName;
        private ImageSource image;
        private bool allowContextMenu;
        #endregion

        #region Properties
        public string PlaylistName
        {
            get => playlistName;
            set
            {
                playlistName = value;
                OnPropertyChanged();
                OnPropertyChanged(() => Info);
            }
        }
        public string Info
        {
            get
            {
                return string.Concat(FilePath, GlobalData.SEPARATOR, PlaylistName);
            }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public string TrackString
        {
            get
            {
                return trackString;
            }
            set
            {
                string newValue = value;
                if (newValue != trackString)
                {
                    trackString = newValue;
                    OnPropertyChanged();
                }
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

        public bool AllowContextMenu
        {
            get => allowContextMenu;
            set
            {
                allowContextMenu = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        private ICommand openMenu;
        public ICommand OpenMenu
        {
            get
            {
                if (openMenu == null)
                    openMenu = new ActionCommand(parameter =>
                    {
                        ContextMenuBuilder.BuildForTrack((Xamarin.Forms.View)parameter, ((CustomImageButton)parameter).Tag);
                    });

                return openMenu;
            }
        }
        #endregion

        public TrackModel(Newtone.Core.Models.TrackModel model, string playlist = "", bool allowContextMenu = true)
        {
            this.Artist = model.Artist;
            this.Duration = model.Duration;
            this.FilePath = model.FilePath;
            this.Title = model.Title;
            this.PlaylistName = playlist;
            this.AllowContextMenu = allowContextMenu;

            if (FilePath.Length > 11)
                this.Image = (GlobalData.Current.Audios[FilePath].Image == null || GlobalData.Current.Audios[FilePath].Image.Length == 0) ? ImageSource.FromFile("EmptyTrack.png") : ImageProcessing.FromArray(GlobalData.Current.Audios[FilePath].Image);
            else
            {
                Newtone.Core.Media.MediaSource source = null;
                if (GlobalData.Current.SavedTracks.ContainsKey(FilePath))
                    source = GlobalData.Current.SavedTracks[FilePath];
                else
                    source = GlobalData.Current.CurrentPlaylist.Find(src => src.FilePath == model.FilePath);

                if (source != null)
                    this.Image = (source.Image == null || source.Image.Length == 0) ? ImageSource.FromFile("EmptyTrack.png") : ImageProcessing.FromArray(source.Image);
            }
        }

        #region Public Methods

        public TrackModel CheckChanges()
        {
            IsVisible = FilePath == GlobalData.Current.MediaSourcePath;
            TrackString = Artist == Localization.UnknownArtist ? Title : string.Concat(Artist, " - ", Title);
            return this;
        }
        #endregion
    }
}
