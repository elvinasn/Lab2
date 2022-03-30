using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    public static class Tasks
    {
        /// <summary>
        /// solves the task - finds biggest isosceles triangle for each given color from given points
        /// </summary>
        /// <param name="points">given points</param>
        /// <param name="triangles">given triangles</param>
        public static void Solve(LinkList<Point> points, LinkList<Triangle> triangles)
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

        /// <summary>
        /// filters triangle list to only those, which were found
        /// </summary>
        /// <param name="filterFrom">list where to filter from</param>
        /// <returns>filtered list of only found triangles</returns>
        public static LinkList<Triangle> FilterSuccess(LinkList<Triangle> filterFrom)
        {
            LinkList<Triangle> filtered = new LinkList<Triangle>();
            for (filterFrom.Begin(); filterFrom.Exist(); filterFrom.Next())
            {
                if (filterFrom.Get().Perimeter != 0)
                    filtered.Add(filterFrom.Get());
            }
            return filtered;

        }
        /// <summary>
        /// filter triangle list to only those, which were not found
        /// </summary>
        /// <param name="filterFrom">list where to filter from</param>
        /// <returns>filtered list of only unfound triangles</returns>
        public static LinkList<Triangle> FilterUnSuccess(LinkList<Triangle> filterFrom)
        {
            LinkList<Triangle> filtered = new LinkList<Triangle>();
            for (filterFrom.Begin(); filterFrom.Exist(); filterFrom.Next())
            {
                if (!(filterFrom.Get().Perimeter != 0))
                    filtered.Add(filterFrom.Get());
            }
            return filtered;
        }
        /// <summary>
        /// removes triangles from linked list if given coordinates matches
        /// </summary>
        /// <param name="triangles">list of triangles</param>
        /// <param name="x1">first X</param>
        /// <param name="y1">first Y</param>
        /// <param name="x2">second X</param>
        /// <param name="y2">second Y</param>
        /// <param name="x3">third X</param>
        /// <param name="y3">third Y</param>
        /// <param name="success"> bool if it was removed(true if yes)</param>

        public static bool Remove(LinkList<Triangle> triangles, int x1, int y1, int x2, int y2, int x3, int y3)
        {
            bool success = false;
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
            return success;
        }

    }
}