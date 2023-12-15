using System;

namespace Game
{
    internal class Program
    {
        internal static void Main(string[] args)
        {}

        internal enum Result
        {
            Contiunes,
            ForbiddenMove,
            Win,
            Lose,
            Draw
        }
        internal class TicTacToe
        {
            private int[,] table;
            private int move_count;
            internal int MoveCount
            {
                get
                {
                    return move_count;
                }
                private set
                {
                    move_count = value;
                }
            }
            internal int Player
            {
                get
                {
                    return (move_count%2)+1;
                }
            }

            internal TicTacToe()
            {
                table = new int[,]{{0,0,0},{0,0,0},{0,0,0}};
                MoveCount = 0;
            }

            internal Result NewMove(int next_square)
            {
                int row = (next_square-1)/3 - 1;
                int column = (next_square+2)%3;

                if (table[row, column] != 0)
                {
                    return Result.ForbiddenMove;
                }

                MoveCount++;
                table[row, column] = Player;
                return Situation();
            }
            internal Result Situation()
            {
                for (int row = 0; row < 3; row++)
                {
                    if (table[row,0] == 0 || table[row,1] == 0 || table[row,2] == 0)
                    {
                        continue;
                    }

                    if (table[row,0] != table[row,1])
                    {
                        continue;
                    }
                    else if(table[row,1] != table[row,2])
                    {
                        continue;
                    }
                    else
                    {
                        if (table[row,0] == Player)
                        {
                            return Result.Win;
                        }
                        else
                        {
                            return Result.Lose;
                        }
                    }
                }
                for (int column = 0; column < 3; column++)
                {
                    if (table[0, column] == 0 || table[1, column] == 0 || table[2, column] == 0)
                    {
                        continue;
                    }

                    if (table[0, column] != table[1, column])
                    {
                        continue;
                    }
                    else if(table[1, column] != table[2, column])
                    {
                        continue;
                    }
                    else
                    {
                        if (table[0, column] == Player)
                        {
                            return Result.Win;
                        }
                        else
                        {
                            return Result.Lose;
                        }
                    }
                }
                if (table[0,0] == table[1,1])
                {
                    if (table[1,1] == table[2,2])
                    {
                        if (table[1,1] == 0)
                        {
                            return Result.Contiunes;
                        }
                        else if (table[1,1] == Player)
                        {
                            return Result.Win;
                        }
                        else
                        {
                            return Result.Lose;
                        }
                    }
                }
                if (table[0,2] == table[1,1])
                {
                    if (table[1,1] == table[2,0])
                    {
                        if (table[1,1] == 0)
                        {
                            return Result.Contiunes;
                        }
                        else if (table[1,1] == Player)
                        {
                            return Result.Win;
                        }
                        else
                        {
                            return Result.Lose;
                        }
                    }
                }
                int full_count = 9;
                for (int i = 1; i <= 9; i++)
                {
                    int row = (i-1)/3 - 1;
                    int column = (i+2)%3;

                    if (table[row, column] != 0)
                    {
                        full_count--;
                    }
                }
                if (full_count == 0)
                {
                    return Result.Draw;
                }

                return Result.Contiunes;
            }
        }
    }
}