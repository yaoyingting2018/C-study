namespace documentwrite
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.zongTreeView = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.designTreeView = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.testTreeView = new System.Windows.Forms.TreeView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ylTreeView = new System.Windows.Forms.TreeView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.reportTreeView = new System.Windows.Forms.TreeView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.addRoot = new DevExpress.XtraBars.BarButtonItem();
            this.addNode = new DevExpress.XtraBars.BarButtonItem();
            this.editNode = new DevExpress.XtraBars.BarButtonItem();
            this.deleteNode = new DevExpress.XtraBars.BarButtonItem();
            this.deleteAll = new DevExpress.XtraBars.BarButtonItem();
            this.saveTreeNode = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.openButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.saveButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.saveAs = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.Status_bsti = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Location = new System.Drawing.Point(21, 54);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(337, 663);
            this.tabControl.TabIndex = 2;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.zongTreeView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(329, 637);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "总关系";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // zongTreeView
            // 
            this.zongTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.zongTreeView.Location = new System.Drawing.Point(0, 0);
            this.zongTreeView.Name = "zongTreeView";
            this.zongTreeView.Size = new System.Drawing.Size(329, 637);
            this.zongTreeView.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.designTreeView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(329, 637);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设计需求";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // designTreeView
            // 
            this.designTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.designTreeView.Location = new System.Drawing.Point(0, 0);
            this.designTreeView.Name = "designTreeView";
            this.designTreeView.Size = new System.Drawing.Size(329, 637);
            this.designTreeView.TabIndex = 3;
            this.designTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.designTreeView_AfterSelect);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.testTreeView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(329, 637);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "测试需求";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // testTreeView
            // 
            this.testTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.testTreeView.Location = new System.Drawing.Point(0, 0);
            this.testTreeView.Name = "testTreeView";
            this.testTreeView.Size = new System.Drawing.Size(329, 637);
            this.testTreeView.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ylTreeView);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(329, 637);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "测试说明";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ylTreeView
            // 
            this.ylTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ylTreeView.Location = new System.Drawing.Point(0, 0);
            this.ylTreeView.Name = "ylTreeView";
            this.ylTreeView.Size = new System.Drawing.Size(329, 637);
            this.ylTreeView.TabIndex = 3;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.reportTreeView);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(329, 637);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "问题报告";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // reportTreeView
            // 
            this.reportTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.reportTreeView.Location = new System.Drawing.Point(0, 0);
            this.reportTreeView.Name = "reportTreeView";
            this.reportTreeView.Size = new System.Drawing.Size(329, 637);
            this.reportTreeView.TabIndex = 2;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.openButtonItem,
            this.addRoot,
            this.saveButtonItem,
            this.addNode,
            this.deleteAll,
            this.editNode,
            this.deleteNode,
            this.saveTreeNode,
            this.saveAs,
            this.Status_bsti});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 11;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.addRoot),
            new DevExpress.XtraBars.LinkPersistInfo(this.addNode),
            new DevExpress.XtraBars.LinkPersistInfo(this.editNode),
            new DevExpress.XtraBars.LinkPersistInfo(this.deleteNode),
            new DevExpress.XtraBars.LinkPersistInfo(this.deleteAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.saveTreeNode)});
            this.bar1.Text = "Tools";
            // 
            // addRoot
            // 
            this.addRoot.Hint = "添加根节点";
            this.addRoot.Id = 2;
            this.addRoot.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("addRoot.ImageOptions.Image")));
            this.addRoot.Name = "addRoot";
            this.addRoot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addRoot_ItemClick);
            // 
            // addNode
            // 
            this.addNode.Hint = "添加子节点";
            this.addNode.Id = 4;
            this.addNode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("addNode.ImageOptions.Image")));
            this.addNode.Name = "addNode";
            this.addNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addNode_ItemClick);
            // 
            // editNode
            // 
            this.editNode.Hint = "edit node";
            this.editNode.Id = 6;
            this.editNode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("editNode.ImageOptions.Image")));
            this.editNode.Name = "editNode";
            this.editNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.editNode_ItemClick);
            // 
            // deleteNode
            // 
            this.deleteNode.Hint = "delete node";
            this.deleteNode.Id = 7;
            this.deleteNode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("deleteNode.ImageOptions.Image")));
            this.deleteNode.Name = "deleteNode";
            this.deleteNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.deleteNode_ItemClick);
            // 
            // deleteAll
            // 
            this.deleteAll.Hint = "clear all node";
            this.deleteAll.Id = 5;
            this.deleteAll.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("deleteAll.ImageOptions.Image")));
            this.deleteAll.Name = "deleteAll";
            this.deleteAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.deleteAll_ItemClick);
            // 
            // saveTreeNode
            // 
            this.saveTreeNode.Hint = "save node ";
            this.saveTreeNode.Id = 8;
            this.saveTreeNode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("saveTreeNode.ImageOptions.Image")));
            this.saveTreeNode.Name = "saveTreeNode";
            this.saveTreeNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.saveTreeNode_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, this.barSubItem1, "&File")});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Id = 0;
            this.barSubItem1.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.barSubItem1.ImageOptions.AllowStubGlyph = DevExpress.Utils.DefaultBoolean.True;
            this.barSubItem1.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.DisabledImage")));
            this.barSubItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.Image")));
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.Caption | DevExpress.XtraBars.BarLinkUserDefines.PaintStyle))), this.openButtonItem, "&open", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, this.saveButtonItem, "&save"),
            new DevExpress.XtraBars.LinkPersistInfo(this.saveAs)});
            this.barSubItem1.Name = "barSubItem1";
            this.barSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // openButtonItem
            // 
            this.openButtonItem.Caption = "&open";
            this.openButtonItem.Hint = "open word file";
            this.openButtonItem.Id = 1;
            this.openButtonItem.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("openButtonItem.ImageOptions.DisabledImage")));
            this.openButtonItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("openButtonItem.ImageOptions.Image")));
            this.openButtonItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("openButtonItem.ImageOptions.LargeImage")));
            this.openButtonItem.Name = "openButtonItem";
            this.openButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            this.openButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.openButtonItem_ItemClick);
            // 
            // saveButtonItem
            // 
            this.saveButtonItem.Caption = "&save";
            this.saveButtonItem.Hint = "save xml file";
            this.saveButtonItem.Id = 3;
            this.saveButtonItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("saveButtonItem.ImageOptions.Image")));
            this.saveButtonItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("saveButtonItem.ImageOptions.LargeImage")));
            this.saveButtonItem.Name = "saveButtonItem";
            this.saveButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.saveButtonItem_ItemClick);
            // 
            // saveAs
            // 
            this.saveAs.Caption = "&save as";
            this.saveAs.Id = 9;
            this.saveAs.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("saveAs.ImageOptions.Image")));
            this.saveAs.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("saveAs.ImageOptions.LargeImage")));
            this.saveAs.Name = "saveAs";
            this.saveAs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.saveAs_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Status_bsti)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // Status_bsti
            // 
            this.Status_bsti.Id = 10;
            this.Status_bsti.Name = "Status_bsti";
            this.Status_bsti.Size = new System.Drawing.Size(150, 0);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1162, 55);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 733);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1162, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 55);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 678);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1162, 55);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 678);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer1.Location = new System.Drawing.Point(433, 76);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Size = new System.Drawing.Size(603, 637);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 760);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView zongTreeView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView designTreeView;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TreeView testTreeView;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TreeView ylTreeView;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TreeView reportTreeView;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem openButtonItem;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem addRoot;
        private DevExpress.XtraBars.BarButtonItem saveButtonItem;
        private DevExpress.XtraBars.BarButtonItem addNode;
        private DevExpress.XtraBars.BarButtonItem deleteAll;
        private DevExpress.XtraBars.BarButtonItem editNode;
        private DevExpress.XtraBars.BarButtonItem deleteNode;
        private DevExpress.XtraBars.BarButtonItem saveTreeNode;
        private DevExpress.XtraBars.BarButtonItem saveAs;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraBars.BarStaticItem Status_bsti;
    }
}

