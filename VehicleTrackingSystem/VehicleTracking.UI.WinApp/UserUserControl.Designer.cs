namespace VehicleTracking.UI.WinApp
{
    partial class UserUserControl
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
            this.PhoneLbl = new System.Windows.Forms.Label();
            this.UsernameLbl = new System.Windows.Forms.Label();
            this.RoleLbl = new System.Windows.Forms.Label();
            this.LastNameLbl = new System.Windows.Forms.Label();
            this.FirstNameLbl = new System.Windows.Forms.Label();
            this.UserListBox = new System.Windows.Forms.ListBox();
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
            this.ModifyZoneBtn.Location = new System.Drawing.Point(1237, 713);
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
            this.DeleteZoneBtn.Location = new System.Drawing.Point(1565, 713);
            this.DeleteZoneBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.DeleteZoneBtn.Name = "DeleteZoneBtn";
            this.DeleteZoneBtn.Size = new System.Drawing.Size(309, 105);
            this.DeleteZoneBtn.TabIndex = 19;
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
            this.AddZoneBtn.Location = new System.Drawing.Point(1640, 153);
            this.AddZoneBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.AddZoneBtn.Name = "AddZoneBtn";
            this.AddZoneBtn.Size = new System.Drawing.Size(283, 105);
            this.AddZoneBtn.TabIndex = 18;
            this.AddZoneBtn.Text = "Agregar";
            this.AddZoneBtn.UseVisualStyleBackColor = true;
            this.AddZoneBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddZoneBtn_MouseClick);
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.TitleLbl.Location = new System.Drawing.Point(525, 50);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(421, 105);
            this.TitleLbl.TabIndex = 17;
            this.TitleLbl.Text = "Usuarios";
            // 
            // ViewPnl
            // 
            this.ViewPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(233)))));
            this.ViewPnl.Controls.Add(this.PhoneLbl);
            this.ViewPnl.Controls.Add(this.UsernameLbl);
            this.ViewPnl.Controls.Add(this.RoleLbl);
            this.ViewPnl.Controls.Add(this.LastNameLbl);
            this.ViewPnl.Controls.Add(this.FirstNameLbl);
            this.ViewPnl.Location = new System.Drawing.Point(1333, 293);
            this.ViewPnl.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ViewPnl.Name = "ViewPnl";
            this.ViewPnl.Size = new System.Drawing.Size(443, 384);
            this.ViewPnl.TabIndex = 16;
            // 
            // PhoneLbl
            // 
            this.PhoneLbl.AutoSize = true;
            this.PhoneLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.PhoneLbl.Location = new System.Drawing.Point(3, 310);
            this.PhoneLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.PhoneLbl.Name = "PhoneLbl";
            this.PhoneLbl.Size = new System.Drawing.Size(176, 46);
            this.PhoneLbl.TabIndex = 4;
            this.PhoneLbl.Text = "Telefono";
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.UsernameLbl.Location = new System.Drawing.Point(3, 241);
            this.UsernameLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(304, 46);
            this.UsernameLbl.TabIndex = 3;
            this.UsernameLbl.Text = "Nombre usuario";
            // 
            // RoleLbl
            // 
            this.RoleLbl.AutoSize = true;
            this.RoleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.RoleLbl.Location = new System.Drawing.Point(8, 19);
            this.RoleLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.RoleLbl.Name = "RoleLbl";
            this.RoleLbl.Size = new System.Drawing.Size(81, 46);
            this.RoleLbl.TabIndex = 2;
            this.RoleLbl.Text = "Rol";
            // 
            // LastNameLbl
            // 
            this.LastNameLbl.AutoSize = true;
            this.LastNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LastNameLbl.Location = new System.Drawing.Point(3, 162);
            this.LastNameLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.LastNameLbl.Name = "LastNameLbl";
            this.LastNameLbl.Size = new System.Drawing.Size(163, 46);
            this.LastNameLbl.TabIndex = 1;
            this.LastNameLbl.Text = "Apellido";
            // 
            // FirstNameLbl
            // 
            this.FirstNameLbl.AutoSize = true;
            this.FirstNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.FirstNameLbl.Location = new System.Drawing.Point(8, 91);
            this.FirstNameLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.FirstNameLbl.Name = "FirstNameLbl";
            this.FirstNameLbl.Size = new System.Drawing.Size(162, 46);
            this.FirstNameLbl.TabIndex = 0;
            this.FirstNameLbl.Text = "Nombre";
            // 
            // UserListBox
            // 
            this.UserListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(233)))));
            this.UserListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.UserListBox.FormattingEnabled = true;
            this.UserListBox.ItemHeight = 46;
            this.UserListBox.Location = new System.Drawing.Point(544, 188);
            this.UserListBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.UserListBox.Name = "UserListBox";
            this.UserListBox.Size = new System.Drawing.Size(428, 602);
            this.UserListBox.TabIndex = 15;
            this.UserListBox.SelectedIndexChanged += new System.EventHandler(this.UserListBox_SelectedIndexChanged);
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
            this.showArrowBtn.Location = new System.Drawing.Point(983, 384);
            this.showArrowBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.showArrowBtn.Name = "showArrowBtn";
            this.showArrowBtn.Size = new System.Drawing.Size(334, 203);
            this.showArrowBtn.TabIndex = 22;
            this.showArrowBtn.Text = "\r\n";
            this.showArrowBtn.UseVisualStyleBackColor = true;
            // 
            // UserUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.showArrowBtn);
            this.Controls.Add(this.ModifyZoneBtn);
            this.Controls.Add(this.DeleteZoneBtn);
            this.Controls.Add(this.AddZoneBtn);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.ViewPnl);
            this.Controls.Add(this.UserListBox);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "UserUserControl";
            this.Size = new System.Drawing.Size(2403, 870);
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
        private System.Windows.Forms.Label RoleLbl;
        private System.Windows.Forms.Label LastNameLbl;
        private System.Windows.Forms.Label FirstNameLbl;
        private System.Windows.Forms.ListBox UserListBox;
        private System.Windows.Forms.Label PhoneLbl;
        private System.Windows.Forms.Label UsernameLbl;
        private System.Windows.Forms.Button showArrowBtn;
    }
}
