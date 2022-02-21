using board;
using chess;
using Chess_Game.Chess.Pieces;
using System;
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
        public bool check { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            shift = 1;
            check = false;
            playerNow = ColorPiece.White;
            finalized = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
        }

        public Piece executeMoviment(Position pStart, Position pEnd)
        {
            Piece p = board.removePiece(pStart);
            p.movimentValueIncrement();
            Piece pCaptured = board.removePiece(pEnd);
            board.putPiece(p,pEnd);
            if(pCaptured != null)
            {
                captured.Add(pCaptured);
            }
            return pCaptured;
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

        private ColorPiece adversary(ColorPiece cor )
        {
            if(cor == ColorPiece.White)
            {
                return ColorPiece.Black;
            }
            return ColorPiece.White;
        }

        private Piece king(ColorPiece cor)
        {
            foreach(var x in piecesInGame(cor))
            {
                if(x is King)
                {
                    if (cor == x.color)
                    {
                        return x;
                    }
                }
            }
            return null;
        }
       
        public bool stateCheck(ColorPiece cor)
        {
            Piece R = king(cor);
            if(R == null)
            {
                throw new BoardException($"Não tem rei da cor {cor} no tabuleiro!");
            }
            foreach(var x in piecesInGame(adversary(cor)))
            {
                bool[,] mat = x.movePosible();
                if(mat[R.position.line,R.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool checkMate(ColorPiece cor)
        {
            try
            {
                if (!stateCheck(cor))
                {
                    return false;
                }
                foreach (Piece x in piecesInGame(cor))
                {
                    bool[,] mat = x.movePosible();
                    for (int i = 0; i < board.lines; i++)
                    {
                        for (int j = 0; j < board.columns; j++)
                        {
                            if (mat[i, j])
                            {
                                Position origin = x.position;
                                Position destino = new Position(i, j);
                                Piece pieceCaptured = executeMoviment(origin, destino);
                                bool testCheck = stateCheck(cor);                                
                                undoMove(origin, destino, pieceCaptured);
                                if (!testCheck)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void makeMove(Position pStart, Position pEnd)
        {
           
            Piece pieceCaptured = executeMoviment(pStart, pEnd);
            if (stateCheck(playerNow))
            {
                undoMove(pStart, pEnd, pieceCaptured);
                throw new BoardException("Você não pode se colocar em xeque!");
            }

            if (stateCheck(adversary(playerNow)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (checkMate(adversary(playerNow))) //
            {
                finalized = true;
            }
            else
            {
                shift++;
                ChangeJogador();
            }

        }

        private void undoMove(Position pStart, Position pEnd, Piece pieceCaptured)
        {
            
            Piece p = board.removePiece(pEnd);
            p.movimentValueDecrement();
            if(pieceCaptured != null)
            {
                board.putPiece(pieceCaptured, pEnd);
                captured.Remove(pieceCaptured);
            }
            board.putPiece(p, pStart);
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
            if (!board.getPiece(origin).movePosibles(destiny))
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
            //White
            putNewPieces('a', 1, new Tower(board, ColorPiece.White));
            putNewPieces('h', 1, new Tower(board, ColorPiece.White));
            putNewPieces('d', 1, new King(board, ColorPiece.White));
            putNewPieces('e', 1, new Dame(board, ColorPiece.White));
            putNewPieces('f', 1, new Bishop(board, ColorPiece.White));
            putNewPieces('c', 1, new Bishop(board, ColorPiece.White));
            putNewPieces('g', 1, new Horse(board, ColorPiece.White));
            putNewPieces('b', 1, new Horse(board, ColorPiece.White));
            //Peão
            /*putNewPieces('a', 2, new Pawn(board, ColorPiece.White));
            putNewPieces('b', 2, new Pawn(board, ColorPiece.White));
            putNewPieces('c', 2, new Pawn(board, ColorPiece.White));
            putNewPieces('d', 2, new Pawn(board, ColorPiece.White));
            putNewPieces('e', 2, new Pawn(board, ColorPiece.White));
            putNewPieces('f', 2, new Pawn(board, ColorPiece.White));
            putNewPieces('g', 2, new Pawn(board, ColorPiece.White));
            putNewPieces('h', 2, new Pawn(board, ColorPiece.White));*/

            //Black
            putNewPieces('a', 8, new Tower(board, ColorPiece.Black));
            putNewPieces('h', 8, new Tower(board, ColorPiece.Black));
            putNewPieces('d', 8, new King(board, ColorPiece.Black));
            putNewPieces('e', 8, new Dame(board, ColorPiece.Black));
            putNewPieces('f', 8, new Bishop(board, ColorPiece.Black));
            putNewPieces('c', 8, new Bishop(board, ColorPiece.Black));
            putNewPieces('g', 8, new Horse(board, ColorPiece.Black));
            putNewPieces('b', 8, new Horse(board, ColorPiece.Black));
            //Peão
           /* putNewPieces('a', 7, new Pawn(board, ColorPiece.Black));
            putNewPieces('b', 7, new Pawn(board, ColorPiece.Black));
            putNewPieces('c', 7, new Pawn(board, ColorPiece.Black));
            putNewPieces('d', 7, new Pawn(board, ColorPiece.Black));
            putNewPieces('e', 7, new Pawn(board, ColorPiece.Black));
            putNewPieces('f', 7, new Pawn(board, ColorPiece.Black));
            putNewPieces('g', 7, new Pawn(board, ColorPiece.Black));
            putNewPieces('h', 7, new Pawn(board, ColorPiece.Black));*/
        }
    }
}
