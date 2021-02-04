using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodPattern4
{
    public abstract class Application
    {
        public abstract Document CreateDocument();
    }

    public class TextApplication : Application
    {
        public override Document CreateDocument()
        {
            return new TextDocument();
        }
    }

    public class PngApplication : Application
    {
        public override Document CreateDocument()
        {
            return new PngDocument();
        }
    }
}
