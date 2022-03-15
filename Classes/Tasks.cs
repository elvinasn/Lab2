using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    public static class Tasks
    {
        public static void Solve(PointsLinkedList points, TrianglesLinkedList triangles)
        {
            bool NEXTFLAG;
            bool NEXTSECONDFLAG;

            for (triangles.Begin(); triangles.Exist(); triangles.Next())
            {
                Triangle current = triangles.Get();
                Triangle max = new Triangle("unknown", false);
                if (current.Able)
                {
                    foreach (Point first in points)
                    {
                        NEXTFLAG = false;
                        if (first.Color == triangles.Get().Color)
                        {
                            foreach (Point second in points)
                            {
                                NEXTSECONDFLAG = false;
                                if (!NEXTFLAG)
                                {
                                    if (second.Equals(first))
                                        NEXTFLAG = true;
                                    continue;
                                }
                                else
                                {
                                    if (second.Color == first.Color)
                                    {
                                        foreach (Point third in points)
                                        {
                                            if (!NEXTSECONDFLAG)
                                            {
                                                if (third.Equals(second))
                                                    NEXTSECONDFLAG = true;
                                                continue;
                                            }
                                            else
                                            {
                                                if (third.Color == first.Color)
                                                {
                                                    Triangle newTriangle = new Triangle(current.Color, current.Able);
                                                    if ((first.CoordX != second.CoordX || first.CoordX != third.CoordX) && (first.CoordY != second.CoordY || first.CoordY != third.CoordY)) // not in one line
                                                    {
                                                        newTriangle.FirstV = first;
                                                        newTriangle.SecondV = second;
                                                        newTriangle.ThirdV = third;
                                                        if (newTriangle > max && newTriangle.IsIsosceles())
                                                            max = newTriangle;
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (max.Color != "unknown")
                        triangles.Set(max);
                }
            }
        }

        public static TrianglesLinkedList FilterSuccess(TrianglesLinkedList filterFrom)
        {
            TrianglesLinkedList filtered = new TrianglesLinkedList();
            for (filterFrom.Begin(); filterFrom.Exist(); filterFrom.Next())
            {
                if (filterFrom.Get().Perimeter != 0)
                    filtered.Add(filterFrom.Get());
            }
            return filtered;

        }
        public static TrianglesLinkedList FilterUnSuccess(TrianglesLinkedList filterFrom)
        {
            TrianglesLinkedList filtered = new TrianglesLinkedList();
            for (filterFrom.Begin(); filterFrom.Exist(); filterFrom.Next())
            {
                if (!(filterFrom.Get().Perimeter != 0))
                    filtered.Add(filterFrom.Get());
            }
            return filtered;
        }

        public static void Remove(TrianglesLinkedList triangles, int x1, int y1, int x2, int y2, int x3, int y3, out bool success)
        {
            success = false;
            if (triangles != null)
            {
                for (triangles.Begin(); triangles.Exist(); triangles.Next())
                {
                    Triangle curr = triangles.Get();
                    int firstX = curr.FirstV.CoordX;
                    int firstY = curr.FirstV.CoordY;
                    int secondX = curr.SecondV.CoordX;
                    int secondY = curr.SecondV.CoordY;
                    int thirdX = curr.ThirdV.CoordX;
                    int thirdY = curr.ThirdV.CoordY;

                    if (firstX == x1 && firstY == y1 && secondX == x2 && secondY == y2 && thirdX == x3 && thirdY == y3)
                    {
                        triangles.Remove();
                        success = true;
                    }
                }
            }
  
        }

    }
}