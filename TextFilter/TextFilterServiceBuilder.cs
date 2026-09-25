using Microsoft.Extensions.DependencyInjection;
using TextFilter.Interfaces;
using TextFilter.Readers;

namespace TextFilter;

internal class TextFilterServiceBuilder
{
    ServiceCollection _services = new ServiceCollection();
    List<IFilter> _filterOuts = new List<IFilter>();
    public void AddFilter(IFilter filter)
    {
        _filterOuts.Add(filter);
    }

    public void RegisterTextReaderFactory<T>() where T : class, ITextReaderFactory
    {
        _services.AddTransient<ITextReaderFactory, T>();
    }

    public void RegisterTokenizer<T>() where T : class, ITokenizer
    {
        _services.AddTransient<ITokenizer, T>();
    }

    public ITextFilterService Build()
    {
        _services.AddTransient<ITextFilterService, TextFilterService>();
        _services.AddTransient(s => _filterOuts);
        
        return _services.BuildServiceProvider().GetRequiredService<ITextFilterService>();
    }
}
