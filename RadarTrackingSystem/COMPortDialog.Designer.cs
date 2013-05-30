namespace RadarTrackingSystem
{
    partial class COMPortDialog
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
            this.SelectButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pitanje = new System.Windows.Forms.LinkLabel();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ThemePicture = new System.Windows.Forms.PictureBox();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ThemePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectButton
            // 
            this.SelectButton.Enabled = false;
            this.SelectButton.Location = new System.Drawing.Point(167, 132);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(85, 40);
            this.SelectButton.TabIndex = 0;
            this.SelectButton.Text = "Izaberi";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(167, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(145, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Izaberite COM port na kojem se nalazi Arduino";
            // 
            // pitanje
            // 
            this.pitanje.AutoSize = true;
            this.pitanje.Location = new System.Drawing.Point(272, 100);
            this.pitanje.Name = "pitanje";
            this.pitanje.Size = new System.Drawing.Size(100, 13);
            this.pitanje.TabIndex = 3;
            this.pitanje.TabStop = true;
            this.pitanje.Text = "Sta je to COM port?";
            this.pitanje.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.pitanje_LinkClicked);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(333, 57);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(40, 40);
            this.RefreshButton.TabIndex = 4;
            this.RefreshButton.Text = "F5";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            this.RefreshButton.Paint += new System.Windows.Forms.PaintEventHandler(this.RefreshButton_Paint);
            // 
            // ThemePicture
            // 
            this.ThemePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThemePicture.Image = global::RadarTrackingSystem.Properties.Resources.USBConnectionIcon;
            this.ThemePicture.Location = new System.Drawing.Point(12, 43);
            this.ThemePicture.Name = "ThemePicture";
            this.ThemePicture.Size = new System.Drawing.Size(127, 129);
            this.ThemePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ThemePicture.TabIndex = 5;
            this.ThemePicture.TabStop = false;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(287, 132);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(85, 40);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Odustani";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // COMPortDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 190);
            this.ControlBox = false;
            this.Controls.Add(this.ThemePicture);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.pitanje);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "COMPortDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Izaberite COM port";
            this.Load += new System.EventHandler(this.COMPortDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ThemePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel pitanje;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.PictureBox ThemePicture;
        private System.Windows.Forms.Button CancelButton;
    }
}