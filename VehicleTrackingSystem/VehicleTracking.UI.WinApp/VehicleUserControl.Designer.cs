﻿namespace VehicleTracking.UI.WinApp
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
            this.showArrowBtn = new System.Windows.Forms.Button();
            this.ViewPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // VehicleListBox
            // 
            this.VehicleListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(233)))));
            this.VehicleListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VehicleListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.VehicleListBox.FormattingEnabled = true;
            this.VehicleListBox.ItemHeight = 46;
            this.VehicleListBox.Location = new System.Drawing.Point(395, 174);
            this.VehicleListBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.VehicleListBox.Name = "VehicleListBox";
            this.VehicleListBox.Size = new System.Drawing.Size(633, 602);
            this.VehicleListBox.TabIndex = 0;
            this.VehicleListBox.SelectedIndexChanged += new System.EventHandler(this.VehicleListBox_SelectedIndexChanged);
            // 
            // ViewPnl
            // 
            this.ViewPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(233)))));
            this.ViewPnl.Controls.Add(this.YearLbl);
            this.ViewPnl.Controls.Add(this.ColorLbl);
            this.ViewPnl.Controls.Add(this.ModelLbl);
            this.ViewPnl.Controls.Add(this.BrandLbl);
            this.ViewPnl.Controls.Add(this.VINLbl);
            this.ViewPnl.Location = new System.Drawing.Point(1333, 343);
            this.ViewPnl.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ViewPnl.Name = "ViewPnl";
            this.ViewPnl.Size = new System.Drawing.Size(677, 317);
            this.ViewPnl.TabIndex = 2;
            // 
            // YearLbl
            // 
            this.YearLbl.AutoSize = true;
            this.YearLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.YearLbl.Location = new System.Drawing.Point(11, 234);
            this.YearLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.YearLbl.Name = "YearLbl";
            this.YearLbl.Size = new System.Drawing.Size(92, 46);
            this.YearLbl.TabIndex = 4;
            this.YearLbl.Text = "Año";
            // 
            // ColorLbl
            // 
            this.ColorLbl.AutoSize = true;
            this.ColorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ColorLbl.Location = new System.Drawing.Point(11, 186);
            this.ColorLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.ColorLbl.Name = "ColorLbl";
            this.ColorLbl.Size = new System.Drawing.Size(117, 46);
            this.ColorLbl.TabIndex = 3;
            this.ColorLbl.Text = "Color";
            // 
            // ModelLbl
            // 
            this.ModelLbl.AutoSize = true;
            this.ModelLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ModelLbl.Location = new System.Drawing.Point(11, 138);
            this.ModelLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.ModelLbl.Name = "ModelLbl";
            this.ModelLbl.Size = new System.Drawing.Size(152, 46);
            this.ModelLbl.TabIndex = 2;
            this.ModelLbl.Text = "Modelo";
            // 
            // BrandLbl
            // 
            this.BrandLbl.AutoSize = true;
            this.BrandLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrandLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.BrandLbl.Location = new System.Drawing.Point(11, 91);
            this.BrandLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.BrandLbl.Name = "BrandLbl";
            this.BrandLbl.Size = new System.Drawing.Size(131, 46);
            this.BrandLbl.TabIndex = 1;
            this.BrandLbl.Text = "Marca";
            // 
            // VINLbl
            // 
            this.VINLbl.AutoSize = true;
            this.VINLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VINLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.VINLbl.Location = new System.Drawing.Point(11, 43);
            this.VINLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.VINLbl.Name = "VINLbl";
            this.VINLbl.Size = new System.Drawing.Size(86, 46);
            this.VINLbl.TabIndex = 0;
            this.VINLbl.Text = "VIN";
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.TitleLbl.Location = new System.Drawing.Point(528, 36);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(458, 105);
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
            this.AddVehicleBtn.Location = new System.Drawing.Point(1704, 174);
            this.AddVehicleBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.AddVehicleBtn.Name = "AddVehicleBtn";
            this.AddVehicleBtn.Size = new System.Drawing.Size(283, 105);
            this.AddVehicleBtn.TabIndex = 4;
            this.AddVehicleBtn.Text = "Agregar";
            this.AddVehicleBtn.UseVisualStyleBackColor = true;
            this.AddVehicleBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddVehicleBtn_MouseClick);
            // 
            // DeleteVehicleBtn
            // 
            this.DeleteVehicleBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.DeleteVehicleBtn.FlatAppearance.BorderSize = 6;
            this.DeleteVehicleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteVehicleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteVehicleBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.DeleteVehicleBtn.Location = new System.Drawing.Point(1677, 699);
            this.DeleteVehicleBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.DeleteVehicleBtn.Name = "DeleteVehicleBtn";
            this.DeleteVehicleBtn.Size = new System.Drawing.Size(309, 105);
            this.DeleteVehicleBtn.TabIndex = 5;
            this.DeleteVehicleBtn.Text = "Eliminar";
            this.DeleteVehicleBtn.UseVisualStyleBackColor = true;
            this.DeleteVehicleBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DeleteVehicleBtn_MouseClick);
            // 
            // ModifyBtn
            // 
            this.ModifyBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ModifyBtn.FlatAppearance.BorderSize = 6;
            this.ModifyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ModifyBtn.Location = new System.Drawing.Point(1349, 699);
            this.ModifyBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ModifyBtn.Name = "ModifyBtn";
            this.ModifyBtn.Size = new System.Drawing.Size(312, 105);
            this.ModifyBtn.TabIndex = 6;
            this.ModifyBtn.Text = "Modificar";
            this.ModifyBtn.UseVisualStyleBackColor = true;
            this.ModifyBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ModifyBtn_MouseClick);
            // 
            // showArrowBtn
            // 
            this.showArrowBtn.BackgroundImage = global::VehicleTracking.UI.WinApp.Properties.Resources.RightArrow;
            this.showArrowBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showArrowBtn.Enabled = false;
            this.showArrowBtn.FlatAppearance.BorderSize = 0;
            this.showArrowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showArrowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.showArrowBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.showArrowBtn.Location = new System.Drawing.Point(1053, 402);
            this.showArrowBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.showArrowBtn.Name = "showArrowBtn";
            this.showArrowBtn.Size = new System.Drawing.Size(242, 203);
            this.showArrowBtn.TabIndex = 22;
            this.showArrowBtn.Text = "\r\n";
            this.showArrowBtn.UseVisualStyleBackColor = true;
            // 
            // VehicleUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.showArrowBtn);
            this.Controls.Add(this.ModifyBtn);
            this.Controls.Add(this.DeleteVehicleBtn);
            this.Controls.Add(this.AddVehicleBtn);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.ViewPnl);
            this.Controls.Add(this.VehicleListBox);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "VehicleUserControl";
            this.Size = new System.Drawing.Size(2403, 870);
            this.ViewPnl.ResumeLayout(false);
            this.ViewPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox VehicleListBox;
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
        private System.Windows.Forms.Button showArrowBtn;
    }
}
