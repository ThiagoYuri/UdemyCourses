using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    class Piece
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

        public void movimentValueIncrement()
        {
            qteMovimentos++;
        }

    }
}
