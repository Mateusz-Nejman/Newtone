using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Media
{
    public class MediaOutput
    {
        public byte[] Data { get; set; }
        public MediaOutputType OutputType { get; set; }

        public MediaOutput(byte[] data, MediaOutputType outputType)
        {
            Data = data;
            OutputType = outputType;
        }
    }
}
