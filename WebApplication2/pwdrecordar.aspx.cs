using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Web.Mail;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace WebApplication2
{
    public partial class pwdrecordar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtMailUser.Value = System.Environment.UserName;
                txtMail.Value = txtMailUser.Value + "@dts.cl";                
            }
        }

        protected void Button1_Click1(object sender, EventArgs e) 
        {
            codificarPwd codPwd = new codificarPwd("intranet@dts", txtMailUser.Value);

            if (SendMail(Convert.ToString(txtMail.Value)))
            {

                String cod = codPwd.returnCodPwd();

                SqlConnection scSqlConnectionn = new SqlConnection(WebConfigurationManager.ConnectionStrings["Conexion_DB_Intranet"].ToString());
                scSqlConnectionn.Open();
                SqlCommand scSqlCommandnu = new SqlCommand("update Usuario set pwd_code = '" + cod + "' where usuario = '" + txtMailUser.Value + "'", scSqlConnectionn);
                scSqlCommandnu.ExecuteNonQuery();
                scSqlConnectionn.Close();

                String notificacionUn = "alert(\"Mensaje Enviado\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUn, true);
                Response.AddHeader("REFRESH", "0.5;URL=login.aspx");
            }
            else
            {
                String notificacionUn = "alert(\"Mensaje No Enviado\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUn, true);
                Response.AddHeader("REFRESH", "0.5;URL=login.aspx");
            }
        }

        protected void Button2_Click2(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        public static bool SendMail(String email)
        {

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(email);
            msg.From = new MailAddress("adminintranet@dts.cl", "Admin Intranet", System.Text.Encoding.UTF8);
            msg.Subject = "Cambio contraseña intranet";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Estimado:<br>Esta es su nueva contraseña la cual debera cambiar.<br>Contraseña: intranet@dts<br><br>Favor no responder a este mail.<br>Admin Intranet.";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            //client.UseDefaultCredentials = true;
            //client.Credentials = new System.Net.NetworkCredential("local/wcontreras", "014789asdf");
            client.Port = 25;
            client.Host = "post2";
            client.EnableSsl = false;


            try
            {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }
    }
}