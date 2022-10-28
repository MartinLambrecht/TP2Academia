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
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
            this.dgvComisiones.ReadOnly = true; //que sea de solo lectura 
            this.dgvComisiones.AutoGenerateColumns = false; //No agregue columnas automáticamente
            this.dgvComisiones.AllowUserToAddRows = false;
            this.dgvComisiones.AllowUserToDeleteRows = false;
            this.dgvComisiones.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvComisiones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            AddTextColumn("id", "ID", "ID");
            AddTextColumn("anio especialidad", "AnioEspecialidad", "AnioEspecialidad");
            AddTextColumn("descripcion", "Descripcion", "Descripcion");
            AddTextColumn("Id Plan", "IDPlan", "IDPlan");
        }

        private void AddTextColumn(string name, string headerText, string dataPropertyName)
        {
            DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
            newColumn.Name = name;
            newColumn.HeaderText = headerText;
            newColumn.DataPropertyName = dataPropertyName;

            this.dgvComisiones.Columns.Add(newColumn);
        }

        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            this.dgvComisiones.DataSource = cl.GetAll(); //se define el origen de datos con el DataSource
        }

        private void Comisiones_Load(object sender, EventArgs e)
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
            ComisionDesktop comisionDesk = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            comisionDesk.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop comisionDesk = new ComisionDesktop(ApplicationForm.ModoForm.Modificacion);
            comisionDesk.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop comisionDesk = new ComisionDesktop(ApplicationForm.ModoForm.Baja);
            comisionDesk.ShowDialog();
            this.Listar();
        }
    }
}
