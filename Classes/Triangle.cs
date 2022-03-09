using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    public class Triangle
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
                    return Math.Round(Math.Sqrt(Math.Pow((double)FirstV.CoordX - (double)SecondV.CoordX, 2) + Math.Pow((double)FirstV.CoordY - (double)SecondV.CoordY, 2)), 2);
                return 0;
            }
        }
        private double SecondEdge
        {
            get
            {
                if(FirstV != null && ThirdV != null)
                    return Math.Round(Math.Sqrt(Math.Pow((double)FirstV.CoordX - (double)ThirdV.CoordX, 2) + Math.Pow((double)FirstV.CoordY - (double)ThirdV.CoordY, 2)), 2);
                return 0;
            }
        }
        private double ThirdEdge
        {
            get
            {
                if(SecondV != null && ThirdV != null)
                    return Math.Round(Math.Sqrt(Math.Pow((double)SecondV.CoordX - (double)ThirdV.CoordX, 2) + Math.Pow((double)SecondV.CoordY - (double)ThirdV.CoordY, 2)));
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

        public Triangle(string color, bool able)
        {
            Color = color;
            Able = able;
        }



        public bool isIsosceles() => FirstEdge == SecondEdge || FirstEdge == ThirdEdge || SecondEdge == FirstEdge;

        ///
        public static bool operator <(Triangle lhs, Triangle rhs) => lhs.Perimeter < rhs.Perimeter;

        public static bool operator >(Triangle lhs, Triangle rhs) => lhs.Perimeter > rhs.Perimeter;

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

        public int CompareTo(Triangle other)
        {
            return this.Color.CompareTo(other.Color);
        }
    }
}