using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Newtone.Desktop.Logic
{
    public interface IWindowContent
    {
        void ChangeMaximizeIcon(ImageSource newSource);
    }
}
