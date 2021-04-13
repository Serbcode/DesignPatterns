using System;

namespace MediatorPattern1
{
    /// <summary>
    /// Базовый Компонент обеспечивает базовую функциональность хранения
    /// экземпляра посредника внутри объектов компонентов.
    /// </summary>
    public class Component
    {
        protected IMediator mediator;

        public Component(IMediator mediator = null)
        {
            this.mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void SendMessage(string message)
        {
            mediator.Notify(this, message);
        }

        public virtual void Notify(object sender, string message)
        {
            string who = sender.GetType().Name;
            string iam = this.GetType().Name;
            Console.WriteLine($"{iam} received message: {message} from {who}");
        }
    }
}
