using Newtone.Core;
using Newtone.Core.Models;
using Newtone.Core.Languages;
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
    public partial class SearchPage : ContentView
    {
        private ObservableCollection<HistoryModel> Items { get; set; }
        public SearchPage()
        {
            InitializeComponent();

            historyList.ItemsSource = Items = new ObservableCollection<HistoryModel>();

            foreach(var item in GlobalData.History)
            {
                Items.Add(item);
            }
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            clearLabel.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Items.Clear();
            GlobalData.History.Clear();
            GlobalData.SaveConfig();
        }

        private void SearchEntry_Completed(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(searchEntry.Text))
            {
                if(MainActivity.IsInternet())
                    NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new SearchResultPage(searchEntry.Text), searchEntry.Text));
                else
                    NormalPage.Instance.DisplayAlert(Localization.Warning, "Nie masz neta typie", "OK");
            }
        }

        private void HistoryList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if(index >= 0 && index < Items.Count)
            {
                if (MainActivity.IsInternet())
                    NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new SearchResultPage(Items[index].Text), Items[index].Text));
                else
                    NormalPage.Instance.DisplayAlert(Localization.Warning, "Nie masz neta typie", "OK");
                
                historyList.SelectedItem = null;
            }
        }
    }
}