using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ZeroitDevSolutionEditor.Helpers;

namespace ZeroitDevSolutionEditor
{
    public partial class FormStyler : Form
    {

        #region Enums

        public enum Drawing
        {
            Solid,
            Gradient,
            Hatch
        }

        #endregion

        #region Private Fields

        private HatchStyle hatchStyle = HatchStyle.Weave;

        private Color[] bordColors = { Color.FromArgb(28, 28, 28), Color.Black };

        private float radius = 1;

        private bool drawBorder = true;

        private bool controlAllCorners = false;

        private StringAlignment textAlignment = StringAlignment.Center;

        private Color borderColor = Color.Gray;

        /// <summary>
        /// The upper left curve
        /// </summary>
        private int upperLeftCurve = 10;

        /// <summary>
        /// The upper right curve
        /// </summary>
        private int upperRightCurve = 10;

        /// <summary>
        /// Down left curve
        /// </summary>
        private int downLeftCurve = 10;

        /// <summary>
        /// Down right curve
        /// </summary>
        private int downRightCurve = 10;

        /// <summary>
        /// The curve
        /// </summary>
        private int curve = 10;

        Point lastClick;

        /// <summary>
        /// The border width
        /// </summary>
        private float borderWidth = 1;

        private Drawing drawing = Drawing.Solid;

        LinearGradientMode gradientMode = LinearGradientMode.BackwardDiagonal;

        #endregion

        #region Public Properties

        public LinearGradientMode GradientMode
        {
            get { return gradientMode; }
            set
            {
                gradientMode = value;
                Invalidate();
            }
        }

        public Drawing DrawingMode
        {
            get { return drawing; }
            set
            {
                drawing = value;
                Invalidate();
            }
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

        public HatchStyle HatchStyle
        {
            get { return hatchStyle; }
            set
            {
                hatchStyle = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public new Color BackColor
        {
            get;
            set;
        }
        public Color[] BackColors
        {
            get { return bordColors; }
            set
            {
                bordColors = value;

                TransparencyKey = Color.FromArgb((int)(1.04 * value[0].R), (int)(1.04 * value[0].G), (int)(1.04 * value[0].B));

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public float BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                Invalidate();
            }
        }

        public bool DrawBorder
        {
            get { return drawBorder; }
            set
            {
                drawBorder = value;
                Invalidate();
            }
        }

        public bool ControlAllCorners
        {
            get { return controlAllCorners; }
            set
            {
                controlAllCorners = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the curve.
        /// </summary>
        /// <value>The curve.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Value must be more than 1</exception>
        [Category("Rounded Rectangle Control")]
        public int CurveAll
        {
            get { return curve; }
            set
            {
                if (value > 0)
                {
                    upperLeftCurve = value;
                    upperRightCurve = value;
                    downLeftCurve = value;
                    downRightCurve = value;
                }

                if (value < 1)
                {
                    value = 1;
                    throw new ArgumentOutOfRangeException("", "Value must be more than 1");
                }

                curve = value;

            }
        }

        /// <summary>
        /// Gets or sets the upper left curve.
        /// </summary>
        /// <value>The upper left curve.</value>
        public int CurveUpperLeft
        {
            get { return upperLeftCurve; }
            set
            {
                upperLeftCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the upper right curve.
        /// </summary>
        /// <value>The upper right curve.</value>
        [Category("Rounded Rectangle Control")]
        public int CurveUpperRight
        {
            get { return upperRightCurve; }
            set
            {
                upperRightCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets down left curve.
        /// </summary>
        /// <value>Down left curve.</value>
        [Category("Rounded Rectangle Control")]
        public int CurveDownLeft
        {
            get { return downLeftCurve; }
            set
            {
                downLeftCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets down right curve.
        /// </summary>
        /// <value>Down right curve.</value>
        [Category("Rounded Rectangle Control")]
        public int CurveDownRight
        {
            get { return downRightCurve; }
            set
            {
                downRightCurve = value;
                Invalidate();
            }
        }

        public StringAlignment TextAlign
        {
            get { return textAlignment; }
            set
            {
                textAlignment = value;
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


        #endregion

        #region Constructor
        public FormStyler()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            TransparencyKey = Color.FromArgb((int)(1.04 * BackColors[0].R), (int)(1.04 * BackColors[0].G), (int)(1.04 * BackColors[0].B));
            FormBorderStyle = FormBorderStyle.None;
            ShowIcon = false;
        }
        #endregion

        #region Events

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            lastClick = new Point(e.X, e.Y); //We'll need this for when the Form starts to move

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            //Point newLocation = new Point(e.X - lastE.X, e.Y - lastE.Y);
            if (e.Button == MouseButtons.Left) //Only when mouse is clicked
            {
                //Move the Form the same difference the mouse cursor moved;
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            StringFormat stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Near
            };

            SizeF fs = g.MeasureString(Text, Font);


            g.Clear(Color.FromArgb((int)(1.04 * BackColors[0].R), (int)(1.04 * BackColors[0].G), (int)(1.04 * BackColors[0].B)));

            if (EnableHatchAnimation)
            {
                switch (AnimOrientation)
                {
                    case AnimationOrientation.Horizontally:
                        g.RenderingOrigin = new Point(reactorOFS, 0);
                        break;
                    case AnimationOrientation.Vertically:
                        g.RenderingOrigin = new Point(0, reactorOFS);
                        break;
                    case AnimationOrientation.Both:
                        g.RenderingOrigin = new Point(reactorOFS, reactorOFS);
                        break;

                }

            }

            Brush hatchBrush = new HatchBrush(HatchStyle, BackColors[0], BackColors[1]);

            switch (DrawingMode)
            {
                case Drawing.Solid:
                    hatchBrush = new SolidBrush(BackColors[1]);
                    break;
                case Drawing.Gradient:
                    hatchBrush = new LinearGradientBrush(Bounds, BackColors[0], BackColors[1], GradientMode);
                    break;
                case Drawing.Hatch:
                    hatchBrush = new HatchBrush(HatchStyle, BackColors[0], BackColors[1]);
                    break;
                default:
                    break;
            }
            

            GraphicsPath BG = DrawHelper.CreateRoundRect(0, 0, Width - 1, Height - 1, Corners);

            Region region = new Region(BG);

            Rectangle rectangle = new Rectangle(((int)BorderWidth / 2), ((int)BorderWidth / 2),
                Width - (int)BorderWidth - 1, Height - (int)BorderWidth - 1);

            GraphicsPath path = new GraphicsPath();

            if (ControlAllCorners)
            {
                RoundedRectangleControl(e, path, rectangle);
            }
            else
            {
                g.FillPath(hatchBrush, BG);

                if (DrawBorder)
                {
                    g.DrawPath(new Pen(BorderColor, BorderWidth), BG);
                }

                g.SetClip(region, CombineMode.Replace);
            }

            //if (ShowIcon)
            //    DrawImage(g, new Rectangle(30 + (int)Corners, 10, ImageSize.Width, ImageSize.Height));

            Bitmap iconBitmap = Icon.ToBitmap();

            if (ShowIcon)
            {
                g.DrawImage(iconBitmap, new Point((int)Corners, 0));

            }


            switch (TextAlign)
            {
                case StringAlignment.Near:
                    g.DrawString(Text, Font, new SolidBrush(ForeColor), new PointF(30 + (1.2f * Corners), 10), stringFormat);

                    break;
                case StringAlignment.Center:
                    g.DrawString(Text, Font, new SolidBrush(ForeColor), new PointF((Width / 2) - (fs.Width / 2) + Corners, 10), stringFormat);

                    break;
                case StringAlignment.Far:
                    g.DrawString(Text, Font, new SolidBrush(ForeColor), new PointF(Width - (fs.Width * 2) + Corners, 10), stringFormat);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Rounds the rectangle control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="P">The p.</param>
        /// <param name="rectangle">The rectangle.</param>
        public void RoundedRectangleControl(PaintEventArgs e, GraphicsPath P, Rectangle rectangle)
        {
            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            //GraphicsPath P = new GraphicsPath();

            int upperLeftCorner = this.CurveUpperLeft * 2;
            int upperRightCorner = this.CurveUpperRight * 2;
            int downLeftCorner = this.CurveDownLeft * 2;
            int downRightCorner = this.CurveDownRight * 2;


            P.AddArc(new Rectangle(rectangle.X, rectangle.Y, upperLeftCorner, upperLeftCorner), -180, 90);
            P.AddArc(new Rectangle(rectangle.Width - upperRightCorner + rectangle.X, rectangle.Y, upperRightCorner, upperRightCorner), -90, 90);
            P.AddArc(new Rectangle(rectangle.Width - downRightCorner + rectangle.X, rectangle.Height - downRightCorner + rectangle.Y, downRightCorner, downRightCorner), 0, 90);
            P.AddArc(new Rectangle(rectangle.X, rectangle.Height - downLeftCorner + rectangle.Y, downLeftCorner, downLeftCorner), 90, 90);

            P.CloseAllFigures();

            HatchBrush hatchBrush = new HatchBrush(HatchStyle, BackColors[0], BackColors[1]);

            G.FillPath(hatchBrush, P);

            if (DrawBorder)
            {
                G.DrawPath(new Pen(BorderColor, BorderWidth), P);
            }
        }

        #region Hatch Animation

        private bool enableHatchAnimation = false;

        public bool EnableHatchAnimation
        {
            get { return enableHatchAnimation; }
            set
            {
                enableHatchAnimation = value;
                Invalidate();
            }
        }

        public int HatchSpeed
        {
            get { return hatchSpeed; }
            set
            {
                hatchSpeed = value;
                Invalidate();
            }
        }



        //---------------------------Include in Paint--------------------//
        //
        //if (EnableHatchAnimation)
        //{
        //    G.RenderingOrigin = new Point(reactorOFS, 0);
        //}
        //
        //---------------------------Include in Paint--------------------//

        private int reactorOFS = 20;
        private int hatchSpeed = 50;
        private AnimationOrientation animOrientation = AnimationOrientation.Horizontally;

        public AnimationOrientation AnimOrientation
        {
            get { return animOrientation; }
            set
            {
                animOrientation = value;
                Invalidate();
            }
        }

        public enum AnimationOrientation
        {
            Horizontally,
            Vertically,
            Both
        }

        private System.Threading.Thread T;

        private void ReactorCreateHandle()
        {
            T = new System.Threading.Thread(ReactorAnimate);
            if (EnableHatchAnimation)
            {
                // Dim tmr As New Timer With {.Interval = hatchSpeed}
                // AddHandler tmr.Tick, AddressOf ReactorAnimate
                // tmr.Start()

                T.IsBackground = true;
                T.Start();
            }
            else
            {
                T.IsBackground = false;
                T.Abort();
            }

        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            ReactorCreateHandle();
        }

        public void ReactorAnimate()
        {
            while (true)
            {
                if (reactorOFS <= Width)
                {
                    reactorOFS += 1;
                }
                else
                {
                    reactorOFS = 0;
                }

                if (reactorOFS <= Height)
                {
                    reactorOFS += 1;
                }
                else
                {
                    reactorOFS = 0;
                }
                Invalidate();
                System.Threading.Thread.Sleep(hatchSpeed);
            }
        }


        #endregion

        #endregion

    }
}
