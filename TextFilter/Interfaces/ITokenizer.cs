namespace TextFilter.Interfaces;

internal interface ITokenizer
{
    IEnumerable<string> GetTokens(ITextReader textReader);
}
