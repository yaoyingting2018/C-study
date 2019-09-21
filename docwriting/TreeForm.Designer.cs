namespace docWriting
{
    partial class TreeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeForm));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.addRoot = new DevExpress.XtraBars.BarButtonItem();
            this.addNode = new DevExpress.XtraBars.BarButtonItem();
            this.editNode = new DevExpress.XtraBars.BarButtonItem();
            this.deleteNode = new DevExpress.XtraBars.BarButtonItem();
            this.clearNodes = new DevExpress.XtraBars.BarButtonItem();
            this.save = new DevExpress.XtraBars.BarButtonItem();
            this.multiSelectButton = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.fileBarSubItem = new DevExpress.XtraBars.BarSubItem();
            this.openButton = new DevExpress.XtraBars.BarButtonItem();
            this.saveButton = new DevExpress.XtraBars.BarButtonItem();
            this.saveAsButton = new DevExpress.XtraBars.BarButtonItem();
            this.requireBarSubItem = new DevExpress.XtraBars.BarSubItem();
            this.testRequireButton = new DevExpress.XtraBars.BarButtonItem();
            this.TestSubReqButton = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.statusBar = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.zongTabPage = new System.Windows.Forms.TabPage();
            this.zongTreeView = new System.Windows.Forms.TreeView();
            this.designTabPage = new System.Windows.Forms.TabPage();
            this.designTreeView = new docWriting.GTreeView();
            this.testTabPage = new System.Windows.Forms.TabPage();
            this.testTreeView = new System.Windows.Forms.TreeView();
            this.testSubtabPage = new System.Windows.Forms.TabPage();
            this.ylTreeView = new System.Windows.Forms.TreeView();
            this.reportTabPage = new System.Windows.Forms.TabPage();
            this.reportTreeView = new System.Windows.Forms.TreeView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.zongTabPage.SuspendLayout();
            this.designTabPage.SuspendLayout();
            this.testTabPage.SuspendLayout();
            this.testSubtabPage.SuspendLayout();
            this.reportTabPage.SuspendLayout();
            this.SuspendLayout();
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
            this.statusBar,
            this.fileBarSubItem,
            this.requireBarSubItem,
            this.addRoot,
            this.addNode,
            this.editNode,
            this.deleteNode,
            this.openButton,
            this.saveButton,
            this.saveAsButton,
            this.testRequireButton,
            this.TestSubReqButton,
            this.clearNodes,
            this.save,
            this.multiSelectButton});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 15;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(87, 181);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.addRoot),
            new DevExpress.XtraBars.LinkPersistInfo(this.addNode),
            new DevExpress.XtraBars.LinkPersistInfo(this.editNode),
            new DevExpress.XtraBars.LinkPersistInfo(this.deleteNode),
            new DevExpress.XtraBars.LinkPersistInfo(this.clearNodes),
            new DevExpress.XtraBars.LinkPersistInfo(this.save),
            new DevExpress.XtraBars.LinkPersistInfo(this.multiSelectButton)});
            this.bar1.Offset = 1;
            this.bar1.Text = "Tools";
            // 
            // addRoot
            // 
            this.addRoot.Hint = "添加根节点";
            this.addRoot.Id = 3;
            this.addRoot.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("addRoot.ImageOptions.Image")));
            this.addRoot.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("addRoot.ImageOptions.LargeImage")));
            this.addRoot.Name = "addRoot";
            this.addRoot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addRoot_ItemClick);
            // 
            // addNode
            // 
            this.addNode.Hint = "添加子节点";
            this.addNode.Id = 4;
            this.addNode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("addNode.ImageOptions.Image")));
            this.addNode.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("addNode.ImageOptions.LargeImage")));
            this.addNode.Name = "addNode";
            this.addNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addNode_ItemClick);
            // 
            // editNode
            // 
            this.editNode.Hint = "编辑节点";
            this.editNode.Id = 5;
            this.editNode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("editNode.ImageOptions.Image")));
            this.editNode.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("editNode.ImageOptions.LargeImage")));
            this.editNode.Name = "editNode";
            this.editNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.editNode_ItemClick);
            // 
            // deleteNode
            // 
            this.deleteNode.Hint = "删除节点";
            this.deleteNode.Id = 6;
            this.deleteNode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("deleteNode.ImageOptions.Image")));
            this.deleteNode.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("deleteNode.ImageOptions.LargeImage")));
            this.deleteNode.Name = "deleteNode";
            this.deleteNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.deleteNode_ItemClick);
            // 
            // clearNodes
            // 
            this.clearNodes.Hint = "删除所有节点";
            this.clearNodes.Id = 12;
            this.clearNodes.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("clearNodes.ImageOptions.Image")));
            this.clearNodes.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("clearNodes.ImageOptions.LargeImage")));
            this.clearNodes.Name = "clearNodes";
            this.clearNodes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.clearNodes_ItemClick);
            // 
            // save
            // 
            this.save.Hint = "保存";
            this.save.Id = 13;
            this.save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("save.ImageOptions.Image")));
            this.save.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("save.ImageOptions.LargeImage")));
            this.save.Name = "save";
            // 
            // multiSelectButton
            // 
            this.multiSelectButton.Hint = "多选编辑";
            this.multiSelectButton.Id = 14;
            this.multiSelectButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("multiSelectButton.ImageOptions.Image")));
            this.multiSelectButton.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("multiSelectButton.ImageOptions.LargeImage")));
            this.multiSelectButton.Name = "multiSelectButton";
            this.multiSelectButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.multiSelectButton_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.fileBarSubItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.requireBarSubItem)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // fileBarSubItem
            // 
            this.fileBarSubItem.Caption = "&File";
            this.fileBarSubItem.Id = 1;
            this.fileBarSubItem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.openButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.saveButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.saveAsButton)});
            this.fileBarSubItem.Name = "fileBarSubItem";
            // 
            // openButton
            // 
            this.openButton.Caption = "&open";
            this.openButton.Id = 7;
            this.openButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("openButton.ImageOptions.Image")));
            this.openButton.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("openButton.ImageOptions.LargeImage")));
            this.openButton.Name = "openButton";
            this.openButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.openButton_ItemClick);
            // 
            // saveButton
            // 
            this.saveButton.Caption = "&save";
            this.saveButton.Id = 8;
            this.saveButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.ImageOptions.Image")));
            this.saveButton.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("saveButton.ImageOptions.LargeImage")));
            this.saveButton.Name = "saveButton";
            this.saveButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.saveButton_ItemClick);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Caption = "&save as";
            this.saveAsButton.Id = 9;
            this.saveAsButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("saveAsButton.ImageOptions.Image")));
            this.saveAsButton.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("saveAsButton.ImageOptions.LargeImage")));
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.saveAsButton_ItemClick);
            // 
            // requireBarSubItem
            // 
            this.requireBarSubItem.Caption = "&Require";
            this.requireBarSubItem.Id = 2;
            this.requireBarSubItem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.testRequireButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.TestSubReqButton)});
            this.requireBarSubItem.Name = "requireBarSubItem";
            // 
            // testRequireButton
            // 
            this.testRequireButton.Caption = "&TestRequire";
            this.testRequireButton.Id = 10;
            this.testRequireButton.Name = "testRequireButton";
            this.testRequireButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.testRequireButton_ItemClick);
            // 
            // TestSubReqButton
            // 
            this.TestSubReqButton.Caption = "&TestSubReq";
            this.TestSubReqButton.Id = 11;
            this.TestSubReqButton.Name = "TestSubReqButton";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.statusBar)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // statusBar
            // 
            this.statusBar.Id = 0;
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(150, 0);
            this.statusBar.Width = 150;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1194, 55);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 618);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1194, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 55);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 563);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1194, 55);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 563);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl.Controls.Add(this.zongTabPage);
            this.tabControl.Controls.Add(this.designTabPage);
            this.tabControl.Controls.Add(this.testTabPage);
            this.tabControl.Controls.Add(this.testSubtabPage);
            this.tabControl.Controls.Add(this.reportTabPage);
            this.tabControl.Location = new System.Drawing.Point(8, 59);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(344, 551);
            this.tabControl.TabIndex = 4;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // zongTabPage
            // 
            this.zongTabPage.Controls.Add(this.zongTreeView);
            this.zongTabPage.Location = new System.Drawing.Point(4, 22);
            this.zongTabPage.Name = "zongTabPage";
            this.zongTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.zongTabPage.Size = new System.Drawing.Size(336, 525);
            this.zongTabPage.TabIndex = 0;
            this.zongTabPage.Text = "总关系";
            this.zongTabPage.UseVisualStyleBackColor = true;
            // 
            // zongTreeView
            // 
            this.zongTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zongTreeView.Location = new System.Drawing.Point(3, 3);
            this.zongTreeView.Name = "zongTreeView";
            this.zongTreeView.Size = new System.Drawing.Size(330, 519);
            this.zongTreeView.TabIndex = 0;
            // 
            // designTabPage
            // 
            this.designTabPage.Controls.Add(this.designTreeView);
            this.designTabPage.Location = new System.Drawing.Point(4, 22);
            this.designTabPage.Name = "designTabPage";
            this.designTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.designTabPage.Size = new System.Drawing.Size(336, 525);
            this.designTabPage.TabIndex = 1;
            this.designTabPage.Text = "设计需求";
            this.designTabPage.UseVisualStyleBackColor = true;
            // 
            // designTreeView
            // 
            this.designTreeView.AllowDrop = true;
            this.designTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designTreeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.designTreeView.IsMultiSelect = true;
            this.designTreeView.Location = new System.Drawing.Point(3, 3);
            this.designTreeView.Name = "designTreeView";
            this.designTreeView.Size = new System.Drawing.Size(330, 519);
            this.designTreeView.TabIndex = 0;
            // 
            // testTabPage
            // 
            this.testTabPage.Controls.Add(this.testTreeView);
            this.testTabPage.Location = new System.Drawing.Point(4, 22);
            this.testTabPage.Name = "testTabPage";
            this.testTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.testTabPage.Size = new System.Drawing.Size(336, 525);
            this.testTabPage.TabIndex = 2;
            this.testTabPage.Text = "测试需求";
            this.testTabPage.UseVisualStyleBackColor = true;
            // 
            // testTreeView
            // 
            this.testTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testTreeView.Location = new System.Drawing.Point(3, 3);
            this.testTreeView.Name = "testTreeView";
            this.testTreeView.Size = new System.Drawing.Size(330, 519);
            this.testTreeView.TabIndex = 0;
            // 
            // testSubtabPage
            // 
            this.testSubtabPage.Controls.Add(this.ylTreeView);
            this.testSubtabPage.Location = new System.Drawing.Point(4, 22);
            this.testSubtabPage.Name = "testSubtabPage";
            this.testSubtabPage.Padding = new System.Windows.Forms.Padding(3);
            this.testSubtabPage.Size = new System.Drawing.Size(336, 525);
            this.testSubtabPage.TabIndex = 3;
            this.testSubtabPage.Text = "测试说明";
            this.testSubtabPage.UseVisualStyleBackColor = true;
            // 
            // ylTreeView
            // 
            this.ylTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ylTreeView.Location = new System.Drawing.Point(3, 3);
            this.ylTreeView.Name = "ylTreeView";
            this.ylTreeView.Size = new System.Drawing.Size(330, 519);
            this.ylTreeView.TabIndex = 0;
            // 
            // reportTabPage
            // 
            this.reportTabPage.Controls.Add(this.reportTreeView);
            this.reportTabPage.Location = new System.Drawing.Point(4, 22);
            this.reportTabPage.Name = "reportTabPage";
            this.reportTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.reportTabPage.Size = new System.Drawing.Size(336, 525);
            this.reportTabPage.TabIndex = 4;
            this.reportTabPage.Text = "问题报告";
            this.reportTabPage.UseVisualStyleBackColor = true;
            // 
            // reportTreeView
            // 
            this.reportTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportTreeView.Location = new System.Drawing.Point(3, 3);
            this.reportTreeView.Name = "reportTreeView";
            this.reportTreeView.Size = new System.Drawing.Size(330, 519);
            this.reportTreeView.TabIndex = 0;
            // 
            // TreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 645);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TreeForm";
            this.Text = "DocEdit";
            this.Load += new System.EventHandler(this.TreeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.zongTabPage.ResumeLayout(false);
            this.designTabPage.ResumeLayout(false);
            this.testTabPage.ResumeLayout(false);
            this.testSubtabPage.ResumeLayout(false);
            this.reportTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem addRoot;
        private DevExpress.XtraBars.BarButtonItem addNode;
        private DevExpress.XtraBars.BarButtonItem editNode;
        private DevExpress.XtraBars.BarButtonItem deleteNode;
        private DevExpress.XtraBars.BarSubItem fileBarSubItem;
        private DevExpress.XtraBars.BarSubItem requireBarSubItem;
        private DevExpress.XtraBars.BarStaticItem statusBar;
        private DevExpress.XtraBars.BarButtonItem openButton;
        private DevExpress.XtraBars.BarButtonItem saveButton;
        private DevExpress.XtraBars.BarButtonItem saveAsButton;
        private DevExpress.XtraBars.BarButtonItem testRequireButton;
        private DevExpress.XtraBars.BarButtonItem TestSubReqButton;
        private DevExpress.XtraBars.BarButtonItem clearNodes;
        private DevExpress.XtraBars.BarButtonItem save;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage zongTabPage;
        private System.Windows.Forms.TabPage designTabPage;
        private System.Windows.Forms.TabPage testTabPage;
        private System.Windows.Forms.TabPage testSubtabPage;
        private System.Windows.Forms.TabPage reportTabPage;
        private System.Windows.Forms.TreeView zongTreeView;
        //private System.Windows.Forms.TreeView designTreeView;
        private System.Windows.Forms.TreeView testTreeView;
        private System.Windows.Forms.TreeView ylTreeView;
        private System.Windows.Forms.TreeView reportTreeView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public  GTreeView designTreeView;
        private DevExpress.XtraBars.BarButtonItem multiSelectButton;
    }
}

