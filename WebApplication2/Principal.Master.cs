using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

using System.Web.Configuration;

namespace WebApplication2
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        String ColumnaPrivilegio = "";
        
        protected void BindMenuControl(String ColumnaPrivilegio)
        {
            SqlConnection scSqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Conexion_DB_Intranet"].ToString());
            SqlCommand scSqlCommand = new SqlCommand("SELECT Id_Menu, Nombre_Menu, Grupo_Menu, Link_Menu FROM Menu where " + ColumnaPrivilegio + " = " + Request.Cookies["Privilegios"].Value + " order by Grupo_Menu asc", scSqlConnection);
            SqlDataAdapter sdaSqlDataAdapter = new SqlDataAdapter(scSqlCommand);
            DataSet dsDataSet = new DataSet();
            DataTable dtDataTable = null;
            try
            {
                scSqlConnection.Open();
                sdaSqlDataAdapter.Fill(dsDataSet);
                dtDataTable = dsDataSet.Tables[0];
                if (dtDataTable != null && dtDataTable.Rows.Count > 0)
                {
                    foreach (DataRow drDataRow in dtDataTable.Rows)
                    {
                        if (Convert.ToInt32(drDataRow[0]) == Convert.ToInt32(drDataRow[2]))
                        {
                            MenuItem miMenuItem = new MenuItem(Convert.ToString(drDataRow[1]), Convert.ToString(drDataRow[0]), String.Empty, Convert.ToString(drDataRow[3]));
                            this.Menu1.Items.Add(miMenuItem);
                            AddChildItem(ref miMenuItem, dtDataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                scSqlConnection.Close();
                sdaSqlDataAdapter.Dispose();
                dsDataSet.Dispose();
            }
        }

        protected void AddChildItem(ref MenuItem miMenuItem, DataTable dtDataTable)
        {

            foreach (DataRow drDataRow in dtDataTable.Rows)
            {

                if (Convert.ToInt32(drDataRow[2]) == Convert.ToInt32(miMenuItem.Value) && Convert.ToInt32(drDataRow[0]) != Convert.ToInt32(drDataRow[2]))
                {

                    MenuItem miMenuItemChild = new MenuItem(Convert.ToString(drDataRow[1]), Convert.ToString(drDataRow[0]), String.Empty, Convert.ToString(drDataRow[3]));

                    miMenuItem.ChildItems.Add(miMenuItemChild);

                    AddChildItem(ref miMenuItemChild, dtDataTable);

                }

            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Privilegios"] != null)
            {

                if (Request.Cookies["Privilegios"].Value == "1")
                    ColumnaPrivilegio = "Nro_Funcion_1";
                if (Request.Cookies["Privilegios"].Value == "2")
                    ColumnaPrivilegio = "Nro_Funcion_2";
                if (Request.Cookies["Privilegios"].Value == "3")
                    ColumnaPrivilegio = "Nro_funcion_3";
                if (Request.Cookies["Privilegios"].Value == "4")
                    ColumnaPrivilegio = "Nro_funcion_4";
                if (Request.Cookies["Privilegios"].Value == "5")
                    ColumnaPrivilegio = "Nro_funcion_5";
                if (Request.Cookies["Privilegios"].Value == "6")
                    ColumnaPrivilegio = "Nro_funcion_6";
                if (Request.Cookies["Privilegios"].Value == "7")
                    ColumnaPrivilegio = "Nro_funcion_7";
                if (Request.Cookies["Privilegios"].Value == "8")
                    ColumnaPrivilegio = "Nro_funcion_8";
                if (Request.Cookies["Privilegios"].Value == "9")
                    ColumnaPrivilegio = "Nro_funcion_9";
                if (Request.Cookies["Privilegios"].Value == "10")
                    ColumnaPrivilegio = "Nro_funcion_10";
                if (Request.Cookies["Privilegios"].Value == "11")
                    ColumnaPrivilegio = "Nro_funcion_11";
                if (Request.Cookies["Privilegios"].Value == "12")
                    ColumnaPrivilegio = "Nro_funcion_12";
                if (Request.Cookies["Privilegios"].Value == "13")
                    ColumnaPrivilegio = "Nro_funcion_13";
                if (Request.Cookies["Privilegios"].Value == "14")
                    ColumnaPrivilegio = "Nro_funcion_14";
                if (Request.Cookies["Privilegios"].Value == "15")
                    ColumnaPrivilegio = "Nro_funcion_15";
                if (Request.Cookies["Privilegios"].Value == "16")
                    ColumnaPrivilegio = "Nro_funcion_16";
                if (Request.Cookies["Privilegios"].Value == "17")
                    ColumnaPrivilegio = "Nro_funcion_17";
                if (Request.Cookies["Privilegios"].Value == "18")
                    ColumnaPrivilegio = "Nro_funcion_18";
                if (Request.Cookies["Privilegios"].Value == "19")
                    ColumnaPrivilegio = "Nro_funcion_19";
                if (Request.Cookies["Privilegios"].Value == "20")
                    ColumnaPrivilegio = "Nro_funcion_20";
                if (Request.Cookies["Privilegios"].Value == "21")
                    ColumnaPrivilegio = "Nro_funcion_21";
                if (Request.Cookies["Privilegios"].Value == "22")
                    ColumnaPrivilegio = "Nro_funcion_22";
                if (Request.Cookies["Privilegios"].Value == "23")
                    ColumnaPrivilegio = "Nro_funcion_23";
                if (Request.Cookies["Privilegios"].Value == "24")
                    ColumnaPrivilegio = "Nro_funcion_24";
                if (Request.Cookies["Privilegios"].Value == "25")
                    ColumnaPrivilegio = "Nro_funcion_25";
                if (Request.Cookies["Privilegios"].Value == "26")
                    ColumnaPrivilegio = "Nro_funcion_26";
                if (Request.Cookies["Privilegios"].Value == "27")
                    ColumnaPrivilegio = "Nro_funcion_27";
                if (Request.Cookies["Privilegios"].Value == "28")
                    ColumnaPrivilegio = "Nro_funcion_28";
                if (Request.Cookies["Privilegios"].Value == "29")
                    ColumnaPrivilegio = "Nro_funcion_29";
                if (Request.Cookies["Privilegios"].Value == "30")
                    ColumnaPrivilegio = "Nro_funcion_30";
                if (Request.Cookies["Privilegios"].Value == "31")
                    ColumnaPrivilegio = "Nro_funcion_31";
                if (Request.Cookies["Privilegios"].Value == "32")
                    ColumnaPrivilegio = "Nro_funcion_32";
                if (Request.Cookies["Privilegios"].Value == "33")
                    ColumnaPrivilegio = "Nro_funcion_33";
                if (Request.Cookies["Privilegios"].Value == "34")
                    ColumnaPrivilegio = "Nro_funcion_34";
                if (Request.Cookies["Privilegios"].Value == "35")
                    ColumnaPrivilegio = "Nro_funcion_35";
                if (Request.Cookies["Privilegios"].Value == "36")
                    ColumnaPrivilegio = "Nro_funcion_36";

                if (ColumnaPrivilegio != "")
                    BindMenuControl(ColumnaPrivilegio);
                else
                    Response.Redirect("~/login.aspx");//Response.Redirect
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }

            Label1.Text = "Conectado como " + Request.Cookies["NomUsuario"].Value;

            //String notificacionUno = "alert(\"Pie página de los documentos:\\\nUSO INTERNO DE DTS LTDA. PROHIBIDO IMPRIMIR, COPIAR O RE-ENVIAR A TERCEROS.\\\n© DTS LTDA.<08/2013>\");";
            //String notificacionDos = "alert(\"Los documentos que se contienen en el presente Catálogo son exclusivamente para uso interno de DTS y bajo ningún propósito para uso público.\\\\nDTS Ltda. declara reconocer el dominio de los respectivos titulares del derecho de autor, con pleno respeto a la Ley N° 17.336, sobre Propiedad Intelectual y los Tratados Internacionales firmados por Chile, para proteger y preservar tales derechos de terceros.\\\\n(71 A-U) En razón de lo anterior, se hace presente a Ud. que al bajar un documento pdf de nuestra colección, no puede almacenarlo, distribuirlo, imprimirlo, copiarlo o enviar a terceros vía correo electrónico o por cualquier otro medio.\n Deberá respetar el grado de confidencialidad definido en el respectivo documento.\\\\n\\\\n El no cumplimiento de estos puntos, será penalizado según Reglamento Interno de Orden, Higiene y Seguridad de DTS, Código de Ética de la empresa y la legislación aplicable.\");";
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionDos, true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/busqueda.aspx");
        }

    }
}