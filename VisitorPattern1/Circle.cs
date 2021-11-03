using System;

namespace VisitorPattern1
{
    public class Circle : IShape
    {
        public void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        public void Draw()
        {
            Console.WriteLine("Draw Circle");
        }

        public void Move(int x, int y)
        {
            Console.WriteLine($"Moved to [{x},{y}]");
        }
    }
}
