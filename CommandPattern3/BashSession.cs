using System.Collections.Generic;

namespace CommandPattern3
{
    /// <summary>
    /// Invoker class
    /// </summary>
    internal class BashSession
    {
        public void ExecuteCommand(Command cmd)
        {
            cmd.Excecute();
        }
    }
}