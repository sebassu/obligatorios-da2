namespace VehicleTracking.UI.WinApp
{
    partial class LogsUserControl
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
            this.LogsGridView = new System.Windows.Forms.DataGridView();
            this.DateFromPicker = new System.Windows.Forms.DateTimePicker();
            this.DateUntilPicker = new System.Windows.Forms.DateTimePicker();
            this.DateFromLbl = new System.Windows.Forms.Label();
            this.DateUntilLbl = new System.Windows.Forms.Label();
            this.ApplyBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.TitleLbl.Location = new System.Drawing.Point(43, 29);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(701, 101);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Registro de logs:";
            // 
            // LogsGridView
            // 
            this.LogsGridView.BackgroundColor = System.Drawing.Color.LightGray;
            this.LogsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogsGridView.Location = new System.Drawing.Point(619, 260);
            this.LogsGridView.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.LogsGridView.Name = "LogsGridView";
            this.LogsGridView.RowHeadersWidth = 30;
            this.LogsGridView.Size = new System.Drawing.Size(1173, 563);
            this.LogsGridView.TabIndex = 1;
            // 
            // DateFromPicker
            // 
            this.DateFromPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateFromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateFromPicker.Location = new System.Drawing.Point(232, 155);
            this.DateFromPicker.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.DateFromPicker.Name = "DateFromPicker";
            this.DateFromPicker.Size = new System.Drawing.Size(796, 53);
            this.DateFromPicker.TabIndex = 2;
            // 
            // DateUntilPicker
            // 
            this.DateUntilPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateUntilPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateUntilPicker.Location = new System.Drawing.Point(1229, 155);
            this.DateUntilPicker.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.DateUntilPicker.Name = "DateUntilPicker";
            this.DateUntilPicker.Size = new System.Drawing.Size(785, 53);
            this.DateUntilPicker.TabIndex = 3;
            this.DateUntilPicker.ValueChanged += new System.EventHandler(this.DateUntilPicker_ValueChanged);
            // 
            // DateFromLbl
            // 
            this.DateFromLbl.AutoSize = true;
            this.DateFromLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateFromLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.DateFromLbl.Location = new System.Drawing.Point(56, 165);
            this.DateFromLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.DateFromLbl.Name = "DateFromLbl";
            this.DateFromLbl.Size = new System.Drawing.Size(146, 46);
            this.DateFromLbl.TabIndex = 4;
            this.DateFromLbl.Text = "Desde:";
            // 
            // DateUntilLbl
            // 
            this.DateUntilLbl.AutoSize = true;
            this.DateUntilLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateUntilLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.DateUntilLbl.Location = new System.Drawing.Point(1064, 162);
            this.DateUntilLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.DateUntilLbl.Name = "DateUntilLbl";
            this.DateUntilLbl.Size = new System.Drawing.Size(135, 46);
            this.DateUntilLbl.TabIndex = 5;
            this.DateUntilLbl.Text = "Hasta:";
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ApplyBtn.FlatAppearance.BorderSize = 6;
            this.ApplyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.ApplyBtn.Location = new System.Drawing.Point(2088, 150);
            this.ApplyBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(237, 103);
            this.ApplyBtn.TabIndex = 17;
            this.ApplyBtn.Text = "Aplicar";
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ApplyBtn_MouseClick);
            // 
            // LogsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.ApplyBtn);
            this.Controls.Add(this.DateUntilLbl);
            this.Controls.Add(this.DateFromLbl);
            this.Controls.Add(this.DateUntilPicker);
            this.Controls.Add(this.DateFromPicker);
            this.Controls.Add(this.LogsGridView);
            this.Controls.Add(this.TitleLbl);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "LogsUserControl";
            this.Size = new System.Drawing.Size(2403, 870);
            ((System.ComponentModel.ISupportInitialize)(this.LogsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.DataGridView LogsGridView;
        private System.Windows.Forms.DateTimePicker DateFromPicker;
        private System.Windows.Forms.DateTimePicker DateUntilPicker;
        private System.Windows.Forms.Label DateFromLbl;
        private System.Windows.Forms.Label DateUntilLbl;
        private System.Windows.Forms.Button ApplyBtn;
    }
}
