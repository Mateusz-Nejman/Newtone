using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Nejman.Xamarin.FocusLibrary;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Mobile.UI.Logic;
using Newtone.Mobile.UI.Processing;
using Newtone.Mobile.UI.Views.Custom;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.Models
{
    public class TrackModel : NListViewItem
    {
        #region Fields
        private string filePath;
        private string title;
        private string duration;
        private string artist;
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

        public string FilePath
        {
            get => filePath;
            set
            {
                filePath = value;
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
                        ContextMenuBuilder.BuildForTrack((Xamarin.Forms.View)parameter, Info);
                    });

                return openMenu;
            }
        }
        #endregion

        public TrackModel(Newtone.Core.Models.TrackModel model, string playlist = "", bool allowContextMenu = true, bool currentPlaylist = false)
        {
            this.Artist = model.Artist;
            this.Duration = model.Duration;
            this.FilePath = model.FilePath;
            this.Title = model.Title;
            this.PlaylistName = playlist;
            this.AllowContextMenu = allowContextMenu;
            this.CurrentPlaylist = currentPlaylist;

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

        public override void FocusAction()
        {
            int index = -1;
            List<MediaSource> items = null;
            
            if(CurrentPlaylist)
            {
                index = GlobalData.Current.CurrentPlaylist.FindIndex(source => source.FilePath == filePath);
                items = GlobalData.Current.CurrentPlaylist;
            }
            else
            {
                if(playlistName == "")
                {
                    List<TrackModel> models = new List<TrackModel>();
                    foreach (var track in GlobalData.Current.Audios.Values.ToList())
                    {
                        models.Add(new TrackModel(track).CheckChanges());
                    }

                    items = models.OrderBy(item => item.TrackString).Select(item => GlobalData.Current.Audios[item.FilePath]).ToList();
                    index = items.FindIndex(item => item.FilePath == FilePath);
                }
                else
                {
                    items = GlobalData.Current.Playlists[PlaylistName].Select(item => GlobalData.Current.Audios[item]).ToList();
                    index = items.FindIndex(item => item.FilePath == FilePath);
                }
            }
            if (index >= 0 && index < items.Count)
            {
                GlobalData.Current.MediaPlayer.LoadPlaylist(items.Select(item => item.FilePath).ToList(), index, true, true);
            }
        }

        public override void LongFocusAction()
        {
            OpenMenu.Execute(this.ParentListView.GetCurrentItemView());
        }
        #endregion
    }
}
