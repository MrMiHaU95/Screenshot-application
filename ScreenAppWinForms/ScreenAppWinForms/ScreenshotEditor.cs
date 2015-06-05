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
        private bool drawLine;
        private bool drawRectangle;
        private bool drawEllipse;
        private Point startlocation = new Point(0, 0);
        private Point currentLocation;
        private Graphics g;
        private Pen pen;
        private float toolSize;

        public ScreenshotEditor()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            this.DoubleBuffered = true;
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

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            canDraw = true;
            startlocation = new Point(e.X, e.Y);

            //if(drawLine)
            //{
            //    Cursor lineCursor = new Cursor(@"Cursors\Line.cur");
            //    Cursor.Current = lineCursor;
            //}
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
                    pen = new Pen(toolStripBtnColor.BackColor, toolSize);
                    g.DrawLine(pen, startlocation, currentLocation);

                    startlocation = new Point(e.X, e.Y);
                    //this.Invalidate();


                }
                else if(drawLine)
                {
                    Cursor drawLineCursor = new Cursor(@"Cursors\Line.cur");
                    Cursor.Current = drawLineCursor;

                    currentLocation = new Point(e.X, e.Y);
                    pen = new Pen(toolStripBtnColor.BackColor, toolSize);
                    g.DrawLine(pen, startlocation, currentLocation);
                    
                }
                else if(drawRectangle)
                {
                    Cursor drawRectangleCursor = new Cursor(@"Cursors\Rectangle.cur");
                    Cursor.Current = drawRectangleCursor;
                }
                else if(drawEllipse)
                {
                    Cursor drawEllipseCursor = new Cursor(@"Cursors\Ellipse.cur");
                    Cursor.Current = drawEllipseCursor;
                }
                //else
                //{
                //    Cursor.Current = Cursors.Default;
                //}
            }

            panel1.Refresh();
            
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            canDraw = false;

            //if(drawLine)
            //{
            //    Cursor lineCursor = new Cursor(@"Cursors\Line.cur");
            //    Cursor.Current = lineCursor;
            //}
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
                }
                else if(drawLine)
                {
                    //Graphics g = e.Graphics;
                    //Pen p = new Pen(toolStripBtnColor.BackColor, toolSize);
                    //g.DrawLine(p, startlocation, currentLocation);
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
                drawLine = true;
                toolStripBtnDrawLine.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnDrawLine);
            }
            else if (toolStripBtnDrawLine.CheckState == CheckState.Checked)
            {
                drawLine = false;
                toolStripBtnDrawLine.CheckState = CheckState.Unchecked;
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            //if(drawLine)
            //{
            //    Cursor lineCursor = new Cursor(@"Cursors\Line.cur");
            //    Cursor.Current = lineCursor;
            //}
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
                drawRectangle = true;
                toolStripBtnDrawRectangle.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnDrawRectangle);
            }
            else if (toolStripBtnDrawRectangle.CheckState == CheckState.Checked)
            {
                drawRectangle = false;
                toolStripBtnDrawRectangle.CheckState = CheckState.Unchecked;
            }
        }

        private void toolStripBtnDrawEllipse_Click(object sender, EventArgs e)
        {
            if (toolStripBtnDrawEllipse.CheckState == CheckState.Unchecked)
            {
                drawEllipse = true;
                toolStripBtnDrawEllipse.CheckState = CheckState.Checked;
                UncheckRestOfButtons(toolStripBtnDrawEllipse);
            }
            else if (toolStripBtnDrawEllipse.CheckState == CheckState.Checked)
            {
                drawEllipse = false;
                toolStripBtnDrawEllipse.CheckState = CheckState.Unchecked;
            }
        }

        private void toolStripBtnDrawLine_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            if(btn.CheckState == CheckState.Checked)
            {
                drawLine = true;
            }
            else
            {
                drawLine = false;
            }
        }

        private void toolStripBtnDrawRectangle_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            if (btn.CheckState == CheckState.Checked)
            {
                drawRectangle = true;
            }
            else
            {
                drawRectangle = false;
            }
        }

        private void toolStripBtnDrawEllipse_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            if (btn.CheckState == CheckState.Checked)
            {
                drawEllipse = true;
            }
            else
            {
                drawEllipse = false;
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



    }
}
