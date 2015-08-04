namespace ScreenAppWinForms
{
    partial class Settings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonPolish = new System.Windows.Forms.RadioButton();
            this.radioButtonEnglish = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxCaptureScreenUpload = new System.Windows.Forms.TextBox();
            this.textBoxCaptureArea = new System.Windows.Forms.TextBox();
            this.textBoxCaptureScreen = new System.Windows.Forms.TextBox();
            this.buttonCaptureScreenUpload = new System.Windows.Forms.Button();
            this.buttonCaptureArea = new System.Windows.Forms.Button();
            this.buttonCaptureScreen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonPolish);
            this.groupBox1.Controls.Add(this.radioButtonEnglish);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Language";
            // 
            // radioButtonPolish
            // 
            this.radioButtonPolish.AutoSize = true;
            this.radioButtonPolish.Location = new System.Drawing.Point(194, 32);
            this.radioButtonPolish.Name = "radioButtonPolish";
            this.radioButtonPolish.Size = new System.Drawing.Size(53, 17);
            this.radioButtonPolish.TabIndex = 1;
            this.radioButtonPolish.TabStop = true;
            this.radioButtonPolish.Text = "Polish";
            this.radioButtonPolish.UseVisualStyleBackColor = true;
            this.radioButtonPolish.CheckedChanged += new System.EventHandler(this.radioButtonPolish_CheckedChanged);
            // 
            // radioButtonEnglish
            // 
            this.radioButtonEnglish.AutoSize = true;
            this.radioButtonEnglish.Location = new System.Drawing.Point(45, 32);
            this.radioButtonEnglish.Name = "radioButtonEnglish";
            this.radioButtonEnglish.Size = new System.Drawing.Size(59, 17);
            this.radioButtonEnglish.TabIndex = 0;
            this.radioButtonEnglish.Text = "English";
            this.radioButtonEnglish.UseVisualStyleBackColor = true;
            this.radioButtonEnglish.CheckedChanged += new System.EventHandler(this.radioButtonEnglish_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxCaptureScreenUpload);
            this.groupBox2.Controls.Add(this.textBoxCaptureArea);
            this.groupBox2.Controls.Add(this.textBoxCaptureScreen);
            this.groupBox2.Controls.Add(this.buttonCaptureScreenUpload);
            this.groupBox2.Controls.Add(this.buttonCaptureArea);
            this.groupBox2.Controls.Add(this.buttonCaptureScreen);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 154);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Keyboard Shortcuts";
            // 
            // textBoxCaptureScreenUpload
            // 
            this.textBoxCaptureScreenUpload.Location = new System.Drawing.Point(170, 111);
            this.textBoxCaptureScreenUpload.Name = "textBoxCaptureScreenUpload";
            this.textBoxCaptureScreenUpload.Size = new System.Drawing.Size(69, 20);
            this.textBoxCaptureScreenUpload.TabIndex = 11;
            // 
            // textBoxCaptureArea
            // 
            this.textBoxCaptureArea.Location = new System.Drawing.Point(170, 72);
            this.textBoxCaptureArea.Name = "textBoxCaptureArea";
            this.textBoxCaptureArea.Size = new System.Drawing.Size(69, 20);
            this.textBoxCaptureArea.TabIndex = 10;
            // 
            // textBoxCaptureScreen
            // 
            this.textBoxCaptureScreen.Location = new System.Drawing.Point(170, 33);
            this.textBoxCaptureScreen.Name = "textBoxCaptureScreen";
            this.textBoxCaptureScreen.Size = new System.Drawing.Size(69, 20);
            this.textBoxCaptureScreen.TabIndex = 9;
            // 
            // buttonCaptureScreenUpload
            // 
            this.buttonCaptureScreenUpload.Location = new System.Drawing.Point(245, 111);
            this.buttonCaptureScreenUpload.Name = "buttonCaptureScreenUpload";
            this.buttonCaptureScreenUpload.Size = new System.Drawing.Size(75, 23);
            this.buttonCaptureScreenUpload.TabIndex = 8;
            this.buttonCaptureScreenUpload.Text = "Change";
            this.buttonCaptureScreenUpload.UseVisualStyleBackColor = true;
            this.buttonCaptureScreenUpload.Click += new System.EventHandler(this.buttonCaptureScreenUpload_Click);
            // 
            // buttonCaptureArea
            // 
            this.buttonCaptureArea.Location = new System.Drawing.Point(245, 72);
            this.buttonCaptureArea.Name = "buttonCaptureArea";
            this.buttonCaptureArea.Size = new System.Drawing.Size(75, 23);
            this.buttonCaptureArea.TabIndex = 7;
            this.buttonCaptureArea.Text = "Change";
            this.buttonCaptureArea.UseVisualStyleBackColor = true;
            this.buttonCaptureArea.Click += new System.EventHandler(this.buttonCaptureArea_Click);
            // 
            // buttonCaptureScreen
            // 
            this.buttonCaptureScreen.Location = new System.Drawing.Point(245, 33);
            this.buttonCaptureScreen.Name = "buttonCaptureScreen";
            this.buttonCaptureScreen.Size = new System.Drawing.Size(75, 23);
            this.buttonCaptureScreen.TabIndex = 6;
            this.buttonCaptureScreen.Text = "Change";
            this.buttonCaptureScreen.UseVisualStyleBackColor = true;
            this.buttonCaptureScreen.Click += new System.EventHandler(this.buttonCaptureScreen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Capture Screen and upload:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Capture area:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Capture screen:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 257);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Settings";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonPolish;
        private System.Windows.Forms.RadioButton radioButtonEnglish;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCaptureScreenUpload;
        private System.Windows.Forms.Button buttonCaptureArea;
        private System.Windows.Forms.Button buttonCaptureScreen;
        private System.Windows.Forms.TextBox textBoxCaptureScreenUpload;
        private System.Windows.Forms.TextBox textBoxCaptureArea;
        private System.Windows.Forms.TextBox textBoxCaptureScreen;
    }
}