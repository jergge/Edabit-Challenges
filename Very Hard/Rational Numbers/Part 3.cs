// Rational Number Class (Part 3)
// In parts 1 and 2 of this 3 part challenge, you were asked to develop a Rational number struct. A rational number, as the name suggests, is a ratio between two natural numbers and is usually represented as a fraction in the form 1/2, 5/4, -79/13, etc.

// In part 1, the task was to create a C# struct with:

// A constructor which takes two integer parameters,
// two read-only properties Numerator and Denominator which return the numerator and denominator of the fraction respectively, reduced to there lowest common form.
// An override of the ToString() method giving a string representation of the rational number as described in the preceding paragraph.
// In part 2, the code was extended to:

// Allow arithmetic operations +, -, *, and / between rational numbers (including unary - operator)
// A Sign property that returned the sign of the fraction.
// Before completing this part, make sure your class meets the conditions described in parts 1 and 2. The best way to do this is to complete those challenges first and use the code to start this challenge.

// Task
// Your task now is to add comparison operators to your class so that rational numbers can be compared with each other using the comparison operators ==, !=, <, <=, > and >=. A further requirement is to implement implicit and explicit conversion to and from the C# decimal value type. For information on how to implement these functionalities, check the Resources tab.

// Examples
// var r1 = new Rational(1, 2);
// var r2 = new Rational(10, 8);
// var r3 = new Rational(2, -1);

// // Comparison operations
// r1 == r2 ➞ false
// r2 >= r1 ➞ true
// r2 != r3 ➞ true
// r1 == new Rational(17/34) ➞ true

// // Type conversion
// var r4 = (Rational)6.5572m; ➞ explicit conversion from decimal
// var d = (decimal)r2;  ➞ explicit conversion to decimal
// r4 == 6.5572m ➞ true (implicit conversion to decimal)
// r4.ToString() ➞ "16393/2500"
// Notes
// When overloading comparison operators == and !=, you'll also be expected to override the Equals() and GetHashCode() methods (see the Resources tab for further information).

using System;
public partial struct RationalNumber : IEquatable<RationalNumber>
{
    public static bool operator == (RationalNumber a, RationalNumber b)
        => (a.numerator == b.numerator && a.denominator == b.denominator) ? true : false;

    public static bool operator != (RationalNumber a, RationalNumber b)
        => !(a==b);

    public override bool Equals(object? obj)
    {
        if (!(obj is RationalNumber))
        {
            return false;
        }

        return Equals((RationalNumber)obj);
    }
    public bool Equals(RationalNumber other)
    {
        return (this==other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(numerator, denominator);
    }

    public static implicit operator decimal (RationalNumber a)
        => (decimal)a.numerator / (decimal)a.denominator;

    // public static explicit operator decimal (RationalNumber a)
    //     => (decimal)a.numerator / a.denominator;

    public static explicit operator RationalNumber (decimal other)
    {
        int length = other.ToString().Length;
        int locationOfDecimal = other.ToString().IndexOf(".");

        int lengthOfDecimal = length - locationOfDecimal - 1;

        return new RationalNumber ((int)((double)other*Math.Pow(10, lengthOfDecimal)), (int)Math.Pow(10, length-1));
    }

    public static bool operator < (RationalNumber a, RationalNumber b)
        => ((decimal)a < (decimal)b);

    public static bool operator > (RationalNumber a, RationalNumber b)
        => ((decimal)a > (decimal)b);

    public static bool operator <= (RationalNumber a, RationalNumber b)
        => ((decimal) a <= (decimal)b);

    public static bool operator >=(RationalNumber a, RationalNumber b)
        => ((decimal) a >= (decimal)b);
    
}