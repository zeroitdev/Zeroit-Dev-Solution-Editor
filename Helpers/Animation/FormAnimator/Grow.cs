﻿using System.Drawing;

namespace ZeroitDevSolutionEditor.Helpers.Animations.FormAnimator
{

    /// <summary>
    /// Class Grow.
    /// </summary>
    public class Grow
    {
        /// <summary>
        /// The start
        /// </summary>
        private int start = 0;
        /// <summary>
        /// The end
        /// </summary>
        private int end = 100;

        /// <summary>
        /// The start point
        /// </summary>
        private Point startPoint = new Point(0, 0);
        /// <summary>
        /// The end point
        /// </summary>
        private Point endPoint = new Point(100, 100);

        /// <summary>
        /// The size
        /// </summary>
        private Size size = new Size(100, 00);
        /// <summary>
        /// The recalculate
        /// </summary>
        private bool recalculate = true;

        /// <summary>
        /// The fix window when grown
        /// </summary>
        private bool fixWindowWhenGrown = true;

        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>The start.</value>
        public int Start { get => start; set => start = value; }
        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>The end.</value>
        public int End { get => end; set => end = value; }
        /// <summary>
        /// Gets or sets a value indicating whether [fix window when grown].
        /// </summary>
        /// <value><c>true</c> if [fix window when grown]; otherwise, <c>false</c>.</value>
        public bool FixWindowWhenGrown { get => fixWindowWhenGrown; set => fixWindowWhenGrown = value; }
        /// <summary>
        /// Gets or sets the start point.
        /// </summary>
        /// <value>The start point.</value>
        public Point StartPoint { get => startPoint; set => startPoint = value; }
        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        /// <value>The end point.</value>
        public Point EndPoint { get => endPoint; set => endPoint = value; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public Size Size { get => size; set => size = value; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Grow"/> is recalculate.
        /// </summary>
        /// <value><c>true</c> if recalculate; otherwise, <c>false</c>.</value>
        public bool Recalculate { get => recalculate; set => recalculate = value; }
    }


}
