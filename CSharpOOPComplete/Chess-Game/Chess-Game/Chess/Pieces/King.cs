using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game.Chess.Pieces
{
    class King : Piece
    {
        private ChessMatch match;
        public King(Board board, ColorPiece color , ChessMatch match):base(board, color)
        {
            this.match = match;
        }

        private bool testTowersToRoque(Position pos)
        {
            Piece p = board.getPiece(pos);
            return p != null && p is Tower && p.color == color && p.qteMovimentos == 0;
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

            //# special move
            if(qteMovimentos == 0 && !match.check)
            {
                //special move rock small
                Position posT1 = new Position(position.line, position.column + 3);
                if (testTowersToRoque(posT1))
                {
                    Position p1 = new Position(position.line, position.column + 1);
                    Position p2 = new Position(position.line, position.column + 2);
                    if(board.getPiece(p1) == null && board.getPiece(p2) == null)
                    {
                        mat[position.line, position.column + 2] = true;
                    }
                }
                //special move rock big
                Position posT2 = new Position(position.line, position.column -4);
                if (testTowersToRoque(posT2))
                {
                    Position p1 = new Position(position.line, position.column - 1);
                    Position p2 = new Position(position.line, position.column - 2);
                    Position p3 = new Position(position.line, position.column - 3);
                    if (board.getPiece(p1) == null && board.getPiece(p2) == null && board.getPiece(p3) == null)
                    {
                        mat[position.line, position.column - 2] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
