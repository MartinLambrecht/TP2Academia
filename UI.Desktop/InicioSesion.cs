using Business.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var usuarioLogueando = new { NombreUsuario = this.txtUsuario.Text, Clave = this.txtPass.Text };

            //Validar que este en usuarios y que coincida la contraseña
            Business.Logic.UsuarioLogic userLogic = new Business.Logic.UsuarioLogic();
            List<Usuario> listaUsuarios = userLogic.GetAll();

            Usuario usuarioEncontrado = new Usuario();
            Boolean flag = false;

            foreach (Usuario usuarioActual in listaUsuarios)
            {
                if (usuarioActual.NombreUsuario == usuarioLogueando.NombreUsuario && usuarioActual.Clave == usuarioLogueando.Clave)
                {
                    usuarioEncontrado = usuarioActual;
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                MenuPrincipal.usuarioLogueado = usuarioEncontrado;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}