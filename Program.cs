using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        public static char playerSignature = ' ';
        //will count each turn once this ==10 game is a draw.
        static int turns = 0;
        static char[] ABoard =
        {
            '1', '2', '3','4', '5', '6','7', '8', '9'
        }; //char array variable to store player input in the selected boxes.
        
        //this resets the board.
        public static void BoardReset()
        {
            char[] ABoardInitialize =
            {
                '1', '2', '3','4', '5', '6','7', '8', '9'
            };

            ABoard = ABoardInitialize;
            DrawBoard();
            turns = 0;
               
        }

        public static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", ABoard[0], ABoard[1], ABoard[2]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", ABoard[3], ABoard[4], ABoard[5]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", ABoard[6], ABoard[7], ABoard[8]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
        } //Draws the player board to the terminal.
        
        //this covers the game basic rules 
        public static void introduction()
        {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(" _______  ___   _______    _______   _______   _______    _______   _______   _______");
        Console.WriteLine("|       ||   | |       |  |       | |   _   | |       |  |       | |       | |       |");
        Console.WriteLine("| _   _ ||   | |       |  |_     _| |  |_|  | |       |  |_     _| |   _   | |    ___|");
        Console.WriteLine("  |   |  |   | |       |    |   |   |       | |       |    |   |   |  | |  | |   |___");
        Console.WriteLine("  |   |  |   | |      _|    |   |   |       | |      _|    |   |   |  |_|  | |    ___|");
        Console.WriteLine("  |   |  |   | |     |_|    |   |   |   _   | |     |_|    |   |   |       | |   |___");
        Console.WriteLine("  |___|  |___| |_______|    |___|   |__| |__| |_______|    |___|   |_______| |_______|");
        Console.ResetColor();
        Console.WriteLine("Welcome to tic tac toe, please press any key to continue");
            Console.ReadKey();
            Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("RULES");
        Console.ResetColor();
        Console.WriteLine("Tic Tac toe is a two player turn based game." +
                          "\nThe aim is to win either with 3 X's or 3 O's." +
                          "\nThis can be either Horizontal, Vertical or Diagonal");
        Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            
        }

        static void Main(sting[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;

            introduction();

            do
            {
                if (player == 2)
                {
                    player = 1;
                    XorO(player, input);
                }
                else if (player == 1)
                {
                    player = 2;
                    XorO(player, input);
                }

                DrawBoard();
                turns++;

                //Checks game status if win
                HorizontalWin();
                VerticalWin();
                DiagonalWin();

                if(turns == 10)
                {
                    Draw();
                }

                do
                {
                    Console.WriteLine("\nReady Player {0}: It's your move!", player);

                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }

                }
            }
        }
      
    }
}
