using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern1
{
    // Общий интерфейс компонентов.
    public abstract class DataSource
    {
        public abstract void WriteData(string data);
        public abstract string ReadData();
    }
}
