using Microsoft.AspNetCore.Mvc;

string? inputFromConsole = Environment.GetCommandLineArgs().ElementAtOrDefault(1);
if (inputFromConsole != null)
{
    var palindromes = PalindromeSubstring.SortByLengthDesc(GetUniquePalindromesFromTextService.Execute(inputFromConsole)).Take(3);
    Console.WriteLine($"The 3 longest palindromes in {inputFromConsole} are:" + '\n');
    foreach (var palindrome in palindromes)
    {
        Console.WriteLine(palindrome);
        Console.WriteLine();
    }
}

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", ([FromQuery] string text) =>
                    PalindromeSubstring.SortByLengthDesc(GetUniquePalindromesFromTextService.Execute(text)).Take(3));

app.Run();