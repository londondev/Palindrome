using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringHelper;
using System.Linq;

namespace PalindromeFinderTests
{
    [TestClass]
    public class PalindromeFinderTests
    {
        PalindromeFinder _palindromeFinder;

        [TestInitialize]
        public void TestInitialize()
        {
            _palindromeFinder = new PalindromeFinder();
        }

        [TestMethod]
        public void ReturnsEmptyListWhenStringIsEmpty()
        {
            var result = _palindromeFinder.GetPalindromes(string.Empty);
            Assert.AreEqual(0, result.Count);
        }
        [TestMethod]
        public void ReturnsEmptyListWhenStringWhiteSpace()
        {
            var result = _palindromeFinder.GetPalindromes("  ");
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ReturnsEmptyListWhenStringIsNull()
        {
            var result = _palindromeFinder.GetPalindromes(null);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ReturnsOneCharacterPalindromeWhenStringIsOnlyOneCharacter()
        {
            var result = _palindromeFinder.GetPalindromes("a");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("a", result[0].Text);
        }

        [TestMethod]
        public void ReturnsTheStringItselfWhenTheGivenStringIsPalindrome()
        {
            var result = _palindromeFinder.GetPalindromes("abba");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("abba", result[0].Text);
            Assert.AreEqual(0, result[0].Index);
            Assert.AreEqual(4, result[0].Length);
        }

        [TestMethod]
        public void ReturnsTwoPalindromesWhenThereAreOnlyTwoPalindromesInTheString()
        {
            var result = _palindromeFinder.GetPalindromes("abbaeme");

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("abba", result[0].Text);
            Assert.AreEqual("eme", result[1].Text);
        }


        [TestMethod]
        public void ReturnsLongestThreePalindromesWhenThereAreMoreThanThreePalindromesInTheString()
        {
            var result = _palindromeFinder.GetPalindromes("aakabakbbtaatccataddcec");
            Assert.AreEqual(1, result.Count(r => r.Text == "kabak"));
            Assert.AreEqual(1, result.Count(r => r.Text == "taat"));
            Assert.AreEqual(1, result.Count(r => r.Text == "ata"));

            Assert.AreEqual(0, result.Count(r => r.Text == "cec"));
        }

        [TestMethod]
        public void ReturnsPalindromesInDecendingOrderOfLength()
        {
            var result = _palindromeFinder.GetPalindromes("sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop");
            Assert.AreEqual("hijkllkjih", result[0].Text);
            Assert.AreEqual("defggfed", result[1].Text);
            Assert.AreEqual("abccba", result[2].Text);
        }

        [TestMethod]
        public void DoesNotReturnSubPalindormes()
        {
            var result = _palindromeFinder.GetPalindromes("kabak");

            // not returns 'aba' which is in another palindrone
            Assert.AreEqual(0, result.Count(r => r.Text == "aba"));
            // returns only larger palindrome
            Assert.AreEqual(1, result.Count(r => r.Text == "kabak"));
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void ReturnsUniqueListOfPalindrones()
        {
            var result = _palindromeFinder.GetPalindromes("abbackabba");
            Assert.AreEqual(1, result.Count(r => r.Text == "abba"));
        }

        [TestMethod]
        public void IgnoreSpaceInString()
        {
            var result = _palindromeFinder.GetPalindromes("ka b ak");
            Assert.AreEqual(1, result.Count(r => r.Text == "kabak"));
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void ShouldBeCaseSensitive()
        {
            var result = _palindromeFinder.GetPalindromes("abbackABBA");
            Assert.AreEqual(1, result.Count(r => r.Text == "abba"));
            Assert.AreEqual(1, result.Count(r => r.Text == "ABBA"));
        }
    }
}
