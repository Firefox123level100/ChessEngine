using System;
using System.Collections.Generic;
using System.Text;

namespace ChessEngine
{
    internal class Board
    {
        private string[][] BOARD = new string[][]
        {
            new string[8],
            new string[8],
            new string[8],
            new string[8],
            new string[8],
            new string[8],
            new string[8],
            new string[8]
        };

        private Dictionary<string, int[]> PiecesPositionHolder = new Dictionary<string, int[]>();
        private Dictionary<string, int> PiecesValueHolder = new Dictionary<string, int>();

        public Board(string BoardState)
        {
            SetUpBoard(BoardState);
        }

        public int[] DisplayBoard()
        {
            ConsoleKeyInfo KeyPressed;

            int[] SelectedPos = new int[] { 5, 6 };

            do
            {
                if (SelectedPos[0] < 0)
                {
                    SelectedPos[0] = BOARD.GetLength(0) - 1;
                }
                else if (SelectedPos[0] > BOARD.GetLength(0) - 1)
                {
                    SelectedPos[0] = 0;
                }

                if (SelectedPos[1] < 0)
                {
                    SelectedPos[1] = BOARD.Length - 1;
                }
                else if (SelectedPos[1] > BOARD.Length - 1)
                {
                    SelectedPos[1] = 0;
                }

                for (int i = 0; i < BOARD.Length; i++)
                {
                    for (int j = 0; j < BOARD.GetLength(0); j++)
                    {
                        string character = BOARD[i][j]; 

                        if ((i + j) % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                        }

                        if (SelectedPos[0] == j && SelectedPos[1] == i)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                        }

                        if (character.Contains('W'))
                        {
                            character = character.Remove(0, 1);
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (character.Contains('B'))
                        {
                            character = character.Remove(0, 1);
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.Write($" {character} ");

                    }
                    Console.Write("\n");
                }

                KeyPressed = Console.ReadKey(true);

                if (KeyPressed.Key == ConsoleKey.UpArrow || KeyPressed.Key == ConsoleKey.W)
                {
                    SelectedPos[1]--;
                }
                else if (KeyPressed.Key == ConsoleKey.DownArrow || KeyPressed.Key == ConsoleKey.S)
                {
                    SelectedPos[1]++;
                }
                else if (KeyPressed.Key == ConsoleKey.LeftArrow || KeyPressed.Key == ConsoleKey.A)
                {
                    SelectedPos[0]--;
                }
                else if (KeyPressed.Key == ConsoleKey.RightArrow || KeyPressed.Key == ConsoleKey.D)
                {
                    SelectedPos[0]++;
                }

                Console.Clear();

            } while (KeyPressed.Key != ConsoleKey.Enter);

            Console.ResetColor();

            return SelectedPos;
        }

        private void SetUpBoard(string boardstate)
        {
            string[] ArrangementByRow = boardstate.Split('/');
            string[] temp = new string[8];

            for (int i = 0; i < ArrangementByRow.Length; i++)
            {
                temp = ArrangementByRow[i].Split(' ');

                int indx = 0;

                for (int j = 0; j < temp.Length; j++)
                {
                    if (temp[j].Contains('O'))
                    {
                        for (int k = 0; k < temp[j][0] - '0'; k++)
                        {
                            BOARD[i][k + indx] = " ";
                        }

                        indx += temp[j][0] - '0';
                    }
                    else
                    {
                        BOARD[i][indx] = temp[j];
                        indx++;
                    }
                }

            }
        }

    }
}
