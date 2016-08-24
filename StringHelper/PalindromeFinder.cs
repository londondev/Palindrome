using System.Collections.Generic;
using System.Linq;

namespace StringHelper
{
    public class PalindromeFinder
    {
        const int MAXIMUM_NUMBER_OF_PALINDRONE = 3;
        IList<PalindromeTextInformation> _palindromeTextInformation;

        public IList<PalindromeTextInformation> GetPalindromes(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new List<PalindromeTextInformation>();

            return FindAllPalindromes(text.Replace(" ", ""));
        }

        private IList<PalindromeTextInformation> FindAllPalindromes(string text)
        {
            _palindromeTextInformation = _palindromeTextInformation = new List<PalindromeTextInformation>();

            for (int lengthOfPalindrome = text.Length; lengthOfPalindrome > 0; lengthOfPalindrome--)
            {
                for (int offSet = 0; offSet <= text.Length - lengthOfPalindrome; offSet++)
                {
                    if (!DoesSubTextIntersectToAnyOtherPalindrome(offSet, lengthOfPalindrome))
                    {
                        var subTextToQuery = text.Substring(offSet, lengthOfPalindrome);
                        AddTextToListIfPalindrone(subTextToQuery, offSet);
                        if (_palindromeTextInformation.Count() == MAXIMUM_NUMBER_OF_PALINDRONE)
                            return _palindromeTextInformation;
                    }
                }
            }
            return _palindromeTextInformation;
        }

        private void AddTextToListIfPalindrone(string subTextToQuery, int offSet)
        {
            if (IsPalindrome(subTextToQuery) && HasAlreadyNotBeenAdded(subTextToQuery))
            {
                _palindromeTextInformation.Add(new PalindromeTextInformation
                {
                    Text = subTextToQuery,
                    Index = offSet,
                    Length = subTextToQuery.Length
                });
            }
        }
        private bool IsPalindrome(string text)
        {
            var reversedText = new string(text.Reverse().ToArray());

            return text == reversedText;
        }

        private bool DoesSubTextIntersectToAnyOtherPalindrome(int index, int length)
        {
            return _palindromeTextInformation.Any(p => index < p.Index + p.Length && p.Index < index + length);
        }

        private bool HasAlreadyNotBeenAdded(string text)
        {
            return !_palindromeTextInformation.Any(p => p.Text == text);
        }

    }
}
