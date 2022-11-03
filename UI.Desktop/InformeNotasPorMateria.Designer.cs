
namespace UI.Desktop
{
    partial class InformeNotasPorMateria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crvInformeNotasPorMateria = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ReporteNotasPorMateria1 = new UI.Desktop.ReporteNotasPorMateria();
            this.SuspendLayout();
            // 
            // crvInformeNotasPorMateria
            // 
            this.crvInformeNotasPorMateria.ActiveViewIndex = 0;
            this.crvInformeNotasPorMateria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvInformeNotasPorMateria.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvInformeNotasPorMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvInformeNotasPorMateria.Location = new System.Drawing.Point(0, 0);
            this.crvInformeNotasPorMateria.Name = "crvInformeNotasPorMateria";
            this.crvInformeNotasPorMateria.ReportSource = this.ReporteNotasPorMateria1;
            this.crvInformeNotasPorMateria.Size = new System.Drawing.Size(800, 450);
            this.crvInformeNotasPorMateria.TabIndex = 0;
            // 
            // InformeNotasPorMateria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvInformeNotasPorMateria);
            this.Name = "InformeNotasPorMateria";
            this.Text = "InformeNotasPorMateria";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvInformeNotasPorMateria;
        private ReporteNotasPorMateria ReporteNotasPorMateria1;
    }
}