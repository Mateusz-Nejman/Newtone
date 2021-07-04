using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;

namespace Nejman.Newtone.Core
{
    public class MemorySubject<T> : ISubject<T>, IDisposable
    {
        private readonly Subject<T> subject;

        public T LastValue { get; private set; }

        public MemorySubject()
        {
            subject = new Subject<T>();
        }
        public void Dispose()
        {
            subject.Dispose();
        }

        public void OnCompleted()
        {
            subject.OnCompleted();
        }

        public void OnError(Exception error)
        {
            subject.OnError(error);
        }

        public void OnNext(T value)
        {
            LastValue = value;

            if(LastValue is bool val && val)
            {
                val.ToString();
            }
            subject.OnNext(value);
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            return subject.Subscribe(observer);
        }
    }
}
