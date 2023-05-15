// Primal Strength

// In number theory, a prime number is balanced if it is equidistant from the prime before it and the prime after it. It is therefore the arithmetic mean of those primes. For example, 5 is a balanced prime, two units away from 3, and two from 7. 211 is 12 units away from the previous prime, 199, and 12 away from the next, 223.

// A prime that is greater than the arithmetic mean of the primes before and after it is called a strong prime. It is closer to the prime after it than the one before it. For example, the strong prime 17 is closer to 19 than it is to 13 (see note at bottom).

// A prime that is lesser than the arithmetic mean of the primes before and after it is called weak prime. For example, 19.

// Create a function that takes a prime number as input and returns "Strong" if it is a strong prime, "Weak" if it is a weak prime, or "Balanced".
// Examples

// PrimalStrength(211) ➞ "Balanced"

// PrimalStrength(17) ➞ "Strong"

// PrimalStrength(19) ➞ "Weak"

// Notes

// This definition of strong primes is not to be confused with strong primes as defined in cryptography, which are much more complicated than this. You are all welcome to make a challenge based on cryptographically strong primes.

using System;
public static class PrimalStrength
{
    static int GetNextPrime(int input)
    {
        int testCase = input+1;

        while (true)
        {
            if (IsPrime(testCase))
            {
                Console.WriteLine("the next prime up from " + input + " is: " + testCase);
                return testCase;
            }

            testCase++;
        }
    }

    static int GetPreviousPrime(int input)
    {
        int testCase = input-1;

        while (true)
        {
            if (IsPrime(testCase))
            {
                Console.WriteLine("the next prime down from " + input + " is: " + testCase);
                return testCase;
            }

            testCase--;
        }
    }

    static bool IsPrime(int input)
    {
        int maxTest = (int)Math.Ceiling( Math.Sqrt(input) );

        for (int i = 2; i <= maxTest; i++)
        {
            if (input % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static string Evaluate(int primeInput)
    {
        if (!IsPrime(primeInput))
        {
            return "The number you input is not a prime";
        }

        int deltaUp = GetNextPrime(primeInput) - primeInput;
        int deltaDown = primeInput - GetPreviousPrime(primeInput);

        if (deltaDown == deltaUp)
        {
            return primeInput + " is a Balanced Prime";
        } else {
            return (deltaUp > deltaDown) ? primeInput + " is a Strong Prime" : primeInput + " is a Weak Prime";
        }
    }
}