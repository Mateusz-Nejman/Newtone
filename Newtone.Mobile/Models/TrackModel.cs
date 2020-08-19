using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Mobile.Logic;
using Newtone.Mobile.Processing;
using Newtone.Mobile.Views.Images;
using Xamarin.Forms;

namespace Newtone.Mobile.Models
{
    public class TrackModel : Newtone.Core.Models.TrackModel
    {
        #region Fields
        //TODO Visibility
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
                return $"{FilePath}{GlobalData.SEPARATOR}{PlaylistName}";
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

            if(FilePath.Length > 11)
                this.Image = (GlobalData.Current.Audios[FilePath].Image == null || GlobalData.Current.Audios[FilePath].Image.Length == 0) ? ImageSource.FromFile("EmptyTrack.png") : ImageProcessing.FromArray(GlobalData.Current.Audios[FilePath].Image);
            else
            {
                var source = GlobalData.Current.CurrentPlaylist.Find(src => src.FilePath == model.FilePath);

                if (source != null)
                    this.Image = ImageProcessing.FromArray(source.Image);
            }
        }

        #region Public Methods

        public TrackModel CheckChanges()
        {
            IsVisible = FilePath == GlobalData.Current.MediaSourcePath;
            TrackString = Artist == Localization.UnknownArtist ? Title : $"{Artist} - {Title}";
            return this;
        }
        #endregion
    }
}