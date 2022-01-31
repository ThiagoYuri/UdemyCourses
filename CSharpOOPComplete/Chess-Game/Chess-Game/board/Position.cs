using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    public class Position
    {
        public int line { get; set; }

        public int column { get; set; }

        //Constructor
        public Position(int line, int column)
        {
            this.line = line;
            this.column = column;
        }

        //Override ToString
        public override string ToString()
        {
            return $"Position: {this.line}, {this.column}";
        }

    }
}
