using System;
using System.Collections.Generic;
using CommandPattern3.Commands;

namespace CommandPattern3
{
    /// <summary>
    /// Invoker class
    /// </summary>
    public class BashSession
    {
        protected readonly List<string> history = new List<string>();

        public BashSession(BashTerminal terminal)
        {
            Terminal = terminal;
        }

        public BashTerminal Terminal { get; }

        public void ExecuteCommand(Command cmd)
        {
            Console.WriteLine(cmd.Execute());
            history.Add(cmd.ToString());

            if (cmd is UndoCommand) Terminal.GetCommand();
            else Terminal.PutCommand(cmd);
        }

        public string GetHistory()
        {
            return string.Join(" -> ", history);
        }
    }
}