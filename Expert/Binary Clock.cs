// Building a Binary Clock
// A binary clock displays the time of day in binary format. Modern binary clocks have six columns of lights; two for each of the hours, minutes and seconds. The photo below shows a binary clock displaying the time "12:15:45":



// The binary values increase from the bottom to the top row. Lights on the bottom row have a value of 1, lights on the row above have a value of 2, then 4 on the row above that, and finally a value of 8 on the top row. Any 24-hour time can be shown by switching on a certain combination of lights. For example, to show the time "10:37:49":



// You've decided to build your own binary clock, and you need to figure out how to light each row of the clock to show the correct time. Given the time as a string, return an array containing strings that shows the lights for each row of the clock (top to bottom). Use "1" for on, and "0" for off. Leave a blank space for any part of the row that doesn't require a light.

// Examples
// BinaryClock("10:37:49") ➞ new string[] {
//   " 0 0 1",
//   " 00110",
//   "001100",
//   "101101"
// }

// BinaryClock("18:57:31") ➞ new string[] {
//   " 1 0 0",
//   " 01100",
//   "000110",
//   "101111"
// }

// BinaryClock("10:50:22") ➞ new string[]  {
//   " 0 0 0",
//   " 01000",
//   "000011",
//   "101000"
// }
// Notes
// See the Resources section for more information on binary clocks.
using System;
public class BinaryClock
{
    public static void Display(string input)
    {
        Console.WriteLine(input);

        int hour = DateTime.Parse(input).Hour;
        int minute = DateTime.Parse(input).Minute;
        int seconds = DateTime.Parse(input).Second;

        int hourTens = hour / 10;
        int hourOnes = hour % 10;
        int minuteTens = minute / 10;
        int minuteOnes = minute % 10;
        int secondTens = seconds / 10;
        int SecondOnes = seconds % 10;


        string[] strings = new string[4];

        for (int k = 0; k < 4; k++)
        {
           string newStr = "";
           newStr += DecToBinStr(hourTens, 2, 2).Substring(3-k,1);
           newStr += DecToBinStr(hourOnes, 4, 0).Substring(3-k,1);
           newStr += DecToBinStr(minuteTens, 2, 2).Substring(3-k,1);
           newStr += DecToBinStr(minuteOnes, 4, 0).Substring(3-k,1);
           newStr += DecToBinStr(secondTens, 2, 2).Substring(3-k,1);
           newStr += DecToBinStr(SecondOnes, 4, 0).Substring(3-k,1);

           strings[k] = newStr; 
           //Console.WriteLine(newStr);
        }

        for (int k = strings.Length -1; k >= 0; k--)
        {
            Console.WriteLine(strings[k]);
        }


    }

    protected static string DecToBinStr(in int input, in int binaryLength, in int padding)
    {
        //Find highest power of 2 that's less than the input
        int i = 0;

        //Console.WriteLine(input);

        while( Math.Pow(2, i) <= input)
        {
            i++;
        }
        int pow = (int)Math.Pow(2, i-1);

        // Console.WriteLine(i-1 + " || " + pow);

        //int padding = maxLength - i;

        //Console.WriteLine(padding);

        string str = "";

        for (int j = 0; j < padding; j++)
        {
            str += " ";
        }

        int remaining = input;

        for (int p = binaryLength -1; p >= 0; p--)
        {
            if (remaining - (int)MathF.Pow(2, p) >= 0 )
            {
                str += "1";
                remaining -= (int)MathF.Pow(2, p);
            } else {
               str += "0";

            }
        } 
        
        // Console.WriteLine(str);

        return str;
    }
}