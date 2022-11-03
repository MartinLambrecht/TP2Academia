using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UI.Desktop
{
    public partial class ModulosUsuarios : Form
    {

        public Usuario usuarioActual { get; set; }

        public ModulosUsuarios()
        {
            InitializeComponent();

            this.dgvModulosUsuarios.ReadOnly = true;

            this.dgvModulosUsuarios.AutoGenerateColumns = false;
            this.dgvModulosUsuarios.AllowUserToAddRows = false;
            this.dgvModulosUsuarios.AllowUserToDeleteRows = false;
            this.dgvModulosUsuarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvModulosUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            AddTextColumn("id_modulo_usuario", "ID", "ID");
            AddTextColumn("idModulo", "IDModulo", "idModulo");
            AddTextColumn("idUsuario", "IDUsuario", "idUsuario");
            AddCheckColumn("permiteAlta", "Permite Alta", "PermiteAlta");
            AddCheckColumn("permiteBaja", "Permite Baja", "PermiteBaja");
            AddCheckColumn("permiteModificacion", "Permite Modificacion", "PermiteModificacion");
            AddCheckColumn("permiteConsulta", "Permite Consulta", "PermiteConsulta");

        }
        public ModulosUsuarios(Usuario usuario) : this()
        {
            this.usuarioActual = usuario;

            Autorizacion();
        }

        private void Autorizacion()
        {

            this.tsbNuevo.Enabled = Validaciones.HasAuthorization(usuarioActual.ID, 5, Validaciones.Permisos.Alta);
            this.tsbEliminar.Enabled = Validaciones.HasAuthorization(usuarioActual.ID, 5, Validaciones.Permisos.Baja);
            this.tsbEditar.Enabled = Validaciones.HasAuthorization(usuarioActual.ID, 5, Validaciones.Permisos.Modificacion);
        }

        public void Listar()
        {
            ModuloUsuarioLogic el = new ModuloUsuarioLogic();
            this.dgvModulosUsuarios.DataSource = el.GetAll();
        }

        private void AddTextColumn(string name, string headerText, string dataPropertyName)
        {
            DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
            newColumn.Name = name;
            newColumn.HeaderText = headerText;
            newColumn.DataPropertyName = dataPropertyName;

            this.dgvModulosUsuarios.Columns.Add(newColumn);
        }

        private void AddCheckColumn(string name, string headerText, string dataPropertyName)
        {
            DataGridViewCheckBoxColumn newColumn = new DataGridViewCheckBoxColumn();
            newColumn.Name = name;
            newColumn.HeaderText = headerText;
            newColumn.DataPropertyName = dataPropertyName;

            this.dgvModulosUsuarios.Columns.Add(newColumn);
        }

        private void ModulosUsuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ModuloUsuarioDesktop moduloUsuarioDesktop = new ModuloUsuarioDesktop(ApplicationForm.ModoForm.Alta);
            moduloUsuarioDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.ModuloUsuario)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).ID;

            ModuloUsuarioDesktop moduloUsuarioDesktop = new ModuloUsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
            moduloUsuarioDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.ModuloUsuario)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).ID;

            ModuloUsuarioDesktop moduloUsuarioDesktop = new ModuloUsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            moduloUsuarioDesktop.ShowDialog();
            this.Listar();
        }
    }
}
