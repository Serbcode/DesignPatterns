using System;

namespace CoR1
{
    internal class MonkeyHandler : BaseHandler
    {
        public override object Handle(object request)
        {
            if ((request as string).ToLower() == "banana")
                return $"I will eat this {request}" + Environment.NewLine;
            else return base.Handle(request);
        }
    }
}
