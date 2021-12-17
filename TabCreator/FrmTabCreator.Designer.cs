namespace TabCreator
{
    partial class FrmTabCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTabCreator));
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewProject,
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.btnSave,
            this.btnExport});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // btnNewProject
            // 
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.btnNewProject.Size = new System.Drawing.Size(213, 22);
            this.btnNewProject.Text = "&New Project";
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenProject});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.btnOpenProject.Size = new System.Drawing.Size(186, 22);
            this.btnOpenProject.Text = "&Project";
            this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.saveAsToolStripMenuItem.Text = "&Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.btnSave.Size = new System.Drawing.Size(213, 22);
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.btnExport.Size = new System.Drawing.Size(213, 22);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(874, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appInfoToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // appInfoToolStripMenuItem
            // 
            this.appInfoToolStripMenuItem.Name = "appInfoToolStripMenuItem";
            this.appInfoToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.appInfoToolStripMenuItem.Text = "&App Info";
            this.appInfoToolStripMenuItem.Click += new System.EventHandler(this.appInfoToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(874, 25);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.TabIndex = 2;
            // 
            // FrmTabCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 733);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmTabCreator";
            this.ShowIcon = false;
            this.Text = "TabCreator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTabCreator_Load);
            this.MdiChildActivate += new System.EventHandler(this.FrmTabCreator_MdiChildActivate);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTabCreator_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmTabCreator_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnNewProject;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnOpenProject;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appInfoToolStripMenuItem;
    }
}

