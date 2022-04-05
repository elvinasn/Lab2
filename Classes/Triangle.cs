using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    /// <summary>
    /// data class to store Triangle object
    /// </summary>
    public class Triangle : IComparable<Triangle>, IEquatable<Triangle>
    {

        public string Color { get; set; }
        public Point FirstV { get; set; }
        public Point SecondV { get; set; }
        public Point ThirdV { get; set; }
        public bool Able { get; set; }
        private double FirstEdge
        {
            get
            {
                if (FirstV != null && SecondV != null)
                    return Math.Sqrt(Math.Pow((double)FirstV.CoordX - (double)SecondV.CoordX, 2) + Math.Pow((double)FirstV.CoordY - (double)SecondV.CoordY, 2));
                return 0;
            }
        }
        private double SecondEdge
        {
            get
            {
                if(FirstV != null && ThirdV != null)
                    return Math.Sqrt(Math.Pow((double)FirstV.CoordX - (double)ThirdV.CoordX, 2) + Math.Pow((double)FirstV.CoordY - (double)ThirdV.CoordY, 2));
                return 0;
            }
        }
        private double ThirdEdge
        {
            get
            {
                if (SecondV != null && ThirdV != null)
                    return Math.Sqrt(Math.Pow((double)SecondV.CoordX - (double)ThirdV.CoordX, 2) + Math.Pow((double)SecondV.CoordY - (double)ThirdV.CoordY, 2));
                return 0;
            }
        }
        public double Perimeter
        {
            get
            {

                if (FirstEdge != 0 && SecondEdge != 0 && ThirdEdge != 0)
                {
                    double sum = 0;
                    sum += FirstEdge;
                    sum += SecondEdge;
                    sum += ThirdEdge;
                    return Math.Round(sum, 2);
                }
                return 0;
            }
        }
        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <param name="color">given color</param>
        /// <param name="able">given bool if it is possible to create triangle</param>
        public Triangle(string color, bool able)
        {
            Color = color;
            Able = able;
        }


        /// <summary>
        /// checks if triangle is isosceles
        /// </summary>
        /// <returns>true if isosceles, false if not</returns>
        public bool IsIsosceles() => FirstEdge == SecondEdge || FirstEdge == ThirdEdge || SecondEdge == ThirdEdge;

        /// <summary>
        /// overriden (<) operator to compare two triangles by their perimeters
        /// </summary>
        /// <param name="lhs">lhs triangle</param>
        /// <param name="rhs">rhs triangle</param>
        /// <returns>bool if first < second</returns>
        public static bool operator <(Triangle lhs, Triangle rhs) => lhs.Perimeter < rhs.Perimeter;

        /// <summary>
        /// overriden (>) operator to compare two triangles by their perimeters
        /// </summary>
        /// <param name="lhs">lhs triangle</param>
        /// <param name="rhs">rhs triangle</param>
        /// <returns>bool if first > second</returns>
        public static bool operator >(Triangle lhs, Triangle rhs) => lhs.Perimeter > rhs.Perimeter;

        /// <summary>
        /// overriden tostring method to return formatted data of triangle
        /// </summary>
        /// <returns>formatted line of triangle data</returns>
        public override string ToString()
        {
            if(Able && Perimeter > 0)
            {
                return string.Format("| {0,-15} | {1,4} | {2,4} | {3,4} | {4,4} | {5,4} | {6,4} | {7, 20} |", Color, FirstV.CoordX, FirstV.CoordY, SecondV.CoordX, SecondV.CoordY, ThirdV.CoordX, ThirdV.CoordY, Perimeter);
            }
            else
            {
                string last;
                if (Able)
                    last = "nėra";
                else
                    last = "negalima";
                     
                return string.Format("| {0,-15} | {1,4} | {2,4} | {3,4} | {4,4} | {5,4} | {6,4} | {7, 20} |", Color, "", "", "", "", "", "", last);
            }
            
        }

        /// <summary>
        /// implements IEquatable interface, checks if two triangles equals by their color
        /// </summary>
        /// <param name="other"></param>
        /// <returns>true if triangles' colors matches, false if not</returns>
        public bool Equals(Triangle other)
        {
            return Color == other.Color;
        }

        /// <summary>
        /// overriden gethascode by triangle color
        /// </summary>
        /// <returns>overriden hashcode</returns>
        public override int GetHashCode()
        {
            return Color.GetHashCode();
        }
        /// <summary>
        /// Implements IComparable interface, compares two triangles by their color
        /// </summary>
        /// <param name="other"></param>
        /// <returns> returns >0 if first > second, 0 if first = second, <0 if first < second, compares by their color</returns>
        public int CompareTo(Triangle other)
        {
            return Color.CompareTo(other.Color);
        }
    }
}