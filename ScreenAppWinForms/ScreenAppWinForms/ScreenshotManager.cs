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
        public ScreenshotManager()
        {
            InitializeComponent();
        }

       //http://stackoverflow.com/questions/2073519/uploading-to-imgur-com

        //http://stackoverflow.com/questions/2073519/uploading-to-imgur-com

        private void ScreenshotManager_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InfoAboutScreenshot.FolderPath))
            {
                panel1.BackgroundImage = Image.FromFile(InfoAboutScreenshot.FolderPath);
            }
        }
    }
}
