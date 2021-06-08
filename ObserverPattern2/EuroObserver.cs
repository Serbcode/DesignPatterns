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
                Console.WriteLine($"Euro change: {value.Price - lastValue.Price}₽ in {value.Date - lastValue.Date}. Price is: {value.Price}₽");
                lastValue = value;
            }
        }
    }
}
