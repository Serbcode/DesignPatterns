using System;
using System.Collections.Generic;
using System.Diagnostics;
using CommandPattern3.Commands;

namespace CommandPattern3
{
    /// <summary>
    /// Reciever, who recive commands and do some job
    /// </summary>
    public class BashTerminal : IDisposable
    {
        private readonly Stack<Command> stack;        

        public readonly Stopwatch Uptime;        

        public BashTerminal()
        {
            Uptime = new Stopwatch();
            Uptime.Start();
            
            stack = new Stack<Command>();            
        }

        public Command GetCommand()
        {
            try
            {
                return stack.Pop();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }                        
        }

        public void PutCommand(Command cmd)
        {
            if (!(cmd is NotFoundCommand))
                stack.Push(cmd);
        }

        public string GetQueue()
        {
            return string.Join(" -> ", stack);
        }

        public void Dispose()
        {
            Uptime.Stop();                        
        }
    }
}