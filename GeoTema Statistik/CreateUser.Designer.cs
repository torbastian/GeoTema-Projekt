namespace GeoTema_Statistik
{
    partial class frmCreateUser
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
            this.lblRoles = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbnSuper = new System.Windows.Forms.RadioButton();
            this.rbnStandard = new System.Windows.Forms.RadioButton();
            this.cbMustChange = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Location = new System.Drawing.Point(73, 76);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(37, 13);
            this.lblRoles.TabIndex = 1;
            this.lblRoles.Text = "Roller:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(91, 9);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(125, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(91, 41);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(125, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(14, 12);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(65, 13);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Brugernavn:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(23, 41);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(141, 157);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 157);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Anuller";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbnSuper
            // 
            this.rbnSuper.AutoSize = true;
            this.rbnSuper.Location = new System.Drawing.Point(116, 74);
            this.rbnSuper.Name = "rbnSuper";
            this.rbnSuper.Size = new System.Drawing.Size(87, 17);
            this.rbnSuper.TabIndex = 7;
            this.rbnSuper.Text = "Super Bruger";
            this.rbnSuper.UseVisualStyleBackColor = true;
            // 
            // rbnStandard
            // 
            this.rbnStandard.AutoSize = true;
            this.rbnStandard.Checked = true;
            this.rbnStandard.Location = new System.Drawing.Point(116, 97);
            this.rbnStandard.Name = "rbnStandard";
            this.rbnStandard.Size = new System.Drawing.Size(102, 17);
            this.rbnStandard.TabIndex = 8;
            this.rbnStandard.TabStop = true;
            this.rbnStandard.Text = "Standard Bruger";
            this.rbnStandard.UseVisualStyleBackColor = true;
            // 
            // cbMustChange
            // 
            this.cbMustChange.AutoSize = true;
            this.cbMustChange.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbMustChange.Location = new System.Drawing.Point(32, 134);
            this.cbMustChange.Name = "cbMustChange";
            this.cbMustChange.Size = new System.Drawing.Size(184, 17);
            this.cbMustChange.TabIndex = 9;
            this.cbMustChange.Text = "Ændre password ved næste login";
            this.cbMustChange.UseVisualStyleBackColor = true;
            // 
            // frmCreateUser
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(228, 192);
            this.Controls.Add(this.cbMustChange);
            this.Controls.Add(this.rbnStandard);
            this.Controls.Add(this.rbnSuper);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblRoles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCreateUser";
            this.ShowIcon = false;
            this.Text = "Ny Bruger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbnSuper;
        private System.Windows.Forms.RadioButton rbnStandard;
        private System.Windows.Forms.CheckBox cbMustChange;
    }
}