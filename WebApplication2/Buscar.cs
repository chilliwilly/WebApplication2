using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public class Buscar
    {
        public String nro_documento { get; set; }
        public String nombre_documento { get; set; }
        public String dir_documento { get; set; }
    }

    public class detBuscar
    {
        public static List<Buscar> getEquipoCli(String criteria) 
        {
            List<Buscar> dBuscar = new List<Buscar>();
            String conSql = System.Configuration.ConfigurationManager.ConnectionStrings["Conexion_DB_Intranet"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conSql)) 
            {
                con.Open();
                string qry = "SELECT * FROM BUSQUEDA WHERE NRO_DOCUMENTO LIKE '%'+@buscar+'%' OR NOMBRE_DOCUMENTO LIKE '%'+@buscar+'%'";
                SqlCommand cmd = new SqlCommand(qry, con);                
                cmd.Parameters.Add(new SqlParameter("buscar", SqlDbType.VarChar)).Value = criteria;
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read()) 
                {
                    Buscar dBusca = new Buscar();
                    dBusca.nro_documento = Convert.ToString(read["Nro_Documento"]);
                    dBusca.nombre_documento = Convert.ToString(read["Nombre_Documento"]);
                    dBusca.dir_documento = getDireccion(Convert.ToString(read["Dir_Documento"]));

                    dBuscar.Add(dBusca);
                }
            }          

            return dBuscar;
        }

        private static String getDireccion(String inDir)
        {
            String[] splitDir = inDir.Replace("\\","/").Split('/');

            String pal = "";

            for (int i = 5; i < splitDir.Length; i++)
            {
                if (i == 5)
                {
                    pal = "~/" + splitDir[i];
                }
                else
                {
                    pal = pal + "/" + splitDir[i];
                }
            }

            return pal;
        }
    }
}