using NSEC.Music_Player.Loaders;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistPage : ContentPage, IAsyncEndListener, IInvokePage
    {
        private ObservableCollection<ArtistListModel> Items;
        public event EventHandler AsyncEnded;
        public ArtistPage()
        {
            InitializeComponent();
            artistList.ItemsSource = Items = new ObservableCollection<ArtistListModel>();

            Global.AsyncEndController.Add("authorstab", this);
            Appearing += ArtistPage_Appearing;
            AsyncEnded += ArtistPage_AsyncEnded;
        }

        private void ArtistPage_AsyncEnded(object sender, EventArgs e)
        {
            ArtistLoader.Load(ref Items);
        }

        private void ArtistPage_Appearing(object sender, EventArgs e)
        {
            ArtistLoader.Reload(ref Items);
        }

        private void ArtistList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                string artist = Items[e.SelectedItemIndex].Name;
                Navigation.PushAsync(new TrackListPage(Global.Artists[artist]));
                artistList.SelectedItem = null;
            }
        }

        public void AsyncEnd()
        {
            AsyncEnded.Invoke(this, new EventArgs());
        }

        public void PageInvoke()
        {
            ArtistPage_Appearing(null, null);
        }
    }
}