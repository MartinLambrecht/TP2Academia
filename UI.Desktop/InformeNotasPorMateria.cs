using Data.Database;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class InformeNotasPorMateria : Form
    {
        public InformeNotasPorMateria()
        {
            InitializeComponent();

            ReporteNotasPorMateria rNotasPorMateria = new ReporteNotasPorMateria();
            rNotasPorMateria.SetDataSource(new AlumnoInscripcionAdapter().GetDSNotasPorMateria());
            this.crvInformeNotasPorMateria.ReportSource = rNotasPorMateria;

            this.crvInformeNotasPorMateria.RefreshReport();
        }
    }
}