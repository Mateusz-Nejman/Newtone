using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Views.Custom;
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
    public partial class SearchPage : ContentView, IViewPage
    {
        private ObservableCollection<HistoryModel> Items { get; set; }
        private bool stopTimer = false;
        public SearchPage()
        {
            InitializeComponent();
            historyList.ItemsSource = Items = new ObservableCollection<HistoryModel>();

            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            clearLabel.GestureRecognizers.Add(tapGestureRecognizer);
            Device.StartTimer(TimeSpan.FromSeconds(0.5), Refresh);

            Disappearing += SearchPage_Disappearing;
            Appearing += SearchPage_Appearing;
        }

        private void SearchPage_Appearing(object sender, EventArgs e)
        {
            if(stopTimer)
            {
                stopTimer = false;
                Device.StartTimer(TimeSpan.FromSeconds(0.5), Refresh);
            }
        }

        private void SearchPage_Disappearing(object sender, EventArgs e)
        {
            stopTimer = true;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Items.Clear();
            Global.History.Clear();
            Global.SaveConfig();
        }

        public event EventHandler Appearing;
        public event EventHandler Disappearing;

        private bool Refresh()
        {
            Items.Clear();
            List<HistoryModel> list = new List<HistoryModel>(Global.History);
            list.Reverse();
            
            foreach(HistoryModel model in list)
            {
                Items.Add(model);
            }
            return !stopTimer;
        }
        public void InvokeD(object sender)
        {
            Disappearing?.Invoke(sender, null);
        }

        public void InvokeA(object sender)
        {
            Appearing?.Invoke(sender, null);
        }

        public void SetTitleView(CustomTitleView titleView)
        {
            titleView.Title = Localization.Search;
            titleView.IsBackButton = false;
        }

        private void HistoryList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            List<HistoryModel> list = new List<HistoryModel>(Global.History);
            list.Reverse();
            if (e.SelectedItemIndex >= 0 && e.SelectedItem != null)
            {
                Navigation.PushAsync(new SearchResultPage(list[e.SelectedItemIndex].Text));
                historyList.SelectedItem = null;
            }
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            if(searchEntry.Text.Length > 0)
            {
                Global.History.Add(new HistoryModel()
                {
                    Text = searchEntry.Text,
                    Youtube = true
                });
                Global.SaveConfig();
                Navigation.PushAsync(new SearchResultPage(searchEntry.Text));
                
            }
        }
    }
}