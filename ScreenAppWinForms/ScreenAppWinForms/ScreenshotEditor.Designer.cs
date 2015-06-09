namespace ScreenAppWinForms
{
    partial class ScreenshotEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenshotEditor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToImgurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toImgurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnNewFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSaveFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnCursor = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnDrawLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnDrawRectangle = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnDrawEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnPenTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnAddText = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxFonts = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnColorText = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxToolSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnUploadToImgur = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.drawToolStripMenuItem,
            this.uploadToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1904, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.uploadToImgurToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            // 
            // uploadToImgurToolStripMenuItem
            // 
            this.uploadToImgurToolStripMenuItem.Name = "uploadToImgurToolStripMenuItem";
            this.uploadToImgurToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.uploadToImgurToolStripMenuItem.Text = "Upload to Imgur";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toImgurToolStripMenuItem});
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.uploadToolStripMenuItem.Text = "Upload";
            // 
            // toImgurToolStripMenuItem
            // 
            this.toImgurToolStripMenuItem.Name = "toImgurToolStripMenuItem";
            this.toImgurToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.toImgurToolStripMenuItem.Text = "to Imgur";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNewFile,
            this.toolStripBtnOpenFile,
            this.toolStripBtnSaveFile,
            this.toolStripBtnCursor,
            this.toolStripBtnDrawLine,
            this.toolStripBtnDrawRectangle,
            this.toolStripBtnDrawEllipse,
            this.toolStripBtnPenTool,
            this.toolStripSeparator1,
            this.toolStripBtnUndo,
            this.toolStripBtnRedo,
            this.toolStripSeparator2,
            this.toolStripBtnAddText,
            this.toolStripComboBoxFonts,
            this.toolStripComboBoxFontSize,
            this.toolStripSeparator3,
            this.toolStripBtnColor,
            this.toolStripBtnColorText,
            this.toolStripSeparator4,
            this.toolStripComboBoxToolSize,
            this.toolStripSeparator5,
            this.toolStripBtnPrint,
            this.toolStripSeparator6,
            this.toolStripBtnUploadToImgur,
            this.toolStripSeparator7,
            this.toolStripBtnInfo,
            this.toolStripSeparator8});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1904, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnNewFile
            // 
            this.toolStripBtnNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnNewFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnNewFile.Image")));
            this.toolStripBtnNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNewFile.Name = "toolStripBtnNewFile";
            this.toolStripBtnNewFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnNewFile.Text = "toolStripButton1";
            this.toolStripBtnNewFile.Click += new System.EventHandler(this.toolStripBtnNewFile_Click);
            // 
            // toolStripBtnOpenFile
            // 
            this.toolStripBtnOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnOpenFile.Image")));
            this.toolStripBtnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnOpenFile.Name = "toolStripBtnOpenFile";
            this.toolStripBtnOpenFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnOpenFile.Text = "toolStripButton2";
            this.toolStripBtnOpenFile.Click += new System.EventHandler(this.toolStripBtnOpenFile_Click);
            // 
            // toolStripBtnSaveFile
            // 
            this.toolStripBtnSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSaveFile.Image")));
            this.toolStripBtnSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSaveFile.Name = "toolStripBtnSaveFile";
            this.toolStripBtnSaveFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnSaveFile.Text = "toolStripButton1";
            this.toolStripBtnSaveFile.Click += new System.EventHandler(this.toolStripBtnSaveFile_Click);
            // 
            // toolStripBtnCursor
            // 
            this.toolStripBtnCursor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnCursor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnCursor.Image")));
            this.toolStripBtnCursor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnCursor.Name = "toolStripBtnCursor";
            this.toolStripBtnCursor.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnCursor.Text = "toolStripButton1";
            this.toolStripBtnCursor.Click += new System.EventHandler(this.toolStripBtnCursor_Click);
            // 
            // toolStripBtnDrawLine
            // 
            this.toolStripBtnDrawLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnDrawLine.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnDrawLine.Image")));
            this.toolStripBtnDrawLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDrawLine.Name = "toolStripBtnDrawLine";
            this.toolStripBtnDrawLine.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnDrawLine.Text = "toolStripButton1";
            this.toolStripBtnDrawLine.CheckStateChanged += new System.EventHandler(this.toolStripBtnDrawLine_CheckStateChanged);
            this.toolStripBtnDrawLine.Click += new System.EventHandler(this.toolStripBtnDrawLine_Click);
            // 
            // toolStripBtnDrawRectangle
            // 
            this.toolStripBtnDrawRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnDrawRectangle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnDrawRectangle.Image")));
            this.toolStripBtnDrawRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDrawRectangle.Name = "toolStripBtnDrawRectangle";
            this.toolStripBtnDrawRectangle.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnDrawRectangle.Text = "toolStripButton1";
            this.toolStripBtnDrawRectangle.CheckStateChanged += new System.EventHandler(this.toolStripBtnDrawRectangle_CheckStateChanged);
            this.toolStripBtnDrawRectangle.Click += new System.EventHandler(this.toolStripBtnDrawRectangle_Click);
            // 
            // toolStripBtnDrawEllipse
            // 
            this.toolStripBtnDrawEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnDrawEllipse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnDrawEllipse.Image")));
            this.toolStripBtnDrawEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDrawEllipse.Name = "toolStripBtnDrawEllipse";
            this.toolStripBtnDrawEllipse.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnDrawEllipse.Text = "toolStripButton1";
            this.toolStripBtnDrawEllipse.CheckStateChanged += new System.EventHandler(this.toolStripBtnDrawEllipse_CheckStateChanged);
            this.toolStripBtnDrawEllipse.Click += new System.EventHandler(this.toolStripBtnDrawEllipse_Click);
            // 
            // toolStripBtnPenTool
            // 
            this.toolStripBtnPenTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnPenTool.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnPenTool.Image")));
            this.toolStripBtnPenTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPenTool.Name = "toolStripBtnPenTool";
            this.toolStripBtnPenTool.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnPenTool.Text = "toolStripButton1";
            this.toolStripBtnPenTool.CheckStateChanged += new System.EventHandler(this.toolStripBtnPenTool_CheckStateChanged);
            this.toolStripBtnPenTool.Click += new System.EventHandler(this.toolStripBtnPenTool_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnUndo
            // 
            this.toolStripBtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnUndo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnUndo.Image")));
            this.toolStripBtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnUndo.Name = "toolStripBtnUndo";
            this.toolStripBtnUndo.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnUndo.Text = "toolStripButton1";
            this.toolStripBtnUndo.Click += new System.EventHandler(this.toolStripBtnUndo_Click);
            // 
            // toolStripBtnRedo
            // 
            this.toolStripBtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnRedo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnRedo.Image")));
            this.toolStripBtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnRedo.Name = "toolStripBtnRedo";
            this.toolStripBtnRedo.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnRedo.Text = "toolStripButton1";
            this.toolStripBtnRedo.Click += new System.EventHandler(this.toolStripBtnRedo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnAddText
            // 
            this.toolStripBtnAddText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnAddText.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAddText.Image")));
            this.toolStripBtnAddText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAddText.Name = "toolStripBtnAddText";
            this.toolStripBtnAddText.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnAddText.Text = "toolStripButton1";
            this.toolStripBtnAddText.CheckStateChanged += new System.EventHandler(this.toolStripBtnAddText_CheckStateChanged);
            this.toolStripBtnAddText.Click += new System.EventHandler(this.toolStripBtnAddText_Click);
            // 
            // toolStripComboBoxFonts
            // 
            this.toolStripComboBoxFonts.Name = "toolStripComboBoxFonts";
            this.toolStripComboBoxFonts.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripComboBoxFontSize
            // 
            this.toolStripComboBoxFontSize.Items.AddRange(new object[] {
            "Select font size",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25"});
            this.toolStripComboBoxFontSize.Name = "toolStripComboBoxFontSize";
            this.toolStripComboBoxFontSize.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnColor
            // 
            this.toolStripBtnColor.BackColor = System.Drawing.Color.Transparent;
            this.toolStripBtnColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnColor.Name = "toolStripBtnColor";
            this.toolStripBtnColor.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnColor.Text = " Color";
            this.toolStripBtnColor.Click += new System.EventHandler(this.toolStripBtnColor_Click);
            // 
            // toolStripBtnColorText
            // 
            this.toolStripBtnColorText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnColorText.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnColorText.Image")));
            this.toolStripBtnColorText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnColorText.Name = "toolStripBtnColorText";
            this.toolStripBtnColorText.Size = new System.Drawing.Size(40, 22);
            this.toolStripBtnColorText.Text = "Color";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBoxToolSize
            // 
            this.toolStripComboBoxToolSize.Items.AddRange(new object[] {
            "Select size",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25"});
            this.toolStripComboBoxToolSize.Name = "toolStripComboBoxToolSize";
            this.toolStripComboBoxToolSize.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxToolSize.TextChanged += new System.EventHandler(this.toolStripComboBoxToolSize_TextChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnPrint
            // 
            this.toolStripBtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnPrint.Image")));
            this.toolStripBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPrint.Name = "toolStripBtnPrint";
            this.toolStripBtnPrint.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnPrint.Text = "toolStripButton1";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnUploadToImgur
            // 
            this.toolStripBtnUploadToImgur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnUploadToImgur.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnUploadToImgur.Image")));
            this.toolStripBtnUploadToImgur.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnUploadToImgur.Name = "toolStripBtnUploadToImgur";
            this.toolStripBtnUploadToImgur.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnUploadToImgur.Text = "toolStripButton1";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnInfo
            // 
            this.toolStripBtnInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnInfo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnInfo.Image")));
            this.toolStripBtnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnInfo.Name = "toolStripBtnInfo";
            this.toolStripBtnInfo.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnInfo.Text = "toolStripButton1";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // ScreenshotEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1002);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ScreenshotEditor";
            this.Text = "Screenshot Editor";
            this.Load += new System.EventHandler(this.ScreenshotEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToImgurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnNewFile;
        private System.Windows.Forms.ToolStripButton toolStripBtnOpenFile;
        private System.Windows.Forms.ToolStripButton toolStripBtnSaveFile;
        private System.Windows.Forms.ToolStripButton toolStripBtnDrawLine;
        private System.Windows.Forms.ToolStripButton toolStripBtnDrawRectangle;
        private System.Windows.Forms.ToolStripButton toolStripBtnDrawEllipse;
        private System.Windows.Forms.ToolStripButton toolStripBtnAddText;
        private System.Windows.Forms.ToolStripButton toolStripBtnPenTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripBtnUndo;
        private System.Windows.Forms.ToolStripButton toolStripBtnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripBtnColor;
        private System.Windows.Forms.ToolStripButton toolStripBtnCursor;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxFonts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxToolSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripBtnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripBtnInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripBtnColorText;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toImgurToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripBtnUploadToImgur;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxFontSize;
    }
}