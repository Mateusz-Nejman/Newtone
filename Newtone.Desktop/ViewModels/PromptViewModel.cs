using Newtone.Core.Logic;
using Newtone.Core.Models;
using System.Windows;
using System.Windows.Input;

namespace Newtone.Desktop.ViewModels
{
    public class PromptViewModel:PropertyChangedBase
    {
        #region Fields
        private string title;
        private string yesText;
        private string noText;
        private string boxValue;
        #endregion
        #region Properties
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public string YesText
        {
            get => yesText;
            set
            {
                yesText = value;
                OnPropertyChanged();
            }
        }
        public string NoText
        {
            get => noText;
            set
            {
                noText = value;
                OnPropertyChanged();
            }
        }
        public string Value
        {
            get => boxValue;
            set
            {
                boxValue = value;
                OnPropertyChanged();
            }
        }
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
                        var window = parameter as Window;
                        window.DialogResult = true;
                        window.Close();
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
                        var window = parameter as Window;
                        window.DialogResult = false;
                        window.Close();
                    });
                return noCommand;
            }
        }
        #endregion
        #region Constructors
        public PromptViewModel(string title, string yes, string no, string initValue = "")
        {
            Title = title;
            YesText = yes;
            NoText = no;
            Value = initValue;
        }
        #endregion
    }
}
