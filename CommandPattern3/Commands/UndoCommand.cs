using System;

namespace CommandPattern3.Commands
{
    public class UndoCommand : Command
    {
        public UndoCommand(string name, BashSession session) : base(name, session) { }

        public override string Execute()
        {
            session.Terminal.GetCommand();
            return ("Undo command executed.");
        }
    }
}