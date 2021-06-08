using System;
using System.Collections.Generic;

namespace ObserverPattern2
{
    public class EuroCurrencyStock : IObservable<EuroCurrency>
    {
        private readonly List<IObserver<EuroCurrency>> observers;

        public EuroCurrencyStock()
        {
            observers = new List<IObserver<EuroCurrency>>();
        }

        public IDisposable Subscribe(IObserver<EuroCurrency> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new Unsubscriber(observers, observer);
            /* method should return IDisposable, but observer cannot delete himself :(( MS is hot */
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<EuroCurrency>> _observers;
            private IObserver<EuroCurrency> _observer;

            public Unsubscriber(List<IObserver<EuroCurrency>> observers, IObserver<EuroCurrency> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }
    }
}
