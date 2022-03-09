using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    public class Point
    {
        public string Color { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        

        public Point(string color, int coordX, int coordY)
        {
            Color = color;
            CoordX = coordX;
            CoordY = coordY;

        }

        public override string ToString()
        {
            return string.Format("| {0, -15} | {1, 5} | {2, 5} |", Color, CoordX, CoordY);
        }
    }

}