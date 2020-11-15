using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Nejman.Xamarin.FocusLibrary;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Mobile.UI.Logic;
using Newtone.Mobile.UI.Processing;
using Newtone.Mobile.UI.Views.Custom;
using Newtone.Mobile.UI.Views.TV;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.Models
{
    public class SearchResultModel : NListViewItem
    {
        #region Fields
        private string title;
        private string author;
        private string id;
        private string mixId;
        private byte[] image;
        private TimeSpan duration;
        private string thumbUrl;
        private string videoData;
        private ImageSource thumb;
        #endregion

        #region Properties
        public ImageSource Thumb
        {
            get
            {
                CheckThumb();
                return thumb;
            }
            set
            {
                if (thumb != value)
                {
                    thumb = value;
                    OnPropertyChanged();
                }
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
        public string Author
        {
            get => author;
            set
            {
                author = value;
                OnPropertyChanged();
            }
        }
        public string Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string MixId
        {
            get => mixId;
            set
            {
                mixId = value;
                OnPropertyChanged();
            }
        }
        public byte[] Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }
        public TimeSpan Duration
        {
            get => duration;
            set
            {
                duration = value;
                OnPropertyChanged();
                OnPropertyChanged(() => DurationString);
            }
        }
        public string ThumbUrl
        {
            get => thumbUrl;
            set
            {
                thumbUrl = value;
                OnPropertyChanged();
            }
        }
        public string VideoData
        {
            get => videoData;
            set
            {
                videoData = value;
                OnPropertyChanged();
            }
        }
        public string DurationString
        {
            get
            {
                return Duration.ToString("mm':'ss");
            }
        }
        public bool IsOffline
        {
            get
            {
                return id.Length > 11;
            }
        }
        public Color BackgroundColor
        {
            get => IsOffline ? Color.FromHex("#060606") : Color.Transparent;
        }

        public bool IsVisible => !IsOffline;
        #endregion
        #region Commands
        private ICommand downloadClicked;
        public ICommand DownloadClicked
        {
            get
            {
                if (downloadClicked == null)
                    downloadClicked = new ActionCommand(parameter =>
                    {
                        ContextMenuBuilder.BuildForSearchResult(parameter as View, VideoData);
                    });

                return downloadClicked;
            }
            set => downloadClicked = value;
        }
        #endregion
        #region Constructors
        public SearchResultModel(Newtone.Core.Models.SearchResultModel model)
        {
            this.Author = model.Author;
            this.Duration = model.Duration;
            this.Id = model.Id;
            this.Image = model.Image;
            this.MixId = model.MixId;
            this.ThumbUrl = model.ThumbUrl;
            this.Title = model.Title;
            this.VideoData = model.VideoData;
        }
        #endregion
        #region Public Methods
        public void CheckChanges()
        {
            CheckThumb();
        }

        public MediaSource ToMediaSource()
        {
            return new MediaSource()
            {
                Artist = Author,
                Duration = Duration,
                FilePath = Id,
                Image = Image,
                Title = Title,
                Type = Id.Length == 11 ? MediaSource.SourceType.Web : MediaSource.SourceType.Local
            };
        }

        public override async void FocusAction()
        {
            NUntouchedListView listView = ParentListView;

            int index = listView.NFocusedIndex;

            if (index >= 0 && index < listView.NItemSource.Count)
            {
                var item = listView.NItemSource[index] as SearchResultModel;
                GlobalData.Current.CurrentPlaylist.Clear();

                if (string.IsNullOrEmpty(item.MixId))
                {
                    GlobalData.Current.PlaylistPosition = index;

                    foreach (var _item in listView.NItemSource)
                    {
                        var __item = _item as SearchResultModel;
                        GlobalData.Current.CurrentPlaylist.Add(new Newtone.Core.Media.MediaSource()
                        {
                            Artist = __item.Author,
                            Duration = __item.Duration,
                            FilePath = __item.Id,
                            Image = __item.Image,
                            Title = __item.Title,
                            Type = __item.Id.Length == 11 ? Newtone.Core.Media.MediaSource.SourceType.Web : Core.Media.MediaSource.SourceType.Local
                        });
                    }

                    GlobalData.Current.MediaSource = GlobalData.Current.CurrentPlaylist[index];

                    GlobalData.Current.MediaPlayer.LoadPlaylist(() =>
                    {
                        List<Core.Media.MediaSource> newPlaylist = listView.NItemSource.Select(_item =>
                        {
                            var __item = _item as SearchResultModel;
                            return new Core.Media.MediaSource()
                            {
                                Artist = __item.Author,
                                Duration = __item.Duration,
                                FilePath = __item.Id,
                                Image = __item.Image,
                                Title = __item.Title,
                                Type = __item.Id.Length == 11 ? Newtone.Core.Media.MediaSource.SourceType.Web : Core.Media.MediaSource.SourceType.Local
                            };
                        }).ToList();

                        return newPlaylist;
                    }, index, true, true);
                }
                else
                {
                    GlobalData.Current.MediaPlayer.LoadPlaylist(item.MixId, 0, new Newtone.Core.Media.MediaSource()
                    {
                        Artist = item.Author,
                        Duration = item.Duration,
                        FilePath = item.Id,
                        Image = item.Image,
                        Title = item.Title,
                        Type = Newtone.Core.Media.MediaSource.SourceType.Web
                    }, true, true);
                }

                await Global.NavigationInstance.PushModalAsync(new FullScreenPage());
            }
        }

        public override void LongFocusAction()
        {
            DownloadClicked.Execute(ParentListView.GetCurrentItemView());
        }
        #endregion
        #region Private Methods
        private void CheckThumb()
        {
            if (thumb == null && Image != null && Image.Length > 0)
            {
                thumb = ImageProcessing.FromArray(Image);
                OnPropertyChanged(() => Thumb);
            }
        }
        #endregion
    }
}
