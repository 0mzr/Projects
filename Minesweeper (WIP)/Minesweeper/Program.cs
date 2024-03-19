/*
Simple minesweeper game
Made by 
Rules are simple
*/

using System;

class Minesweeper
{
    static char[,] board = new char[10, 10]; // initialise array
    static Random rnd = new Random();
    static void Main(string[] args)
    {
        Console.WriteLine("Minesweeper. Press Enter to start."); // welcome message
        Console.ReadLine();
        while (true)
        { 
            Console.Clear();
            placeMines();
            createBoard();
            printBoard();
            Console.ReadLine();
        }
    }

    static void turn()
    {

    }
    static void createBoard() // initialises playing board (from battleships)
    {
        for (int row = 0; row < 10; row++)
        {
            for (int col = 0; col < 10; col++)
            {
                board[row, col] = ' ';
            }
        }
    }

    static void placeMines()
    {
        int placeCount = 0;
        while (true)
        {
            int col = rnd.Next(0, 10);
            int row = rnd.Next(0, 10);
            if (board[row, col] == 'X')
            {
                continue;
            }
            else
            {
                placeCount++;
                if (placeCount == 10)
                {
                    break;
                }
                board[row, col] = 'X';
            }
            printBoard(false); // prints board with 'X' (for testing)
            Console.Write($"({row}, {col+1})");
            Console.ReadLine();
        }
    }

    static void printBoard(bool isHidden = true) // prints out board (from battleships)
    {
        Console.WriteLine("  A B C D E F G H I J");
        for (int row = 0; row < 10; row++)
        {
            Console.Write(row);
            for (int col = 0; col < 10; col++)
            {
                char charCheck = board[row, col];
                if (isHidden == true && (board[row, col] == 'X'))
                {
                    charCheck = ' ';
                }
                Console.Write(" " + charCheck + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static string turn(char[,] tboard)
    {
        int row;
        int col;
        while (true)
        {
            Console.Write("Enter target position (e.g., A3): ");
            string position = Console.ReadLine().ToUpper();

            if (position.Length != 2 || !char.IsLetter(position[0]) || !char.IsDigit(position[1]))
            {
                Console.WriteLine("Invalid input. Use the format: Letter, Number (e.g., A3).");
                continue;
            }

            row = position[1] - '0';
            col = position[0] - 'A';

            if (row < 0 || row >= 10 || col < 0 || col >= 10)
            {
                Console.WriteLine("Invalid position. Row must be between A and F and column must be between 0 and 9.");
                continue;
            }

            if (tboard[row, col] == 'X')
            {
                tboard[row, col] = 'X'; // "X" is hit
                return "Game Over!";
            }
            else if (tboard[row, col] == 'X')
            {
                Console.WriteLine("You've already hit this position. Try again.");
            }
            else if (tboard[row, col] == 'O')
            {
                tboard[row, col] = 'M'; // "M" is a miss
                return "Safe!";
            }
            else
            {
                Console.WriteLine("Invalid position. You can't hit this spot again.");
            }
        }
    }

    /*static void neighbourCheck(row, col)
    {
        if(col == false)
        {
            continue;
        }
    }*/
}
