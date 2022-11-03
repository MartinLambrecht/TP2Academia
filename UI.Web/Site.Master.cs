using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["IDUsuarioLogueado"] == null)
            {
                Response.Redirect("~/Login/Login.aspx");
            }
            else
            {
                Autorization();
            }
        }

        private void Autorization()
        {
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Session.Remove("IDUsuarioLogueado");
            Response.Redirect("~/Login/Login.aspx");
        }

        
    }
}