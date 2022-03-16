using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    /// <summary>
    /// comparator class of triangle
    /// </summary>
    public class TriangleComparator
    {
        /// <summary>
        /// compares two triangles by their compareTo method
        /// </summary>
        /// <param name="a">first triangle</param>
        /// <param name="b">second triangle</param>
        /// <returns>returns >0 if a color > b color, 0 if equals and <0 if b color > a color</returns>
        public virtual int Compare(Triangle a, Triangle b)
        {
            return a.CompareTo(b);
        }
    }
}