namespace StrategyPattern2.Parsers;
using StrategyPattern2.Abstract;

internal class MVideoParser : IPeriodParser
{
    string IPeriodParser.Parse(string input)
    {
        return "MVideoParser";
    }
}
