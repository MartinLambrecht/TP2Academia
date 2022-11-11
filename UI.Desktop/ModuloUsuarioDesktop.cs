using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ModuloUsuarioDesktop : ApplicationForm
    {
        private ModuloUsuario ModuloUsuarioActual;

        public ModuloUsuarioDesktop()
        {
            InitializeComponent();
        }

        public ModuloUsuarioDesktop(ModoForm modo) : this()
        {
            this.modo = modo;

            MapearDeDatos();
        }

        public ModuloUsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.modo = modo;
            ModuloUsuarioLogic el = new ModuloUsuarioLogic();
            this.ModuloUsuarioActual = el.GetOne(ID);
            MapearDeDatos();
        }

        private new void MapearDeDatos()
        {
            this.cmbIdModulo.DisplayMember = "Descripcion";
            this.cmbIdModulo.ValueMember = "ID";
            this.cmbIdModulo.DataSource = new ModulosLogic().GetAll();

            this.cmbIdUsuario.DisplayMember = "NombreUsuario";
            this.cmbIdUsuario.ValueMember = "ID";
            this.cmbIdUsuario.DataSource = new UsuarioLogic().GetAll();

            if (modo == ModoForm.Alta)
            {
                this.txtID.Text = "";//Cuando hace el save lo genera automaticamente autoincremental
            }
            else
            {
                this.txtID.Text = this.ModuloUsuarioActual.ID.ToString();
                this.cmbIdModulo.SelectedValue = this.ModuloUsuarioActual.IDModulo;
                this.cmbIdUsuario.SelectedValue = this.ModuloUsuarioActual.IDUsuario;
                this.cmbIdModulo.Enabled = false;
                this.cmbIdUsuario.Enabled = false;

                this.chkAlta.Checked = this.ModuloUsuarioActual.PermiteAlta;
                this.chkBaja.Checked = this.ModuloUsuarioActual.PermiteBaja;
                this.chkModificacion.Checked = this.ModuloUsuarioActual.PermiteModificacion;
                this.chkConsulta.Checked = this.ModuloUsuarioActual.PermiteConsulta;
            }

            switch (modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja";
                    this.btnAceptar.Text = "Eliminar";

                    this.cmbIdModulo.Enabled = false;
                    this.cmbIdUsuario.Enabled = false;
                    this.chkAlta.Enabled = false;
                    this.chkBaja.Enabled = false;
                    this.chkModificacion.Enabled = false;
                    this.chkConsulta.Enabled = false;
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Consulta:
                    this.Text = "Consulta";
                    this.btnAceptar.Text = "Aceptar";
                    break;

                default:
                    break;
            }
        }

        private new void MapearADatos()
        {
            if (this.modo == ModoForm.Alta)
            {
                this.ModuloUsuarioActual = new ModuloUsuario();
            }

            this.ModuloUsuarioActual.IDModulo = (int)this.cmbIdModulo.SelectedValue;
            this.ModuloUsuarioActual.IDUsuario = (int)this.cmbIdUsuario.SelectedValue;

            this.ModuloUsuarioActual.PermiteAlta = this.chkAlta.Checked;
            this.ModuloUsuarioActual.PermiteBaja = this.chkBaja.Checked;
            this.ModuloUsuarioActual.PermiteModificacion = this.chkModificacion.Checked;
            this.ModuloUsuarioActual.PermiteConsulta = this.chkConsulta.Checked;

            this.ModuloUsuarioActual.State = (BusinessEntity.States)(int)modo;
        }

        private new void GuardarCambios()
        {
            MapearADatos();
            ModuloUsuarioLogic el = new ModuloUsuarioLogic();
            el.Save(ModuloUsuarioActual);
        }

        private new bool Validar()
        {
            bool isOK = true;

            if (!isOK)
            {
                MessageBox.Show("Hay campos incorrectos, por favor verifique.", "Campos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isOK;
        }

        #region ValidacionesPersonalizadas

        private bool ValidarCampoVacio(TextBox txtActual, ErrorProvider erpActual, string mensajeError)
        {
            if (String.IsNullOrEmpty(txtActual.Text.Trim()))
            {
                erpActual.SetError(txtActual, mensajeError);
                return false;
            }
            else
            {
                erpActual.Clear();
                return true;
            }
        }

        #endregion ValidacionesPersonalizadas

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool ok = Validar();
            if (ok) { GuardarCambios(); this.Close(); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}