using System;

namespace CommandPattern3.Commands
{
    public class RedoCommand : Command
    {
        public RedoCommand(string name) : base(name)
        {
        }

        public override string Execute()
        {
            return "Redo command executed.";
        }
    }
}