namespace StrategyPattern2.Parsers;
using StrategyPattern2.Abstract;

internal class DnsParser : IPeriodParser
{
    string IPeriodParser.Parse(string input)
    {
        return "DnsParser";
    }
}