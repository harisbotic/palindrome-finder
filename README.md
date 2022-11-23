
## Table of Contents

1. [Project Requirements](#project-requirements)
2. [How to run](#how-to-run)
3. [Assumptions](#assumptions)
4. [Unit tests](#unit-tests)

# Project Requirements

Click [here](REQUIREMENTS.md) to read the project requirements

# How to run

### Prerequisite

* .NET 6 - https://dotnet.microsoft.com/en-us/download

### Configurations
* Http server port is **5678** - ex: `http://localhost:5678`

### How to Run
* App with the REST endpoint is run by going into **src** folder and executing command `dotnet run`

* Example Console invocation - `dotnet run sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop`
<img width="759" alt="image" src="https://user-images.githubusercontent.com/6454831/199931211-afd30e80-8690-4d2c-8aa3-b8aa6195a3be.png">

* Example GET request - `http://localhost:5678?text=sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop`
<img width="737" alt="image" src="https://user-images.githubusercontent.com/6454831/199902037-c76f6b2f-bc6a-45cd-bcbe-66d3dab686d6.png">


# Assumptions

* If multiple palindromes have the same length, the one which appears first has a priority in ordering.

* For text abcba only one palindrome should be shown. Explanation:

    A palindrome's central index number is its ID. For any palindrome (ex. 12321) if a single character is cut from both sides that is still going to be a palindrome (with same id) so there is no need to return that as a separate result as well.
  
* Max Input text size is **8170** characters, as that is the maximum URI length my default and that is more than enough as users will never need more than that. But by change of requirements a larger text needs to be supported, that can be achieved through other ways of communication or change http server config.

* Palindromes’ starting index is not a distinguishing property and its sole purpose is to help users find it more easily. Two palindromes having the same text and a different starting position (index) are considered equal.

* A single character palindromes won’t be displayed to the user.

* Indexes reported are zero based. Index counting starts from zero.

* Length reported represents number of characters in a palindrome. Palindrome 'aaa' has length of 3.

* An empty string is not a palindrome.

* Palindrome checking is case sensitive. Letter casing is important to the user.

* Whitespace and any other special character should be counted as a distinct character.

* User will mainly use the app through a web-client so returning a JSON response format is a good practice.

* User can use the app through console as well for quick checks.

* The app's palindrome features will always be used to get unique palindromes. The variable part is the way how to sort them and how many to display. But at the moment there is only one requirement of that kind.


  
# Unit tests
* GetUniquePalindromeInTextServiceTests.Execute_GivenTextWith1LetterPalindromes_ResultExcludes1LetterPalindromes

* GetUniquePalindromeInTextServiceTests.Execute_GivenTextContaningSamePalindromesWithDifferentIndex_ReturnsUniquePalindromesByText

* GetUniquePalindromeInTextServiceTests.Execute_GivenTextWithLongPalindrome_ResultDoesntContainSubPalindromesWithTheSameCenterIndex

* GetUniquePalindromeInTextServiceTests.Execute_GivenCaseSensitiveText_ResultIsCaseSensitive

* GetUniquePalindromeInTextServiceTests.Execute_GivenTextWithWhitespaces_ResultTreatsWhitespacesAsCharacter

* GetUniquePalindromeInTextServiceTests.Execute_GivenTextWithSpecialCharacters_ResultTreatsThemAsAnyOtherCharacter

* GetUniquePalindromeInTextServiceTests.Execute_GivenTextWithPalindromes_ReturnsZeroBasedPositionalIndexes

___


* PalindromeSubstringTests.Constructor_GivenNonPalindromicText_ThrowsTextNotPalindromeException

* PalindromeSubstringTests.Constructor_GivenZeroLengthText_ThrowsTextNotPalindromeException

* PalindromeSubstringTests.Constructor_GivenPalindromicText_ReturnsObject

* PalindromeSubstringTests.ByLengthDescComparer_GivenDifferentLengthPalindromes_ComparesInDescendingOrderByTextLength

* PalindromeSubstringTests.ByLengthDescComparer_GivenSameLengthPalindromes_ComparesInAscendingOrderByIndex

* PalindromeSubstringTests.ByLengthDescComparer_GivenOneNullObject_ReturnsNullObjectAsSmaller

* PalindromeSubstringTests.ByLengthDescComparer_GivenNullObjects_ReturnsNullObjectAsSame

* PalindromeSubstringTests.SortByLengthDesc_GivenUnsortedPalindromSubstrings_ReturnsThemSorted

___

* IntegrationTests.GetUniquePalindromesFromText_SortedByLengthDescending
