
namespace UI.Desktop
{
    partial class UsuarioDesktop
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuarioDesktop));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtConfirmarClave = new System.Windows.Forms.TextBox();
            this.lblConfirmarClave = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.erpNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpApellido = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpClave = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpConfirmarClave = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblIdPersona = new System.Windows.Forms.Label();
            this.cmbIdPersona = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpApellido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpConfirmarClave)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Controls.Add(this.lblNombre, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblEmail, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblClave, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtClave, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtApellido, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUsuario, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtConfirmarClave, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblConfirmarClave, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblUsuario, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblApellido, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkHabilitado, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblIdPersona, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbIdPersona, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.erpNombre.SetIconPadding(this.tableLayoutPanel1, 3);
            this.erpApellido.SetIconPadding(this.tableLayoutPanel1, 3);
            this.erpConfirmarClave.SetIconPadding(this.tableLayoutPanel1, 3);
            this.erpClave.SetIconPadding(this.tableLayoutPanel1, 3);
            this.erpEmail.SetIconPadding(this.tableLayoutPanel1, 3);
            this.erpUsuario.SetIconPadding(this.tableLayoutPanel1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 135);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(8, 32);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(14, 58);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email";
            // 
            // lblClave
            // 
            this.lblClave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(13, 84);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(34, 13);
            this.lblClave.TabIndex = 3;
            this.lblClave.Text = "Clave";
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.erpNombre.SetIconPadding(this.txtID, 3);
            this.erpApellido.SetIconPadding(this.txtID, 3);
            this.erpConfirmarClave.SetIconPadding(this.txtID, 3);
            this.erpClave.SetIconPadding(this.txtID, 3);
            this.erpEmail.SetIconPadding(this.txtID, 3);
            this.erpUsuario.SetIconPadding(this.txtID, 3);
            this.txtID.Location = new System.Drawing.Point(64, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(121, 20);
            this.txtID.TabIndex = 0;
            this.txtID.TabStop = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.erpNombre.SetIconPadding(this.txtNombre, 3);
            this.erpApellido.SetIconPadding(this.txtNombre, 3);
            this.erpConfirmarClave.SetIconPadding(this.txtNombre, 3);
            this.erpClave.SetIconPadding(this.txtNombre, 3);
            this.erpEmail.SetIconPadding(this.txtNombre, 3);
            this.erpUsuario.SetIconPadding(this.txtNombre, 3);
            this.txtNombre.Location = new System.Drawing.Point(64, 29);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.erpNombre.SetIconPadding(this.txtEmail, 3);
            this.erpApellido.SetIconPadding(this.txtEmail, 3);
            this.erpConfirmarClave.SetIconPadding(this.txtEmail, 3);
            this.erpClave.SetIconPadding(this.txtEmail, 3);
            this.erpEmail.SetIconPadding(this.txtEmail, 3);
            this.erpUsuario.SetIconPadding(this.txtEmail, 3);
            this.txtEmail.Location = new System.Drawing.Point(64, 55);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(121, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // txtClave
            // 
            this.txtClave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.erpNombre.SetIconPadding(this.txtClave, 3);
            this.erpApellido.SetIconPadding(this.txtClave, 3);
            this.erpConfirmarClave.SetIconPadding(this.txtClave, 3);
            this.erpClave.SetIconPadding(this.txtClave, 3);
            this.erpEmail.SetIconPadding(this.txtClave, 3);
            this.erpUsuario.SetIconPadding(this.txtClave, 3);
            this.txtClave.Location = new System.Drawing.Point(64, 81);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(121, 20);
            this.txtClave.TabIndex = 6;
            // 
            // txtApellido
            // 
            this.txtApellido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.erpNombre.SetIconPadding(this.txtApellido, 3);
            this.erpApellido.SetIconPadding(this.txtApellido, 3);
            this.erpConfirmarClave.SetIconPadding(this.txtApellido, 3);
            this.erpClave.SetIconPadding(this.txtApellido, 3);
            this.erpEmail.SetIconPadding(this.txtApellido, 3);
            this.erpUsuario.SetIconPadding(this.txtApellido, 3);
            this.txtApellido.Location = new System.Drawing.Point(301, 29);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(106, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.erpNombre.SetIconPadding(this.txtUsuario, 3);
            this.erpApellido.SetIconPadding(this.txtUsuario, 3);
            this.erpConfirmarClave.SetIconPadding(this.txtUsuario, 3);
            this.erpClave.SetIconPadding(this.txtUsuario, 3);
            this.erpEmail.SetIconPadding(this.txtUsuario, 3);
            this.erpUsuario.SetIconPadding(this.txtUsuario, 3);
            this.txtUsuario.Location = new System.Drawing.Point(301, 55);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(106, 20);
            this.txtUsuario.TabIndex = 5;
            // 
            // txtConfirmarClave
            // 
            this.txtConfirmarClave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.erpNombre.SetIconPadding(this.txtConfirmarClave, 3);
            this.erpApellido.SetIconPadding(this.txtConfirmarClave, 3);
            this.erpConfirmarClave.SetIconPadding(this.txtConfirmarClave, 3);
            this.erpClave.SetIconPadding(this.txtConfirmarClave, 3);
            this.erpEmail.SetIconPadding(this.txtConfirmarClave, 3);
            this.erpUsuario.SetIconPadding(this.txtConfirmarClave, 3);
            this.txtConfirmarClave.Location = new System.Drawing.Point(301, 81);
            this.txtConfirmarClave.Name = "txtConfirmarClave";
            this.txtConfirmarClave.Size = new System.Drawing.Size(106, 20);
            this.txtConfirmarClave.TabIndex = 7;
            // 
            // lblConfirmarClave
            // 
            this.lblConfirmarClave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConfirmarClave.AutoSize = true;
            this.lblConfirmarClave.Location = new System.Drawing.Point(214, 84);
            this.lblConfirmarClave.Name = "lblConfirmarClave";
            this.lblConfirmarClave.Size = new System.Drawing.Size(81, 13);
            this.lblConfirmarClave.TabIndex = 10;
            this.lblConfirmarClave.Text = "Confirmar Clave";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(233, 58);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 9;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblApellido
            // 
            this.lblApellido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(232, 32);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 8;
            this.lblApellido.Text = "Apellido";
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Checked = true;
            this.chkHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHabilitado.Location = new System.Drawing.Point(218, 4);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitado.TabIndex = 1;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(301, 109);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(81, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAceptar.Location = new System.Drawing.Point(214, 109);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(81, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblId
            // 
            this.lblId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(21, 6);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID";
            // 
            // erpNombre
            // 
            this.erpNombre.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erpNombre.ContainerControl = this;
            this.erpNombre.Icon = ((System.Drawing.Icon)(resources.GetObject("erpNombre.Icon")));
            // 
            // erpApellido
            // 
            this.erpApellido.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erpApellido.ContainerControl = this;
            this.erpApellido.Icon = ((System.Drawing.Icon)(resources.GetObject("erpApellido.Icon")));
            // 
            // erpEmail
            // 
            this.erpEmail.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erpEmail.ContainerControl = this;
            this.erpEmail.Icon = ((System.Drawing.Icon)(resources.GetObject("erpEmail.Icon")));
            // 
            // erpUsuario
            // 
            this.erpUsuario.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erpUsuario.ContainerControl = this;
            this.erpUsuario.Icon = ((System.Drawing.Icon)(resources.GetObject("erpUsuario.Icon")));
            // 
            // erpClave
            // 
            this.erpClave.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erpClave.ContainerControl = this;
            this.erpClave.Icon = ((System.Drawing.Icon)(resources.GetObject("erpClave.Icon")));
            // 
            // erpConfirmarClave
            // 
            this.erpConfirmarClave.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erpConfirmarClave.ContainerControl = this;
            this.erpConfirmarClave.Icon = ((System.Drawing.Icon)(resources.GetObject("erpConfirmarClave.Icon")));
            // 
            // lblIdPersona
            // 
            this.lblIdPersona.AutoSize = true;
            this.lblIdPersona.Location = new System.Drawing.Point(3, 104);
            this.lblIdPersona.Name = "lblIdPersona";
            this.lblIdPersona.Size = new System.Drawing.Size(55, 13);
            this.lblIdPersona.TabIndex = 11;
            this.lblIdPersona.Text = "IdPersona";
            // 
            // cmbIdPersona
            // 
            this.cmbIdPersona.FormattingEnabled = true;
            this.cmbIdPersona.Location = new System.Drawing.Point(64, 107);
            this.cmbIdPersona.Name = "cmbIdPersona";
            this.cmbIdPersona.Size = new System.Drawing.Size(121, 21);
            this.cmbIdPersona.TabIndex = 12;
            // 
            // UsuarioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 135);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UsuarioDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpApellido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpConfirmarClave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtConfirmarClave;
        private System.Windows.Forms.Label lblConfirmarClave;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ErrorProvider erpNombre;
        private System.Windows.Forms.ErrorProvider erpApellido;
        private System.Windows.Forms.ErrorProvider erpEmail;
        private System.Windows.Forms.ErrorProvider erpUsuario;
        private System.Windows.Forms.ErrorProvider erpClave;
        private System.Windows.Forms.ErrorProvider erpConfirmarClave;
        private System.Windows.Forms.Label lblIdPersona;
        private System.Windows.Forms.ComboBox cmbIdPersona;
    }
}