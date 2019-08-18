using System.Windows.Forms;

namespace ZeroitDevSolutionEditor
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.board1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.brushSizeSmallNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.penSizeSmallNum = new System.Windows.Forms.NumericUpDown();
            this.canvasColorBelow = new System.Windows.Forms.Button();
            this.penColorBelow = new System.Windows.Forms.Button();
            this.rightScreenShotPanel = new ZeroitDevSolutionEditor.NoFlickerPanel();
            this.firstViewer = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neutralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.brushSizeNumBtn = new System.Windows.Forms.NumericUpDown();
            this.penSizeNumBtn = new System.Windows.Forms.NumericUpDown();
            this.canvasColorBtn = new System.Windows.Forms.Button();
            this.penColorBtn = new System.Windows.Forms.Button();
            this.newPage = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splineBtn = new System.Windows.Forms.Button();
            this.lineBtn = new System.Windows.Forms.Button();
            this.eraserBtn = new System.Windows.Forms.Button();
            this.penBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.penColorSmallBtn = new System.Windows.Forms.Button();
            this.canvasColorSmallBtn = new System.Windows.Forms.Button();
            this.triangleBtn = new System.Windows.Forms.Button();
            this.circleBtn = new System.Windows.Forms.Button();
            this.rectangleBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.boardsCtxtMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllBoardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minBtn = new System.Windows.Forms.Button();
            this.maxBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.board1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeSmallNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeSmallNum)).BeginInit();
            this.rightScreenShotPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.firstViewer)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeNumBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeNumBtn)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.boardsCtxtMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelContainer.Controls.Add(this.board1);
            this.panelContainer.Location = new System.Drawing.Point(60, 78);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(924, 601);
            this.panelContainer.TabIndex = 1;
            // 
            // board1
            // 
            this.board1.BackColor = System.Drawing.Color.Black;
            this.board1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.board1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.board1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.board1.Location = new System.Drawing.Point(0, 0);
            this.board1.Name = "board1";
            this.board1.Size = new System.Drawing.Size(924, 601);
            this.board1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.board1.TabIndex = 0;
            this.board1.TabStop = false;
            this.board1.Tag = "DrawingBoard";
            this.board1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawingMouseClick);
            this.board1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.board1_MouseDoubleClick);
            this.board1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingMouseDown);
            this.board1.MouseEnter += new System.EventHandler(this.board1_MouseEnter);
            this.board1.MouseLeave += new System.EventHandler(this.board1_MouseLeave);
            this.board1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingMouseMove);
            this.board1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawingMouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Eraser";
            // 
            // brushSizeSmallNum
            // 
            this.brushSizeSmallNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.brushSizeSmallNum.ForeColor = System.Drawing.Color.White;
            this.brushSizeSmallNum.Location = new System.Drawing.Point(6, 157);
            this.brushSizeSmallNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.brushSizeSmallNum.Name = "brushSizeSmallNum";
            this.brushSizeSmallNum.Size = new System.Drawing.Size(37, 21);
            this.brushSizeSmallNum.TabIndex = 17;
            this.brushSizeSmallNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.brushSizeSmallNum.ValueChanged += new System.EventHandler(this.brushSizeSmallNum_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Pen";
            // 
            // penSizeSmallNum
            // 
            this.penSizeSmallNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.penSizeSmallNum.ForeColor = System.Drawing.Color.White;
            this.penSizeSmallNum.Location = new System.Drawing.Point(7, 112);
            this.penSizeSmallNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.penSizeSmallNum.Name = "penSizeSmallNum";
            this.penSizeSmallNum.Size = new System.Drawing.Size(37, 21);
            this.penSizeSmallNum.TabIndex = 14;
            this.penSizeSmallNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.penSizeSmallNum.ValueChanged += new System.EventHandler(this.penSizeSmallNum_ValueChanged);
            // 
            // canvasColorBelow
            // 
            this.canvasColorBelow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.canvasColorBelow.BackColor = System.Drawing.Color.Cyan;
            this.canvasColorBelow.FlatAppearance.BorderSize = 0;
            this.canvasColorBelow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canvasColorBelow.Font = new System.Drawing.Font("Verdana", 6F);
            this.canvasColorBelow.ForeColor = System.Drawing.Color.White;
            this.canvasColorBelow.Location = new System.Drawing.Point(10, 79);
            this.canvasColorBelow.Name = "canvasColorBelow";
            this.canvasColorBelow.Size = new System.Drawing.Size(23, 5);
            this.canvasColorBelow.TabIndex = 12;
            this.canvasColorBelow.UseCompatibleTextRendering = true;
            this.canvasColorBelow.UseVisualStyleBackColor = false;
            // 
            // penColorBelow
            // 
            this.penColorBelow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.penColorBelow.BackColor = System.Drawing.Color.Red;
            this.penColorBelow.FlatAppearance.BorderSize = 0;
            this.penColorBelow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.penColorBelow.Font = new System.Drawing.Font("Verdana", 6F);
            this.penColorBelow.ForeColor = System.Drawing.Color.White;
            this.penColorBelow.Location = new System.Drawing.Point(8, 28);
            this.penColorBelow.Name = "penColorBelow";
            this.penColorBelow.Size = new System.Drawing.Size(23, 5);
            this.penColorBelow.TabIndex = 9;
            this.penColorBelow.UseCompatibleTextRendering = true;
            this.penColorBelow.UseVisualStyleBackColor = false;
            // 
            // rightScreenShotPanel
            // 
            this.rightScreenShotPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rightScreenShotPanel.AutoScroll = true;
            this.rightScreenShotPanel.BackColor = System.Drawing.Color.Transparent;
            this.rightScreenShotPanel.Controls.Add(this.firstViewer);
            this.rightScreenShotPanel.Location = new System.Drawing.Point(990, 78);
            this.rightScreenShotPanel.Name = "rightScreenShotPanel";
            this.rightScreenShotPanel.Size = new System.Drawing.Size(249, 601);
            this.rightScreenShotPanel.TabIndex = 1;
            // 
            // firstViewer
            // 
            this.firstViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstViewer.Location = new System.Drawing.Point(3, 0);
            this.firstViewer.Name = "firstViewer";
            this.firstViewer.Size = new System.Drawing.Size(215, 122);
            this.firstViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.firstViewer.TabIndex = 0;
            this.firstViewer.TabStop = false;
            this.firstViewer.Tag = "RightPictureBox";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(19, 38);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(173, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.saveAsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.penToolStripMenuItem,
            this.canvasToolStripMenuItem});
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // penToolStripMenuItem
            // 
            this.penToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.penToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.sizeToolStripMenuItem});
            this.penToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.penToolStripMenuItem.Name = "penToolStripMenuItem";
            this.penToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.penToolStripMenuItem.Text = "Pen";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.colorToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.colorToolStripMenuItem.Text = "Color";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.sizeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.sizeToolStripMenuItem.Text = "Size";
            // 
            // canvasToolStripMenuItem
            // 
            this.canvasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.canvasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem1});
            this.canvasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.canvasToolStripMenuItem.Name = "canvasToolStripMenuItem";
            this.canvasToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.canvasToolStripMenuItem.Text = "Canvas";
            // 
            // colorToolStripMenuItem1
            // 
            this.colorToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.colorToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.colorToolStripMenuItem1.Name = "colorToolStripMenuItem1";
            this.colorToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.colorToolStripMenuItem1.Text = "Color";
            this.colorToolStripMenuItem1.Click += new System.EventHandler(this.colorToolStripMenuItem1_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenToolStripMenuItem,
            this.themeToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.fullScreenToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.fullScreenToolStripMenuItem.Text = "Full Screen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackBoardToolStripMenuItem,
            this.whiteBoardToolStripMenuItem,
            this.neutralToolStripMenuItem});
            this.themeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // blackBoardToolStripMenuItem
            // 
            this.blackBoardToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.blackBoardToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.blackBoardToolStripMenuItem.Name = "blackBoardToolStripMenuItem";
            this.blackBoardToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.blackBoardToolStripMenuItem.Text = "Black Board";
            this.blackBoardToolStripMenuItem.Click += new System.EventHandler(this.blackBoardToolStripMenuItem_Click);
            // 
            // whiteBoardToolStripMenuItem
            // 
            this.whiteBoardToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.whiteBoardToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.whiteBoardToolStripMenuItem.Name = "whiteBoardToolStripMenuItem";
            this.whiteBoardToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.whiteBoardToolStripMenuItem.Text = "White Board";
            this.whiteBoardToolStripMenuItem.Click += new System.EventHandler(this.whiteBoardToolStripMenuItem_Click);
            // 
            // neutralToolStripMenuItem
            // 
            this.neutralToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.neutralToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.neutralToolStripMenuItem.Name = "neutralToolStripMenuItem";
            this.neutralToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.neutralToolStripMenuItem.Text = "Neutral";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pen \r\nSize";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(112, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Brush \r\nSize";
            // 
            // brushSizeNumBtn
            // 
            this.brushSizeNumBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.brushSizeNumBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brushSizeNumBtn.ForeColor = System.Drawing.Color.White;
            this.brushSizeNumBtn.Location = new System.Drawing.Point(162, 56);
            this.brushSizeNumBtn.Name = "brushSizeNumBtn";
            this.brushSizeNumBtn.Size = new System.Drawing.Size(39, 20);
            this.brushSizeNumBtn.TabIndex = 5;
            // 
            // penSizeNumBtn
            // 
            this.penSizeNumBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.penSizeNumBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.penSizeNumBtn.ForeColor = System.Drawing.Color.White;
            this.penSizeNumBtn.Location = new System.Drawing.Point(60, 56);
            this.penSizeNumBtn.Name = "penSizeNumBtn";
            this.penSizeNumBtn.Size = new System.Drawing.Size(39, 20);
            this.penSizeNumBtn.TabIndex = 2;
            // 
            // canvasColorBtn
            // 
            this.canvasColorBtn.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.canvasColorBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.canvasColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canvasColorBtn.Font = new System.Drawing.Font("Verdana", 7F);
            this.canvasColorBtn.ForeColor = System.Drawing.Color.White;
            this.canvasColorBtn.Location = new System.Drawing.Point(114, 6);
            this.canvasColorBtn.Name = "canvasColorBtn";
            this.canvasColorBtn.Size = new System.Drawing.Size(86, 35);
            this.canvasColorBtn.TabIndex = 1;
            this.canvasColorBtn.Text = "Canvas Color";
            this.canvasColorBtn.UseVisualStyleBackColor = true;
            this.canvasColorBtn.Click += new System.EventHandler(this.canvasColorBtn_Click);
            // 
            // penColorBtn
            // 
            this.penColorBtn.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.penColorBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.penColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.penColorBtn.Font = new System.Drawing.Font("Verdana", 7F);
            this.penColorBtn.ForeColor = System.Drawing.Color.White;
            this.penColorBtn.Location = new System.Drawing.Point(12, 6);
            this.penColorBtn.Name = "penColorBtn";
            this.penColorBtn.Size = new System.Drawing.Size(86, 35);
            this.penColorBtn.TabIndex = 0;
            this.penColorBtn.Text = "Pen Color";
            this.penColorBtn.UseVisualStyleBackColor = true;
            this.penColorBtn.Click += new System.EventHandler(this.penColorBtn_Click);
            // 
            // newPage
            // 
            this.newPage.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.newPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.newPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newPage.Font = new System.Drawing.Font("Verdana", 7F);
            this.newPage.ForeColor = System.Drawing.Color.White;
            this.newPage.Location = new System.Drawing.Point(13, 90);
            this.newPage.Name = "newPage";
            this.newPage.Size = new System.Drawing.Size(186, 23);
            this.newPage.TabIndex = 7;
            this.newPage.Text = "Clear Board";
            this.newPage.UseVisualStyleBackColor = true;
            this.newPage.Click += new System.EventHandler(this.newPage_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.splineBtn);
            this.panel2.Controls.Add(this.lineBtn);
            this.panel2.Controls.Add(this.eraserBtn);
            this.panel2.Controls.Add(this.penBtn);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.triangleBtn);
            this.panel2.Controls.Add(this.circleBtn);
            this.panel2.Controls.Add(this.rectangleBtn);
            this.panel2.Location = new System.Drawing.Point(3, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(54, 601);
            this.panel2.TabIndex = 21;
            // 
            // splineBtn
            // 
            this.splineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.splineBtn.BackColor = System.Drawing.Color.Transparent;
            this.splineBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.splineBtn.FlatAppearance.BorderSize = 0;
            this.splineBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.splineBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.splineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.splineBtn.Font = new System.Drawing.Font("Verdana", 6F);
            this.splineBtn.ForeColor = System.Drawing.Color.White;
            this.splineBtn.Image = ((System.Drawing.Image)(resources.GetObject("splineBtn.Image")));
            this.splineBtn.Location = new System.Drawing.Point(4, 351);
            this.splineBtn.Name = "splineBtn";
            this.splineBtn.Size = new System.Drawing.Size(44, 39);
            this.splineBtn.TabIndex = 25;
            this.splineBtn.UseCompatibleTextRendering = true;
            this.splineBtn.UseVisualStyleBackColor = false;
            this.splineBtn.Click += new System.EventHandler(this.splineBtn_Click);
            // 
            // lineBtn
            // 
            this.lineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineBtn.BackColor = System.Drawing.Color.Transparent;
            this.lineBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lineBtn.FlatAppearance.BorderSize = 0;
            this.lineBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.lineBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.lineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lineBtn.Font = new System.Drawing.Font("Verdana", 6F);
            this.lineBtn.ForeColor = System.Drawing.Color.White;
            this.lineBtn.Image = global::ZeroitDevSolutionEditor.Properties.Resources.line_40;
            this.lineBtn.Location = new System.Drawing.Point(4, 293);
            this.lineBtn.Name = "lineBtn";
            this.lineBtn.Size = new System.Drawing.Size(44, 39);
            this.lineBtn.TabIndex = 24;
            this.lineBtn.UseCompatibleTextRendering = true;
            this.lineBtn.UseVisualStyleBackColor = false;
            this.lineBtn.Click += new System.EventHandler(this.lineBtn_Click);
            // 
            // eraserBtn
            // 
            this.eraserBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eraserBtn.BackColor = System.Drawing.Color.Transparent;
            this.eraserBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eraserBtn.FlatAppearance.BorderSize = 0;
            this.eraserBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.eraserBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.eraserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eraserBtn.Font = new System.Drawing.Font("Verdana", 6F);
            this.eraserBtn.ForeColor = System.Drawing.Color.White;
            this.eraserBtn.Image = global::ZeroitDevSolutionEditor.Properties.Resources.eraser_40;
            this.eraserBtn.Location = new System.Drawing.Point(4, 61);
            this.eraserBtn.Name = "eraserBtn";
            this.eraserBtn.Size = new System.Drawing.Size(44, 39);
            this.eraserBtn.TabIndex = 19;
            this.eraserBtn.UseCompatibleTextRendering = true;
            this.eraserBtn.UseVisualStyleBackColor = false;
            this.eraserBtn.Click += new System.EventHandler(this.eraserBtn_Click);
            // 
            // penBtn
            // 
            this.penBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.penBtn.BackColor = System.Drawing.Color.Transparent;
            this.penBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.penBtn.FlatAppearance.BorderSize = 0;
            this.penBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.penBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.penBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.penBtn.Font = new System.Drawing.Font("Verdana", 6F);
            this.penBtn.ForeColor = System.Drawing.Color.White;
            this.penBtn.Image = global::ZeroitDevSolutionEditor.Properties.Resources.pen_40;
            this.penBtn.Location = new System.Drawing.Point(4, 3);
            this.penBtn.Name = "penBtn";
            this.penBtn.Size = new System.Drawing.Size(44, 39);
            this.penBtn.TabIndex = 20;
            this.penBtn.UseCompatibleTextRendering = true;
            this.penBtn.UseVisualStyleBackColor = false;
            this.penBtn.Click += new System.EventHandler(this.penBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.penColorSmallBtn);
            this.panel3.Controls.Add(this.penColorBelow);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.canvasColorSmallBtn);
            this.panel3.Controls.Add(this.brushSizeSmallNum);
            this.panel3.Controls.Add(this.canvasColorBelow);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.penSizeSmallNum);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 418);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(52, 181);
            this.panel3.TabIndex = 1;
            // 
            // penColorSmallBtn
            // 
            this.penColorSmallBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.penColorSmallBtn.BackColor = System.Drawing.Color.Transparent;
            this.penColorSmallBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.penColorSmallBtn.FlatAppearance.BorderSize = 0;
            this.penColorSmallBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.penColorSmallBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.penColorSmallBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.penColorSmallBtn.Font = new System.Drawing.Font("Verdana", 6F);
            this.penColorSmallBtn.ForeColor = System.Drawing.Color.White;
            this.penColorSmallBtn.Image = global::ZeroitDevSolutionEditor.Properties.Resources.pen;
            this.penColorSmallBtn.Location = new System.Drawing.Point(9, 7);
            this.penColorSmallBtn.Name = "penColorSmallBtn";
            this.penColorSmallBtn.Size = new System.Drawing.Size(20, 14);
            this.penColorSmallBtn.TabIndex = 11;
            this.penColorSmallBtn.UseCompatibleTextRendering = true;
            this.penColorSmallBtn.UseVisualStyleBackColor = false;
            this.penColorSmallBtn.Click += new System.EventHandler(this.penColorSmallBtn_Click);
            // 
            // canvasColorSmallBtn
            // 
            this.canvasColorSmallBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.canvasColorSmallBtn.BackColor = System.Drawing.Color.Transparent;
            this.canvasColorSmallBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.canvasColorSmallBtn.FlatAppearance.BorderSize = 0;
            this.canvasColorSmallBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.canvasColorSmallBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.canvasColorSmallBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canvasColorSmallBtn.Font = new System.Drawing.Font("Verdana", 6F);
            this.canvasColorSmallBtn.ForeColor = System.Drawing.Color.White;
            this.canvasColorSmallBtn.Image = global::ZeroitDevSolutionEditor.Properties.Resources.board;
            this.canvasColorSmallBtn.Location = new System.Drawing.Point(11, 53);
            this.canvasColorSmallBtn.Name = "canvasColorSmallBtn";
            this.canvasColorSmallBtn.Size = new System.Drawing.Size(20, 26);
            this.canvasColorSmallBtn.TabIndex = 13;
            this.canvasColorSmallBtn.UseCompatibleTextRendering = true;
            this.canvasColorSmallBtn.UseVisualStyleBackColor = false;
            this.canvasColorSmallBtn.Click += new System.EventHandler(this.canvasColorSmallBtn_Click);
            // 
            // triangleBtn
            // 
            this.triangleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.triangleBtn.BackColor = System.Drawing.Color.Transparent;
            this.triangleBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.triangleBtn.FlatAppearance.BorderSize = 0;
            this.triangleBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.triangleBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.triangleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.triangleBtn.Font = new System.Drawing.Font("Verdana", 6F);
            this.triangleBtn.ForeColor = System.Drawing.Color.White;
            this.triangleBtn.Image = global::ZeroitDevSolutionEditor.Properties.Resources.triangle_40;
            this.triangleBtn.Location = new System.Drawing.Point(3, 235);
            this.triangleBtn.Name = "triangleBtn";
            this.triangleBtn.Size = new System.Drawing.Size(44, 39);
            this.triangleBtn.TabIndex = 23;
            this.triangleBtn.UseCompatibleTextRendering = true;
            this.triangleBtn.UseVisualStyleBackColor = false;
            this.triangleBtn.Click += new System.EventHandler(this.triangleBtn_Click);
            // 
            // circleBtn
            // 
            this.circleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.circleBtn.BackColor = System.Drawing.Color.Transparent;
            this.circleBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.circleBtn.FlatAppearance.BorderSize = 0;
            this.circleBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.circleBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.circleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circleBtn.Font = new System.Drawing.Font("Verdana", 6F);
            this.circleBtn.ForeColor = System.Drawing.Color.White;
            this.circleBtn.Image = global::ZeroitDevSolutionEditor.Properties.Resources.circle_40;
            this.circleBtn.Location = new System.Drawing.Point(2, 177);
            this.circleBtn.Name = "circleBtn";
            this.circleBtn.Size = new System.Drawing.Size(44, 39);
            this.circleBtn.TabIndex = 22;
            this.circleBtn.UseCompatibleTextRendering = true;
            this.circleBtn.UseVisualStyleBackColor = false;
            this.circleBtn.Click += new System.EventHandler(this.circleBtn_Click);
            // 
            // rectangleBtn
            // 
            this.rectangleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rectangleBtn.BackColor = System.Drawing.Color.Transparent;
            this.rectangleBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rectangleBtn.FlatAppearance.BorderSize = 0;
            this.rectangleBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rectangleBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rectangleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rectangleBtn.Font = new System.Drawing.Font("Verdana", 6F);
            this.rectangleBtn.ForeColor = System.Drawing.Color.White;
            this.rectangleBtn.Image = global::ZeroitDevSolutionEditor.Properties.Resources.rectangle_40;
            this.rectangleBtn.Location = new System.Drawing.Point(1, 119);
            this.rectangleBtn.Name = "rectangleBtn";
            this.rectangleBtn.Size = new System.Drawing.Size(44, 39);
            this.rectangleBtn.TabIndex = 21;
            this.rectangleBtn.UseCompatibleTextRendering = true;
            this.rectangleBtn.UseVisualStyleBackColor = false;
            this.rectangleBtn.Click += new System.EventHandler(this.rectangleBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Xml Files|*.xml";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Xml Files|*.xml";
            // 
            // boardsCtxtMenuStrip
            // 
            this.boardsCtxtMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.clearAllBoardsToolStripMenuItem});
            this.boardsCtxtMenuStrip.Name = "boardsCtxtMenuStrip";
            this.boardsCtxtMenuStrip.Size = new System.Drawing.Size(158, 48);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.removeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // clearAllBoardsToolStripMenuItem
            // 
            this.clearAllBoardsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.clearAllBoardsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.clearAllBoardsToolStripMenuItem.Name = "clearAllBoardsToolStripMenuItem";
            this.clearAllBoardsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.clearAllBoardsToolStripMenuItem.Text = "Clear All Boards";
            this.clearAllBoardsToolStripMenuItem.Click += new System.EventHandler(this.clearAllBoardsToolStripMenuItem_Click);
            // 
            // minBtn
            // 
            this.minBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minBtn.BackColor = System.Drawing.Color.Transparent;
            this.minBtn.FlatAppearance.BorderSize = 0;
            this.minBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.minBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.minBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minBtn.Font = new System.Drawing.Font("Verdana", 6F);
            this.minBtn.ForeColor = System.Drawing.Color.White;
            this.minBtn.Image = global::ZeroitDevSolutionEditor.Properties.Resources.min;
            this.minBtn.Location = new System.Drawing.Point(1158, 6);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(23, 20);
            this.minBtn.TabIndex = 8;
            this.minBtn.UseCompatibleTextRendering = true;
            this.minBtn.UseVisualStyleBackColor = false;
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            // 
            // maxBtn
            // 
            this.maxBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxBtn.BackColor = System.Drawing.Color.Transparent;
            this.maxBtn.FlatAppearance.BorderSize = 0;
            this.maxBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.maxBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.maxBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maxBtn.Font = new System.Drawing.Font("Verdana", 5F);
            this.maxBtn.ForeColor = System.Drawing.Color.White;
            this.maxBtn.Image = global::ZeroitDevSolutionEditor.Properties.Resources.max;
            this.maxBtn.Location = new System.Drawing.Point(1187, 6);
            this.maxBtn.Name = "maxBtn";
            this.maxBtn.Size = new System.Drawing.Size(23, 20);
            this.maxBtn.TabIndex = 7;
            this.maxBtn.UseCompatibleTextRendering = true;
            this.maxBtn.UseVisualStyleBackColor = false;
            this.maxBtn.Click += new System.EventHandler(this.maxBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Image = global::ZeroitDevSolutionEditor.Properties.Resources.close;
            this.closeBtn.Location = new System.Drawing.Point(1216, 6);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(23, 20);
            this.closeBtn.TabIndex = 6;
            this.closeBtn.UseCompatibleTextRendering = true;
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 6F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::ZeroitDevSolutionEditor.Properties.Resources.arrow_left_16;
            this.button1.Location = new System.Drawing.Point(3, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 14);
            this.button1.TabIndex = 26;
            this.button1.UseCompatibleTextRendering = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.leftShiftBtn_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 6F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::ZeroitDevSolutionEditor.Properties.Resources.arrow_right_16;
            this.button2.Location = new System.Drawing.Point(1212, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 14);
            this.button2.TabIndex = 27;
            this.button2.UseCompatibleTextRendering = true;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.rightShiftBtn_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Verdana", 8F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(425, 682);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(375, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Copyright © 2019 Zeroit Dev Technologies. All Rights Reserved.";
            // 
            // Main
            // 
            this.AnimOrientation = ZeroitDevSolutionEditor.FormStyler.AnimationOrientation.Both;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 698);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.minBtn);
            this.Controls.Add(this.maxBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rightScreenShotPanel);
            this.Corners = 10F;
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.ShowIcon = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Zeroit Board";
            this.TextAlign = System.Drawing.StringAlignment.Near;
            this.Load += new System.EventHandler(this.Main_Load);
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.board1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeSmallNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeSmallNum)).EndInit();
            this.rightScreenShotPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.firstViewer)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeNumBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeNumBtn)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.boardsCtxtMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.PictureBox board1;
        private NoFlickerPanel rightScreenShotPanel;
        private System.Windows.Forms.PictureBox firstViewer;
        private System.Windows.Forms.Button minBtn;
        private System.Windows.Forms.Button maxBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog;
        private Label label2;
        private NumericUpDown brushSizeNumBtn;
        private Label label1;
        private NumericUpDown penSizeNumBtn;
        private Button canvasColorBtn;
        private Button penColorBtn;
        private Button newPage;
        private ToolStripMenuItem colorToolStripMenuItem1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem fullScreenToolStripMenuItem;
        private Button penColorSmallBtn;
        private Button penColorBelow;
        private Button canvasColorSmallBtn;
        private Button canvasColorBelow;
        private Label label4;
        private NumericUpDown brushSizeSmallNum;
        private Label label3;
        private NumericUpDown penSizeSmallNum;
        private Button eraserBtn;
        private Button penBtn;
        private Panel panel2;
        private Button triangleBtn;
        private Button circleBtn;
        private Button rectangleBtn;
        private Panel panel3;
        private Button splineBtn;
        private Button lineBtn;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private ContextMenuStrip boardsCtxtMenuStrip;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripMenuItem clearAllBoardsToolStripMenuItem;
        private ToolStripMenuItem themeToolStripMenuItem;
        private Button button1;
        private Button button2;
        private ToolStripMenuItem blackBoardToolStripMenuItem;
        private ToolStripMenuItem whiteBoardToolStripMenuItem;
        private ToolStripMenuItem neutralToolStripMenuItem;
        private ImageList imageList1;
        private Label label5;
    }
}