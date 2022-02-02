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
                    try
                    {
                        Console.Clear();
                        Screen.printGame(chessMatch);
                        Console.WriteLine("Origin: ");
                        Position origin = Screen.readPositionChess().toPosition();
                        chessMatch.validPositionOrigin(origin);
                        bool[,] positionPosible = chessMatch.board.getPiece(origin).movePosible();
                        Console.Clear();
                        Screen.printOutBoard(chessMatch.board, positionPosible);
                        Console.WriteLine("Destiny:");
                        Position destiny = Screen.readPositionChess().toPosition();
                        chessMatch.validPositionDestiny(origin,destiny);
                        chessMatch.makeMove(origin, destiny);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Aperte alguma tecla para continuar");
                        Console.ReadKey();
                    }
                }


            }
            catch (BoardException m)
            {
                Console.WriteLine(m.Message);
            }


        }



    }
}
