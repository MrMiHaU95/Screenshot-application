namespace ScreenAppWinForms
{
    partial class Form1
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
            this.btnFullScreenShoot = new System.Windows.Forms.Button();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonCaptureArea = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnFullScreenShoot
            // 
            this.btnFullScreenShoot.Location = new System.Drawing.Point(12, 12);
            this.btnFullScreenShoot.Name = "btnFullScreenShoot";
            this.btnFullScreenShoot.Size = new System.Drawing.Size(75, 23);
            this.btnFullScreenShoot.TabIndex = 1;
            this.btnFullScreenShoot.Text = "Cały Ekran";
            this.toolTip2.SetToolTip(this.btnFullScreenShoot, "screen całego ekranu");
            this.btnFullScreenShoot.UseVisualStyleBackColor = true;
            this.btnFullScreenShoot.Click += new System.EventHandler(this.btnFullScreenShoot_Click);
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 5000;
            // 
            // buttonCaptureArea
            // 
            this.buttonCaptureArea.Location = new System.Drawing.Point(93, 12);
            this.buttonCaptureArea.Name = "buttonCaptureArea";
            this.buttonCaptureArea.Size = new System.Drawing.Size(123, 23);
            this.buttonCaptureArea.TabIndex = 3;
            this.buttonCaptureArea.Text = "Screen Obszaru";
            this.toolTip1.SetToolTip(this.buttonCaptureArea, "screen zaznaczonego obszaru, najpierw naciśnij i przytrzymaj lewy przycisk myszy " +
        " i przesuń mysz aby utworzyć zaznaczenie następnie naciśnij i przytrzymaj prawy " +
        "przyisk myszy aby przesunąć zaznaczenie");
            this.buttonCaptureArea.UseVisualStyleBackColor = true;
            this.buttonCaptureArea.Click += new System.EventHandler(this.buttonCaptureArea_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 49);
            this.Controls.Add(this.buttonCaptureArea);
            this.Controls.Add(this.btnFullScreenShoot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Screenshot Maker";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFullScreenShoot;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Button buttonCaptureArea;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}

