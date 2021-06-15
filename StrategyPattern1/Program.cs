using System;

namespace StrategyPattern1
{
    // context class
    public class DataImporter
    {
        private Parser _parser;

        public void SetParser(Parser parser)
        {
            _parser = parser;
        }

        public void Execute(object data)
        {
            try
            {
                _parser.ParseData(data);
                OnDataParsed(new DataParsedEventArgs() { JsonString = "JSON RESULT", Exception = null, TimeReached = DateTime.Now });
            }
            catch (Exception e)
            {
                OnDataParsed(new DataParsedEventArgs() { JsonString = string.Empty, Exception = e, TimeReached = DateTime.Now });
            }            
        }

        public event EventHandler<DataParsedEventArgs> DataParsed;

        protected void OnDataParsed(DataParsedEventArgs args)
        {
            DataParsed?.Invoke(this, args);
        }
    }

    // strategies interface
    public abstract class Parser
    {
        public abstract void ParseData(object data);
    }

    // concrete strategy
    public class DNSParser : Parser
    {       
        public override void ParseData(object data)
        {
            Console.WriteLine("DNS parser goes work");
        }
    }

    // concrete strategy
    public class MVideoParser : Parser
    {        
        public override void ParseData(object data)
        {
            Program.wline("MVIDEO parser goes work");
        }
    }

    public class DataParsedEventArgs : EventArgs
    { 
        public Exception Exception { get; set; }
        public string JsonString { get; set; }
        public DateTime TimeReached { get; set; }
    }

    public delegate void writeline(string str);
    

    class Program
    {
        public readonly Action line = () => Console.WriteLine();
        public static writeline wline = (string s) => Console.WriteLine(s);

        static void Main(string[] args)
        {            
            wline("input parser name: ");
            string parser = Console.ReadLine();

            DataImporter importer = new DataImporter();
            importer.DataParsed += Importer_DataParsed;

            if (parser.ToLower().Contains("dns"))
            {
                importer.SetParser(new DNSParser());                
            }
            else 
            {
                importer.SetParser(new MVideoParser());                
            }

            importer.Execute(null);
        }

        private static void Importer_DataParsed(object sender, DataParsedEventArgs e)
        {
            wline("sender: " + sender.GetType().Name);
            if (e.Exception == null)
            {
                wline(e.TimeReached.ToString("HH:mm ss"));
            }
        }
    }
}
