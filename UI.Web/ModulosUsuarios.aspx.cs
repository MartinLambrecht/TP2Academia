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
    public partial class ModulosUsuarios : System.Web.UI.Page
    {
        private ModuloUsuario Entity { get; set; }
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

        private ModuloUsuarioLogic _logic;
        private ModuloUsuarioLogic logic
        {
            get
            {
                if (_logic is null)
                {
                    _logic = new ModuloUsuarioLogic();
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
            this.ddlUsuarios.SelectedValue = Convert.ToString(this.Entity.IDUsuario);
            this.ddlModulo.SelectedValue = Convert.ToString(this.Entity.IDModulo);
            this.chkPermiteAlta.Checked = this.Entity.PermiteAlta;
            this.chkPermiteBaja.Checked = this.Entity.PermiteBaja;
            this.chkPermiteModificacion.Checked = this.Entity.PermiteModificacion;
            this.chkPermiteConsulta.Checked = this.Entity.PermiteConsulta;
        }

        private void LoadEntity(ModuloUsuario moduloUsuario)
        {
            moduloUsuario.IDUsuario = Convert.ToInt32(this.ddlUsuarios.SelectedValue);
            moduloUsuario.IDModulo = Convert.ToInt32(this.ddlModulo.SelectedValue);
            moduloUsuario.PermiteAlta = this.chkPermiteAlta.Checked;
            moduloUsuario.PermiteBaja = this.chkPermiteBaja.Checked;
            moduloUsuario.PermiteModificacion = this.chkPermiteModificacion.Checked;
            moduloUsuario.PermiteConsulta = this.chkPermiteConsulta.Checked;
        }

        private void SaveEntity(ModuloUsuario inscripcion)
        {
            this.logic.Save(inscripcion);
        }
        private void DeleteEntity(int id)
        {
            this.logic.Delete(id);
        }

        private void EnableForm(bool enabled)
        {
            this.ddlUsuarios.Enabled = enabled;
            this.ddlUsuarios.DataSource = new UsuarioLogic().GetAll();
            this.ddlUsuarios.DataTextField = "Apellido";
            this.ddlUsuarios.DataValueField = "ID";
            this.ddlUsuarios.DataBind();

            this.ddlModulo.Enabled = enabled;
            this.ddlModulo.DataSource = new ModulosLogic().GetAll();
            this.ddlModulo.DataTextField = "Descripcion";
            this.ddlModulo.DataValueField = "ID";
            this.ddlModulo.DataBind();

            this.chkPermiteAlta.Enabled = enabled;
            this.chkPermiteBaja.Enabled = enabled;
            this.chkPermiteModificacion.Enabled = enabled;
            this.chkPermiteConsulta.Enabled = enabled;

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
            this.ddlModulo.DataSource = null;
            this.ddlUsuarios.DataSource = null;
            this.chkPermiteAlta.Checked = false;
            this.chkPermiteBaja.Checked = false;
            this.chkPermiteModificacion.Checked = false;
            this.chkPermiteConsulta.Checked = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid || this.formMode == FormMode.Baja)
            {
                switch (this.formMode)
                {
                    case FormMode.Alta:
                        this.Entity = new ModuloUsuario();
                        this.LoadEntity(Entity);
                        this.SaveEntity(Entity);
                        break;
                    case FormMode.Baja:
                        this.DeleteEntity(this.SelectedID);
                        break;
                    case FormMode.Modificacion:
                        this.Entity = new ModuloUsuario();
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

    }
}