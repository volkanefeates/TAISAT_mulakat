using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAISAT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int speed = 0;
        double x = Convert.ToDouble(40.820138888889);
        double y = Convert.ToDouble(29.918383333333);
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value--;

            if (progressBar1.Value < 30 && progressBar1.Value > 0)
            {
                progressBar1.ForeColor = Color.Red;
            }
            else if (progressBar1.Value <= 50 && progressBar1.Value >= 30)
            {
                progressBar1.ForeColor = Color.Yellow;
            }
            else if (progressBar1.Value > 50 && progressBar1.Value <= 100)
            {
                progressBar1.ForeColor = Color.Green;
            }
            else { progressBar1.Value = 100; }

            label5.Text = "%" + progressBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 100;
            timer1.Start();
            timer2.Start();
            timer3.Start();
            label4.Text = speed.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            speed++;

            if (speed <= 20 && speed>0)
            {
                label4.Text = speed.ToString();

            }
            else
            {
                speed = 0;
            }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            x = x - 0.00001;
            y = y - 0.000001;

            label1.Text = "X   : " + x.ToString();
            label2.Text = "Y   : " + y.ToString();

            gmap.MapProvider = GMapProviders.GoogleMap;

            gmap.DragButton = MouseButtons.Left;
            gmap.Position = new PointLatLng(x, y);
            gmap.MinZoom = 5;
            gmap.MaxZoom = 100;
            gmap.Zoom = 16;

            PointLatLng point = new PointLatLng(x, y);
            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);

            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            gmap.Overlays.Add(markers);


        }


    }
}
