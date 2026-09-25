using TextFilter.Filters;
using TextFilter.Readers;

namespace TextFilter.Test;

public class TestTextFilterService
{
    [Fact]
    public void TestFilterTextFromFile()
    {
        string input = "Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing to do: once or twice";
        List<string> expectedTokens = ["beginning", "and", "once"];


        var inputPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".txt");
        File.WriteAllText(inputPath, input);
        using var temp = new AutoDisposeFile(inputPath);

        
        TextFilterServiceBuilder builder = new TextFilterServiceBuilder();
        
        builder.RegisterTokenizer<WordTokenizer>();
        builder.RegisterTextReaderFactory<TextReaderFactory>();

        builder.AddFilter(new FilterLengthLT(3));
        builder.AddFilter(new FilterContainsChar('t'));
        builder.AddFilter(new FilterMiddleVowel());

        var service = builder.Build();
        var actualTokens = service.FilterTextFromFile(inputPath).ToList();
        Assert.Equal(expectedTokens, actualTokens);
    }
}
