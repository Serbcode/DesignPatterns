using System;

namespace AdapterPattern1
{
    public interface ITarget
    {
        string GetRequest();
    }

    public class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request";
        }
    }

    public class Adapter : ITarget
    {
        private readonly Adaptee adaptee;

        // aggregation
        public Adapter(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is {this.adaptee.GetSpecificRequest()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // existing (old) class - has to be adapted
            Adaptee adaptee = new Adaptee();

            // ITarget is interface of user code we do not want to change.
            ITarget target = new Adapter(adaptee);

            // user code
            Console.WriteLine(target.GetRequest());            
        }
    }
}
