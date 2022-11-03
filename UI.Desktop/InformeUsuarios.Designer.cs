
namespace UI.Desktop
{
    partial class InformeUsuarios
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
            this.crvInformeUsuarios = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ReporteUsuarios1 = new UI.Desktop.ReporteUsuarios();
            this.SuspendLayout();
            // 
            // crvInformeUsuarios
            // 
            this.crvInformeUsuarios.ActiveViewIndex = 0;
            this.crvInformeUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvInformeUsuarios.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvInformeUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvInformeUsuarios.Location = new System.Drawing.Point(0, 0);
            this.crvInformeUsuarios.Name = "crvInformeUsuarios";
            this.crvInformeUsuarios.ReportSource = this.ReporteUsuarios1;
            this.crvInformeUsuarios.Size = new System.Drawing.Size(800, 450);
            this.crvInformeUsuarios.TabIndex = 0;
            // 
            // InformeUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvInformeUsuarios);
            this.Name = "InformeUsuarios";
            this.Text = "InformeUsuarios";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvInformeUsuarios;
        private ReporteUsuarios ReporteUsuarios1;
    }
}