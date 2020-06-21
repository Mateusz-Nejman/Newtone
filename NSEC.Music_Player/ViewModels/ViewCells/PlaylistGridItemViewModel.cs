﻿using System;
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
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Processing;
using NSEC.Music_Player.Views;
using Xamarin.Forms;

namespace NSEC.Music_Player.ViewModels.ViewCells
{
    public class PlaylistGridItemViewModel : PropertyChangedBase
    {
        #region Fields
        private string playlistName;
        private string tracksText;
        private ImageSource image;
        #endregion
        #region Properties
        private Xamarin.Forms.View View { get; set; }

        public string PlaylistName
        {
            get => playlistName;
            set
            {
                playlistName = value;
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
                        ContextMenuBuilder.BuildForPlaylist(View, PlaylistName);
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
                        await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new CurrentTracksPage(GlobalData.Playlists[PlaylistName], PlaylistName), PlaylistName));
                    });
                return pressedCommand;
            }
        }
        #endregion
        #region Constructors
        public PlaylistGridItemViewModel(string playlistName, Xamarin.Forms.View view)
        {
            View = view;
            PlaylistName = playlistName;
            TracksText = Localization.TrackCount + ": " + GlobalData.Playlists[playlistName].Count;
            Image = ImageSource.FromFile("EmptyTrack.png");

            foreach (string filePath in GlobalData.Playlists[playlistName])
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