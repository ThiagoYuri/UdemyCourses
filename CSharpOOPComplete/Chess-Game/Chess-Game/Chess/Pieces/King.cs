using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class King : Piece
    {
        public King(Board board, ColorPiece color ):base(board, color)
        {

        }

        private bool canMove(Position pos)
        {
            Piece p = board.getPiece(pos);
            return p == null || p.color != this.color;
        }
        public override bool[,] movePosible()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);
            //Up
            pos.changeValues(position.line - 1, position.column);
            if(board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //northeast
            pos.changeValues(position.line - 1, position.column+1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //right
            pos.changeValues(position.line, position.column+1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //southeast
            pos.changeValues(position.line+1, position.column+1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //down
            pos.changeValues(position.line + 1, position.column );
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //down
            pos.changeValues(position.line + 1, position.column);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //southwest
            pos.changeValues(position.line + 1, position.column-1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //left
            pos.changeValues(position.line , position.column - 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //northwest
            pos.changeValues(position.line-1, position.column - 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
