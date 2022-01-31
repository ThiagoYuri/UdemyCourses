using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Tower: Piece
    {      
            public Tower(Board board, ColorPiece color) : base(board, color)
            {

            }

            public override string ToString()
            {
                return "T";
            }        
    }
}
