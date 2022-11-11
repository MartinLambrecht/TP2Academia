using Business.Logic;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Informes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Autorization();
        }

        private void Autorization()
        {
            int idModulo = new ModulosLogic().GetAll().Single(m => m.Descripcion == "informes").ID;

            if (!Validaciones.HasAuthorization((int)Session["IDUsuarioLogueado"], idModulo, Validaciones.Permisos.Consulta))
            {
                Response.Redirect("~/Default.aspx");
            }
            this.btnMateriasPorPlanes.Enabled = Validaciones.HasAuthorization((int)Session["IDUsuarioLogueado"], idModulo, Validaciones.Permisos.Consulta);
            this.btnCupoPorMateria.Enabled = Validaciones.HasAuthorization((int)Session["IDUsuarioLogueado"], idModulo, Validaciones.Permisos.Consulta);
        }

        protected void btnMateriasPorPlanes_Click(object sender, EventArgs e)
        {
            ReporteMateriasPorPlan rMateriasPorPlan = new ReporteMateriasPorPlan();
            rMateriasPorPlan.SetDataSource(new MateriaAdapter().GetDSMaterias());
            crv.ReportSource = rMateriasPorPlan;

            rMateriasPorPlan.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Informacion Notas.");
        }

        protected void btnCupoPorMateria_Click(object sender, EventArgs e)
        {
           

            ReporteCupoPorMateria rCupoPorMateria = new ReporteCupoPorMateria();
            rCupoPorMateria.SetDataSource(new AlumnoInscripcionAdapter().GetDSInscripciones());
            crv.ReportSource = rCupoPorMateria;

            rCupoPorMateria.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Informacion Notas.");

        }
    }
}