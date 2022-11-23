public record class PalindromeSubstring
{
    public string Text { get; }
    public int Index { get; }
    public int Length => Text.Length;

    public PalindromeSubstring(string text, int index)
    {
        if (text == string.Empty || !text.SequenceEqual(text.Reverse()))
            throw new TextNotPalindromeException($"Text {text} is not a palindrome");

        Text = text;
        Index = index;
    }

    public static ICollection<PalindromeSubstring> SortByLengthDesc(IEnumerable<PalindromeSubstring> palindromes)
    {
        var palindromesList = palindromes.ToList();
        palindromesList.Sort(new ByLengthDescComparer());
        return palindromesList;
    }

    public class ByLengthDescComparer : Comparer<PalindromeSubstring>
    {
        public override int Compare(PalindromeSubstring? y, PalindromeSubstring? x)
        {
            if (x is null && y is null) return 0;
            if (x is null) return -1;
            if (y is null) return 1;

            // Compares Length then Index for sorting purposes
            if (x.Length.CompareTo(y.Length) != 0)
            {
                return x.Length.CompareTo(y.Length);
            }
            else if (x.Index.CompareTo(y.Index) != 0)
            {
                return -x.Index.CompareTo(y.Index);
            }
            else
            {
                return 0;
            }
        }
    }
    
    public virtual bool Equals(PalindromeSubstring? other) => Text.Equals(other?.Text);

    public override int GetHashCode() => Text.GetHashCode();

    public override string ToString() => $"Text: {Text}, Index: {Index}, Length: {Length}";
}
public class TextNotPalindromeException : Exception
{
    public TextNotPalindromeException(string message)
        : base(message)
    {
    }
}