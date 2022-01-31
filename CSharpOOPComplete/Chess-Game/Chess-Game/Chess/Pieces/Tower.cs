using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Tower : Piece
    {
        public Tower(Board board, ColorPiece color) : base(board, color)
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
            Position pos = new Position(0,0);

            //up
            pos.changeValues(position.line - 1, position.column);
            while(board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if(board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line - 1;

            }
            //down
            pos.changeValues(position.line + 1, position.column);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line + 1;
            }
            //right
            pos.changeValues(position.line , position.column+1);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }

            //left
            pos.changeValues(position.line, position.column - 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }
            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
