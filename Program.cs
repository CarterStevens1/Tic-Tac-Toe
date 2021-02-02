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
        public static void Introduction()
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

        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;

            Introduction();

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

                if (turns == 10)
                {
                    Draw();
                }
                //Gameplay loop. This controls player turns and overrides the array with player choice.
                do
                {
                    Console.WriteLine("\nReady Player {0}: It's your move!", player);

                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid number!");
                    }
                    if ((input == 1) && (ABoard[0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (ABoard[1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (ABoard[2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (ABoard[3] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (ABoard[4] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (ABoard[5] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (ABoard[6] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (ABoard[7] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (ABoard[8] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("Please try again...");
                        inputCorrect = false;
                    }
                } while (!inputCorrect);
            } while (true);

        }

        //controlls is the player is X or O
        public static void XorO(int player, int input)
        {
            if (player == 1) playerSignature = 'X';
            else if (player == 2) playerSignature = 'O';

            switch (input)
            {
                case 1: ABoard[0] = playerSignature; break;
                case 2: ABoard[1] = playerSignature; break;
                case 3: ABoard[2] = playerSignature; break;
                case 4: ABoard[3] = playerSignature; break;
                case 5: ABoard[4] = playerSignature; break;
                case 6: ABoard[5] = playerSignature; break;
                case 7: ABoard[6] = playerSignature; break;
                case 8: ABoard[7] = playerSignature; break;
                case 9: ABoard[8] = playerSignature; break;
            }

        }
        public static void HorizontalWin()
        {
            char[] playerSignatures = { 'X', 'O' };

            foreach (char playerSignatue in playerSignatures)
            {
                if (((ABoard[0] == playerSignatue) && (ABoard[1] == playerSignatue) && (ABoard[2] == playerSignatue))
                    || ((ABoard[3] == playerSignatue) && (ABoard[4] == playerSignatue) && (ABoard[5] == playerSignatue))
                    || ((ABoard[6] == playerSignatue) && (ABoard[7] == playerSignatue) && (ABoard[8] == playerSignatue)))
                {
                    Console.Clear();
                    if (playerSignatue == 'X')
                    {
                        Console.WriteLine("Player 1, Thats a Horizontal Win!");
                    }
                    else if (playerSignatue == 'O')
                    {
                        Console.WriteLine("Player 2, Thats a horizontal win!");
                    }


                   
                    Console.WriteLine("Please press any key to reset the game");
                    Console.ReadKey();
                    BoardReset();

                    break;
                }
            }
        } //Method is called to check for a horizontal win.  

        public static void VerticalWin()
        {
            char[] playerSignatures = { 'X', 'O' };

            foreach (char playerSignatue in playerSignatures)
            {
                if (((ABoard[0] == playerSignatue) && (ABoard[3] == playerSignatue) && (ABoard[6] == playerSignatue))
                    || ((ABoard[1] == playerSignatue) && (ABoard[4] == playerSignatue) && (ABoard[7] == playerSignatue))
                    || ((ABoard[2] == playerSignatue) && (ABoard[5] == playerSignatue) && (ABoard[8] == playerSignatue)))
                {
                    Console.Clear();
                    if (playerSignatue == 'X')
                    {
                        Console.WriteLine("Player 1, that's a vertical win!\n");
                    }
                    else
                    {
                        Console.WriteLine("Player 2, that's a vertical win!");
                    }

                    
                    Console.WriteLine("Please press any key to reset the game");
                    Console.ReadKey();
                    BoardReset();

                    break;
                }
            }
        } //Method is called to check for a vertical win.  

        public static void DiagonalWin()
        {
            char[] playerSignatures = { 'X', 'O' };

            foreach (char playerSignatue in playerSignatures)
            {
                if (((ABoard[0] == playerSignatue) && (ABoard[4] == playerSignatue) && (ABoard[8] == playerSignatue))
                    || ((ABoard[6] == playerSignatue) && (ABoard[4] == playerSignatue) && (ABoard[2] == playerSignatue)))
                {
                    Console.Clear();
                    if (playerSignatue == 'X')
                    {
                        Console.WriteLine("Player 1 that's a diagonal win! ");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 that's a diagonal win!");
                    }

                    
                    Console.WriteLine("Please press any key to reset the game");
                    Console.ReadKey();
                    BoardReset();

                    break;
                }
            }
        } //Method is called to check for a diagonal win.

        public static void Draw()
        {

            {
                Console.WriteLine("Aw gosh... it's a draw." +
                                  "\nPlease press any key to reset the game and try again!");
                Console.ReadKey();
                BoardReset();

            }
        } //Method is called to check if the game is a draw.

       
    }
}