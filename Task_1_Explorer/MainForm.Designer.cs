namespace Task_1_Explorer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.treeView = new System.Windows.Forms.TreeView();
            this.listView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerCenter = new System.Windows.Forms.SplitContainer();
            this.labelTextFileOrDir = new System.Windows.Forms.Label();
            this.labelNameFileOrDir = new System.Windows.Forms.Label();
            this.labelNumberFilesInFolder = new System.Windows.Forms.Label();
            this.labelDateCreate = new System.Windows.Forms.Label();
            this.labelDateChange = new System.Windows.Forms.Label();
            this.labelDateCreateValue = new System.Windows.Forms.Label();
            this.labelDateChangeValue = new System.Windows.Forms.Label();
            this.labelSizeFile = new System.Windows.Forms.Label();
            this.labelSizeFileValue = new System.Windows.Forms.Label();
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCenter)).BeginInit();
            this.splitContainerCenter.Panel1.SuspendLayout();
            this.splitContainerCenter.Panel2.SuspendLayout();
            this.splitContainerCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.Panel1.SuspendLayout();
            this.splitContainerRight.Panel2.SuspendLayout();
            this.splitContainerRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(217, 621);
            this.treeView.TabIndex = 0;
            // 
            // listView
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(520, 547);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_ItemSelectionChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(741, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconToolStripMenuItem,
            this.smallIconToolStripMenuItem,
            this.tileToolStripMenuItem,
            this.listToolStripMenuItem,
            this.detailsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.viewToolStripMenuItem.Text = "Вид";
            // 
            // largeIconToolStripMenuItem
            // 
            this.largeIconToolStripMenuItem.Name = "largeIconToolStripMenuItem";
            this.largeIconToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.largeIconToolStripMenuItem.Text = "LargeIcon";
            this.largeIconToolStripMenuItem.Click += new System.EventHandler(this.largeIconToolStripMenuItem_Click);
            // 
            // smallIconToolStripMenuItem
            // 
            this.smallIconToolStripMenuItem.Name = "smallIconToolStripMenuItem";
            this.smallIconToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.smallIconToolStripMenuItem.Text = "SmallIcon";
            this.smallIconToolStripMenuItem.Click += new System.EventHandler(this.smallIconToolStripMenuItem_Click);
            // 
            // tileToolStripMenuItem
            // 
            this.tileToolStripMenuItem.Name = "tileToolStripMenuItem";
            this.tileToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.tileToolStripMenuItem.Text = "Tile";
            this.tileToolStripMenuItem.Click += new System.EventHandler(this.tileToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.listToolStripMenuItem.Text = "List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // splitContainerCenter
            // 
            this.splitContainerCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCenter.Location = new System.Drawing.Point(0, 24);
            this.splitContainerCenter.Name = "splitContainerCenter";
            // 
            // splitContainerCenter.Panel1
            // 
            this.splitContainerCenter.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainerCenter.Panel2
            // 
            this.splitContainerCenter.Panel2.Controls.Add(this.splitContainerRight);
            this.splitContainerCenter.Size = new System.Drawing.Size(741, 621);
            this.splitContainerCenter.SplitterDistance = 217;
            this.splitContainerCenter.TabIndex = 3;
            // 
            // labelTextFileOrDir
            // 
            this.labelTextFileOrDir.AutoSize = true;
            this.labelTextFileOrDir.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelTextFileOrDir.Location = new System.Drawing.Point(12, 28);
            this.labelTextFileOrDir.Name = "labelTextFileOrDir";
            this.labelTextFileOrDir.Size = new System.Drawing.Size(0, 13);
            this.labelTextFileOrDir.TabIndex = 3;
            // 
            // labelNameFileOrDir
            // 
            this.labelNameFileOrDir.AutoSize = true;
            this.labelNameFileOrDir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelNameFileOrDir.Location = new System.Drawing.Point(12, 13);
            this.labelNameFileOrDir.Name = "labelNameFileOrDir";
            this.labelNameFileOrDir.Size = new System.Drawing.Size(0, 13);
            this.labelNameFileOrDir.TabIndex = 2;
            // 
            // labelNumberFilesInFolder
            // 
            this.labelNumberFilesInFolder.AutoSize = true;
            this.labelNumberFilesInFolder.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelNumberFilesInFolder.Location = new System.Drawing.Point(12, 43);
            this.labelNumberFilesInFolder.Name = "labelNumberFilesInFolder";
            this.labelNumberFilesInFolder.Size = new System.Drawing.Size(0, 13);
            this.labelNumberFilesInFolder.TabIndex = 4;
            // 
            // labelDateCreate
            // 
            this.labelDateCreate.AutoSize = true;
            this.labelDateCreate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDateCreate.Location = new System.Drawing.Point(239, 13);
            this.labelDateCreate.Name = "labelDateCreate";
            this.labelDateCreate.Size = new System.Drawing.Size(87, 13);
            this.labelDateCreate.TabIndex = 5;
            this.labelDateCreate.Text = "Дата создания:";
            // 
            // labelDateChange
            // 
            this.labelDateChange.AutoSize = true;
            this.labelDateChange.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDateChange.Location = new System.Drawing.Point(239, 28);
            this.labelDateChange.Name = "labelDateChange";
            this.labelDateChange.Size = new System.Drawing.Size(93, 13);
            this.labelDateChange.TabIndex = 6;
            this.labelDateChange.Text = "Дата изменения:";
            // 
            // labelDateCreateValue
            // 
            this.labelDateCreateValue.AutoSize = true;
            this.labelDateCreateValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelDateCreateValue.Location = new System.Drawing.Point(328, 13);
            this.labelDateCreateValue.Name = "labelDateCreateValue";
            this.labelDateCreateValue.Size = new System.Drawing.Size(0, 13);
            this.labelDateCreateValue.TabIndex = 7;
            // 
            // labelDateChangeValue
            // 
            this.labelDateChangeValue.AutoSize = true;
            this.labelDateChangeValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelDateChangeValue.Location = new System.Drawing.Point(334, 28);
            this.labelDateChangeValue.Name = "labelDateChangeValue";
            this.labelDateChangeValue.Size = new System.Drawing.Size(0, 13);
            this.labelDateChangeValue.TabIndex = 8;
            // 
            // labelSizeFile
            // 
            this.labelSizeFile.AutoSize = true;
            this.labelSizeFile.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelSizeFile.Location = new System.Drawing.Point(240, 43);
            this.labelSizeFile.Name = "labelSizeFile";
            this.labelSizeFile.Size = new System.Drawing.Size(49, 13);
            this.labelSizeFile.TabIndex = 9;
            this.labelSizeFile.Text = "Размер: ";
            // 
            // labelSizeFileValue
            // 
            this.labelSizeFileValue.AutoSize = true;
            this.labelSizeFileValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelSizeFileValue.Location = new System.Drawing.Point(289, 43);
            this.labelSizeFileValue.Name = "labelSizeFileValue";
            this.labelSizeFileValue.Size = new System.Drawing.Size(0, 13);
            this.labelSizeFileValue.TabIndex = 10;
            // 
            // splitContainerRight
            // 
            this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRight.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRight.Name = "splitContainerRight";
            this.splitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRight.Panel1
            // 
            this.splitContainerRight.Panel1.Controls.Add(this.listView);
            // 
            // splitContainerRight.Panel2
            // 
            this.splitContainerRight.Panel2.Controls.Add(this.labelSizeFileValue);
            this.splitContainerRight.Panel2.Controls.Add(this.labelSizeFile);
            this.splitContainerRight.Panel2.Controls.Add(this.labelDateChange);
            this.splitContainerRight.Panel2.Controls.Add(this.labelDateChangeValue);
            this.splitContainerRight.Panel2.Controls.Add(this.labelNameFileOrDir);
            this.splitContainerRight.Panel2.Controls.Add(this.labelDateCreateValue);
            this.splitContainerRight.Panel2.Controls.Add(this.labelTextFileOrDir);
            this.splitContainerRight.Panel2.Controls.Add(this.labelDateCreate);
            this.splitContainerRight.Panel2.Controls.Add(this.labelNumberFilesInFolder);
            this.splitContainerRight.Size = new System.Drawing.Size(520, 621);
            this.splitContainerRight.SplitterDistance = 547;
            this.splitContainerRight.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 645);
            this.Controls.Add(this.splitContainerCenter);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Проводник";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainerCenter.Panel1.ResumeLayout(false);
            this.splitContainerCenter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCenter)).EndInit();
            this.splitContainerCenter.ResumeLayout(false);
            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel2.ResumeLayout(false);
            this.splitContainerRight.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerCenter;
        private System.Windows.Forms.Label labelNameFileOrDir;
        private System.Windows.Forms.Label labelTextFileOrDir;
        private System.Windows.Forms.Label labelNumberFilesInFolder;
        private System.Windows.Forms.Label labelDateCreate;
        private System.Windows.Forms.Label labelDateChangeValue;
        private System.Windows.Forms.Label labelDateCreateValue;
        private System.Windows.Forms.Label labelDateChange;
        private System.Windows.Forms.Label labelSizeFileValue;
        private System.Windows.Forms.Label labelSizeFile;
        private System.Windows.Forms.SplitContainer splitContainerRight;
    }
}

