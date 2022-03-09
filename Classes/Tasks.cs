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
            for(triangles.Begin(); triangles.Exist(); triangles.Next())
            {
                Triangle current = triangles.Get();
                Triangle max = new Triangle("unknown", false);
                if (current.Able)
                {
                    for (points.Begin(); points.Exist(); points.Next())
                    {
                        Point first = points.Get();
                        if (first.Color == triangles.Get().Color)
                        {
                            for (points.BeginInner(points.Get()); points.ExistInner(); points.NextInner())
                            {
                                Point second = points.GetInner();
                                if (second.Color == first.Color)
                                {
                                    for (points.BeginInnerInner(second); points.ExistInnerInner(); points.NextInnerInner())
                                    {
                                        Point third = points.GetInnerInner();
                                        if (third.Color == first.Color)
                                        {
                                            Triangle newTriangle = new Triangle(current.Color, current.Able);
                                            if((first.CoordX != second.CoordX || first.CoordX != third.CoordX) && (first.CoordY != second.CoordY || first.CoordY != third.CoordY)) // not in one line
                                            {
                                                newTriangle.FirstV = first;
                                                newTriangle.SecondV = second;
                                                newTriangle.ThirdV = third;
                                                if (newTriangle > max && newTriangle.isIsosceles())
                                                    max = newTriangle;
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

        public static void FilterSuccess(TrianglesLinkedList filterFrom, ref TrianglesLinkedList Success, ref TrianglesLinkedList UnSuccess)
        { 
            for(filterFrom.Begin(); filterFrom.Exist(); filterFrom.Next())
            {
                if (filterFrom.Get().Perimeter != 0)
                    Success.Add(filterFrom.Get());
                else
                    UnSuccess.Add(filterFrom.Get());
                        
            }
  
        }

    }
}