using System;

namespace CommandPattern3.Commands
{
    public class RmCommand : Command
    {
        public RmCommand(string name) : base(name) { }

        public override string Execute()
        {
            return ("Remove command executed");
        }
    }
}