using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Web.Configuration;

namespace WebApplication2.Acceso
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            string pwdUsuario = "";

            if(!Page.IsPostBack)
            {
                //TextBox1.Text = System.Environment.UserName;
                txtUser.Value = Environment.UserName;//Convert.ToString(System.Security.Principal.WindowsIdentity.GetCurrent().User.Translate(typeof(System.Security.Principal.NTAccount)));//System.Environment.UserName;
                //TextBox2.Attributes["type"] = "password";
                txtPwd.Attributes["type"] = "password";            

                codificarPwd comparaPwd = new codificarPwd("intranet@dts",txtUser.Value);

                SqlConnection scSqlConnectionn = new SqlConnection(WebConfigurationManager.ConnectionStrings["Conexion_DB_Intranet"].ToString());
                scSqlConnectionn.Open();
                //SqlConnection.Open();

                SqlCommand scSqlCommandn = new SqlCommand("SELECT pwd_code FROM Usuario where usuario = '" + txtUser.Value + "'", scSqlConnectionn);
                SqlDataReader reader = scSqlCommandn.ExecuteReader();

                if (reader.Read())
                {
                    //TextBox2.Text = Convert.ToString(reader["pwd_usuario"]);
                    pwdUsuario = Convert.ToString(reader["pwd_code"]);
                    if (pwdUsuario.Equals(""))
                    {
                        Response.Redirect("pwdcambiar.aspx");
                    }
                    if(pwdUsuario.Equals(comparaPwd.returnCodPwd()))
                    {
                        String notificacionUno = "alert(\"De acuerdo al mail recibido, su contraseña actual debe cambiarla.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
                        Response.AddHeader("REFRESH", "0.5;URL=pwdcambiar.aspx");   
                    }
                }
            }

            //String notificacionDos = "alert(\"md5 " + resultado + "\");";
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionDos, true);
        }
        
        private void MessageBoxShow(Page page, string message)
        {
            Literal ltr = new Literal();
            ltr.Text = @"<script type='text/javascript'> alert('" + message + "') </script>";
            page.Controls.Add(ltr);
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //INICIO NORMAL DE LOGIN
            String Usuario = "";
            String Password = "";
            String Privilegios = "";
            String NomUsuario = "";

            //String userIn = txtUser.Value;
            //String pwdIn = txtPwd.Value;

            SqlConnection SqlConnection = null;
            SqlCommand SqlCommand = null;

            codificarPwd revPwd = new codificarPwd(txtPwd.Value,txtUser.Value);

            if (revPwd.returnCon().Equals(revPwd.returnCodPwd()))
            {
                SqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Conexion_DB_Intranet"].ToString());
                SqlCommand = new SqlCommand("select usuario,pwd_code,perfil_usuario,nombre + ' ' + ap_paterno from Usuario where usuario='" + txtUser.Value + "'", SqlConnection);
                SqlDataAdapter sdaSqlDataAdapter = new SqlDataAdapter(SqlCommand);
                DataSet dsDataSet = new DataSet();
                DataTable dtDataTable = null;
                try
                {
                    SqlConnection.Open();

                    sdaSqlDataAdapter.Fill(dsDataSet);

                    dtDataTable = dsDataSet.Tables[0];

                    if (dtDataTable != null && dtDataTable.Rows.Count > 0)
                    {
                        foreach (DataRow drDataRow in dtDataTable.Rows)
                        {
                            Usuario = Convert.ToString(drDataRow[0]);
                            Password = Convert.ToString(drDataRow[1]);
                            Privilegios = Convert.ToString(drDataRow[2]);
                            NomUsuario = Convert.ToString(drDataRow[3]);
                        }
                    }
                    if (Usuario == txtUser.Value)
                        if (Password == revPwd.returnCodPwd())
                        {
                            HttpCookie cookie = new HttpCookie("Privilegios");
                            HttpCookie cookiee = new HttpCookie("Usuario");
                            HttpCookie cookie_nom = new HttpCookie("NomUsuario");
                            cookie.Value = Privilegios;
                            cookiee.Value = Usuario;
                            cookie_nom.Value = NomUsuario;
                            cookie.Expires = DateTime.Now.AddMinutes(45);
                            cookiee.Expires = DateTime.Now.AddMinutes(45);
                            cookie_nom.Expires = DateTime.Now.AddMinutes(45);
                            Response.Cookies.Add(cookie);
                            Response.Cookies.Add(cookiee);
                            Response.Cookies.Add(cookie_nom);

                            Response.Redirect("~/introduccion.aspx");//Response.Redirect,false
                        }
                }
                catch (Exception ex) { MessageBoxShow(this, ex.Message); }
                finally
                {
                    SqlConnection.Close();
                    sdaSqlDataAdapter.Dispose();
                    dsDataSet.Dispose();
                    dtDataTable.Dispose();
                }
            }
            else 
            {
                String notificacionUno = "alert(\"Contraseña ingresada no coincide.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
                Response.AddHeader("REFRESH", "0.5;URL=login.aspx");
            }

            
            //FIN INICIO NORMAL LOGIN
        }
    }
}