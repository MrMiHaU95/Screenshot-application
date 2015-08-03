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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            if(SettingsHelper.CurrentLanguage == "en")
            {
                radioButtonEnglish.Checked = true;
            }
            else
            {
                radioButtonPolish.Checked = true;
            }
        }

        private void radioButtonEnglish_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            if(btn.Checked)
            {
                NotifyIconHelper.CreateNotifyIconEnglish();

                this.Text = "Settings";
                groupBox1.Text = "Language";
                radioButtonEnglish.Text = "English";
                radioButtonPolish.Text = "Polish";

                groupBox2.Text = "Keyboard Shortcuts";
                label1.Text = "Capture screen:";
                label2.Text = "Capture area:";
                label3.Text = "Capture Screen and upload:";
            }
        }

        private void radioButtonPolish_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            if (btn.Checked)
            {
                NotifyIconHelper.CreateNotifyIconPolish();

                this.Text = "Ustawienia";
                groupBox1.Text = "Język";
                radioButtonEnglish.Text = "Angielski";
                radioButtonPolish.Text = "Polski";

                groupBox2.Text = "Skróty klawiszowe";
                label1.Text = "Screen ekranu:";
                label2.Text = "Screen zaznaczenia:";
                label3.Text = "Screen ekranu i upload:";
            }
        }
    }
}
