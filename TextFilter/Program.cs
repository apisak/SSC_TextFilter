using TextFilter.Filters;
using TextFilter.Interfaces;
using TextFilter.Readers;

namespace TextFilter;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            var textFilterService = CreateTextFilterService();

            var enterFilePathStr = "Enter file path (default: input.txt): ";
            Console.Write(enterFilePathStr);
            string inputPath = Console.ReadLine() ?? "";

            if (string.IsNullOrEmpty(inputPath))
            {
                inputPath = "input.txt";
                Console.SetCursorPosition(enterFilePathStr.Length, Console.CursorTop - 1);
                Console.WriteLine(inputPath);
            }

            if (File.Exists(inputPath) == false)
            {
                throw new Exception($"File '{inputPath}' does not exist.");
            }

            var result = textFilterService.FilterTextFromFile(inputPath).ToList();
            string resultStr = string.Join(", ", result);

            Console.WriteLine();
            Console.WriteLine("Filtered word count: " + result.Count);
            Console.WriteLine();
            Console.WriteLine(resultStr);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.ReadLine();
    }

    private static ITextFilterService CreateTextFilterService()
    {
        TextFilterServiceBuilder builder = new TextFilterServiceBuilder();
        builder.RegisterTokenizer<WordTokenizer>();
        builder.RegisterTextReaderFactory<TextReaderFactory>();

        builder.AddFilter(new FilterLengthLT(3));
        builder.AddFilter(new FilterContainsChar('t'));
        builder.AddFilter(new FilterMiddleVowel());

        var service = builder.Build();
        return service;
    }
}
