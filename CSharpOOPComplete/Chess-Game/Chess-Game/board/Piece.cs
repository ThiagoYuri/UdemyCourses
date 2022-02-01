using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public ColorPiece color { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Board board { get; protected set; }
        //Constructor
        public Piece( Board board, ColorPiece color)
        {
            this.position = null;
            this.board = board;
            this.color = color;
            this.qteMovimentos = 0;
        }

        public bool existsMovePosible()
        {
            bool[,] mat = movePosible();
            for(int i = 0; i< board.lines; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public abstract bool[,] movePosible();        

        public void movimentValueIncrement()
        {
            qteMovimentos++;
        }


        public bool canMoveTo(Position pos)
        {
            return movePosible()[pos.line, pos.column];
        }

    }
}
