namespace TextFilter.Interfaces;

internal interface IFilter
{
    string Name { get; }
    bool IsMatch(string input);
}
