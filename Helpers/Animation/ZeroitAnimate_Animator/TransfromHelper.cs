﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Transitions
// Author           : ZEROIT
// Created          : 12-02-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="TransfromHelper.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Imaging;
//using System.Windows.Forms.VisualStyles;

#endregion

namespace ZeroitDevSolutionEditor.Helpers.Animations
{
    #region TransfromHelper
    /// <summary>
    /// Implements image transformations
    /// </summary>
    public static class TransfromHelper
    {
        /// <summary>
        /// The bytes per pixel
        /// </summary>
        const int bytesPerPixel = 4;
        /// <summary>
        /// The random
        /// </summary>
        static Random rnd = new Random();

        /// <summary>
        /// Does the scale.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="animation">The animation.</param>
        public static void DoScale(TransfromNeededEventArg e, ZeroitAnimate_Animation animation)
        {
            var rect = e.ClientRectangle;
            var center = new PointF(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
            e.Matrix.Translate(center.X, center.Y);
            var kx = 1f - animation.ScaleCoeff.X * e.CurrentTime;
            var ky = 1f - animation.ScaleCoeff.X * e.CurrentTime;
            if (Math.Abs(kx) <= 0.001f) kx = 0.001f;
            if (Math.Abs(ky) <= 0.001f) ky = 0.001f;
            e.Matrix.Scale(kx, ky);
            e.Matrix.Translate(-center.X, -center.Y);
        }

        /// <summary>
        /// Does the slide.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="animation">The animation.</param>
        public static void DoSlide(TransfromNeededEventArg e, ZeroitAnimate_Animation animation)
        {
            var k = e.CurrentTime;
            e.Matrix.Translate(-e.ClientRectangle.Width * k * animation.SlideCoeff.X, -e.ClientRectangle.Height * k * animation.SlideCoeff.Y);
        }

        /// <summary>
        /// Does the blind.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="animation">The animation.</param>
        public static void DoBlind(NonLinearTransfromNeededEventArg e, ZeroitAnimate_Animation animation)
        {
            if (animation.BlindCoeff == PointF.Empty)
                return;

            var pixels = e.Pixels;
            var sx = e.ClientRectangle.Width;
            var sy = e.ClientRectangle.Height;
            var s = e.Stride;
            var kx = animation.BlindCoeff.X;
            var ky = animation.BlindCoeff.Y;
            var a = (int)((sx * kx + sy * ky) * (1 - e.CurrentTime));

            for (int x = 0; x < sx; x++)
            for (int y = 0; y < sy; y++)
            {
                int i = y * s + x * bytesPerPixel;
                var d = x * kx + y * ky - a;
                if (d >= 0)
                    pixels[i + 3] = (byte)0;
            }
        }

        /// <summary>
        /// Does the mosaic.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="animation">The animation.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="pixelsBuffer">The pixels buffer.</param>
        public static void DoMosaic(NonLinearTransfromNeededEventArg e, ZeroitAnimate_Animation animation, ref System.Drawing.Point[] buffer, ref byte[] pixelsBuffer)
        {
            if (animation.MosaicCoeff == PointF.Empty || animation.MosaicSize == 0)
                return;

            var pixels = e.Pixels;
            var sx = e.ClientRectangle.Width;
            var sy = e.ClientRectangle.Height;
            var s = e.Stride;
            var a = e.CurrentTime;
            var count = pixels.Length;
            var opacity = 1 - e.CurrentTime;
            if (opacity < 0f) opacity = 0f;
            if (opacity > 1f) opacity = 1f;
            var mkx = animation.MosaicCoeff.X;
            var mky = animation.MosaicCoeff.Y;

            if (buffer == null)
            {
                buffer = new System.Drawing.Point[pixels.Length];
                for (int i = 0; i < pixels.Length; i++)
                    buffer[i] = new System.Drawing.Point((int)(mkx * (rnd.NextDouble() - 0.5)), (int)(mky * (rnd.NextDouble() - 0.5)));
            }

            if (pixelsBuffer == null)
                pixelsBuffer = (byte[])pixels.Clone();


            for (int i = 0; i < count; i += bytesPerPixel)
            {
                pixels[i + 0] = 255;
                pixels[i + 1] = 255;
                pixels[i + 2] = 255;
                pixels[i + 3] = 0;
            }

            var ms = animation.MosaicSize;
            var msx = animation.MosaicShift.X;
            var msy = animation.MosaicShift.Y;

            for (int y = 0; y < sy; y++)
            for (int x = 0; x < sx; x++)
            {
                int yi = (y / ms);
                int xi = (x / ms);
                int i = y * s + x * bytesPerPixel;
                int j = yi * s + xi * bytesPerPixel;

                var newX = x + (int)(a * (buffer[j].X + xi * msx));
                var newY = y + (int)(a * (buffer[j].Y + yi * msy));

                if (newX >= 0 && newX < sx)
                    if (newY >= 0 && newY < sy)
                    {
                        int newI = newY * s + newX * bytesPerPixel;
                        pixels[newI + 0] = pixelsBuffer[i + 0];
                        pixels[newI + 1] = pixelsBuffer[i + 1];
                        pixels[newI + 2] = pixelsBuffer[i + 2];
                        pixels[newI + 3] = (byte)(pixelsBuffer[i + 3] * opacity);
                    }
            }
        }


        /// <summary>
        /// Does the leaf.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="animation">The animation.</param>
        public static void DoLeaf(NonLinearTransfromNeededEventArg e, ZeroitAnimate_Animation animation)
        {
            if (animation.LeafCoeff == 0f)
                return;

            var pixels = e.Pixels;
            var sx = e.ClientRectangle.Width;
            var sy = e.ClientRectangle.Height;
            var s = e.Stride;
            var a = (int)((sx + sy) * (1 - e.CurrentTime * e.CurrentTime));

            var count = pixels.Length;

            for (int x = 0; x < sx; x++)
            for (int y = 0; y < sy; y++)
            {
                int i = y * s + x * bytesPerPixel;
                if (x + y >= a)
                {
                    var newX = a - y;
                    var newY = a - x;
                    var d = a - x - y;
                    if (d < -20)
                        d = -20;

                    int newI = newY * s + newX * bytesPerPixel;
                    if (newX >= 0 && newY >= 0)
                        if (newI >= 0 && newI < count)
                            if (pixels[i + 3] > 0)
                            {
                                pixels[newI + 0] = (byte)Math.Min(255, d + 250 + pixels[i + 0] / 10);
                                pixels[newI + 1] = (byte)Math.Min(255, d + 250 + pixels[i + 1] / 10);
                                pixels[newI + 2] = (byte)Math.Min(255, d + 250 + pixels[i + 2] / 10);
                                pixels[newI + 3] = 230;
                            }
                    pixels[i + 3] = (byte)(0);
                }
            }
        }

        /// <summary>
        /// Does the transparent.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="animation">The animation.</param>
        public static void DoTransparent(NonLinearTransfromNeededEventArg e, ZeroitAnimate_Animation animation)
        {
            if (animation.TransparencyCoeff == 0f)
                return;
            var opacity = 1f - animation.TransparencyCoeff * e.CurrentTime;
            if (opacity < 0f)
                opacity = 0f;
            if (opacity > 1f)
                opacity = 1f;

            var pixels = e.Pixels;
            for (int counter = 0; counter < pixels.Length; counter += bytesPerPixel)
                pixels[counter + 3] = (byte)(pixels[counter + 3] * opacity);
        }

        /// <summary>
        /// Calculates the difference.
        /// </summary>
        /// <param name="bmp1">The BMP1.</param>
        /// <param name="bmp2">The BMP2.</param>
        public static void CalcDifference(Bitmap bmp1, Bitmap bmp2)
        {
            PixelFormat pxf = PixelFormat.Format32bppArgb;
            Rectangle rect = new Rectangle(0, 0, bmp1.Width, bmp1.Height);

            BitmapData bmpData1 = bmp1.LockBits(rect, ImageLockMode.ReadWrite, pxf);
            IntPtr ptr1 = bmpData1.Scan0;

            BitmapData bmpData2 = bmp2.LockBits(rect, ImageLockMode.ReadOnly, pxf);
            IntPtr ptr2 = bmpData2.Scan0;

            int numBytes = bmp1.Width * bmp1.Height * bytesPerPixel;
            byte[] pixels1 = new byte[numBytes];
            byte[] pixels2 = new byte[numBytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr1, pixels1, 0, numBytes);
            System.Runtime.InteropServices.Marshal.Copy(ptr2, pixels2, 0, numBytes);

            for (int i = 0; i < numBytes; i += bytesPerPixel)
            {
                if (pixels1[i + 0] == pixels2[i + 0] &&
                    pixels1[i + 1] == pixels2[i + 1] &&
                    pixels1[i + 2] == pixels2[i + 2])
                {
                    pixels1[i + 0] = 255;
                    pixels1[i + 1] = 255;
                    pixels1[i + 2] = 255;
                    pixels1[i + 3] = 0;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(pixels1, 0, ptr1, numBytes);
            bmp1.UnlockBits(bmpData1);
            bmp2.UnlockBits(bmpData2);
        }

        /// <summary>
        /// Does the rotate.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="animation">The animation.</param>
        public static void DoRotate(TransfromNeededEventArg e, ZeroitAnimate_Animation animation)
        {
            var rect = e.ClientRectangle;
            var center = new PointF(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);

            e.Matrix.Translate(center.X, center.Y);
            if (e.CurrentTime > animation.RotateLimit)
                e.Matrix.Rotate(360 * (e.CurrentTime - animation.RotateLimit) * animation.RotateCoeff);
            e.Matrix.Translate(-center.X, -center.Y);
        }

        /// <summary>
        /// Does the bottom mirror.
        /// </summary>
        /// <param name="e">The e.</param>
        public static void DoBottomMirror(NonLinearTransfromNeededEventArg e)
        {
            var source = e.SourcePixels;
            var output = e.Pixels;

            var s = e.Stride;
            var dy = 1;
            var beginY = e.SourceClientRectangle.Bottom + dy;
            var sy = e.ClientRectangle.Height;
            var beginX = e.SourceClientRectangle.Left;
            var endX = e.SourceClientRectangle.Right;
            var d = sy - beginY;

            for (int x = beginX; x < endX; x++)
            for (int y = beginY; y < sy; y++)
            {
                var sourceY = (int)(beginY - 1 - dy - (y - beginY));
                if (sourceY < 0)
                    break;
                var sourceX = x;
                int sourceI = sourceY * s + sourceX * bytesPerPixel;
                int outI = y * s + x * bytesPerPixel;
                output[outI + 0] = source[sourceI + 0];
                output[outI + 1] = source[sourceI + 1];
                output[outI + 2] = source[sourceI + 2];
                output[outI + 3] = (byte)((1 - 1f * (y - beginY) / d) * 90);
            }
        }

        /*
        internal static void DoBottomShadow(NonLinearTransfromNeededEventArg e)
        {
            var source = e.SourcePixels;
            var output = e.Pixels;

            var s = e.Stride;
            var dy = 1;
            var beginY = e.SourceClientRectangle.Bottom + dy;
            var sy = e.ClientRectangle.Height;
            var beginX = e.SourceClientRectangle.Left;
            var endX = e.SourceClientRectangle.Right;
            var d = sy - beginY;

            var bgG = source[0];
            var bgB = source[1];
            var bgR = source[2];

            for (int x = beginX; x < endX; x++)
                for (int y = beginY; y < sy; y++)
                {
                    var sourceY = (int)(beginY - 1 - dy - (y - beginY)*6);
                    if (sourceY < 0)
                        break;
                    var sourceX = x;
                    int sourceI = sourceY * s + sourceX * bytesPerPixel;
                    int outI = y * s + x * bytesPerPixel;
                    if (source[sourceI + 0] != bgG && source[sourceI + 1] != bgB && source[sourceI + 2] != bgR)
                    {
                        output[outI + 0] = 0;
                        output[outI + 1] = 0;
                        output[outI + 2] = 0;
                        output[outI + 3] = (byte) ((1 - 1f*(y - beginY)/d)*90);
                    }
                }
        }*/

        /// <summary>
        /// Does the blur.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="r">The r.</param>
        public static void DoBlur(NonLinearTransfromNeededEventArg e, int r)
        {
            var output = e.Pixels;
            var source = e.SourcePixels;

            var s = e.Stride;
            var sy = e.ClientRectangle.Height;
            var sx = e.ClientRectangle.Width;
            var maxI = source.Length - bytesPerPixel;

            for (int x = r; x < sx - r; x++)
            for (int y = r; y < sy - r; y++)
            {
                int outI = y * s + x * bytesPerPixel;

                int R = 0, G = 0, B = 0, A = 0;
                int counter = 0;
                for (int xx = x - r; xx < x + r; xx++)
                for (int yy = y - r; yy < y + r; yy++)
                {
                    int srcI = yy * s + xx * bytesPerPixel;
                    if (srcI >= 0 && srcI < maxI)
                        if (source[srcI + 3] > 0)
                        {
                            B += source[srcI + 0];
                            G += source[srcI + 1];
                            R += source[srcI + 2];
                            A += source[srcI + 3];
                            counter++;
                        }
                }
                if (outI < maxI && counter > 5)
                {
                    output[outI + 0] = (byte)(B / counter);
                    output[outI + 1] = (byte)(G / counter);
                    output[outI + 2] = (byte)(R / counter);
                    output[outI + 3] = (byte)(A / counter);
                    //output[outI + 3] = 255; //(byte)((1 - 1f * (y - beginY) / d) * 90);
                }
            }
        }

        /// <summary>
        /// Does the flip.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="animation">The animation.</param>
        public static void DoFlip(TransfromNeededEventArg e, ZeroitAnimate_Animation animation)
        {
            var cy = e.ClientRectangle.Height / 5;

            var sy = 1 - 2 * e.CurrentTime;
            if (sy < 0.01f && sy > -0.01f)
                sy = 0.01f;

            e.Matrix.Translate(0, cy);
            e.Matrix.Scale(1, sy);
            e.Matrix.Translate(0, -cy);
        }

    }
    #endregion
}
