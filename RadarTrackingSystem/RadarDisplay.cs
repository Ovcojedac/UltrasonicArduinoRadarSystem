using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;

namespace RadarTrackingSystem
{
    public enum DialogState { OK = 1, CANCEL };

    public partial class RadarDisplay : Form
    {
        #region Fields
            private const int MaxRange = 50;
            private int distance=0;
            private int position=0;
            private int previous_pos=0;
            private bool StillListening;
            private int RadarInc = 1;
            //private int[] measurement_buffer;
            private bool Switched = false;
            private Dictionary<int, int> radar_data = new Dictionary<int, int>();
        #endregion

        public RadarDisplay()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
            if (!PortSet() || !PortExists())
            {
                COMPortDialog p = new COMPortDialog();
                p.ShowDialog();
                if (!Properties.Settings.Default.DialogResult)
                {
                    return;
                }
            }
            if (Properties.Settings.Default.COM_Port_Name != "None")
            {
                serialPort1.PortName = Properties.Settings.Default.COM_Port_Name;
                serialPort1.BaudRate = 115200;
                serialPort1.Open();

                byte[] d = { 48 };
                serialPort1.Write(d, 0, 1);

                serialPort1.DataReceived += serialPort1_DataReceived;
                this.StillListening = true;
                DrawRadarDisplay(pictureBox1.CreateGraphics(), pictureBox1);
            }
            else
                MessageBox.Show("Nije izabran COM port.\nIzaberite COM port i pokusajte ponovo.", "Greska!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private bool PortExists()
        {
            bool result = false;

            string[] portNames = SerialPort.GetPortNames();
            foreach (var port in portNames)
            {
                if (port == Properties.Settings.Default.COM_Port_Name)
                    result = true;
            }

            return result;
        }

        private bool PortSet()
        {
            bool result = false;

            if (Properties.Settings.Default.COM_Port_Name != "")
                result = true;

            return result;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.StillListening = false;
            if (serialPort1.IsOpen)
            {
                byte[] d = { 49 };
                serialPort1.Write(d, 0, 1);
                serialPort1.Close();
            }

        }

        private delegate void LineReceivedEvent(string line);
        private void LineReceived(string line)
        {
            string[] lines = line.Split(' ');
            line = lines[0];
            int dist_samp = int.Parse(line);
            line = lines[1];
            previous_pos = position;
            position = int.Parse(line)-90;
            //measurement_buffer[dispData] = dist_samp;
            distance = dist_samp;
            
            //            button1.Text = distance.ToString();

            pictureBox1.Invalidate();
            radar_data[position] = dist_samp;
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (this.StillListening)
            {
                try
                {
                    string line = serialPort1.ReadLine();
                    LineReceivedEvent l = new LineReceivedEvent(LineReceived);
                    this.BeginInvoke(l, line);
                }
                catch (Exception exception)
                {
                    
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Point center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            int blip_radius = (int)(pictureBox1.Width / (2 * MaxRange) * distance);
            float constant = pictureBox1.Width / (2 * MaxRange);
            Graphics g = e.Graphics;
            g.Clear(RadarDisplay.DefaultBackColor);

            DrawRadarDisplay(g, pictureBox1);

            Point[] temp_form;

            Brush frSolid = new SolidBrush(Color.FromArgb(30,Color.DarkBlue));
            Brush obstacleSolid = new SolidBrush(Color.FromArgb(95, Color.Red));
            Brush brSolid = new SolidBrush(Color.Green);
            for (int i = -90; i < 90; i += RadarInc)
            {
                int tmp_radius = (int)(constant * radar_data[i]);
                //g.FillPie(frSolid, center.X - pictureBox1.Width, center.Y - pictureBox1.Width, 2 * pictureBox1.Width, 2 * pictureBox1.Width, 0, -180);   
                g.FillPie(obstacleSolid, center.X - pictureBox1.Width, center.Y - pictureBox1.Width, 2 * pictureBox1.Width, 2 * pictureBox1.Width, -i - RadarInc + 90, RadarInc);
                //g.FillPie(obstacleSolid, 0, 0, pictureBox1.Width, pictureBox1.Height, -i - 10 + 90, 10);
                g.FillPie(brSolid, center.X - tmp_radius, center.Y - tmp_radius, 2 * tmp_radius, 2 * tmp_radius, -i - RadarInc + 90, RadarInc);   
            }

            g.FillPie(frSolid, center.X - pictureBox1.Width, center.Y - pictureBox1.Width, 2 * pictureBox1.Width, 2 * pictureBox1.Width, 0, -180);

            g = DrawRadarLines(g, pictureBox1);

            // Drawing Target
            int small_rad = 5;
            g.FillEllipse(new SolidBrush(Color.Red), (int)(center.X - small_rad + blip_radius * Math.Cos((position - 90) * Math.PI / 180)), (int)(center.Y - small_rad - blip_radius * Math.Sin((position - 90) * Math.PI / 180)), 10, 10);
            
        }

        private Point[] CoordinatesOfAEllipse(Point center, float width, float height)
        {
            Point[] result = new Point[2];
            
            result[0].X = center.X - (int) width;
            result[0].Y = center.Y - (int) height;
            result[1].X = 2*(int) width;
            result[1].Y = 2*(int) height;

            return result;
        }

        private Graphics DrawRadarDisplay(Graphics g, PictureBox p)
        {
            Point center = new Point(p.Width / 2, p.Height / 2);
            g.Clear(Color.White);

            float wsize = p.Width;
            float hsize = p.Height;

            //Crtanje radarskog ekrana
            Point[] temp_form = CoordinatesOfAEllipse(center, wsize, hsize);
            g.FillEllipse(new SolidBrush(Color.Green), temp_form[0].X, temp_form[0].Y, temp_form[1].X, temp_form[1].Y);

            return g;
        }

        private Graphics DrawRadarLines(Graphics g, PictureBox p)
        {
            Point center = new Point(p.Width / 2, p.Height / 2);


            float wsize = p.Width/2;
            float hsize = p.Height/2;

            Point[] temp_form;

            //Crtanje vertikale i horizontale
            g.DrawLine(new Pen(Color.WhiteSmoke), center.X - wsize, center.Y, center.X + wsize, center.Y);
            g.DrawLine(new Pen(Color.WhiteSmoke), center.X, center.Y - hsize, center.X, center.Y + hsize);

            // Crtanje krugova koji oznacavaju rastojanje
            int line_num = 5;
            float winc = (int)((pictureBox1.Width / (2 * MaxRange)) * 10);
            float hinc = (int)((pictureBox1.Width / (2 * MaxRange)) * 10);
            //(int)((pictureBox1.Width / (2 * MaxRange)) * 10);
            for (int i = 1; i <= line_num; i++)
            {
                temp_form = CoordinatesOfAEllipse(center, i * winc, i * hinc);
                g.DrawEllipse(new Pen(Color.WhiteSmoke), temp_form[0].X, temp_form[0].Y, temp_form[1].X, temp_form[1].Y);
            }

            return g;
        }

        private int FiltarSenzora(int[] measurement_seq)
        {
            float result = 0;
            for (int i = 0; i < measurement_seq.Length; i++)
            {
                result += measurement_seq[i] / measurement_seq.Length;
            }
            return (int) result;
        }

        private bool IsInArray(int num, List<int> array)
        {
            bool result = false;

            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] == num)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = -90; i < 90; i += RadarInc)
            {
                radar_data[i] = 1;
            }
        }

        private void SwitchButton_Click(object sender, EventArgs e)
        {
            if (Switched)
            {
                SwitchButton.Image = Properties.Resources.SwitchOn;
                this.StillListening = false;
                if (serialPort1.IsOpen)
                {
                    byte[] d = { 49 };
                    serialPort1.Write(d, 0, 1);
                    serialPort1.Close();
                }
                distance = 0;
                position = 0;
                for (int i = -90; i < 90; i += RadarInc)
                {
                    radar_data[i] = 1;
                }
                pictureBox1.Invalidate();
            }
            else
            {
                if (serialPort1.IsOpen)
                    serialPort1.Close();
                if (!PortSet() || !PortExists())
                {
                    COMPortDialog p = new COMPortDialog();
                    p.ShowDialog();
                    if (!Properties.Settings.Default.DialogResult)
                    {
                        return;
                    }
                }
                if (Properties.Settings.Default.COM_Port_Name != "None")
                {
                    serialPort1.PortName = Properties.Settings.Default.COM_Port_Name;
                    serialPort1.BaudRate = 115200;
                    serialPort1.Open();

                    byte[] d = { 48 };
                    serialPort1.Write(d, 0, 1);

                    serialPort1.DataReceived += serialPort1_DataReceived;
                    this.StillListening = true;
                    SwitchButton.Image = Properties.Resources.SwitchOff;
                }
                else
                    MessageBox.Show("Nije izabran COM port.\nIzaberite COM port i pokusajte ponovo.", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Switched = !Switched;
        }

        private void logoArduino_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Settings.Default.ArduinoLink);
        }

        private void logoETF_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Settings.Default.ETFRoboticsLink);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            AuthorBox box = new AuthorBox();
            box.ShowDialog();
        }
    }
}
