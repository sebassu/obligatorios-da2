namespace VehicleTracking.UI.WinApp
{
    partial class SubzoneUserControl
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
            this.AddSubzoneBtn = new System.Windows.Forms.Button();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.ViewPnl = new System.Windows.Forms.Panel();
            this.ZoneLbl = new System.Windows.Forms.Label();
            this.CapacityLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.SubzoneListBox = new System.Windows.Forms.ListBox();
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
            this.ModifyZoneBtn.Location = new System.Drawing.Point(444, 301);
            this.ModifyZoneBtn.Name = "ModifyZoneBtn";
            this.ModifyZoneBtn.Size = new System.Drawing.Size(117, 44);
            this.ModifyZoneBtn.TabIndex = 20;
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
            this.DeleteZoneBtn.Location = new System.Drawing.Point(567, 301);
            this.DeleteZoneBtn.Name = "DeleteZoneBtn";
            this.DeleteZoneBtn.Size = new System.Drawing.Size(116, 44);
            this.DeleteZoneBtn.TabIndex = 19;
            this.DeleteZoneBtn.Text = "Eliminar";
            this.DeleteZoneBtn.UseVisualStyleBackColor = true;
            this.DeleteZoneBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DeleteZoneBtn_MouseClick);
            // 
            // AddSubzoneBtn
            // 
            this.AddSubzoneBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.AddSubzoneBtn.FlatAppearance.BorderSize = 6;
            this.AddSubzoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSubzoneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSubzoneBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.AddSubzoneBtn.Location = new System.Drawing.Point(577, 81);
            this.AddSubzoneBtn.Name = "AddSubzoneBtn";
            this.AddSubzoneBtn.Size = new System.Drawing.Size(106, 44);
            this.AddSubzoneBtn.TabIndex = 18;
            this.AddSubzoneBtn.Text = "Agregar";
            this.AddSubzoneBtn.UseVisualStyleBackColor = true;
            this.AddSubzoneBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddSubzoneBtn_MouseClick);
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.TitleLbl.Location = new System.Drawing.Point(177, 23);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(194, 42);
            this.TitleLbl.TabIndex = 17;
            this.TitleLbl.Text = "Subzonas";
            // 
            // ViewPnl
            // 
            this.ViewPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(233)))));
            this.ViewPnl.Controls.Add(this.ZoneLbl);
            this.ViewPnl.Controls.Add(this.CapacityLbl);
            this.ViewPnl.Controls.Add(this.NameLbl);
            this.ViewPnl.Location = new System.Drawing.Point(479, 152);
            this.ViewPnl.Name = "ViewPnl";
            this.ViewPnl.Size = new System.Drawing.Size(166, 133);
            this.ViewPnl.TabIndex = 16;
            // 
            // ZoneLbl
            // 
            this.ZoneLbl.AutoSize = true;
            this.ZoneLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoneLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ZoneLbl.Location = new System.Drawing.Point(3, 97);
            this.ZoneLbl.Name = "ZoneLbl";
            this.ZoneLbl.Size = new System.Drawing.Size(46, 20);
            this.ZoneLbl.TabIndex = 2;
            this.ZoneLbl.Text = "Zona";
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
            // SubzoneListBox
            // 
            this.SubzoneListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(233)))));
            this.SubzoneListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubzoneListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.SubzoneListBox.FormattingEnabled = true;
            this.SubzoneListBox.ItemHeight = 20;
            this.SubzoneListBox.Location = new System.Drawing.Point(184, 81);
            this.SubzoneListBox.Name = "SubzoneListBox";
            this.SubzoneListBox.Size = new System.Drawing.Size(163, 244);
            this.SubzoneListBox.TabIndex = 14;
            this.SubzoneListBox.SelectedIndexChanged += new System.EventHandler(this.SubzoneListBox_SelectedIndexChanged);
            // 
            // ArrowLbl
            // 
            this.ArrowLbl.AutoSize = true;
            this.ArrowLbl.Font = new System.Drawing.Font("Wingdings 3", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.ArrowLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ArrowLbl.Location = new System.Drawing.Point(369, 175);
            this.ArrowLbl.Name = "ArrowLbl";
            this.ArrowLbl.Size = new System.Drawing.Size(104, 83);
            this.ArrowLbl.TabIndex = 21;
            this.ArrowLbl.Text = "]";
            // 
            // SubzoneUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.ArrowLbl);
            this.Controls.Add(this.ModifyZoneBtn);
            this.Controls.Add(this.DeleteZoneBtn);
            this.Controls.Add(this.AddSubzoneBtn);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.ViewPnl);
            this.Controls.Add(this.SubzoneListBox);
            this.Name = "SubzoneUserControl";
            this.Size = new System.Drawing.Size(901, 365);
            this.ViewPnl.ResumeLayout(false);
            this.ViewPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ModifyZoneBtn;
        private System.Windows.Forms.Button DeleteZoneBtn;
        private System.Windows.Forms.Button AddSubzoneBtn;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Panel ViewPnl;
        private System.Windows.Forms.Label ZoneLbl;
        private System.Windows.Forms.Label CapacityLbl;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.ListBox SubzoneListBox;
        private System.Windows.Forms.Label ArrowLbl;
    }
}
