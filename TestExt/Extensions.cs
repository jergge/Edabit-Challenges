using System;
using System.Collections.Generic;
using System.Collections;

public static class Extensions
{
    public static void ConsolePrint (this IList list, int indent = 0)
    {
        string firstLine = "";
        for (int i = 0; i < indent; i++)
        {
            firstLine += " ";
        }
        firstLine += "List: {";
        Console.WriteLine(firstLine);

        foreach ( var item in list )
        {
            if (item is IList ilist)
            {
                ilist.ConsolePrint(indent + 4);
            } else if (item is not null)
            {
                string outputBuffer = "";
                for (int i = 0; i < indent+2; i++)
                {
                    outputBuffer += " ";
                }
                outputBuffer += item.GetType() + ": ";
                outputBuffer += item.ToString();
                Console.WriteLine(outputBuffer);
            }
        }

        string lastLine = "";
        for (int i = 0; i < indent; i++)
        {
            lastLine += " ";
        }
        lastLine += "}";
        Console.WriteLine(lastLine);
    }

    public static T Random<T>(this List<T> list)
    {
        if ( list.Count == 0 )
        {
            throw new IndexOutOfRangeException("Cannot return a random element of an empty List<T>");
        }
        return list[ new Random().Next(list.Count -1) ];
    }

    public static List<List<T>> Redcution<T>(this List<T> list, int n)
    {
        if ( n > list.Count )
        {
            throw new ArgumentOutOfRangeException("List length must be greater than the argument(n) of n-wise reductions");
        }

        List<List<T>> reductionsList = new List<List<T>>();

        for (int i = 0; i < list.Count - n + 1; i++)
        {
            List<T> reduction = new List<T>();

            for (int j = 0; j < n; j++)
            {
                reduction.Add(list[i+j]);
            }

            //Console.WriteLine(reduction.ToString());
            reductionsList.Add(reduction);
        }

        return reductionsList;
    }

}