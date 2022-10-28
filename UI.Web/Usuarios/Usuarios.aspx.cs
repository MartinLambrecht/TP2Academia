using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        private Usuario Entity { get; set; }
        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }
        private bool isEntitySelected
        {
            get
            {
                return this.SelectedID != 0;
            }
        }

        private UsuarioLogic _logic;
        private UsuarioLogic logic
        {
            get
            {
                if (_logic is null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        public enum FormMode
        {
            Alta, Baja, Modificacion
        }

        public FormMode formMode
        {
            get { return (FormMode)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.logic.GetAll();
            this.gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
            this.formPanel.Visible = false;
        }

        protected void LoadForm(int id)
        {
            this.Entity = logic.GetOne(id);
            this.txtNombre.Text = this.Entity.Nombre;
            this.txtApellido.Text = this.Entity.Apellido;
            this.txtEmail.Text = this.Entity.Email;
            this.chkHabilitado.Checked = this.Entity.Habilitado;
            this.txtNombreUsuario.Text = this.Entity.NombreUsuario;
            this.txtClave.Attributes["value"] = this.Entity.Clave;
            this.txtRepetirClave.Attributes["value"] = this.Entity.Clave;
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = this.txtNombre.Text;
            usuario.Apellido = this.txtApellido.Text;
            usuario.Email = this.txtEmail.Text;
            usuario.NombreUsuario = this.txtNombreUsuario.Text;
            usuario.Habilitado = this.chkHabilitado.Checked;
            usuario.Clave = this.txtClave.Text;
        }
        private void SaveEntity(Usuario usuario)
        {
            this.logic.Save(usuario);
        }
        private void DeleteEntity(int id)
        {
            this.logic.Delete(id);
        }

        private void EnableForm(bool enabled)
        {
            this.txtNombre.Enabled = enabled;
            this.txtApellido.Enabled = enabled;
            this.txtEmail.Enabled = enabled;
            this.chkHabilitado.Enabled = enabled;
            this.txtNombreUsuario.Enabled = enabled;
            this.txtClave.Enabled = enabled;
            this.txtRepetirClave.Enabled = enabled;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.formMode = FormMode.Modificacion;
                this.EnableForm(true);
                this.LoadForm(this.SelectedID);
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.formMode = FormMode.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            this.formPanel.Visible = true;
            this.formMode = FormMode.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.chkHabilitado.Checked = true;
            this.txtNombreUsuario.Text = string.Empty;
            this.txtClave.Attributes["value"] = string.Empty;
            this.txtRepetirClave.Attributes["value"] = string.Empty;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid || this.formMode == FormMode.Baja)
            {
                switch (this.formMode)
                {
                    case FormMode.Alta:
                        this.Entity = new Usuario();
                        this.LoadEntity(Entity);
                        this.SaveEntity(Entity);
                        break;
                    case FormMode.Baja:
                        this.DeleteEntity(this.SelectedID);
                        break;
                    case FormMode.Modificacion:
                        this.Entity = new Usuario();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(Entity);
                        this.SaveEntity(Entity);
                        break;
                    default:
                        throw new NotImplementedException();
                }
                this.LoadGrid();

                this.formPanel.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }

        protected void ValidateEmail(object source, ServerValidateEventArgs args)
        {
            bool validationsResult = Validaciones.IsValidEmail(args.Value);

            args.IsValid = validationsResult;
        }

        protected void ValidatePassword(object source, ServerValidateEventArgs args)
        {
            bool validationsResult = Validaciones.IsValidPassword(args.Value);

            args.IsValid = validationsResult;
        }
    }
}