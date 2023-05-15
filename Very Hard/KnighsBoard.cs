    // Knights on a Board
    // Write a function that returns true if the knights are placed on a chessboard such that no knight can capture another knight. Here, 0s represent empty squares and 1s represent knights.

    // Examples
    // CannotCapture(new int[,] {
    // { 0, 0, 0, 1, 0, 0, 0, 0 },
    // { 0, 0, 0, 0, 0, 0, 0, 0 },
    // { 0, 1, 0, 0, 0, 1, 0, 0 },
    // { 0, 0, 0, 0, 1, 0, 1, 0 },
    // { 0, 1, 0, 0, 0, 1, 0, 0 },
    // { 0, 0, 0, 0, 0, 0, 0, 0 },
    // { 0, 1, 0, 0, 0, 0, 0, 1 },
    // { 0, 0, 0, 0, 1, 0, 0, 0 }
    // }) ➞ True

    // CannotCapture(new int[,] {
    // {1, 0, 1, 0, 1, 0, 1, 0},
    // {0, 1, 0, 1, 0, 1, 0, 1},
    // {1, 0, 1, 0, 1, 0, 1, 0},
    // {0, 0, 0, 1, 0, 1, 0, 1},
    // {1, 0, 0, 0, 1, 0, 1, 0},
    // {0, 0, 0, 0, 0, 1, 0, 1},
    // {1, 0, 1, 0, 1, 0, 1, 0},
    // {1, 0, 0, 1, 0, 0, 0, 1} 
    // }) ➞ False
    // Notes
    // Knights can be present in any of the 64 squares.
    // No other pieces except knights exist.
using System;
using System.Collections.Generic;
using System.Collections;
public class KnightsOnBoard
{
    public static bool CannotCapture(int[,] board)
    {
        return CheckKnights(board);
    }

    public static bool EvaluateRandom(bool outputBoard = false)
    {
        return false;
    }

    public static void FindKnights(int[,] board)
    {
        for (int y = 0; y < board.GetLength(0); y++)
        {
            for (int x = 0; x < board.GetLength(1); x++)
            {
                if ( board[y, x] == 1)
                {
                    Console.WriteLine("Knight found at: " + (x+1) + "," + (y+1));
                }
            }
        }
    }

    protected static bool CheckKnights(int[,] board)
    {
        Console.WriteLine(board.GetLength(1));
        Console.WriteLine(board.GetLength(0));
        for (int down = 0; down < board.GetLength(0); down++)
        {
            for (int across = 0; across < board.GetLength(1); across++)
            {
                if ( board[down, across] == 1)
                {
                    if ( CanCapture(board, across, down) )
                    {
                        Console.WriteLine("Knight at position x=" + (across+1) + " | y=" + (down+1) + " can make a capture");
                        return false;
                    }
                }
            }
            
        }
        return true;
    }

    protected static bool CanCapture(int [,] board, int across, int down)
    {
        List<(int x, int y)> coords = new List<(int, int)>
            {   (1, 2),
                (2, 1),
                (2, -1),
                (1, -2),
                (-1, -2),
                (-2, -1),
                (-2, 1),
                (-1, 2)
            };
        foreach (var coord in coords)
        {
            int testAcross = across + coord.x;
            int testDown = down + coord.y;
            //Console.WriteLine("Checking if knight can capture at " + (testAcross+1) + "," + (testDown+1) );
            //check board bounds
            if( testAcross >= board.GetLength(1) ||
                testAcross < 0 ||
                testDown >= board.GetLength(0) ||
                testDown < 0  )
                {
                    continue;
                }
            if (board[testDown, testAcross] == 1)
            {
                return true;
            }
            return false;  
        }
        return false;
    }
}