using System;

namespace CoR1
{
    internal class SquirrelHandler : BaseHandler
    {
        public override object Handle(object request)
        {
            if ((request as string).ToLower() == "nut")
                return $"I will eat this {request}" + Environment.NewLine;
            else return base.Handle(request);
        }
    }
}
