using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication2
{
    public class codificarPwd
    {
        string inPwd,inUser;

        public codificarPwd(string pwd,string user) 
        {
            this.inPwd = pwd;
            this.inUser = user;
        }

        public String returnCodPwd() 
        {
            String localPwd = "";

            System.Security.Cryptography.MD5CryptoServiceProvider pwd = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(inPwd);
            data = pwd.ComputeHash(data);
            //string localPwd = "";
            for (int i = 0; i < data.Length; i++)
            localPwd += data[i].ToString("x2").ToLower();
            
            return localPwd;
        }

        public String returnCon()
        {
            String retPwdCod = "";

            SqlConnection scSqlConnectionn = new SqlConnection(WebConfigurationManager.ConnectionStrings["Conexion_DB_Intranet"].ToString());
            scSqlConnectionn.Open();
            SqlCommand scSqlCommandnd = new SqlCommand("SELECT pwd_code FROM Usuario where usuario = '" + inUser + "'", scSqlConnectionn);
            SqlDataReader reader = scSqlCommandnd.ExecuteReader();

            if (reader.Read())
            {
                retPwdCod = Convert.ToString(reader["pwd_code"]);
            }

            return retPwdCod;
        } 
    }
}