using System;
using System.Collections.Generic;
using System.Threading;

namespace ObserverPattern1
{

    // Observer - Наблюдатель (Подписчик)
    // Publisher - Издатель (на кого подписываются)

    /*
     Также известен как: Издатель-Подписчик, Слушатель, Observer
    */

    /*
    Когда после изменения состояния одного объекта требуется что-то сделать в других, 
    но вы не знаете наперёд, какие именно объекты должны отреагировать.     */

    /// <summary>
    /// Подписчик
    /// </summary>
    public class Observer 
    {
        // этот метод будет вызываться Издателем
        public void Update(int State)
        {
            Console.WriteLine($"I've got notification that Publisher state was changed: {State}");
        }
    }

    /// <summary>
    /// Издатель, ведет журнал подписчиков (удаляет, добавляет) 
    /// и уведомляет их при изменении своего состояния  
    /// </summary>
    public class Publisher
    {
        public int State { get; set; } = 0;

        private List<Observer> observers = new List<Observer>();

        public void AddObserver(Observer observer)
        {
            this.observers.Add(observer);
        }

        public bool RemoveObserver(Observer observer)
        {
            return this.observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(State);
            }
        }

        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state has just changed to: " + this.State);
            this.Notify();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            Observer observer1 = new Observer();
            Observer observer2 = new Observer();

            publisher.AddObserver(observer1);
            publisher.AddObserver(observer2);

            publisher.SomeBusinessLogic();
            publisher.SomeBusinessLogic();
            publisher.SomeBusinessLogic();

            publisher.RemoveObserver(observer1);

            publisher.SomeBusinessLogic();
        }
    }
}
