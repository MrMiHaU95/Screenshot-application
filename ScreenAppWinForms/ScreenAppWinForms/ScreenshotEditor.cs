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
    public partial class ScreenshotEditor : Form
    {
        private bool canDraw;
        private bool penTool;
        //private bool drawLine;
        //private bool drawRectangle;
        //private bool drawEllipse;
        private Point startlocation = new Point(0, 0);
        private Point currentLocation;
        //private Point lineStartPosition;
        //private Point lineEndPosition;
        private Graphics g;
        private Pen pen;
        private float toolSize;
        //private List<Line> LineListToDraw = new List<Line>();
        private Line newLine;
        private Rectangle1 newRectangle;
        private Ellipse1 newEllipse;

        public ScreenshotEditor()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            this.DoubleBuffered = true;
            toolStripComboBoxToolSize.SelectedIndex = 0;
            toolStripComboBoxFontSize.SelectedIndex = 0;
        }

       //http://stackoverflow.com/questions/2073519/uploading-to-imgur-com

        //http://www.codeproject.com/Tips/811495/Simple-Paint-Application-in-Csharp

        //http://www.codeproject.com/Articles/22776/WPF-DrawTools

        

        private void ScreenshotEditor_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InfoAboutScreenshot.FolderPath))
            {
                panel1.BackgroundImage = Image.FromFile(InfoAboutScreenshot.FolderPath);
            }

            toolStripBtnColor.BackColor = Color.Black;

            LoadFonts();

        }

        public void LoadFonts()
        {
            toolStripComboBoxFonts.Items.Add("Select Font");
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                toolStripComboBoxFonts.Items.Add(font.Name);
            }
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            canDraw = true;
            startlocation = new Point(e.X, e.Y);
            //lineStartPosition = new Point(e.X, e.Y);
            
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
            //if (penTool)
            //{
            //    Cursor lineCursor = new Cursor(@"Cursors\Pencil.cur");
            //    Cursor.Current = lineCursor;
            //}

            if (canDraw)
            {
                if (penTool)
                {
                    Cursor penToolCursor = new Cursor(@"Cursors\Pencil.cur");
                    Cursor.Current = penToolCursor;

                    currentLocation = new Point(e.X, e.Y);
                    //pen = new Pen(toolStripBtnColor.BackColor, toolSize);
                    //g.DrawLine(pen, startlocation, currentLocation);

                    startlocation = new Point(e.X, e.Y);
                    this.Invalidate();


                }
                else if(DrawingLineHelper.CanDrawLine)
                {
                    Cursor drawLineCursor = new Cursor(@"Cursors\Line.cur");
                    Cursor.Current = drawLineCursor;

                    //currentLocation = new Point(e.X, e.Y);
                    //pen = new Pen(toolStripBtnColor.BackColor, toolSize);
                    //g.DrawLine(pen, startlocation, currentLocation);

                    //lineEndPosition = new Point(e.X, e.Y);
                    newLine.EndPoint = new Point(e.X, e.Y);
                    panel1.Invalidate();
                    
                }
                else if(DrawingRectangleHelper.CanDrawRectangle)
                {
                    Cursor drawRectangleCursor = new Cursor(@"Cursors\Rectangle.cur");
                    Cursor.Current = drawRectangleCursor;

                    newRectangle.CurrentPosition = new Point(e.X, e.Y);

                    int x = Math.Min(newRectangle.StartPosition.X, newRectangle.CurrentPosition.X);
                    int y = Math.Min(newRectangle.StartPosition.Y, newRectangle.CurrentPosition.Y);

                    //newRectangle.StartPosition = new Point(x, y);

                    int width = Math.Abs(newRectangle.CurrentPosition.X - newRectangle.StartPosition.X);
                    int height = Math.Abs(newRectangle.CurrentPosition.Y - newRectangle.StartPosition.Y);
                    newRectangle.Width = width;
                    newRectangle.Height = height;
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
                //else
                //{
                //    Cursor.Current = Cursors.Default;
                //}
            }

            //panel1.Refresh();
            
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            canDraw = false;

            if (DrawingLineHelper.CanDrawLine)
            {
                //LineListToDraw.Add(new Line(new Pen(toolStripBtnColor.BackColor, toolSize), lineStartPosition, lineEndPosition));
                //LineListToDraw.Add(newLine);
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
            //g = e.Graphics; 
            if (canDraw)
            {
                if(penTool)
                {
                    //dlaczego to nie działą 
                    //pen = new Pen(toolStripBtnColor.BackColor, toolSize);
                    //g.DrawLine(pen, startlocation, currentLocation);
                    Graphics g = e.Graphics;
                    pen = new Pen(toolStripBtnColor.BackColor, toolSize);
                    g.DrawLine(pen, startlocation, currentLocation);
                    
                }
                else if (DrawingLineHelper.CanDrawLine)
                {
                    //Graphics g = e.Graphics;
                    //Pen p = new Pen(toolStripBtnColor.BackColor, toolSize);
                    //g.DrawLine(p, startlocation, currentLocation);
                    Graphics g = e.Graphics;
                    //g.DrawLine(new Pen(toolStripBtnColor.BackColor, toolSize), lineStartPosition, lineEndPosition);
                    g.DrawLine(newLine.LinePen, newLine.StartPoint, newLine.EndPoint);
                }
                else if(DrawingRectangleHelper.CanDrawRectangle)
                {

                    g.DrawRectangle(newRectangle.RectPen, newRectangle.StartPosition.X, newRectangle.StartPosition.Y, newRectangle.Width, newRectangle.Height);
                }
                else if(DrawEllipseHelper.CanDrawEllipse)
                {
                    g.DrawEllipse(newEllipse.EllipsePen, newEllipse.StartPosition.X, newEllipse.StartPosition.Y, newEllipse.Width, newEllipse.Height);
                }
            }
            Graphics gr = panel1.CreateGraphics();
            //foreach (Line l in ShapesManagercs.ShapeList)
            //{
            //    gr.DrawLine(l.LinePen, l.StartPoint, l.EndPoint);
            //}
            //foreach(Rectangle1 r in ShapesManagercs.ShapeList)
            //{
            //    g.DrawRectangle(r.RectPen, r.StartPosition.X, r.StartPosition.Y, r.Width, r.Height);
            //}
            
            foreach(Shape s in ShapesManagercs.ShapeList)
            {
                //linia
                if(s.id == 1)
                {
                    Line l = s as Line;
                    gr.DrawLine(l.LinePen, l.StartPoint, l.EndPoint);
                }
                    //prostokąt
                else if(s.id == 2)
                {
                    Rectangle1 r = s as Rectangle1;
                    g.DrawRectangle(r.RectPen, r.StartPosition.X, r.StartPosition.Y, r.Width, r.Height);
                }
                    //elipsa
                else if(s.id == 3)
                {
                    Ellipse1 ee = s as Ellipse1;
                    g.DrawEllipse(ee.EllipsePen, ee.StartPosition.X, ee.StartPosition.Y, ee.Width, ee.Height);
                }
            }
        }

        private void toolStripBtnColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

            toolStripBtnColor.BackColor = colorDialog1.Color;
        }

        private void toolStripComboBoxToolSize_TextChanged(object sender, EventArgs e)
        {
            float result;
            if(toolStripComboBoxToolSize.Text != "Select size")
            {
                if (float.TryParse(toolStripComboBoxToolSize.Text,out result))
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
                //drawLine = true;
                DrawingLineHelper.CanDrawLine = true;
                newLine = new Line();
                toolStripBtnDrawLine.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnDrawLine);
            }
            else if (toolStripBtnDrawLine.CheckState == CheckState.Checked)
            {
                //drawLine = false;
                DrawingLineHelper.CanDrawLine = false;
                toolStripBtnDrawLine.CheckState = CheckState.Unchecked;
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
        }

        private void toolStripBtnPenTool_Click(object sender, EventArgs e)
        {
            if (toolStripBtnPenTool.CheckState == CheckState.Unchecked)
            {
                penTool = true;
                toolStripBtnPenTool.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnPenTool);
            }
            else if (toolStripBtnPenTool.CheckState == CheckState.Checked)
            {
                penTool = false;
                toolStripBtnPenTool.CheckState = CheckState.Unchecked;
            }
        }

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

            foreach(ToolStripButton btn in Buttons)
            {
                if(btn != checkedButton)
                {
                    btn.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void toolStripBtnDrawRectangle_Click(object sender, EventArgs e)
        {
            if (toolStripBtnDrawRectangle.CheckState == CheckState.Unchecked)
            {
                //drawRectangle = true;
                DrawingRectangleHelper.CanDrawRectangle = true;
                toolStripBtnDrawRectangle.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnDrawRectangle);
            }
            else if (toolStripBtnDrawRectangle.CheckState == CheckState.Checked)
            {
                //drawRectangle = false;
                DrawingRectangleHelper.CanDrawRectangle = false;
                toolStripBtnDrawRectangle.CheckState = CheckState.Unchecked;
            }
        }

        private void toolStripBtnDrawEllipse_Click(object sender, EventArgs e)
        {
            if (toolStripBtnDrawEllipse.CheckState == CheckState.Unchecked)
            {
                //drawEllipse = true;
                DrawEllipseHelper.CanDrawEllipse = true;
                toolStripBtnDrawEllipse.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnDrawEllipse);
            }
            else if (toolStripBtnDrawEllipse.CheckState == CheckState.Checked)
            {
                //drawEllipse = false;
                DrawEllipseHelper.CanDrawEllipse = false;
                toolStripBtnDrawEllipse.CheckState = CheckState.Unchecked;
            }
        }

        private void toolStripBtnDrawLine_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            if(btn.CheckState == CheckState.Checked)
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
                //drawRectangle = true;
                DrawingRectangleHelper.CanDrawRectangle = true;
                UncheckRestOfButtons(toolStripBtnDrawRectangle);
            }
            else
            {
                //drawRectangle = false;
                DrawingRectangleHelper.CanDrawRectangle = false;
            }
        }

        private void toolStripBtnDrawEllipse_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            if (btn.CheckState == CheckState.Checked)
            {
                //drawEllipse = true;
                DrawEllipseHelper.CanDrawEllipse = true;
            }
            else
            {
                //drawEllipse = false;
                DrawEllipseHelper.CanDrawEllipse = false;
            }
        }

        private void toolStripBtnPenTool_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            if (btn.CheckState == CheckState.Checked)
            {
                penTool = true;
            }
            else
            {
                penTool = false;
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

        //http://stackoverflow.com/questions/3426089/fill-combobox-with-list-of-available-fonts

        //dodawania tekstu
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (AddTextHelper.CanAddText)
            {
                Label label = new Label();
                label.Location = new Point(e.X, e.Y);
                Add_Text txt = new Add_Text();
                txt.ShowDialog();

                label.Text = txt.TxtToAdd;
                label.Visible = true;
                label.ForeColor = toolStripBtnColor.BackColor;
                if(toolStripComboBoxFonts.SelectedText != "Select Font" && toolStripComboBoxFontSize.SelectedText != "Select font size")
                {
                    label.Font = new Font(toolStripComboBoxFonts.SelectedText, float.Parse(toolStripComboBoxFontSize.Text));
                }
                int lengthOfText = 0;
                if (!string.IsNullOrEmpty(label.Text))
                {
                    lengthOfText = label.Text.Length;
                }
                label.Size = new System.Drawing.Size(lengthOfText * 10 * int.Parse(toolStripComboBoxFontSize.Text), lengthOfText*10);
                panel1.Controls.Add(label);
            }
        }

        private void toolStripBtnNewFile_Click(object sender, EventArgs e)
        {

            if (toolStripBtnNewFile.CheckState == CheckState.Unchecked)
            {
                toolStripBtnNewFile.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnNewFile);

                //wyczyszcenie wszystkich obiektów nowe tło
                ShapesManagercs.ShapeList.Clear();
                panel1.BackgroundImage = null;
                panel1.BackColor = Color.White;
                panel1.Invalidate();
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

                //wczytanie nowego obrazka
                ShapesManagercs.ShapeList.Clear();
                panel1.BackgroundImage = null;
                panel1.BackColor = Color.White;
                panel1.Invalidate();

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Open image";
                ofd.Filter = "JPEG|*.jpg|Bitmapa|*.bmp|Gif|*.gif|PNG|*.png";
                DialogResult result = ofd.ShowDialog();
                if(result == System.Windows.Forms.DialogResult.OK)
                {
                    Image loadedImage = Image.FromFile(ofd.FileName);
                    panel1.BackgroundImageLayout = ImageLayout.None;
                    panel1.BackgroundImage = loadedImage;
                }
            }
            else if (toolStripBtnOpenFile.CheckState == CheckState.Checked)
            {
                toolStripBtnOpenFile.CheckState = CheckState.Unchecked;
            }
        }

        //http://stackoverflow.com/questions/22843369/c-sharp-save-modified-image-in-panel
        //zapisywanie do pliku
        private void toolStripBtnSaveFile_Click(object sender, EventArgs e)
        {
            if (toolStripBtnSaveFile.CheckState == CheckState.Unchecked)
            {
                toolStripBtnSaveFile.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnSaveFile);


                //zapisywanie pliku
                Image imageToSave = panel1.BackgroundImage;

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Save image";
                sfd.Filter = "JPEG|*.jpg|Bitmapa|*.bmp|Gif|*.gif|PNG|*.png";
                DialogResult result = sfd.ShowDialog();
                if(result == System.Windows.Forms.DialogResult.OK)
                {
                    Bitmap b = new Bitmap(panel1.Width,panel1.Height);
                    panel1.DrawToBitmap(b, new Rectangle(panel1.Location.X, panel1.Location.Y, panel1.Width, panel1.Height));
                    b.Save(sfd.FileName);
                }
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

        //cofanie zmian
        private void toolStripBtnUndo_Click(object sender, EventArgs e)
        {
            if (ShapesManagercs.ShapeList.Count != 0)
            {
                Shape undoShape = ShapesManagercs.ShapeList[ShapesManagercs.ShapeList.Count - 1];
                ShapesManagercs.ShapeListUndo.Add(undoShape);
                ShapesManagercs.ShapeList.Remove(undoShape);
                panel1.Invalidate();
            }
        }

        //cofanie cofania zmian
        private void toolStripBtnRedo_Click(object sender, EventArgs e)
        {
            if(ShapesManagercs.ShapeListUndo.Count != 0)
            {
                Shape redoShape = ShapesManagercs.ShapeListUndo[ShapesManagercs.ShapeListUndo.Count - 1];
                ShapesManagercs.ShapeList.Add(redoShape);
                ShapesManagercs.ShapeListUndo.Remove(redoShape);
                panel1.Invalidate();
            }
        }

        
    }
}
