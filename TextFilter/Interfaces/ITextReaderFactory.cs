namespace TextFilter.Interfaces;

internal interface ITextReaderFactory
{
    ITextReader Open(string file);
    ITextReader FromString(string text);
}
