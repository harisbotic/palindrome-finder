public class GetUniquePalindromeInTextServiceTests
{
    [Fact]
    public void Execute_GivenTextWith1LetterPalindromes_ResultExcludes1LetterPalindromes()
    {
        string text = "abc";

        var palindromes = GetUniquePalindromesFromTextService.Execute(text);

        Assert.Empty(palindromes);
    }

    [Fact]
    public void Execute_GivenTextContaningSamePalindromesWithDifferentIndex_ReturnsUniquePalindromesByText()
    {
        string text = "111x111";

        var palindromes = GetUniquePalindromesFromTextService.Execute(text);

        Assert.Single(palindromes, x => x.Text == "111");
    }

    [Fact]
    public void Execute_GivenTextWithLongPalindrome_ResultDoesntContainSubPalindromesWithTheSameCenterIndex()
    {
        string subPalindrome = "232";
        string text = $"1{subPalindrome}1";

        var palindromes = GetUniquePalindromesFromTextService.Execute(text);

        Assert.DoesNotContain(palindromes, x => x.Text == subPalindrome);
    }

    [Fact]
    public void Execute_GivenCaseSensitiveText_ResultIsCaseSensitive()
    {
        string text = "Aaaa";

        var palindromes = GetUniquePalindromesFromTextService.Execute(text);

        Assert.Single(palindromes);
        Assert.Equal("aaa", palindromes.First().Text);
    }

    [Fact]
    public void Execute_GivenTextWithWhitespaces_ResultTreatsWhitespacesAsCharacter()
    {
        string text = "aa aa";

        var palindromes = GetUniquePalindromesFromTextService.Execute(text);

        Assert.DoesNotContain(palindromes, x => x.Text == "aaaa");
        Assert.Contains(palindromes, x => x.Text == text);
    }

    [Fact]
    public void Execute_GivenTextWithSpecialCharacters_ResultTreatsThemAsAnyOtherCharacter()
    {
        string text = "#$@$#";

        var palindromes = GetUniquePalindromesFromTextService.Execute(text);

        Assert.Contains(palindromes, x => x.Text == text);
    }

    [Fact]
    public void Execute_GivenTextWithPalindromes_ReturnsZeroBasedPositionalIndexes()
    {
        string palindrome1 = "111";
        string palindrome2 = "aaa";
        string text = $"{palindrome1}x{palindrome2}";

        var palindromes = GetUniquePalindromesFromTextService.Execute(text);

        Assert.Equal(0, palindromes.Single(x => x.Text == palindrome1).Index);
        Assert.Equal(4, palindromes.Single(x => x.Text == palindrome2).Index);
    }
}