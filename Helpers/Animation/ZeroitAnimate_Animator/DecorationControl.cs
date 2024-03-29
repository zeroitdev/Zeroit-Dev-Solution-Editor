﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Transitions
// Author           : ZEROIT
// Created          : 12-02-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DecorationControl.cs" company="Zeroit Dev Technologies">
//    This program is for creating components to aid in Animating controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace ZeroitDevSolutionEditor.Helpers.Animations
{
    #region DecorationControl
    /// <summary>
    /// Class DecorationControl.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public class DecorationControl : UserControl
    {
        /// <summary>
        /// Gets or sets the type of the decoration.
        /// </summary>
        /// <value>The type of the decoration.</value>
        public DecorationType DecorationType { get; set; }
        /// <summary>
        /// Gets or sets the decorated control.
        /// </summary>
        /// <value>The decorated control.</value>
        public Control DecoratedControl { get; set; }
        /// <summary>
        /// Gets or sets padding within the control.
        /// </summary>
        /// <value>The padding.</value>
        public Padding Padding { get; set; }
        /// <summary>
        /// Gets or sets the control BMP.
        /// </summary>
        /// <value>The control BMP.</value>
        public Bitmap CtrlBmp { get; set; }
        /// <summary>
        /// Gets or sets the control pixels.
        /// </summary>
        /// <value>The control pixels.</value>
        public byte[] CtrlPixels { get; set; }
        /// <summary>
        /// Gets or sets the control stride.
        /// </summary>
        /// <value>The control stride.</value>
        public int CtrlStride { get; set; }
        /// <summary>
        /// Gets or sets the frame.
        /// </summary>
        /// <value>The frame.</value>
        public Bitmap Frame { get; set; }
        /// <summary>
        /// Gets or sets the current time.
        /// </summary>
        /// <value>The current time.</value>
        public float CurrentTime { get; set; }
        /// <summary>
        /// The tm
        /// </summary>
        System.Windows.Forms.Timer tm;

        /// <summary>
        /// Initializes a new instance of the <see cref="DecorationControl"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="decoratedControl">The decorated control.</param>
        public DecorationControl(DecorationType type, Control decoratedControl)
        {
            this.DecorationType = type;
            this.DecoratedControl = decoratedControl;

            decoratedControl.VisibleChanged += new EventHandler(control_VisibleChanged);
            decoratedControl.ParentChanged += new EventHandler(control_VisibleChanged);
            decoratedControl.LocationChanged += new EventHandler(control_VisibleChanged);

            decoratedControl.Paint += new PaintEventHandler(decoratedControl_Paint);

            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            //BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            InitPadding();

            tm = new System.Windows.Forms.Timer();
            tm.Interval = 100;
            tm.Tick += new EventHandler(tm_Tick);
            tm.Enabled = true;
        }

        /// <summary>
        /// Initializes the padding.
        /// </summary>
        private void InitPadding()
        {
            switch (DecorationType)
            {
                case ZeroitDevSolutionEditor.Helpers.Animations.DecorationType.BottomMirror:
                    Padding = new Padding(0, 0, 0, 20);
                    break;
            }
        }

        /// <summary>
        /// Handles the Tick event of the tm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void tm_Tick(object sender, EventArgs e)
        {
            switch (DecorationType)
            {
                case ZeroitDevSolutionEditor.Helpers.Animations.DecorationType.BottomMirror:
                case ZeroitDevSolutionEditor.Helpers.Animations.DecorationType.Custom:
                    Invalidate();
                    break;
            }
        }

        /// <summary>
        /// Handles the Paint event of the decoratedControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        void decoratedControl_Paint(object sender, PaintEventArgs e)
        {
            if (!isSnapshotNow)
            {
                /*
                if (Frame != null)
                {
                    e.Graphics.DrawImage(Frame, new System.Drawing.Point(-Padding.Left, -Padding.Top));
                    wasDraw = true;
                }*/
                /*
                CtrlBmp = GetForeground(DecoratedControl);
                CtrlPixels = GetPixels(CtrlBmp);*/
                /*does not work for TextBox*/
                //wasRepainted = true;
                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            CtrlBmp = GetForeground(DecoratedControl);
            CtrlPixels = GetPixels(CtrlBmp);

            if (Frame != null)
                Frame.Dispose();
            Frame = OnNonLinearTransfromNeeded();

            if (Frame != null)
            {
                e.Graphics.DrawImage(Frame, System.Drawing.Point.Empty);
            }
        }

        /// <summary>
        /// Handles the VisibleChanged event of the control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void control_VisibleChanged(object sender, EventArgs e)
        {
            Init();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Init()
        {
            this.Parent = DecoratedControl.Parent;
            this.Visible = DecoratedControl.Visible;
            this.Location = new System.Drawing.Point(DecoratedControl.Left - Padding.Left, DecoratedControl.Top - Padding.Top);


            if (Parent != null)
            {
                var i = Parent.Controls.GetChildIndex(DecoratedControl);
                Parent.Controls.SetChildIndex(this, i + 1);
            }

            var newSize = new System.Drawing.Size(DecoratedControl.Width + Padding.Left + Padding.Right, DecoratedControl.Height + Padding.Top + Padding.Bottom);
            if (newSize != Size)
            {
                this.Size = newSize;
            }
        }

        /// <summary>
        /// The is snapshot now
        /// </summary>
        bool isSnapshotNow = false;

        /// <summary>
        /// Gets the foreground.
        /// </summary>
        /// <param name="ctrl">The control.</param>
        /// <returns>Bitmap.</returns>
        protected virtual Bitmap GetForeground(Control ctrl)
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);

            if (!ctrl.IsDisposed)
            {
                isSnapshotNow = true;
                ctrl.DrawToBitmap(bmp, new Rectangle(Padding.Left, Padding.Top, ctrl.Width, ctrl.Height));
                isSnapshotNow = false;
            }
            return bmp;
        }

        /// <summary>
        /// Gets the pixels.
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        /// <returns>System.Byte[].</returns>
        byte[] GetPixels(Bitmap bmp)
        {
            const int bytesPerPixel = 4;
            PixelFormat pxf = PixelFormat.Format32bppArgb;
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, pxf);
            IntPtr ptr = bmpData.Scan0;
            int numBytes = bmp.Width * bmp.Height * bytesPerPixel;
            byte[] argbValues = new byte[numBytes];
            Marshal.Copy(ptr, argbValues, 0, numBytes);
            //Marshal.Copy(argbValues, 0, ptr, numBytes);
            bmp.UnlockBits(bmpData);
            return argbValues;
        }

        /// <summary>
        /// Occurs when [non linear transfrom needed].
        /// </summary>
        public event EventHandler<NonLinearTransfromNeededEventArg> NonLinearTransfromNeeded;

        /// <summary>
        /// Called when [non linear transfrom needed].
        /// </summary>
        /// <returns>Bitmap.</returns>
        protected virtual Bitmap OnNonLinearTransfromNeeded()
        {
            Bitmap bmp = null;
            if (CtrlBmp == null)
                return null;

            try
            {
                bmp = new Bitmap(Width, Height);

                const int bytesPerPixel = 4;
                PixelFormat pxf = PixelFormat.Format32bppArgb;
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, pxf);
                IntPtr ptr = bmpData.Scan0;
                int numBytes = bmp.Width * bmp.Height * bytesPerPixel;
                byte[] argbValues = new byte[numBytes];

                Marshal.Copy(ptr, argbValues, 0, numBytes);

                var e = new NonLinearTransfromNeededEventArg() { CurrentTime = CurrentTime, ClientRectangle = ClientRectangle, Pixels = argbValues, Stride = bmpData.Stride, SourcePixels = CtrlPixels, SourceClientRectangle = new Rectangle(Padding.Left, Padding.Top, DecoratedControl.Width, DecoratedControl.Height), SourceStride = CtrlStride };

                try
                {
                    if (NonLinearTransfromNeeded != null)
                        NonLinearTransfromNeeded(this, e);
                    else
                        e.UseDefaultTransform = true;

                    if (e.UseDefaultTransform)
                    {
                        switch (DecorationType)
                        {
                            case DecorationType.BottomMirror: TransfromHelper.DoBottomMirror(e); break;
                        }
                    }
                }
                catch { }

                Marshal.Copy(argbValues, 0, ptr, numBytes);
                bmp.UnlockBits(bmpData);
            }
            catch
            {
            }

            return bmp;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            tm.Stop();
            tm.Dispose();
            base.Dispose(disposing);
        }
        
    }

    #endregion
}
