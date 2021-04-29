using System;

namespace ObserverPattern2
{
    public class EuroCurrency
    {
        public EuroCurrency(decimal Price, DateTime Date)
        {
            this.Price = Price;
            this.Date = Date;
        }

        public decimal Price { get; }
        public DateTime Date { get; }
    }
}
