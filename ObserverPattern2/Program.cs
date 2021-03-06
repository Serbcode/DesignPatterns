﻿using System;

namespace ObserverPattern2
{

    public class CurrencyUnknownException : Exception
    {
        internal CurrencyUnknownException() { }
    }

    class Program
    {        
        public static EuroCurrency[] Week = new EuroCurrency[]
            {
                new EuroCurrency(92.29m, Convert.ToDateTime("22.04.2021")),
                new EuroCurrency(92.04m, Convert.ToDateTime("23.04.2021")),
                new EuroCurrency(90.46m, Convert.ToDateTime("24.04.2021")),
                new EuroCurrency(90.44m, Convert.ToDateTime("27.04.2021")),
                null,
                new EuroCurrency(90.46m, Convert.ToDateTime("28.04.2021")),
                new EuroCurrency(90.42m, Convert.ToDateTime("29.04.2021")),
                new EuroCurrency(90.15m, Convert.ToDateTime("30.04.2021")),
            };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // provider
            EuroCurrencyStock stock = new EuroCurrencyStock();

            // subscribers
            EuroObserver observer1 = new EuroObserver();

            stock.Subscribe(observer1);

            foreach (var currency in Week)
            {
                System.Threading.Thread.Sleep(1500);


                if (currency == null)
                    observer1.OnError(new CurrencyUnknownException());
                else
                    observer1.OnNext(currency);
            }
            observer1.OnCompleted();
        }
    }
}
