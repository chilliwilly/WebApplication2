using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int limit = Request.Cookies.Count - 1;
            //String nomCookie = "";
            //for (int i = 0; i <= limit; i++ )
            //{
            //    nomCookie = Request.Cookies[i].Name;
            //    HttpCookie outCookie = new HttpCookie(nomCookie);
            //    outCookie.Expires = DateTime.Now.AddMinutes(-1);
            //    Response.Cookies.Add(outCookie);
            //}
            Response.Cookies.Clear();
            Response.Redirect("~/login.aspx");
        }
    }
}