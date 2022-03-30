﻿using System;
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


        /// <summary>
        /// page load method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Enabled = false;
            Trinti.Enabled = false;

            File.Delete(Server.MapPath("~") + startData);
            File.Delete(Server.MapPath("~") + resultsPath);            
            
            if(Session["found"] != null)
            {
                FillTable((LinkList<Triangle>)Session["found"], ref results1, ref Nera3);
            }
            if(Session["unfound"] != null)
            {
                FillTable((LinkList<Triangle>)Session["unfound"], ref results2, ref Nera4);
            }
            if (Session["triangles"] != null)
            {
                FillTable((LinkList<Triangle>)Session["triangles"], ref start1, ref Nera1);
            }
            if (Session["points"] != null)
            {
                FillTable((LinkList<Point>)Session["points"], ref start2, ref Nera2);
            }
            if (Session["triangles"] != null && Session["points"] != null)
            {
                Button1.Enabled = true;
                Trinti.Enabled = true;
            }
        }

        /// <summary>
        /// run button click method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Tasks.Solve((LinkList<Point>)Session["points"], (LinkList<Triangle>)Session["triangles"]);
            Session["found"] = Tasks.FilterSuccess((LinkList<Triangle>)Session["triangles"]);
            Session["unfound"] = Tasks.FilterUnSuccess((LinkList<Triangle>)Session["triangles"]);
            ((LinkList<Triangle>)Session["found"]).Sort();
            ((LinkList<Triangle>)Session["unfound"]).Sort();
            InOut.Print((LinkList<Triangle>)Session["found"], Server.MapPath("~") + resultsPath, "Rasti perimetrai:");
            InOut.Print((LinkList<Triangle>)Session["unfound"], Server.MapPath("~") + resultsPath, "Nerasti perimetrai:");
            FillTable((LinkList<Triangle>)Session["found"], ref results1, ref Nera3);
            FillTable((LinkList<Triangle>)Session["unfound"], ref results2, ref Nera4);

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
                FillTable((LinkList<Triangle>)Session["found"], ref results1, ref Nera3);
                InOut.Print((LinkList<Triangle>)Session["found"], Server.MapPath("~") + resultsPath, "Rasti perimetrai:");
                InOut.Print((LinkList<Triangle>)Session["unfound"], Server.MapPath("~") + resultsPath, "Nerasti perimetrai:");
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
                InOut.Print((LinkList<Point>)Session["points"], Server.MapPath("~") + startData, "Pradiniai duomenys \"U5a.txt\":");
                FillTable((LinkList<Point>)Session["points"], ref start2, ref Nera2);
                if (Session["triangles"] != null && Session["points"] != null)
                {
                    Button1.Enabled = true;
                    Trinti.Enabled = true;
                }
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
                InOut.Print((LinkList<Triangle>)Session["triangles"], Server.MapPath("~") + startData, "Pradiniai duomenys \"U5b.txt\"");
                FillTable((LinkList<Triangle>)Session["triangles"], ref start1, ref Nera1);
                if (Session["triangles"] != null && Session["points"] != null)
                {
                    Button1.Enabled = true;
                    Trinti.Enabled = true;
                }


            }
        }
    }
}