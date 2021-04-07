using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern3.Commands
{
    class NotFoundCommand : Command
    {
        public NotFoundCommand(string name) : base(name) { }

        public override string Execute()
        {
            return "Command not found.";
        }

        public override string ToString()
        {
            return base.Name;
        }
    }
}
