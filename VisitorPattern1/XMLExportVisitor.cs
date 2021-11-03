using System;

namespace VisitorPattern1
{
    public class XMLExportVisitor : IVisitor
    {
        public void Visit(Dot dot)
        {
            Console.WriteLine("Dot exported to XML");
        }

        public void Visit(Circle circle)
        {
            Console.WriteLine("Circle exported to XML");
        }

        public void Visit(Rectangle rectangle)
        {
            Console.WriteLine("Rectangle exported to XML");
        }

        public void Visit(CompoundShape compoundShape)
        {
            Console.WriteLine("CompoundShape exported to XML");
        }
    }
}
