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
        private const string resultsPath = @"Rezultatai\Results.txt";
        private const string startData = @"Rezultatai\StartData.txt";
        private readonly string[] triangleHeaders = { "Spalva", "1X", "1Y", "2X", "2Y", "3X", "3Y", "Perimetras" };
        private readonly string[] pointHeaders = { "Spalva", "X", "Y" };
        private readonly string trianglesUpper = 
            string.Format("| {0,-15} | {1,4} | {2,4} | {3,4} | {4,4} | {5,4} | {6,4} | {7, 20} |", "Spalva", "1 X", "1 Y", "2 X", "2 Y", "3 X", "3 Y", "Perimetras/nerasta");
        private readonly string pointsUpper = string.Format("| {0, -15} | {1, 5} | {2, 5} |", "Spalva", "X", "Y");


        /// <summary>
        /// page load method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        { 

            File.Delete(Server.MapPath("~") + startData);
            File.Delete(Server.MapPath("~") + resultsPath);
              
            Button1.Enabled = false;
            Trinti.Enabled = false;

            if (Session["triangles"] != null && Session["points"] != null)
            {
                Button1.Enabled = true;
                Trinti.Enabled = true;
            }
            if (Session["found"] != null)
            {

                FillTable((LinkList<Triangle>)Session["found"], ref results1, ref Nera3, triangleHeaders);
                InOut.PrintTxt((LinkList<Triangle>)Session["found"], Server.MapPath("~") + resultsPath, "Rasti perimetrai:",
               trianglesUpper);
                Button1.Enabled = false;
            }
            if(Session["unfound"] != null)
            {
                FillTable((LinkList<Triangle>)Session["unfound"], ref results2, ref Nera4, triangleHeaders);
                InOut.PrintTxt((LinkList<Triangle>)Session["unfound"], Server.MapPath("~") + resultsPath, "Nerasti perimetrai:",
                trianglesUpper);
            }
            if (Session["triangles"] != null)
            {
                FillTable((LinkList<Triangle>)Session["triangles"], ref start1, ref Nera1, triangleHeaders);
                InOut.PrintTxt((LinkList<Triangle>)Session["triangles"], Server.MapPath("~") + startData, "Pradiniai duomenys \"U5b.txt\"",
                trianglesUpper);
            }
            if (Session["points"] != null)
            {
                FillTable((LinkList<Point>)Session["points"], ref start2, ref Nera2, pointHeaders);
                InOut.PrintTxt((LinkList<Point>)Session["points"], Server.MapPath("~") + startData, "Pradiniai duomenys \"U5a.txt\":",pointsUpper);
            }
            
        }

        /// <summary>
        /// run button click method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Tasks.Solve((LinkList<Point>)Session["points"], (LinkList<Triangle>)Session["triangles_copy"]);
            Session["found"] = Tasks.FilterSuccess((LinkList<Triangle>)Session["triangles_copy"]);
            Session["unfound"] = Tasks.FilterUnSuccess((LinkList<Triangle>)Session["triangles_copy"]);
            ((LinkList<Triangle>)Session["found"]).Sort();
            ((LinkList<Triangle>)Session["unfound"]).Sort();
            InOut.PrintTxt((LinkList<Triangle>)Session["found"], Server.MapPath("~") + resultsPath, "Rasti perimetrai:",
                trianglesUpper);
            InOut.PrintTxt((LinkList<Triangle>)Session["unfound"], Server.MapPath("~") + resultsPath, "Nerasti perimetrai:",
                trianglesUpper);
            FillTable((LinkList<Triangle>)Session["found"], ref results1, ref Nera3, triangleHeaders);
            FillTable((LinkList<Triangle>)Session["unfound"], ref results2, ref Nera4, triangleHeaders);
            Button1.Enabled = false;

        }

        /// <summary>
        /// remove button click method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if (Tasks.Remove((LinkList<Triangle>)Session["found"], firstX, firstY, secondX, secondY, thirdX, thirdY))
                    Success.Text = "Šalinimas pavyko.";
                else  
                    Success.Text = "Šalinimas nepavyko.";
                FillTable((LinkList<Triangle>)Session["found"], ref results1, ref Nera3, triangleHeaders);
                InOut.PrintTxt((LinkList<Triangle>)Session["found"], Server.MapPath("~") + resultsPath, "Rasti perimetrai:",
                    trianglesUpper);
                InOut.PrintTxt((LinkList<Triangle>)Session["unfound"], Server.MapPath("~") + resultsPath, "Nerasti perimetrai:",
                    trianglesUpper);
            }
            

        }

        protected void Upload1_Click(object sender, EventArgs e)
        {
            if(FileUpload1.Value!= "")
            {
                string line;
                List<string> lines = new List<string>();
                using (var stream = FileUpload1.PostedFile.InputStream)
                using (var reader = new StreamReader(stream))
                {    
                    while((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
                Session["points"] = InOut.ReadPoints(lines);
                InOut.PrintTxt((LinkList<Point>)Session["points"], Server.MapPath("~") + startData, "Pradiniai duomenys \"U5a.txt\":", pointsUpper);
                FillTable((LinkList<Point>)Session["points"], ref start2, ref Nera2, pointHeaders);
                if (Session["triangles"] != null && Session["points"] != null)
                {
                    Button1.Enabled = true;
                    Trinti.Enabled = true;
                }
                FileUpload1.Attributes.Add("style", "display: none");
                Upload1.Enabled = false;
            }
            

        }

        protected void Upload2_Click(object sender, EventArgs e)
        {
            if (FileUpload2.Value != "")
            {
                string line;
                List<string> lines = new List<string>();
                using (var stream = FileUpload2.PostedFile.InputStream)
                using (var reader = new StreamReader(stream))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
                Session["triangles"] = InOut.ReadTriangles(lines);
                Session["triangles_copy"] = InOut.ReadTriangles(lines);
                InOut.PrintTxt((LinkList<Triangle>)Session["triangles"], Server.MapPath("~") + startData, "Pradiniai duomenys \"U5b.txt\"",    
                trianglesUpper);
                FillTable((LinkList<Triangle>)Session["triangles"], ref start1, ref Nera1, triangleHeaders);
                if (Session["triangles"] != null && Session["points"] != null)
                {
                    Button1.Enabled = true;
                    Trinti.Enabled = true;
                }
                FileUpload2.Attributes.Add("style", "display: hidden");
                Upload2.Enabled = false;


            }

        }
    }
}