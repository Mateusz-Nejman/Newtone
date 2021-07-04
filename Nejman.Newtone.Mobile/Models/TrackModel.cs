using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Localization;
using Nejman.Newtone.Core.Media;
using Nejman.Newtone.Mobile.Implementations;
using Nejman.Newtone.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.Models
{
    public class TrackModel : PropertyChangedBase
    {
        #region Fields
        private string path;
        private string title;
        private string duration;
        private string artist;
        private string trackString;
        private string playlistName;
        private ImageSource image;
        private bool isVisible;
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
                return string.Concat(Path, CoreGlobal.SEPARATOR, PlaylistName);
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

        public string Path
        {
            get => path;
            set
            {
                path = value;
                OnPropertyChanged();
            }
        }
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
                TrackString = Artist == Localization.UnknownArtist ? Title : string.Concat(Artist, " - ", Title);
            }
        }
        public string Duration
        {
            get => duration;
            set
            {
                duration = value;
                OnPropertyChanged();
            }
        }

        public string Artist
        {
            get => artist;
            set
            {
                artist = value;
                OnPropertyChanged();
                TrackString = Artist == Localization.UnknownArtist ? Title : string.Concat(Artist, " - ", Title);
            }
        }

        public bool IsVisible
        {
            get => isVisible;
            set
            {
                if(isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool CurrentPlaylist { get; }
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
                        ContextMenuBuilder.BuildForTrack((View)parameter, Info);
                    });

                return openMenu;
            }
        }
        #endregion
        public TrackModel(MediaSource source, string playlist = "")
        {
            Artist = source.Artist;
            Duration = source.Duration.ToString("mm':'ss");
            Path = source.Path;
            Title = source.Title;
            PlaylistName = playlist;

            Image = ImageProcessingImplementation.FromArray(source.Image);
        }

        #region Public Methods

        public TrackModel CheckChanges()
        {
            IsVisible = Path == CoreGlobal.CurrentSource?.Path;
            return this;
        }

        #endregion
    }
}
