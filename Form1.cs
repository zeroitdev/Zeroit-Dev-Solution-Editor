using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ZeroitDevSolutionEditor
{
    
    public partial class Form1 : Form
    {
        #region Private Fields

        private bool canPaint = false;

        
        private Graphics g;

        private Color penColor = Color.Cyan;

        private float penSize = 1f;

        private int? prevX = null;

        private int? prevY = null;

        List<NoFlickerPanel> pages = new List<NoFlickerPanel>();
        
        
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();

            g = board1.CreateGraphics();

            
            foreach (NoFlickerPanel flickerPanel in panelContainer.Controls)
            {
                pages.Add(flickerPanel);
            }

            
        }
        
        #endregion

        #region Events

        #region Close
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } 
        #endregion

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            
        }

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
                }
            }


            if ((e.Button & MouseButtons.Left) != 0)
            {
                if (canPaint)
                {
                    
                    changeSizeColorPanel.Visible = false;

                    for (int i = 0; i < pages.Count; i++)
                    {
                        g = pages[i].CreateGraphics();

                    }
                }
            }
        }

        
        private void Clear(NoFlickerPanel board)
        {
            g.Clear(board.BackColor);
        }


        #endregion

        
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

        private void canvasColorBtn_Click(object sender, EventArgs e)
        {
            
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (NoFlickerPanel noFlickerPanel in panelContainer.Controls)
                {
                    noFlickerPanel.BackColor = colorDialog.Color;

                }
                
            }
            
        }

        
        private void newPage_Click(object sender, EventArgs e)
        {

            NoFlickerPanel newFlickerPanel = new NoFlickerPanel();
            newFlickerPanel.BackColor = board1.BackColor;
            newFlickerPanel.BorderStyle = BorderStyle.FixedSingle;
            newFlickerPanel.Size = board1.Size;
            newFlickerPanel.Location = new Point(pages[pages.Count - 1].Location.X, pages[pages.Count - 1].Location.Y + pages[pages.Count - 1].Height + 20);
            newFlickerPanel.Tag = "DrawingBord";
            newFlickerPanel.MouseDown += MouseDown;
            newFlickerPanel.MouseUp += MouseUp;
            newFlickerPanel.MouseMove += MouseMove;
            newFlickerPanel.MouseClick += MouseClick;
            panelContainer.Controls.Add(newFlickerPanel);
            pages.Add(newFlickerPanel);

            #region TestCode

            for (int i = 0; i < pages.Count; i++)
            {
                Label label = new Label();
                label.Font = new Font("Verdana",7);
                label.ForeColor = Color.White;
                label.Location = new Point(pages[i].Location.X + (panelContainer.Width/2) - 1, pages[i].Location.Y + pages[i].Height);
                label.Text = i.ToString();
                panelContainer.Controls.Add(label);
            }
            
            #endregion

            changeSizeColorPanel.Visible = false;

        }
    }
}
