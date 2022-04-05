using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    /// <summary>
    /// data class to store Point
    /// </summary>
    public class Point : IComparable<Point>, IEquatable<Point>
    {
        public string Color { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <param name="color">given color</param>
        /// <param name="coordX">given X coordinate</param>
        /// <param name="coordY">given Y coordinate</param>

        public Point(string color, int coordX, int coordY)
        {
            Color = color;
            CoordX = coordX;
            CoordY = coordY;

        }

        /// <summary>
        /// overrided method to return formatted data about object
        /// </summary>
        /// <returns>returns formatted data</returns>
        public override string ToString()
        {
            return string.Format("| {0, -15} | {1, 5} | {2, 5} |", Color, CoordX, CoordY);
        }

        /// <summary>
        /// Implements IComparable interface, compares two points by their color
        /// </summary>
        /// <param name="other"></param>
        /// <returns>returns >0 if first > second, 0 if first = second, <0 if first < second, compares by their color</returns>
        public int CompareTo(Point other)
        {
            return Color.CompareTo(other.Color);
        }

        /// <summary>
        /// implements IEquatable interface, checks if two points equals by their color
        /// </summary>
        /// <param name="other"></param>
        /// <returns>true if points' colors matches, false if not</returns>
        public bool Equals(Point other)
        {
            return this.Color.Equals(other.Color);
        }
        /// <summary>
        /// overriden gethascode by point color
        /// </summary>
        /// <returns>overriden hashcode</returns>
        public override int GetHashCode()
        {
            return Color.GetHashCode();
        }
    }


}