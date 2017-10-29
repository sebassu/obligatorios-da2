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
            this.ArrowLbl = new System.Windows.Forms.Label();
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
            this.ViewPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArrowLbl
            // 
            this.ArrowLbl.AutoSize = true;
            this.ArrowLbl.Font = new System.Drawing.Font("Wingdings 3", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.ArrowLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ArrowLbl.Location = new System.Drawing.Point(390, 163);
            this.ArrowLbl.Name = "ArrowLbl";
            this.ArrowLbl.Size = new System.Drawing.Size(104, 83);
            this.ArrowLbl.TabIndex = 21;
            this.ArrowLbl.Text = "]";
            // 
            // ModifyZoneBtn
            // 
            this.ModifyZoneBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ModifyZoneBtn.FlatAppearance.BorderSize = 6;
            this.ModifyZoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModifyZoneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyZoneBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ModifyZoneBtn.Location = new System.Drawing.Point(464, 299);
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
            this.DeleteZoneBtn.Location = new System.Drawing.Point(587, 299);
            this.DeleteZoneBtn.Name = "DeleteZoneBtn";
            this.DeleteZoneBtn.Size = new System.Drawing.Size(116, 44);
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
            this.AddZoneBtn.Location = new System.Drawing.Point(615, 64);
            this.AddZoneBtn.Name = "AddZoneBtn";
            this.AddZoneBtn.Size = new System.Drawing.Size(106, 44);
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
            this.TitleLbl.Location = new System.Drawing.Point(197, 21);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(174, 42);
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
            this.ViewPnl.Location = new System.Drawing.Point(500, 123);
            this.ViewPnl.Name = "ViewPnl";
            this.ViewPnl.Size = new System.Drawing.Size(166, 161);
            this.ViewPnl.TabIndex = 16;
            // 
            // PhoneLbl
            // 
            this.PhoneLbl.AutoSize = true;
            this.PhoneLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.PhoneLbl.Location = new System.Drawing.Point(1, 130);
            this.PhoneLbl.Name = "PhoneLbl";
            this.PhoneLbl.Size = new System.Drawing.Size(71, 20);
            this.PhoneLbl.TabIndex = 4;
            this.PhoneLbl.Text = "Telefono";
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.UsernameLbl.Location = new System.Drawing.Point(1, 101);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(121, 20);
            this.UsernameLbl.TabIndex = 3;
            this.UsernameLbl.Text = "Nombre usuario";
            // 
            // RoleLbl
            // 
            this.RoleLbl.AutoSize = true;
            this.RoleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.RoleLbl.Location = new System.Drawing.Point(3, 8);
            this.RoleLbl.Name = "RoleLbl";
            this.RoleLbl.Size = new System.Drawing.Size(33, 20);
            this.RoleLbl.TabIndex = 2;
            this.RoleLbl.Text = "Rol";
            // 
            // LastNameLbl
            // 
            this.LastNameLbl.AutoSize = true;
            this.LastNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LastNameLbl.Location = new System.Drawing.Point(1, 68);
            this.LastNameLbl.Name = "LastNameLbl";
            this.LastNameLbl.Size = new System.Drawing.Size(65, 20);
            this.LastNameLbl.TabIndex = 1;
            this.LastNameLbl.Text = "Apellido";
            // 
            // FirstNameLbl
            // 
            this.FirstNameLbl.AutoSize = true;
            this.FirstNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.FirstNameLbl.Location = new System.Drawing.Point(3, 38);
            this.FirstNameLbl.Name = "FirstNameLbl";
            this.FirstNameLbl.Size = new System.Drawing.Size(65, 20);
            this.FirstNameLbl.TabIndex = 0;
            this.FirstNameLbl.Text = "Nombre";
            // 
            // UserListBox
            // 
            this.UserListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(233)))));
            this.UserListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.UserListBox.FormattingEnabled = true;
            this.UserListBox.ItemHeight = 20;
            this.UserListBox.Location = new System.Drawing.Point(204, 79);
            this.UserListBox.Name = "UserListBox";
            this.UserListBox.Size = new System.Drawing.Size(163, 264);
            this.UserListBox.TabIndex = 15;
            this.UserListBox.SelectedIndexChanged += new System.EventHandler(this.UserListBox_SelectedIndexChanged);
            // 
            // UserUserControl
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
            this.Controls.Add(this.UserListBox);
            this.Name = "UserUserControl";
            this.Size = new System.Drawing.Size(901, 365);
            this.ViewPnl.ResumeLayout(false);
            this.ViewPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ArrowLbl;
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
    }
}
