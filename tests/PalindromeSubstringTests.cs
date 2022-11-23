public class PalindromeSubstringTests
{
    [Fact]
    public void Constructor_GivenNonPalindromicText_ThrowsTextNotPalindromeException()
    {
        string text = "not_palindrome";

        Assert.Throws<TextNotPalindromeException>(() => new PalindromeSubstring(text, 0));
    }

    [Fact]
    public void Constructor_GivenZeroLengthText_ThrowsTextNotPalindromeException()
    {
        string text = "";

        Assert.Throws<TextNotPalindromeException>(() => new PalindromeSubstring(text, 0));
    }

    [Fact]
    public void Constructor_GivenPalindromicText_ReturnsObject()
    {
        string text = "abba";

        var palindromeSubstring = new PalindromeSubstring(text, 0);

        Assert.NotNull(palindromeSubstring);
    }

    [Fact]
    public void ByLengthDescComparer_GivenDifferentLengthPalindromes_ComparesInDescendingOrderByTextLength()
    {
        var list = new PalindromeSubstring[]
        {
            new PalindromeSubstring("a", 0),
            new PalindromeSubstring("aaa", 0),
            new PalindromeSubstring("aa", 0),
        };

        var sortedList = new SortedSet<PalindromeSubstring>(collection: list, comparer: new PalindromeSubstring.ByLengthDescComparer());

        Assert.Equal("aaa", sortedList.First().Text);
    }

    [Fact]
    public void ByLengthDescComparer_GivenSameLengthPalindromes_ComparesInAscendingOrderByIndex()
    {
        var list = new PalindromeSubstring[]
        {
            new PalindromeSubstring("aaa", 3),
            new PalindromeSubstring("aaa", 1),
            new PalindromeSubstring("aaa", 2),
        };

        var sortedList = new SortedSet<PalindromeSubstring>(collection: list, comparer: new PalindromeSubstring.ByLengthDescComparer());

        Assert.Equal(1, sortedList.First().Index);
    }

    [Fact]
    public void ByLengthDescComparer_GivenOneNullObject_ReturnsNullObjectAsSmaller()
    {
        var list = new PalindromeSubstring[]
        {
            new PalindromeSubstring("a", 0),
            null!,
        };

        var sortedList = new SortedSet<PalindromeSubstring>(collection: list, comparer: new PalindromeSubstring.ByLengthDescComparer());

        Assert.NotNull(sortedList.First());
    }

    [Fact]
    public void ByLengthDescComparer_GivenNullObjects_ReturnsNullObjectAsSame()
    {
        var result = new PalindromeSubstring.ByLengthDescComparer().Compare(null, null);

        Assert.Equal(0, result);
    }

    [Fact]
    public void SortByLengthDesc_GivenUnsortedPalindromSubstrings_ReturnsThemSorted()
    {
        var list = new PalindromeSubstring[]
        {
            new PalindromeSubstring("aa", 3),
            new PalindromeSubstring("a", 0),
            new PalindromeSubstring("aaa", 1),
        };

        var sortedList = PalindromeSubstring.SortByLengthDesc(list);

        Assert.Equal("aaa", sortedList.ElementAt(0).Text);
        Assert.Equal("aa", sortedList.ElementAt(1).Text);
        Assert.Equal("a", sortedList.ElementAt(2).Text);
    }
}