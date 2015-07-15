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
    public partial class pwdcambiar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!Page.IsPostBack)
            {
                txtCambUser.Value = System.Environment.UserName;
                txtOldPw.Attributes["type"] = "password";
                txtCambioPw.Attributes["type"] = "password";
                txtCambioPwn.Attributes["type"] = "password";

                if(nullPwdCode())
                {
                    txtOldPw.Disabled = true;
                }
            }
        }

        protected Boolean nullPwdCode()
        {
            Boolean nullPwd = false;
            String oldPwd = "";

            SqlConnection pwdSqlConnectionn = new SqlConnection(WebConfigurationManager.ConnectionStrings["Conexion_DB_Intranet"].ToString());
            pwdSqlConnectionn.Open();

            SqlCommand pwdSqlCommandn = new SqlCommand("SELECT pwd_code FROM Usuario where usuario = '" + txtCambUser.Value + "'", pwdSqlConnectionn);
            SqlDataReader pwdReader = pwdSqlCommandn.ExecuteReader();

            if (pwdReader.Read())
            {
                oldPwd = Convert.ToString(pwdReader["pwd_code"]);

                if (oldPwd.Equals(""))
                {
                    nullPwd = true;
                }
            }

            return nullPwd;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            String revOldPwd = txtOldPw.Value;
            String newPwd = txtCambioPw.Value;
            String newPwdR = txtCambioPwn.Value;
            String cPwd = "";
            String cPwdn = "";
            String notificacionUno = "alert(\"Contraseña ingresada no coincide.\");";

            codificarPwd codPwd = new codificarPwd(newPwd,txtCambUser.Value);
            cPwd = codPwd.returnCodPwd();
            codificarPwd codPwdn = new codificarPwd(newPwdR, txtCambUser.Value);
            cPwdn = codPwdn.returnCodPwd();

            SqlConnection scSqlConnectionn = new SqlConnection(WebConfigurationManager.ConnectionStrings["Conexion_DB_Intranet"].ToString());
            //scSqlConnectionn.Open();

            if(revOldPwd.Equals(""))
            {
                //ENTRA PORQUE EL USUARIO AUN NO TIENE CONTRASEÑA EN FORMATO MD5
                if (cPwd.Equals(cPwdn))
                {
                    scSqlConnectionn.Open();
                    SqlCommand scSqlCommandnu = new SqlCommand("update Usuario set pwd_code = '" + cPwdn + "' where usuario = '" + txtCambUser.Value + "'", scSqlConnectionn);
                    scSqlCommandnu.ExecuteNonQuery();
                    scSqlConnectionn.Close();

                    String notificacionUn = "alert(\"Contraseña ingresada exitosamente. Sera redireccionado al login a continuación.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUn, true);
                    Response.AddHeader("REFRESH", "1;URL=login.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
                    scSqlConnectionn.Close();
                    txtCambioPw.Value = "";
                    txtCambioPwn.Value = "";
                }
            }
            else
            {
                codificarPwd codOldPwd = new codificarPwd(revOldPwd,txtCambUser.Value);

                if (codOldPwd.returnCon().Equals(codOldPwd.returnCodPwd()))//reader["pwd_code"].Equals(codOldPwd.returnCodPwd())
                {
                    if (cPwd.Equals(cPwdn))
                    {
                        scSqlConnectionn.Open();
                        SqlCommand scSqlCommandnt = new SqlCommand("update Usuario set pwd_code = '" + cPwdn + "' where usuario = '" + txtCambUser.Value + "'", scSqlConnectionn);
                        scSqlCommandnt.ExecuteNonQuery();
                        scSqlConnectionn.Close();

                        String notificacionU = "alert(\"Contraseña cambiada exitosamente. Sera redireccionado al login a continuación.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionU, true);
                        //Response.Redirect("login.aspx");
                        Response.AddHeader("REFRESH", "1;URL=login.aspx");
                    }
                    else 
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
                        txtCambioPw.Value = "";
                        txtCambioPwn.Value = "";
                    }

                }
                else
                {
                    String notificacionD = "alert(\"Contraseña actual no coincide.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionD, true);
                    scSqlConnectionn.Close();
                    txtOldPw.Value = "";
                }
            }
        }

        protected void Button2_Click2(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}