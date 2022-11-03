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
using UI.Web.DSCupoPorMateriaTableAdapters;
using UI.Web.DSMateriasPorPlanTableAdapters;
using static UI.Web.DSCupoPorMateria;
using static UI.Web.DSMateriasPorPlan;

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
            
            MateriasPorPlanTableAdapter da = new MateriasPorPlanTableAdapter();
            DSMateriasPorPlan dsMateriasPorPlan = new DSMateriasPorPlan();

            MateriasPorPlanDataTable dt = (MateriasPorPlanDataTable)dsMateriasPorPlan.Tables["MateriasPorPlan"];

            da.Fill(dt);

            ReporteMateriasPorPlan rMateriasPorPlan = new ReporteMateriasPorPlan();
            rMateriasPorPlan.SetDataSource(dsMateriasPorPlan);
            crv.ReportSource = rMateriasPorPlan;

            rMateriasPorPlan.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Informacion Notas.");
        }

        protected void btnCupoPorMateria_Click(object sender, EventArgs e)
        {
            CupoPorMateriaTableAdapter da = new CupoPorMateriaTableAdapter();
            DSCupoPorMateria dsCupoPorMateria = new DSCupoPorMateria();

            CupoPorMateriaDataTable dt = (CupoPorMateriaDataTable)dsCupoPorMateria.Tables["CupoPorMateria"];

            da.Fill(dt);

            ReporteCupoPorMateria rCupoPorMateria = new ReporteCupoPorMateria();
            rCupoPorMateria.SetDataSource(dsCupoPorMateria);
            crv.ReportSource = rCupoPorMateria;

            rCupoPorMateria.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Informacion Notas.");

        }
    }
}