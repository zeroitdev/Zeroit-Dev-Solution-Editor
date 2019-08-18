using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ZeroitDevSolutionEditor
{
    
    public partial class Form2 : Form
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

        private bool maximized = false;

        TransparentPanel changeSizeColorPanel = new ZeroitDevSolutionEditor.TransparentPanel();

        int tag = 0;
        #endregion

        #region Constructor
        public Form2()
        {
            InitializeComponent();

            ChangeSizeColorPanel();

            g = board1.CreateGraphics();
            g.SmoothingMode = SmoothingMode.HighQuality;

            foreach (PictureBox viewers in rightScreenShotPanel.Controls)
            {
                pages.Add(viewers);
            }
            
            MessageBox.Show(string.Format("Form \nWidth : {0} \nHeight : {1} \nContainer \nWidth : {2} \nHeight : {3}",
                Width, Height, panelContainer.Width, panelContainer.Height));



        }

        #endregion

        #region Events

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
            this.WindowState = FormWindowState.Maximized;

            Bitmap tempImage = MakeScreenshot(board1);

            maximized = !maximized;

            if (maximized)
            {
                panelContainer.Width = Convert.ToInt32(0.9732665f * Width);
                panelContainer.Height = Convert.ToInt32(0.89948454 * Height);

                board1.Image = tempImage;
                board1.SizeMode = PictureBoxSizeMode.Zoom;

                tempImage = MakeScreenshot(board1);

                baseTheme1.Sizable = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;

                panelContainer.Width = 1165;
                panelContainer.Height = 698;

                board1.Image = tempImage;
                board1.SizeMode = PictureBoxSizeMode.Zoom;

                baseTheme1.Sizable = false;
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

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                canPaint = true;
            }

        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                canPaint = false;

                prevX = null;
                prevY = null;
            }

        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            g = board1.CreateGraphics();

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

        private void MouseClick(object sender, MouseEventArgs e)
        {


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
            //changeSizeColorPanel.Controls.Add(this.newPage);
            changeSizeColorPanel.Controls.Add(this.label2);
            changeSizeColorPanel.Controls.Add(this.brushSizeNumBtn);
            changeSizeColorPanel.Controls.Add(this.label1);
            changeSizeColorPanel.Controls.Add(this.penSizeNumBtn);
            changeSizeColorPanel.Controls.Add(this.canvasColorBtn);
            changeSizeColorPanel.Controls.Add(this.penColorBtn);
            changeSizeColorPanel.Corners = 5F;
            changeSizeColorPanel.Location = new System.Drawing.Point(466, 235);
            changeSizeColorPanel.Name = "changeSizeColorPanel";
            changeSizeColorPanel.Size = new System.Drawing.Size(210, 110);
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
        }
        #endregion
        
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
            AddPage();

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
            PictureBox pictureBox = new PictureBox();
            pictureBox.BackColor = firstViewer.BackColor;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Size = firstViewer.Size;
            pictureBox.Location = new Point(pages[pages.Count - 1].Location.X, pages[pages.Count - 1].Location.Y + pages[pages.Count - 1].Height + 20);
            pictureBox.Name = string.Format("pictureBox{0}", tag);

            
            pages[pages.Count - 1].Image = screenShotImages[screenShotImages.Count - 1];
            pages[pages.Count - 1].SizeMode = PictureBoxSizeMode.Zoom;

            rightScreenShotPanel.Controls.Add(pictureBox);
            pages.Add(pictureBox);


            #region ListBox Code
            //listBox1.Items.Add(string.Format("Page {0}", tag + 1)); 
            #endregion

            firstViewer.Image = screenShotImages[0];

            #region TestCode

            for (int i = 0; i < pages.Count; i++)
            {

                Label label = new Label();

                label.AutoSize = true;
                label.Font = new Font("Verdana", 7);
                label.ForeColor = Color.White;
                label.Text = (i+1).ToString();
                Graphics g = CreateGraphics();
                SizeF fs = g.MeasureString(label.Text, label.Font);

                label.Location = new Point(pages[i].Location.X + (rightScreenShotPanel.Width / 2) - (int)(fs.Width / 2) - 5, pages[i].Location.Y + pages[i].Height);

                rightScreenShotPanel.Controls.Add(label);
            }

            #endregion

            Clear(board1);
            tag++;

            for (int i = 0; i < pages.Count; i++)
            {
                pictureBox.MouseHover += ViewerMouseHover;
                pictureBox.MouseLeave += ViewerMouseLeave;
                pictureBox.MouseClick += ViewerMouseClick;

                firstViewer.MouseHover += ViewerMouseHover;
                firstViewer.MouseLeave += ViewerMouseLeave;
                firstViewer.MouseClick += ViewerMouseClick;
            }
            

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

            PictureBox currentPictureBox = (PictureBox) sender;

            currentPictureBox.Size = new Size(188, 125);

        }

        private void ViewerMouseLeave(object sender, EventArgs e)
        {

            #region Old Code
            for (int i = 0; i < pages.Count; i++)
            {

                if ((string)pages[i].Name == string.Format("pictureBox{0}", i))
                {
                    pages[i].Size = new Size(185, 122);

                }
            } 
            #endregion

            PictureBox currentPictureBox = (PictureBox)sender;

            currentPictureBox.Size = new Size(185, 122);

        }

        private void ViewerMouseClick(object sender, MouseEventArgs e)
        {
            PictureBox currentPictureBox = (PictureBox)sender;

            if (currentPictureBox.Image != null)
            {
                board1.Image = currentPictureBox.Image;
            }
            
        }

        #endregion

        #region ListBox Code
        //private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    board1.Image = pages[listBox1.SelectedIndex].Image;
        //    board1.SizeMode = PictureBoxSizeMode.Zoom;

        //    listBox1.BorderStyle = BorderStyle.FixedSingle;
        //}

        //private void listBox1_MouseEnter(object sender, EventArgs e)
        //{
        //    listBox1.BorderStyle = BorderStyle.FixedSingle;
        //}

        //private void listBox1_MouseLeave(object sender, EventArgs e)
        //{
        //    listBox1.BorderStyle = BorderStyle.FixedSingle;
        //}

        //private void listBox1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.KeyData == Keys.Delete)
        //    {
        //        listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        //        pages.RemoveAt(listBox1.SelectedIndex);
        //    }
        //} 
        #endregion

    }
}
