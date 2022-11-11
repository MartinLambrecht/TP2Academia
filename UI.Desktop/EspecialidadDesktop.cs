using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class EspecialidadDesktop : ApplicationForm
    {
        private Especialidad EspecialidadActual;

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm modo) : this()
        {
            this.modo = modo;

            MapearDeDatos();
        }

        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            this.modo = modo;
            EspecialidadLogic el = new EspecialidadLogic();
            this.EspecialidadActual = el.GetOne(ID);
            MapearDeDatos();
        }

        private new void MapearDeDatos()
        {
            if (modo == ModoForm.Alta)
            {
                this.txtID.Text = "";//Cuando hace el save lo genera automaticamente autoincremental
            }
            else
            {
                this.txtID.Text = this.EspecialidadActual.ID.ToString();
                this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
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

                    this.txtDescripcion.ReadOnly = true;
                    this.txtDescripcion.TabStop = false;
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
            if (modo == ModoForm.Alta)
            {
                this.EspecialidadActual = new Especialidad();
            }
            this.EspecialidadActual.Descripcion = this.txtDescripcion.Text.Trim();
            this.EspecialidadActual.State = (BusinessEntity.States)(int)modo;
        }

        private new void GuardarCambios()
        {
            MapearADatos();
            EspecialidadLogic el = new EspecialidadLogic();
            el.Save(EspecialidadActual);
        }

        private new bool Validar()
        {
            bool descripcionVal = ValidarCampoVacio(txtDescripcion, erpDescripcion, "La descripcion no puede estar vacia.");

            bool isOK = descripcionVal;

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