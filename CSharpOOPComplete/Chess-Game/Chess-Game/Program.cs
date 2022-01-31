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
                    Console.Write("Origin: ");
                    Position origin = Screen.readPositionChess().toPosition();
                    Console.Write("Destiny");
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
