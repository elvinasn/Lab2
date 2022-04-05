using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Lab2
{
    /// <summary>
    /// partial class to work with form elements
    /// </summary>
    public partial class Lab1 : System.Web.UI.Page
    {
        /// <summary>
        /// fills asp net table with given list
        /// </summary>
        /// <typeparam name="Type">type</typeparam>
        /// <param name="list">list of data</param>
        /// <param name="Table1">Table where to fill</param>
        /// <param name="label">label of the table</param>
        /// <param name="headers">headers of the table</param>
        protected static void FillTable <Type>(IEnumerable<Type> list, ref Table Table1, ref Label label, string[] headers)
        {
            Table1.Rows.Clear();
            if(list.Count() == 0)
            {
                label.CssClass = label.CssClass.Replace("none", "");
                return;
            }
            else
            {
                label.CssClass = "none";
            }
            TableRow row = new TableRow();
            foreach(string header in headers)
            {
                TableCell cell = new TableCell();
                cell.Text = "<b>" + header + "</b>";
                row.Cells.Add(cell);
            }
            Table1.Rows.Add(row);

            foreach(Type T in list)
            {

                row = new TableRow();
                string[] values = T.ToString().Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
                foreach(string value in values)
                {
                    TableCell cell = new TableCell();
                    cell.Text = value.Trim();
                    row.Cells.Add(cell);
                }
                Table1.Rows.Add(row);
            }
        }
 
    }
}