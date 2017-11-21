namespace VehicleTracking.UI.WinApp
{
    partial class CreateModifySubzone
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.ZoneLbl = new System.Windows.Forms.Label();
            this.CapacityLbl = new System.Windows.Forms.Label();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.NameLbl = new System.Windows.Forms.Label();
            this.ZoneComboBox = new System.Windows.Forms.ComboBox();
            this.CapacityNud = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.CapacityNud)).BeginInit();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.OkBtn.FlatAppearance.BorderSize = 6;
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.OkBtn.Location = new System.Drawing.Point(1245, 618);
            this.OkBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(317, 110);
            this.OkBtn.TabIndex = 25;
            this.OkBtn.Text = "Button 1";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OkBtn_MouseClick);
            // 
            // CancelBtn
            // 
            this.CancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.CancelBtn.FlatAppearance.BorderSize = 6;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.CancelBtn.Location = new System.Drawing.Point(882, 618);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(312, 110);
            this.CancelBtn.TabIndex = 24;
            this.CancelBtn.Text = "Cancelar";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CancelBtn_MouseClick);
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.TitleLbl.Location = new System.Drawing.Point(915, 142);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(279, 101);
            this.TitleLbl.TabIndex = 23;
            this.TitleLbl.Text = "label1";
            // 
            // ZoneLbl
            // 
            this.ZoneLbl.AutoSize = true;
            this.ZoneLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoneLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ZoneLbl.Location = new System.Drawing.Point(872, 491);
            this.ZoneLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.ZoneLbl.Name = "ZoneLbl";
            this.ZoneLbl.Size = new System.Drawing.Size(147, 55);
            this.ZoneLbl.TabIndex = 17;
            this.ZoneLbl.Text = "Zona:";
            // 
            // CapacityLbl
            // 
            this.CapacityLbl.AutoSize = true;
            this.CapacityLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CapacityLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.CapacityLbl.Location = new System.Drawing.Point(872, 393);
            this.CapacityLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.CapacityLbl.Name = "CapacityLbl";
            this.CapacityLbl.Size = new System.Drawing.Size(268, 55);
            this.CapacityLbl.TabIndex = 15;
            this.CapacityLbl.Text = "Capacidad:";
            // 
            // NameTxt
            // 
            this.NameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTxt.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.NameTxt.Location = new System.Drawing.Point(1168, 300);
            this.NameTxt.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(393, 53);
            this.NameTxt.TabIndex = 14;
            this.NameTxt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameTxt_MouseClick);
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.NameLbl.Location = new System.Drawing.Point(872, 296);
            this.NameLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(209, 55);
            this.NameLbl.TabIndex = 13;
            this.NameLbl.Text = "Nombre:";
            // 
            // ZoneComboBox
            // 
            this.ZoneComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoneComboBox.FormattingEnabled = true;
            this.ZoneComboBox.Location = new System.Drawing.Point(1168, 494);
            this.ZoneComboBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ZoneComboBox.Name = "ZoneComboBox";
            this.ZoneComboBox.Size = new System.Drawing.Size(394, 54);
            this.ZoneComboBox.TabIndex = 26;
            // 
            // CapacityNud
            // 
            this.CapacityNud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CapacityNud.Location = new System.Drawing.Point(1168, 393);
            this.CapacityNud.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.CapacityNud.Name = "CapacityNud";
            this.CapacityNud.Size = new System.Drawing.Size(394, 53);
            this.CapacityNud.TabIndex = 27;
            // 
            // CreateModifySubzone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.CapacityNud);
            this.Controls.Add(this.ZoneComboBox);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.ZoneLbl);
            this.Controls.Add(this.CapacityLbl);
            this.Controls.Add(this.NameTxt);
            this.Controls.Add(this.NameLbl);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "CreateModifySubzone";
            this.Size = new System.Drawing.Size(2403, 870);
            ((System.ComponentModel.ISupportInitialize)(this.CapacityNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Label ZoneLbl;
        private System.Windows.Forms.Label CapacityLbl;
        private System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.ComboBox ZoneComboBox;
        private System.Windows.Forms.NumericUpDown CapacityNud;
    }
}
