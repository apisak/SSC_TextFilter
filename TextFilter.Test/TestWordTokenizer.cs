using TextFilter.Readers;

namespace TextFilter.Test;

public class TestWordTokenizer
{
    [Fact]
    public void TestTokenize()
    {
        string input = "Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing to do: once or twice";
        List<string> expectedTokens = [ "Alice", "was", "beginning", "to", "get", "very", "tired", "of", "sitting", "by", "her", "sister", "on", "the", "bank", "and", "of", "having", "nothing", "to", "do", "once", "or", "twice"];

        var reader = new TextReaderFactory().FromString(input);
        var tokenizer = new WordTokenizer();

        var actualTokens = tokenizer.GetTokens(reader).ToList();
        Assert.Equal(expectedTokens, actualTokens);
    }

    [Fact]
    public void TestTokenize_Truncate_Word()
    {
        string input = "Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing to do: once or twice";
        List<string> expectedTokens = ["Alice", "was", "beginning", "to", "get", "very", "tired", "of", "sitting", "by", "her", "sister", "on", "the", "bank", "and", "of", "having", "nothing", "to", "do", "once", "or", "twice"];

        var reader = new TextReaderFactory().FromString(input);
        var tokenizer = new WordTokenizer();

        reader.BufferSize = 20;

        var actualTokens = tokenizer.GetTokens(reader).ToList();
        Assert.Equal(expectedTokens, actualTokens);
    }

    [Fact]
    public void TestTokenize_Word_Longer_Than_Buffer_Size()
    {
        string input = "Alicewasbeginningtogetverytiredof sittingbyhersisteronthebank, andofhavingnothingtodo: once or twice";
        List<string> expectedTokens = ["Alicewasbeginningtogetverytiredof", "sittingbyhersisteronthebank", "andofhavingnothingtodo", "once", "or", "twice"];

        var reader = new TextReaderFactory().FromString(input);
        var tokenizer = new WordTokenizer();

        reader.BufferSize = 20;

        var actualTokens = tokenizer.GetTokens(reader).ToList();
        Assert.Equal(expectedTokens, actualTokens);
    }


}
