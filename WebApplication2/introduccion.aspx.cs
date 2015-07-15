using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Data.SqlClient;
//using System.Data;

namespace WebApplication2
{
    public partial class introduccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //String ColumnaPrivilegio = "";
        ////privilegios1=1
        //protected void BindMenuControl(String ColumnaPrivilegio)
        //{
        //    SqlConnection scSqlConnection = new SqlConnection("Data Source=mant-wcontreras\\sqlexpress;Initial Catalog=SGMT;Integrated Security=True");
        //    SqlCommand scSqlCommand = new SqlCommand("SELECT id, funcion, grupos, link FROM Menu where " + ColumnaPrivilegio + " = 1 order by grupos asc", scSqlConnection);
        //    SqlDataAdapter sdaSqlDataAdapter = new SqlDataAdapter(scSqlCommand);
        //    DataSet dsDataSet = new DataSet();
        //    DataTable dtDataTable = null;
        //    try
        //    {
        //        scSqlConnection.Open();
        //        sdaSqlDataAdapter.Fill(dsDataSet);
        //        dtDataTable = dsDataSet.Tables[0];
        //        if (dtDataTable != null && dtDataTable.Rows.Count > 0)
        //        {
        //            foreach (DataRow drDataRow in dtDataTable.Rows)
        //            {
        //                if (Convert.ToInt32(drDataRow[0]) == Convert.ToInt32(drDataRow[2]))
        //                {
        //                    MenuItem miMenuItem = new MenuItem(Convert.ToString(drDataRow[1]), Convert.ToString(drDataRow[0]), String.Empty, Convert.ToString(drDataRow[3]));
        //                    this.Menu1.Items.Add(miMenuItem);
        //                    AddChildItem(ref miMenuItem, dtDataTable);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message.ToString());
        //    }
        //    finally
        //    {
        //        scSqlConnection.Close();
        //        sdaSqlDataAdapter.Dispose();
        //        dsDataSet.Dispose();
        //    }
        //}

        //protected void AddChildItem(ref MenuItem miMenuItem, DataTable dtDataTable)
        //{

        //    foreach (DataRow drDataRow in dtDataTable.Rows)
        //    {

        //        if (Convert.ToInt32(drDataRow[2]) == Convert.ToInt32(miMenuItem.Value) && Convert.ToInt32(drDataRow[0]) != Convert.ToInt32(drDataRow[2]))
        //        {

        //            MenuItem miMenuItemChild = new MenuItem(Convert.ToString(drDataRow[1]), Convert.ToString(drDataRow[0]), String.Empty, Convert.ToString(drDataRow[3]));

        //            miMenuItem.ChildItems.Add(miMenuItemChild);

        //            AddChildItem(ref miMenuItemChild, dtDataTable);

        //        }

        //    }

        //}

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (Request.Cookies["Privilegios"] != null)
        //    {
        //        if (Request.Cookies["Privilegios"].Value == "1")
        //            ColumnaPrivilegio = "privilegios1";
        //        if (Request.Cookies["Privilegios"].Value == "0")
        //            ColumnaPrivilegio = "privilegios2";
        //        //if (Request.Cookies["Privilegios"].Value == "A")
        //        //    ColumnaPrivilegio = "privilegios3";

        //        if (ColumnaPrivilegio != "")
        //            BindMenuControl(ColumnaPrivilegio);
        //        else
        //            Response.Redirect("login.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("login.aspx");
        //    }
        //}
    }
}