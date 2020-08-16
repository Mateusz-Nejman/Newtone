using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Logic
{
    public interface ICoreMessage
    {
        public void ShowSnackbar(string message);
        public void ShowMessage(string message);
        public void ShowError(string message);
    }
}
