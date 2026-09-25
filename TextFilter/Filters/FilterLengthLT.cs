using TextFilter.Interfaces;

namespace TextFilter.Filters;

internal class FilterLengthLT : IFilter
{
    public string Name => "FilterLengthLT";
    public int Length { get; }

    public FilterLengthLT(int length)
    {
        Length = length;
    }

    public bool IsMatch(string input)
    {
        return input.Length < Length;
    }

}
