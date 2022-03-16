using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    /// <summary>
    /// triangle comparator class by perimeter
    /// </summary>
    public class TriangleComparatorByPerimeter : TriangleComparator
    {
        /// <summary>
        /// compares by compareto method, if it equals, by their perimeters
        /// </summary>
        /// <param name="a">first triangle</param>
        /// <param name="b">second triangle</param>
        /// <returns> >0 if a color > b color or a color = b color and a perimeter > b perimeter, 0 if a color = b color and a perimeter = b perimeter, >0 if else</returns>
        public override int Compare(Triangle a, Triangle b)
        {
            int result = a.CompareTo(b);
            if (result == 0)
            {
                return a.Perimeter.CompareTo(b.Perimeter);
            }
            return result;
        }
    }
}