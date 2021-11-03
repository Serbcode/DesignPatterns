namespace VisitorPattern1
{
    /// <summary>
    /// Base interface for all shapes
    /// </summary>
    public interface IShape
    {
        void Move(int x, int y);
        void Draw();
        void Accept(IVisitor v);
    }

    /*
    public abstract class Shape
    {
        protected virtual void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    */
}
