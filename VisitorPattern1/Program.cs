using System;

namespace VisitorPattern1
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapes = { new Dot(), new Circle(), new Rectangle(), new CompoundShape() };

            XMLExportVisitor xmlExport = new XMLExportVisitor();

            foreach (IShape shape in shapes)
            {
                shape.Accept(xmlExport);
            }

            Console.WriteLine(shapes[0] is Dot);
            Console.WriteLine(shapes[0] is Circle);
            Console.WriteLine(shapes[0] is IShape);
        }
    }
}

