using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
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
    public partial class SyncListPage : ContentView, ITimerContent
    {
        private ObservableCollection<TrackModel> Items { get; set; }
        public SyncListPage()
        {
            InitializeComponent();
            trackListView.ItemsSource = Items = new ObservableCollection<TrackModel>();
        }

        public void Tick()
        {
            if (Items.Count != SyncProcessing.Audios.Count)
            {
                Items.Clear();
                foreach (var item in SyncProcessing.Audios)
                    Items.Add(new TrackModel(GlobalData.Audios[item]));
            }

            foreach (var item in Items)
                item.CheckChanges();
        }
    }
}