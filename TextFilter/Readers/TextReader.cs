using TextFilter.Interfaces;

namespace TextFilter.Readers;

internal class TextReader : ITextReader
{
    StreamReader? _streamReader;
    char[] _buffer = new char[4096];

    public int BufferSize
    {
        get => _buffer.Length;
        set
        {
            if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "Buffer size must be greater than zero.");
            _buffer = new char[value];
        }
    }

    public bool Eof => _streamReader?.EndOfStream ?? true;

    public TextReader(string filePath)
    {
        _streamReader = new StreamReader(filePath);
    }

    public TextReader(Stream stream)
    {
        _streamReader = new StreamReader(stream);
    }

    public void Dispose()
    {
        _streamReader?.Dispose();
    }

    public string ReadChunk()
    {
        if (_streamReader == null) return string.Empty;

        int len = _streamReader.ReadBlock(_buffer, 0, _buffer.Length);
        if (len == 0) return string.Empty;

        return new string(_buffer, 0, len);
    }

}
