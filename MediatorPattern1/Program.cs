using System;

namespace MediatorPattern1
{

    /// <summary>
    /// Интерфейс Посредника предоставляет метод, используемый компонентами для
    /// уведомления посредника о различных событиях. Посредник может реагировать
    /// на эти события  и передавать исполнение другим компонентам.
    /// </summary>
    public interface IMediator
    { 
        public void Notify(object sender, string ev);
    }

    public class ConcreteMediator : IMediator
    {
        public Component[] Components { get; }

        public ConcreteMediator(params Component[] components)
        {
            Components = components;
        }

        public void Notify(object sender, string ev)
        {
            foreach (var co in Components)
            {
                if (co != sender)
                    co.Notify(sender, ev);
            }
        }
    }

    // RabbidMQ https://www.programmingwithwolfgang.com/rabbitmq-in-an-asp-net-core-3-1-microservice
    // Microservices https://www.programmingwithwolfgang.com/microservice-series-from-zero-to-hero

    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Component1();
            var c2 = new Component2();
            var mediator = new ConcreteMediator(c1, c2);
            c1.SetMediator(mediator);
            c2.SetMediator(mediator);

            c1.DoA();
            Console.WriteLine("");
            c2.DoD();

            c1.SendMessage("Hallo from C1");

        }
    }
}
