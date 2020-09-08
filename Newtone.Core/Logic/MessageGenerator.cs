namespace Newtone.Core.Logic
{
    public class MessageGenerator
    {
        #region Properties
        public ICoreMessage Core { get; private set; }
        #endregion
        #region Constructor
        public MessageGenerator(ICoreMessage core)
        {
            Core = core;
        }
        #endregion
        #region Public Methods
        public void Show(EMessageType type, string message)
        {
            if (type == EMessageType.Snackbar)
                Core?.ShowSnackbar(message);
            else if (type == EMessageType.Message)
                Core?.ShowMessage(message);
            else
                Core?.ShowError(message);
        }
        #endregion
        #region Enums
        public enum EMessageType
        {
            Snackbar,
            Message,
            Error
        }
        #endregion
    }
}
