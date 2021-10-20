using System;

namespace EventsDelegates
{

    // unsafe
    public class DelegateComponent
    { 
        public EventHandler Rendered { get; set; }
        public void Render()
        {         
            //... some code, then
            Rendered?.Invoke(this, EventArgs.Empty);
        }
    }

    // safe
    public class EventComponent
    {
        public event EventHandler Rendered = delegate { }; // thread safe assigment (always not null)
        public void Render()
        {
            //... some code, then
            Rendered.Invoke(this, EventArgs.Empty);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            DelegateComponent component1 = new DelegateComponent();
            component1.Rendered += (s, e) => Console.WriteLine("component1 rendered!");

            // re-assign delegate with null
            component1.Rendered = delegate { };
            // or like this
            component1.Rendered = (s, e) => { };            

            // shows nothing
            component1.Render();



            // for events, you can only subscribe or unsubscribe +=/-=
            EventComponent component2 = new EventComponent();
            component2.Rendered += OnComponentRendered;

            // ... some Vasya reset handler
            // component2.Rendered = OnComponentRendered2; -> compilation error
            component2.Render();
        }

        private static void OnComponentRendered(object sender, EventArgs e)
        {
            Console.WriteLine("component2 rendered!");
        }

        private static void OnComponentRendered2(object sender, EventArgs e)
        {
            Console.WriteLine("component2 rendered!");
        }
    }
}
