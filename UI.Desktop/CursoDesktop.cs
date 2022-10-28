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
    public partial class CursoDesktop : ApplicationForm
    {
        private Curso CursoActual;

        public CursoDesktop()
        {
            InitializeComponent();
        }

        public CursoDesktop(ModoForm modo) : this() //este constructor servira para las altas
        {
            this.modo = modo;
            MapearDeDatos();
        }

        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            this.modo = modo;
            CursoLogic cl = new CursoLogic();
            this.CursoActual = cl.GetOne(ID);
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
                this.txtID.Text = this.CursoActual.ID.ToString();
                this.txtDescripcion.Text = this.CursoActual.Descripcion;
                this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
                this.txtCupo.Text = this.CursoActual.Cupo.ToString();
                this.txtIDComision.Text = this.CursoActual.IDComision.ToString();
                this.txtIDMateria.Text = this.CursoActual.IDMateria.ToString();
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

        private new void MapearADatos()
        {
            if (modo == ModoForm.Alta)
            {
                this.CursoActual = new Curso();
            }
            this.CursoActual.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text.Trim()); //se puede hacer de otra forma el convertir de string a int
            this.CursoActual.Cupo = int.Parse(this.txtCupo.Text.Trim());
            this.CursoActual.Descripcion = this.txtDescripcion.Text.Trim();
            this.CursoActual.State = (BusinessEntity.States)(int)modo;

        }

        private new void GuardarCambios()
        {
            MapearADatos();
            CursoLogic cl = new CursoLogic();
            cl.Save(CursoActual);

        }

        private new bool Validar()
        {
            bool descripcionVal = ValidarCampoVacio(txtDescripcion, errorDescripcion, "La descripcion no puede estar vacia.");
            bool cupoVal = ValidarCampoVacio(txtCupo, errorCupo, "El cupo no puede estar vacio.");
            bool anioCalendarioVal = ValidarCampoVacio(txtAnioCalendario, errorAnioCalendario1, "El año del calendario no puede estar vacio.");

            bool isOK = (descripcionVal && cupoVal && anioCalendarioVal);

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
        #endregion

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
