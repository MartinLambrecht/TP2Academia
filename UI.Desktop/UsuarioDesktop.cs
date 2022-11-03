using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public Usuario UsuarioActual;

        private PersonaLogic _personaLogic;
        public PersonaLogic personaLogic
        {
            get
            {
                if (_personaLogic is null)
                {
                    _personaLogic = new PersonaLogic();
                }
                return _personaLogic;
            }
        }

        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.modo = modo;
            MapearDeDatos();
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            this.UsuarioActual = ul.GetOne(ID);
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
                this.txtID.Text = this.UsuarioActual.ID.ToString();
                this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
                this.txtNombre.Text = this.UsuarioActual.Nombre;
                this.txtApellido.Text = this.UsuarioActual.Apellido;
                this.txtEmail.Text = this.UsuarioActual.Email;
                this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
                this.txtClave.Text = this.UsuarioActual.Clave;
                this.txtConfirmarClave.Text = this.UsuarioActual.Clave;

                
            }
            if (modo == ModoForm.Baja)
            {
                this.txtClave.Hide();
                this.lblClave.Hide();
                this.txtConfirmarClave.Hide();
                this.lblConfirmarClave.Hide();
            }

            //Añadir opcion nula
            var sourceCombo = personaLogic.GetAll();
            sourceCombo.Add(new Persona { ID = 0, Legajo = 0 });

            this.cmbIdPersona.DataSource = sourceCombo;
            this.cmbIdPersona.DisplayMember = "Legajo";
            this.cmbIdPersona.ValueMember = "ID";

            this.cmbIdPersona.SelectedValue = this.UsuarioActual is null ? 0: this.UsuarioActual.IDPersona;


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
                this.UsuarioActual = new Usuario();

                this.txtID.TabStop = true;
            }
            else
            {
                this.UsuarioActual.ID = Convert.ToInt32(this.txtID.Text.Trim());
            }
            this.UsuarioActual.Nombre = this.txtNombre.Text.Trim();
            this.UsuarioActual.Apellido = this.txtApellido.Text.Trim();
            this.UsuarioActual.Email = this.txtEmail.Text.Trim();
            this.UsuarioActual.NombreUsuario = this.txtUsuario.Text.Trim();
            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            this.UsuarioActual.State = (BusinessEntity.States)(int)modo;
            this.UsuarioActual.Clave = this.txtClave.Text.Trim();
            if ((int)this.cmbIdPersona.SelectedValue != 0)
            {
                this.UsuarioActual.IDPersona = Convert.ToInt32(this.cmbIdPersona.SelectedValue);
            }

        }

        private new void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }

        private new bool Validar()
        {
            bool nombreVal = ValidarCampoVacio(txtNombre, erpNombre, "El nombre no puede estar vacio.");
            bool apellidoVal = ValidarCampoVacio(txtApellido, erpApellido, "El apellido no puede estar vacio.");
            bool usuarioVal = ValidarCampoVacio(txtUsuario, erpUsuario, "El usuario no puede estar vacio.");

            bool emailVal = ValidarEmail(txtEmail, erpEmail, "El email ingresado no es valido.");

            bool claveVal = ValidarClave(txtClave, erpClave, "La clave no puede tener menos de 8 caracteres.");

            bool confirmacionClaveVal = ValidarConfirmacionClave(txtConfirmarClave, erpConfirmarClave, "La confirmación no coincide con la contraseña.");

            bool isOK = nombreVal && apellidoVal && usuarioVal && emailVal && claveVal && confirmacionClaveVal;

            if (!isOK)
            {
                MessageBox.Show("Hay campos incorrectos, por favor verifique.", "Campos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isOK;
        }

        #region ValidacionesPersonalizadas

        private bool ValidarConfirmacionClave(TextBox txtActual, ErrorProvider erpActual, string mensajeError)
        {
            if (txtActual.Text != txtClave.Text)
            {
                erpActual.SetError(txtConfirmarClave, mensajeError);
                return false;
            }
            else
            {
                erpActual.Clear();
                return true;
            }
        }

        private bool ValidarClave(TextBox txtActual, ErrorProvider erpActual, string mensajeError)
        {
            if (Validaciones.IsValidPassword(txtActual.Text))
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

        private bool ValidarEmail(TextBox txtActual, ErrorProvider erpActual, string mensajeError)
        {
            if (!Validaciones.IsValidEmail(txtEmail.Text))
            {
                erpEmail.SetError(txtEmail, mensajeError);
                return false;
            }
            else
            {
                erpEmail.Clear();
                return true;
            }
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