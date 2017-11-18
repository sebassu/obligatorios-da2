namespace VehicleTracking.UI.WinApp
{
    partial class ImportVehiclesForm
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
            this.LayoutPanel = new System.Windows.Forms.Panel();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.ImportVehiclesBtn = new System.Windows.Forms.Button();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.LayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.Controls.Add(this.ContainerPanel);
            this.LayoutPanel.Controls.Add(this.ImportVehiclesBtn);
            this.LayoutPanel.Controls.Add(this.TitleLbl);
            this.LayoutPanel.Location = new System.Drawing.Point(0, 1);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.Size = new System.Drawing.Size(901, 522);
            this.LayoutPanel.TabIndex = 0;
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.Location = new System.Drawing.Point(3, 73);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(895, 352);
            this.ContainerPanel.TabIndex = 29;
            // 
            // ImportVehiclesBtn
            // 
            this.ImportVehiclesBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ImportVehiclesBtn.FlatAppearance.BorderSize = 6;
            this.ImportVehiclesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportVehiclesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportVehiclesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ImportVehiclesBtn.Location = new System.Drawing.Point(648, 431);
            this.ImportVehiclesBtn.Name = "ImportVehiclesBtn";
            this.ImportVehiclesBtn.Size = new System.Drawing.Size(217, 46);
            this.ImportVehiclesBtn.TabIndex = 28;
            this.ImportVehiclesBtn.Text = "Importar vehiculos";
            this.ImportVehiclesBtn.UseVisualStyleBackColor = true;
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.TitleLbl.Location = new System.Drawing.Point(25, 22);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(302, 39);
            this.TitleLbl.TabIndex = 25;
            this.TitleLbl.Text = "Importar vehiculos";
            // 
            // ImportVehiclesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(901, 523);
            this.Controls.Add(this.LayoutPanel);
            this.Name = "ImportVehiclesForm";
            this.Text = "Importar vehiculos";
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LayoutPanel;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Button ImportVehiclesBtn;
        private System.Windows.Forms.Panel ContainerPanel;
    }
}