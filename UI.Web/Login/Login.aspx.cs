using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Home : System.Web.UI.Page
    {
        private UsuarioLogic _usuarioLogic = new UsuarioLogic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            this.txtNombreUsuario.Text = "net";
            this.txtContraseña.Text = "net";
        }

        protected void btnLoguearse_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario loggedUser = _usuarioLogic.GetAll().Single<Usuario>((user) => user.NombreUsuario == this.txtNombreUsuario.Text && user.Clave == this.txtContraseña.Text);
                this.Session.Add("IDUsuarioLogueado", loggedUser.ID);
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception)
            {
                this.lblWarning.Text = "Usuario y/o contraseña incorrectos.";

            }

        }
    }
}