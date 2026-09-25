namespace TextFilter.Interfaces;

internal interface ITextReader:IDisposable
{
    bool Eof { get; }
    int BufferSize { get; set; }
    string ReadChunk();
}
