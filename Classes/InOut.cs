using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace Lab2
{
    /// <summary>
    /// static class for in and out utils
    /// </summary>
    public static class InOut
    {
        /// <summary>
        /// reads data from given file and stores it in points linked list
        /// </summary>
        /// <param name="fileName">file to read from</param>
        /// <returns>linked list of points</returns>
        public static LinkList<Point> ReadPoints(List<string> lines)
        {
            LinkList<Point> points = new LinkList<Point>();
            foreach (string line in lines)
            {
                string[] values = line.Split(new[] { ", " }, StringSplitOptions.None);
                Point point = new Point(values[0], Convert.ToInt32(values[1]), Convert.ToInt32(values[2]));
                points.Add(point);
            }
            return points;
        }

        /// <summary>
        /// reads data from given file and stores it in triangles linked list
        /// </summary>
        /// <param name="fileName">file to read from</param>
        /// <returns>linked list of triangles</returns>
        public static LinkList<Triangle> ReadTriangles(List<string> lines)
        {
            LinkList<Triangle> triangles = new LinkList<Triangle>();
            foreach (string line in lines)
            {
                string[] values = line.Split(new[] { ", " }, StringSplitOptions.None);
                Triangle triangle = new Triangle(values[0], values[1] == "taip");
                triangles.Add(triangle);
            }
            return triangles;
        }

        /// <summary>
        /// prints formatted points' data in table to  given file
        /// </summary>
        /// <param name="points">given list of points</param>
        /// <param name="fn">file where to print</param>
        /// <param name="header">header of the table</param>
        public static void Print(LinkList<Point> points, string fn, string header)
        {
            string[] lines = new string[points.Count + 6];
            string dashes = new string('-', 35);
            lines[0] = header;
            lines[1] = dashes;
            lines[2] = string.Format("| {0, -15} | {1, 5} | {2, 5} |", "Spalva", "X", "Y");
            lines[3] = dashes;
            int i = 4;
            foreach(Point point in points)
            {
                lines[i] = point.ToString();
                i++;
            }
            lines[lines.Length - 2] = dashes;
            lines[lines.Length - 1] = "";
            File.AppendAllLines(fn, lines, Encoding.UTF8);

        }
        /// <summary>
        /// prints formatted triangles' data in table to given file
        /// </summary>
        /// <param name="triangles">given list of triangles</param>
        /// <param name="fn">file where to print</param>
        /// <param name="header">header of the table</param>
        public static void Print(LinkList<Triangle> triangles, string fn, string header)
        {
            string[] lines;
            if (triangles.Count == 0)
            {
                lines = new string[2];
                lines[0] = header;
                lines[1] = "Nėra tokių trikampių.";
            }
            else
            {
                lines = new string[triangles.Count + 6];
                string dashes = new string('-', 84);
                lines[0] = header;
                lines[1] = dashes;
                lines[2] = string.Format("| {0,-15} | {1,4} | {2,4} | {3,4} | {4,4} | {5,4} | {6,4} | {7, 20} |", "Spalva", "1 X", "1 Y", "2 X", "2 Y", "3 X", "3 Y", "Perimetras/nerasta");
                lines[3] = dashes;
                int i = 4;
                foreach (Triangle triangle in triangles)
                {
                    lines[i] = triangle.ToString();
                    i++;
                }
                lines[lines.Length - 2] = dashes;
                lines[lines.Length - 1] = "";
            }
            
            File.AppendAllLines(fn, lines, Encoding.UTF8);

        }


    }
}