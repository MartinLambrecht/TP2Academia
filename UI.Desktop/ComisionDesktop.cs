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
    public partial class ComisionDesktop : ApplicationForm
    {
        private Comision ComisionActual;

        public ComisionDesktop()
        {
            InitializeComponent();
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            this.modo = modo;
            MapearDeDatos();
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            this.modo = modo;
            ComisionLogic cl = new ComisionLogic();
            this.ComisionActual = cl.GetOne(ID);
            MapearDeDatos();
        }


        new public virtual void MapearDeDatos()
        {
            if (modo == ModoForm.Alta)
            {
                this.txtID.Text = "";//Cuando hace el save lo genera automaticamente autoincremental
            }
            else
            {
                this.txtID.Text = this.ComisionActual.ID.ToString();
                this.txtDescripcion.Text = this.ComisionActual.Descripcion;
                this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
                this.txtIDPlan.Text = this.ComisionActual.IDPlan.ToString();
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

        new public virtual void MapearADatos()
        {
            if (modo == ModoForm.Alta)
            {
                this.ComisionActual = new Comision();
            }
            this.ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnioEspecialidad.Text.Trim()); //se puede hacer de otra forma el convertir de string a int
            this.ComisionActual.IDPlan = int.Parse(this.txtIDPlan.Text.Trim());
            this.ComisionActual.Descripcion = this.txtDescripcion.Text.Trim();
            this.ComisionActual.State = (BusinessEntity.States)(int)modo;

        }

        new public virtual void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic cl = new ComisionLogic();
            cl.Save(ComisionActual);

        }

        new public virtual bool Validar()
        {
            bool descripcionVal = ValidarCampoVacio(txtDescripcion, errorDescripcion, "La descripcion no puede estar vacia.");
            bool idPlanVal = ValidarCampoVacio(txtIDPlan, errorIDPlan, "El Id del Plan no puede estar vacio.");
            bool anioEspecialidadVal = ValidarCampoVacio(txtAnioEspecialidad, errorAnioEspecialidad, "El año de la especialidad no puede estar vacio.");

            bool isOK = (descripcionVal && idPlanVal && anioEspecialidadVal);

            if (!isOK)
            {
                MessageBox.Show("Hay campos incorrectos, por favor verifique.", "Campos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isOK;
        }

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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool ok = Validar();
            if (ok)
            {
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
