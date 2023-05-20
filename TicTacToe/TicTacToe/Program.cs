using System;
using System.Threading;

namespace TicTacToe
{
     class Program
    {
        static char[] spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag;

        static void DrawBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |   {2}  ", spaces[0], spaces[1], spaces[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |   {2}  ", spaces[3], spaces[4], spaces[5]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |   {2}  ", spaces[6], spaces[7], spaces[8]);
            Console.WriteLine("     |     |     ");
        }

        static int CheckWin()
        {
            if (spaces[0] == spaces[1] &&
                spaces[1] == spaces[2] ||
                spaces[3] == spaces[4] &&
                spaces[4] == spaces[5] ||
                spaces[6] == spaces[7] &&
                spaces[7] == spaces[8] ||
                spaces[0] == spaces[3] &&
                spaces[3] == spaces[6] ||
                spaces[1] == spaces[4] &&
                spaces[4] == spaces[7] ||
                spaces[2] == spaces[5] &&
                spaces[5] == spaces[8] ||
                spaces[0] == spaces[4] &&
                spaces[4] == spaces[8] ||
                spaces[2] == spaces[4] &&
                spaces[4] == spaces[6])
            {
                return 1;
            }
            else if (spaces[0] != '1' &&
                     spaces[1] != '2' &&
                     spaces[1] != '3' &&
                     spaces[1] != '4' &&
                     spaces[1] != '5' &&
                     spaces[1] != '6' &&
                     spaces[1] != '7' &&
                     spaces[1] != '8' &&
                     spaces[1] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        static void DrawX(int pos)
        {
            spaces[pos] = 'X';
        }

        static void DrawO(int pos)
        {
            spaces[pos] = 'O';
        }
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1: X and Player 2: O" + "\n");
                if (player % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("player 2's turn");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Blue;
                    Console.WriteLine("Player 1's turn");
                    Console.ResetColor();
                }

                Console.WriteLine("\n");
                DrawBoard();
                choice = int.Parse(Console.ReadLine()) - 1;

                if (spaces[choice] != 'X' &&
                    spaces[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {

                        DrawO(choice);
                    }
                    else
                    {
                        DrawX(choice);
                    }
                    player++;
                }
                else
                {
                    Console.WriteLine("Sorry thr row {0} is already marked with {1} \n", choice, spaces[choice]);
                    Console.WriteLine("Please wait 2 seconds board is loading again...");
                    Thread.Sleep(2000);
                }

                flag = CheckWin();
            } while (flag != 1 && flag != -1);

            Console.Clear();
            DrawBoard();

            if(flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) +1);
            }
            else
            {
                Console.WriteLine("Tie Game");
            }

            Console.ReadLine();
        }
    }
}
