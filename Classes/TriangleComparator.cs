using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    public class TriangleComparator
    {
        public virtual int Compare(Triangle a, Triangle b)
        {
            return a.CompareTo(b);
        }
    }
}