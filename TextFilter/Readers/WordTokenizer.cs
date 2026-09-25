using System.Text.RegularExpressions;
using TextFilter.Interfaces;

namespace TextFilter.Readers;

internal partial class WordTokenizer : ITokenizer
{

    [GeneratedRegex(@"\W", RegexOptions.RightToLeft)]
    private static partial Regex NotLetterRegEx();

    private static (string, string) ReadChunk(ITextReader textReader, string prevTruncatedWord)
    {
        var chunk = prevTruncatedWord + textReader.ReadChunk();
        if (textReader.Eof) return (chunk, string.Empty);

        //check non letter character
        var nonLetter = NotLetterRegEx().Match(chunk);
        // if no non letter character is found, the word is truncated
        if (nonLetter.Success == false) return (string.Empty, chunk);

        return (chunk.Substring(0, nonLetter.Index), chunk.Substring(nonLetter.Index + 1));
    }

    private static IEnumerable<string> SplitWords(string str)
    {
        if (string.IsNullOrEmpty(str)) yield break;

        int startIndex = 0;
        for (var i = 0; i < str.Length; i++)
        {
            //split on non-letter characters
            if (!char.IsLetter(str[i]))
            {
                if (i > startIndex)
                {
                    yield return str.Substring(startIndex, i - startIndex);
                }
                startIndex = i + 1;
            }
        }
        if (startIndex < str.Length)
        {
            yield return str.Substring(startIndex);
        }
    }

    public IEnumerable<string> GetTokens(ITextReader textReader)
    {
        if (textReader.Eof) yield break;

        string prevTruncatedWord = string.Empty;
        while (!textReader.Eof)
        {
            (var str, prevTruncatedWord) = ReadChunk(textReader, prevTruncatedWord);
            if (string.IsNullOrEmpty(str)) continue;

            foreach (var word in SplitWords(str))
            {
                yield return word;
            }
        }
    }
}
