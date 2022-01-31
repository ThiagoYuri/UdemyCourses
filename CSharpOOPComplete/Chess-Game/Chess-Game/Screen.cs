using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using board;
using chess;

namespace Chess_Game
{
    class Screen
    {
        //Print Board
        public static void PrintOutBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write((8 - i) + "  ");
                for (int j = 0; j < board.columns; j++)
                {                    
                    if (board.getPiece(new Position(i, j)) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimirPeca(board.getPiece(new Position(i,j)));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a b c d e f g h ");
        }

        public  static PositionChess readPositionChess()
        {
            string s = Console.ReadLine();
            char line = s[0];
            int column = int.Parse(s[1].ToString());
            return new PositionChess(line, column);
        }

        public static void imprimirPeca(Piece piece)
        {
            if (piece.color == ColorPiece.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
