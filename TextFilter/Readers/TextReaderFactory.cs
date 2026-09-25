using TextFilter.Interfaces;

namespace TextFilter.Readers;

internal class TextReaderFactory : ITextReaderFactory
{
    static MemoryStream CreateStreamFromString(string input)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(input);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }

    public ITextReader FromString(string str)
    {
        return new TextReader(CreateStreamFromString(str));
    }

    public ITextReader Open(string file)
    {
        return new TextReader(file);
    }
}
