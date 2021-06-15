using System;

namespace StatePattern2
{
    public interface FanState
    {
        void Pull(CeilingFan fan);
    }

    public class Off : FanState
    {
        public void Pull(CeilingFan fan)
        {
            fan.SetState(new Low());
            Console.WriteLine("Fan is working at [Low] speed...");
        }
    }

    public class Low : FanState
    {
        public void Pull(CeilingFan fan)
        {
            fan.SetState(new Medium());
            Console.WriteLine("Fan is working at [Medium] speed...");
        }
    }

    public class Medium : FanState
    {
        public void Pull(CeilingFan fan)
        {
            fan.SetState(new High());
            Console.WriteLine("Fan is working at [High] speed...");
        }
    }

    public class High : FanState
    {
        public void Pull(CeilingFan fan)
        {
            fan.SetState(new Off());
            Console.WriteLine("Fan is turning [OFF]...");
        }
    }

    public class CeilingFan
    {
        private FanState CurrentState;

        public void PullChain()
        {
            CurrentState.Pull(this);
        }

        public CeilingFan()
        {
            CurrentState = new Off();
        }

        public void SetState(FanState s)
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
