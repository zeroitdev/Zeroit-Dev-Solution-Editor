using System.Windows.Forms;

namespace ZeroitDevSolutionEditor
{
    partial class Form1
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
            this.baseTheme1 = new ZeroitDevSolutionEditor.BaseTheme();
            this.noFlickerPanel2 = new ZeroitDevSolutionEditor.NoFlickerPanel();
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
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeBtn = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.board1 = new ZeroitDevSolutionEditor.NoFlickerPanel();
            this.changeSizeColorPanel = new ZeroitDevSolutionEditor.TransparentPanel();
            this.newPage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.brushSizeNumBtn = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.penSizeNumBtn = new System.Windows.Forms.NumericUpDown();
            this.canvasColorBtn = new System.Windows.Forms.Button();
            this.penColorBtn = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.baseTheme1.SuspendLayout();
            this.noFlickerPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.board1.SuspendLayout();
            this.changeSizeColorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeNumBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeNumBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // baseTheme1
            // 
            this.baseTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.baseTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.baseTheme1.Colors = new ZeroitDevSolutionEditor.Bloom[0];
            this.baseTheme1.Controls.Add(this.noFlickerPanel2);
            this.baseTheme1.Controls.Add(this.closeBtn);
            this.baseTheme1.Controls.Add(this.panelContainer);
            this.baseTheme1.Customization = "";
            this.baseTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTheme1.Font = new System.Drawing.Font("Verdana", 8F);
            this.baseTheme1.Image = null;
            this.baseTheme1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.baseTheme1.ImageSize = new System.Drawing.Size(0, 0);
            this.baseTheme1.Location = new System.Drawing.Point(0, 0);
            this.baseTheme1.Movable = true;
            this.baseTheme1.Name = "baseTheme1";
            this.baseTheme1.NoRounding = false;
            this.baseTheme1.ShowIcon = false;
            this.baseTheme1.ShowText = false;
            this.baseTheme1.Sizable = true;
            this.baseTheme1.Size = new System.Drawing.Size(1182, 776);
            this.baseTheme1.SmartBounds = true;
            this.baseTheme1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.baseTheme1.TabIndex = 0;
            this.baseTheme1.Text = "Solution Editor";
            this.baseTheme1.TextAlign = System.Drawing.StringAlignment.Center;
            this.baseTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.baseTheme1.Transparent = false;
            // 
            // noFlickerPanel2
            // 
            this.noFlickerPanel2.Controls.Add(this.menuStrip1);
            this.noFlickerPanel2.Location = new System.Drawing.Point(16, 28);
            this.noFlickerPanel2.Name = "noFlickerPanel2";
            this.noFlickerPanel2.Size = new System.Drawing.Size(1149, 32);
            this.noFlickerPanel2.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1149, 32);
            this.menuStrip1.TabIndex = 0;
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 28);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.saveAsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.penToolStripMenuItem,
            this.canvasToolStripMenuItem});
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 28);
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
            this.canvasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.canvasToolStripMenuItem.Name = "canvasToolStripMenuItem";
            this.canvasToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.canvasToolStripMenuItem.Text = "Canvas";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 28);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // closeBtn
            // 
            this.closeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(1161, 2);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(20, 20);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "x";
            this.closeBtn.UseCompatibleTextRendering = true;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.Controls.Add(this.board1);
            this.panelContainer.Location = new System.Drawing.Point(16, 66);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1154, 698);
            this.panelContainer.TabIndex = 0;
            // 
            // board1
            // 
            this.board1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.board1.Controls.Add(this.changeSizeColorPanel);
            this.board1.Location = new System.Drawing.Point(9, 27);
            this.board1.Name = "board1";
            this.board1.Size = new System.Drawing.Size(1136, 643);
            this.board1.TabIndex = 0;
            this.board1.Tag = "DrawingBoard";
            this.board1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick);
            this.board1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.board1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.board1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // changeSizeColorPanel
            // 
            this.changeSizeColorPanel.AllowTransparency = true;
            this.changeSizeColorPanel.BackColor = System.Drawing.Color.Transparent;
            this.changeSizeColorPanel.Border = 1F;
            this.changeSizeColorPanel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.changeSizeColorPanel.Controls.Add(this.newPage);
            this.changeSizeColorPanel.Controls.Add(this.label2);
            this.changeSizeColorPanel.Controls.Add(this.brushSizeNumBtn);
            this.changeSizeColorPanel.Controls.Add(this.label1);
            this.changeSizeColorPanel.Controls.Add(this.penSizeNumBtn);
            this.changeSizeColorPanel.Controls.Add(this.canvasColorBtn);
            this.changeSizeColorPanel.Controls.Add(this.penColorBtn);
            this.changeSizeColorPanel.Corners = 5F;
            this.changeSizeColorPanel.Location = new System.Drawing.Point(466, 235);
            this.changeSizeColorPanel.Name = "changeSizeColorPanel";
            this.changeSizeColorPanel.Size = new System.Drawing.Size(210, 121);
            this.changeSizeColorPanel.TabIndex = 0;
            this.changeSizeColorPanel.Visible = false;
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
            this.newPage.Text = "+";
            this.newPage.UseVisualStyleBackColor = true;
            this.newPage.Click += new System.EventHandler(this.newPage_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 776);
            this.Controls.Add(this.baseTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.baseTheme1.ResumeLayout(false);
            this.noFlickerPanel2.ResumeLayout(false);
            this.noFlickerPanel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            this.board1.ResumeLayout(false);
            this.changeSizeColorPanel.ResumeLayout(false);
            this.changeSizeColorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeNumBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeNumBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseTheme baseTheme1;
        private Panel panelContainer;
        private NoFlickerPanel board1;
        private Button closeBtn;
        private NoFlickerPanel noFlickerPanel2;
        private ColorDialog colorDialog;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem penToolStripMenuItem;
        private ToolStripMenuItem colorToolStripMenuItem;
        private ToolStripMenuItem sizeToolStripMenuItem;
        private ToolStripMenuItem canvasToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TransparentPanel changeSizeColorPanel;
        private Label label2;
        private NumericUpDown brushSizeNumBtn;
        private Label label1;
        private NumericUpDown penSizeNumBtn;
        private Button canvasColorBtn;
        private Button penColorBtn;
        private Button newPage;
    }
}

