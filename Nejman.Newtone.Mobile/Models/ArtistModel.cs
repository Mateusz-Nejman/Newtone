using Nejman.Newtone.Core;
using Nejman.Newtone.Mobile.Services;
using Nejman.Newtone.Mobile.ViewModels;
using Nejman.Newtone.Mobile.Views;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.Models
{
    public class ArtistModel
    {
        public string Name { get; }
        public ImageSource Image { get; }

        public ArtistModel(string name, byte[] image)
        {
            Name = name;
            if(image == null || image.Length == 0)
            {
                Image = Global.EmptyTrackImage;
            }
            else
            {
                Image = ImageSource.FromStream(() => new MemoryStream(image));
            }
        }

        #region Commands
        private ICommand menuCommand;
        public ICommand MenuCommand
        {
            get
            {
                if (menuCommand == null)
                    menuCommand = new ActionCommand(parameter =>
                    {
                        ContextMenuBuilder.BuildForArtist((View)parameter, Name);
                    });

                return menuCommand;
            }
        }

        private ICommand pressedCommand;
        public ICommand PressedCommand
        {
            get
            {
                if (pressedCommand == null)
                    pressedCommand = new ActionCommand(parameter =>
                    {
                        ShellHelpers.GoTo($"{nameof(TracksListPage)}?{nameof(TracksListViewModel.ArtistName)}={Name}");
                    });
                return pressedCommand;
            }
        }
        #endregion
    }
}
