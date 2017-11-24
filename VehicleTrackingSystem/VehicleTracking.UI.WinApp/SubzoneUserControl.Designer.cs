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
            this.showArrowBtn = new System.Windows.Forms.Button();
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
            this.ModifyZoneBtn.Location = new System.Drawing.Point(1184, 718);
            this.ModifyZoneBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ModifyZoneBtn.Name = "ModifyZoneBtn";
            this.ModifyZoneBtn.Size = new System.Drawing.Size(312, 105);
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
            this.DeleteZoneBtn.Location = new System.Drawing.Point(1512, 718);
            this.DeleteZoneBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.DeleteZoneBtn.Name = "DeleteZoneBtn";
            this.DeleteZoneBtn.Size = new System.Drawing.Size(309, 105);
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
            this.AddSubzoneBtn.Location = new System.Drawing.Point(1539, 193);
            this.AddSubzoneBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.AddSubzoneBtn.Name = "AddSubzoneBtn";
            this.AddSubzoneBtn.Size = new System.Drawing.Size(283, 105);
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
            this.TitleLbl.Location = new System.Drawing.Point(334, 53);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(469, 105);
            this.TitleLbl.TabIndex = 17;
            this.TitleLbl.Text = "Subzonas";
            // 
            // ViewPnl
            // 
            this.ViewPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(233)))));
            this.ViewPnl.Controls.Add(this.ZoneLbl);
            this.ViewPnl.Controls.Add(this.CapacityLbl);
            this.ViewPnl.Controls.Add(this.NameLbl);
            this.ViewPnl.Location = new System.Drawing.Point(1277, 362);
            this.ViewPnl.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ViewPnl.Name = "ViewPnl";
            this.ViewPnl.Size = new System.Drawing.Size(443, 317);
            this.ViewPnl.TabIndex = 16;
            // 
            // ZoneLbl
            // 
            this.ZoneLbl.AutoSize = true;
            this.ZoneLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoneLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ZoneLbl.Location = new System.Drawing.Point(8, 231);
            this.ZoneLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.ZoneLbl.Name = "ZoneLbl";
            this.ZoneLbl.Size = new System.Drawing.Size(111, 46);
            this.ZoneLbl.TabIndex = 2;
            this.ZoneLbl.Text = "Zona";
            // 
            // CapacityLbl
            // 
            this.CapacityLbl.AutoSize = true;
            this.CapacityLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CapacityLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.CapacityLbl.Location = new System.Drawing.Point(8, 145);
            this.CapacityLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.CapacityLbl.Name = "CapacityLbl";
            this.CapacityLbl.Size = new System.Drawing.Size(211, 46);
            this.CapacityLbl.TabIndex = 1;
            this.CapacityLbl.Text = "Capacidad";
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.NameLbl.Location = new System.Drawing.Point(8, 55);
            this.NameLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(162, 46);
            this.NameLbl.TabIndex = 0;
            this.NameLbl.Text = "Nombre";
            // 
            // SubzoneListBox
            // 
            this.SubzoneListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(233)))));
            this.SubzoneListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubzoneListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.SubzoneListBox.FormattingEnabled = true;
            this.SubzoneListBox.ItemHeight = 46;
            this.SubzoneListBox.Location = new System.Drawing.Point(230, 193);
            this.SubzoneListBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.SubzoneListBox.Name = "SubzoneListBox";
            this.SubzoneListBox.Size = new System.Drawing.Size(689, 556);
            this.SubzoneListBox.TabIndex = 14;
            this.SubzoneListBox.SelectedIndexChanged += new System.EventHandler(this.SubzoneListBox_SelectedIndexChanged);
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
            this.showArrowBtn.Location = new System.Drawing.Point(927, 380);
            this.showArrowBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.showArrowBtn.Name = "showArrowBtn";
            this.showArrowBtn.Size = new System.Drawing.Size(334, 203);
            this.showArrowBtn.TabIndex = 21;
            this.showArrowBtn.Text = "\r\n";
            this.showArrowBtn.UseVisualStyleBackColor = true;
            // 
            // SubzoneUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.showArrowBtn);
            this.Controls.Add(this.ModifyZoneBtn);
            this.Controls.Add(this.DeleteZoneBtn);
            this.Controls.Add(this.AddSubzoneBtn);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.ViewPnl);
            this.Controls.Add(this.SubzoneListBox);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "SubzoneUserControl";
            this.Size = new System.Drawing.Size(2403, 870);
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
        private System.Windows.Forms.Button showArrowBtn;
    }
}
