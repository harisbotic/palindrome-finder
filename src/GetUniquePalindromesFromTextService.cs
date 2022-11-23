public class GetUniquePalindromesFromTextService
{
    public static HashSet<PalindromeSubstring> Execute(string text)
    {
        var palindromes = new HashSet<PalindromeSubstring>();

        for (int i = 0; i < text.Length; i++)
        {
            var palindrome = GetPalindromeByExpandingFromCenter(text, centerIndex: i);

            if (palindrome.Length > 1)
            {
                palindromes.Add(palindrome);
            }
        }

        return palindromes;
    }

    private static PalindromeSubstring GetPalindromeByExpandingFromCenter(String text, int centerIndex)
    {
        bool canExpandToIndex(int toIndex) => toIndex < text.Length - 1;
        bool canExpandFromIndex(int fromIndex) => fromIndex > 0;

        int from = centerIndex;
        int to = centerIndex;
        while (canExpandToIndex(to) && text[to + 1] == text[centerIndex])
        {
            to++;
        }
        while (canExpandFromIndex(from) && text[from - 1] == text[centerIndex])
        {
            from--;
        }

        while (canExpandFromIndex(from) && canExpandToIndex(to) && text[from - 1] == text[to + 1])
        {
            from--;
            to++;
        }

        int length = to - from + 1;
        return new PalindromeSubstring(text.Substring(from, length), from);
    }
}