using System;
using System.Collections.Generic;
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
using Newtone.Core.Media;
using Newtone.Core.Models;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Processing;
using NSEC.Music_Player.Views;
using Xamarin.Forms;

namespace NSEC.Music_Player.ViewModels.ViewCells
{
    public class ArtistGridItemViewModel : PropertyChangedBase
    {
        #region Fields
        private string artistName;
        private string tracksText;
        private ImageSource image;
        #endregion
        #region Properties
        public string ArtistName
        {
            get => artistName;
            set
            {
                artistName = value;
                OnPropertyChanged();
            }
        }

        public string TracksText
        {
            get => tracksText;
            set
            {
                tracksText = value;
                OnPropertyChanged();
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
        #endregion

        #region Commands
        private ICommand longPressedCommand;
        public ICommand LongPressedCommand
        {
            get
            {
                if (longPressedCommand == null)
                    longPressedCommand = new ActionCommand(parameter =>
                    {
                        if (GlobalData.Artists[ArtistName].Count > 0)
                        {
                            GlobalData.CurrentPlaylist.Clear();

                            foreach (var item in GlobalData.Artists[ArtistName])
                            {
                                GlobalData.CurrentPlaylist.Add(GlobalData.Audios[item]);
                            }

                            GlobalData.PlaylistPosition = 0;
                            GlobalData.MediaPlayer.Load(GlobalData.CurrentPlaylist[0].FilePath);
                            GlobalData.MediaSource = GlobalData.CurrentPlaylist[0];
                            MediaPlayerHelper.Play();
                        }
                    });

                return longPressedCommand;
            }
        }

        private ICommand pressedCommand;
        public ICommand PressedCommand
        {
            get
            {
                if (pressedCommand == null)
                    pressedCommand = new ActionCommand(async (parameter) =>
                    {
                        await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new CurrentTracksPage(GlobalData.Artists[ArtistName], ""), ArtistName));
                    });
                return pressedCommand;
            }
        }
        #endregion
        #region Constructors
        public ArtistGridItemViewModel(string artistName)
        {
            ArtistName = artistName;
            TracksText = Localization.TrackCount + ": " + GlobalData.Artists[artistName].Count;
            Image = ImageSource.FromFile("EmptyTrack.png");

            foreach (string filePath in GlobalData.Artists[artistName])
            {
                var source = GlobalData.Audios[filePath];
                if (source.Image != null)
                {
                    Image = ImageProcessing.FromArray(source.Image);
                    break;
                }
            }
        }
        #endregion
    }
}