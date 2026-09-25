namespace TextFilter.Interfaces;

internal interface ITextFilterService
{
    IEnumerable<string> FilterTextFromFile(string file);
}
