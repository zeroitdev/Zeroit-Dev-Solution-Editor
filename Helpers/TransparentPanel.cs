// ***********************************************************************
// Assembly         : Zeroit Dev Color Picker
// Author           : ZEROIT
// Created          : 06-29-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 08-02-2019
// ***********************************************************************
// <copyright file="TransparentPanel.cs" company="Zeroit Dev Technologies">
//     Copyright ©  2019 Zeroit Dev Technologies. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ZeroitDevSolutionEditor.Helpers;

namespace ZeroitDevSolutionEditor
{
    public class TransparentPanel : Panel
    {
        private float border = 1;
        private Color borderColor = Color.Black;
        

        /// <summary>
        /// The radius
        /// </summary>
        private float radius = 1;

        

        public TransparentPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;

            
        }

        /// <summary>
        /// Gets or sets the corners.
        /// </summary>
        /// <value>The corners.</value>
        public float Corners
        {
            get { return radius; }
            set
            {
                radius = value;
                Invalidate();
            }
        }

        
        public float Border
        {
            get { return border; }
            set
            {
                border = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }


        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            Bitmap bitmap = new Bitmap(Width,Height, PixelFormat.Format32bppPArgb);
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (AllowTransparency)
            {
                MakeTransparent(this, g);
            }

            GraphicsPath  BG = DrawHelper.CreateRoundRect(1, 1, Width - 3, Height - 3, radius);

            
            //Region region = new Region(BG);
            
            g.DrawPath(new Pen(BorderColor, Border), BG);

            e.Graphics.DrawImage(bitmap,0,0);
        }

        #region Transparency


        #region Include in Paint

        private void TransInPaint(Graphics g)
        {
            if (AllowTransparency)
            {
                MakeTransparent(this, g);
            }
        }

        #endregion

        #region Include in Private Field

        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion

        #region Method

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion


        #endregion
        
        
    }
}
