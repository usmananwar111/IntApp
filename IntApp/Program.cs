using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace IntApp
{
    class TicTacToe
    {
        static Dictionary<int, char> dict = new Dictionary<int, char>()
        {
            {1,'7'},{2,'8'},{3,'9'},
            {4,'4'},{5,'5'},{6,'6'},
            {7,'1'},{8,'2'},{9,'3'},
        };

        static char UserChoice;

        static string PlayerOne;
        static string PlayerTwo;

        //True - PlayerOne
        //False - PlayerTwo
        static bool PlayerTurn = false;

        //True - Winner Found
        //False - Draw
        //null - continue loop
        static bool? WinCheck = null;

        static void Main(string[] args)
        {
            Console.WriteLine("*******************\n" +
                              "*** Welcome...  ***\n" +
                              "*** Tic-Tac-Toe ***\n" +
                              "*******************\n");

            Console.WriteLine("Player One Enter Name: ");
            PlayerOne = Console.ReadLine();
            Console.WriteLine("\nPlayer Two Enter Name: ");
            PlayerTwo = Console.ReadLine();

            Random rand = new Random();

            //Random Player First Turn
            if (rand.Next(2) == 0)
                PlayerTurn = true;

            do
            {
                Console.Clear();
                Console.WriteLine("*******************\n" +
                                  "*** Tic-Tac-Toe ***\n" +
                                  "*******************\n");

                Console.WriteLine(PlayerOne + ": X\n" +
                                  PlayerTwo + ": O\n");

                if (PlayerTurn)
                {
                    Console.WriteLine(PlayerOne + " Turn\n");
                }
                else
                {
                    Console.WriteLine(PlayerTwo + " Turn\n");
                }

                DrawBoard();
                UserChoice = GetUserInput();

                char? dictComp = null;

                if (dict.ContainsKey(dict.FirstOrDefault(x => x.Value == UserChoice).Key))
                {
                    dictComp = dict[dict.FirstOrDefault(x => x.Value == UserChoice).Key];
                }

                // Mark X or O
                if (dictComp != null && dict[dict.FirstOrDefault(x => x.Value == UserChoice).Key] != 'X' && dict[dict.FirstOrDefault(x => x.Value == UserChoice).Key] != 'O')
                {
                    if (PlayerTurn)
                    {
                        dict[dict.FirstOrDefault(x => x.Value == UserChoice).Key] = 'X';
                        PlayerTurn = false;
                    }
                    else
                    {
                        dict[dict.FirstOrDefault(x => x.Value == UserChoice).Key] = 'O';
                        PlayerTurn = true;
                    }      
                }
                else //Handle Already Marked Space
                {
                    Console.WriteLine(UserChoice 
                                     + " is already chosen.\n"
                                     + "Select Available Place...");
                    Thread.Sleep(2500);
                }

                WinCheck = CheckWin();
            } while (WinCheck != true && WinCheck != false);


            Console.Clear();
            DrawBoard();

            if (WinCheck == true)
            {
                if (PlayerTurn)
                {
                    Console.WriteLine(PlayerTwo + " won!");
                }
                else
                {
                    Console.WriteLine(PlayerOne + " won!");
                }
            }
            else
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }

        public static char GetUserInput()
        {
            //User Input
            int x;
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Invalid Data! Enter a valid no:");
            }
            if (x > 9 || x < 1)
            {
                Console.WriteLine("Invalid Data! Enter a valid no:");
                x = GetUserInput();
            }
            return x.ToString()[0];
        }

        // Draw Tic-Tac-Toe Playing Board
        private static void DrawBoard()
        {
            Console.WriteLine("     |     |      \n"
                               + "  " + dict[1] + "  |  " + dict[2] + "  |  " + dict[3] + "\n"
                               + "_____|_____|_____ \n"
                               + "     |     |      \n"
                               + "  " + dict[4] + "  |  " + dict[5] + "  |  " + dict[6] + "\n"
                               + "_____|_____|_____ \n"
                               + "     |     |      \n"
                               + "  " + dict[7] + "  |  " + dict[8] + "  |  " + dict[9] + "\n"
                               + "     |     |      ");
        }
  
        private static bool? CheckWin()
        {
            //Horizontal Check
            if (dict[1].Equals(dict[2]) && dict[2].Equals(dict[3])) return true;
            else if (dict[4].Equals(dict[5]) && dict[5].Equals(dict[6])) return true;
            else if (dict[7].Equals(dict[8]) && dict[8].Equals(dict[9])) return true;

            //Vertical Check
            else if (dict[1].Equals(dict[4]) && dict[4].Equals(dict[7])) return true;
            else if (dict[2].Equals(dict[5]) && dict[5].Equals(dict[8])) return true;
            else if (dict[3].Equals(dict[6]) && dict[6].Equals(dict[9])) return true;

            //Diagonal
            else if (dict[1].Equals(dict[5]) && dict[5].Equals(dict[9])) return true;
            else if (dict[3].Equals(dict[5]) && dict[5].Equals( dict[7])) return true;
            
            //Draw Check
            else if (!dict[1].Equals('7') && !dict[2].Equals('8') && !dict[3].Equals('9') &&
                     !dict[4].Equals('4') && !dict[5].Equals('5') && !dict[6].Equals('6') &&
                     !dict[7].Equals('1') && !dict[8].Equals('2') && !dict[9].Equals('3')) return false;
            else return null;
        }

       

    }

}