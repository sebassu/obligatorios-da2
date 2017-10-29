namespace VehicleTracking.UI.WinApp
{
    partial class ZoneUserControl
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
            this.ModifyZoneBtn = new System.Windows.Forms.Button();
            this.DeleteZoneBtn = new System.Windows.Forms.Button();
            this.AddZoneBtn = new System.Windows.Forms.Button();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.ViewPnl = new System.Windows.Forms.Panel();
            this.SubzonesLbl = new System.Windows.Forms.Label();
            this.CapacityLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.ZoneListBox = new System.Windows.Forms.ListBox();
            this.ArrowLbl = new System.Windows.Forms.Label();
            this.ViewPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModifyZoneBtn
            // 
            this.ModifyZoneBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ModifyZoneBtn.FlatAppearance.BorderSize = 6;
            this.ModifyZoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModifyZoneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyZoneBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ModifyZoneBtn.Location = new System.Drawing.Point(453, 301);
            this.ModifyZoneBtn.Name = "ModifyZoneBtn";
            this.ModifyZoneBtn.Size = new System.Drawing.Size(117, 44);
            this.ModifyZoneBtn.TabIndex = 13;
            this.ModifyZoneBtn.Text = "Modificar";
            this.ModifyZoneBtn.UseVisualStyleBackColor = true;
            this.ModifyZoneBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ModifyZoneBtn_MouseClick);
            // 
            // DeleteZoneBtn
            // 
            this.DeleteZoneBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.DeleteZoneBtn.FlatAppearance.BorderSize = 6;
            this.DeleteZoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteZoneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteZoneBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.DeleteZoneBtn.Location = new System.Drawing.Point(576, 301);
            this.DeleteZoneBtn.Name = "DeleteZoneBtn";
            this.DeleteZoneBtn.Size = new System.Drawing.Size(116, 44);
            this.DeleteZoneBtn.TabIndex = 12;
            this.DeleteZoneBtn.Text = "Eliminar";
            this.DeleteZoneBtn.UseVisualStyleBackColor = true;
            this.DeleteZoneBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DeleteZoneBtn_MouseClick);
            // 
            // AddZoneBtn
            // 
            this.AddZoneBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.AddZoneBtn.FlatAppearance.BorderSize = 6;
            this.AddZoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddZoneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddZoneBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.AddZoneBtn.Location = new System.Drawing.Point(586, 81);
            this.AddZoneBtn.Name = "AddZoneBtn";
            this.AddZoneBtn.Size = new System.Drawing.Size(106, 44);
            this.AddZoneBtn.TabIndex = 11;
            this.AddZoneBtn.Text = "Agregar";
            this.AddZoneBtn.UseVisualStyleBackColor = true;
            this.AddZoneBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddZoneBtn_MouseClick);
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.TitleLbl.Location = new System.Drawing.Point(186, 23);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(128, 42);
            this.TitleLbl.TabIndex = 10;
            this.TitleLbl.Text = "Zonas";
            // 
            // ViewPnl
            // 
            this.ViewPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(233)))));
            this.ViewPnl.Controls.Add(this.SubzonesLbl);
            this.ViewPnl.Controls.Add(this.CapacityLbl);
            this.ViewPnl.Controls.Add(this.NameLbl);
            this.ViewPnl.Location = new System.Drawing.Point(488, 152);
            this.ViewPnl.Name = "ViewPnl";
            this.ViewPnl.Size = new System.Drawing.Size(166, 133);
            this.ViewPnl.TabIndex = 9;
            // 
            // SubzonesLbl
            // 
            this.SubzonesLbl.AutoSize = true;
            this.SubzonesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubzonesLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.SubzonesLbl.Location = new System.Drawing.Point(3, 97);
            this.SubzonesLbl.Name = "SubzonesLbl";
            this.SubzonesLbl.Size = new System.Drawing.Size(81, 20);
            this.SubzonesLbl.TabIndex = 2;
            this.SubzonesLbl.Text = "Subzonas";
            // 
            // CapacityLbl
            // 
            this.CapacityLbl.AutoSize = true;
            this.CapacityLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CapacityLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.CapacityLbl.Location = new System.Drawing.Point(3, 61);
            this.CapacityLbl.Name = "CapacityLbl";
            this.CapacityLbl.Size = new System.Drawing.Size(85, 20);
            this.CapacityLbl.TabIndex = 1;
            this.CapacityLbl.Text = "Capacidad";
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.NameLbl.Location = new System.Drawing.Point(3, 23);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(65, 20);
            this.NameLbl.TabIndex = 0;
            this.NameLbl.Text = "Nombre";
            // 
            // ZoneListBox
            // 
            this.ZoneListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(233)))));
            this.ZoneListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoneListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ZoneListBox.FormattingEnabled = true;
            this.ZoneListBox.ItemHeight = 20;
            this.ZoneListBox.Location = new System.Drawing.Point(193, 81);
            this.ZoneListBox.Name = "ZoneListBox";
            this.ZoneListBox.Size = new System.Drawing.Size(163, 264);
            this.ZoneListBox.TabIndex = 7;
            this.ZoneListBox.SelectedIndexChanged += new System.EventHandler(this.ZoneListBox_SelectedIndexChanged);
            // 
            // ArrowLbl
            // 
            this.ArrowLbl.AutoSize = true;
            this.ArrowLbl.Font = new System.Drawing.Font("Wingdings 3", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.ArrowLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ArrowLbl.Location = new System.Drawing.Point(379, 175);
            this.ArrowLbl.Name = "ArrowLbl";
            this.ArrowLbl.Size = new System.Drawing.Size(104, 83);
            this.ArrowLbl.TabIndex = 14;
            this.ArrowLbl.Text = "]";
            // 
            // ZoneUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.ArrowLbl);
            this.Controls.Add(this.ModifyZoneBtn);
            this.Controls.Add(this.DeleteZoneBtn);
            this.Controls.Add(this.AddZoneBtn);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.ViewPnl);
            this.Controls.Add(this.ZoneListBox);
            this.Name = "ZoneUserControl";
            this.Size = new System.Drawing.Size(901, 365);
            this.ViewPnl.ResumeLayout(false);
            this.ViewPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ModifyZoneBtn;
        private System.Windows.Forms.Button DeleteZoneBtn;
        private System.Windows.Forms.Button AddZoneBtn;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Panel ViewPnl;
        private System.Windows.Forms.Label CapacityLbl;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.ListBox ZoneListBox;
        private System.Windows.Forms.Label SubzonesLbl;
        private System.Windows.Forms.Label ArrowLbl;
    }
}
