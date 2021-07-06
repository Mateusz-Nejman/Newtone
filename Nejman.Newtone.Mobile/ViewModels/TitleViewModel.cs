using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Data;
using Nejman.Newtone.Mobile.Implementations;
using Nejman.Newtone.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.ViewModels
{
    public class TitleViewModel : PropertyChangedBase
    {
        private IDisposable timer;
        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged();
            }
        }

        private int downloadsCount;
        public int DownloadsCount
        {
            get => downloadsCount;
            set
            {
                downloadsCount = value;
                OnPropertyChanged();
            }
        }

        private bool isBadgeVisible;
        public bool IsBadgeVisible
        {
            get => isBadgeVisible;
            set
            {
                isBadgeVisible = value;
                OnPropertyChanged();
            }
        }
        private ICommand speechCommand;
        public ICommand SpeechCommand
        {
            get
            {
                if(speechCommand == null)
                {
                    speechCommand = new ActionCommand(param => SpeechImplementation.Current.StartSpeech());
                }

                return speechCommand;
            }
        }
        private ICommand downloadCommand;
        public ICommand DownloadCommand
        {
            get
            {
                if(downloadCommand == null)
                {
                    downloadCommand = new ActionCommand(param =>
                    {
                        ShellHelpers.GoTo($"{nameof(DownloadsPage)}");
                    });
                }

                return downloadCommand;
            }
        }

        public void Search()
        {
            ShellHelpers.GoTo($"{nameof(SearchPage)}?{nameof(SearchViewModel.SearchQueryBase)}={HttpUtility.UrlEncode(SearchText)}");
        }

        public void Appearing()
        {
            timer = Observable.Interval(TimeSpan.FromMilliseconds(250)).Subscribe(x => Tick());
        }

        public void Disappearing()
        {
            timer?.Dispose();
            timer = null;
        }

        private void Tick()
        {
            DownloadsCount = DownloadAction.GetBadgeCount();

            IsBadgeVisible = DownloadsCount > 0;
        }
    }
}
