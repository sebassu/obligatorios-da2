namespace VehicleTracking.UI.WinApp
{
    partial class CreateModifyZone
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
            this.CapacityTxt = new System.Windows.Forms.TextBox();
            this.CapacityLbl = new System.Windows.Forms.Label();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.NameLbl = new System.Windows.Forms.Label();
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.TitleLbl.Location = new System.Drawing.Point(228, 64);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(109, 39);
            this.TitleLbl.TabIndex = 15;
            this.TitleLbl.Text = "label1";
            // 
            // CapacityTxt
            // 
            this.CapacityTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CapacityTxt.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CapacityTxt.Location = new System.Drawing.Point(225, 164);
            this.CapacityTxt.Name = "CapacityTxt";
            this.CapacityTxt.Size = new System.Drawing.Size(150, 26);
            this.CapacityTxt.TabIndex = 14;
            this.CapacityTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CapacityTxt_KeyPress);
            this.CapacityTxt.Leave += new System.EventHandler(this.CapacityTxt_Leave);
            // 
            // CapacityLbl
            // 
            this.CapacityLbl.AutoSize = true;
            this.CapacityLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CapacityLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.CapacityLbl.Location = new System.Drawing.Point(133, 164);
            this.CapacityLbl.Name = "CapacityLbl";
            this.CapacityLbl.Size = new System.Drawing.Size(86, 24);
            this.CapacityLbl.TabIndex = 13;
            this.CapacityLbl.Text = "Capacity:";
            // 
            // NameTxt
            // 
            this.NameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTxt.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.NameTxt.Location = new System.Drawing.Point(225, 125);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(150, 26);
            this.NameTxt.TabIndex = 12;
            this.NameTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameTxt_KeyPress);
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.NameLbl.Location = new System.Drawing.Point(133, 125);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(84, 24);
            this.NameLbl.TabIndex = 11;
            this.NameLbl.Text = "Nombre:";
            // 
            // OkBtn
            // 
            this.OkBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.OkBtn.FlatAppearance.BorderSize = 6;
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.OkBtn.Location = new System.Drawing.Point(291, 224);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(119, 46);
            this.OkBtn.TabIndex = 17;
            this.OkBtn.Text = "Button 1";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.CancelBtn.FlatAppearance.BorderSize = 6;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.CancelBtn.Location = new System.Drawing.Point(164, 224);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(117, 46);
            this.CancelBtn.TabIndex = 16;
            this.CancelBtn.Text = "Cancelar";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // CreateModifyZone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.CapacityTxt);
            this.Controls.Add(this.CapacityLbl);
            this.Controls.Add(this.NameTxt);
            this.Controls.Add(this.NameLbl);
            this.Name = "CreateModifyZone";
            this.Size = new System.Drawing.Size(573, 378);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.TextBox CapacityTxt;
        private System.Windows.Forms.Label CapacityLbl;
        private System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}
