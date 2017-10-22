namespace VehicleTracking.UI.WinApp
{
    partial class VehicleUserControl
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
            this.VehicleListBox = new System.Windows.Forms.ListBox();
            this.ArrowBtn = new System.Windows.Forms.Button();
            this.ViewPnl = new System.Windows.Forms.Panel();
            this.YearLbl = new System.Windows.Forms.Label();
            this.ColorLbl = new System.Windows.Forms.Label();
            this.ModelLbl = new System.Windows.Forms.Label();
            this.BrandLbl = new System.Windows.Forms.Label();
            this.VINLbl = new System.Windows.Forms.Label();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.AddVehicleBtn = new System.Windows.Forms.Button();
            this.DeleteVehicleBtn = new System.Windows.Forms.Button();
            this.ModifyBtn = new System.Windows.Forms.Button();
            this.ViewPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // VehicleListBox
            // 
            this.VehicleListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(233)))));
            this.VehicleListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VehicleListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.VehicleListBox.FormattingEnabled = true;
            this.VehicleListBox.ItemHeight = 20;
            this.VehicleListBox.Location = new System.Drawing.Point(48, 77);
            this.VehicleListBox.Name = "VehicleListBox";
            this.VehicleListBox.Size = new System.Drawing.Size(163, 264);
            this.VehicleListBox.TabIndex = 0;
            // 
            // ArrowBtn
            // 
            this.ArrowBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ArrowBtn.FlatAppearance.BorderSize = 0;
            this.ArrowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArrowBtn.Font = new System.Drawing.Font("Wingdings 3", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.ArrowBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ArrowBtn.Location = new System.Drawing.Point(247, 171);
            this.ArrowBtn.Name = "ArrowBtn";
            this.ArrowBtn.Size = new System.Drawing.Size(75, 75);
            this.ArrowBtn.TabIndex = 1;
            this.ArrowBtn.Text = "]";
            this.ArrowBtn.UseVisualStyleBackColor = true;
            this.ArrowBtn.Click += new System.EventHandler(this.ArrowBtn_Click);
            // 
            // ViewPnl
            // 
            this.ViewPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(233)))));
            this.ViewPnl.Controls.Add(this.YearLbl);
            this.ViewPnl.Controls.Add(this.ColorLbl);
            this.ViewPnl.Controls.Add(this.ModelLbl);
            this.ViewPnl.Controls.Add(this.BrandLbl);
            this.ViewPnl.Controls.Add(this.VINLbl);
            this.ViewPnl.Location = new System.Drawing.Point(343, 148);
            this.ViewPnl.Name = "ViewPnl";
            this.ViewPnl.Size = new System.Drawing.Size(166, 133);
            this.ViewPnl.TabIndex = 2;
            // 
            // YearLbl
            // 
            this.YearLbl.AutoSize = true;
            this.YearLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.YearLbl.Location = new System.Drawing.Point(4, 98);
            this.YearLbl.Name = "YearLbl";
            this.YearLbl.Size = new System.Drawing.Size(38, 20);
            this.YearLbl.TabIndex = 4;
            this.YearLbl.Text = "Año";
            // 
            // ColorLbl
            // 
            this.ColorLbl.AutoSize = true;
            this.ColorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ColorLbl.Location = new System.Drawing.Point(4, 78);
            this.ColorLbl.Name = "ColorLbl";
            this.ColorLbl.Size = new System.Drawing.Size(46, 20);
            this.ColorLbl.TabIndex = 3;
            this.ColorLbl.Text = "Color";
            // 
            // ModelLbl
            // 
            this.ModelLbl.AutoSize = true;
            this.ModelLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ModelLbl.Location = new System.Drawing.Point(4, 58);
            this.ModelLbl.Name = "ModelLbl";
            this.ModelLbl.Size = new System.Drawing.Size(61, 20);
            this.ModelLbl.TabIndex = 2;
            this.ModelLbl.Text = "Modelo";
            // 
            // BrandLbl
            // 
            this.BrandLbl.AutoSize = true;
            this.BrandLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrandLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.BrandLbl.Location = new System.Drawing.Point(4, 38);
            this.BrandLbl.Name = "BrandLbl";
            this.BrandLbl.Size = new System.Drawing.Size(53, 20);
            this.BrandLbl.TabIndex = 1;
            this.BrandLbl.Text = "Marca";
            // 
            // VINLbl
            // 
            this.VINLbl.AutoSize = true;
            this.VINLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VINLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.VINLbl.Location = new System.Drawing.Point(4, 18);
            this.VINLbl.Name = "VINLbl";
            this.VINLbl.Size = new System.Drawing.Size(36, 20);
            this.VINLbl.TabIndex = 0;
            this.VINLbl.Text = "VIN";
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.TitleLbl.Location = new System.Drawing.Point(41, 19);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(190, 42);
            this.TitleLbl.TabIndex = 3;
            this.TitleLbl.Text = "Vehículos";
            // 
            // AddVehicleBtn
            // 
            this.AddVehicleBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.AddVehicleBtn.FlatAppearance.BorderSize = 6;
            this.AddVehicleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddVehicleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddVehicleBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.AddVehicleBtn.Location = new System.Drawing.Point(441, 77);
            this.AddVehicleBtn.Name = "AddVehicleBtn";
            this.AddVehicleBtn.Size = new System.Drawing.Size(106, 44);
            this.AddVehicleBtn.TabIndex = 4;
            this.AddVehicleBtn.Text = "Agregar";
            this.AddVehicleBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteVehicleBtn
            // 
            this.DeleteVehicleBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.DeleteVehicleBtn.FlatAppearance.BorderSize = 6;
            this.DeleteVehicleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteVehicleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteVehicleBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.DeleteVehicleBtn.Location = new System.Drawing.Point(431, 297);
            this.DeleteVehicleBtn.Name = "DeleteVehicleBtn";
            this.DeleteVehicleBtn.Size = new System.Drawing.Size(116, 44);
            this.DeleteVehicleBtn.TabIndex = 5;
            this.DeleteVehicleBtn.Text = "Eliminar";
            this.DeleteVehicleBtn.UseVisualStyleBackColor = true;
            this.DeleteVehicleBtn.Click += new System.EventHandler(this.DeleteVehicleBtn_Click);
            // 
            // ModifyBtn
            // 
            this.ModifyBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ModifyBtn.FlatAppearance.BorderSize = 6;
            this.ModifyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ModifyBtn.Location = new System.Drawing.Point(308, 297);
            this.ModifyBtn.Name = "ModifyBtn";
            this.ModifyBtn.Size = new System.Drawing.Size(117, 44);
            this.ModifyBtn.TabIndex = 6;
            this.ModifyBtn.Text = "Modificar";
            this.ModifyBtn.UseVisualStyleBackColor = true;
            this.ModifyBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
            // 
            // VehicleUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.ModifyBtn);
            this.Controls.Add(this.DeleteVehicleBtn);
            this.Controls.Add(this.AddVehicleBtn);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.ViewPnl);
            this.Controls.Add(this.ArrowBtn);
            this.Controls.Add(this.VehicleListBox);
            this.Name = "VehicleUserControl";
            this.Size = new System.Drawing.Size(573, 378);
            this.ViewPnl.ResumeLayout(false);
            this.ViewPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox VehicleListBox;
        private System.Windows.Forms.Button ArrowBtn;
        private System.Windows.Forms.Panel ViewPnl;
        private System.Windows.Forms.Label YearLbl;
        private System.Windows.Forms.Label ColorLbl;
        private System.Windows.Forms.Label ModelLbl;
        private System.Windows.Forms.Label BrandLbl;
        private System.Windows.Forms.Label VINLbl;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Button AddVehicleBtn;
        private System.Windows.Forms.Button DeleteVehicleBtn;
        private System.Windows.Forms.Button ModifyBtn;
    }
}
