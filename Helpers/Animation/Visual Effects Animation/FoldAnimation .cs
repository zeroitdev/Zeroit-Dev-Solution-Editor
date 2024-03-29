﻿// ***********************************************************************
// Assembly         : ZeroitDevSolutionEditor.Helpers.Animations
// Author           : ZEROIT
// Created          : 12-02-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="FoldAnimation .cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Linq;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using static ZeroitDevSolutionEditor.Helpers.Animations.ZeroitVisAnim;

#endregion

namespace ZeroitDevSolutionEditor.Helpers.Animations
{
    #region ExampleFoldAnimation
    /// <summary>
    /// Class FoldAnimation.
    /// </summary>
    public class FoldAnimation
    {
        /// <summary>
        /// The cancellation tokens
        /// </summary>
        private List<ZeroitDevSolutionEditor.Helpers.Animations.AnimationStatus> _cancellationTokens;

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <value>The control.</value>
        public Control Control { get; private set; }

        /// <summary>
        /// Gets or sets the maximum size.
        /// </summary>
        /// <value>The maximum size.</value>
        public System.Drawing.Size MaxSize { get; set; }

        /// <summary>
        /// Gets or sets the minimum size.
        /// </summary>
        /// <value>The minimum size.</value>
        public System.Drawing.Size MinSize { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the delay.
        /// </summary>
        /// <value>The delay.</value>
        public int Delay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FoldAnimation"/> is reverse.
        /// </summary>
        /// <value><c>true</c> if reverse; otherwise, <c>false</c>.</value>
        public bool Reverse { get; set; }

        /// <summary>
        /// Gets or sets the loops.
        /// </summary>
        /// <value>The loops.</value>
        public int Loops { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FoldAnimation"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        public FoldAnimation(Control control)
        {
            _cancellationTokens = new List<ZeroitDevSolutionEditor.Helpers.Animations.AnimationStatus>();

            this.Control = control;
            this.MaxSize = control.Size;
            this.MinSize = control.MinimumSize;
            this.Duration = 1000;
            this.Delay = 0;
        }

        /// <summary>
        /// Shows this instance.
        /// </summary>
        public void Show()
        {
            int duration = this.Duration;
            if (_cancellationTokens.Any(animation => !animation.IsCompleted))
            {
                var token = _cancellationTokens.First(animation => !animation.IsCompleted);
                duration = (int)(token.ElapsedMilliseconds);
            }

            //cancel hide animation if in progress
            this.Cancel();

            var cT1 = this.Control.Animate(new HorizontalFoldEffect(),
                EasingFunctions.CircEaseIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);

            var cT2 = this.Control.Animate(new VerticalFoldEffect(),
                EasingFunctions.CircEaseOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);

            _cancellationTokens.Add(cT1);
            _cancellationTokens.Add(cT2);
        }

        /// <summary>
        /// Hides this instance.
        /// </summary>
        public void Hide()
        {
            int duration = this.Duration;

            if (_cancellationTokens.Any(animation => !animation.IsCompleted))
            {
                var token = _cancellationTokens.First(animation => !animation.IsCompleted);
                duration = (int)(token.ElapsedMilliseconds);
            }

            //cancel show animation if in progress
            this.Cancel();


            var cT1 = this.Control.Animate(new HorizontalFoldEffect(),
                EasingFunctions.CircEaseOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);

            var cT2 = this.Control.Animate(new VerticalFoldEffect(),
                EasingFunctions.CircEaseIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);

            _cancellationTokens.Add(cT1);
            _cancellationTokens.Add(cT2);
        }

        /// <summary>
        /// Shows the specified horizontal.
        /// </summary>
        /// <param name="horizontal">The horizontal.</param>
        /// <param name="vertical">The vertical.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// horizontal - null
        /// or
        /// horizontal - null
        /// </exception>
        public void Show(EasingFunctionTypes horizontal, EasingFunctionTypes vertical)
        {
            int duration = this.Duration;
            if (_cancellationTokens.Any(animation => !animation.IsCompleted))
            {
                var token = _cancellationTokens.First(animation => !animation.IsCompleted);
                duration = (int)(token.ElapsedMilliseconds);
            }

            //cancel hide animation if in progress
            this.Cancel();

            switch (horizontal)
            {
                case EasingFunctionTypes.BackEaseIn:
                    var cH1 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BackEaseIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH1);
                    break;
                case EasingFunctionTypes.BackEaseInOut:
                    var cH2 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BackEaseInOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH2);
                    break;
                case EasingFunctionTypes.BackEaseOut:
                    var cH3 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BackEaseOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH3);
                    break;
                case EasingFunctionTypes.BackEaseOutIn:
                    var cH4 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BackEaseOutIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH4);
                    break;
                case EasingFunctionTypes.BounceEaseIn:
                    var cH5 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BounceEaseIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH5);
                    break;
                case EasingFunctionTypes.BounceEaseInOut:
                    var cH6 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BounceEaseInOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH6);
                    break;
                case EasingFunctionTypes.BounceEaseOut:
                    var cH7 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BounceEaseOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH7);
                    break;
                case EasingFunctionTypes.BounceEaseOutIn:
                    var cH8 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BounceEaseOutIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH8);
                    break;
                case EasingFunctionTypes.CircEaseIn:
                    var cH9 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CircEaseIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH9);
                    break;
                case EasingFunctionTypes.CircEaseInOut:
                    var cH10 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CircEaseInOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH10);
                    break;
                case EasingFunctionTypes.CircEaseOut:
                    var cH11 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CircEaseOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH11);
                    break;
                case EasingFunctionTypes.CircEaseOutIn:
                    var cH12 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CircEaseOutIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH12);
                    break;
                case EasingFunctionTypes.CubicEaseIn:
                    var cH13 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CubicEaseIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH13);
                    break;
                case EasingFunctionTypes.CubicEaseInOut:
                    var cH14 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CubicEaseInOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH14);
                    break;
                case EasingFunctionTypes.CubicEaseOut:
                    var cH15 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CubicEaseOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH15);
                    break;
                case EasingFunctionTypes.CubicEaseOutIn:
                    var cH16 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CubicEaseOutIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH16);
                    break;
                case EasingFunctionTypes.ElasticEaseIn:
                    var cH17 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ElasticEaseIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH17);
                    break;
                case EasingFunctionTypes.ElasticEaseInOut:
                    var cH18 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ElasticEaseInOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH18);
                    break;
                case EasingFunctionTypes.ElasticEaseOut:
                    var cH19 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ElasticEaseOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH19);
                    break;
                case EasingFunctionTypes.ElasticEaseOutIn:
                    var cH20 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ElasticEaseOutIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH20);
                    break;
                case EasingFunctionTypes.ExpoEaseIn:
                    var cH21 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ExpoEaseIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH21);
                    break;
                case EasingFunctionTypes.ExpoEaseInOut:
                    var cH22 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ExpoEaseInOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH22);
                    break;
                case EasingFunctionTypes.ExpoEaseOut:
                    var cH23 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ExpoEaseOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH23);
                    break;
                case EasingFunctionTypes.ExpoEaseOutIn:
                    var cH24 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ExpoEaseOutIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH24);
                    break;
                case EasingFunctionTypes.Linear:
                    var cH25 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.Linear, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH25);
                    break;
                case EasingFunctionTypes.QuadEaseIn:
                    var cH26 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuadEaseIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH26);
                    break;
                case EasingFunctionTypes.QuadEaseInOut:
                    var cH27 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuadEaseInOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH27);
                    break;
                case EasingFunctionTypes.QuadEaseOut:
                    var cH28 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuadEaseOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH28);
                    break;
                case EasingFunctionTypes.QuadEaseOutIn:
                    var cH29 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuadEaseOutIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH29);
                    break;
                case EasingFunctionTypes.QuartEaseIn:
                    var cH30 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuartEaseIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH30);
                    break;
                case EasingFunctionTypes.QuartEaseInOut:
                    var cH31 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuartEaseInOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH31);
                    break;
                case EasingFunctionTypes.QuartEaseOut:
                    var cH32 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuartEaseOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH32);
                    break;
                case EasingFunctionTypes.QuartEaseOutIn:
                    var cH33 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuartEaseOutIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH33);
                    break;
                case EasingFunctionTypes.QuintEaseIn:
                    var cH34 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuintEaseIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH34);
                    break;
                case EasingFunctionTypes.QuintEaseInOut:
                    var cH35 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuintEaseInOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH35);
                    break;
                case EasingFunctionTypes.QuintEaseOut:
                    var cH36 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuintEaseOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH36);
                    break;
                case EasingFunctionTypes.QuintEaseOutIn:
                    var cH37 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuintEaseOutIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH37);
                    break;
                case EasingFunctionTypes.SineEaseIn:
                    var cH38 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.SineEaseIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH38);
                    break;
                case EasingFunctionTypes.SineEaseInOut:
                    var cH39 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.SineEaseInOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH39);
                    break;
                case EasingFunctionTypes.SineEaseOut:
                    var cH40 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.SineEaseOut, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH40);
                    break;
                case EasingFunctionTypes.SineEaseOutIn:
                    var cH41 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.SineEaseOutIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH41);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(horizontal), horizontal, null);
            }

            switch (vertical)
            {
                case EasingFunctionTypes.BackEaseIn:
                    var cH1 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BackEaseIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH1);
                    break;
                case EasingFunctionTypes.BackEaseInOut:
                    var cH2 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BackEaseInOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH2);
                    break;
                case EasingFunctionTypes.BackEaseOut:
                    var cH3 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BackEaseOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH3);
                    break;
                case EasingFunctionTypes.BackEaseOutIn:
                    var cH4 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BackEaseOutIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH4);
                    break;
                case EasingFunctionTypes.BounceEaseIn:
                    var cH5 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BounceEaseIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH5);
                    break;
                case EasingFunctionTypes.BounceEaseInOut:
                    var cH6 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BounceEaseInOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH6);
                    break;
                case EasingFunctionTypes.BounceEaseOut:
                    var cH7 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BounceEaseOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH7);
                    break;
                case EasingFunctionTypes.BounceEaseOutIn:
                    var cH8 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BounceEaseOutIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH8);
                    break;
                case EasingFunctionTypes.CircEaseIn:
                    var cH9 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CircEaseIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH9);
                    break;
                case EasingFunctionTypes.CircEaseInOut:
                    var cH10 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CircEaseInOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH10);
                    break;
                case EasingFunctionTypes.CircEaseOut:
                    var cH11 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CircEaseOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH11);
                    break;
                case EasingFunctionTypes.CircEaseOutIn:
                    var cH12 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CircEaseOutIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH12);
                    break;
                case EasingFunctionTypes.CubicEaseIn:
                    var cH13 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CubicEaseIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH13);
                    break;
                case EasingFunctionTypes.CubicEaseInOut:
                    var cH14 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CubicEaseInOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH14);
                    break;
                case EasingFunctionTypes.CubicEaseOut:
                    var cH15 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CubicEaseOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH15);
                    break;
                case EasingFunctionTypes.CubicEaseOutIn:
                    var cH16 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CubicEaseOutIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH16);
                    break;
                case EasingFunctionTypes.ElasticEaseIn:
                    var cH17 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ElasticEaseIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH17);
                    break;
                case EasingFunctionTypes.ElasticEaseInOut:
                    var cH18 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ElasticEaseInOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH18);
                    break;
                case EasingFunctionTypes.ElasticEaseOut:
                    var cH19 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ElasticEaseOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH19);
                    break;
                case EasingFunctionTypes.ElasticEaseOutIn:
                    var cH20 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ElasticEaseOutIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH20);
                    break;
                case EasingFunctionTypes.ExpoEaseIn:
                    var cH21 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ExpoEaseIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH21);
                    break;
                case EasingFunctionTypes.ExpoEaseInOut:
                    var cH22 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ExpoEaseInOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH22);
                    break;
                case EasingFunctionTypes.ExpoEaseOut:
                    var cH23 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ExpoEaseOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH23);
                    break;
                case EasingFunctionTypes.ExpoEaseOutIn:
                    var cH24 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ExpoEaseOutIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH24);
                    break;
                case EasingFunctionTypes.Linear:
                    var cH25 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.Linear, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH25);
                    break;
                case EasingFunctionTypes.QuadEaseIn:
                    var cH26 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuadEaseIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH26);
                    break;
                case EasingFunctionTypes.QuadEaseInOut:
                    var cH27 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuadEaseInOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH27);
                    break;
                case EasingFunctionTypes.QuadEaseOut:
                    var cH28 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuadEaseOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH28);
                    break;
                case EasingFunctionTypes.QuadEaseOutIn:
                    var cH29 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuadEaseOutIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH29);
                    break;
                case EasingFunctionTypes.QuartEaseIn:
                    var cH30 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuartEaseIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH30);
                    break;
                case EasingFunctionTypes.QuartEaseInOut:
                    var cH31 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuartEaseInOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH31);
                    break;
                case EasingFunctionTypes.QuartEaseOut:
                    var cH32 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuartEaseOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH32);
                    break;
                case EasingFunctionTypes.QuartEaseOutIn:
                    var cH33 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuartEaseOutIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH33);
                    break;
                case EasingFunctionTypes.QuintEaseIn:
                    var cH34 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuintEaseIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH34);
                    break;
                case EasingFunctionTypes.QuintEaseInOut:
                    var cH35 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuintEaseInOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH35);
                    break;
                case EasingFunctionTypes.QuintEaseOut:
                    var cH36 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuintEaseOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH36);
                    break;
                case EasingFunctionTypes.QuintEaseOutIn:
                    var cH37 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuintEaseOutIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH37);
                    break;
                case EasingFunctionTypes.SineEaseIn:
                    var cH38 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.SineEaseIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH38);
                    break;
                case EasingFunctionTypes.SineEaseInOut:
                    var cH39 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.SineEaseInOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH39);
                    break;
                case EasingFunctionTypes.SineEaseOut:
                    var cH40 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.SineEaseOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH40);
                    break;
                case EasingFunctionTypes.SineEaseOutIn:
                    var cH41 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.SineEaseOutIn, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH41);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(horizontal), horizontal, null);
            }


            //var cT1 = this.Control.Animate(new HorizontalFoldEffect(),
            //    EasingFunctions.CircEaseIn, this.MaxSize.Height, duration, this.Delay, Reverse, Loops);

            //var cT2 = this.Control.Animate(new VerticalFoldEffect(),
            //    EasingFunctions.CircEaseOut, this.MaxSize.Width, duration, this.Delay, Reverse, Loops);

            //_cancellationTokens.Add(cT1);
            //_cancellationTokens.Add(cT2);
        }

        /// <summary>
        /// Hides the specified horizontal.
        /// </summary>
        /// <param name="horizontal">The horizontal.</param>
        /// <param name="vertical">The vertical.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// horizontal - null
        /// or
        /// horizontal - null
        /// </exception>
        public void Hide(EasingFunctionTypes horizontal, EasingFunctionTypes vertical)
        {
            int duration = this.Duration;

            if (_cancellationTokens.Any(animation => !animation.IsCompleted))
            {
                var token = _cancellationTokens.First(animation => !animation.IsCompleted);
                duration = (int)(token.ElapsedMilliseconds);
            }

            //cancel show animation if in progress
            this.Cancel();

            switch (horizontal)
            {
                case EasingFunctionTypes.BackEaseIn:
                    var cH1 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BackEaseIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH1);
                    break;
                case EasingFunctionTypes.BackEaseInOut:
                    var cH2 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BackEaseInOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH2);
                    break;
                case EasingFunctionTypes.BackEaseOut:
                    var cH3 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BackEaseOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH3);
                    break;
                case EasingFunctionTypes.BackEaseOutIn:
                    var cH4 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BackEaseOutIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH4);
                    break;
                case EasingFunctionTypes.BounceEaseIn:
                    var cH5 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BounceEaseIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH5);
                    break;
                case EasingFunctionTypes.BounceEaseInOut:
                    var cH6 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BounceEaseInOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH6);
                    break;
                case EasingFunctionTypes.BounceEaseOut:
                    var cH7 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BounceEaseOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH7);
                    break;
                case EasingFunctionTypes.BounceEaseOutIn:
                    var cH8 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.BounceEaseOutIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH8);
                    break;
                case EasingFunctionTypes.CircEaseIn:
                    var cH9 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CircEaseIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH9);
                    break;
                case EasingFunctionTypes.CircEaseInOut:
                    var cH10 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CircEaseInOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH10);
                    break;
                case EasingFunctionTypes.CircEaseOut:
                    var cH11 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CircEaseOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH11);
                    break;
                case EasingFunctionTypes.CircEaseOutIn:
                    var cH12 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CircEaseOutIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH12);
                    break;
                case EasingFunctionTypes.CubicEaseIn:
                    var cH13 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CubicEaseIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH13);
                    break;
                case EasingFunctionTypes.CubicEaseInOut:
                    var cH14 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CubicEaseInOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH14);
                    break;
                case EasingFunctionTypes.CubicEaseOut:
                    var cH15 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CubicEaseOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH15);
                    break;
                case EasingFunctionTypes.CubicEaseOutIn:
                    var cH16 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.CubicEaseOutIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH16);
                    break;
                case EasingFunctionTypes.ElasticEaseIn:
                    var cH17 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ElasticEaseIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH17);
                    break;
                case EasingFunctionTypes.ElasticEaseInOut:
                    var cH18 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ElasticEaseInOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH18);
                    break;
                case EasingFunctionTypes.ElasticEaseOut:
                    var cH19 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ElasticEaseOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH19);
                    break;
                case EasingFunctionTypes.ElasticEaseOutIn:
                    var cH20 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ElasticEaseOutIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH20);
                    break;
                case EasingFunctionTypes.ExpoEaseIn:
                    var cH21 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ExpoEaseIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH21);
                    break;
                case EasingFunctionTypes.ExpoEaseInOut:
                    var cH22 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ExpoEaseInOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH22);
                    break;
                case EasingFunctionTypes.ExpoEaseOut:
                    var cH23 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ExpoEaseOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH23);
                    break;
                case EasingFunctionTypes.ExpoEaseOutIn:
                    var cH24 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.ExpoEaseOutIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH24);
                    break;
                case EasingFunctionTypes.Linear:
                    var cH25 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.Linear, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH25);
                    break;
                case EasingFunctionTypes.QuadEaseIn:
                    var cH26 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuadEaseIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH26);
                    break;
                case EasingFunctionTypes.QuadEaseInOut:
                    var cH27 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuadEaseInOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH27);
                    break;
                case EasingFunctionTypes.QuadEaseOut:
                    var cH28 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuadEaseOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH28);
                    break;
                case EasingFunctionTypes.QuadEaseOutIn:
                    var cH29 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuadEaseOutIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH29);
                    break;
                case EasingFunctionTypes.QuartEaseIn:
                    var cH30 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuartEaseIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH30);
                    break;
                case EasingFunctionTypes.QuartEaseInOut:
                    var cH31 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuartEaseInOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH31);
                    break;
                case EasingFunctionTypes.QuartEaseOut:
                    var cH32 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuartEaseOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH32);
                    break;
                case EasingFunctionTypes.QuartEaseOutIn:
                    var cH33 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuartEaseOutIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH33);
                    break;
                case EasingFunctionTypes.QuintEaseIn:
                    var cH34 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuintEaseIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH34);
                    break;
                case EasingFunctionTypes.QuintEaseInOut:
                    var cH35 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuintEaseInOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH35);
                    break;
                case EasingFunctionTypes.QuintEaseOut:
                    var cH36 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuintEaseOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH36);
                    break;
                case EasingFunctionTypes.QuintEaseOutIn:
                    var cH37 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.QuintEaseOutIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH37);
                    break;
                case EasingFunctionTypes.SineEaseIn:
                    var cH38 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.SineEaseIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH38);
                    break;
                case EasingFunctionTypes.SineEaseInOut:
                    var cH39 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.SineEaseInOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH39);
                    break;
                case EasingFunctionTypes.SineEaseOut:
                    var cH40 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.SineEaseOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH40);
                    break;
                case EasingFunctionTypes.SineEaseOutIn:
                    var cH41 = this.Control.Animate(new HorizontalFoldEffect(),
                        EasingFunctions.SineEaseOutIn, this.MinSize.Height, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH41);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(horizontal), horizontal, null);
            }

            switch (vertical)
            {
                case EasingFunctionTypes.BackEaseIn:
                    var cH1 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BackEaseIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH1);
                    break;
                case EasingFunctionTypes.BackEaseInOut:
                    var cH2 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BackEaseInOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH2);
                    break;
                case EasingFunctionTypes.BackEaseOut:
                    var cH3 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BackEaseOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH3);
                    break;
                case EasingFunctionTypes.BackEaseOutIn:
                    var cH4 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BackEaseOutIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH4);
                    break;
                case EasingFunctionTypes.BounceEaseIn:
                    var cH5 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BounceEaseIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH5);
                    break;
                case EasingFunctionTypes.BounceEaseInOut:
                    var cH6 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BounceEaseInOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH6);
                    break;
                case EasingFunctionTypes.BounceEaseOut:
                    var cH7 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BounceEaseOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH7);
                    break;
                case EasingFunctionTypes.BounceEaseOutIn:
                    var cH8 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.BounceEaseOutIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH8);
                    break;
                case EasingFunctionTypes.CircEaseIn:
                    var cH9 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CircEaseIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH9);
                    break;
                case EasingFunctionTypes.CircEaseInOut:
                    var cH10 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CircEaseInOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH10);
                    break;
                case EasingFunctionTypes.CircEaseOut:
                    var cH11 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CircEaseOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH11);
                    break;
                case EasingFunctionTypes.CircEaseOutIn:
                    var cH12 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CircEaseOutIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH12);
                    break;
                case EasingFunctionTypes.CubicEaseIn:
                    var cH13 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CubicEaseIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH13);
                    break;
                case EasingFunctionTypes.CubicEaseInOut:
                    var cH14 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CubicEaseInOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH14);
                    break;
                case EasingFunctionTypes.CubicEaseOut:
                    var cH15 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CubicEaseOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH15);
                    break;
                case EasingFunctionTypes.CubicEaseOutIn:
                    var cH16 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.CubicEaseOutIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH16);
                    break;
                case EasingFunctionTypes.ElasticEaseIn:
                    var cH17 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ElasticEaseIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH17);
                    break;
                case EasingFunctionTypes.ElasticEaseInOut:
                    var cH18 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ElasticEaseInOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH18);
                    break;
                case EasingFunctionTypes.ElasticEaseOut:
                    var cH19 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ElasticEaseOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH19);
                    break;
                case EasingFunctionTypes.ElasticEaseOutIn:
                    var cH20 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ElasticEaseOutIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH20);
                    break;
                case EasingFunctionTypes.ExpoEaseIn:
                    var cH21 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ExpoEaseIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH21);
                    break;
                case EasingFunctionTypes.ExpoEaseInOut:
                    var cH22 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ExpoEaseInOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH22);
                    break;
                case EasingFunctionTypes.ExpoEaseOut:
                    var cH23 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ExpoEaseOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH23);
                    break;
                case EasingFunctionTypes.ExpoEaseOutIn:
                    var cH24 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.ExpoEaseOutIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH24);
                    break;
                case EasingFunctionTypes.Linear:
                    var cH25 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.Linear, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH25);
                    break;
                case EasingFunctionTypes.QuadEaseIn:
                    var cH26 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuadEaseIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH26);
                    break;
                case EasingFunctionTypes.QuadEaseInOut:
                    var cH27 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuadEaseInOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH27);
                    break;
                case EasingFunctionTypes.QuadEaseOut:
                    var cH28 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuadEaseOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH28);
                    break;
                case EasingFunctionTypes.QuadEaseOutIn:
                    var cH29 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuadEaseOutIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH29);
                    break;
                case EasingFunctionTypes.QuartEaseIn:
                    var cH30 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuartEaseIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH30);
                    break;
                case EasingFunctionTypes.QuartEaseInOut:
                    var cH31 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuartEaseInOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH31);
                    break;
                case EasingFunctionTypes.QuartEaseOut:
                    var cH32 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuartEaseOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH32);
                    break;
                case EasingFunctionTypes.QuartEaseOutIn:
                    var cH33 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuartEaseOutIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH33);
                    break;
                case EasingFunctionTypes.QuintEaseIn:
                    var cH34 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuintEaseIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH34);
                    break;
                case EasingFunctionTypes.QuintEaseInOut:
                    var cH35 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuintEaseInOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH35);
                    break;
                case EasingFunctionTypes.QuintEaseOut:
                    var cH36 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuintEaseOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH36);
                    break;
                case EasingFunctionTypes.QuintEaseOutIn:
                    var cH37 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.QuintEaseOutIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH37);
                    break;
                case EasingFunctionTypes.SineEaseIn:
                    var cH38 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.SineEaseIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH38);
                    break;
                case EasingFunctionTypes.SineEaseInOut:
                    var cH39 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.SineEaseInOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH39);
                    break;
                case EasingFunctionTypes.SineEaseOut:
                    var cH40 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.SineEaseOut, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH40);
                    break;
                case EasingFunctionTypes.SineEaseOutIn:
                    var cH41 = this.Control.Animate(new VerticalFoldEffect(),
                        EasingFunctions.SineEaseOutIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);
                    _cancellationTokens.Add(cH41);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(horizontal), horizontal, null);
            }




            //var cT1 = this.Control.Animate(new HorizontalFoldEffect(),
            //    EasingFunctions.CircEaseOut, this.MinSize.Height, duration, this.Delay, Reverse, Loops);

            //var cT2 = this.Control.Animate(new VerticalFoldEffect(),
            //    EasingFunctions.CircEaseIn, this.MinSize.Width, duration, this.Delay, Reverse, Loops);

            //_cancellationTokens.Add(cT1);
            //_cancellationTokens.Add(cT2);
        }

        


        /// <summary>
        /// Cancels this instance.
        /// </summary>
        public void Cancel()
        {
            foreach (var token in _cancellationTokens)
                token.CancellationToken.Cancel();

            _cancellationTokens.Clear();
        }

    }
    #endregion
}
