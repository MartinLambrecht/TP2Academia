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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();

            this.dgvUsuarios.ReadOnly = true;

            this.dgvUsuarios.AutoGenerateColumns = false;
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            AddTextColumn("id", "ID", "ID");

            AddTextColumn("nombre", "Nombre", "Nombre");

            AddTextColumn("apellido", "Apellido", "Apellido");

            AddTextColumn("usuario", "Nombre Usuario", "NombreUsuario");

            AddTextColumn("email", "Email", "Email");

            DataGridViewCheckBoxColumn enabledColumn = new DataGridViewCheckBoxColumn();
            enabledColumn.Name = "habilitado";
            enabledColumn.HeaderText = "Habilitado";
            enabledColumn.DataPropertyName = "Habilitado";

            this.dgvUsuarios.Columns.Add(enabledColumn);
            AddTextColumn("idPersona", "Id Persona", "IDPersona");

        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();
        }

        private void AddTextColumn(string name, string headerText, string dataPropertyName)
        {
            DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
            newColumn.Name = name;
            newColumn.HeaderText = headerText;
            newColumn.DataPropertyName = dataPropertyName;

            this.dgvUsuarios.Columns.Add(newColumn);
        }

        private void Usuarios_Load(object sender, EventArgs e)
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
            UsuarioDesktop usuarioDesk = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            usuarioDesk.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;

            UsuarioDesktop usuarioDesk = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
            usuarioDesk.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;

            UsuarioDesktop usuarioDesk = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            usuarioDesk.ShowDialog();
            this.Listar();
        }
    }
}
