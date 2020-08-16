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
using Newtone.Mobile.Logic;
using Newtone.Mobile.Media;
using Newtone.Mobile.Processing;
using Newtone.Mobile.Views;
using Xamarin.Forms;

namespace Newtone.Mobile.ViewModels.ViewCells
{
    public class ArtistGridItemViewModel : PropertyChangedBase
    {
        #region Fields
        private string artistName;
        private string tracksText;
        private ImageSource image;
        #endregion
        #region Properties
        private Xamarin.Forms.View View { get; set; }
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
                        ContextMenuBuilder.BuildForArtist(View, ArtistName);
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
        public ArtistGridItemViewModel(string artistName, Xamarin.Forms.View view)
        {
            View = view;
            ArtistName = artistName;
            TracksText = Localization.Tracks + ": " + GlobalData.Artists[artistName].Count;
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