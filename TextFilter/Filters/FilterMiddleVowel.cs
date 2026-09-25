using TextFilter.Interfaces;

namespace TextFilter.Filters;

internal class FilterMiddleVowel : IFilter
{
    const string Vowels = "aeiou";

    public string Name => "FilterVowel";
    public bool IsMatch(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        var len = input.Length;
        if (len % 2 != 0)
        {
            var middleIndex = len / 2;
            return Vowels.Contains(input[middleIndex], StringComparison.OrdinalIgnoreCase);
        }
        else
        {
            var middleIndex1 = len / 2 - 1;
            var middleIndex2 = len / 2;
            return Vowels.Contains(input[middleIndex1], StringComparison.OrdinalIgnoreCase) || Vowels.Contains(input[middleIndex2], StringComparison.OrdinalIgnoreCase);
        }
    }

}
