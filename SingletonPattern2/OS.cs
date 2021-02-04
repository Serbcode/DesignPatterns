using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonPattern2
{
    public class OS
    {
        private static OS instance;
        private static object SyncRoot = new Object();

        public string Name { get; private set; }

        protected OS(string name)
        {
            this.Name = name;
        }

        public static OS GetInstance(string name)
        {
            if (instance == null)
            {
                lock (SyncRoot)
                {
                    if (instance == null)
                        instance = new OS(name);
                }
            }                
            return instance;
        }
    }
}
