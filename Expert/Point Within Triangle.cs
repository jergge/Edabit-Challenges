// Point Within Triangle
// Create a function that takes four integer arrays of 2 elements. The first three are (x, y) coordinates of three corners of a triangle. Return True if the fourth array — the (x, y) coordinates of a test point — lies within the triangle, False if it doesn't.

// Examples
// WithinTriangle((1, 4), (5, 6), (6, 1), (4, 5)) ➞ True

// WithinTriangle((1, 4), (5, 6), (6, 1), (3, 2)) ➞ False

// WithinTriangle((-6, 2), (-2, -2), (8, 4), (4, 2)) ➞ True
// Notes
// N/A

//I'm changing the integer arrays requested into Vector2 because, well come on....
using System;
using System.Numerics;


public static class PointInTriangle
{
    /// <summary>
    /// Tests if a given point falls within the triangle
    /// </summary>
    /// <param name="a">The first vertex of the triangle</param>
    /// <param name="b">The second vertex of the triangle</param>
    /// <param name="c">The third vertex of the triangle</param>
    /// <param name="p">The test point</param>
    /// <returns></returns>
    public static bool Evaluate(Vector2 a, Vector2 b, Vector2 c, Vector2 p)
    {

        float c1 = PerpDotProduct(b-a, p-a);
        Console.WriteLine(c1);
        float c2 = PerpDotProduct(c-b, p-b);
        Console.WriteLine(c2);
        float c3 = PerpDotProduct(a-c, p-c);
        Console.WriteLine(c3);

        float signedSum = MathF.Sign(c1) + MathF.Sign(c2) + MathF.Sign(c3);
        Console.WriteLine(signedSum);

        if (MathF.Abs(signedSum) == 3)
        {
            Console.WriteLine("True");
            return true;
        }

        Console.WriteLine("False");
        return false;
    }

    static float PerpDotProduct(Vector2 a, Vector2 b)
    {
        return a.X * b.Y - a.Y * b.X;
    }
}