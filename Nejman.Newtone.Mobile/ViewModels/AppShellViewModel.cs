using Nejman.Newtone.Core;
using System;
using System.Reactive.Linq;

namespace Nejman.Newtone.Mobile.ViewModels
{
    public class AppShellViewModel : PropertyChangedBase
    {
        private bool isPlayButtonVisible = false;

        public bool IsPlayButtonVisible
        {
            get => isPlayButtonVisible;
            set
            {
                if(isPlayButtonVisible != value)
                {
                    isPlayButtonVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public AppShellViewModel()
        {
            _ = Observable.Interval(TimeSpan.FromMilliseconds(250)).Subscribe(x =>
            {
                //IsPlayButtonVisible = CoreGlobal.MediaPlayer.IsPlaying;
            });
        }
    }
}
