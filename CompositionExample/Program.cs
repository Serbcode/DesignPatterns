using System;

namespace CompositionExample
{

    public class Engine { }

    /*
        При этом класс автомобиля полностью управляет жизненным циклом объекта двигателя. 
        При уничтожении объекта автомобиля в области памяти вместе с ним будет уничтожен и объект двигателя. 
        И в этом плане объект автомобиля является главным, а объект двигателя - зависимой.
    */


    // Композиция 

    public class Car
    {
        private readonly Engine engine;

        public Car()
        {
            this.engine = new Engine();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
        }
    }
}
