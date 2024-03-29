﻿using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game.Chess.Pieces
{
    class Dame : Piece
    {
        public Dame(Board board, ColorPiece color) : base(board, color)
        {
        }
        public override string ToString()
        {
            return "D";
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

            //bispo
            //no
            pos.changeValues(position.line - 1, position.column - 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line - 1;
                pos.column = pos.column - 1;
            }
            //ne
            pos.changeValues(position.line - 1, position.column + 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line - 1;
                pos.column = pos.column + 1;
            }
            //so
            pos.changeValues(position.line + 1, position.column - 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line + 1;
                pos.column = pos.column - 1;
            }

            //se
            pos.changeValues(position.line + 1, position.column + 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line + 1;
                pos.column = pos.column + 1;
            }
            //Tower
            //up
            pos.changeValues(position.line - 1, position.column);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
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
            pos.changeValues(position.line, position.column + 1);
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
    }
}
