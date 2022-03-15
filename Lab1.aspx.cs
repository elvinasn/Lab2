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

        protected void Page_Load(object sender, EventArgs e)
        {
            File.Delete(Server.MapPath("~") + startData);
            File.Delete(Server.MapPath("~") + resultsPath);
            InOut.Print(points, Server.MapPath("~") + startData, "Pradiniai duomenys \"U5a.txt\":");
            InOut.Print(triangles, Server.MapPath("~") + startData, "Pradiniai duomenys \"U5b.txt\"");
            FillTable(triangles, ref start1, ref Nera1);
            FillTable(points, ref start2, ref Nera2);
            if(Session["found"] != null)
            {
                FillTable((TrianglesLinkedList)Session["found"], ref results1, ref Nera3);
            }
            if(Session["unfound"] != null)
            {
                FillTable((TrianglesLinkedList)Session["unfound"], ref results2, ref Nera4);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Tasks.Solve(points, triangles);
            Session["found"] = Tasks.FilterSuccess(triangles);
            Session["unfound"] = Tasks.FilterUnSuccess(triangles);
            ((TrianglesLinkedList)Session["found"]).Sort(new TriangleComparatorByPerimeter());
            ((TrianglesLinkedList)Session["unfound"]).Sort(new TriangleComparator());
            InOut.Print((TrianglesLinkedList)Session["found"], Server.MapPath("~") + resultsPath, "Rasti perimetrai:");
            InOut.Print((TrianglesLinkedList)Session["unfound"], Server.MapPath("~") + resultsPath, "Nerasti perimetrai:");
            FillTable((TrianglesLinkedList)Session["found"], ref results1, ref Nera3);
            FillTable((TrianglesLinkedList)Session["unfound"], ref results2, ref Nera4);

        }

        protected void Trinti_Click(object sender, EventArgs e)
        {
            string x1 = X1.Text;
            string y1 = Y1.Text;
            string x2 = X2.Text;
            string y2 = Y2.Text;
            string x3 = X3.Text;
            string y3 = Y3.Text;
            if (x1 == "" || y1 == "" || x2 == "" || y2 == "" || x3 == "" || y3 == "" || !int.TryParse(x1, out int firstX) ||
              !int.TryParse(y1, out int firstY) || !int.TryParse(x2, out int secondX) || !int.TryParse(y2, out int secondY) || !int.TryParse(x3, out int thirdX) || !int.TryParse(y3, out int thirdY))
            {
                Error.CssClass = Error.CssClass.Replace("none", "");
            }
            else
            {
                if (!Error.CssClass.Contains("none"))
                    Error.CssClass += "none";
                Tasks.Remove((TrianglesLinkedList)Session["found"], firstX, firstY, secondX, secondY, thirdX, thirdY, out bool success);
                if (success)
                    Success.Text = "Šalinimas pavyko.";
                else
                    Success.Text = "Šalinimas nepavyko.";
                FillTable((TrianglesLinkedList)Session["found"], ref results1, ref Nera3);
            }
            

        }
    }
}