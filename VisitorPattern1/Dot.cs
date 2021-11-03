using System;

namespace VisitorPattern1
{
    public class Dot : IShape
    {
        public void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        public void Draw()
        {
            Console.WriteLine("Draw Dot");
        }

        public void Move(int x, int y)
        {
            Console.WriteLine($"Dot moved to [{x},{y}]");
        }
    }
}
