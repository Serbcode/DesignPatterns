using System;
using System.IO;

namespace DecoratorPattern1
{
    // Создаем декоратор.
    // это родитель всех декораторов. он наследует и аггрегирует общий интерфейс!
    
    // Родитель всех декораторов содержит код обёртывания.
    public class DataSourceDecorator : DataSource
    {
        private readonly DataSource source;

        public DataSourceDecorator(DataSource source)
        {
            this.source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public override string ReadData()
        {
            return source.ReadData();
        }

        public override void WriteData(string data)
        {
            source.WriteData(data);
        }
    }

    public class EncryptionDecorator : DataSourceDecorator
    {
        public EncryptionDecorator(DataSource dataSource) : base(dataSource)
        {

        }

        public override string ReadData()
        {
            string encrypted = base.ReadData();
            string decrypted = encrypted.Substring(1, encrypted.Length - 2);
            return decrypted;
        }

        public override void WriteData(string data)
        {
            data = "#" + data + "#";
            base.WriteData(data);
        }
    }

    public class CompressionDecorator : DataSourceDecorator
    {
        public CompressionDecorator(DataSource dataSource) : base(dataSource)
        {
        }

        public override void WriteData(string data)
        {
            data = ">" + data + "<";
            base.WriteData(data);
        }

        public override string ReadData()
        {
            string zipped = base.ReadData();
            string unzipped = zipped.Substring(1, zipped.Length - 2);
            return unzipped;
        }
    }

    public class Client
    {
        // Клиентский код работает со всеми объектами, используя интерфейс
        // Компонента. Таким образом, он остаётся независимым от конкретных
        // классов компонентов, с которыми работает.
        public void ClientCode(DataSource component)
        {
            component.WriteData("here is a text data");
            Console.WriteLine(component.ReadData());            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // то, что у нас было.
            Client client = new Client();
            var fs = new FileDataSource("Test.txt");
            client.ClientCode(fs);

            // а теперь декораторы. добавленная функциональность.
            // декораторы могут обертывать декораторы ))
            EncryptionDecorator ed = new EncryptionDecorator(fs);
            CompressionDecorator cd = new CompressionDecorator(ed);
            
            // клиентский код не меняется и работает также с ними.
            client.ClientCode(cd);
        }
    }
}
