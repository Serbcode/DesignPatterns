using System;
using System.Collections.Generic;
using CommandPattern3.Commands;

namespace CommandPattern3
{
    /// <summary>
    /// Design Patterns - Command Pattern Example
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // receiver
            Terminal terminal = new Terminal();

            // invoker
            var Session = new Session(terminal);                        

            string name = string.Empty;
            do
            {
                string input = Console.ReadLine();
                Command command = CommandFactory.CreateCommand(input.ToLower(), Session);

                if (command == null) continue;
                name = command.ToString();
                
                Session.ExecuteCommand(command);               

            } while (name != "exit");

        }
    }
}
