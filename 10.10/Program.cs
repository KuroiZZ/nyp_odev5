using System;

namespace Game
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.PrintTable();
            Console.Write("\n\n");
            game.NewMove(1);
            game.PrintTable();
            Console.Write("\n\n");
            game.NewMove(5);
            game.PrintTable();
            Console.Write("\n\n");
            
            game.NewMove(7);
            game.PrintTable();
            Console.Write("\n\n");
            game.NewMove(8);
            game.PrintTable();
            Console.Write("\n\n");
            Console.Write("{1} {0}\n", game.NewMove(4), game.Player-1);
            game.PrintTable();
            Console.Write("\n\n");

            
        }
    }
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

        internal void PrintTable()
        {
            for(int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    Console.Write("{0} ", table[row,column]);
                }
                Console.Write("\n");
            }
        }

        internal Result NewMove(int next_square)
        {
            int row = (next_square-1)/3;
            int column = (next_square+2)%3;

            if (table[row, column] != 0)
            {
                return Result.ForbiddenMove;
            }

            table[row, column] = Player;
            Result result = Situation();
            MoveCount++;
            return result;
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
                int row = (i-1)/3;
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
