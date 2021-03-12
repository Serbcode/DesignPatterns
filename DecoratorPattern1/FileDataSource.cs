using System;
using System.IO;

namespace DecoratorPattern1
{
    // Один из конкретных компонентов реализует базовую
    // функциональность. Мы не можем, например, ее менять (чужой код) но нужно...

    public class FileDataSource : DataSource
    {
        private readonly string filename;

        public FileDataSource(string filename)
        {
            this.filename = filename ?? throw new ArgumentNullException(nameof(filename));
        }

        public override string ReadData()
        {
            return File.ReadAllText(filename);
        }

        public override void WriteData(string data)
        {
            File.WriteAllText(filename, data);
        }
    }
}
