using System;

namespace NSEC.Music_Player.Services
{
    public interface IAsyncEndListener
    {
        event EventHandler AsyncEnded;

        void AsyncEnd();
    }
}
