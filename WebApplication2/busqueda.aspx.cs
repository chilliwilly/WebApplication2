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
    public partial class busqueda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            String criterioBusca = TextBox1.Text;
            setDataGridBuscar(criterioBusca);
        }

        private void setDataGridBuscar(String criterio) 
        {
            GridView1.DataSource = detBuscar.getEquipoCli(criterio);
            GridView1.DataBind();
        }
    }
}