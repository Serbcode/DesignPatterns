using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern3.Commands
{
    class StatusCommand : Command
    {
        public StatusCommand(string name, BashSession session) : base(name, session) 
        { }

        public override string Execute()
        {
            return session.Terminal.GetQueue();
        }
    }
}
