using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    class Board
    {
        //lines e columns Attributes
        public int lines { get; set; }
        public int columns { get; set; }

        //Array of Pieces
        private Piece[,] pieces;

        //Create Board Constructor of class
        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }

        //Methods
        //piece
        public Piece getPiece(Position pos)
        {
            return pieces[pos.line, pos.column];
        }

        public void putPiece(Piece p, Position pos)
        {
            if (existsPiece(pos))
            {
                throw new BoardException("there is already a piece in this position");
            }
            pieces[pos.line, pos.column] = p;
            p.position = pos;
        }

        public Piece removePiece(Position p)
        {
            if(getPiece(p) == null)
            {
                return null;
            }
            Piece aux = getPiece(p);
            aux.position = null;
            pieces[p.line, p.column] = null;
            return aux;
        }

        public bool existsPiece(Position pos)
        {
            validPosition(pos);
            return pieces[pos.line, pos.column] != null;
        }

        public void validPosition(Position pos)
        {
            if (!positionValid(pos))
            {
                throw new BoardException("Invalid Position!");
            }
        }

        public bool positionValid(Position pos)
        {
            if (pos.line < 0 || pos.line >= lines || pos.column < 0 || pos.column >= columns)
            {
                return false;
            }
            return true;
        }
    


    }
}
