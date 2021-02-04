using System;

namespace FactoryMethodPattern4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 'p' to open PNG document, or 't' to open Text document");
            char key = Console.ReadKey().KeyChar;

            Application app = key switch
            {
                'p' => new PngApplication(),
                't' => new TextApplication(),
                _ => throw new NotImplementedException()
            };

            Document doc = app.CreateDocument();
            doc.Open();
        }
    }
}
