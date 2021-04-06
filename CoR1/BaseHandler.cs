namespace CoR1
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        object Handle(object request);
    }

    internal abstract class BaseHandler : IHandler
    {
        private IHandler next;

        public IHandler SetNext(IHandler handler)
        {
            next = handler;
            return handler;
        }

        public virtual object Handle(object request)
        {
            if (next == null) return null;

            return next.Handle(request);
        }
    }
}
