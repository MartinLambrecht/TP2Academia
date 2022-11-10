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
