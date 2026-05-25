using System;

namespace PrototypePattern
{
    class Program
    {
        /*        
         * Прототип — это порождающий паттерн проектирования, который позволяет копировать ОБЪЕКТЫ, 
         * не вдаваясь в подробности их реализации.
         * Паттерн Прототип поручает создание копий самим копируемым объектам.
         * Note: Клонирование объектов может быть поверхностным (shallow copy) или глубоким (deep copy).
         * Поверхностное копирование (shallow copy) создает новый объект и копирует значения полей из исходного объекта.
         * Если поле является ссылкой на другой объект, то копируется только ссылка, а не сам объект. 
         * Это может привести к тому, что изменения в одном объекте повлияют на другой, если они ссылаются 
         * на один и тот же объект.
         * Глубокое копирование (deep copy) создает новый объект и рекурсивно копирует все объекты, 
         * на которые ссылаются поля исходного объекта. Это гарантирует, что изменения в одном объекте 
         * не повлияют на другой, так как они будут ссылаться на разные объекты.
         * Используй C# records для реализации паттерна Прототип, так как они предоставляют встроенную 
         * поддержку для создания копий объектов.
         */

        static void Main(string[] args)
        {
            PhoneSketch phone10 = new PhoneSketch("Phone 10", "Ram 4", new OperationSystem("Android", 10));
            Console.WriteLine(phone10);

            var phone11 = phone10.CloneIt() as PhoneSketch;
            // phone11.OS.Version = 11;
            Console.WriteLine(phone11);

            Console.WriteLine(" is original changed?");
            Console.WriteLine(phone10);


            // below DeepCopy variant //
            /*
            PhoneSketch newphone = phone11.DeepCopy() as PhoneSketch;
            newphone.OS.Version = 12;
            newphone.Dump();

            // is phone 11 changed?
            phone11.Dump(); // nop!
            */
            Console.ReadKey();
        }
    }
}
