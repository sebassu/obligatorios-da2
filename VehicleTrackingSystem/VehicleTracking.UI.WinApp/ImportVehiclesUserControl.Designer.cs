namespace VehicleTracking.UI.WinApp
{
    partial class ImportVehiclesUserControl
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
            this.TitleLbl = new System.Windows.Forms.Label();
            this.StrategiesListBox = new System.Windows.Forms.ListBox();
            this.AddStrategiesBtn = new System.Windows.Forms.Button();
            this.ImportVehiclesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.TitleLbl.Location = new System.Drawing.Point(274, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(302, 39);
            this.TitleLbl.TabIndex = 24;
            this.TitleLbl.Text = "Importar vehiculos";
            // 
            // StrategiesListBox
            // 
            this.StrategiesListBox.FormattingEnabled = true;
            this.StrategiesListBox.Location = new System.Drawing.Point(179, 65);
            this.StrategiesListBox.Name = "StrategiesListBox";
            this.StrategiesListBox.Size = new System.Drawing.Size(223, 251);
            this.StrategiesListBox.TabIndex = 25;
            // 
            // AddStrategiesBtn
            // 
            this.AddStrategiesBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.AddStrategiesBtn.FlatAppearance.BorderSize = 6;
            this.AddStrategiesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddStrategiesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStrategiesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.AddStrategiesBtn.Location = new System.Drawing.Point(491, 116);
            this.AddStrategiesBtn.Name = "AddStrategiesBtn";
            this.AddStrategiesBtn.Size = new System.Drawing.Size(217, 46);
            this.AddStrategiesBtn.TabIndex = 26;
            this.AddStrategiesBtn.Text = "Agregar estrategias";
            this.AddStrategiesBtn.UseVisualStyleBackColor = true;
            this.AddStrategiesBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddStrategiesBtn_MouseClick);
            // 
            // ImportVehiclesBtn
            // 
            this.ImportVehiclesBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ImportVehiclesBtn.FlatAppearance.BorderSize = 6;
            this.ImportVehiclesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportVehiclesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportVehiclesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ImportVehiclesBtn.Location = new System.Drawing.Point(491, 223);
            this.ImportVehiclesBtn.Name = "ImportVehiclesBtn";
            this.ImportVehiclesBtn.Size = new System.Drawing.Size(217, 46);
            this.ImportVehiclesBtn.TabIndex = 27;
            this.ImportVehiclesBtn.Text = "Importar vehiculos";
            this.ImportVehiclesBtn.UseVisualStyleBackColor = true;
            // 
            // ImportVehiclesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.ImportVehiclesBtn);
            this.Controls.Add(this.AddStrategiesBtn);
            this.Controls.Add(this.StrategiesListBox);
            this.Controls.Add(this.TitleLbl);
            this.Name = "ImportVehiclesUserControl";
            this.Size = new System.Drawing.Size(901, 365);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.ListBox StrategiesListBox;
        private System.Windows.Forms.Button AddStrategiesBtn;
        private System.Windows.Forms.Button ImportVehiclesBtn;
    }
}
