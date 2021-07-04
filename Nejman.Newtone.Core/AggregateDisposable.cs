using System;

namespace Nejman.Newtone.Core
{
    public class AggregateDisposable : IDisposable
    {
        private readonly IDisposable[] disposables;

        public AggregateDisposable(params IDisposable[] disposables)
        {
            this.disposables = disposables;
        }
        public void Dispose()
        {
            foreach(var disposable in disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
