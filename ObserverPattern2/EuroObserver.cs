using System;

namespace ObserverPattern2
{
    public class EuroObserver : IObserver<EuroCurrency>
    {
        private bool firstTime = true;
        private EuroCurrency lastValue;

        public void OnCompleted()
        {
            Console.WriteLine("The Euro currency changes will not be transmitted.");
        }

        public void OnError(Exception error)
        {
            // do nothing
        }

        public void OnNext(EuroCurrency value)
        {
            if (firstTime)
            {
                firstTime = false;
                lastValue = value;
            }
            else 
            {                
                Console.WriteLine("\tEuro change: {0}₽ in {1:g}. Price is: {2}₽", value.Price - lastValue.Price,
                    value.Date.ToUniversalTime() - lastValue.Date.ToUniversalTime(), value);
                lastValue = value;
            }
        }
    }
}
