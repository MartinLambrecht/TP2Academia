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
    public partial class Inscripciones : System.Web.UI.Page
    {
        private AlumnoInscripcion Entity { get; set; }
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

        private AlumnoInscripcionLogic _logic;
        private AlumnoInscripcionLogic logic
        {
            get
            {
                if (_logic is null)
                {
                    _logic = new AlumnoInscripcionLogic();
                }
                return _logic;
            }
        }

        private CursoLogic _cursoLogic;
        private CursoLogic cursoLogic
        {
            get
            {
                if (_cursoLogic is null)
                {
                    _cursoLogic = new CursoLogic();
                }
                return _cursoLogic;
            }
        }

        private PersonaLogic _personaLogic;
        private PersonaLogic personaLogic
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
            Autorization();
        }

        private void Autorization()
        {
            int idModulo = new ModulosLogic().GetAll().Single(m => m.Descripcion == "alumnos_inscripciones").ID;

            if (!Validaciones.HasAuthorization((int)Session["IDUsuarioLogueado"], idModulo, Validaciones.Permisos.Consulta))
            {
                Response.Redirect("~/Default.aspx");
            }
            this.btnNuevo.Enabled = Validaciones.HasAuthorization((int)Session["IDUsuarioLogueado"], idModulo, Validaciones.Permisos.Alta);
            this.btnEliminar.Enabled = Validaciones.HasAuthorization((int)Session["IDUsuarioLogueado"], idModulo, Validaciones.Permisos.Baja);
            this.btnEditar.Enabled = Validaciones.HasAuthorization((int)Session["IDUsuarioLogueado"], idModulo, Validaciones.Permisos.Modificacion);
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
            this.ddlAlumnos.SelectedValue = Convert.ToString(this.Entity.IDAlumno);
            this.ddlCurso.SelectedValue = Convert.ToString(this.Entity.IDCurso);
            this.txtCondicion.Text = this.Entity.Condicion;
            this.txtNota.Text = Convert.ToString(this.Entity.Nota);
        }

        private void LoadEntity(AlumnoInscripcion inscripcion)
        {
            inscripcion.IDAlumno = Convert.ToInt32(this.ddlAlumnos.SelectedValue);
            inscripcion.IDCurso = Convert.ToInt32(this.ddlCurso.SelectedValue);
            inscripcion.Condicion = this.txtCondicion.Text;
            if(this.txtNota.Text != ""){
                inscripcion.Nota= Convert.ToInt32(this.txtNota.Text);
            }
        }
        private void SaveEntity(AlumnoInscripcion inscripcion)
        {
            this.logic.Save(inscripcion);
            
        }
        private void DeleteEntity(int id)
        {
            this.logic.Delete(id);
        }

        private void EnableForm(bool enabled)
        {
            this.ddlAlumnos.Enabled = enabled;
            this.ddlAlumnos.DataSource = personaLogic.GetAll().Where(p=>p.TipoPersona == Persona.TipoPersonas.Estudiante).ToList();
            this.ddlAlumnos.DataTextField = "Legajo";
            this.ddlAlumnos.DataValueField = "ID";
            this.ddlAlumnos.DataBind();

            this.ddlCurso.Enabled = enabled;
            this.ddlCurso.DataSource = cursoLogic.GetAll().Where(c=>c.Cupo>0).ToList();
            this.ddlCurso.DataTextField = "ID";
            this.ddlCurso.DataValueField = "ID";
            this.ddlCurso.DataBind();

            this.txtCondicion.Enabled = enabled;
            this.txtNota.Enabled = enabled;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.formMode = FormMode.Modificacion;
                this.EnableForm(true);
                //Al editar no se puede cambiar el alumno o el curso
                this.ddlAlumnos.Enabled = false;
                this.ddlCurso.Enabled = false;
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
            this.ddlAlumnos.DataSource = null;
            this.ddlCurso.DataSource = null;
            this.txtCondicion.Text = string.Empty;
            this.txtNota.Text = string.Empty;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid || this.formMode == FormMode.Baja)
            {
                switch (this.formMode)
                {
                    case FormMode.Alta:
                        this.Entity = new AlumnoInscripcion();
                        this.LoadEntity(Entity);
                        this.SaveEntity(Entity);
                        this.ModificarCupo(Convert.ToInt32(this.ddlCurso.SelectedValue));
                        break;
                    case FormMode.Baja:
                        this.DeleteEntity(this.SelectedID);
                        this.ModificarCupo(Convert.ToInt32(this.ddlCurso.SelectedValue));
                        break;
                    case FormMode.Modificacion:
                        this.Entity = new AlumnoInscripcion();
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

        private void ModificarCupo(int idCurso)
        {
            Curso cursoActual = cursoLogic.GetOne(idCurso);
            switch (this.formMode)
            {
                case FormMode.Alta:
                    cursoActual.Cupo -= 1;
                    break;
                case FormMode.Baja:
                    cursoActual.Cupo += 1;
                    break;
            }
            cursoActual.State = BusinessEntity.States.Modified;
            cursoLogic.Save(cursoActual);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }

    }
}