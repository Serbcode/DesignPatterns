using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodPattern4
{
    public abstract class Document
    {
        public abstract void Open();
    }

    public class TextDocument : Document
    {
        public override void Open()
        {
            Console.WriteLine("Open as text document...");
        }
    }

    public class PngDocument : Document
    {
        public override void Open()
        {
            Console.WriteLine("Open as Png image...");
        }
    }

}
