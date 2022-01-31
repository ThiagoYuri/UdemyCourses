using board;
using chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game.Chess
{
    class ChessMatch
    {
        public Board board { get; set; }
        private int turno;
        private ColorPiece jogadorAtual;
        public bool finalized { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turno = 1;
            jogadorAtual = ColorPiece.White;
            finalized = false;
            putPieces();
        }

        public void executeMoviment(Position pStart, Position pEnd)
        {
            Piece p = board.removePiece(pStart);
            p.movimentValueIncrement();
            Piece pCaptured = board.removePiece(pEnd);
            board.putPiece(p,pEnd);
        }


        public void putPieces()
        {

            board.putPiece(new Tower(board, ColorPiece.White), new PositionChess('c', 1).toPosition());
            board.putPiece(new Tower(board, ColorPiece.White), new PositionChess('c', 2).toPosition());
            board.putPiece(new Tower(board, ColorPiece.White), new PositionChess('d', 2).toPosition());
            board.putPiece(new Tower(board, ColorPiece.White), new PositionChess('e', 2).toPosition());
            board.putPiece(new Tower(board, ColorPiece.White), new PositionChess('e', 1).toPosition());
            board.putPiece(new King(board, ColorPiece.White), new PositionChess('d', 1).toPosition());


            board.putPiece(new Tower(board, ColorPiece.Yellow), new PositionChess('c', 7).toPosition());
            board.putPiece(new Tower(board, ColorPiece.Yellow), new PositionChess('c', 8).toPosition());
            board.putPiece(new Tower(board, ColorPiece.Yellow), new PositionChess('d', 7).toPosition());
            board.putPiece(new Tower(board, ColorPiece.Yellow), new PositionChess('e', 7).toPosition());
            board.putPiece(new Tower(board, ColorPiece.Yellow), new PositionChess('e', 8).toPosition());
            board.putPiece(new King(board, ColorPiece.Yellow), new PositionChess('d', 8).toPosition());

        }
    }
}
