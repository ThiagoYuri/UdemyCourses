using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game.Chess.Pieces
{
    class Pawn: Piece
    {
        public Pawn(Board board, ColorPiece color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        public bool canMove(Position pos)
        {
            Piece p = board.getPiece(pos);
            if(p != null)
            {
                return p.color != this.color;
            }
            return false;
        }
        private bool free(Position pos)
        {
            return board.getPiece(pos) == null;
        }

        public override bool[,] movePosible()
        {
            bool[,] mat = new bool[board.lines, board.columns];
            Position pos = new Position(0, 0);
            if(color == ColorPiece.White)
            {
                pos.changeValues(position.line - 1, position.column);
                if (board.positionValid(pos) && free(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.changeValues(position.line - 2, position.column);
                if (board.positionValid(pos) && free(pos) && qteMovimentos == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.changeValues(position.line - 1, position.column-1);
                if (board.positionValid(pos) && canMove(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.changeValues(position.line - 1, position.column+1);
                if (board.positionValid(pos) && canMove(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }
            else
            {
                pos.changeValues(position.line +1, position.column);
                if (board.positionValid(pos) && free(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.changeValues(position.line + 2, position.column);
                if (board.positionValid(pos) && free(pos) && qteMovimentos == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.changeValues(position.line + 1, position.column - 1);
                if (board.positionValid(pos) && canMove(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.changeValues(position.line + 1, position.column + 1);
                if (board.positionValid(pos) && canMove(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }
            return mat;
        }
    }
}
