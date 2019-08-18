using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeroitDevSolutionEditor
{
    public partial class FullScreenMode : FormStyler
    {
        #region Private Fields
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

        Bitmap screenShotImage = null;

        private bool fullScreen = true;

        #endregion

        public bool FullScreen
        {
            get { return fullScreen; }
        }

        public Bitmap ScreenShot
        {
            get { return screenShotImage; }
        }

        public FullScreenMode()
        {
            InitializeComponent();
        }

        public FullScreenMode(Image image)
        {
            InitializeComponent();

            mainBoard.Image = image;
            mainBoard.SizeMode = PictureBoxSizeMode.Zoom;
            this.DrawBorder = false;
        }

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
                
        #region Clear Board
        private void Clear()
        {
            g.Clear(Color.Transparent);
            mainBoard.BackColor = Color.Transparent;
            mainBoard.Image = null;
            Invalidate();
        }
        #endregion
        
        #region Drawing

        private void DrawingMouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                canPaint = true;
            }

        }

        private void DrawingMouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                canPaint = false;

                prevX = null;
                prevY = null;

                screenShotImage = MakeScreenshot(mainBoard);

            }

        }

        private void DrawingMouseMove(object sender, MouseEventArgs e)
        {
            g = mainBoard.CreateGraphics();
            if ((e.Button & MouseButtons.Left) != 0)
            {
                if (canPaint)
                {

                    Pen pen = new Pen(penColor, penSize);

                    g.DrawLine(pen, new Point(prevX ?? e.X, prevY ?? e.Y), new Point(e.X, e.Y));

                    prevX = e.X;
                    prevY = e.Y;


                }
            }



        }
        
        #region Drawing on main form (To Be Used Later)
        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    if ((e.Button & MouseButtons.Left) != 0)
        //    {
        //        canPaint = true;
        //    }

        //}

        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    g = this.CreateGraphics();

        //    if ((e.Button & MouseButtons.Left) != 0)
        //    {
        //        if (canPaint)
        //        {

        //            Pen pen = new Pen(penColor, penSize);

        //            g.DrawLine(pen, new Point(prevX ?? e.X, prevY ?? e.Y), new Point(e.X, e.Y));

        //            prevX = e.X;
        //            prevY = e.Y;


        //        }
        //    }
        //}

        //protected override void OnMouseUp(MouseEventArgs e)
        //{
        //    if ((e.Button & MouseButtons.Left) != 0)
        //    {
        //        canPaint = false;

        //        prevX = null;
        //        prevY = null;
        //    }
        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{


        //    Graphics g = e.Graphics;
        //    g.SmoothingMode = SmoothingMode.HighQuality;

        //    DrawImage(g, Bounds);

        //    base.OnPaint(e);
        //}

        #endregion

        #endregion

        #region Image Designer

        #region Include in paint method

        ///////////////////////////////////////////////////////////////////////////////////////////////// 
        //                                                                                             //                                                                     
        //         ------------------------Add this to the Paint Method ------------------------       //
        //                                                                                             //
        // Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          //
        //                                                                                             //
        // PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   //
        //                                                                                             //
        // if ((Image == null))                                                                        //
        //     {                                                                                       //
        //         G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           //
        //             {                                                                               //
        //                 Alignment = _TextAlignment,                                                 //
        //                 LineAlignment = StringAlignment.Center                                      //
        //             });                                                                             //
        //      }                                                                                      //
        // else                                                                                        //
        //      {                                                                                      //
        //         G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              //
        //          G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          //
        //             {                                                                               //
        //                 Alignment = _TextAlignment,                                                 //
        //                 LineAlignment = StringAlignment.Center                                      //
        //             });                                                                             //
        //      }                                                                                      //
        //                                                                                             //
        /////////////////////////////////////////////////////////////////////////////////////////////////

        #endregion

        #region Include in Private Fields
        private Image _Image;
        private Size _ImageSize;
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleCenter;
        private StringAlignment _TextAlignment = StringAlignment.Center;
        private bool showText = false;
        #endregion

        #region Include in Public Properties
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }

                _Image = value;
                Invalidate();
            }
        }

        protected Size ImageSize
        {
            get { return _ImageSize; }
        }

        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

        public bool ShowText
        {
            get { return showText; }
            set
            {
                showText = value;
                Invalidate();
            }
        }

        public StringAlignment TextAlign
        {
            get { return _TextAlignment; }
            set
            {
                _TextAlignment = value;
                Invalidate();
            }
        }


        #endregion

        #region Include in Private Methods
        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            PointF MyPoint = default(PointF);
            switch (SF.Alignment)
            {
                case StringAlignment.Center:
                    MyPoint.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.X = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.X = Area.Width - ImageArea.Width - 2;
                    break;
            }

            switch (SF.LineAlignment)
            {
                case StringAlignment.Center:
                    MyPoint.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.Y = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.Y = Area.Height - ImageArea.Height - 2;
                    break;
            }
            return MyPoint;
        }

        private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
        {
            StringFormat SF = new StringFormat();
            switch (_ContentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.TopCenter:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopLeft:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Far;
                    break;
            }
            return SF;
        }

        private void DrawImage(Graphics G, Rectangle R1)
        {
            //Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          
            G.SmoothingMode = SmoothingMode.HighQuality;

            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);

            if ((Image == null))
            {
                if (ShowText)
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = _TextAlignment,
                        LineAlignment = StringAlignment.Center

                    });
            }
            else
            {
                G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);

                if (ShowText)
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = _TextAlignment,
                        LineAlignment = StringAlignment.Center
                    });
            }

        }





        #endregion

        #endregion

        private void exitFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            DialogResult = DialogResult.OK;

            fullScreen = false;
        }

        private void clearBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }



    }
}
