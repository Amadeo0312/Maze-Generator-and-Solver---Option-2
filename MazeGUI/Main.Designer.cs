namespace MazeGUI
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.speedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slowestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.methodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SolveMethodDepthFirstSearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SolveMethodWallFollowerRightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SolveMethodWallFollowerLeftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recursiveBacktrackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depthFirstSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stepLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.solveToolStripMenuItem,
            this.generateToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(690, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.loadToolStripMenuItem.Text = "Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.FileLoadMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveAsToolStripMenuItem.Text = "Save";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.FileSaveMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.FileExitMenuItem_Click);
            // 
            // solveToolStripMenuItem
            // 
            this.solveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.stepToolStripMenuItem,
            this.toolStripSeparator1,
            this.speedToolStripMenuItem,
            this.methodToolStripMenuItem});
            this.solveToolStripMenuItem.Name = "solveToolStripMenuItem";
            this.solveToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.solveToolStripMenuItem.Text = "Solve";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.SolveStartMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.stopToolStripMenuItem.Text = "Pause";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.SolveStopMenuItem_Click);
            // 
            // stepToolStripMenuItem
            // 
            this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            this.stepToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.stepToolStripMenuItem.Text = "Step";
            this.stepToolStripMenuItem.Click += new System.EventHandler(this.SolveStepMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(112, 6);
            // 
            // speedToolStripMenuItem
            // 
            this.speedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fastestToolStripMenuItem,
            this.fastToolStripMenuItem,
            this.normalToolStripMenuItem,
            this.slowToolStripMenuItem,
            this.slowestToolStripMenuItem});
            this.speedToolStripMenuItem.Name = "speedToolStripMenuItem";
            this.speedToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.speedToolStripMenuItem.Text = "Speed";
            // 
            // fastestToolStripMenuItem
            // 
            this.fastestToolStripMenuItem.Checked = true;
            this.fastestToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fastestToolStripMenuItem.Name = "fastestToolStripMenuItem";
            this.fastestToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.fastestToolStripMenuItem.Tag = "";
            this.fastestToolStripMenuItem.Text = "Fastest";
            this.fastestToolStripMenuItem.Click += new System.EventHandler(this.ToggleMenuChecked);
            // 
            // fastToolStripMenuItem
            // 
            this.fastToolStripMenuItem.Name = "fastToolStripMenuItem";
            this.fastToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.fastToolStripMenuItem.Tag = "";
            this.fastToolStripMenuItem.Text = "Fast";
            this.fastToolStripMenuItem.Click += new System.EventHandler(this.ToggleMenuChecked);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.normalToolStripMenuItem.Tag = "";
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.ToggleMenuChecked);
            // 
            // slowToolStripMenuItem
            // 
            this.slowToolStripMenuItem.Name = "slowToolStripMenuItem";
            this.slowToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.slowToolStripMenuItem.Tag = "";
            this.slowToolStripMenuItem.Text = "Slow";
            this.slowToolStripMenuItem.Click += new System.EventHandler(this.ToggleMenuChecked);
            // 
            // slowestToolStripMenuItem
            // 
            this.slowestToolStripMenuItem.Name = "slowestToolStripMenuItem";
            this.slowestToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.slowestToolStripMenuItem.Tag = "";
            this.slowestToolStripMenuItem.Text = "Slowest";
            this.slowestToolStripMenuItem.Click += new System.EventHandler(this.ToggleMenuChecked);
            // 
            // methodToolStripMenuItem
            // 
            this.methodToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SolveMethodDepthFirstSearchMenuItem,
            this.SolveMethodWallFollowerRightMenuItem,
            this.SolveMethodWallFollowerLeftMenuItem,
            this.randomToolStripMenuItem});
            this.methodToolStripMenuItem.Name = "methodToolStripMenuItem";
            this.methodToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.methodToolStripMenuItem.Text = "Method";
            // 
            // SolveMethodDepthFirstSearchMenuItem
            // 
            this.SolveMethodDepthFirstSearchMenuItem.Checked = true;
            this.SolveMethodDepthFirstSearchMenuItem.CheckOnClick = true;
            this.SolveMethodDepthFirstSearchMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SolveMethodDepthFirstSearchMenuItem.Name = "SolveMethodDepthFirstSearchMenuItem";
            this.SolveMethodDepthFirstSearchMenuItem.Size = new System.Drawing.Size(182, 22);
            this.SolveMethodDepthFirstSearchMenuItem.Text = "Depth First Search";
            this.SolveMethodDepthFirstSearchMenuItem.Click += new System.EventHandler(this.ToggleMenuChecked);
            // 
            // SolveMethodWallFollowerRightMenuItem
            // 
            this.SolveMethodWallFollowerRightMenuItem.CheckOnClick = true;
            this.SolveMethodWallFollowerRightMenuItem.Name = "SolveMethodWallFollowerRightMenuItem";
            this.SolveMethodWallFollowerRightMenuItem.Size = new System.Drawing.Size(182, 22);
            this.SolveMethodWallFollowerRightMenuItem.Text = "Wall Follower (Right)";
            this.SolveMethodWallFollowerRightMenuItem.Click += new System.EventHandler(this.ToggleMenuChecked);
            // 
            // SolveMethodWallFollowerLeftMenuItem
            // 
            this.SolveMethodWallFollowerLeftMenuItem.CheckOnClick = true;
            this.SolveMethodWallFollowerLeftMenuItem.Name = "SolveMethodWallFollowerLeftMenuItem";
            this.SolveMethodWallFollowerLeftMenuItem.Size = new System.Drawing.Size(182, 22);
            this.SolveMethodWallFollowerLeftMenuItem.Text = "Wall Follower (Left)";
            this.SolveMethodWallFollowerLeftMenuItem.Click += new System.EventHandler(this.ToggleMenuChecked);
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.randomToolStripMenuItem.Text = "Random Mouse";
            this.randomToolStripMenuItem.Click += new System.EventHandler(this.ToggleMenuChecked);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recursiveBacktrackerToolStripMenuItem,
            this.depthFirstSearchToolStripMenuItem});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.generateToolStripMenuItem.Text = "Generate";
            // 
            // recursiveBacktrackerToolStripMenuItem
            // 
            this.recursiveBacktrackerToolStripMenuItem.Name = "recursiveBacktrackerToolStripMenuItem";
            this.recursiveBacktrackerToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.recursiveBacktrackerToolStripMenuItem.Text = "Recursive Backtracker";
            this.recursiveBacktrackerToolStripMenuItem.Click += new System.EventHandler(this.GenerateRecursiveBacktrackerMenuItem_Click);
            // 
            // depthFirstSearchToolStripMenuItem
            // 
            this.depthFirstSearchToolStripMenuItem.Name = "depthFirstSearchToolStripMenuItem";
            this.depthFirstSearchToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.depthFirstSearchToolStripMenuItem.Text = "Depth First Search";
            this.depthFirstSearchToolStripMenuItem.Click += new System.EventHandler(this.GenerateDepthFirstSearchMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.stepLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 552);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(690, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(675, 17);
            this.statusLabel.Spring = true;
            this.statusLabel.Text = "MazeGUI by avian";
            // 
            // stepLabel
            // 
            this.stepLabel.Name = "stepLabel";
            this.stepLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 574);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "Main";
            this.Text = "MazeGUI";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recursiveBacktrackerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depthFirstSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem speedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slowestToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem methodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SolveMethodDepthFirstSearchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SolveMethodWallFollowerRightMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SolveMethodWallFollowerLeftMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel stepLabel;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
    }
}

