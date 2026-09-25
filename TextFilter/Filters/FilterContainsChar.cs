using TextFilter.Interfaces;

namespace TextFilter.Filters;

internal class FilterContainsChar : IFilter
{
    public string Name => "FilterContainsChar";
    public string Character { get; }

    public FilterContainsChar(char character)
    {
        Character = character.ToString();
    }

    public bool IsMatch(string input)
    {
        return input.Contains(Character.ToString(), StringComparison.OrdinalIgnoreCase);
    }
}
