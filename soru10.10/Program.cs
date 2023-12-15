using System;
using System.Reflection.Metadata;
using System.Security;

namespace Odev
{
    internal class TicTacToe
    {
        internal static void Main()
        {
            TicTacToe game = new TicTacToe();
            game.letPlay();
        }

        private int[,] playGround;
        internal TicTacToe()
        {
            playGround = new int[3,3] {{0,0,0},{0,0,0},{0,0,0}};
        }

        internal bool Move(int[] square,ref bool player1)
        {
            bool illegalMove = false;
            if(playGround[square[0]-1,square[1]-1]==0)
            {
                if(player1)
                {
                    playGround[square[0]-1,square[1]-1]=1;
                }
                else
                {
                    playGround[square[0]-1,square[1]-1]=2;
                }
            }
            else
            {
                illegalMove = true;
                Console.Write("Illegal move\n");
            }
            if(!illegalMove)
                player1 = !player1;
            /*if(player1)
            {
                player1 = false;
            }
            else
            {
                player1 = true;
            }*/

            return illegalMove;
        }

        internal int[] askSquare()
        {
            int[] square;
            square = new int[] {0,0};
            Console.Write("\nRow: ");
            square[0] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Column: ");
            square[1] = Convert.ToInt32(Console.ReadLine());
            return square;
        }

        internal void letPlay()
        {
            bool win = false;
            bool illegalMove = false;
            bool player1= true;
            int[] square = new int[2];
            while(!win)
            {
                if(!illegalMove)
                {
                    square = askSquare();
                    illegalMove = Move(square,ref player1);
                    win = controlWin();
                    playGroundPrint();
                }
                while(illegalMove)
                {
                    square = askSquare();
                    illegalMove = Move(square,ref player1);
                    win = controlWin();
                    playGroundPrint();
                }
            }
        }
        
        internal bool controlWin()
        {
            bool win = false;
            for(int i=0;i<3;i++)
            {
                if(playGround[i,0]==playGround[i,1]&&playGround[i,1]==playGround[i,2]&&playGround[i,0]!=0)
                {
                    win = true;
                    Console.Write("Kazandin\n");
                    break;
                }
                else if(playGround[0,i]==playGround[1,i]&&playGround[2,i]==playGround[1,i]&&playGround[1,i]!=0)
                {
                    win = true;
                    Console.Write("Kazandin\n");
                    break;
                }
            }
            if(playGround[0,0]==playGround[1,1]&&playGround[1,1]==playGround[2,2]&&playGround[1,1]!=0)
            {
                win = true;
                Console.Write("Kazandin\n");
                return win;
            }
            else if(playGround[0,2]==playGround[1,1]&&playGround[1,1]==playGround[2,0]&&playGround[1,1]!=0)
            {
                win = true;
                Console.Write("Kazandin\n");
                return win;
            }
            return win;
        }

        internal void playGroundPrint()
        {
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<3;j++)
                {
                    Console.Write($"{playGround[i,j]} ");
                }
                Console.Write("\n");
            }
        }
    }

}
