using System;

namespace FactoryMethodPattern
{
    class Program
    {
        /*
            Основной задачей паттерна Factory Method является организация техники делегирования 
            ответственности за создание объектов продуктов одним классом (часто абстрактным) другому классу (производному конкретному классу). 
            Другими словами – абстрактный класс содержащий в себе абстрактный фабричный метод, говорит своему производному конкретному классу: 
            «Конкретный класс, я поручаю твоему разработчику самостоятельно выбрать конкретный класс порождаемого объекта-продукта 
            при реализации моего абстрактного фабричного метода».
         */

        static void Main(string[] args)
        {
            Logistics logic = new TrainLogistics();
            Transport transport = logic.CreateTransport();            
            transport.Deliver();

            logic = new PlainLogistics();
            logic.CreateTransport().Deliver();
        }
    }
}
