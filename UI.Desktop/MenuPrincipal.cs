using Business.Logic;
using System;
using System.Linq;
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
            else
            {
                Autorizacion();
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
            new Usuarios(usuarioLogueado).Show();
        }

        private void especialidadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Especialidades(usuarioLogueado).Show();
        }

        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Modulos(usuarioLogueado).Show();
        }

        private void modulosUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ModulosUsuarios(usuarioLogueado).Show();
        }

        private void listadoDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InformeUsuarios().Show();
        }

        private void listadoNotasPorMateriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InformeNotasPorMateria().Show();
        }

        private void Autorizacion()
        {
            var idModuloModulos = new ModulosLogic().GetAll().Single(m => m.Descripcion == "modulos").ID;
            var idModuloUsuarios = new ModulosLogic().GetAll().Single(m => m.Descripcion == "usuarios").ID;
            var idModuloModulosUsuarios = new ModulosLogic().GetAll().Single(m => m.Descripcion == "modulos_usuarios").ID;
            var idModuloEspecialidades = new ModulosLogic().GetAll().Single(m => m.Descripcion == "especialidades").ID;
            var idModuloInformes = new ModulosLogic().GetAll().Single(m => m.Descripcion == "informes").ID;


            this.modulosToolStripMenuItem.Enabled = Validaciones.HasAuthorization(usuarioLogueado.ID, idModuloModulos, Validaciones.Permisos.Consulta);
            this.usuariosToolStripMenuItem1.Enabled = Validaciones.HasAuthorization(usuarioLogueado.ID, idModuloUsuarios, Validaciones.Permisos.Consulta);
            this.modulosUsuariosToolStripMenuItem.Enabled = Validaciones.HasAuthorization(usuarioLogueado.ID, idModuloModulosUsuarios, Validaciones.Permisos.Consulta);
            this.especialidadesToolStripMenuItem1.Enabled = Validaciones.HasAuthorization(usuarioLogueado.ID, idModuloEspecialidades, Validaciones.Permisos.Consulta);
            this.informesToolStripMenuItem.Enabled = Validaciones.HasAuthorization(usuarioLogueado.ID, idModuloInformes, Validaciones.Permisos.Consulta);
        }

    }
}
