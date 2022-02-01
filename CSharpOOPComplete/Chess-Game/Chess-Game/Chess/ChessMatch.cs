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
        public Board board { get; private set; }
        public int shift { get; private set; }
        public ColorPiece playerNow { get; private set; }
        public bool finalized { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            shift = 1;
            playerNow = ColorPiece.White;
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

        public void makeMove(Position pStart, Position pEnd)
        {
            executeMoviment(pStart, pEnd);
            shift++;
            ChangeJogador();
        }

        public void validPositionOrigin(Position pos)
        {
            if(board.getPiece(pos) == null){
                throw new BoardException("Não existe peça na posição de origem escolhida!");
            }
            if(playerNow != board.getPiece(pos).color)
            {
                throw new BoardException("A peça de origem escolhida não é sua!");
            }
            if (!board.getPiece(pos).existsMovePosible())
            {
                throw new BoardException("Não há movimentos possíveis para a peça de origem escolhída!");
            }

        }

        public void validPositionDestiny(Position origin,Position destiny)
        {
            if (!board.getPiece(origin).canMoveTo(destiny))
            {
                throw new BoardException("Posição de destino invalida");
            }
        }


        private void ChangeJogador()
        {
            if(playerNow == ColorPiece.White)
            {
                playerNow = ColorPiece.Black;
            }
            else
            {
                playerNow = ColorPiece.White;
            }
        }

        public void putPieces()
        {

            board.putPiece(new Tower(board, ColorPiece.White), new PositionChess('c', 1).toPosition());
            board.putPiece(new Tower(board, ColorPiece.White), new PositionChess('c', 2).toPosition());
            board.putPiece(new Tower(board, ColorPiece.White), new PositionChess('d', 2).toPosition());
            board.putPiece(new Tower(board, ColorPiece.White), new PositionChess('e', 2).toPosition());
            board.putPiece(new Tower(board, ColorPiece.White), new PositionChess('e', 1).toPosition());
            board.putPiece(new King(board, ColorPiece.White), new PositionChess('d', 1).toPosition());


            board.putPiece(new Tower(board, ColorPiece.Black), new PositionChess('c', 7).toPosition());
            board.putPiece(new Tower(board, ColorPiece.Black), new PositionChess('c', 8).toPosition());
            board.putPiece(new Tower(board, ColorPiece.Black), new PositionChess('d', 7).toPosition());
            board.putPiece(new Tower(board, ColorPiece.Black), new PositionChess('e', 7).toPosition());
            board.putPiece(new Tower(board, ColorPiece.Black), new PositionChess('e', 8).toPosition());
            board.putPiece(new King(board, ColorPiece.Black), new PositionChess('d', 8).toPosition());

        }
    }
}
