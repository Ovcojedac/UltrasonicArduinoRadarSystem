namespace RadarTrackingSystem
{
    partial class RadarDisplay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadarDisplay));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.logoETF = new System.Windows.Forms.PictureBox();
            this.SwitchButton = new System.Windows.Forms.PictureBox();
            this.logoArduino = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoETF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SwitchButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoArduino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(282, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aktiviraj radar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Powered by:";
            // 
            // logoETF
            // 
            this.logoETF.BackColor = System.Drawing.SystemColors.Control;
            this.logoETF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoETF.Image = global::RadarTrackingSystem.Properties.Resources.ETFRoboticsLogo;
            this.logoETF.Location = new System.Drawing.Point(124, 364);
            this.logoETF.Name = "logoETF";
            this.logoETF.Size = new System.Drawing.Size(154, 57);
            this.logoETF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoETF.TabIndex = 4;
            this.logoETF.TabStop = false;
            this.logoETF.Click += new System.EventHandler(this.logoETF_Click);
            // 
            // SwitchButton
            // 
            this.SwitchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SwitchButton.Image = global::RadarTrackingSystem.Properties.Resources.SwitchOn;
            this.SwitchButton.Location = new System.Drawing.Point(282, 118);
            this.SwitchButton.Name = "SwitchButton";
            this.SwitchButton.Size = new System.Drawing.Size(76, 117);
            this.SwitchButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SwitchButton.TabIndex = 4;
            this.SwitchButton.TabStop = false;
            this.SwitchButton.Click += new System.EventHandler(this.SwitchButton_Click);
            // 
            // logoArduino
            // 
            this.logoArduino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoArduino.Image = global::RadarTrackingSystem.Properties.Resources.ArduinoLogo;
            this.logoArduino.Location = new System.Drawing.Point(12, 351);
            this.logoArduino.Name = "logoArduino";
            this.logoArduino.Size = new System.Drawing.Size(106, 70);
            this.logoArduino.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoArduino.TabIndex = 4;
            this.logoArduino.TabStop = false;
            this.logoArduino.Click += new System.EventHandler(this.logoArduino_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(9, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(127, 13);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.Text = "Radar Display application";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 449);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(369, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(158, 17);
            this.toolStripStatusLabel1.Text = "Copyright Vuk Vujovic, 2013.";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Green;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(164, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Radar raster - 10cm";
            // 
            // RadarDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 471);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoETF);
            this.Controls.Add(this.SwitchButton);
            this.Controls.Add(this.logoArduino);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RadarDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Radar Display";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoETF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SwitchButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoArduino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox logoArduino;
        private System.Windows.Forms.PictureBox logoETF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox SwitchButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label2;
    }
}

