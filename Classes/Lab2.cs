using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class Lab1 : System.Web.UI.Page
    {
        protected static void FillTable(PointsLinkedList points, ref Table Table1, ref Label label)
        {
            Table1.Rows.Clear();
            if(points.Count == 0)
            {
                label.CssClass = label.CssClass.Replace("none", "");
                return;
            }
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            cell1.Text = "<b>Spalva</b>";
            cell2.Text = "<b>X</b>";
            cell3.Text = "<b>Y</b>";
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            Table1.Rows.Add(row);

            for (points.Begin(); points.Exist(); points.Next())
            {
                row = new TableRow();
                cell1 = new TableCell();
                cell2 = new TableCell();
                cell3 = new TableCell();
                cell1.Text = points.Get().Color;
                cell2.Text = (points.Get().CoordX).ToString();
                cell3.Text = (points.Get().CoordY).ToString();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                Table1.Rows.Add(row);
            }
        }
        protected static void FillTable(TrianglesLinkedList triangles, ref Table Table1, ref Label label)
        {
            if(triangles != null)
            {
                Table1.Rows.Clear();
                if (triangles.Count == 0)
                {
                    label.CssClass = label.CssClass.Replace("none", "");
                    return;
                }
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();
                TableCell cell4 = new TableCell();
                TableCell cell5 = new TableCell();
                TableCell cell6 = new TableCell();
                TableCell cell7 = new TableCell();
                TableCell cell8 = new TableCell();
                cell1.Text = "<b>Spalva</b>";
                cell2.Text = "<b>1 X</b>";
                cell3.Text = "<b>1 Y</b>";
                cell4.Text = "<b>2 X</b>";
                cell5.Text = "<b>2 Y</b>";
                cell6.Text = "<b>3 X</b>";
                cell7.Text = "<b>3 Y</b>";
                cell8.Text = "<b>Perimetras</b>";
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
                row.Cells.Add(cell6);
                row.Cells.Add(cell7);
                row.Cells.Add(cell8);

                Table1.Rows.Add(row);

                for (triangles.Begin(); triangles.Exist(); triangles.Next())
                {
                    row = new TableRow();
                    cell1 = new TableCell();
                    cell2 = new TableCell();
                    cell3 = new TableCell();
                    cell4 = new TableCell();
                    cell5 = new TableCell();
                    cell6 = new TableCell();
                    cell7 = new TableCell();
                    cell8 = new TableCell();
                    string h = triangles.Get().ToString();
                    string[] values = h.Split('|');
                    cell1.Text = values[1];
                    cell2.Text = values[2];
                    cell3.Text = values[3];
                    cell4.Text = values[4];
                    cell5.Text = values[5];
                    cell6.Text = values[6];
                    cell7.Text = values[7];
                    cell8.Text = values[8];
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Cells.Add(cell5);
                    row.Cells.Add(cell6);
                    row.Cells.Add(cell7);
                    row.Cells.Add(cell8);
                    Table1.Rows.Add(row);

                }
            
            }
        }
    }
}