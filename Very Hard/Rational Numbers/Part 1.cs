    // Rational Number Class (Part 1)
    // C# has several numeric types, including natural, real, and irrational numbers. 
    // One numeric type that's missing is a Rational number. 
    // A rational number, as the name suggests is a ratio between 2 natural numbers and is usually represented as a fraction in the form 1/2, 5/4, -79/13, etc.

    // Create a C# struct with a constructor that takes two integer parameters, either or both of which may be positive or negative. Include two read-only properties, Numerator and Denominator, that return the numerator and denominator of the fraction respectively of type int. Also, override the ToString() method to give a string representation of the rational number as described in the preceding paragraph.

    // Examples
    // var r1 = new Rational(1, 2);
    // r1.Numerator ➞ 1
    // r1.Denominator ➞ 2
    // r1.ToString() ➞ "1/2"

    // var r2 = new Rational(10, 8);
    // r2.Numerator ➞ 5
    // r2.Denominator ➞ 4
    // r2.ToString() ➞ "5/4"

    // var r3 = new Rational(2, -1);
    // r3.Numerator ➞ -2
    // r3.Denominator ➞ 1
    // r3.ToString() ➞ "-2"

    // var r4 = new Rational(-16, -64);
    // r4.Numerator ➞ 1
    // r4.Denominator ➞ 4
    // r4.ToString() ➞ "1/4"

    // Notes
    // The numerator may be zero, but if the denominator is zero an ArgumentException should be raised by the constructor function.
    // The Numerator and Denominator values should be reduced to their lowest possible integer values to maintain the ratio (examples r2 and r4 above).
    // If the resulting fraction is a whole number, the Denominator should return 1 but the ToString() method should only show the integer value (example r3 above).
    // If one of the values of numerator and denominator is negative, the sign is shown on the Numerator and the Denominator is positive (example r3 above).
    // If both the numerator and denominator are negative, the fraction is positive and both Numerator and Denominator are positive (example r4 above).
    // If the numerator is zero, the denominator should be set to 1, regardless of the value passed to the constructor.

using System;
public partial struct RationalNumber
{
    public readonly int numerator {get;}
    public readonly int denominator {get;}
    private int whole {get{
        int intPart = 0;
        if (Math.Abs(numerator) > denominator)
        {
            intPart = (numerator > 0)? (int)Math.Floor((float)numerator/(float)denominator) : (int)Math.Ceiling((float)numerator/(float)denominator);
        }
        return intPart;
    }}

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Rational Numbers cannot have a denominator of 0");
        }
        if (numerator == 0 )
        {
            this.numerator = 0;
            this.denominator = 1;
            return;
        }
        var reduced = ReduceByLCD( Math.Abs(numerator), Math.Abs(denominator) );

        if ( (numerator < 0) != (denominator < 0))
        {
            this.numerator = -reduced.numerator;
        } else{
            this.numerator = reduced.numerator;
        }
        this.denominator = reduced.denominator;
    }

    public override string ToString()
    {
        string tostring = "";
        if (whole != 0)
        {
            tostring += whole;

            int num = Math.Abs(numerator - whole * denominator);
            tostring += (num == 0) ? " " :  " " + num + "/" + denominator;
        } else{
            tostring += numerator + "/" + denominator;
        }
        return  tostring;
    }

    private static (int numerator, int denominator) ReduceByLCD(int num, int denom)
    {
        float numerator = num;
        float denominator = denom;

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
                    //Console.WriteLine("Common Factor found: " + i);
                    //Console.WriteLine("num % cf = " + numerator + " % " + i + " = " + numerator % i);
                    //Console.WriteLine("denom % cf = " + denominator + " % " + i + " = " + numerator % i);
                    numerator /= i;
                    denominator /= i;
                    //Console.WriteLine("new faction is: " + numerator + "/" + denominator);
                    break;
                }

                if (i == Math.Min(numerator, denominator))
                {
                    //Console.WriteLine("tested up to i=" + i + " and there were no factors found!");
                    stillTrying = false;
                }
            }
        }

        return ((int)numerator, (int)denominator);
    }
}