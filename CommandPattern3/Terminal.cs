using System;
using System.Collections.Generic;
using System.Diagnostics;
using CommandPattern3.Commands;

namespace CommandPattern3
{
    /// <summary>
    /// Receiver, who receives commands and do some job
    /// </summary>
    public class Terminal : IDisposable
    {
        private readonly Stack<Command> stack;

        public readonly Stopwatch Uptime;

        public Terminal()
        {
            Uptime = new Stopwatch();
            Uptime.Start();

            stack = new Stack<Command>();
        }

        public Command PopCommand()
        {
            try
            {
                // stack could be empty
                return stack.Pop();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void PushCommand(Command cmd)
        {
            if (!(cmd is NotFoundCommand))
                stack.Push(cmd);
        }

        public string GetCommands()
        {
            return string.Join(" -> ", stack);
        }

        public void Dispose()
        {
            Uptime.Stop();
        }
    }
}