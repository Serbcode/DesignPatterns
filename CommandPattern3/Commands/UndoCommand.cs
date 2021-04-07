using System;

namespace CommandPattern3.Commands
{
    /// <summary>
    /// remove last executed command from Terminal stack
    /// </summary>
    public class UndoCommand : Command
    {
        public UndoCommand(string name, Session session) : base(name, session) { }

        public override string Execute()
        {
            session.Terminal.PopCommand();
            return ("Undo command executed.");
        }
    }
}