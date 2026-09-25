namespace TextFilter.Test;

class AutoDisposeFile : IDisposable
{
    private readonly string _filePath;
    public AutoDisposeFile(string filePath)
    {
        _filePath = filePath;
    }
    public void Dispose()
    {
        if (File.Exists(_filePath))
        {
            File.Delete(_filePath);
        }
    }
}