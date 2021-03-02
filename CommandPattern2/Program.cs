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
            var reciever = new Receiver();

            // создание конкретной операции над заказом (например добавление кофе)
            Command command = new ConcreteCommand(reciever);
                        
            // пользователь добавляет (регистрирует) эту комманду
            invoker.StoreCommand(command);

            // выполняет комманду
            invoker.ExecuteCommand();
        }
    }

}

