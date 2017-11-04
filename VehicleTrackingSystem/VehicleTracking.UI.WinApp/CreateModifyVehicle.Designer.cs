namespace VehicleTracking.UI.WinApp
{
    partial class CreateModifyVehicle
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
            this.YearTxt = new System.Windows.Forms.TextBox();
            this.YearLbl = new System.Windows.Forms.Label();
            this.ColorTxt = new System.Windows.Forms.TextBox();
            this.ColorLbl = new System.Windows.Forms.Label();
            this.ModelTxt = new System.Windows.Forms.TextBox();
            this.ModelLbl = new System.Windows.Forms.Label();
            this.BrandTxt = new System.Windows.Forms.TextBox();
            this.BrandLbl = new System.Windows.Forms.Label();
            this.VINTxt = new System.Windows.Forms.TextBox();
            this.VINLbl = new System.Windows.Forms.Label();
            this.ImportBtn = new System.Windows.Forms.Button();
            this.TypeLbl = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.OkBtn.FlatAppearance.BorderSize = 6;
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.OkBtn.Location = new System.Drawing.Point(457, 313);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(119, 46);
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
            this.CancelBtn.Location = new System.Drawing.Point(330, 313);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(117, 46);
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
            this.TitleLbl.Location = new System.Drawing.Point(379, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(109, 39);
            this.TitleLbl.TabIndex = 23;
            this.TitleLbl.Text = "label1";
            // 
            // YearTxt
            // 
            this.YearTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearTxt.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.YearTxt.Location = new System.Drawing.Point(403, 268);
            this.YearTxt.Name = "YearTxt";
            this.YearTxt.Size = new System.Drawing.Size(187, 26);
            this.YearTxt.TabIndex = 22;
            this.YearTxt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.YearTxt_MouseClick);
            this.YearTxt.Leave += new System.EventHandler(this.YearTxt_Leave);
            // 
            // YearLbl
            // 
            this.YearLbl.AutoSize = true;
            this.YearLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.YearLbl.Location = new System.Drawing.Point(312, 268);
            this.YearLbl.Name = "YearLbl";
            this.YearLbl.Size = new System.Drawing.Size(50, 24);
            this.YearLbl.TabIndex = 21;
            this.YearLbl.Text = "Año:";
            // 
            // ColorTxt
            // 
            this.ColorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorTxt.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.ColorTxt.Location = new System.Drawing.Point(403, 228);
            this.ColorTxt.Name = "ColorTxt";
            this.ColorTxt.Size = new System.Drawing.Size(187, 26);
            this.ColorTxt.TabIndex = 20;
            this.ColorTxt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ColorTxt_MouseClick);
            // 
            // ColorLbl
            // 
            this.ColorLbl.AutoSize = true;
            this.ColorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ColorLbl.Location = new System.Drawing.Point(312, 232);
            this.ColorLbl.Name = "ColorLbl";
            this.ColorLbl.Size = new System.Drawing.Size(60, 24);
            this.ColorLbl.TabIndex = 19;
            this.ColorLbl.Text = "Color:";
            // 
            // ModelTxt
            // 
            this.ModelTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelTxt.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.ModelTxt.Location = new System.Drawing.Point(404, 186);
            this.ModelTxt.Name = "ModelTxt";
            this.ModelTxt.Size = new System.Drawing.Size(186, 26);
            this.ModelTxt.TabIndex = 18;
            this.ModelTxt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ModelTxt_MouseClick);
            // 
            // ModelLbl
            // 
            this.ModelLbl.AutoSize = true;
            this.ModelLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ModelLbl.Location = new System.Drawing.Point(312, 188);
            this.ModelLbl.Name = "ModelLbl";
            this.ModelLbl.Size = new System.Drawing.Size(79, 24);
            this.ModelLbl.TabIndex = 17;
            this.ModelLbl.Text = "Modelo:";
            // 
            // BrandTxt
            // 
            this.BrandTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrandTxt.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.BrandTxt.Location = new System.Drawing.Point(404, 145);
            this.BrandTxt.Name = "BrandTxt";
            this.BrandTxt.Size = new System.Drawing.Size(186, 26);
            this.BrandTxt.TabIndex = 16;
            this.BrandTxt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BrandTxt_MouseClick);
            // 
            // BrandLbl
            // 
            this.BrandLbl.AutoSize = true;
            this.BrandLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrandLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.BrandLbl.Location = new System.Drawing.Point(312, 147);
            this.BrandLbl.Name = "BrandLbl";
            this.BrandLbl.Size = new System.Drawing.Size(67, 24);
            this.BrandLbl.TabIndex = 15;
            this.BrandLbl.Text = "Marca:";
            // 
            // VINTxt
            // 
            this.VINTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VINTxt.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.VINTxt.Location = new System.Drawing.Point(404, 104);
            this.VINTxt.Name = "VINTxt";
            this.VINTxt.Size = new System.Drawing.Size(186, 26);
            this.VINTxt.TabIndex = 14;
            this.VINTxt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VINTxt_MouseClick);
            // 
            // VINLbl
            // 
            this.VINLbl.AutoSize = true;
            this.VINLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VINLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.VINLbl.Location = new System.Drawing.Point(312, 106);
            this.VINLbl.Name = "VINLbl";
            this.VINLbl.Size = new System.Drawing.Size(46, 24);
            this.VINLbl.TabIndex = 13;
            this.VINLbl.Text = "VIN:";
            // 
            // ImportBtn
            // 
            this.ImportBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ImportBtn.FlatAppearance.BorderSize = 6;
            this.ImportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ImportBtn.Location = new System.Drawing.Point(608, 17);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(119, 46);
            this.ImportBtn.TabIndex = 26;
            this.ImportBtn.Text = "Importar";
            this.ImportBtn.UseVisualStyleBackColor = true;
            this.ImportBtn.Visible = false;
            // 
            // TypeLbl
            // 
            this.TypeLbl.AutoSize = true;
            this.TypeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.TypeLbl.Location = new System.Drawing.Point(313, 67);
            this.TypeLbl.Name = "TypeLbl";
            this.TypeLbl.Size = new System.Drawing.Size(53, 24);
            this.TypeLbl.TabIndex = 27;
            this.TypeLbl.Text = "Tipo:";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(403, 65);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(187, 28);
            this.TypeComboBox.TabIndex = 28;
            // 
            // CreateModifyVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.TypeLbl);
            this.Controls.Add(this.ImportBtn);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.YearTxt);
            this.Controls.Add(this.YearLbl);
            this.Controls.Add(this.ColorTxt);
            this.Controls.Add(this.ColorLbl);
            this.Controls.Add(this.ModelTxt);
            this.Controls.Add(this.ModelLbl);
            this.Controls.Add(this.BrandTxt);
            this.Controls.Add(this.BrandLbl);
            this.Controls.Add(this.VINTxt);
            this.Controls.Add(this.VINLbl);
            this.Name = "CreateModifyVehicle";
            this.Size = new System.Drawing.Size(901, 365);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.TextBox YearTxt;
        private System.Windows.Forms.Label YearLbl;
        private System.Windows.Forms.TextBox ColorTxt;
        private System.Windows.Forms.Label ColorLbl;
        private System.Windows.Forms.TextBox ModelTxt;
        private System.Windows.Forms.Label ModelLbl;
        private System.Windows.Forms.TextBox BrandTxt;
        private System.Windows.Forms.Label BrandLbl;
        private System.Windows.Forms.TextBox VINTxt;
        private System.Windows.Forms.Label VINLbl;
        private System.Windows.Forms.Button ImportBtn;
        private System.Windows.Forms.Label TypeLbl;
        private System.Windows.Forms.ComboBox TypeComboBox;
    }
}
