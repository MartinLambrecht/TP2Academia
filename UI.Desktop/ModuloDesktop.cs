using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ModuloDesktop : ApplicationForm
    {
        private Modulo ModuloActual;

        public ModuloDesktop()
        {
            InitializeComponent();
        }

        public ModuloDesktop(ModoForm modo) : this()
        {
            this.modo = modo;

            MapearDeDatos();
        }

        public ModuloDesktop(int ID, ModoForm modo) : this()
        {
            this.modo = modo;
            ModulosLogic el = new ModulosLogic();
            this.ModuloActual = el.GetOne(ID);
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
                this.txtID.Text = this.ModuloActual.ID.ToString();
                this.txtDescripcion.Text = this.ModuloActual.Descripcion;
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
                this.ModuloActual = new Modulo();
            }
            this.ModuloActual.Descripcion = this.txtDescripcion.Text.Trim();
            this.ModuloActual.State = (BusinessEntity.States)(int)modo;
        }

        private new void GuardarCambios()
        {
            MapearADatos();
            ModulosLogic el = new ModulosLogic();
            el.Save(ModuloActual);
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