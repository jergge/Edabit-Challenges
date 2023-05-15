        // Almost Palindrome
        // A string is an almost-palindrome if, by changing only one character, you can make it a palindrome. 
        // Create a function that returns true if a string is an almost-palindrome and false otherwise.

        // Examples
        // AlmostPalindrome("abcdcbg") ➞ true
        // // Transformed to "abcdcba" by changing "g" to "a".

        // AlmostPalindrome("abccia") ➞ true
        // // Transformed to "abccba" by changing "i" to "b".

        // AlmostPalindrome("abcdaaa") ➞ false
        // // Can't be transformed to a palindrome in exactly 1 turn.

        // AlmostPalindrome("1234312") ➞ false
        // Notes
        // Return false if the string is already a palindrome.
using System;
public class AlmostPalindrome
{
    public static bool IsAlmostPalindrome(string testString)
    {
        int halfLength = (int)MathF.Ceiling(testString.Length / 2f);
        int nonMatchCount = 0;

        for (int i = 0; i < halfLength; i++)
        {
            string first = testString.Substring(i,1);;
            string second = testString.Substring(testString.Length - i -1 ,1);

            // Console.WriteLine(first);
            // Console.WriteLine(second);

            if (!string.Equals(first, second))
            {
                nonMatchCount++;
            }
        }

        return (nonMatchCount == 1) ? true : false;
    }
}