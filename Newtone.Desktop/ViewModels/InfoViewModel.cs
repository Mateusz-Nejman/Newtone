using Newtone.Core.Logic;
using Newtone.Core.Models;
using System.Windows;
using System.Windows.Input;

namespace Newtone.Desktop.ViewModels
{
    public class InfoViewModel : PropertyChangedBase
    {
        #region Fields
        private string title;
        private string text;
        private string buttonText;
        #endregion
        #region Properties
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(() => Title);
            }
        }
        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(() => Text);
            }
        }
        public string ButtonText
        {
            get => buttonText;
            set
            {
                buttonText = value;
                OnPropertyChanged(() => ButtonText);
            }
        }
        private Window Window { get; set; }
        #endregion
        #region Commands
        private ICommand command;
        public ICommand Command
        {
            get
            {
                if (command == null)
                    command = new ActionCommand(parameter =>
                    {
                        Window.DialogResult = true;
                        Window.Close();
                    });

                return command;
            }
        }
        #endregion
        #region Constructors
        public InfoViewModel(Window window, string title, string message, string confirm)
        {
            Window = window;
            ButtonText = confirm;
            Title = title;
            Text = message;
        }
        #endregion
    }
}
