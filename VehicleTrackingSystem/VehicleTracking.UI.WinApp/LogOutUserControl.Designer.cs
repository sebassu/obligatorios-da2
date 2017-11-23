namespace VehicleTracking.UI.WinApp
{
    partial class LogOutUserControl
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
            this.LogOutBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.FlatAppearance.BorderSize = 0;
            this.LogOutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LogOutBtn.Location = new System.Drawing.Point(75, 52);
            this.LogOutBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(336, 76);
            this.LogOutBtn.TabIndex = 3;
            this.LogOutBtn.Text = "Cerrar sesión";
            this.LogOutBtn.UseVisualStyleBackColor = true;
            this.LogOutBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LogOutBtn_MouseClick);
            // 
            // LogOutUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.LogOutBtn);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "LogOutUserControl";
            this.Size = new System.Drawing.Size(504, 136);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LogOutBtn;
    }
}
