using System;

namespace NSEC.Music_Player.Logic
{
    public interface IAsyncEndListener
    {
        event EventHandler AsyncEnded;

        void AsyncEnd();
    }
}