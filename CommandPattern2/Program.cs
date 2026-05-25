using System;

namespace CommandPattern2
{
    abstract class Command
    {
        protected readonly Receiver receiver;

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }

    public class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Receiver");
        }
    }

    class Invoker
    {
        private Command command;

        public void StoreCommand(Command command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // покупатель в макдональдс
            Invoker invoker = new Invoker();

            // заказ в макдональдсе
            var receiver = new Receiver();

            // создание конкретной операции над заказом (например добавление кофе)
            Command command = new ConcreteCommand(receiver);

            // пользователь добавляет (регистрирует) эту команду
            invoker.StoreCommand(command);

            // выполняет команду
            invoker.ExecuteCommand();
        }
    }

}

