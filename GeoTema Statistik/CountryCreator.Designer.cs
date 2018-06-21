namespace GeoTema_Statistik
{
    partial class frmCountryCreator
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
            this.txtLand = new System.Windows.Forms.TextBox();
            this.nudRang = new System.Windows.Forms.NumericUpDown();
            this.nudFoedsel = new System.Windows.Forms.NumericUpDown();
            this.lblLand = new System.Windows.Forms.Label();
            this.lblVerden = new System.Windows.Forms.Label();
            this.lblRang = new System.Windows.Forms.Label();
            this.lblFoedsel = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbbVerdensdel = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudRang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFoedsel)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLand
            // 
            this.txtLand.Location = new System.Drawing.Point(83, 12);
            this.txtLand.Name = "txtLand";
            this.txtLand.Size = new System.Drawing.Size(182, 20);
            this.txtLand.TabIndex = 0;
            // 
            // nudRang
            // 
            this.nudRang.Location = new System.Drawing.Point(83, 66);
            this.nudRang.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudRang.Name = "nudRang";
            this.nudRang.Size = new System.Drawing.Size(45, 20);
            this.nudRang.TabIndex = 2;
            // 
            // nudFoedsel
            // 
            this.nudFoedsel.DecimalPlaces = 2;
            this.nudFoedsel.Location = new System.Drawing.Point(204, 66);
            this.nudFoedsel.Name = "nudFoedsel";
            this.nudFoedsel.Size = new System.Drawing.Size(61, 20);
            this.nudFoedsel.TabIndex = 3;
            // 
            // lblLand
            // 
            this.lblLand.AutoSize = true;
            this.lblLand.Location = new System.Drawing.Point(43, 15);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(34, 13);
            this.lblLand.TabIndex = 3;
            this.lblLand.Text = "Land:";
            // 
            // lblVerden
            // 
            this.lblVerden.AutoSize = true;
            this.lblVerden.Location = new System.Drawing.Point(14, 41);
            this.lblVerden.Name = "lblVerden";
            this.lblVerden.Size = new System.Drawing.Size(63, 13);
            this.lblVerden.TabIndex = 3;
            this.lblVerden.Text = "Verdensdel:";
            // 
            // lblRang
            // 
            this.lblRang.AutoSize = true;
            this.lblRang.Location = new System.Drawing.Point(41, 68);
            this.lblRang.Name = "lblRang";
            this.lblRang.Size = new System.Drawing.Size(36, 13);
            this.lblRang.TabIndex = 3;
            this.lblRang.Text = "Rang:";
            // 
            // lblFoedsel
            // 
            this.lblFoedsel.AutoSize = true;
            this.lblFoedsel.Location = new System.Drawing.Point(134, 68);
            this.lblFoedsel.Name = "lblFoedsel";
            this.lblFoedsel.Size = new System.Drawing.Size(64, 13);
            this.lblFoedsel.TabIndex = 3;
            this.lblFoedsel.Text = "Fødeslsrate:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(190, 94);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Anuller";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbbVerdensdel
            // 
            this.cbbVerdensdel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbVerdensdel.FormattingEnabled = true;
            this.cbbVerdensdel.Items.AddRange(new object[] {
            "Asien",
            "Afrika",
            "Nordamerika",
            "Sydamerika",
            "Antarktis",
            "Europa",
            "Oceanien"});
            this.cbbVerdensdel.Location = new System.Drawing.Point(83, 38);
            this.cbbVerdensdel.Name = "cbbVerdensdel";
            this.cbbVerdensdel.Size = new System.Drawing.Size(182, 21);
            this.cbbVerdensdel.TabIndex = 1;
            // 
            // frmCountryCreator
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(277, 125);
            this.Controls.Add(this.cbbVerdensdel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblFoedsel);
            this.Controls.Add(this.lblRang);
            this.Controls.Add(this.lblVerden);
            this.Controls.Add(this.lblLand);
            this.Controls.Add(this.nudFoedsel);
            this.Controls.Add(this.nudRang);
            this.Controls.Add(this.txtLand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCountryCreator";
            this.ShowIcon = false;
            this.Text = "Opret Land";
            this.Load += new System.EventHandler(this.frmCountryCreator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudRang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFoedsel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLand;
        private System.Windows.Forms.NumericUpDown nudRang;
        private System.Windows.Forms.NumericUpDown nudFoedsel;
        private System.Windows.Forms.Label lblLand;
        private System.Windows.Forms.Label lblVerden;
        private System.Windows.Forms.Label lblRang;
        private System.Windows.Forms.Label lblFoedsel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbbVerdensdel;
    }
}