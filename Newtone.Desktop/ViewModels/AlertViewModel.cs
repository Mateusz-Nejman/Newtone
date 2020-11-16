using Newtone.Core.Logic;
using Newtone.Core.Models;
using System.Windows;
using System.Windows.Input;

namespace Newtone.Desktop.ViewModels
{
    public class AlertViewModel : PropertyChangedBase
    {
        #region Fields
        private string title;
        private string text;
        private string yes;
        private string no;
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
        public string Yes
        {
            get => yes;
            set
            {
                yes = value;
                OnPropertyChanged(() => Yes);
            }
        }
        public string No
        {
            get => no;
            set
            {
                no = value;
                OnPropertyChanged(() => No);
            }
        }
        private Window Window { get; set; }
        #endregion
        #region Commands
        private ICommand yesCommand;
        public ICommand YesCommand
        {
            get
            {
                if (yesCommand == null)
                    yesCommand = new ActionCommand(parameter =>
                    {
                        Window.DialogResult = true;
                        Window.Close();
                    });

                return yesCommand;
            }
        }

        private ICommand noCommand;
        public ICommand NoCommand
        {
            get
            {
                if (noCommand == null)
                    noCommand = new ActionCommand(parameter =>
                    {
                        Window.DialogResult = false;
                        Window.Close();
                    });
                return noCommand;
            }
        }
        #endregion
        #region Constructors
        public AlertViewModel(Window window, string title, string message, string confirm, string cancel)
        {
            Window = window;
            Yes = confirm;
            No = cancel;
            Title = title;
            Text = message;
        }
        #endregion
    }
}
