using System.Collections.Generic;
using System.Text;
using System;

namespace CommandPattern3.Commands
{
    /// <summary>
    /// base class for simple and complex commands
    /// </summary>
    public abstract class Command 
    {
        protected readonly Session session;
        public readonly string Name;

        public Command(string name)
        {
            this.Name = name;
        }

        public Command(string name, Session bashSession)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.session = bashSession;
        }

        public virtual void Cancel() 
        { 
        }

        public override string ToString()
        {
            return this.Name;
        }

        public virtual string Execute() 
        { 
            return string.Empty; 
        }

    }
}