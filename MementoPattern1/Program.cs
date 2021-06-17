using System;

namespace MementoPattern1
{
    public class Originator
    {
        public EventHandler<StateChangedEventArgs> StateChanged;

        private string _state;
        public Originator(string state)
        {
            _state = state;
            StateChanged?.Invoke(this, new StateChangedEventArgs() { State = state, Date = DateTime.Now });            
        }
    }

    public delegate void Write(string msg);

    class Program
    {
        // create delegate using lambda expression
        static Write write = (string s) => Console.WriteLine(s);

        static void Main(string[] args)
        {
            Originator originator = new Originator("default state");
            originator.StateChanged += Originator_StateChanged;
        }

        private static void Originator_StateChanged(object sender, StateChangedEventArgs e)
        {
            write("Originator's state has been changed: " + e.State + " at " + e.Date.ToString("HH:mm"));
        }
    }

    public class StateChangedEventArgs : EventArgs
    {
        public string State { get; set; }
        public DateTime Date { get; set; }
    }

}
