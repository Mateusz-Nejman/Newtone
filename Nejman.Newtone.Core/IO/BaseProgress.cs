using System;
using System.Collections.Generic;
using System.Text;

namespace Nejman.Newtone.Core.IO
{
    public class BaseProgress : IProgress<double>
    {
        public event EventHandler<double> ProgressChanged;
        public delegate void OnProgressChanged(double progress);
        public void Report(double value)
        {
            ProgressChanged?.Invoke(this, value);
        }
    }
}
