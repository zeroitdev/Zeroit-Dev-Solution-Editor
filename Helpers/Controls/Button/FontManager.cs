﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.LollipopControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="FontManager.cs" company="Zeroit Dev Technologies">
//    This program is for creating Lollipop controls.
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
using ZeroitDevSolutionEditor.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace ZeroitDevSolutionEditor.Helpers
{
    /// <summary>
    /// Class FontManager.
    /// </summary>
    public class FontManager
    {

        /// <summary>
        /// The roboto medium15
        /// </summary>
        public Font Roboto_Medium15;
        /// <summary>
        /// The roboto medium10
        /// </summary>
        public Font Roboto_Medium10;
        /// <summary>
        /// The roboto regular10
        /// </summary>
        public Font Roboto_Regular10;


        /// <summary>
        /// The roboto medium9
        /// </summary>
        public Font Roboto_Medium9;
        /// <summary>
        /// The roboto regular9
        /// </summary>
        public Font Roboto_Regular9;


        /// <summary>
        /// Initializes a new instance of the <see cref="FontManager"/> class.
        /// </summary>
        public FontManager()
        {
            Roboto_Medium15 = new Font(LoadFont(Resources.Roboto_Medium), 15f);
            Roboto_Medium10 = new Font(LoadFont(Resources.Roboto_Medium), 10f);
            Roboto_Regular10 = new Font(LoadFont(Resources.Roboto_Regular), 10f);

            Roboto_Medium9 = new Font(LoadFont(Resources.Roboto_Medium), 9f);
            Roboto_Regular9 = new Font(LoadFont(Resources.Roboto_Regular), 9f);
        }

        /// <summary>
        /// The private font collection
        /// </summary>
        private PrivateFontCollection privateFontCollection = new PrivateFontCollection();

        /// <summary>
        /// Adds the font memory resource ex.
        /// </summary>
        /// <param name="pbFont">The pb font.</param>
        /// <param name="cbFont">The cb font.</param>
        /// <param name="pvd">The PVD.</param>
        /// <param name="pcFonts">The pc fonts.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pvd, [In] ref uint pcFonts);

        /// <summary>
        /// Loads the font.
        /// </summary>
        /// <param name="fontResource">The font resource.</param>
        /// <returns>FontFamily.</returns>
        private FontFamily LoadFont(byte[] fontResource)
        {
            int dataLength = fontResource.Length;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontResource, 0, fontPtr, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(fontPtr, (uint)fontResource.Length, IntPtr.Zero, ref cFonts);
            privateFontCollection.AddMemoryFont(fontPtr, dataLength);

            return privateFontCollection.Families.Last();
        }
    }

}
