namespace VehicleTracking.UI.WinApp
{
    partial class SaleFlowUserControl
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
            this.availableSubzonesListBox = new System.Windows.Forms.ListBox();
            this.subzonesToSetListBox = new System.Windows.Forms.ListBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.NewSubzoneTxt = new System.Windows.Forms.TextBox();
            this.NotExistingSubzoneCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // availableSubzonesListBox
            // 
            this.availableSubzonesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableSubzonesListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.availableSubzonesListBox.FormattingEnabled = true;
            this.availableSubzonesListBox.ItemHeight = 20;
            this.availableSubzonesListBox.Location = new System.Drawing.Point(178, 83);
            this.availableSubzonesListBox.Name = "availableSubzonesListBox";
            this.availableSubzonesListBox.Size = new System.Drawing.Size(198, 144);
            this.availableSubzonesListBox.TabIndex = 0;
            this.availableSubzonesListBox.SelectedIndexChanged += new System.EventHandler(this.availableSubzonesListBox_SelectedIndexChanged);
            // 
            // subzonesToSetListBox
            // 
            this.subzonesToSetListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subzonesToSetListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.subzonesToSetListBox.FormattingEnabled = true;
            this.subzonesToSetListBox.ItemHeight = 20;
            this.subzonesToSetListBox.Location = new System.Drawing.Point(507, 83);
            this.subzonesToSetListBox.Name = "subzonesToSetListBox";
            this.subzonesToSetListBox.Size = new System.Drawing.Size(198, 204);
            this.subzonesToSetListBox.TabIndex = 1;
            this.subzonesToSetListBox.SelectedIndexChanged += new System.EventHandler(this.subzonesToSetListBox_SelectedIndexChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.FlatAppearance.BorderSize = 0;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("Wingdings 3", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.AddBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.AddBtn.Location = new System.Drawing.Point(403, 91);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(96, 85);
            this.AddBtn.TabIndex = 2;
            this.AddBtn.Text = "]";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddBtn_MouseClick);
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.TitleLbl.Location = new System.Drawing.Point(134, 13);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(647, 39);
            this.TitleLbl.TabIndex = 4;
            this.TitleLbl.Text = "Definir el flujo para la venta de vehiculos:";
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.FlatAppearance.BorderSize = 0;
            this.RemoveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveBtn.Font = new System.Drawing.Font("Wingdings 3", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.RemoveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.RemoveBtn.Location = new System.Drawing.Point(403, 182);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(96, 85);
            this.RemoveBtn.TabIndex = 5;
            this.RemoveBtn.Text = "\\";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RemoveBtn_MouseClick);
            // 
            // CancelBtn
            // 
            this.CancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.CancelBtn.FlatAppearance.BorderSize = 6;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.CancelBtn.Location = new System.Drawing.Point(308, 306);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(117, 46);
            this.CancelBtn.TabIndex = 38;
            this.CancelBtn.Text = "Cancelar";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CancelBtn_MouseClick);
            // 
            // SaveBtn
            // 
            this.SaveBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.SaveBtn.FlatAppearance.BorderSize = 6;
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.SaveBtn.Location = new System.Drawing.Point(443, 306);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(117, 46);
            this.SaveBtn.TabIndex = 39;
            this.SaveBtn.Text = "Guardar";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // NewSubzoneTxt
            // 
            this.NewSubzoneTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSubzoneTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.NewSubzoneTxt.Location = new System.Drawing.Point(178, 268);
            this.NewSubzoneTxt.Name = "NewSubzoneTxt";
            this.NewSubzoneTxt.Size = new System.Drawing.Size(198, 27);
            this.NewSubzoneTxt.TabIndex = 40;
            // 
            // NotExistingSubzoneCheckBox
            // 
            this.NotExistingSubzoneCheckBox.AutoSize = true;
            this.NotExistingSubzoneCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotExistingSubzoneCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.NotExistingSubzoneCheckBox.Location = new System.Drawing.Point(178, 243);
            this.NotExistingSubzoneCheckBox.Name = "NotExistingSubzoneCheckBox";
            this.NotExistingSubzoneCheckBox.Size = new System.Drawing.Size(182, 24);
            this.NotExistingSubzoneCheckBox.TabIndex = 41;
            this.NotExistingSubzoneCheckBox.Text = "Subzona no existente";
            this.NotExistingSubzoneCheckBox.UseVisualStyleBackColor = true;
            this.NotExistingSubzoneCheckBox.CheckStateChanged += new System.EventHandler(this.NotExistingSubzoneCheckBox_CheckStateChanged);
            // 
            // SaleFlowUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.NotExistingSubzoneCheckBox);
            this.Controls.Add(this.NewSubzoneTxt);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.RemoveBtn);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.subzonesToSetListBox);
            this.Controls.Add(this.availableSubzonesListBox);
            this.Name = "SaleFlowUserControl";
            this.Size = new System.Drawing.Size(901, 365);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox availableSubzonesListBox;
        private System.Windows.Forms.ListBox subzonesToSetListBox;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TextBox NewSubzoneTxt;
        private System.Windows.Forms.CheckBox NotExistingSubzoneCheckBox;
    }
}
