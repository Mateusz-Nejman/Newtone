using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Newtone.Core.Sync
{
    public static class SyncHelper
    {
        public static IPAddress IpAddress
        {
            get
            {
                return Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            }
        }
    }
}
