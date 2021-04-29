using System;

namespace ObserverPattern2
{
    class Program
    {
        public static EuroCurrency[] Week = new EuroCurrency[]
            {
                new EuroCurrency(92.29m, Convert.ToDateTime("22.04.2021")),
                new EuroCurrency(92.04m, Convert.ToDateTime("23.04.2021")),
                new EuroCurrency(90.46m, Convert.ToDateTime("24.04.2021")),
                new EuroCurrency(90.44m, Convert.ToDateTime("27.04.2021")),
                new EuroCurrency(90.46m, Convert.ToDateTime("28.04.2021")),
                new EuroCurrency(90.42m, Convert.ToDateTime("29.04.2021")),
                new EuroCurrency(90.15m, Convert.ToDateTime("30.04.2021")),
                null // end of data to unsubscribe
            };

        static void Main(string[] args)
        {

            EuroCurrencyStock stock = new EuroCurrencyStock();
            EuroObserver observer1 = new EuroObserver();
            
            stock.Subscribe(observer1);

            bool start = true;

            foreach (var currency in Week)
            {
                System.Threading.Thread.Sleep(2500);

                if (currency != null)
                {
                    Temperature tempData = new Temperature(temp.Value, DateTime.Now);
                    foreach (var observer in observers)
                        observer.OnNext(tempData);
                    previous = temp;
                    if (start) start = false;

                }
                else
                {
                    foreach (var observer in stock.ToArray())
                        if (observer != null) observer.OnCompleted();

                    observers.Clear();
                    break;
                }
            }
        }
    }
}
