using System;

namespace StatePattern2
{
    public interface IFanState
    {
        void Pull(CeilingFan fan);
    }

    public class Off : IFanState
    {
        public void Pull(CeilingFan fan)
        {
            fan.SetState(new Low());
            Console.WriteLine("Fan is working at [Low] speed...");
        }
    }

    public class Low : IFanState
    {
        public void Pull(CeilingFan fan)
        {
            fan.SetState(new Medium());
            Console.WriteLine("Fan is working at [Medium] speed...");
        }
    }

    public class Medium : IFanState
    {
        public void Pull(CeilingFan fan)
        {
            fan.SetState(new High());
            Console.WriteLine("Fan is working at [High] speed...");
        }
    }

    public class High : IFanState
    {
        public void Pull(CeilingFan fan)
        {
            fan.SetState(new Off());
            Console.WriteLine("Fan is turning [OFF]...");
        }
    }

    public class CeilingFan
    {
        private IFanState CurrentState;

        public void PullChain()
        {
            CurrentState.Pull(this);
        }

        public CeilingFan()
        {
            CurrentState = new Off();
        }

        public void SetState(IFanState s)
        {
            CurrentState = s;
        }        
    }

    class Program
    {
        static void Main(string[] args)
        {
            CeilingFan fan = new CeilingFan();
            while (true)
            {
                Console.WriteLine("Press key");
                Console.ReadKey();
                Console.WriteLine("");
                fan.PullChain();
            }
        }
    }
}
