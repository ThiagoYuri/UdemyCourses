using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game.Chess.Pieces
{
    class Horse : Piece
    {
        public Horse(Board board, ColorPiece color) : base(board, color)
        {
        }
        public override string ToString()
        {
            return "C";
        }
        public bool canMove(Position pos)
        {
            Piece p = board.getPiece(pos);
            return p == null || p.color != color;
        }
        public override bool[,] movePosible()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);
           
            pos.changeValues(position.line - 1, position.column-2);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            
            pos.changeValues(position.line - 1, position.column + 2);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            
            pos.changeValues(position.line+1, position.column - 2);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            
            pos.changeValues(position.line + 1, position.column +2);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.changeValues(position.line - 2, position.column - 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.changeValues(position.line - 2, position.column + 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.changeValues(position.line + 2, position.column -1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.changeValues(position.line + 2, position.column + 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            return mat;

        }
    }
}
