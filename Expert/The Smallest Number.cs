// The Smallest Number
// Given a positive integer n, implement a function that finds the smallest number that is evenly divisible by the integers 1 through n inclusive. Return value as a string.

// Examples
// Smallest(1) ➞ "1"

// Smallest(5) ➞ "60"

// Smallest(10) ➞ "2520"

// Smallest(20) ➞ "232792560"


// Notes
// You will need to cope with numbers larger than Int64.MaxValue (see Resources).

public static class SmallestNumber
{
    /// <summary>
    /// Compute the smallest integer that is divisible by the integers 1 through n inclusive
    /// </summary>
    /// <param name="n">Inclusive upper integer</param>
    /// <returns>The smallest value as a string</returns>
    public static string Smallest(ulong n)
    {
        ulong currentN = 1;

        ulong currentLCM = 1;

        while ( currentN <= n)
        {
            currentLCM = LCM(currentN, currentLCM);
            currentN++;
        }

        return currentLCM.ToString();
    }

    static ulong LCM(ulong a, ulong b)
    {
        ulong value = b * (a / GCD(a, b));
        //Console.WriteLine("LCM is: " + value);
        return value;
    }

    static ulong GCD(ulong a, ulong b)
    {
        if (b == 0)
        {
            //Console.WriteLine("GCD is: " + a);
            return a;
        } else
        {
            return GCD(b, a%b);
        }
    }
}