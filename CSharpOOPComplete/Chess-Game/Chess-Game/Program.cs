using board;
using chess;
using Chess_Game.Chess;
using System;
using System.Drawing;

namespace Chess_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.finalized)
                {
                    Console.Clear();
                    Screen.PrintOutBoard(chessMatch.board);
                    Console.WriteLine("Origin: ");
                    Position origin = Screen.readPositionChess().toPosition();
                    bool[,] positionPosible = chessMatch.board.getPiece(origin).movePosible();
                    Console.Clear();
                    Screen.PrintOutBoard(chessMatch.board, positionPosible);
                    Console.WriteLine("Destiny:");
                    Position destiny = Screen.readPositionChess().toPosition();

                    chessMatch.executeMoviment(origin, destiny);
                }


            }
            catch (BoardException m)
            {
                Console.WriteLine(m.Message);
            }


        }



    }
}
