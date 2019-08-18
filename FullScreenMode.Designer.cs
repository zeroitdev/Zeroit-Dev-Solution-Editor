namespace ZeroitDevSolutionEditor
{
    partial class FullScreenMode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitFullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainBoard = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitFullScreenToolStripMenuItem,
            this.clearBoardToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 48);
            // 
            // exitFullScreenToolStripMenuItem
            // 
            this.exitFullScreenToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.exitFullScreenToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitFullScreenToolStripMenuItem.Name = "exitFullScreenToolStripMenuItem";
            this.exitFullScreenToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.exitFullScreenToolStripMenuItem.Text = "Exit Full Screen";
            this.exitFullScreenToolStripMenuItem.Click += new System.EventHandler(this.exitFullScreenToolStripMenuItem_Click);
            // 
            // clearBoardToolStripMenuItem
            // 
            this.clearBoardToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.clearBoardToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.clearBoardToolStripMenuItem.Name = "clearBoardToolStripMenuItem";
            this.clearBoardToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.clearBoardToolStripMenuItem.Text = "Clear Board";
            this.clearBoardToolStripMenuItem.Click += new System.EventHandler(this.clearBoardToolStripMenuItem_Click);
            // 
            // mainBoard
            // 
            this.mainBoard.BackColor = System.Drawing.Color.Transparent;
            this.mainBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainBoard.Location = new System.Drawing.Point(0, 0);
            this.mainBoard.Name = "mainBoard";
            this.mainBoard.Size = new System.Drawing.Size(1163, 784);
            this.mainBoard.TabIndex = 1;
            this.mainBoard.TabStop = false;
            this.mainBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingMouseDown);
            this.mainBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingMouseMove);
            this.mainBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawingMouseUp);
            // 
            // FullScreenMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 784);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.mainBoard);
            this.Name = "FullScreenMode";
            this.Text = "FullScreenMode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitFullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearBoardToolStripMenuItem;
        public System.Windows.Forms.PictureBox mainBoard;
    }
}