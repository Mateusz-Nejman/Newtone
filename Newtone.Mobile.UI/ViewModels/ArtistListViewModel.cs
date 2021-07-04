using Nejman.Xamarin.FocusLibrary;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Mobile.UI.Processing;
using Newtone.Mobile.UI.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ArtistModel = Newtone.Mobile.UI.Models.ArtistModel;

namespace Newtone.Mobile.UI.ViewModels
{
    public class ArtistListViewModel : PropertyChangedBase
    {
        #region Fields
        private bool isRefreshing;
        #endregion
        #region Properties
        public ObservableCollection<ArtistModel> Items { get; set; }
        public ObservableCollection<NListViewItem> ListItems { get; set; }
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            { isRefreshing = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        private ICommand refresh;

        public ICommand Refresh
        {
            get
            {
                if (refresh == null)
                    refresh = new ActionCommand(parameter =>
                    {
                        IsRefreshing = true;
                        List<string> beforeSort = new List<string>();
                        string unknown = null;

                        GlobalData.Current.Artists.Keys.ForEach<string>(artist =>
                        {
                            if (artist == Localization.UnknownArtist)
                                unknown = artist;
                            else
                                beforeSort.Add(artist);
                        });

                        List<string> afterSort = beforeSort.OrderBy(o => o).ToList();

                        if (unknown != null)
                            afterSort.Add(unknown);

                        Items.Clear();
                        afterSort.ForEach<string>(artistName =>
                        {
                            ImageSource image = ImageSource.FromFile("EmptyTrack.png");
                            foreach (string filePath in GlobalData.Current.Artists[artistName])
                            {
                                var source = GlobalData.Current.Audios[filePath];
                                if (source.Image != null)
                                {
                                    image = ImageProcessing.FromArray(source.Image);
                                    break;
                                }
                            }

                            Items.Add(new ArtistModel() { Image = image, Name = artistName, TrackCount = GlobalData.Current.Artists[artistName].Count });
                        });
                        IsRefreshing = false;
                    });

                return refresh;
            }
        }
        #endregion
        #region Constructors
        public ArtistListViewModel()
        {
            List<string> beforeSort = new List<string>();
            string unknown = null;

            GlobalData.Current.Artists.Keys.ForEach<string>(artist =>
            {
                if (artist == Localization.UnknownArtist)
                    unknown = artist;
                else
                    beforeSort.Add(artist);
            });

            List<string> afterSort = beforeSort.OrderBy(o => o).ToList();

            if (unknown != null)
                afterSort.Add(unknown);

            Items = new ObservableCollection<ArtistModel>(afterSort.Select(artistName =>
            {
                ImageSource image = ImageSource.FromFile("EmptyTrack.png");
                foreach (string filePath in GlobalData.Current.Artists[artistName].ToList())
                {
                    var source = GlobalData.Current.Audios[filePath];
                    if (source.Image != null)
                    {
                        image = ImageProcessing.FromArray(source.Image);
                        break;
                    }
                }

                return new ArtistModel() { Image = image, Name = artistName, TrackCount = GlobalData.Current.Artists[artistName].Count };
            }));
        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            if(Items.Count != GlobalData.Current.Artists.Count)
            {
                List<string> beforeSort = new List<string>();
                string unknown = null;

                GlobalData.Current.Artists.Keys.ForEach<string>(artist =>
                {
                    if (artist == Localization.UnknownArtist)
                        unknown = artist;
                    else
                        beforeSort.Add(artist);
                });

                List<string> afterSort = beforeSort.OrderBy(o => o).ToList();

                if (unknown != null)
                    afterSort.Add(unknown);

                Items.Clear();
                afterSort.ForEach<string>(artistName =>
                {
                    ImageSource image = ImageSource.FromFile("EmptyTrack.png");
                    foreach (string filePath in GlobalData.Current.Artists[artistName])
                    {
                        var source = GlobalData.Current.Audios[filePath];
                        if (source.Image != null)
                        {
                            image = ImageProcessing.FromArray(source.Image);
                            break;
                        }
                    }

                    Items.Add(new ArtistModel() { Image = image, Name = artistName, TrackCount = GlobalData.Current.Artists[artistName].Count });
                });
            }
        }

        public async Task Artist_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if(index >= 0 && index < Items.Count)
            {
                await Global.NavigationInstance.PushModalAsync(new ModalPage(new CurrentTracksPage(GlobalData.Current.Artists[Items[index].Name], ""), Items[index].Name));
                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }
        #endregion
    }
}
