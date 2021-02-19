using System;
using System.Text.RegularExpressions;

namespace AdapterPattern2
{
    // extract interface from legacy XML provider
    public interface IStockDataProvider
    {
        string GetDaylyCounts();
        string GetWeeklyCounts();
        string GetMonthlyData();
    }

    // adapter class
    public class JsonStockDataProvider : IStockDataProvider
    {
        private readonly XmlStockDataProvider XmlStockDataProvider;

        // takes old specification in constructor.
        public JsonStockDataProvider(XmlStockDataProvider xmlStockDataProvider)
        {
            XmlStockDataProvider = xmlStockDataProvider;
        }

        public string GetDaylyCounts()
        {
            string xml = XmlStockDataProvider.GetDaylyCounts();
            return Regex.Replace(xml, "XML", "Json");
        }

        public string GetMonthlyData()
        {
            string xml = XmlStockDataProvider.GetWeeklyCounts();
            return Regex.Replace(xml, "XML", "Json");
        }

        public string GetWeeklyCounts()
        {
            string xml = XmlStockDataProvider.GetMonthlyData();
            return Regex.Replace(xml, "XML", "Json");
        }
    }

    // legacy class retuns XML from  endpoint URI
    public class XmlStockDataProvider : IDisposable
    {
        public string Endpoint { get; set; }

        public XmlStockDataProvider(string endpoint)
        {
            Endpoint = endpoint;
        }

        public void Dispose()
        {
            Endpoint = null;
        }

        internal string GetDaylyCounts()
        {
            return "Dayly data in XML format";
        }

        internal string GetWeeklyCounts()
        {
            return "Weekly data in XML format";
        }

        internal string GetMonthlyData()
        {
            return "XML data in this month";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string endpoint = (args.Length == 0) ? "default endpoint" : args[0];
            
            // old legacy code. or code we do not have access
            var xml_provider = new XmlStockDataProvider(endpoint);

            // adapter which adaptee old code to user interface
            var provider = new JsonStockDataProvider(xml_provider);

            // user code. it used xml format before.
            var dayly = provider.GetDaylyCounts();
            var weekly = provider.GetWeeklyCounts();
            var monthlyData = provider.GetMonthlyData();
            Console.WriteLine(dayly + Environment.NewLine + weekly + Environment.NewLine + monthlyData);

        }
    }
}
