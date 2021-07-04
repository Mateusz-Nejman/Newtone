using System;
using System.Windows.Input;

namespace Nejman.Newtone.Core
{
    public class ActionCommand : ICommand
    {
        #region Fields
        private readonly Action<object> action;
        #endregion
        #region Events
        public event EventHandler CanExecuteChanged;
        #endregion
        #region Constructors
        public ActionCommand(Action<object> action)
        {
            this.action = action;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        #region Public Methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action?.Invoke(parameter);
        }
        #endregion
    }
}
