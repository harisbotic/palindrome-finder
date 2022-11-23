public class IntegrationTests
{
    public record struct PalindromeSubstringMock(string ExpectedText, int ExpectedIndex, int ExpectedLength);

    public static IEnumerable<object[]> TextsWithSortedPalindromes()
    {
        yield return new object[] {
            "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop",
            new PalindromeSubstringMock("hijkllkjih", 23, 10),
            new PalindromeSubstringMock("defggfed", 13, 8),
            new PalindromeSubstringMock("abccba", 5, 6),
            new PalindromeSubstringMock("qrrq", 1, 4),
            new PalindromeSubstringMock("mnnm", 35, 4),
            new PalindromeSubstringMock("pop", 40, 3),
        };
        yield return new object[] {
            "aaa",
            new PalindromeSubstringMock("aaa", 0, 3)
        };
        yield return new object[] {
            " @111@ xxAAidemodaljemidAxx ....",
            new PalindromeSubstringMock(" @111@ ", 0, 7),
            new PalindromeSubstringMock("....", 28, 4),
            new PalindromeSubstringMock("xx", 7, 2),
            new PalindromeSubstringMock("AA", 9, 2),
        };
    }

    [Theory]
    [MemberData(nameof(TextsWithSortedPalindromes))]
    public void GetUniquePalindromesFromText_SortedByLengthDescending(string text, params PalindromeSubstringMock[] expectedPalindromes)
    {
        var actualPalindromes = PalindromeSubstring.SortByLengthDesc(GetUniquePalindromesFromTextService.Execute(text));
   
        Assert.Equal(expectedPalindromes.Length, actualPalindromes.Count());
        for (int i = 0; i < expectedPalindromes.Length; i++)
        {
            var expectedPalindrome = expectedPalindromes[i];
            var actualPalindrome = actualPalindromes.ElementAt(i);
            Assert.Equal(expectedPalindrome.ExpectedText, actualPalindrome.Text);
            Assert.Equal(expectedPalindrome.ExpectedIndex, actualPalindrome.Index);
            Assert.Equal(expectedPalindrome.ExpectedLength, actualPalindrome.Length);
        }
    }
}