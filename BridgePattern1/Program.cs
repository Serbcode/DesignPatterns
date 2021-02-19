using System;

namespace BridgePattern1
{

    // implementer interface.
    public interface DrawAPI
    {
        public void DrawCircle(int radius, int x, int y);
    }

    // concrete bridge implementer classes
    public class RedCircle : DrawAPI
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine($"Drawing Circle: Color RED, radius: {radius}, x:{x}, y:{y}");
        }
    }

    //concrete bridge implementer classes
    public class GreenCircle : DrawAPI
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine($"Drawing Circle: Color GREEN, radius: {radius}, x:{x}, y:{y}");
        }
    }

    // abstract class Shape using the DrawAPI interface
    public abstract class Shape
    {
        protected readonly DrawAPI drawAPI;
        public Shape(DrawAPI drawAPI)
        {
            this.drawAPI = drawAPI;
        }

        public abstract void Draw();
    }

    // concrete class implementing the Shape interface
    public class Circle : Shape
    {
        private int x;
        private int y;
        private int radius;

        public Circle(int x, int y, int radius, DrawAPI drawAPI) : base(drawAPI)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public override void Draw()
        {
            drawAPI.DrawCircle(radius, x, y);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Shape redCircle = new Circle(100, 100, 10, new RedCircle());
            Shape greenCircle = new Circle(100, 100, 10, new GreenCircle());

            redCircle.Draw();
            greenCircle.Draw();
        }
    }
}
