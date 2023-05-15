    // ReverseAndNot
    // Write a function that takes an integer i and returns a string with the integer backwards followed by the original integer.

    // To illustrate:

    // "123"
    // We reverse "123" to get "321" and then add "123" to the end, resulting in "321123".

    // Examples
    // ReverseAndNot(123) ➞ "321123"

    // ReverseAndNot(152) ➞ "251152"

    // ReverseAndNot(123456789) ➞ "987654321123456789"
    // Notes
    // i is a non-negative integer.
    // Bonus: By using System.Linq this should be completed in one line of code.
using System;
public class ReverseAndNot
{
    public static int DoThing(int input)
    {
        int length = input.ToString().Length;

        int reversedNumber = 0;

        for (int i = 0; i < length; i++)
        {
            int temp = input / (int)(Math.Pow(10, i));
            // Console.WriteLine("temp: " + temp);

            int lastDigit = temp % 10;
            // Console.WriteLine(lastDigit);

            int digitToAdd = lastDigit * (int)Math.Pow(10, length - i -1);
            // Console.WriteLine(digitToAdd);

            reversedNumber += digitToAdd;
        }

        //Console.WriteLine(reversedNumber);
        int mul = (int)Math.Pow(10, length);
        //Console.WriteLine(mul);

        reversedNumber = reversedNumber * mul;
        //Console.WriteLine(reversedNumber);
        
        reversedNumber += input;
        //Console.WriteLine(reversedNumber);

        return reversedNumber;
    }
}