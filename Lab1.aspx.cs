using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Lab2
{
    public partial class Lab1 : System.Web.UI.Page
    {
        private const string pointsPath = @"App_Data\U5a.txt";
        private const string coloursPath = @"App_Data\U5b.txt";
        private const string resultsPath = @"Rezultatai\Results.txt";
        private const string startData = @"Rezultatai\StartData.txt";

        private PointsLinkedList points = InOut.ReadPoints(HttpContext.Current.Server.MapPath(pointsPath));
        private TrianglesLinkedList triangles = InOut.ReadTriangles(HttpContext.Current.Server.MapPath(coloursPath));
        private TrianglesLinkedList found = new TrianglesLinkedList();
        private TrianglesLinkedList unfound = new TrianglesLinkedList();

        protected void Page_Load(object sender, EventArgs e)
        {
            File.Delete(Server.MapPath("~") + startData);
            File.Delete(Server.MapPath("~") + resultsPath);
            InOut.PrintPointsToTXT(points, Server.MapPath("~") + startData, "Pradiniai duomenys \"U5a.txt\":");
            InOut.PrintTrianglesToTXT(triangles, Server.MapPath("~") + startData, "Pradiniai duomenys \"U5b.txt\"");
            FillTableWithTriangles(triangles, ref start1);
            FillTableWithPoints(points, ref start2);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Tasks.Solve(points, triangles);
            Tasks.FilterSuccess(triangles, ref found, ref unfound);
            found.Sort(new TriangleComparatorByPerimeter());
            unfound.Sort(new TriangleComparator());
            InOut.PrintTrianglesToTXT(found, Server.MapPath("~") + resultsPath, "Rasti perimetrai:");
            InOut.PrintTrianglesToTXT(unfound, Server.MapPath("~") + resultsPath, "Nerasti perimetrai:");
            FillTableWithTriangles(found, ref results1);
            FillTableWithTriangles(unfound, ref results2);

        }
    }
}