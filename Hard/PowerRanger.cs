    // Create a function that takes in n, a, b and returns the number of positive values raised to the nth power that lie in the range [a, b], inclusive.

    // Examples
    // PowerRanger(2, 49, 65) ➞ 2
    // // 2 squares (n^2) lie between 48 and 65, 49 (7^2) and 64 (8^2)

    // PowerRanger(3, 1, 27) ➞ 3
    // // 3 cubes (n^3) lie between 1 and 27, 1 (1^3), 8 (2^3) and 27 (3^3)

    // PowerRanger(10, 1, 5) ➞ 1
    // // 1 value raised to the 10th power lies between 1 and 5, 1 (1^10)

    // PowerRanger(5, 31, 33) ➞ 1

    // PowerRanger(4, 250, 1300) ➞ 3
    // Notes
    // Remember that the range is inclusive.
    // a < b will always be true.
using System;
public class PowerRanger
{
    public static int CountPowers(int power, int lower, int upper)
    {
        int powerCount = 0;
        int squareNumber = 0;
        int n = 1;

        while (squareNumber <= upper)
        {
            squareNumber = (int)Math.Pow(n, power);
            if (squareNumber >= lower && squareNumber <= upper)
            {
                powerCount++;
                //Console.WriteLine(squareNumber);
            }
            n++;
        }

        return powerCount;
    }
}