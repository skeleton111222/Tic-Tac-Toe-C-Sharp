using System;

public class TicTacToe
{
    static char[] board = { '1','2','3','4','5','6','7','8','9' };
    static char currentPlayer = 'X';
    public static void Main(string[] args)
    {
        int choice;
        bool gameOver = false;

        do
        {
            Console.Clear();
            DrawBoard();
            
            Console.WriteLine ($"\n{currentPlayer} Turn");
            Console.WriteLine ("\nEnter where you want to place: ");
            bool validInput = int.TryParse(Console.ReadLine(), out choice);
            if (!validInput|| choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O'){
                Console.WriteLine("\nInvalid move!");
                continue;
            }
            board[choice - 1] = currentPlayer;
            if (CheckWin())
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine($"\nPlayer {currentPlayer} wins!");
                gameOver = true;
            }
            else if (CheckDraw())
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("\nDraw!");
                gameOver = true;
            }
            else
            {
                if(currentPlayer == 'X')
                {
                    currentPlayer ='O';
                }
                else{
                    currentPlayer= 'X';
                }
            }
        }while(gameOver==false);
    }
    static void DrawBoard()
    {
        Console.WriteLine("...................");
        Console.WriteLine(":     |     |     :");
        Console.WriteLine($":  {board[0]}  |  {board[1]}  |  {board[2]}  :");
        Console.WriteLine(":_____|_____|_____:");
        Console.WriteLine(":     |     |     :");
        Console.WriteLine($":  {board[3]}  |  {board[4]}  |  {board[5]}  :");
        Console.WriteLine(":_____|_____|_____:");
        Console.WriteLine(":     |     |     :");
        Console.WriteLine($":  {board[6]}  |  {board[7]}  |  {board[8]}  :");
        Console.WriteLine(":     |     |     :");
        Console.WriteLine("...................");
    }
    static bool CheckWin()
    {
        int[,] winCombos =
        {
            {0,1,2},{3,4,5},{6,7,8},
            {0,3,6},{1,4,7},{2,5,8},
            {0,4,8},{2,4,6}
        };

        for (int i = 0; i < winCombos.GetLength(0); i++)
        {
            if (board[winCombos[i, 0]] == currentPlayer &&
                board[winCombos[i, 1]] == currentPlayer &&
                board[winCombos[i, 2]] == currentPlayer)
                return true;
        }
        return false;
    }
    static bool CheckDraw()
    {
        foreach (char c in board)
        {
            if (c != 'X' && c != 'O')
                return false;
        }
        return true;
    }
}