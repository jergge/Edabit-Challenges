// Kaprekar's Constant

// 6174 is known as one of Kaprekar's constants, after the Indian mathematician D. R. Kaprekar. Number 6174 is notable for the following rule:

//     Take any four-digit number, using at least two different digits (leading zeros are allowed).
//     Arrange the digits in descending and then in ascending order to get two four-digit numbers, adding leading zeros if necessary.
//     Subtract the smaller number from the bigger number.
//     Go back to step 2 and repeat.

// The above process, known as Kaprekar's routine, will always reach its fixed point, 6174, in at most 7 iterations. Once 6174 is reached, the process will continue yielding 7641 – 1467 = 6174. For example, choose 3524:

// 5432 – 2345 = 3087
// 8730 – 0378 = 8352
// 8532 – 2358 = 6174
// 7641 – 1467 = 6174

// Write a recursive function that will return the number of times it will take to get from a number to 6174 (the above example would equal 3).

// (1)5432 – 2345 = 3087,
// (2)8730 – 0378 = 8352,
// (3)8532 – 2358 = 6174

// 495 would produce the following: 4950 to 9540 - 459, 9081 to 9810 - 189, 9621 to 9621 - 1269, 8352 to 8532 - 2358 answer: 4

// For a 2 digit number, the following would be produced (stating with number 10 -> 100):

// 100 to 100 - 1, 990 to 990 - 99, 8910 to 9810 - 189, 9621 to 9621 - 1269, 8352 to 8532 - 2358 answer: 5
// Examples

// Kaprekar(6621) ➞ 5

// Kaprekar(6554) ➞ 4

// Kaprekar(1234) ➞ 3

// Notes

// If the subtracted number is less than 1000, add an extra zero to that number. The number 1111 will equal 0000, so this number (1111) is invalid. If you're still unclear, please check the comments section.

using System;
using System.Collections.Generic;
public static class Kapreker
{
    static int targetNumber = 6174;
    //check less than 1000
    static int AddZeroIfLessThanThousand(int number)
    {
        Console.WriteLine("Input number is: " + number);
        return (number < 1000)? number * 10 : number;
    }

    //sort the digits to decending order
    static int SortDigitsDescending(int number)
    {
        List<int> list = new List<int>();
        int tempNumber = number;
        
        for (int i = 0; i < 4; i++)
        {
            list.Add(tempNumber % 10);
            tempNumber /= 10;
        }
        
        list.Sort();

        int sortedNumber = 0;

        for (int i = 0; i < list.Count; i++)
        {
            sortedNumber += list[i] * (int)Math.Pow(10, i);
        }

        Console.WriteLine("Sorted number is: " + sortedNumber);

        return sortedNumber;
    }

    //also make them in ascending order
    static int FlipNumberDigits(int number)
    {
        //Console.WriteLine("Number to flip: " + number);
        string numberString = number.ToString();
        //Console.WriteLine("String length is: " + numberString.Length);

        string newNumberString = "";

        for (int i = 3; i >= 0; i--)
        {
            newNumberString += numberString.Substring(i, 1);
        }

        Console.WriteLine("Flipped number is: " + newNumberString);

        return int.Parse(newNumberString);
    }

    static int Subtract(int a, int b)
    {
        Console.WriteLine("Delta (new number) is: " + (a-b));
        return a - b;
    }

    public static int Evaluate(int startingNumber, int count = 1)
    {

        int temp = startingNumber;
        temp = AddZeroIfLessThanThousand(temp);
        temp = SortDigitsDescending(temp);
        int flipped = FlipNumberDigits(temp);
        int result = Subtract(temp, flipped);
        Console.WriteLine("");
        if (result == targetNumber)
        {
            return count;
        } else {
            return Evaluate(result, count+1);
        }
    }
}