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
    public partial class Especialidades : Form
    {

        public Usuario usuarioActual { get; set; }

        public Especialidades()
        {
            InitializeComponent();

            this.dgvEspecialidades.ReadOnly = true;

            this.dgvEspecialidades.AutoGenerateColumns = false;
            this.dgvEspecialidades.AllowUserToAddRows = false;
            this.dgvEspecialidades.AllowUserToDeleteRows = false;
            this.dgvEspecialidades.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvEspecialidades.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            AddTextColumn("id", "ID", "ID");
            AddTextColumn("descripcion", "Descripcion", "Descripcion");

        }

        public Especialidades(Usuario usuario):this()
        {
            this.usuarioActual = usuario;

            Autorizacion();
        }

        private void Autorizacion()
        {

            this.tsbNuevo.Enabled = Validaciones.HasAuthorization(usuarioActual.ID, 6, Validaciones.Permisos.Alta);
            this.tsbEliminar.Enabled = Validaciones.HasAuthorization(usuarioActual.ID, 6, Validaciones.Permisos.Baja);
            this.tsbEditar.Enabled = Validaciones.HasAuthorization(usuarioActual.ID, 6, Validaciones.Permisos.Modificacion);
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }

        private void AddTextColumn(string name, string headerText, string dataPropertyName)
        {
            DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
            newColumn.Name = name;
            newColumn.HeaderText = headerText;
            newColumn.DataPropertyName = dataPropertyName;

            this.dgvEspecialidades.Columns.Add(newColumn);
        }

        private void Especialidades_Load(object sender, EventArgs e)
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
            EspecialidadDesktop especialidadDesktop = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            especialidadDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;

            EspecialidadDesktop especialidadDesktop = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja);
            especialidadDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;

            EspecialidadDesktop especialidadDesktop = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            especialidadDesktop.ShowDialog();
            this.Listar();
        }
    }
}
