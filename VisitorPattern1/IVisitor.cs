namespace VisitorPattern1
{
    public interface IVisitor
    {
        void Visit(Dot dot);
        void Visit(Circle circle);
        void Visit(Rectangle rectangle);
        void Visit(CompoundShape compoundShape);        
    }
}
