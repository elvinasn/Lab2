using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    public class TriangleComparatorByPerimeter : TriangleComparator
    {
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