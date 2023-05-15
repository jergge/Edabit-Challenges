    // Simplified Fractions
    // Create a function that returns the simplified version of a fraction.

    // Examples
    // Simplify("4/6") ➞ "2/3"

    // Simplify("10/11") ➞ "10/11"

    // Simplify("100/400") ➞ "1/4"

    // Simplify("8/4") ➞ "2"
    // Notes
    // A fraction is simplified if there are no common factors (except 1) between the numerator and the denominator. 
    // For example, 4/6 is not simplified, since 4 and 6 both share 2 as a factor.
    // If improper fractions can be transformed into integers, do so in your code (see example #4).
using System;
public class SimplifiedFriactions
{
    public static string Simplify(string input)
    {
        string result = "";
        string errorResult = "-1";

        if (input.IndexOf("/") != input.LastIndexOf("/"))
        {
            return errorResult;
        }
        Console.WriteLine(input);
        string num = input.Substring(0, input.IndexOf("/"));
        Console.WriteLine(num);

        string denom = input.Substring(input.IndexOf("/")+1, input.Length - input.IndexOf("/") -1);
        Console.WriteLine(denom);

        float numerator = int.Parse(num);
        float denominator = int.Parse(denom);

        bool stillTrying = true;

        while (stillTrying)
        {
            if ( numerator == 1 || denominator == 1 )
            {
                break;
            }

            for (int i = 2; i <= Math.Min(numerator, denominator); i++)
            {
                //Console.WriteLine("testing i=" + i);
                if (numerator % i == 0 && denominator % i == 0)
                {
                    Console.WriteLine("Common Factor found: " + i);
                    //Console.WriteLine("num % cf = " + numerator + " % " + i + " = " + numerator % i);
                    //Console.WriteLine("denom % cf = " + denominator + " % " + i + " = " + numerator % i);
                    numerator /= i;
                    denominator /= i;
                    Console.WriteLine("new faction is: " + numerator + "/" + denominator);
                    break;
                }

                if (i == Math.Min(numerator, denominator))
                {
                    Console.WriteLine("tested up to i=" + i + " and there were no factors found!");
                    stillTrying = false;
                }
            }
        }
        int intPart = 0;
        if (denominator == 1 )
        {
            return numerator.ToString();
        }
        if (numerator >= denominator)
        {
            intPart = (int)Math.Floor(numerator/denominator);
            numerator = numerator - denominator * intPart;

            result = intPart + " " + numerator + "/" + denominator;
        } else
        {
            result = numerator + "/" + denominator;
        }


        return result;
    }
}