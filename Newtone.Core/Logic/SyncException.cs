using System;
using System.Runtime.Serialization;

namespace Newtone.Core.Logic
{
    [Serializable]
    public class SyncException : Exception
    {
        public SyncException() : base("SyncException")
        {

        }

        public SyncException(string message) : base("SyncException: "+message)
        { 
        }

        protected SyncException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
