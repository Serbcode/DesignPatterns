using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonPattern1
{
    class Singleton
    {
        private static Singleton UniqueInstance;
        private string SingletonData = string.Empty;

        protected Singleton()
        {
        }

        public static Singleton Instance()
        {
            if (UniqueInstance == null) UniqueInstance = new Singleton();
            return UniqueInstance;
        }

        public void SingletonOperation()
        {
            SingletonData = "SingletonData";
        }

        public string GetSingletonData()
        {
            return SingletonData;
        }

    }
}
