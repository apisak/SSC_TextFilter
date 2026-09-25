using TextFilter.Filters;

namespace TextFilter.Test;

public class TestFilters
{
    [Theory]
    [InlineData("apple", true)]
    [InlineData("github", false)]
    public void TestFilterContainsChar(string input, bool expected)
    {
        var filter = new FilterContainsChar('a');
        Assert.Equal(expected, filter.IsMatch(input));
    }

    [Theory]
    [InlineData("", true)]
    [InlineData("1234", true)]
    [InlineData("12345", false)]
    [InlineData("123456", false)]
    public void TestFilterLengthLT(string input, bool expected)
    {
        var filter = new FilterLengthLT(5);
        Assert.Equal(expected, filter.IsMatch(input));
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("clean", true)]
    [InlineData("what", true)]
    [InlineData("currently", true)]
    [InlineData("sky", false)]
    public void TestFilterVowel(string input, bool expected)
    {
        var filter = new FilterMiddleVowel();
        Assert.Equal(expected, filter.IsMatch(input));
    }
}
