using System;

namespace ProxyPattern1
{
    interface ISubject
    {
        void Request();
    }

    internal class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }

    internal class Proxy : ISubject
    {
        private readonly RealSubject realSubject;

        public Proxy(RealSubject realSubject)
        {
            this.realSubject = realSubject;
        }

        // Наиболее распространёнными областями применения паттерна Заместитель
        // являются ленивая загрузка, кэширование, контроль доступа, ведение
        // журнала и т.д. Заместитель может выполнить одну из этих задач, а
        // затем, в зависимости от результата, передать выполнение одноимённому
        // методу в связанном объекте класса Реального Субъект.
        public void Request()
        {
            if (this.CheckAccess())
            {
                realSubject.Request();
                this.LogAccess();
            }
        }

        private void LogAccess()
        {
            Console.WriteLine("I am logging client request (proxy)");
        }

        private bool CheckAccess()
        {
            Console.WriteLine("I am checking access before call original method Request() (proxy)");
            return true;
        }
    }

    internal static class Client
    {
        public static void ClientCode(ISubject subject)
        {
            subject.Request();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client: Executing the client code with a real subject:");
            RealSubject realSubject = new RealSubject();
            Client.ClientCode(realSubject);

            Console.WriteLine();

            Console.WriteLine("Client: Executing the same client code with a proxy:");

            // usually: Lasy loading, cash, check access, logging...
            Proxy proxy = new Proxy(realSubject);

            Client.ClientCode(proxy);
        }
    }
}
