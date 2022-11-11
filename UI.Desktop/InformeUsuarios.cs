using Data.Database;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class InformeUsuarios : Form
    {
        public InformeUsuarios()
        {
            InitializeComponent();

            ReporteUsuarios rUsuarios = new ReporteUsuarios();
            rUsuarios.SetDataSource(new UsuarioAdapter().GetDSUsuarios());
            this.crvInformeUsuarios.ReportSource = rUsuarios;

            this.crvInformeUsuarios.RefreshReport();
        }
    }
}