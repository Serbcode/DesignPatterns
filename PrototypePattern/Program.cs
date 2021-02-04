using System;

namespace PrototypePattern
{
    class Program
    {
        /*        
         * Прототип — это порождающий паттерн проектирования, который позволяет копировать ОБЪЕКТЫ, не вдаваясь в подробности их реализации.
         * Паттерн Прототип поручает создание копий самим копируемым объектам.
         */

        static void Main(string[] args)
        {
            PhoneSketch phone10 = new PhoneSketch("Phone 10", "Ram 4", new OperationSystem("Android", 10));
            phone10.Dump();

            var phone11 = phone10.Clone() as PhoneSketch;            
            phone11.OS.Version = 11;
            phone11.Dump();

            Console.WriteLine(" is original changed?");            
            phone10.Dump();


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
