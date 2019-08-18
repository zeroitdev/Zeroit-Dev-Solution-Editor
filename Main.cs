using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ZeroitDevSolutionEditor
{
    public partial class Main : FormStyler
    {
        #region Enums
        public enum Mode
        {
            FreeForm,
            Rectangle,
            Circle,
            Triangle,
            Line,
            Spline
        }

        #endregion

        #region Private Fields

        string path = String.Empty;

        private Bitmap temporalScreenShot = null;

        private bool canPaint = false;

        private Graphics g;

        private Color penColor = Color.Cyan;

        private float penSize = 1f;

        private int? prevX = null;

        private int? prevY = null;

        List<PictureBox> pages = new List<PictureBox>();

        List<Bitmap> screenShotImages = new List<Bitmap>();

        List<Label> numbering = new List<Label>()
        {
            new Label()
        };

        private bool maximized = false;

        TransparentPanel changeSizeColorPanel = new ZeroitDevSolutionEditor.TransparentPanel();

        int tag = 0;

        private Mode drawingMode = Mode.FreeForm;

        List<string> imageCodes = new List<string>();

        const int locX = 3;
        const int locY = 0;
        const int height = 122;

        int selectedIndex = 0;

        int polyWidthHeight = 5;

        bool fullScreen = false;

        bool shiftRight = false;

        bool shiftLeft = false;

        bool eraser = false;

        SplashScreenForm splash = new SplashScreenForm();

        #endregion

        #region Public Properties

        public Mode Drawing
        {
            get { return drawingMode; }
            set
            {
                drawingMode = value;
                Invalidate();
            }
        }

        #endregion

        #region Constructor

        public Main()
        {
            InitializeComponent();

            CenterScreen(this);

            imageList1.Images.Add(Properties.Resources.eraser_100);

            ChangeSizeColorPanel();

            g = board1.CreateGraphics();
            g.SmoothingMode = SmoothingMode.HighQuality;

            foreach (PictureBox viewers in rightScreenShotPanel.Controls)
            {
                pages.Add(viewers);
            }
            
            numbering[0].AutoSize = true;
            numbering[0].Font = new Font("Verdana", 7);
            numbering[0].ForeColor = Color.White;
            numbering[0].Text = (numbering.Count - 1 + 1).ToString();
            Graphics firstG = CreateGraphics();
            SizeF firstFS = firstG.MeasureString(numbering[0].Text, numbering[0].Font);
            numbering[0].Location = new Point(firstViewer.Location.X + (rightScreenShotPanel.Width / 2) - (int)(firstFS.Width / 2) - 5, firstViewer.Location.Y + firstViewer.Height);
            rightScreenShotPanel.Controls.Add(numbering[0]);
            //MessageBox.Show(string.Format("Form \nWidth : {0} \nHeight : {1} \nContainer \nWidth : {2} \nHeight : {3}",
            //    Width, Height, panelContainer.Width, panelContainer.Height));

            brushSizeNumBtn.Value = (decimal)penSize ;
            brushSizeSmallNum.Value = (decimal)penSize;
            penSizeNumBtn.Value = (decimal)penSize;
            penSizeSmallNum.Value = (decimal)penSize;

            penColorBtn.BackColor = penColor;
            penColorBelow.BackColor = penColor;
            canvasColorBtn.BackColor = Color.FromArgb(28, 28, 28);
            canvasColorBelow.BackColor = Color.FromArgb(28, 28, 28);

        }

        #endregion

        #region Close
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Minimize
        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Maximize

        private void maxBtn_Click(object sender, EventArgs e)
        {
            
            Bitmap notMaximizedScreenshot = MakeScreenshot(board1);
            
            this.WindowState = FormWindowState.Maximized;

            maximized = !maximized;

            if (maximized)
            {
                
                board1.SizeMode = PictureBoxSizeMode.Zoom;
                board1.Image = notMaximizedScreenshot;
                Corners = 1;
                
            }
            else
            {
                this.WindowState = FormWindowState.Normal;

                board1.SizeMode = PictureBoxSizeMode.Zoom;
                board1.Image = notMaximizedScreenshot;
                Corners = 10;
            }
        }

        #endregion

        #region Screen Shot

        private Bitmap MakeScreenshot(Rectangle rect)
        {
            // Capture an rectangle area from the screen
            Bitmap bmp = new Bitmap(rect.Width, rect.Height);

            #region Old Code
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // The standard C# screen capturing
                g.CopyFromScreen(rect.Location, new Point(rect.Location.X, rect.Location.Y), bmp.Size);

                //this.Refresh();


            }
            #endregion

            //this.Refresh();
            return bmp;
        }

        private Bitmap MakeScreenshot(Control control)
        {
            // Capture an rectangle area from the screen
            Bitmap bmp = new Bitmap(control.Width, control.Height);

            #region Old Code
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);

                g.CopyFromScreen(
                    control.PointToScreen(control.ClientRectangle.Location),
                    new Point(0, 0), control.ClientRectangle.Size
                );

            }
            #endregion

            //this.Refresh();
            return bmp;
        }



        #region Windows API
        /// <summary>
        /// This private class is holding all used Win32 API calls and constants
        /// </summary>
        private static class W32
        {
            /// <summary>
            /// Copy the source with BitBlt
            /// </summary>
            public const int SRCCOPY = 0x00CC0020;
            /// <summary>
            /// Copy alpha / layered with BitBlt
            /// </summary>
            public const int CAPTUREBLT = 0x40000000;

            /// <summary>
            /// BitBlt method from the GDI API
            /// </summary>
            /// <param name="hDestDC">Destination DC handle</param>
            /// <param name="x">Destination x</param>
            /// <param name="y">Destination y</param>
            /// <param name="nWidth">Destination width</param>
            /// <param name="nHeight">Destination height</param>
            /// <param name="hSrcDC">Source DC handle</param>
            /// <param name="xSrc">Source x</param>
            /// <param name="ySrc">Source y</param>
            /// <param name="dwRop">Options</param>
            /// <returns>Result</returns>
            [DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = false)]
            public static extern UInt64 BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, System.Int32 dwRop);

            /// <summary>
            /// Get the desktop window handle
            /// </summary>
            /// <returns>Desktop window handle</returns>
            [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = false)]
            public static extern IntPtr GetDesktopWindow();

            /// <summary>
            /// Get a window DC
            /// </summary>
            /// <param name="hwnd">Window handle</param>
            /// <returns>Window DC</returns>
            [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = false)]
            public static extern IntPtr GetWindowDC(IntPtr hwnd);

            /// <summary>
            /// Release a DC
            /// </summary>
            /// <param name="hwnd">Window handle</param>
            /// <param name="dc">Window DC</param>
            /// <returns>Result</returns>
            [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = false)]
            public static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);
        }
        #endregion


        #endregion

        #region Drawing

        private void DrawingMouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                canPaint = true;

                splinePoints.Add(new Point(prevX ?? e.X, prevY ?? e.Y));
                splinePoints.Add(new Point(e.X, e.Y));
            }

        }

        private void DrawingMouseUp(object sender, MouseEventArgs e)
        {
            Point center = new Point(e.X, e.Y);

            //g = board1.CreateGraphics();

            Pen pen = new Pen(penColor, penSize);

            if ((e.Button & MouseButtons.Left) != 0)
            {
                switch (Drawing)
                {
                    case Mode.FreeForm:
                        break;
                    case Mode.Rectangle:
                        g.DrawRectangle(pen, new Rectangle(splinePoints[splinePoints.Count - 1].X, splinePoints[splinePoints.Count - 1].Y, polyWidthHeight, polyWidthHeight));
                        break;
                    case Mode.Circle:
                        g.DrawEllipse(pen, new Rectangle(splinePoints[splinePoints.Count - 1].X, splinePoints[splinePoints.Count - 1].Y, polyWidthHeight, polyWidthHeight));
                        break;
                    case Mode.Triangle:
                        g.DrawPolygon(pen, CalculateVertices(3, polyWidthHeight, 90, center));
                        break;
                    case Mode.Line:
                        break;
                    case Mode.Spline:
                        break;
                    default:
                        break;
                }

                canPaint = false;

                prevX = null;
                prevY = null;

                temporalScreenShot = MakeScreenshot(board1);

            }

            polyWidthHeight = 10;

        }

        List<Point> splinePoints = new List<Point>();

        private void DrawingMouseMove(object sender, MouseEventArgs e)
        {
            polyWidthHeight += 2;

            g = board1.CreateGraphics();

            Pen pen = new Pen(penColor, penSize);

            if ((e.Button & MouseButtons.Left) != 0)
            {
                if (canPaint)
                {

                    switch (Drawing)
                    {
                        case Mode.FreeForm:
                            g.DrawLine(pen, new Point(prevX ?? e.X, prevY ?? e.Y), new Point(e.X, e.Y));
                            break;
                        case Mode.Rectangle:
                            break;
                        case Mode.Circle:
                            break;
                        case Mode.Triangle:
                            break;
                        case Mode.Line:
                            break;
                        case Mode.Spline:
                            //g.DrawCurve(pen, splinePoints.ToArray());

                            break;
                        default:
                            break;
                    }

                    prevX = e.X;
                    prevY = e.Y;

                }
            }

        }

        private void DrawingMouseClick(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(penColor, penSize);

            //g = board1.CreateGraphics();

            if ((e.Button & MouseButtons.Right) != 0)
            {
                if (!canPaint)
                {
                    changeSizeColorPanel.Location = new Point(e.X, e.Y);
                    changeSizeColorPanel.Visible = true;                    
                    this.board1.Controls.Add(changeSizeColorPanel);

                }
            }

            if ((e.Button & MouseButtons.Left) != 0)
            {
                if (canPaint)
                {

                    changeSizeColorPanel.Visible = false;
                    this.board1.Controls.Remove(changeSizeColorPanel);

                    switch (Drawing)
                    {

                        case Mode.Line:
                            g.DrawLine(pen, splinePoints[splinePoints.Count - 1], new Point(e.X, e.Y));
                            break;
                        case Mode.Spline:
                            g.DrawCurve(pen, new Point[] { splinePoints[splinePoints.Count - 1], new Point(e.X, e.Y) });
                            g.DrawCurve(pen, splinePoints.ToArray());
                            break;
                        case Mode.FreeForm:
                            break;
                        case Mode.Rectangle:
                            //g.DrawRectangle(pen, new Rectangle(splinePoints[splinePoints.Count - 1].X, splinePoints[splinePoints.Count - 1].Y, polyWidthHeight, polyWidthHeight));
                            break;
                        case Mode.Circle:
                            break;
                        case Mode.Triangle:
                            break;
                        default:
                            break;
                    }


                }
            }

            if ((e.Button & MouseButtons.Middle) != 0)
            {
                penColor = board1.BackColor;
                penSize = (float)penSizeNumBtn.Value;
            }
        }

        #endregion

        #region Custom Context Menu Strip

        private void ChangeSizeColorPanel()
        {
            changeSizeColorPanel.AllowTransparency = true;
            changeSizeColorPanel.BackColor = System.Drawing.Color.Transparent;
            changeSizeColorPanel.Border = 1F;
            changeSizeColorPanel.BorderColor = System.Drawing.Color.DodgerBlue;
            changeSizeColorPanel.Controls.Add(this.newPage);
            changeSizeColorPanel.Controls.Add(this.label2);
            changeSizeColorPanel.Controls.Add(this.brushSizeNumBtn);
            changeSizeColorPanel.Controls.Add(this.label1);
            changeSizeColorPanel.Controls.Add(this.penSizeNumBtn);
            changeSizeColorPanel.Controls.Add(this.canvasColorBtn);
            changeSizeColorPanel.Controls.Add(this.penColorBtn);            
            changeSizeColorPanel.Corners = 5F;
            changeSizeColorPanel.Location = new System.Drawing.Point(466, 235);
            changeSizeColorPanel.Name = "changeSizeColorPanel";
            changeSizeColorPanel.Size = new System.Drawing.Size(210, 141);
            changeSizeColorPanel.TabIndex = 0;
            changeSizeColorPanel.Visible = false;
            changeSizeColorPanel.SuspendLayout();
            changeSizeColorPanel.ResumeLayout(false);
            changeSizeColorPanel.PerformLayout();

        }

        #endregion

        #region Clear Board
        private void Clear(PictureBox board)
        {
            g.Clear(board.BackColor);
            //board.BackColor = Color.Transparent;
            board.Image = null;
            board.Invalidate();

            temporalScreenShot = null;

            if (fullScreenMode != null)
            {
                g.Clear(fullScreenMode.mainBoard.BackColor);
                fullScreenMode.mainBoard.Image = null;
                fullScreenMode.mainBoard.Invalidate();
            }
        }
        #endregion

        #region Pen Color
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                penColor = colorDialog.Color;
            }
        }

        private void penColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                penColor = colorDialog.Color;
            }
        }
        #endregion

        #region Canvas Color
        private void canvasColorBtn_Click(object sender, EventArgs e)
        {

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                board1.BackColor = colorDialog.Color;

            }

        }
        #endregion

        #region Redundant
        private void newPage_Click(object sender, EventArgs e)
        {
            Clear(board1);

            changeSizeColorPanel.Visible = false;
        }
        #endregion

        #region Add Page

        private void board1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                AddPage();

            }
            

            if ((e.Button & MouseButtons.Middle) != 0)
            {
                penColor = Color.Cyan;
                penSize = (float)brushSizeNumBtn.Value;
            }
        }


        private void AddPage()
        {
            screenShotImages.Add(MakeScreenshot(board1));
                  
            if (selectedIndex < pages.Count - 2)
            {
                pages[pages.Count - 1].Tag = "Picture Added";
                pages[selectedIndex].Image = screenShotImages[screenShotImages.Count - 1];
                pages[pages.Count - 1].SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.BackColor = Color.Transparent;
                pictureBox.BorderStyle = BorderStyle.FixedSingle;
                pictureBox.Image = Properties.Resources.plus;
                pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBox.Size = firstViewer.Size;
                pictureBox.Location = new Point(pages[pages.Count - 1].Location.X, pages[pages.Count - 1].Location.Y + pages[pages.Count - 1].Height + 20);
                pictureBox.Name = string.Format("pictureBox{0}", tag);
                pictureBox.Tag = "No Picture";

                if(fullScreen)
                {
                    pages[pages.Count - 1].Tag = "Picture Added Full Screen";
                }
                else
                {
                    pages[pages.Count - 1].Tag = "Picture Added";
                }
                
                pages[pages.Count - 1].Image = screenShotImages[screenShotImages.Count - 1];
                pages[pages.Count - 1].SizeMode = PictureBoxSizeMode.Zoom;
                pages[pages.Count - 1].Visible = true;
                
                if(rightScreenShotPanel.Controls == null)
                {
                    pages[pages.Count - 1].Location = new Point(3, 0);
                }

                pages.Add(pictureBox);
                rightScreenShotPanel.Controls.Add(pictureBox);

                #region Numbering

                Label label = new Label();

                label.AutoSize = true;
                label.Font = new Font("Verdana", 7);
                label.ForeColor = Color.White;
                label.Text = (numbering.Count+1).ToString();
                Graphics g = CreateGraphics();
                SizeF fs = g.MeasureString(label.Text, label.Font);
                label.Location = new Point(pages[pages.Count - 1].Location.X + (rightScreenShotPanel.Width / 2) - (int)(fs.Width / 2) - 5, pages[pages.Count - 1].Location.Y + pages[pages.Count - 1].Height);
                label.Visible = false;
                rightScreenShotPanel.Controls.Add(label);

                numbering[numbering.Count - 1].Visible = true;
                numbering.Add(label);

                #endregion
                
                for (int i = 0; i < pages.Count; i++)
                {
                    pictureBox.MouseHover += ViewerMouseHover;
                    pictureBox.MouseLeave += ViewerMouseLeave;
                    pictureBox.MouseClick += ViewerMouseClick;

                    firstViewer.MouseHover += ViewerMouseHover;
                    firstViewer.MouseLeave += ViewerMouseLeave;
                    firstViewer.MouseClick += ViewerMouseClick;
                }

                tag++;

            }
            
            if (firstViewer.Image == null)
            {
                firstViewer.Image = screenShotImages[0];
            }

            #region Clear

            Clear(board1);

            if (fullScreenMode != null)
            {
                Clear(fullScreenMode.mainBoard);
            } 

            #endregion
            
            selectedIndex = pages.Count - 1;
        }

        #endregion

        #region Viewers Mouse Movement

        private void ViewerMouseHover(object sender, EventArgs e)
        {
            #region Old Code
            //foreach(PictureBox picbox in pages)
            //{
            //    if (picbox.Name == string.Format("pictureBox{0}", tag))
            //    {
            //        picbox.Size = new Size(200, 125);

            //    }
            //}

            //for (int i = 0; i < pages.Count; i++)
            //{

            //    if ((string)pages[i].Name == string.Format("pictureBox{0}",i))
            //    {
            //        pages[i].Size = new Size(200, 125);

            //    }
            //} 
            #endregion

            PictureBox currentPictureBox = (PictureBox)sender;

            currentPictureBox.Size = new Size(218, 125);

        }

        private void ViewerMouseLeave(object sender, EventArgs e)
        {

            #region Old Code
            //for (int i = 0; i < pages.Count; i++)
            //{

            //    if ((string)pages[i].Name == string.Format("pictureBox{0}", i))
            //    {
            //        pages[i].Size = new Size(185, 122);

            //    }
            //}
            #endregion

            PictureBox currentPictureBox = (PictureBox)sender;

            currentPictureBox.Size = new Size(215, 122);

            if (currentPictureBox.Image == null)
            {

                currentPictureBox.Image = Properties.Resources.plus;
            }

        }



        private void ViewerMouseClick(object sender, MouseEventArgs e)
        {
            PictureBox currentPictureBox = (PictureBox)sender;

            currentPictureBox.ContextMenuStrip = boardsCtxtMenuStrip;

            selectedIndex = pages.IndexOf(currentPictureBox);

            if (currentPictureBox.Tag.Equals("Picture Added"))
            {

                board1.Image = currentPictureBox.Image;
            }
            else if(currentPictureBox.Tag.Equals("Picture Added Full Screen"))
            {
                board1.SizeMode = PictureBoxSizeMode.AutoSize;

                board1.Image = currentPictureBox.Image;
            }
            else
            {
                //Do
            }

        }
        

        #endregion

        #region Full Screen Mode

        private FullScreenMode fullScreenMode;

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fullScreen = true;

            Bitmap notMaximizedScreenshot = MakeScreenshot(board1);

            this.Hide();

            fullScreenMode = new FullScreenMode(notMaximizedScreenshot);

            fullScreenMode.mainBoard.MouseMove += MainBoard_MouseMove;
            fullScreenMode.mainBoard.MouseDoubleClick += FullScreenMode_MouseDoubleClick;

            if (fullScreenMode.ShowDialog() == DialogResult.OK)
            {

                board1.Image = fullScreenMode.ScreenShot;
                board1.SizeMode = PictureBoxSizeMode.Zoom;

                fullScreenMode.Hide();
                this.Show();

                fullScreen = false;
            }


        }

        private void FullScreenMode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                AddPage();

            }

            if ((e.Button & MouseButtons.Middle) != 0)
            {
                penColor = Color.Cyan;
                penSize = (float)brushSizeNumBtn.Value;
            }
        }

        private void MainBoard_MouseMove(object sender, MouseEventArgs e)
        {

        }



        #endregion

        #region Polygon

        /// <summary>
        /// Return an array of 10 points to be used in a Draw- or FillPolygon method
        /// </summary>
        /// <param name="sides">The sides.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="startingAngle">The starting angle.</param>
        /// <param name="center">The center.</param>
        /// <returns>Array of 10 PointF structures</returns>
        /// <exception cref="System.ArgumentException">Polygon must have 3 sides or more.</exception>
        public static Point[] CalculateVertices(int sides, int radius, int startingAngle, Point center)
        {


            if (sides < 3)
                throw new ArgumentException("Polygon must have 3 sides or more.");

            List<Point> points = new List<Point>();
            float step = 360.0f / sides;

            float angle = startingAngle; //starting angle
            for (double i = startingAngle; i < startingAngle + 360.0; i += step) //go in a circle
            {
                points.Add(DegreesToXY(angle, radius, center));
                angle += step;
            }

            return points.ToArray();
        }

        /// <summary>
        /// Degreeses to xy.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="origin">The origin.</param>
        /// <returns>Point.</returns>
        public static Point DegreesToXY(float degrees, float radius, Point origin)
        {
            Point xy = new Point();
            double radians = degrees * Math.PI / 180.0;

            xy.X = (int)(Math.Cos(radians) * radius + origin.X);
            xy.Y = (int)(Math.Sin(-radians) * radius + origin.Y);

            return xy;
        }


        #endregion

        #region Pen and Canvas Color
        private void colorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                board1.BackColor = colorDialog.Color;
                canvasColorBelow.BackColor = colorDialog.Color;
                canvasColorBtn.BackColor = colorDialog.Color;

                if (fullScreenMode != null)
                {
                    fullScreenMode.mainBoard.BackColor = colorDialog.Color;
                }
            }
        }

        private void penColorSmallBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                penColor = colorDialog.Color;
                penColorBelow.BackColor = colorDialog.Color;

                penColorBtn.BackColor = colorDialog.Color;
            }
        }

        private void canvasColorSmallBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                board1.BackColor = colorDialog.Color;
                canvasColorBelow.BackColor = colorDialog.Color;
                canvasColorBtn.BackColor = colorDialog.Color;

                if (fullScreenMode != null)
                {
                    fullScreenMode.mainBoard.BackColor = colorDialog.Color;
                }
            }
        }

        #endregion

        #region Pen and Eraser Size

        private void penSizeSmallNum_ValueChanged(object sender, EventArgs e)
        {
            penSize = (int)penSizeSmallNum.Value;
            penSizeNumBtn.Value = penSizeSmallNum.Value;
        }

        private void brushSizeSmallNum_ValueChanged(object sender, EventArgs e)
        {
            penSize = (float)brushSizeSmallNum.Value;

            brushSizeNumBtn.Value = brushSizeSmallNum.Value;

            imageList1.ImageSize = new Size((int)penSize, (int)penSize);

            imageList1.Images.Clear();

            imageList1.Images.Add(Properties.Resources.eraser_100);
            
            Cursor = CreateCursor((Bitmap)imageList1.Images[0], imageList1.ImageSize);

            #region Old Code
            
            //if (brushSizeSmallNum.Value > 0 && brushSizeSmallNum.Value < 11)
            //{

            //    imageList1.ImageSize = new Size(10, 10);

            //    Cursor = CreateCursor((Bitmap)imageList1.Images[0], imageList1.ImageSize);
            //}
            //else if(brushSizeSmallNum.Value > 10 && brushSizeSmallNum.Value < 21)
            //{
            //    imageList1.ImageSize = new Size(20, 20);

            //    Cursor = CreateCursor((Bitmap)imageList1.Images[0], imageList1.ImageSize);
            //}
            //else if (brushSizeSmallNum.Value > 20 && brushSizeSmallNum.Value < 31)
            //{
            //    imageList1.ImageSize = new Size(30, 30);

            //    Cursor = CreateCursor((Bitmap)imageList1.Images[2], imageList1.ImageSize);
            //}
            //else if (brushSizeSmallNum.Value > 30 && brushSizeSmallNum.Value < 41)
            //{
            //    Cursor = CreateCursor((Bitmap)imageList1.Images[3], imageList1.Images[3].Size);
            //}
            //else if (brushSizeSmallNum.Value > 40 && brushSizeSmallNum.Value < 51)
            //{
            //    Cursor = CreateCursor((Bitmap)imageList1.Images[4], imageList1.Images[4].Size);
            //} 
            #endregion

        }

        #endregion

        #region Left Toolbox

        private void eraserBtn_Click(object sender, EventArgs e)
        {
            eraser = true;

            //Drawing = Mode.FreeForm;

            imageList1.ImageSize = new Size((int)brushSizeSmallNum.Value + 16, (int)brushSizeSmallNum.Value + 16);

            imageList1.Images.Clear();
            imageList1.Images.Add(Properties.Resources.eraser_100);
            //imageList1.Images[0] = Properties.Resources.eraser_100;

            Cursor = CreateCursor((Bitmap)imageList1.Images[0], imageList1.ImageSize);


            penColor = board1.BackColor;
            penSize = (float)brushSizeSmallNum.Value;

            board1.Image = temporalScreenShot;
            board1.SizeMode = PictureBoxSizeMode.Zoom;

            if (fullScreenMode != null)
            {
                fullScreenMode.mainBoard.Image = temporalScreenShot;
                fullScreenMode.mainBoard.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void penBtn_Click(object sender, EventArgs e)
        {
            eraser = false;

            imageList1.ImageSize = new Size(16, 16);
            imageList1.Images.Clear();
            imageList1.Images.Add(Properties.Resources.pen);
            Cursor = CreateCursor((Bitmap)imageList1.Images[0], imageList1.ImageSize);

            Drawing = Mode.FreeForm;
            penColor = penColorBelow.BackColor;
            penSize = (float)penSizeSmallNum.Value;

            board1.Image = temporalScreenShot;
            board1.SizeMode = PictureBoxSizeMode.Zoom;

            if (fullScreenMode != null)
            {
                fullScreenMode.mainBoard.Image = temporalScreenShot;
                fullScreenMode.mainBoard.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void rectangleBtn_Click(object sender, EventArgs e)
        {
            Drawing = Mode.Rectangle;

            board1.Image = temporalScreenShot;
            board1.SizeMode = PictureBoxSizeMode.Zoom;

            if (fullScreenMode != null)
            {
                fullScreenMode.mainBoard.Image = temporalScreenShot;
                fullScreenMode.mainBoard.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void circleBtn_Click(object sender, EventArgs e)
        {
            Drawing = Mode.Circle;

            board1.Image = temporalScreenShot;
            board1.SizeMode = PictureBoxSizeMode.Zoom;

            if (fullScreenMode != null)
            {
                fullScreenMode.mainBoard.Image = temporalScreenShot;
                fullScreenMode.mainBoard.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void triangleBtn_Click(object sender, EventArgs e)
        {
            Drawing = Mode.Triangle;

            board1.Image = temporalScreenShot;
            board1.SizeMode = PictureBoxSizeMode.Zoom;

            if (fullScreenMode != null)
            {
                fullScreenMode.mainBoard.Image = temporalScreenShot;
                fullScreenMode.mainBoard.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void lineBtn_Click(object sender, EventArgs e)
        {
            Drawing = Mode.Line;

            board1.Image = temporalScreenShot;
            board1.SizeMode = PictureBoxSizeMode.Zoom;

            if (fullScreenMode != null)
            {
                fullScreenMode.mainBoard.Image = temporalScreenShot;
                fullScreenMode.mainBoard.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void splineBtn_Click(object sender, EventArgs e)
        {
            Drawing = Mode.Spline;

            board1.Image = temporalScreenShot;
            board1.SizeMode = PictureBoxSizeMode.Zoom;

            if (fullScreenMode != null)
            {
                fullScreenMode.mainBoard.Image = temporalScreenShot;
                fullScreenMode.mainBoard.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        #endregion

        #region Save

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageCodes.Clear();

            for (int i = 0; i < pages.Count; i++)
            {
                imageCodes.Add(ImageToCodeToImage.ImageToCode((Bitmap)pages[i].Image));

            }

            if (File.Exists(path))
            {
                #region Test Code
                ////Create object of FileInfo for specified path            
                //FileInfo fi = new FileInfo(path);

                ////Open file for Read\Write
                //FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);

                ////Create object of StreamReader by passing FileStream object on which it needs to operates on
                //StreamReader sr = new StreamReader(fs);

                ////Use ReadToEnd method to read all the content from file

                //string fileContent = sr.ReadToEnd();

                ////Close StreamReader object after operation
                //sr.Close();
                //fs.Close(); 
                #endregion

                XmlTextWriter xmlwriter = new XmlTextWriter(path, Encoding.UTF8);
                xmlwriter.Formatting = Formatting.Indented;
                xmlwriter.WriteStartElement("Boards");

                for (int i = 0; i < imageCodes.Count; i++)
                {
                    xmlwriter.WriteStartElement("Board");

                    xmlwriter.WriteStartElement("Position");
                    xmlwriter.WriteString((i + 1).ToString());
                    xmlwriter.WriteEndElement();

                    xmlwriter.WriteStartElement("Value");
                    xmlwriter.WriteString(imageCodes[i]);
                    xmlwriter.WriteEndElement();

                    xmlwriter.WriteEndElement();

                }
                                
                xmlwriter.WriteEndElement();
                xmlwriter.Close();
                
            }
            else
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XmlTextWriter xmlwriter = new XmlTextWriter(saveFileDialog.FileName, Encoding.UTF8);
                    xmlwriter.Formatting = Formatting.Indented;
                    xmlwriter.WriteStartElement("Boards");

                    for (int i = 0; i < imageCodes.Count; i++)
                    {
                        xmlwriter.WriteStartElement("Board");

                        xmlwriter.WriteStartElement("Position");
                        xmlwriter.WriteString((i + 1).ToString());
                        xmlwriter.WriteEndElement();

                        xmlwriter.WriteStartElement("Value");
                        xmlwriter.WriteString(imageCodes[i]);
                        xmlwriter.WriteEndElement();

                        xmlwriter.WriteEndElement();

                    }

                    #region Working
                    //foreach (string item in imageCodes)
                    //{
                    //    xmlwriter.WriteStartElement("Image");

                    //    xmlwriter.WriteStartElement("Name");
                    //    xmlwriter.WriteString(imageCodes.Count);
                    //    xmlwriter.WriteEndElement();

                    //    xmlwriter.WriteStartElement("RGB");
                    //    xmlwriter.WriteString(item.SubItems[1].Text);
                    //    xmlwriter.WriteEndElement();

                    //    xmlwriter.WriteStartElement("HTML");
                    //    xmlwriter.WriteString(item.SubItems[2].Text);
                    //    xmlwriter.WriteEndElement();

                    //    xmlwriter.WriteStartElement("HSL");
                    //    xmlwriter.WriteString(item.SubItems[3].Text);
                    //    xmlwriter.WriteEndElement();

                    //    xmlwriter.WriteStartElement("HSV");
                    //    xmlwriter.WriteString(item.SubItems[4].Text);
                    //    xmlwriter.WriteEndElement();

                    //    xmlwriter.WriteStartElement("CMYK");
                    //    xmlwriter.WriteString(item.SubItems[5].Text);
                    //    xmlwriter.WriteEndElement();

                    //    xmlwriter.WriteStartElement("XYZ");
                    //    xmlwriter.WriteString(item.SubItems[6].Text);
                    //    xmlwriter.WriteEndElement();

                    //    xmlwriter.WriteStartElement("Lab");
                    //    xmlwriter.WriteString(item.SubItems[7].Text);
                    //    xmlwriter.WriteEndElement();

                    //    xmlwriter.WriteEndElement();

                    //} 
                    #endregion

                    xmlwriter.WriteEndElement();
                    xmlwriter.Close();
                }

            }
            

        }

        #endregion

        #region Open

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                 
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(openFileDialog.FileName);

                pages.Clear();
                numbering.Clear();
                firstViewer.Image = null;

                #region Numbering

                //for (int n = 1; n < numbering.Count; n++)
                //{
                //    numbering.RemoveAt(n);
                //}

                #region First Viewer Label

                Label label = new Label();

                label.AutoSize = true;
                label.Font = new Font("Verdana", 7);
                label.ForeColor = Color.White;
                label.Text = (numbering.Count).ToString();
                Graphics g = CreateGraphics();
                SizeF fs = g.MeasureString(label.Text, label.Font);
                label.Location = new Point(firstViewer.Location.X + (rightScreenShotPanel.Width / 2) - (int)(fs.Width / 2) - 5, firstViewer.Location.Y + firstViewer.Height);
                label.Text = "1";
                label.Visible = true;
                rightScreenShotPanel.Controls.Add(label);

                #endregion

                #endregion

                for (int i = 1; i < rightScreenShotPanel.Controls.Count; i++)
                {
                    rightScreenShotPanel.Controls.RemoveAt(i);
                }


                firstViewer.SizeMode = PictureBoxSizeMode.Zoom;
                firstViewer.Image = ImageToCodeToImage.CodeToImage(xdoc.SelectNodes("Boards/Board")[0].SelectSingleNode("Value").InnerText);
                firstViewer.Tag = "Picture Added";
                
                pages.Add(firstViewer);

                #region Working Code
                //foreach (XmlNode node in xdoc.SelectNodes("Boards/Board"))
                //{

                //    string[] row = new string[]
                //    {
                //        node.SelectSingleNode("Position").InnerText,
                //        node.SelectSingleNode("Value").InnerText
                //    };

                //    pages.Add(new PictureBox()
                //    {
                //        SizeMode = PictureBoxSizeMode.Zoom,
                //        Image = ImageToCodeToImage.CodeToImage(row[1]),
                //        BackColor = Color.Transparent,
                //        BorderStyle = BorderStyle.FixedSingle,
                //        Size = new Size(215, 122),
                //        Location = new Point(locX, locY + height + 20),
                //        Tag = "Picture Added",
                //        Name = string.Format("pictureBox{0}", tag)
                //    });

                //    rightScreenShotPanel.Controls.Add((pages[pages.Count - 1]));

                //} 
                #endregion

                for (int i = 1; i < xdoc.SelectNodes("Boards/Board").Count; i++)
                {
                    XmlNode node = xdoc.SelectNodes("Boards/Board")[i];

                    string[] row = new string[]
                    {
                        node.SelectSingleNode("Position").InnerText,
                        node.SelectSingleNode("Value").InnerText
                    };

                    pages.Add(new PictureBox()
                    {
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Image = ImageToCodeToImage.CodeToImage(row[1]),
                        BackColor = Color.Transparent,
                        BorderStyle = BorderStyle.FixedSingle,
                        Size = new Size(215, 122),
                        Location = new Point(pages[pages.Count - 1].Location.X, pages[pages.Count - 1].Location.Y + pages[pages.Count - 1].Height + 20),
                        Tag = "Picture Added",
                        Name = string.Format("pictureBox{0}", tag)
                    });

                    numbering.Add(new Label()
                    {
                        AutoSize = true,
                        Font = new Font("Verdana", 7),
                        ForeColor = Color.White,
                        Text = (i+1).ToString(),
                        Location = new Point(pages[pages.Count - 1].Location.X + (rightScreenShotPanel.Width / 2) - 5, pages[pages.Count - 1].Location.Y + pages[pages.Count - 1].Height),
                        Visible = true

                    });

                    rightScreenShotPanel.Controls.Add((numbering[numbering.Count - 1]));

                    rightScreenShotPanel.Controls.Add((pages[pages.Count - 1]));


                }

                pages[pages.Count - 1].SizeMode = PictureBoxSizeMode.CenterImage;
                pages[pages.Count - 1].Image = Properties.Resources.plus;
                pages[pages.Count - 1].Tag = "No Picture Added";

                for (int i = 0; i < pages.Count; i++)
                {
                    pages[i].MouseHover += ViewerMouseHover;
                    pages[i].MouseLeave += ViewerMouseLeave;
                    pages[i].MouseClick += ViewerMouseClick;
                }

                selectedIndex = pages.Count - 1;
            }
        }

        #endregion

        #region ToolStrip Items

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (File.Exists(openFileDialog.FileName))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(openFileDialog.FileName);

                foreach (XmlNode node in doc.SelectNodes("Boards/Board"))
                {

                    try
                    {
                        if (node.SelectSingleNode("Positions").InnerText == imageCodes[selectedIndex])
                        {
                            node.ParentNode.RemoveChild(node);
                        }
                    }
                    catch (System.NullReferenceException exception)
                    {

                        MessageBox.Show("Board Cannot Be Deleted","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

                doc.Save(openFileDialog.FileName);
            }

            int currentPicBoxIndex = rightScreenShotPanel.Controls.IndexOf(pages[selectedIndex]);
            int numberingIndex = rightScreenShotPanel.Controls.IndexOf(numbering[selectedIndex]);

            rightScreenShotPanel.Controls.RemoveAt(currentPicBoxIndex);
            rightScreenShotPanel.Controls.RemoveAt(numberingIndex);

            pages.RemoveAt(selectedIndex);
            numbering.RemoveAt(selectedIndex);

            if (firstViewer != null)
            {
                for (int i = 1; i < pages.Count; i++)
                {

                    pages[i].Location = new Point(pages[i].Location.X, pages[i].Location.Y - height - 20);

                    numbering[i].Location = new Point(numbering[i].Location.X, numbering[i].Location.Y - height - 20);

                    numbering[i].Text = (i + 1).ToString();
                }
            }

        }

        private void clearAllBoardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pages.Clear();
            numbering.Clear();

            firstViewer.Image = null;
            firstViewer.Invalidate();
            firstViewer.Tag = "No Picture";


            rightScreenShotPanel.Controls.Clear();
            rightScreenShotPanel.Controls.Add(firstViewer);

            pages.Add(firstViewer);

            numbering.Add(new Label());


        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pages.Clear();
            numbering.Clear();

            firstViewer.Image = null;
            firstViewer.Invalidate();
            firstViewer.Tag = "No Picture";


            rightScreenShotPanel.Controls.Clear();
            rightScreenShotPanel.Controls.Add(firstViewer);

            pages.Add(firstViewer);

            numbering.Add(new Label());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();

            ZeroitBlurControl blur = new ZeroitBlurControl();

            blur.Target = this;

            blur.RenderBlur();

            if (about.ShowDialog() == DialogResult.OK)
            {
                blur.UnBlur();

            }
        }

        #endregion

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.DefaultExt = "xml";

            for (int i = 0; i < pages.Count; i++)
            {
                imageCodes.Add(ImageToCodeToImage.ImageToCode((Bitmap)pages[i].Image));

            }


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlTextWriter xmlwriter = new XmlTextWriter(saveFileDialog.FileName, Encoding.UTF8);
                xmlwriter.Formatting = Formatting.Indented;
                xmlwriter.WriteStartElement("Boards");

                for (int i = 0; i < imageCodes.Count; i++)
                {
                    xmlwriter.WriteStartElement("Board");

                    xmlwriter.WriteStartElement("Position");
                    xmlwriter.WriteString((i + 1).ToString());
                    xmlwriter.WriteEndElement();

                    xmlwriter.WriteStartElement("Value");
                    xmlwriter.WriteString(imageCodes[i]);
                    xmlwriter.WriteEndElement();

                    xmlwriter.WriteEndElement();

                }

                xmlwriter.WriteEndElement();
                xmlwriter.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rightShiftBtn_Click(object sender, EventArgs e)
        {
            shiftRight = !shiftRight;

            if(shiftRight)
            {
                rightScreenShotPanel.Visible = false;

                if (shiftLeft)
                {
                    panelContainer.Width = 1239;
                }
                else
                {
                    panelContainer.Width = 1185;
                }
                
            }
            else
            {
                rightScreenShotPanel.Visible = true;

                if (shiftLeft)
                {
                    panelContainer.Width = 982;
                }
                else
                {
                    panelContainer.Width = 928;
                }
                
            }

            
        }

        private void leftShiftBtn_Click(object sender, EventArgs e)
        {
            shiftLeft = !shiftLeft;

            if(shiftLeft)
            {
                panelContainer.Location = new Point(3, 78);
                panelContainer.Width = 982;
            }
            else
            {
                panelContainer.Location = new Point(60, 78);
                panelContainer.Width = 928;
            }
        }

        private void blackBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            board1.BackColor = Color.Black;

            changeSizeColorPanel.BackColor = Color.Black;
        }

        private void whiteBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            board1.BackColor = Color.White;
            penColor = Color.Black;

            changeSizeColorPanel.BackColor = Color.Black;
        }

        private static Cursor CreateCursor(Bitmap bmp, Size size)
        {
            bmp = new Bitmap(bmp, size);
            bmp.MakeTransparent();

            return new Cursor(bmp.GetHicon());
        }

        private void board1_MouseEnter(object sender, EventArgs e)
        {
            if(eraser)
            {
                imageList1.ImageSize = new Size((int)brushSizeSmallNum.Value + 16, (int)brushSizeSmallNum.Value + 16);
                imageList1.Images.Clear();
                imageList1.Images.Add(Properties.Resources.eraser_100);
                Cursor = CreateCursor((Bitmap)imageList1.Images[0], imageList1.ImageSize);

            }
            else
            {
                imageList1.ImageSize = new Size(16, 16);
                imageList1.Images.Clear();
                imageList1.Images.Add(Properties.Resources.pen);
                Cursor = CreateCursor((Bitmap)imageList1.Images[0], imageList1.ImageSize);

            }
        }

        private void board1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            splash.Form = this;
            splash.BringToFront();
            splash.Show();
            this.SendToBack();
        }

        private void CenterForm(Form form)
        {
            form.Location = new Point(this.Location.X + (form.Width / 2), this.Location.Y + (form.Height / 5));

        }

        private void CenterScreen(Form form)
        {
            form.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (form.Width / 2), (Screen.PrimaryScreen.Bounds.Height / 2) - (form.Height / 2));

        }




    }
}
