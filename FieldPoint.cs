using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class FieldPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char PointLook { get; set; }

        public FieldPoint(int x, int y, char pointLook)
        {
            X = x;
            Y = y;
            PointLook = pointLook;
        }
    }
}
