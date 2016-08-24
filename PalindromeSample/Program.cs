using System;
using StringHelper;

namespace PalindromeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the string that you want to find palindromes in:");
            var text = Console.ReadLine();

            var palindroneFinder = new PalindromeFinder();
            var palindroneList = palindroneFinder.GetPalindromes(text);

            foreach (var palindrone in palindroneList)
            {
                Console.WriteLine("Text: {0}, Index: {1}, Length: {2}", palindrone.Text, palindrone.Index, palindrone.Length);
            }
            Console.Read();
        }
    }
}
