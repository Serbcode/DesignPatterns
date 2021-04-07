using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern3.Commands
{
    /// <summary>
    /// Shows commands stack in the terminal.
    /// </summary>
    class StatusCommand : Command
    {
        public StatusCommand(string name, Session session) : base(name, session) 
        { }

        public override string Execute()
        {
            return session.Terminal.GetCommands();
        }
    }
}
