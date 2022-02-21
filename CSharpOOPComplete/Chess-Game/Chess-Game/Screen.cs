using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using board;
using chess;
using Chess_Game.Chess;

namespace Chess_Game
{
    class Screen
    {
        //Print Board
        public static void printGame(ChessMatch chessMatch) {
            printOutBoard(chessMatch.board);
            Console.WriteLine();
            printPiecesCaptured(chessMatch);
            Console.WriteLine();
            Console.WriteLine("Turno: " + chessMatch.shift);
            if (!chessMatch.finalized) { 
                Console.WriteLine("Aguardando jogada: " + chessMatch.playerNow);
                if (chessMatch.check)
                {
                    Console.WriteLine("Xeque");
                }
                Console.WriteLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Xeque-Mate");
                Console.WriteLine("Vencedor: " + chessMatch.playerNow);
            }
        }

        private static void printPiecesCaptured(ChessMatch chessMatch)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            printGroup(chessMatch.piecesCaptured(ColorPiece.White));
            Console.WriteLine();
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pretas: ");
            printGroup(chessMatch.piecesCaptured(ColorPiece.Black));
            Console.ForegroundColor = aux;
        }

        private static void printGroup(HashSet<Piece> group)
        {
            Console.Write("[");
            foreach(var x in group)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void printOutBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write((8 - i) + "  ");
                for (int j = 0; j < board.columns; j++)
                {                                         
                        writePice(board.getPiece(new Position(i,j)));                     
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("   a b c d e f g h ");
        }

        public static void printOutBoard(Board board, bool[,] positionPosible)
        {
            ConsoleColor backgroundDefault = Console.BackgroundColor;
            ConsoleColor backgroundChanged = ConsoleColor.DarkGray;
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write((8 - i) + "  ");
                for (int j = 0; j < board.columns; j++)
                {
                    if(positionPosible[i,j]){
                        Console.BackgroundColor = backgroundChanged;
                    }
                    writePice(board.getPiece(new Position(i, j)));
                    Console.BackgroundColor = backgroundDefault;
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

        public static void writePice(Piece piece)
        {
            if(piece == null ) Console.Write("- ");
            else
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
                Console.Write(" ");
            }
           
        }
    }
}
