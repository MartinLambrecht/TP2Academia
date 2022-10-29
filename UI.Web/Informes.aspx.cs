using Business.Logic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
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
using static UI.Web.DSCupoPorMateria;

namespace UI.Web
{
    public partial class Informes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnUsuarios_Click1(object sender, EventArgs e)
        {
            ReporteUsuarios rUsuarios = new ReporteUsuarios();
            rUsuarios.SetDataSource(new UsuarioLogic().GetAll());
            crv.ReportSource = rUsuarios;

            rUsuarios.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Informacion Usuarios.");
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