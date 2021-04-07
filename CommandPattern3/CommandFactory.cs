using System;
using CommandPattern3.Commands;

namespace CommandPattern3
{
    public static class CommandFactory
    {
        public static Command CreateCommand(string name, Session session)
        {
            switch (name)
            {
                case "history": return new HistoryCommand(name, session);

                case "undo": return new UndoCommand(name, session);

                case "exit": return new ExitCommand(name);

                case "uptime": return new UptimeCommand(name, session);

                case "rm": return new RmCommand(name);

                case "status": return new StatusCommand(name, session);
                
                case "help": return new HelpCommand(name);
                
                case "?": return new HelpCommand("help");

                default:
                    return new NotFoundCommand(name);
            }
        }

    }
}