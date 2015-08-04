using registerHotkey;
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

            textBoxCaptureScreen.Text = SettingsHelper.CaptureScreenShortcutText;
            textBoxCaptureArea.Text = SettingsHelper.CaptureAreaShortcutText;
            textBoxCaptureScreenUpload.Text = SettingsHelper.CapureScreenUploadShortcutText;
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
                buttonCaptureScreen.Text = "Change";
                buttonCaptureArea.Text = "Change";
                buttonCaptureScreenUpload.Text = "Change";
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
                buttonCaptureScreen.Text = "Zmień";
                buttonCaptureArea.Text = "Zmień";
                buttonCaptureScreenUpload.Text = "Zmień";
            }
        }

        private void buttonCaptureScreen_Click(object sender, EventArgs e)
        {
            try
            {
                KeysConverter converter = new KeysConverter();
                string txtFromTxtBox = textBoxCaptureScreen.Text;
                txtFromTxtBox = txtFromTxtBox.ToUpper();
                object key = converter.ConvertFromString(txtFromTxtBox);
                Hotkey.UnregisterOldHotkey(SettingsHelper.WindowHandle, 1);
                Hotkey.RegisterNewHotkey(SettingsHelper.WindowHandle, 1, (int)registerHotkey.Hotkey.WindowKeys.None, Convert.ToUInt32(key));
            }
            catch(ArgumentException ex)
            {
                if (SettingsHelper.CurrentLanguage == "en")
                {
                    MessageBox.Show("key not valid", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("wybrałeś zły klawisz tylko jeden może być skrótem", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCaptureArea_Click(object sender, EventArgs e)
        {
            try
            {
                KeysConverter converter = new KeysConverter();
                string txtFromTxtBox = textBoxCaptureArea.Text;
                txtFromTxtBox = txtFromTxtBox.ToUpper();
                object key = converter.ConvertFromString(txtFromTxtBox);
                Hotkey.UnregisterOldHotkey(SettingsHelper.WindowHandle, 2);
                Hotkey.RegisterNewHotkey(SettingsHelper.WindowHandle, 2, (int)registerHotkey.Hotkey.WindowKeys.None, Convert.ToUInt32(key));
            }
            catch (ArgumentException ex)
            {
                if (SettingsHelper.CurrentLanguage == "en")
                {
                    MessageBox.Show("key not valid", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("wybrałeś zły klawisz tylko jeden może być skrótem", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCaptureScreenUpload_Click(object sender, EventArgs e)
        {
            try
            {
                KeysConverter converter = new KeysConverter();
                Hotkey.UnregisterOldHotkey(SettingsHelper.WindowHandle, 3);
                string txtFromTxtBox = textBoxCaptureScreenUpload.Text;
                txtFromTxtBox = txtFromTxtBox.ToUpper();
                object key = converter.ConvertFromString(txtFromTxtBox);
                Hotkey.RegisterNewHotkey(SettingsHelper.WindowHandle, 3, (int)registerHotkey.Hotkey.WindowKeys.None, Convert.ToUInt32(key));
            }
            catch (ArgumentException ex)
            {
                if (SettingsHelper.CurrentLanguage == "en")
                {
                    MessageBox.Show("key not valid", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("wybrałeś zły klawisz tylko jeden może być skrótem", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        
    }
}
