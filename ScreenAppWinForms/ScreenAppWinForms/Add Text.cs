using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    public partial class Add_Text : Form
    {
        private string txtToAdd;

        public string TxtToAdd
        {
            get { return txtToAdd; }
            set { txtToAdd = value; }
        }

        public Add_Text()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                TxtToAdd = textBox1.Text;
            }
            this.Close();
        }
    }
}
