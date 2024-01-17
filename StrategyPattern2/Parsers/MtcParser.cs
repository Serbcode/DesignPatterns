namespace StrategyPattern2.Parsers;
using StrategyPattern2.Abstract;

internal class MtcParser : IPeriodParser
{
    string IPeriodParser.Parse(string input)
    {
        return "MtcParser";
    }
}