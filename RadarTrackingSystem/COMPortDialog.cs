using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadarTrackingSystem
{
    public partial class COMPortDialog : Form
    {
        public COMPortDialog()
        {
            InitializeComponent();
        }

        private void COMPortDialog_Load(object sender, EventArgs e)
        {
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = Properties.Settings.Default.PitanjeLink;
            pitanje.Links.Add(link);

            RefreshButton.Text = "";

            comboBox1.Items.Clear();
            string[] portNames = SerialPort.GetPortNames();
            foreach (var port in portNames)
            {
                comboBox1.Items.Add(port);
            }
        }

        private void RefreshButton_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = Properties.Resources.RefreshIcon;

            Bitmap result = new Bitmap(RefreshButton.Width, RefreshButton.Height);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(bmp, 0, 0, RefreshButton.Width, RefreshButton.Height);

            result.MakeTransparent(Color.White);
            int x = (RefreshButton.Width - result.Width) / 2;
            int y = (RefreshButton.Height - result.Height) / 2;
            e.Graphics.DrawImage(result, x, y);
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string[] portNames = SerialPort.GetPortNames();
            foreach (var port in portNames)
            {
                comboBox1.Items.Add(port);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.COM_Port_Name = "None";
            Properties.Settings.Default.DialogResult = false;
            this.Close();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.COM_Port_Name = comboBox1.Text;
            Properties.Settings.Default.DialogResult = true;
            this.Close();
        }

        private void pitanje_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData as string);
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
                SelectButton.Enabled = true;
            else
                SelectButton.Enabled = false;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
                SelectButton.Enabled = true;
            else
                SelectButton.Enabled = false;
        }
    }
}
