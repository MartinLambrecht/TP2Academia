using Data.Database;
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
