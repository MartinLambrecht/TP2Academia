using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class MenuPrincipal : Form
    {
        static private Business.Entities.Usuario _usuarioLogueado;

        static public Business.Entities.Usuario usuarioLogueado
        {
            get { return _usuarioLogueado; }
            set { _usuarioLogueado = value; }
        }

        public MenuPrincipal()
        {
            InitializeComponent();
        }


        private void MenuPrincipal_Shown(object sender, EventArgs e)
        {
            if (new InicioSesion().ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioDesktop usuarioDesk = new UsuarioDesktop(usuarioLogueado.ID, ApplicationForm.ModoForm.Modificacion);
            usuarioDesk.ShowDialog();
        }

        private void cerrarSesionToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (new InicioSesion().ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Usuarios().Show();
        }

        private void especialidadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Especialidades().Show();
        }

        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Modulos().Show();
        }

        private void modulosUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ModulosUsuarios().Show();
        }

    }
}
