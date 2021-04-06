using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern3
{
    public abstract class Command
    {
        protected readonly BashTerminal bashTerminal;

        public Command(BashTerminal bashTerminal)
        {
            this.bashTerminal = bashTerminal;
        }

        public abstract void Excecute();
        public virtual void Cancel() { }
        public abstract string Name();
    }

    public class HistoryCommand : Command
    {
        public HistoryCommand(BashTerminal bashTerminal) : base(bashTerminal)
        {
        }

        public override void Excecute()
        {
            throw new NotImplementedException();
        }

        public override string Name()
        {
            return "History command";
        }
    }

    public class UndoCommand : Command
    {
        public UndoCommand(BashTerminal bashTerminal) : base(bashTerminal)
        {
        }

        public override void Excecute()
        {
            throw new NotImplementedException();
        }

        public override string Name()
        {
            return "Undo command";
        }
    }

    public class RedoCommand : Command
    {
        public RedoCommand(BashTerminal bashTerminal) : base(bashTerminal)
        {

        }

        public override void Excecute()
        {
            throw new NotImplementedException();
        }

        public override string Name()
        {
            return "Redo command";
        }
    }

    public class ExitCommand : Command
    {
        public ExitCommand(BashTerminal bashTerminal) : base(bashTerminal)
        {
        }

        public override void Excecute()
        {
            Console.WriteLine("Good buy!");
        }

        public override string Name()
        {
            return "Exit command";
        }
    }

    public class UptimeCommand : Command
    {
        public UptimeCommand(BashTerminal bashTerminal) : base(bashTerminal)
        {
        }

        public override void Cancel()
        {
            base.Cancel();
        }

        public override void Excecute()
        {
            throw new NotImplementedException();
        }

        public override string Name()
        {
            return "Uptime command";
        }
    }

    public class RmCommand : Command
    {
        public RmCommand(BashTerminal bashTerminal) : base(bashTerminal)
        {
        }

        public override void Cancel()
        {
            base.Cancel();
        }

        public override void Excecute()
        {
            throw new NotImplementedException();
        }

        public override string Name()
        {
            return "Remove command";
        }
    }

    public static class CommandFactory
    {
        public static Command CreateCommand(string name, BashTerminal terminal)
        {
            switch (name)
            {
                case "history": return new HistoryCommand(terminal);

                case "undo": return new UndoCommand(terminal);

                case "redo": return new RedoCommand(terminal);

                case "exit": return new ExitCommand(terminal);

                case "uptime": return new UptimeCommand(terminal);

                case "rm": return new RmCommand(terminal);

                default:
                    Console.WriteLine("Command not found");
                    return null;
            }
        }

    }
}