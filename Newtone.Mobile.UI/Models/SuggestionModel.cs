using Nejman.Xamarin.FocusLibrary;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.Views.TV;
using System.Windows.Input;

namespace Newtone.Mobile.UI.Models
{
    public class SuggestionModel : NListViewItem
    {
        #region Fields
        private string text;
        #endregion
        #region Properties
        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        private ICommand pressedCommand;
        public ICommand PressedCommand
        {
            get
            {
                if (pressedCommand == null)
                    pressedCommand = new ActionCommand(async (parameter) =>
                    {
                        await Global.NavigationInstance.PushModalAsync(new ModalPage(new Views.TV.SearchResultPage(Text), Text));
                    });
                return pressedCommand;
            }
        }
        #endregion
        #region Public Methods
        public override void FocusAction()
        {
            PressedCommand.Execute(null);
        }
        #endregion
    }
}
