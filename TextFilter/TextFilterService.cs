using TextFilter.Interfaces;

namespace TextFilter;

internal class TextFilterService : ITextFilterService
{
    private readonly ITextReaderFactory _readerFactory;
    private readonly ITokenizer _tokenizer;
    private List<IFilter> _filterOuts;

    public TextFilterService(ITextReaderFactory readerFactory, ITokenizer tokenizer, List<IFilter> filterOuts)
    {
        _readerFactory = readerFactory;
        _tokenizer = tokenizer;
        _filterOuts = filterOuts;
    }

    public IEnumerable<string> FilterTextFromFile(string file)
    {
        using var reader = _readerFactory.Open(file);
        foreach (var token in _tokenizer.GetTokens(reader))
        {
            if (_filterOuts.Any(filter => filter.IsMatch(token)) == false)
            {
                yield return token;
            }
        }
    }
}
