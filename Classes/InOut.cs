using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace Lab2
{
    /// <summary>
    /// static class for in and out tasks
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
        /// Prints given list of type to txt
        /// </summary>
        /// <typeparam name="Type">Type</typeparam>
        /// <param name="list">list of data</param>
        /// <param name="fn">filename</param>
        /// <param name="header">header of table</param>
        /// <param name="upperLine">upperLine of table</param>
        public static void PrintTxt <Type> (IEnumerable<Type> list, string fn, string header, string upperLine)
        {
            string[] lines = new string[list.Count() + 6];
            string dashes = new string('-', upperLine.Length);
            lines[0] = header;
            lines[1] = dashes;
            lines[2] = upperLine;
            lines[3] = dashes;
            int i = 4;
            foreach(Type T in list)
            {
                lines[i] = T.ToString();
                i++;
            }
            lines[lines.Length - 2] = dashes;
            lines[lines.Length - 1] = "";
            File.AppendAllLines(fn, lines, Encoding.UTF8);

        }


    }
}