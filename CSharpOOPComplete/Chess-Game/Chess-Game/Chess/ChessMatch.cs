using board;
using chess;
using System.Collections.Generic;

namespace Chess_Game.Chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int shift { get; private set; }
        public ColorPiece playerNow { get; private set; }
        public bool finalized { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public ChessMatch()
        {
            board = new Board(8, 8);
            shift = 1;
            playerNow = ColorPiece.White;
            finalized = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
        }

        public void executeMoviment(Position pStart, Position pEnd)
        {
            Piece p = board.removePiece(pStart);
            p.movimentValueIncrement();
            Piece pCaptured = board.removePiece(pEnd);
            board.putPiece(p,pEnd);
            if(pCaptured != null)
            {
                captured.Add(pCaptured);
            }
        }

        public HashSet<Piece> piecesCaptured(ColorPiece cor)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(var p in captured)
            {
                if(cor == p.color)
                {
                    aux.Add(p);
                }
            }
            return aux;
        }
        public HashSet<Piece> piecesInGame(ColorPiece cor)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (var p in pieces)
            {
                if (cor == p.color)
                {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(piecesCaptured(cor));
            return aux;
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
        
        public void putNewPieces(char column,int line, Piece piece)
        {
            board.putPiece(piece, new PositionChess(column, line).toPosition());
            pieces.Add(piece);
        }

        public void putPieces()
        {
            putNewPieces('c', 1, new Tower(board, ColorPiece.White));
            putNewPieces('c', 2, new Tower(board, ColorPiece.White));
            putNewPieces('d', 2, new Tower(board, ColorPiece.White));
            putNewPieces('e', 2, new Tower(board, ColorPiece.White));
            putNewPieces('e', 1, new Tower(board, ColorPiece.White));
            putNewPieces('d', 1, new King(board, ColorPiece.White));


            putNewPieces('c', 7, new Tower(board, ColorPiece.Black));
            putNewPieces('c', 8, new Tower(board, ColorPiece.Black));
            putNewPieces('d', 7, new Tower(board, ColorPiece.Black));
            putNewPieces('e', 7, new Tower(board, ColorPiece.Black));
            putNewPieces('e', 8, new Tower(board, ColorPiece.Black));
            putNewPieces('d', 8, new King(board, ColorPiece.Black));           
        }
    }
}
