using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    public partial class ScreenshotEditor : Form
    {
        private Point startlocation = new Point(0, 0);
        private Point currentLocation;
        private Pen pen;
        private float toolSize;
        private Line newLine;
        private Rectangle1 newRectangle;
        private Ellipse1 newEllipse;
        private ImprovedPanel panel1;
        private Bitmap bmp;

        public ScreenshotEditor()
        {
            InitializeComponent();

            #region inicjalizacja panela i comboboxa
            panel1 = new ImprovedPanel();
            panel1.Location = new Point(12, 52);
            panel1.Width = 1880;
            panel1.Height = 930;
            panel1.Visible = true;
            panel1.MouseClick += panel1_MouseClick;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;
            panel1.Paint += panel1_Paint;
            panel1.BackColor = Color.White;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(panel1);
            this.DoubleBuffered = true;
            toolStripComboBoxToolSize.SelectedIndex = 0;
            toolStripComboBoxFontSize.SelectedIndex = 0;
            bmp = new Bitmap(panel1.Width, panel1.Height);
            #endregion 
            if(SettingsHelper.CurrentLanguage == "en")
            {
                ChangeLanguageToEnglish();
            }
            else
            {
                ChangeLanguageToPolish();
            }
        }

        private void ChangeLanguageToPolish()
        {
            fileToolStripMenuItem.Text = "Plik";
            openToolStripMenuItem.Text = "Otwórz obraz";
            saveAsToolStripMenuItem.Text = "Zapisz jako";
            exitToolStripMenuItem.Text = "Wyjdź";
            editToolStripMenuItem.Text = "Edytuj";
            clearDrawingsToolStripMenuItem.Text = "Wyczyść rysunki";
            undoToolStripMenuItem.Text = "Cofnij";
            redoToolStripMenuItem.Text = "Ponów";
            uploadToolStripMenuItem.Text = "Uploaduj";
            toImgurToolStripMenuItem.Text = "do Imgur";
            helpToolStripMenuItem.Text = "Pomoc";
            aboutToolStripMenuItem.Text = "O";
            toolStripBtnColorText.Text = "Kolor";
            toolStripComboBoxFontSize.Items.RemoveAt(0);
            toolStripComboBoxFontSize.Items.Insert(0, "Wybierz rozmiar czcionki");
            toolStripComboBoxToolSize.Items.RemoveAt(0);
            toolStripComboBoxToolSize.Items.Insert(0, "Wybierz kolor");
            toolStripBtnNewFile.ToolTipText = "Nowy rysunek";
            toolStripBtnOpenFile.ToolTipText = "Otwórz plik";
            toolStripBtnSaveFile.ToolTipText = "Zapisz...";
            toolStripBtnCursor.ToolTipText = "Kursor";
            toolStripBtnDrawLine.ToolTipText = "Rysuj linię";
            toolStripBtnDrawRectangle.ToolTipText = "Rysuj prostokąt";
            toolStripBtnDrawEllipse.ToolTipText = "Rysuj elipsę";
            toolStripBtnPenTool.ToolTipText = "Narzędzie pióro";
            toolStripBtnUndo.ToolTipText = "Cofnij";
            toolStripBtnRedo.ToolTipText = "Ponów";
            toolStripBtnAddText.ToolTipText = "Dodaj tekst";
            toolStripComboBoxFonts.ToolTipText = "Czcionki";
            toolStripComboBoxFontSize.ToolTipText = "Rozmiar Czcionki";
            toolStripBtnColor.ToolTipText = "Wybierz kolor";
            toolStripComboBoxToolSize.ToolTipText = "Rozmiarz narzędzia";
            toolStripBtnPrint.ToolTipText = "Drukuj";
            toolStripBtnUploadToImgur.ToolTipText = "Upload na imgur";
            toolStripBtnInfo.ToolTipText = "Info";
            this.Text = "Edytor Screenów";
        }

        private void ChangeLanguageToEnglish()
        {
            fileToolStripMenuItem.Text = "File";
            openToolStripMenuItem.Text = "open Image";
            saveAsToolStripMenuItem.Text = "Save as";
            exitToolStripMenuItem.Text = "Exit";
            editToolStripMenuItem.Text = "Edit";
            clearDrawingsToolStripMenuItem.Text = "Clear drawings";
            undoToolStripMenuItem.Text = "Undo";
            redoToolStripMenuItem.Text = "Redo";
            uploadToolStripMenuItem.Text = "Upload";
            toImgurToolStripMenuItem.Text = "to Imgur";
            helpToolStripMenuItem.Text = "Help";
            aboutToolStripMenuItem.Text = "About";
            toolStripBtnColorText.Text = "Color";
            toolStripComboBoxFontSize.Items.RemoveAt(0);
            toolStripComboBoxFontSize.Items.Insert(0, "Select font size");
            toolStripComboBoxToolSize.Items.RemoveAt(0);
            toolStripComboBoxToolSize.Items.Insert(0, "Select color");
            toolStripBtnNewFile.ToolTipText = "New drawing";
            toolStripBtnOpenFile.ToolTipText = "Open file";
            toolStripBtnSaveFile.ToolTipText = "Save...";
            toolStripBtnCursor.ToolTipText = "Cursor";
            toolStripBtnDrawLine.ToolTipText = "Draw line";
            toolStripBtnDrawRectangle.ToolTipText = "Draw rectangle";
            toolStripBtnDrawEllipse.ToolTipText = "Draw Ellipse";
            toolStripBtnPenTool.ToolTipText = "Pen tool";
            toolStripBtnUndo.ToolTipText = "Undo";
            toolStripBtnRedo.ToolTipText = "Redo";
            toolStripBtnAddText.ToolTipText = "Add text";
            toolStripComboBoxFonts.ToolTipText = "Fonts";
            toolStripComboBoxFontSize.ToolTipText = "Font size";
            toolStripBtnColor.ToolTipText = "Select color";
            toolStripComboBoxToolSize.ToolTipText = "Tool size";
            toolStripBtnPrint.ToolTipText = "Print";
            toolStripBtnUploadToImgur.ToolTipText = "Upload to imgur";
            toolStripBtnInfo.ToolTipText = "Info";
            this.Text = "Screenshot editor";
        }
        #region event handlery Form
        private void ScreenshotEditor_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InfoAboutScreenshot.FolderPath))
            {
                Image img = Image.FromFile(InfoAboutScreenshot.FolderPath);
                if(img.Height > panel1.Height || img.Width > panel1.Width)
                {
                    panel1.BackgroundImageLayout = ImageLayout.Stretch;
                    panel1.BackgroundImage = Image.FromFile(InfoAboutScreenshot.FolderPath);
                }
                else
                {
                    panel1.BackgroundImageLayout = ImageLayout.None;
                    panel1.BackgroundImage = Image.FromFile(InfoAboutScreenshot.FolderPath);
                }
            }
            toolStripBtnColor.BackColor = Color.Black;
            LoadFonts();
        }
        #endregion

        #region event handlery panelu
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            DrawingHelper.CanDraw = true;
            startlocation = new Point(e.X, e.Y);
            
            if(DrawingLineHelper.CanDrawLine)
            {
                newLine.StartPoint = new Point(e.X, e.Y);
                newLine.LinePen =  new Pen(toolStripBtnColor.BackColor, toolSize);
            }
            else if(DrawingRectangleHelper.CanDrawRectangle)
            {
                newRectangle = new Rectangle1();
                newRectangle.StartPosition = new Point(e.X, e.Y);
                newRectangle.RectPen = new Pen(toolStripBtnColor.BackColor, toolSize);
            }
            else if(DrawEllipseHelper.CanDrawEllipse)
            {
                newEllipse = new Ellipse1();
                newEllipse.StartPosition = new Point(e.X, e.Y);
                newEllipse.EllipsePen = new Pen(toolStripBtnColor.BackColor, toolSize);
            }
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (DrawingHelper.CanDraw)
            {
                if (PenToolHelper.CanUsePenTool)
                {
                    Cursor penToolCursor = new Cursor(@"Cursors\Pencil.cur");
                    Cursor.Current = penToolCursor;
                    currentLocation = new Point(e.X, e.Y);
                    //pen = new Pen(toolStripBtnColor.BackColor, toolSize);
                    //g.DrawLine(pen, startlocation, currentLocation);
                    startlocation = new Point(e.X, e.Y);
                    panel1.Invalidate();
                }
                else if(DrawingLineHelper.CanDrawLine)
                {
                    Cursor drawLineCursor = new Cursor(@"Cursors\Line.cur");
                    Cursor.Current = drawLineCursor;
                    newLine.EndPoint = new Point(e.X, e.Y);
                    panel1.Invalidate();
                    
                }
                else if(DrawingRectangleHelper.CanDrawRectangle)
                {
                    Cursor drawRectangleCursor = new Cursor(@"Cursors\Rectangle.cur");
                    Cursor.Current = drawRectangleCursor;
                    newRectangle.CurrentPosition = new Point(e.X, e.Y);
                    newRectangle.Width = Math.Abs(newRectangle.CurrentPosition.X - newRectangle.StartPosition.X);
                    newRectangle.Height = Math.Abs(newRectangle.CurrentPosition.Y - newRectangle.StartPosition.Y);
                    panel1.Invalidate();

                }
                else if(DrawEllipseHelper.CanDrawEllipse)
                {
                    Cursor drawEllipseCursor = new Cursor(@"Cursors\Ellipse.cur");
                    Cursor.Current = drawEllipseCursor;
                    newEllipse.Endposition = new Point(e.X, e.Y);
                    newEllipse.Width = Math.Abs(newEllipse.Endposition.X - newEllipse.StartPosition.X);
                    newEllipse.Height = Math.Abs(newEllipse.Endposition.Y - newEllipse.StartPosition.Y);
                    panel1.Invalidate();
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            DrawingHelper.CanDraw = false;
            if (DrawingLineHelper.CanDrawLine)
            {
                ShapesManagercs.ShapeList.Add(newLine);
                newLine = new Line();
            }
            else if(DrawingRectangleHelper.CanDrawRectangle)
            {
                ShapesManagercs.ShapeList.Add(newRectangle);
                newRectangle = new Rectangle1();
            }
            else if(DrawEllipseHelper.CanDrawEllipse)
            {
                ShapesManagercs.ShapeList.Add(newEllipse);
                newEllipse = new Ellipse1();
            }
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (DrawingHelper.CanDraw)
            {
                if (PenToolHelper.CanUsePenTool)
                {
                    //dlaczego to nie działą 
                    //pen = new Pen(toolStripBtnColor.BackColor, toolSize);
                    //g.DrawLine(pen, startlocation, currentLocation);
                    Graphics g = Graphics.FromImage(bmp);
                    pen = new Pen(toolStripBtnColor.BackColor, toolSize);
                    g.DrawLine(pen, startlocation, currentLocation);                
                }
                else if (DrawingLineHelper.CanDrawLine)
                {
                    Graphics g = Graphics.FromImage(bmp);
                    g.Clear(Color.Transparent);
                    g.DrawLine(newLine.LinePen, newLine.StartPoint, newLine.EndPoint);
                }
                else if(DrawingRectangleHelper.CanDrawRectangle)
                {
                    Graphics g = Graphics.FromImage(bmp);
                    g.Clear(Color.Transparent);
                    g.DrawRectangle(newRectangle.RectPen, newRectangle.StartPosition.X, newRectangle.StartPosition.Y, newRectangle.Width, newRectangle.Height);
                }
                else if(DrawEllipseHelper.CanDrawEllipse)
                {
                    Graphics g = Graphics.FromImage(bmp);
                    g.Clear(Color.Transparent);
                    g.DrawEllipse(newEllipse.EllipsePen, newEllipse.StartPosition.X, newEllipse.StartPosition.Y, newEllipse.Width, newEllipse.Height);
                }
            }
            //rysowanie kształtów już narysowanych przez użytkownika
            foreach (Shape s in ShapesManagercs.ShapeList)
            {
                //linia
                if (s.id == 1)
                {
                    Graphics gr = Graphics.FromImage(bmp);
                    Line l = s as Line;
                    gr.DrawLine(l.LinePen, l.StartPoint, l.EndPoint);
                }
                //prostokąt
                else if (s.id == 2)
                {
                    Graphics gr = Graphics.FromImage(bmp);
                    Rectangle1 r = s as Rectangle1;
                    gr.DrawRectangle(r.RectPen, r.StartPosition.X, r.StartPosition.Y, r.Width, r.Height);
                }
                //elipsa
                else if (s.id == 3)
                {
                    Graphics gr = Graphics.FromImage(bmp);
                    Ellipse1 ee = s as Ellipse1;
                    gr.DrawEllipse(ee.EllipsePen, ee.StartPosition.X, ee.StartPosition.Y, ee.Width, ee.Height);
                }
            }
            e.Graphics.DrawImage(bmp, Point.Empty);
        }
        
        
        
        //dodawania tekstu
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (AddTextHelper.CanAddText)
            {
                if ((toolStripComboBoxFonts.Text != "" && toolStripComboBoxFonts.Text != "Select Font") && toolStripComboBoxFontSize.Text != "Select font size")
                {
                    Label label = new Label();
                    label.Location = new Point(e.X, e.Y);
                    Add_Text txt = new Add_Text();
                    txt.ShowDialog();
                    label.Text = txt.TxtToAdd;
                    label.Visible = true;
                    label.BackColor = Color.Transparent;
                    label.ForeColor = toolStripBtnColor.BackColor;
                    label.Font = new Font(toolStripComboBoxFonts.SelectedText, float.Parse(toolStripComboBoxFontSize.Text));

                    int lengthOfText = 0;
                    if (!string.IsNullOrEmpty(label.Text))
                    {
                        lengthOfText = label.Text.Length;
                    }
                    if(lengthOfText < 3)
                    {
                        lengthOfText *= 4;
                    }
                    label.Size = new System.Drawing.Size(lengthOfText * 10 * int.Parse(toolStripComboBoxFontSize.Text), lengthOfText * 10);
                    panel1.Controls.Add(label);
                }
                else
                {
                    MessageBox.Show("Select font size and font family first", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region event handlery ToolStripButton
        private void toolStripBtnColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            toolStripBtnColor.BackColor = colorDialog1.Color;
        }
        private void toolStripComboBoxToolSize_TextChanged(object sender, EventArgs e)
        {
            float result;
            if (toolStripComboBoxToolSize.Text != "Select size")
            {
                if (float.TryParse(toolStripComboBoxToolSize.Text, out result))
                {
                    toolSize = result;
                }
                else
                {
                    MessageBox.Show("invalid tool size");
                    toolStripComboBoxToolSize.Text = "Select size";
                }
            }
        }
        private void toolStripBtnDrawLine_Click(object sender, EventArgs e)
        {
            if (toolStripBtnDrawLine.CheckState == CheckState.Unchecked)
            {
                DrawingLineHelper.CanDrawLine = true;
                newLine = new Line();
                toolStripBtnDrawLine.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnDrawLine);
            }
            else if (toolStripBtnDrawLine.CheckState == CheckState.Checked)
            {
                DrawingLineHelper.CanDrawLine = false;
                toolStripBtnDrawLine.CheckState = CheckState.Unchecked;
            }
        }
        private void toolStripBtnPenTool_Click(object sender, EventArgs e)
        {
            if (toolStripBtnPenTool.CheckState == CheckState.Unchecked)
            {
                PenToolHelper.CanUsePenTool = true;
                toolStripBtnPenTool.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnPenTool);
            }
            else if (toolStripBtnPenTool.CheckState == CheckState.Checked)
            {
                PenToolHelper.CanUsePenTool = false;
                toolStripBtnPenTool.CheckState = CheckState.Unchecked;
            }
        }
        private void toolStripBtnDrawRectangle_Click(object sender, EventArgs e)
        {
            if (toolStripBtnDrawRectangle.CheckState == CheckState.Unchecked)
            {
                DrawingRectangleHelper.CanDrawRectangle = true;
                toolStripBtnDrawRectangle.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnDrawRectangle);
            }
            else if (toolStripBtnDrawRectangle.CheckState == CheckState.Checked)
            {
                DrawingRectangleHelper.CanDrawRectangle = false;
                toolStripBtnDrawRectangle.CheckState = CheckState.Unchecked;
            }
        }
        private void toolStripBtnDrawEllipse_Click(object sender, EventArgs e)
        {
            if (toolStripBtnDrawEllipse.CheckState == CheckState.Unchecked)
            {
                DrawEllipseHelper.CanDrawEllipse = true;
                toolStripBtnDrawEllipse.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnDrawEllipse);
            }
            else if (toolStripBtnDrawEllipse.CheckState == CheckState.Checked)
            {
                DrawEllipseHelper.CanDrawEllipse = false;
                toolStripBtnDrawEllipse.CheckState = CheckState.Unchecked;
            }
        }
        private void toolStripBtnDrawLine_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            if (btn.CheckState == CheckState.Checked)
            {
                DrawingLineHelper.CanDrawLine = true;
                UncheckRestOfButtons(toolStripBtnDrawLine);
            }
            else
            {
                DrawingLineHelper.CanDrawLine = false;
            }
        }
        private void toolStripBtnDrawRectangle_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            if (btn.CheckState == CheckState.Checked)
            {
                DrawingRectangleHelper.CanDrawRectangle = true;
                UncheckRestOfButtons(toolStripBtnDrawRectangle);
            }
            else
            {
                DrawingRectangleHelper.CanDrawRectangle = false;
            }
        }
        private void toolStripBtnDrawEllipse_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            if (btn.CheckState == CheckState.Checked)
            {
                DrawEllipseHelper.CanDrawEllipse = true;
            }
            else
            {
                DrawEllipseHelper.CanDrawEllipse = false;
            }
        }
        private void toolStripBtnPenTool_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            if (btn.CheckState == CheckState.Checked)
            {
                PenToolHelper.CanUsePenTool = true;
            }
            else
            {
                PenToolHelper.CanUsePenTool = false;
            }
        }
        private void toolStripBtnAddText_Click(object sender, EventArgs e)
        {
            if (toolStripBtnAddText.CheckState == CheckState.Unchecked)
            {
                AddTextHelper.CanAddText = true;
                toolStripBtnAddText.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnAddText);
            }
            else if (toolStripBtnAddText.CheckState == CheckState.Checked)
            {
                AddTextHelper.CanAddText = false;
                toolStripBtnAddText.CheckState = CheckState.Unchecked;
            }
        }
        private void toolStripBtnAddText_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            if (btn.CheckState == CheckState.Checked)
            {
                AddTextHelper.CanAddText = true;
            }
            else
            {
                AddTextHelper.CanAddText = false;
            }
        }
        private void toolStripBtnNewFile_Click(object sender, EventArgs e)
        {
            if (toolStripBtnNewFile.CheckState == CheckState.Unchecked)
            {
                toolStripBtnNewFile.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnNewFile);
                NewEmptyDrawingSpace();
            }
            else if (toolStripBtnNewFile.CheckState == CheckState.Checked)
            {
                toolStripBtnNewFile.CheckState = CheckState.Unchecked;
            }
        }
        private void toolStripBtnOpenFile_Click(object sender, EventArgs e)
        {
            if (toolStripBtnOpenFile.CheckState == CheckState.Unchecked)
            {
                toolStripBtnOpenFile.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnOpenFile);
                OpenNewImage();
            }
            else if (toolStripBtnOpenFile.CheckState == CheckState.Checked)
            {
                toolStripBtnOpenFile.CheckState = CheckState.Unchecked;
            }
        }
        //zapisywanie do pliku
        private void toolStripBtnSaveFile_Click(object sender, EventArgs e)
        {
            if (toolStripBtnSaveFile.CheckState == CheckState.Unchecked)
            {
                toolStripBtnSaveFile.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnSaveFile);
                SaveDrawingsTo();
            }
            else if (toolStripBtnSaveFile.CheckState == CheckState.Checked)
            {
                toolStripBtnSaveFile.CheckState = CheckState.Unchecked;
            }
        }
        private void toolStripBtnCursor_Click(object sender, EventArgs e)
        {
            if (toolStripBtnCursor.CheckState == CheckState.Unchecked)
            {
                toolStripBtnCursor.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnCursor);
            }
            else if (toolStripBtnCursor.CheckState == CheckState.Checked)
            {
                toolStripBtnCursor.CheckState = CheckState.Unchecked;
            }
        }
        private void toolStripBtnUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void toolStripBtnRedo_Click(object sender, EventArgs e)
        {
            Redo();
        }
        private void toolStripBtnUploadToImgur_Click(object sender, EventArgs e)
        {
            if (toolStripBtnUploadToImgur.CheckState == CheckState.Unchecked)
            {
                toolStripBtnUploadToImgur.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnUploadToImgur);
                UploadToImgurHandler();
            }
            else if (toolStripBtnUploadToImgur.CheckState == CheckState.Checked)
            {
                toolStripBtnUploadToImgur.CheckState = CheckState.Unchecked;
            }
        }
        #endregion

        #region event handlery ToolStripMenu
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewImage();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDrawingsTo();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void clearDrawingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NewEmptyDrawingSpace();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }
        private void toImgurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadToImgurHandler();
        }
        #endregion

        #region metody z refactoringu ToolStripMenuItem i ToolStripButtons
        /// <summary>
        /// Wczytuje czcionki zapisane na dysku
        /// </summary>
        public void LoadFonts()
        {
            toolStripComboBoxFonts.Items.Add("Select Font");
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                toolStripComboBoxFonts.Items.Add(font.Name);
            }
        }
        /// <summary>
        /// Odznacza wszystkie przyciski po za podanym służy to temu aby w danym momencie tylko jeden z nich był aktywny
        /// </summary>
        /// <param name="checkedButton">przycisk który ma pozostać zaznaczony</param>
        public void UncheckRestOfButtons(ToolStripButton checkedButton)
        {
            List<ToolStripButton> Buttons = new List<ToolStripButton>();
            Buttons.Add(toolStripBtnDrawLine);
            Buttons.Add(toolStripBtnDrawRectangle);
            Buttons.Add(toolStripBtnDrawEllipse);
            Buttons.Add(toolStripBtnPenTool);
            Buttons.Add(toolStripBtnAddText);
            Buttons.Add(toolStripBtnNewFile);
            Buttons.Add(toolStripBtnOpenFile);
            Buttons.Add(toolStripBtnSaveFile);
            Buttons.Add(toolStripBtnCursor);
            Buttons.Add(toolStripBtnUndo);
            Buttons.Add(toolStripBtnRedo);
            Buttons.Add(toolStripBtnPrint);
            Buttons.Add(toolStripBtnUploadToImgur);
            Buttons.Add(toolStripBtnInfo);

            foreach (ToolStripButton btn in Buttons)
            {
                if (btn != checkedButton)
                {
                    btn.CheckState = CheckState.Unchecked;
                }
            }
        }
        /// <summary>
        /// czysczenie przestrzenie do rysowania oraz obrazka tła
        /// </summary>
        private void NewEmptyDrawingSpace()
        {
            ShapesManagercs.ShapeList.Clear();
            panel1.BackgroundImage = null;
            panel1.BackColor = Color.White;
            bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.Invalidate();
        }
        private void OpenNewImage()
        {
            //wczytanie nowego obrazka
            ShapesManagercs.ShapeList.Clear();
            panel1.BackgroundImage = null;
            panel1.BackColor = Color.White;
            panel1.Invalidate();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open image";
            ofd.Filter = "JPEG|*.jpg|Bitmapa|*.bmp|Gif|*.gif|PNG|*.png";
            DialogResult result = ofd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Image loadedImage = Image.FromFile(ofd.FileName);
                panel1.BackgroundImageLayout = ImageLayout.None;
                panel1.BackgroundImage = loadedImage;
            }
        }
        private void SaveDrawingsTo()
        {
            //zapisywanie pliku
            Image imageToSave = panel1.BackgroundImage;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save image";
            sfd.Filter = "JPEG|*.jpg|Bitmapa|*.bmp|Gif|*.gif|PNG|*.png";
            DialogResult result = sfd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //jesli jest tło i kształty
                if (imageToSave != null)
                {
                    using (Graphics g = Graphics.FromImage(imageToSave))
                    {
                        g.DrawImage(bmp, 0, 0);
                    }
                    imageToSave.Save(sfd.FileName);
                }
                else
                {
                    bmp.Save(sfd.FileName);
                }
            }
        }
        /// <summary>
        /// Cofanie operacji tylko rysowanie linii, prostokąta lub elipsy
        /// </summary>
        private void Undo()
        {
            if (ShapesManagercs.ShapeList.Count != 0)
            {
                Shape undoShape = ShapesManagercs.ShapeList[ShapesManagercs.ShapeList.Count - 1];
                ShapesManagercs.ShapeListUndo.Add(undoShape);
                ShapesManagercs.ShapeList.Remove(undoShape);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.Transparent);
                panel1.Invalidate();
            }
        }
        /// <summary>
        /// ponowianie operacji tylko rysowanie linii, prostokąta lub elipsy
        /// </summary>
        private void Redo()
        {
            if (ShapesManagercs.ShapeListUndo.Count != 0)
            {
                Shape redoShape = ShapesManagercs.ShapeListUndo[ShapesManagercs.ShapeListUndo.Count - 1];
                ShapesManagercs.ShapeList.Add(redoShape);
                ShapesManagercs.ShapeListUndo.Remove(redoShape);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.Transparent);
                panel1.Invalidate();
            }
        }
        private void UploadToImgurHandler()
        {
            Image imageToSave = panel1.BackgroundImage;
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            //upload na imgur
            if (imageToSave != null)
            {
                using (Graphics g = Graphics.FromImage(imageToSave))
                {
                    g.DrawImage(bmp, 0, 0);
                }
                imageToSave.Save(directory + @"\\1.png");
                UploadToImgurHelper.UploadScreenshot(directory + @"\\1.png");
            }
            else
            {
                bmp.Save(directory + @"\\1.png");
                UploadToImgurHelper.UploadScreenshot(directory + @"\\1.png");
            }
        }
        #endregion

        private void toolStripBtnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;
            pd.PrintPage += pd_PrintPage;
            pd.Print();
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image imageToSave = panel1.BackgroundImage;
            Point loc = new Point(100, 100);

            if (imageToSave != null)
            {
                using (Graphics g = Graphics.FromImage(imageToSave))
                {
                    g.DrawImage(bmp, 0, 0);
                }
                e.Graphics.DrawImage(imageToSave, loc);
            }
            else
            {
                e.Graphics.DrawImage(bmp, loc);
            }
        }
    }
}
