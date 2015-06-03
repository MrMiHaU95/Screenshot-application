using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    public partial class ScreenshotManager : Form
    {
        private bool canDraw;
        private Point startlocation;
        private Point currentLocation;
        private Graphics g;
        private Pen pen;
         

        public ScreenshotManager()
        {
            InitializeComponent();
        }

       //http://stackoverflow.com/questions/2073519/uploading-to-imgur-com

        //http://www.codeproject.com/Tips/811495/Simple-Paint-Application-in-Csharp

        //http://www.codeproject.com/Articles/22776/WPF-DrawTools

        private void ScreenshotManager_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InfoAboutScreenshot.FolderPath))
            {
                panel1.BackgroundImage = Image.FromFile(InfoAboutScreenshot.FolderPath);
            }
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

            btnColorPicker.BackColor = colorDialog1.Color;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            canDraw = true;
            startlocation = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(canDraw)
            {
                currentLocation = new Point(e.X, e.Y);
                this.Invalidate();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            canDraw = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            pen = new Pen(btnColorPicker.BackColor, float.Parse(txtBoxToolSize.Text));
            g.DrawLine(pen, startlocation, currentLocation);
        }


    }
}
