namespace VehicleTracking.UI.WinApp
{
    partial class VehicleTrackingUI
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.VehicleBtn = new System.Windows.Forms.Button();
            this.ZoneBtn = new System.Windows.Forms.Button();
            this.SubzoneBtn = new System.Windows.Forms.Button();
            this.FlowBtn = new System.Windows.Forms.Button();
            this.cardPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 117);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(115, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 118);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vehicle Tracking \r\nSystem";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // VehicleBtn
            // 
            this.VehicleBtn.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.VehicleBtn.Enabled = false;
            this.VehicleBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.VehicleBtn.FlatAppearance.BorderSize = 0;
            this.VehicleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VehicleBtn.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VehicleBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.VehicleBtn.Location = new System.Drawing.Point(1, 117);
            this.VehicleBtn.Name = "VehicleBtn";
            this.VehicleBtn.Size = new System.Drawing.Size(142, 43);
            this.VehicleBtn.TabIndex = 1;
            this.VehicleBtn.Text = "Vehículos";
            this.VehicleBtn.UseVisualStyleBackColor = false;
            this.VehicleBtn.Click += new System.EventHandler(this.VehicleBtn_Click);
            this.VehicleBtn.MouseLeave += new System.EventHandler(this.VehicleBtn_MouseLeave);
            this.VehicleBtn.MouseHover += new System.EventHandler(this.VehicleBtn_MouseHover);
            // 
            // ZoneBtn
            // 
            this.ZoneBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ZoneBtn.Enabled = false;
            this.ZoneBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ZoneBtn.FlatAppearance.BorderSize = 0;
            this.ZoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZoneBtn.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoneBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ZoneBtn.Location = new System.Drawing.Point(138, 117);
            this.ZoneBtn.Name = "ZoneBtn";
            this.ZoneBtn.Size = new System.Drawing.Size(142, 43);
            this.ZoneBtn.TabIndex = 2;
            this.ZoneBtn.Text = "Zonas";
            this.ZoneBtn.UseVisualStyleBackColor = false;
            this.ZoneBtn.MouseLeave += new System.EventHandler(this.ZoneBtn_MouseLeave);
            this.ZoneBtn.MouseHover += new System.EventHandler(this.ZoneBtn_MouseHover);
            // 
            // SubzoneBtn
            // 
            this.SubzoneBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.SubzoneBtn.Enabled = false;
            this.SubzoneBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.SubzoneBtn.FlatAppearance.BorderSize = 0;
            this.SubzoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubzoneBtn.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubzoneBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.SubzoneBtn.Location = new System.Drawing.Point(273, 117);
            this.SubzoneBtn.Name = "SubzoneBtn";
            this.SubzoneBtn.Size = new System.Drawing.Size(142, 43);
            this.SubzoneBtn.TabIndex = 3;
            this.SubzoneBtn.Text = "Sub zonas";
            this.SubzoneBtn.UseVisualStyleBackColor = false;
            this.SubzoneBtn.MouseLeave += new System.EventHandler(this.SubzoneBtn_MouseLeave);
            this.SubzoneBtn.MouseHover += new System.EventHandler(this.SubzoneBtn_MouseHover);
            // 
            // FlowBtn
            // 
            this.FlowBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.FlowBtn.Enabled = false;
            this.FlowBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.FlowBtn.FlatAppearance.BorderSize = 0;
            this.FlowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlowBtn.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold);
            this.FlowBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.FlowBtn.Location = new System.Drawing.Point(411, 117);
            this.FlowBtn.Name = "FlowBtn";
            this.FlowBtn.Size = new System.Drawing.Size(160, 43);
            this.FlowBtn.TabIndex = 4;
            this.FlowBtn.Text = "Flujo para venta";
            this.FlowBtn.UseVisualStyleBackColor = false;
            this.FlowBtn.MouseLeave += new System.EventHandler(this.FlowBtn_MouseLeave);
            this.FlowBtn.MouseHover += new System.EventHandler(this.FlowBtn_MouseHover);
            // 
            // cardPanel
            // 
            this.cardPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cardPanel.Location = new System.Drawing.Point(0, 161);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Size = new System.Drawing.Size(573, 365);
            this.cardPanel.TabIndex = 5;
            // 
            // VehicleTrackingUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(571, 526);
            this.Controls.Add(this.VehicleBtn);
            this.Controls.Add(this.SubzoneBtn);
            this.Controls.Add(this.ZoneBtn);
            this.Controls.Add(this.cardPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FlowBtn);
            this.Name = "VehicleTrackingUI";
            this.Text = "VehicleTrackingUI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button VehicleBtn;
        private System.Windows.Forms.Button ZoneBtn;
        private System.Windows.Forms.Button SubzoneBtn;
        private System.Windows.Forms.Button FlowBtn;
        private System.Windows.Forms.Panel cardPanel;
    }
}