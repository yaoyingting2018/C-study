using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace docWriting
{
    partial class TreeForm
    {
        //设计树界面控件
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.RichTextBox richTextBox;
        //测试表格控件
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;       
        private DevExpress.XtraVerticalGrid.Rows.EditorRow PId;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Id;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TestName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TestIdentify;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TestPriority;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TraceRelationships;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TestContent;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TestReqResolve;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow AdequacyRequirements;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TerminalCondition;
        private DevExpress.XtraGrid.Columns.GridColumn SubId;
        private DevExpress.XtraGrid.Columns.GridColumn TestSubReq;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn SubReqAnalyse;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn TestSubIdentify;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;

        //用例表格控件
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl2;
       // private DevExpress.XtraVerticalGrid.Rows.EditorRow PId;
       // private DevExpress.XtraVerticalGrid.Rows.EditorRow Id;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow YlNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow YlName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow YlIdentify;
       // private DevExpress.XtraVerticalGrid.Rows.EditorRow TraceRelationships;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow YlSummarize;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow YlInitialize;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow PrerequisiteConstraints;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TestProcedures;
       // private DevExpress.XtraVerticalGrid.Rows.EditorRow TerminalCondition;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow PassCriteria;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Designer;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        //private DevExpress.XtraGrid.Columns.GridColumn SubId;
        private DevExpress.XtraGrid.Columns.GridColumn InputOperation;
        private DevExpress.XtraGrid.Columns.GridColumn ExpectedOut;


        //删除快捷键
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1; //右键快捷键
        private System.Windows.Forms.ToolStripMenuItem delete;  //菜单里的删除按键
        private void CreatesplitContainer()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.richTextBox = new System.Windows.Forms.RichTextBox();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            //this.SuspendLayout();


            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(387, 81);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dataGridView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.richTextBox);
            this.splitContainer.Size = new System.Drawing.Size(666, 522);
            this.splitContainer.SplitterDistance = 177;
            this.splitContainer.TabIndex = 9;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(666, 177);
            this.dataGridView.TabIndex = 0;
            // dataGridView换行设置
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(0, 0);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(666, 341);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";

            this.Controls.Add(this.splitContainer);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
        }

        private void CreateGridControl()
        {
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.PId = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Id = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TestName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TestIdentify = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TestPriority = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TraceRelationships = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TestContent = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TestReqResolve = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.AdequacyRequirements = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TerminalCondition = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemRichTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.SubId= new DevExpress.XtraGrid.Columns.GridColumn();
            this.TestSubReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SubReqAnalyse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TestSubIdentify = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();

            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);

            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(152, 22);
            this.delete.Text = "删除";
            this.delete.Click += new System.EventHandler(this.delete_Click);



            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(389, 62);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.vGridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(760, 548);
            this.splitContainer1.SplitterDistance = 345;
            this.splitContainer1.TabIndex = 9;
            // 
            // vGridControl1
            // 
            this.vGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGridControl1.Location = new System.Drawing.Point(0, 0);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.OptionsView.AutoScaleBands = true;
            this.vGridControl1.RecordWidth = 172;
            this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemRichTextEdit1,
            this.repositoryItemRadioGroup1,
            this.repositoryItemComboBox1});
            this.vGridControl1.RowHeaderWidth = 28;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.PId,
            this.Id,
            this.TestName,
            this.TestIdentify,
            this.TestPriority,
            this.TraceRelationships,
            this.TestContent,
            this.TestReqResolve,
            this.AdequacyRequirements,
            this.TerminalCondition});
            this.vGridControl1.Size = new System.Drawing.Size(760, 345);
            this.vGridControl1.TabIndex = 0;
            this.vGridControl1.Leave += new System.EventHandler(this.vGridControl1_Leave);
            this.vGridControl1.CellValueChanging += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(this.vGridControl1_CellValueChanging);

            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
            // 
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // PId
            // 
            this.PId.Name = "PId";
            this.PId.Properties.AllowEdit = false;
            this.PId.Appearance.Options.UseTextOptions = true;
            this.PId.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PId.Properties.Caption = "PId";
            this.PId.Properties.FieldName = "PId";
            this.PId.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // Id
            // 
            this.Id.Name = "Id";
            this.Id.Properties.AllowEdit = false;
            this.Id.Appearance.Options.UseTextOptions = true;
            this.Id.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Id.Properties.Caption = "Id";
            this.Id.Properties.FieldName = "Id";
            this.Id.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // TestName
            // 
            this.TestName.Name = "TestName";
            this.TestName.Properties.Caption = "测试项名称";
            this.TestName.Properties.FieldName = "Name";
            this.TestName.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // TestIdentify
            // 
            this.TestIdentify.Name = "TestIdentify";
            this.TestIdentify.Properties.Caption = "测试项标识";
            this.TestIdentify.Properties.FieldName = "TestIdentify";
            this.TestIdentify.Properties.RowEdit = this.repositoryItemComboBox1;
            // 
            // TestPriority
            // 
            this.TestPriority.Name = "TestPriority";
            this.TestPriority.Properties.Caption = "测试优先级";
            this.TestPriority.Properties.FieldName = "TestPriority";
            this.TestPriority.Properties.RowEdit = this.repositoryItemRadioGroup1;
            // 
            // TraceRelationships
            // 
            this.TraceRelationships.Height = 51;
            this.TraceRelationships.Name = "TraceRelationships";
            this.TraceRelationships.Properties.Caption = "追踪关系";
            this.TraceRelationships.Properties.FieldName = "TraceRelationships";
            this.TraceRelationships.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // TestContent
            // 
            this.TestContent.Height = 103;
            this.TestContent.Name = "TestContent";
            this.TestContent.Properties.Caption = "测试内容";
            this.TestContent.Properties.FieldName = "TestContent";
            this.TestContent.Properties.RowEdit = this.repositoryItemRichTextEdit1;
            // 
            // TestReqResolve
            // 
            this.TestReqResolve.Name = "TestReqResolve";
            this.TestReqResolve.Properties.Caption = "测试需求分解";
            this.TestReqResolve.Properties.FieldName = "TestReqResolve";
            this.TestReqResolve.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // AdequacyRequirements
            // 
            this.AdequacyRequirements.Name = "AdequacyRequirements";
            this.AdequacyRequirements.Properties.Caption = "充分性要求";
            this.AdequacyRequirements.Properties.FieldName = "AdequacyRequirements";
            this.AdequacyRequirements.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // TerminalCondition
            // 
            this.TerminalCondition.Name = "TerminalCondition";
            this.TerminalCondition.Properties.Caption = "终止条件";
            this.TerminalCondition.Properties.FieldName = "TerminalCondition";
            this.TerminalCondition.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit2,
            this.repositoryItemRichTextEdit2,
            this.repositoryItemMemoEdit2});
            this.gridControl1.Size = new System.Drawing.Size(760, 222);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.UseEmbeddedNavigator = false; //不显示内置的导航条
            this.gridControl1.Leave += new System.EventHandler(this.gridControl1_Leave); //编辑保存
            this.gridControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseDown);
            
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SubId,
            this.TestSubReq,
            this.SubReqAnalyse,
            this.TestSubIdentify});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false; //不显示分组的面板
            this.gridView1.OptionsView.RowAutoHeight = true;  //根据内容自动行高
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemRichTextEdit2
            // 
            this.repositoryItemRichTextEdit2.Name = "repositoryItemRichTextEdit2";
            this.repositoryItemRichTextEdit2.ShowCaretInReadOnly = false;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";

            //
            //SubID
            //
            this.SubId.ColumnEdit = this.repositoryItemTextEdit2;
            this.SubId.FieldName = "SubId";
            this.SubId.Name = "SubId";
            this.SubId.Visible = true;
            this.SubId.VisibleIndex = 0;
            this.SubId.Width = 40;
            this.SubId.Caption = "序号";
            // 
            // TestSubReq
            // 
            this.TestSubReq.Caption = "测试需求子项";
            this.TestSubReq.ColumnEdit = this.repositoryItemMemoEdit2;
            this.TestSubReq.FieldName = "TestSubReq";
            this.TestSubReq.Name = "TestSubReq";
            this.TestSubReq.Visible = true;
            this.TestSubReq.VisibleIndex = 1;
            this.TestSubReq.Width = 186;
            // 
            // SubReqAnalyse
            // 
            this.SubReqAnalyse.Caption = "测试需求子项分析";
            this.SubReqAnalyse.ColumnEdit = this.repositoryItemRichTextEdit2;
            this.SubReqAnalyse.FieldName = "SubReqAnalyse";
            this.SubReqAnalyse.Name = "SubReqAnalyse";
            this.SubReqAnalyse.Visible = true;
            this.SubReqAnalyse.VisibleIndex = 2;
            this.SubReqAnalyse.Width = 364;
            // 
            // TestSubIdentify
            // 
            this.TestSubIdentify.Caption = "测试子项标识";
            this.TestSubIdentify.ColumnEdit = this.repositoryItemTextEdit2;
            this.TestSubIdentify.FieldName = "TestSubIdentify";
            this.TestSubIdentify.Name = "TestSubIdentify";
            this.TestSubIdentify.Visible = true;
            this.TestSubIdentify.VisibleIndex = 3;
            this.TestSubIdentify.Width = 152;

            this.Controls.Add(this.splitContainer1);

            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);

        }

        private void CreateYlGridControl()
        {
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.vGridControl2 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.PId = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Id = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.YlNumber = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.YlName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.YlIdentify = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TraceRelationships = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.YlSummarize = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.YlInitialize = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.PrerequisiteConstraints = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TestProcedures = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TerminalCondition = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.PassCriteria = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Designer = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SubId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.InputOperation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpectedOut = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();

            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);

            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(152, 22);
            this.delete.Text = "删除";
            this.delete.Click += new System.EventHandler(this.delete2_Click);



            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
           | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(359, 62);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.vGridControl2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gridControl2);
            this.splitContainer2.Size = new System.Drawing.Size(823, 548);
            this.splitContainer2.SplitterDistance = 380;
            this.splitContainer2.TabIndex = 9;
            // 
            // vGridControl2
            // 
            this.vGridControl2.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl2.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGridControl2.Location = new System.Drawing.Point(0, 0);
            this.vGridControl2.Name = "vGridControl2";
            this.vGridControl2.OptionsView.AutoScaleBands = true;
            this.vGridControl2.RecordWidth = 167;
            this.vGridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemMemoEdit1});
            this.vGridControl2.RowHeaderWidth = 33;
            this.vGridControl2.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.PId,
            this.Id,
            this.YlNumber,
            this.YlName,
            this.YlIdentify,
            this.TraceRelationships,
            this.YlSummarize,
            this.YlInitialize,
            this.PrerequisiteConstraints,
            this.TestProcedures,
            this.TerminalCondition,
            this.PassCriteria,
            this.Designer});
            this.vGridControl2.Size = new System.Drawing.Size(823, 380);
            this.vGridControl2.TabIndex = 0;
            this.vGridControl2.Leave += new System.EventHandler(this.vGridControl2_Leave);
            this.vGridControl2.CellValueChanging += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(this.vGridControl2_CellValueChanging);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // PId
            // 
            this.PId.Appearance.Options.UseTextOptions = true;
            this.PId.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PId.Name = "PId";
            this.PId.Properties.AllowEdit = false;
            this.PId.Properties.Caption = "PId";
            this.PId.Properties.FieldName = "PId";
            this.PId.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // Id
            // 
            this.Id.Appearance.Options.UseTextOptions = true;
            this.Id.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Id.Name = "Id";
            this.Id.Properties.AllowEdit = false;
            this.Id.Properties.Caption = "Id";
            this.Id.Properties.FieldName = "Id";
            this.Id.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // YlNumber
            // 
            this.YlNumber.Name = "YlNumber";
            this.YlNumber.Properties.Caption = "用例号";
            this.YlNumber.Properties.FieldName = "Name";
            this.YlNumber.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // YlName
            // 
            this.YlName.Name = "YlName";
            this.YlName.Properties.Caption = "测试用例名称";
            this.YlName.Properties.FieldName = "YlName";
            this.YlName.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // YlIdentify
            // 
            this.YlIdentify.Name = "YlIdentify";
            this.YlIdentify.Properties.Caption = "标识";
            this.YlIdentify.Properties.FieldName = "YlIdentify";
            this.YlIdentify.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // TraceRelationships
            // 
            this.TraceRelationships.Height = 61;
            this.TraceRelationships.Name = "TraceRelationships";
            this.TraceRelationships.Properties.Caption = "追踪关系";
            this.TraceRelationships.Properties.FieldName = "TraceRelationships";
            this.TraceRelationships.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // YlSummarize
            // 
            this.YlSummarize.Height = 45;
            this.YlSummarize.Name = "YlSummarize";
            this.YlSummarize.Properties.Caption = "测试用例综述";
            this.YlSummarize.Properties.FieldName = "YlSummarize";
            this.YlSummarize.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // YlInitialize
            // 
            this.YlInitialize.Height = 30;
            this.YlInitialize.Name = "YlInitialize";
            this.YlInitialize.Properties.Caption = "用例初始化";
            this.YlInitialize.Properties.FieldName = "YlInitialize";
            this.YlInitialize.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // PrerequisiteConstraints
            // 
            this.PrerequisiteConstraints.Height = 29;
            this.PrerequisiteConstraints.Name = "PrerequisiteConstraints";
            this.PrerequisiteConstraints.Properties.Caption = "前提和约束";
            this.PrerequisiteConstraints.Properties.FieldName = "PrerequisiteConstraints";
            this.PrerequisiteConstraints.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // TestProcedures
            // 
            this.TestProcedures.Name = "TestProcedures";
            this.TestProcedures.Properties.Caption = "测试步骤";
            this.TestProcedures.Properties.FieldName = "TestProcedures";
            this.TestProcedures.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // TerminalCondition
            // 
            this.TerminalCondition.Height = 25;
            this.TerminalCondition.Name = "TerminalCondition";
            this.TerminalCondition.Properties.Caption = "终止条件";
            this.TerminalCondition.Properties.FieldName = "TerminalCondition";
            this.TerminalCondition.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // PassCriteria
            // 
            this.PassCriteria.Height = 25;
            this.PassCriteria.Name = "PassCriteria";
            this.PassCriteria.Properties.Caption = "通过准则";
            this.PassCriteria.Properties.FieldName = "PassCriteria";
            this.PassCriteria.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // Designer
            // 
            this.Designer.Name = "Designer";
            this.Designer.Properties.Caption = "设计人员";
            this.Designer.Properties.FieldName = "Designer";
            this.Designer.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.MenuManager = this.barManager1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit2,
            this.repositoryItemMemoEdit2});
            this.gridControl2.Size = new System.Drawing.Size(823, 192);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridControl2.Leave += new System.EventHandler(this.gridControl2_Leave); //编辑保存
            this.gridControl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControl2_MouseDown);

            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SubId,
            this.InputOperation,
            this.ExpectedOut});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView2.OptionsView.RowAutoHeight = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // SubId
            // 
            this.SubId.Caption = "序号";
            this.SubId.FieldName = "SubId";
            this.SubId.Name = "SubId";
            this.SubId.Visible = true;
            this.SubId.VisibleIndex = 0;
            this.SubId.Width = 64;

            // 
            // InputOperation
            // 
            this.InputOperation.Caption = "输入及操作";
            this.InputOperation.ColumnEdit = this.repositoryItemMemoEdit1;
            this.InputOperation.FieldName = "InputOperation";
            this.InputOperation.Name = "InputOperation";
            this.InputOperation.Visible = true;
            this.InputOperation.VisibleIndex = 1;
            this.InputOperation.Width = 341;
            // 
            // ExpectedOut
            // 
            this.ExpectedOut.Caption = "期望结果与评估标准";
            this.ExpectedOut.ColumnEdit = this.repositoryItemMemoEdit1;
            this.ExpectedOut.FieldName = "ExpectedOut";
            this.ExpectedOut.Name = "ExpectedOut";
            this.ExpectedOut.Visible = true;
            this.ExpectedOut.VisibleIndex = 2;
            this.ExpectedOut.Width = 400;

            this.Controls.Add(this.splitContainer2);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
        }

        /// <summary>
        /// 右键弹出删除菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gridControl1.ContextMenuStrip = this.contextMenuStrip1;
                contextMenuStrip1.Show(MousePosition);
            }
        }

        /// <summary>
        /// 用例表格右键弹出删除菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gridControl2.ContextMenuStrip = this.contextMenuStrip1;
                contextMenuStrip1.Show(MousePosition);
            }
        }




        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_Click(object sender, EventArgs e)
        {
            if (gridView1 == null || gridView1.SelectedRowsCount <= 0) return;
            DataRow[] dataRows = new DataRow[gridView1.SelectedRowsCount];
            DataRow tmprow;
            DataRow[] rows;
            for (var i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                dataRows[i] = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
            }
            gridView1.BeginSort();
            try
            {
                foreach (DataRow row in dataRows)
                {
                    
                    tmprow = m_TestSubDataTable.NewRow();
                    tmprow["Id"] = tmpTestdt.Rows[0]["Id"];
                    tmprow["SubId"] = row[0];
                    tmprow["TestSubReq"] = row[1];
                    tmprow["SubReqAnalyse"] = row[2];
                    tmprow["TestSubIdentify"] = row[3];
                    rows=m_TestSubDataTable.Select("id='" + tmprow["Id"] + "' and SubId='" + tmprow["SubId"] + "'");
                    row.Delete();
                    m_TestSubDataTable.Rows.Remove(rows[0]); //更新到数据表
                    //m_TestSubDataTable.Rows.Remove(tmprow);
                }

            }
            catch {  }

            finally
            {
                gridView1.EndSort();

            }
        }

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete2_Click(object sender, EventArgs e)
        {
            if (gridView2 == null || gridView2.SelectedRowsCount <= 0) return;
            DataRow[] dataRows = new DataRow[gridView2.SelectedRowsCount];
            DataRow tmprow;
            DataRow[] rows;
            for (var i = 0; i < gridView2.SelectedRowsCount; i++)
            {
                dataRows[i] = gridView2.GetDataRow(gridView2.GetSelectedRows()[i]);
            }
            gridView2.BeginSort();
            try
            {
                foreach (DataRow row in dataRows)
                {

                    tmprow = m_YLSubDataTable.NewRow();
                    tmprow["Id"] = tmpYldt.Rows[0]["Id"];
                    tmprow["SubId"] = row[0];
                    tmprow["InputOperation"] = row[1];
                    tmprow["ExpectedOut"] = row[2];

                    rows = m_YLSubDataTable.Select("id='" + tmprow["Id"] + "' and SubId='" + tmprow["SubId"] + "'");
                    row.Delete();
                    m_YLSubDataTable.Rows.Remove(rows[0]); //更新到数据表
                    //m_TestSubDataTable.Rows.Remove(tmprow);
                }

            }
            catch { }

            finally
            {
                gridView2.EndSort();

               }
            }

        /// <summary>
        /// 编辑测试表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void vGridControl1_Leave(object sender, EventArgs e)
        {
            try
            {
                uint id = Convert.ToUInt32(tmpTestdt.Rows[0]["Id"].ToString());
                DataRow[] rows = m_TestDataTable.Select("id='" + id + "'");
                //写回去表格
                rows[0].BeginEdit();
                rows[0]["Name"] = vGridControl1.GetCellValue(TestName, 0).ToString();
                rows[0]["TestIdentify"] = vGridControl1.GetCellValue(TestIdentify, 0).ToString();
                rows[0]["TestPriority"] = testPrio_index;
                rows[0]["TraceRelationships"] = vGridControl1.GetCellValue(TraceRelationships, 0).ToString();
                rows[0]["TestContent"] = vGridControl1.GetCellValue(TestContent, 0).ToString();
                rows[0]["TestReqResolve"] = vGridControl1.GetCellValue(TestReqResolve, 0).ToString();
                rows[0]["AdequacyRequirements"] = vGridControl1.GetCellValue(AdequacyRequirements, 0).ToString();
                rows[0]["TerminalCondition"] = vGridControl1.GetCellValue(TerminalCondition, 0).ToString();
                rows[0].EndEdit();
            }
            catch { }
        }

        /// <summary>
        /// 编辑用例表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void vGridControl2_Leave(object sender, EventArgs e)
        {

            try
            {
                uint id = Convert.ToUInt32(tmpYldt.Rows[0]["Id"].ToString());
                DataRow[] rows = m_YLDataTable.Select("id='" + id + "'");
                //写回去表格
                rows[0].BeginEdit();
                rows[0]["Name"] = vGridControl2.GetCellValue(YlNumber, 0).ToString();
                rows[0]["YlName"] = vGridControl2.GetCellValue(YlName, 0).ToString();
                rows[0]["YlIdentify"] = vGridControl2.GetCellValue(YlIdentify, 0).ToString();
                rows[0]["TraceRelationships"] = vGridControl2.GetCellValue(TraceRelationships, 0).ToString();
                rows[0]["YlSummarize"] = vGridControl2.GetCellValue(YlSummarize, 0).ToString();
                rows[0]["YlInitialize"] = vGridControl2.GetCellValue(YlInitialize, 0).ToString();
                rows[0]["PrerequisiteConstraints"] = vGridControl2.GetCellValue(PrerequisiteConstraints, 0).ToString();
                rows[0]["TestProcedures"] = vGridControl2.GetCellValue(TestProcedures, 0).ToString();
                rows[0]["TerminalCondition"] = vGridControl2.GetCellValue(TerminalCondition, 0).ToString();
                rows[0]["PassCriteria"] = vGridControl2.GetCellValue(PassCriteria, 0).ToString();
                rows[0]["Designer"] = vGridControl2.GetCellValue(Designer, 0).ToString();
                rows[0].EndEdit();
            }
            catch { }
        }

        /// <summary>
        /// name字段改变，同步到树控件上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vGridControl1_CellValueChanging(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {

           if((tmpTag!=0) && (e.Row==this.TestName))
            {
                //string originalName = vGridControl1.GetCellValue(TestName, 0).ToString();// 未改变前的值
                ChangeNodeName(testTreeView.Nodes, tmpTag, e.Value.ToString());                
            }
        }


        /// <summary>
        /// name字段改变，同步到树控件上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vGridControl2_CellValueChanging(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {

            if ((tmpTag != 0) && (e.Row == this.YlNumber))
            {
                //string originalName = vGridControl1.GetCellValue(TestName, 0).ToString();// 未改变前的值
                ChangeNodeName(ylTreeView.Nodes, tmpTag, e.Value.ToString());
            }
        }

        /// <summary>
        /// 获取树上所有节点集合
        /// </summary>
        /// <param name="nodeCollection"></param>
        /// <param name="nodeList"></param>
        private void ChangeNodeName(TreeNodeCollection nodeCollection,uint id,string name)
        {
            foreach (TreeNode itemNode in nodeCollection)
            {
                if(Convert.ToUInt32(itemNode.Tag.ToString()) == id)
                {
                    itemNode.Text = name;
                    break;
                }
                ChangeNodeName(itemNode.Nodes,id,name);
            }
        }

        /// <summary>
        /// 编辑测试子项表格，先删除再添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void gridControl1_Leave(object sender, EventArgs e)
        {
            try
            {
                uint id = Convert.ToUInt32(tmpTestdt.Rows[0]["Id"].ToString());
                DataRow tmprow;
                DataRow[] rows = m_TestSubDataTable.Select("id='" + id + "'");
                foreach (DataRow row in rows)
                {
                    m_TestSubDataTable.Rows.Remove(row);
                }
                DataTable tmpdt = tmpTestSubdt.Clone();
                tmpdt = ((DataView)gridView1.DataSource).ToTable();
                foreach (DataRow row in tmpdt.Rows)
                {
                    tmprow = m_TestSubDataTable.NewRow();
                    tmprow["Id"] = id;
                    tmprow["SubId"] = row[0];
                    tmprow["TestSubReq"] = row[1];
                    tmprow["SubReqAnalyse"] = row[2];
                    tmprow["TestSubIdentify"] = row[3];
                    m_TestSubDataTable.Rows.Add(tmprow);

                }
            }
            catch { }

        }

        /// <summary>
        /// 编辑用例测试子项表格，先删除再添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void gridControl2_Leave(object sender, EventArgs e)
        {
            try
            {
                uint id = Convert.ToUInt32(tmpYldt.Rows[0]["Id"].ToString());
                DataRow tmprow;
                DataRow[] rows = m_YLSubDataTable.Select("id='" + id + "'");
                foreach (DataRow row in rows)
                {
                    m_YLSubDataTable.Rows.Remove(row);
                }
                DataTable tmpdt = tmpYlSubdt.Clone();
                tmpdt = ((DataView)gridView2.DataSource).ToTable();
                foreach (DataRow row in tmpdt.Rows)
                {
                    tmprow = m_YLSubDataTable.NewRow();
                    tmprow["Id"] = id;
                    tmprow["SubId"] = row[0];
                    tmprow["InputOperation"] = row[1];
                    tmprow["ExpectedOut"] = row[2];
                    m_YLSubDataTable.Rows.Add(tmprow);

                }
            }
            catch { }

        }





    }

    

    public class EditDialog
    {
        public Form m_Config_form = new Form();
        private string m_nodename;//节点名称
        private RichTextBox m_richTextBox;
        private Button m_btnConfirm;
        private Button m_btnCance;

        public string NodeName
        {
            get { return m_nodename; }
            set { m_nodename = value; }
        }

        public EditDialog()
        {
            InitComponent();
          
        }

        ~EditDialog()
        { }

        private void InitComponent()
        {
            m_richTextBox = new RichTextBox();
            m_btnConfirm = new Button();
            m_btnCance = new Button();

            m_Config_form.SuspendLayout();
            // 
            // richTextBox
            // 
            m_richTextBox.Location = new System.Drawing.Point(0, 0);
            m_richTextBox.Name = "richTextBox";
            m_richTextBox.Size = new System.Drawing.Size(464, 333);
            m_richTextBox.TabIndex = 0;
            m_richTextBox.Text = "";
            m_richTextBox.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            // 
            // btnConfirm
            // 
            m_btnConfirm.Location = new System.Drawing.Point(105, 348);
            m_btnConfirm.Name = "btnConfirm";
            m_btnConfirm.Size = new System.Drawing.Size(75, 23);
            m_btnConfirm.TabIndex = 1;
            m_btnConfirm.Text = "确认";
            m_btnConfirm.UseVisualStyleBackColor = true;
            m_btnConfirm.Click += btnConfirm_Click;
            m_btnConfirm.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            // 
            // btnCancel
            // 
            m_btnCance.Location = new System.Drawing.Point(254, 348);
            m_btnCance.Name = "btnCance";
            m_btnCance.Size = new System.Drawing.Size(75, 23);
            m_btnCance.TabIndex = 1;
            m_btnCance.Text = "取消";
            m_btnCance.UseVisualStyleBackColor = true;
            m_btnCance.Click += btnCancel_Click;
            m_btnCance.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            // 
            // EditForm
            // 
            m_Config_form.MaximizeBox = false;
            m_Config_form.MinimizeBox = false;
            m_Config_form.ClientSize = new System.Drawing.Size(463, 392);
            m_Config_form.Controls.Add(m_btnCance);
            m_Config_form.Controls.Add(m_btnConfirm);
            m_Config_form.Controls.Add(m_richTextBox);
            m_Config_form.Name = "EditDialog";
            m_Config_form.Text = "EditDialog";
            m_Config_form.ResumeLayout(false);
        }

        //获取form2窗口的富文本框
        public RichTextBox RichTextBox
        {
            get { return m_richTextBox; }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_richTextBox.Text.Trim()))
            {
                m_nodename = "设计需求";
            }
            else
            {
                m_nodename = m_richTextBox.Text;
            }

            //窗体对话框结果
            m_Config_form.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_Config_form.DialogResult = DialogResult.Cancel;
        }

        public DialogResult Show()
        {
            return m_Config_form.ShowDialog();
        }
    }

    /// <summary>
    /// 编辑表格类窗体
    /// </summary>
    public class EditGridDialog:Form
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




        public Form m_EditGridForm = new Form();
       
        public TestGridObject testGrid; //返回的V表格对象
        public DataTable testSubTable; //gridcontrol绑定的表格
        private int testPrio_index=0;

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCance;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1; //右键快捷键
        private System.Windows.Forms.ToolStripMenuItem delete;  //菜单里的删除按键


        //测试表格控件
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
       // private DevExpress.XtraVerticalGrid.Rows.EditorRow PId;
        //private DevExpress.XtraVerticalGrid.Rows.EditorRow Id;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TestName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TestType;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TestIdentify;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TestPriority;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TraceRelationships;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TestContent;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TestReqResolve;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow AdequacyRequirements;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TerminalCondition;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;

        private DevExpress.XtraGrid.Columns.GridColumn SubId;
        private DevExpress.XtraGrid.Columns.GridColumn TestSubReq;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn SubReqAnalyse;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn TestSubIdentify;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;


        public EditGridDialog()
        {
            InitializeComponent();
            gridControl1.DataSource = testSubTable; //绑定表格
        }

       

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.testGrid = new TestGridObject();            
            this.testSubTable = new DataTable();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCance = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //this.PId = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            //this.Id = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TestName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TestType= new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TestIdentify = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TestPriority = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TraceRelationships = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TestContent = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TestReqResolve = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.AdequacyRequirements = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TerminalCondition = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemRichTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.SubId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TestSubReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SubReqAnalyse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TestSubIdentify = new DevExpress.XtraGrid.Columns.GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
           

            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            m_EditGridForm.SuspendLayout();


            //
            //editTable
            //
            DataColumn[] cols = {
                                  new DataColumn("SubId",typeof(UInt16)),
                                  new DataColumn("TestSubReq",typeof(string)),
                                  new DataColumn("SubReqAnalyse",typeof(string)),
                                  new DataColumn("TestSubIdentify",typeof(string))
            };
            this.testSubTable.Columns.AddRange(cols);
            this.testSubTable.PrimaryKey = new DataColumn[] { testSubTable.Columns["Id"] };
            //editTable.Columns["Id"].AutoIncrement = true;


            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.Location = new System.Drawing.Point(265, 608);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCance
            // 
            this.btnCance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCance.Location = new System.Drawing.Point(516, 608);
            this.btnCance.Name = "btnCance";
            this.btnCance.Size = new System.Drawing.Size(75, 23);
            this.btnCance.TabIndex = 0;
            this.btnCance.Text = "取消";
            this.btnCance.UseVisualStyleBackColor = true;
            this.btnCance.Click+= btnCancel_Click;

            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);

            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(152, 22);
            this.delete.Text = "删除";
            this.delete.Click += new System.EventHandler(this.delete_Click);




            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(77, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.vGridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(760, 548);
            this.splitContainer1.SplitterDistance = 335;
            this.splitContainer1.TabIndex = 9;
            // 
            // vGridControl1
            // 
            this.vGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGridControl1.Location = new System.Drawing.Point(0, 0);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.OptionsView.AutoScaleBands = true;
            this.vGridControl1.RecordWidth = 168;
            this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemRichTextEdit1,
            this.repositoryItemRadioGroup1,
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2});
            this.vGridControl1.RowHeaderWidth = 32;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            //this.PId,
           // this.Id,
            this.TestName,
            this.TestType,
            this.TestIdentify,
            this.TestPriority,
            this.TraceRelationships,
            this.TestContent,
            this.TestReqResolve,
            this.AdequacyRequirements,
            this.TerminalCondition});
            this.vGridControl1.Size = new System.Drawing.Size(763, 322);
            this.vGridControl1.TabIndex = 0;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
            // 
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            RadioGroupItem r1 = new RadioGroupItem(0, "高");
            RadioGroupItem r2 = new RadioGroupItem(1, "中");
            RadioGroupItem r3 = new RadioGroupItem(2, "低");
            repositoryItemRadioGroup1.Items.Add(r1);
            repositoryItemRadioGroup1.Items.Add(r2);
            repositoryItemRadioGroup1.Items.Add(r3);
            //单选按钮在值改变的时候获取选中的值
            repositoryItemRadioGroup1.SelectedIndexChanged += Testprio_SelectedIndexChanged;

            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            //把测试标识枚举类型加入到repositoryItemComboBox中
            for (int i = 0; i < Enum.GetNames(typeof(TestItendify)).Length; i++)
            {

                string strTestItendify = Enum.GetName(typeof(TestItendify), i);

                repositoryItemComboBox1.Items.Add(strTestItendify);
            }
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            //把测试标识枚举类型加入到repositoryItemComboBox中
            for (int i = 0; i < Enum.GetNames(typeof(TestType)).Length; i++)
            {

                string strTestItendify = Enum.GetName(typeof(TestType), i);

                repositoryItemComboBox2.Items.Add(strTestItendify);
            }

            // 
            // PId
            // 
            //this.PId.Name = "PId";
            //this.PId.Properties.AllowEdit = false;
            //this.PId.Appearance.Options.UseTextOptions = true;
            //this.PId.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            //this.PId.Properties.Caption = "PId";
            //this.PId.Properties.FieldName = "PId";
            //this.PId.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // Id
            // 
            //this.Id.Name = "Id";
            //this.Id.Properties.AllowEdit = false;
            //this.Id.Appearance.Options.UseTextOptions = true;
            //this.Id.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            //this.Id.Properties.Caption = "Id";
            //this.Id.Properties.FieldName = "Id";
            //this.Id.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // TestName
            // 
            this.TestName.Name = "TestName";
            this.TestName.Properties.Caption = "测试项名称";
            this.TestName.Properties.FieldName = "Name";
            this.TestName.Properties.RowEdit = this.repositoryItemTextEdit1;
            //
            //TestType
            //
            this.TestType.Name = "TestType";
            this.TestType.Properties.Caption = "测试类型";
            this.TestType.Properties.FieldName = "TestType";
            this.TestType.Properties.RowEdit= this.repositoryItemComboBox2;

            // 
            // TestIdentify
            // 
            this.TestIdentify.Name = "TestIdentify";
            this.TestIdentify.Properties.Caption = "测试项标识";
            this.TestIdentify.Properties.FieldName = "TestIdentify";
            this.TestIdentify.Properties.RowEdit = this.repositoryItemComboBox1;
            // 
            // TestPriority
            // 
            this.TestPriority.Name = "TestPriority";
            this.TestPriority.Properties.Caption = "测试优先级";
            this.TestPriority.Properties.FieldName = "TestPriority";
            this.TestPriority.Properties.RowEdit = this.repositoryItemRadioGroup1;
            // 
            // TraceRelationships
            // 
            this.TraceRelationships.Height = 51;
            this.TraceRelationships.Name = "TraceRelationships";
            this.TraceRelationships.Properties.Caption = "追踪关系";
            this.TraceRelationships.Properties.FieldName = "TraceRelationships";
            this.TraceRelationships.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // TestContent
            // 
            this.TestContent.Height = 103;
            this.TestContent.Name = "TestContent";
            this.TestContent.Properties.Caption = "测试内容";
            this.TestContent.Properties.FieldName = "TestContent";
            this.TestContent.Properties.RowEdit = this.repositoryItemRichTextEdit1;
            // 
            // TestReqResolve
            // 
            this.TestReqResolve.Name = "TestReqResolve";
            this.TestReqResolve.Properties.Caption = "测试需求分解";
            this.TestReqResolve.Properties.FieldName = "TestReqResolve";
            this.TestReqResolve.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // AdequacyRequirements
            // 
            this.AdequacyRequirements.Name = "AdequacyRequirements";
            this.AdequacyRequirements.Properties.Caption = "充分性要求";
            this.AdequacyRequirements.Properties.FieldName = "AdequacyRequirements";
            this.AdequacyRequirements.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // TerminalCondition
            // 
            this.TerminalCondition.Name = "TerminalCondition";
            this.TerminalCondition.Properties.Caption = "终止条件";
            this.TerminalCondition.Properties.FieldName = "TerminalCondition";
            this.TerminalCondition.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;           
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit2,
            this.repositoryItemRichTextEdit2,
            this.repositoryItemMemoEdit2});
            this.gridControl1.Size = new System.Drawing.Size(763, 224);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.UseEmbeddedNavigator = false; //不显示内置的导航条
            this.gridControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseDown);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SubId,
            this.TestSubReq,
            this.SubReqAnalyse,
            this.TestSubIdentify});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false; //不显示分组的面板
            this.gridView1.OptionsView.RowAutoHeight = true;  //根据内容自动行高
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemRichTextEdit2
            // 
            this.repositoryItemRichTextEdit2.Name = "repositoryItemRichTextEdit2";
            this.repositoryItemRichTextEdit2.ShowCaretInReadOnly = false;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            //
            //SubID
            //
            this.SubId.ColumnEdit = this.repositoryItemTextEdit2;
            this.SubId.FieldName = "SubId";
            this.SubId.Name = "SubId";
            this.SubId.Visible = true;
            this.SubId.VisibleIndex = 0;
            this.SubId.Width = 40;
            this.SubId.Caption = "序号";
            // 
            // TestSubReq
            // 
            this.TestSubReq.Caption = "测试需求子项";
            this.TestSubReq.ColumnEdit = this.repositoryItemMemoEdit2;
            this.TestSubReq.FieldName = "TestSubReq";
            this.TestSubReq.Name = "TestSubReq";
            this.TestSubReq.Visible = true;
            this.TestSubReq.VisibleIndex = 1;
            this.TestSubReq.Width = 177;
            // 
            // SubReqAnalyse
            // 
            this.SubReqAnalyse.Caption = "测试需求子项分析";
            this.SubReqAnalyse.ColumnEdit = this.repositoryItemRichTextEdit2;
            this.SubReqAnalyse.FieldName = "SubReqAnalyse";
            this.SubReqAnalyse.Name = "SubReqAnalyse";
            this.SubReqAnalyse.Visible = true;
            this.SubReqAnalyse.VisibleIndex =2;
            this.SubReqAnalyse.Width = 340;
            // 
            // TestSubIdentify
            // 
            this.TestSubIdentify.Caption = "测试子项标识";
            this.TestSubIdentify.ColumnEdit = this.repositoryItemTextEdit2;
            this.TestSubIdentify.FieldName = "TestSubIdentify";
            this.TestSubIdentify.Name = "TestSubIdentify";
            this.TestSubIdentify.Visible = true;
            this.TestSubIdentify.VisibleIndex = 3;
            this.TestSubIdentify.Width = 200;



          

            // 
            // m_EditGridForm
            // 
            m_EditGridForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            m_EditGridForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            m_EditGridForm.ClientSize = new System.Drawing.Size(953, 652);
            m_EditGridForm.Controls.Add(this.splitContainer1);
            m_EditGridForm.Controls.Add(this.btnCance);
            m_EditGridForm.Controls.Add(this.btnConfirm);
            
            m_EditGridForm.Name = "EditDialog";
            m_EditGridForm.Text = "EditDialog";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            m_EditGridForm.ResumeLayout(false);
            m_EditGridForm.PerformLayout();
        }
        /// <summary>
        /// 确认事件，返回表格对象
        /// </summary>
        private void btnConfirm_Click(object sender, EventArgs e)
        {          
            try
            {
                testGrid.Name = vGridControl1.GetCellValue(TestName, 0).ToString();
                testGrid.TestType = vGridControl1.GetCellValue(TestType, 0).ToString();
                testGrid.TestIdentify = vGridControl1.GetCellValue(TestIdentify, 0).ToString();
                testGrid.TestPriority= testPrio_index;
                testGrid.TraceRelationships= vGridControl1.GetCellValue(TraceRelationships, 0).ToString();
                testGrid.TestContent= vGridControl1.GetCellValue(TestContent, 0).ToString();
                testGrid.TestReqResolve = "";
                testGrid.AdequacyRequirements= vGridControl1.GetCellValue(AdequacyRequirements, 0).ToString();
                testGrid.TerminalCondition= vGridControl1.GetCellValue(TerminalCondition, 0).ToString();
            }
            catch { }

            testSubTable = ((DataView)gridView1.DataSource).ToTable();
            //窗体对话框结果
            m_EditGridForm.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_EditGridForm.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 右键弹出删除菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gridControl1.ContextMenuStrip = this.contextMenuStrip1;
                contextMenuStrip1.Show(MousePosition);                
            }
        }


        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_Click(object sender, EventArgs e)
        {
            if (gridView1 == null || gridView1.SelectedRowsCount <= 0) return;
            DataRow[] dataRows = new DataRow[gridView1.SelectedRowsCount];

            for (var i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                dataRows[i] = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
            }
            gridView1.BeginSort();
            try
            {
                foreach (DataRow row in dataRows)
                {
                    row.Delete();
                }

            }
            catch { }

            finally
            {
                gridView1.EndSort();

            }
        }

        /// <summary>
        /// 测试优先级选项改变，获得testPro_index值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Testprio_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string editvalue = ((DevExpress.XtraEditors.RadioGroup)sender).EditValue.ToString();

            testPrio_index = Convert.ToInt32((((DevExpress.XtraEditors.RadioGroup)sender).EditValue));
           // Console.WriteLine(testPrio_index);
            //string str = repositoryItemRadioGroup1.Properties.Items.GetItemByValue(testPrio_index).Description;
            //放入所需的表格值中

           // Console.WriteLine(str);
        }


        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowForm()
        {
            //追踪关系自动添加到表格
            try
            {
                //多对一情况
                IList<TreeNode> nodeList = TreeForm.treeform1.designTreeView.SelectedNodeList;
                StringBuilder strtmp=new StringBuilder();
                UInt16 count=0;
                foreach(TreeNode node in nodeList)
                {
                    if(count==0)
                    {
                        strtmp.Append(node.Text);
                    }
                    else
                    {
                        strtmp.Append("\r\n" + node.Text);
                    }
                    count++;
                }
                //vGridControl1.SetCellValue(TraceRelationships, 0, TreeForm.treeform1.designTreeView.SelectedNode.Text);
                vGridControl1.SetCellValue(TraceRelationships, 0, strtmp);
            }
            catch
            {
                MessageBox.Show("请选择节点");
                return DialogResult.Cancel;
            }
            return m_EditGridForm.ShowDialog();
        }

    }

    /// <summary>
    /// 编辑用例表格类窗体
    /// </summary>
    public class EditYLGridDialog : Form
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




        public Form m_EditYLGridForm = new Form();

        public YLGridObject ylGrid; //返回的V表格对象
        public DataTable ylSubTable; //gridcontrol绑定的表格


        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCance;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1; //右键快捷键
        private System.Windows.Forms.ToolStripMenuItem delete;  //菜单里的删除按键


        //用例表格控件
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow YlNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow YlName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow YlIdentify;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TraceRelationships;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow YlSummarize;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow YlInitialize;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow PrerequisiteConstraints;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TestProcedures;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TerminalCondition;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow PassCriteria;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Designer;
        private DevExpress.XtraGrid.Columns.GridColumn SubId;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn InputOperation;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn ExpectedOut;


        public EditYLGridDialog()
        {
            InitializeComponent();
            gridControl1.DataSource = ylSubTable; //绑定表格
        }



        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ylGrid = new YLGridObject();
            this.ylSubTable = new DataTable();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCance = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delete = new System.Windows.Forms.ToolStripMenuItem();


            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.YlNumber = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.YlName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.YlIdentify = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TraceRelationships = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.YlSummarize = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.YlInitialize = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.PrerequisiteConstraints = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TestProcedures = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TerminalCondition = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.PassCriteria = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Designer = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.SubId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.InputOperation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpectedOut = new DevExpress.XtraGrid.Columns.GridColumn();


            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();


            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            m_EditYLGridForm.SuspendLayout();


            //
            //editTable
            //
            DataColumn[] cols = {
                                  new DataColumn("SubId",typeof(UInt16)),
                                  new DataColumn("InputOperation",typeof(string)),
                                  new DataColumn("ExpectedOut",typeof(string))
            };
            this.ylSubTable.Columns.AddRange(cols);
            this.ylSubTable.PrimaryKey = new DataColumn[] { ylSubTable.Columns["Id"] };
            //editTable.Columns["Id"].AutoIncrement = true;


            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.Location = new System.Drawing.Point(171, 613);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCance
            // 
            this.btnCance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCance.Location = new System.Drawing.Point(654, 613);
            this.btnCance.Name = "btnCance";
            this.btnCance.Size = new System.Drawing.Size(75, 23);
            this.btnCance.TabIndex = 1;
            this.btnCance.Text = "取消";
            this.btnCance.UseVisualStyleBackColor = true;
            this.btnCance.Click += btnCancel_Click;

            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);

            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(152, 22);
            this.delete.Text = "删除";
            this.delete.Click += new System.EventHandler(this.delete_Click);




            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(28, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.vGridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(895, 585);
            this.splitContainer1.SplitterDistance = 351;
            this.splitContainer1.TabIndex = 0;
            // 
            // vGridControl1
            // 
            this.vGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGridControl1.Location = new System.Drawing.Point(0, 0);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.OptionsView.AutoScaleBands = true;
            this.vGridControl1.RecordWidth = 175;
            this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemMemoEdit1});
            this.vGridControl1.RowHeaderWidth = 25;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.YlNumber,
            this.YlName,
            this.YlIdentify,
            this.TraceRelationships,
            this.YlSummarize,
            this.YlInitialize,
            this.PrerequisiteConstraints,
            this.TestProcedures,
            this.TerminalCondition,
            this.PassCriteria,
            this.Designer});
            this.vGridControl1.Size = new System.Drawing.Size(895, 351);
            this.vGridControl1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit2,
            this.repositoryItemMemoEdit2});
            this.gridControl1.Size = new System.Drawing.Size(895, 230);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseDown);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SubId,
            this.InputOperation,
            this.ExpectedOut});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // YlNumber
            // 
            this.YlNumber.Name = "YlNumber";
            this.YlNumber.Properties.Caption = "用例编号";
            this.YlNumber.Properties.FieldName = "Name";
            this.YlNumber.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // YlName
            // 
            this.YlName.Name = "YlName";
            this.YlName.Properties.Caption = "测试用例名称";
            this.YlName.Properties.FieldName = "YlName";
            this.YlName.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // YlIdentify
            // 
            this.YlIdentify.Name = "YlIdentify";
            this.YlIdentify.Properties.Caption = "标识";
            this.YlIdentify.Properties.FieldName = "YlIdentify";
            this.YlIdentify.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // TraceRelationships
            // 
            this.TraceRelationships.Height = 65;
            this.TraceRelationships.Name = "TraceRelationships";
            this.TraceRelationships.Properties.Caption = "追踪关系";
            this.TraceRelationships.Properties.FieldName = "TraceRelationships";
            this.TraceRelationships.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // YlSummarize
            // 
            this.YlSummarize.Height = 45;
            this.YlSummarize.Name = "YlSummarize";
            this.YlSummarize.Properties.Caption = "测试用例综述";
            this.YlSummarize.Properties.FieldName = "YlSummarize";
            this.YlSummarize.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // YlInitialize
            // 
            this.YlInitialize.Height = 33;
            this.YlInitialize.Name = "YlInitialize";
            this.YlInitialize.Properties.Caption = "用例初始化";
            this.YlInitialize.Properties.FieldName = "YlInitialize";
            this.YlInitialize.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // PrerequisiteConstraints
            // 
            this.PrerequisiteConstraints.Height = 31;
            this.PrerequisiteConstraints.Name = "PrerequisiteConstraints";
            this.PrerequisiteConstraints.Properties.Caption = "前提和约束";
            this.PrerequisiteConstraints.Properties.FieldName = "PrerequisiteConstraints";
            this.PrerequisiteConstraints.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // TestProcedures
            // 
            this.TestProcedures.Name = "TestProcedures";
            this.TestProcedures.Properties.Caption = "测试步骤";
            this.TestProcedures.Properties.FieldName = "TestProcedures";
            this.TestProcedures.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // TerminalCondition
            // 
            this.TerminalCondition.Height = 33;
            this.TerminalCondition.Name = "TerminalCondition";
            this.TerminalCondition.Properties.Caption = "终止条件";
            this.TerminalCondition.Properties.FieldName = "TerminalCondition";
            this.TerminalCondition.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // PassCriteria
            // 
            this.PassCriteria.Height = 22;
            this.PassCriteria.Name = "PassCriteria";
            this.PassCriteria.Properties.Caption = "通过准则";
            this.PassCriteria.Properties.FieldName = "PassCriteria";
            this.PassCriteria.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // Designer
            // 
            this.Designer.Name = "Designer";
            this.Designer.Properties.Caption = "设计者";
            this.Designer.Properties.FieldName = "Designer";
            this.Designer.Properties.RowEdit = this.repositoryItemTextEdit1;
            // 
            // SubId
            // 
            this.SubId.Caption = "序号";
            this.SubId.ColumnEdit = this.repositoryItemTextEdit2;
            this.SubId.FieldName = "SubId";
            this.SubId.Name = "SubId";
            this.SubId.Visible = true;
            this.SubId.VisibleIndex = 0;
            this.SubId.Width = 54;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // InputOperation
            // 
            this.InputOperation.Caption = "输入及操作";
            this.InputOperation.ColumnEdit = this.repositoryItemMemoEdit2;
            this.InputOperation.FieldName = "InputOperation";
            this.InputOperation.Name = "InputOperation";
            this.InputOperation.Visible = true;
            this.InputOperation.VisibleIndex = 1;
            this.InputOperation.Width = 410;
            // 
            // ExpectedOut
            // 
            this.ExpectedOut.Caption = "期望结果与评估标准";
            this.ExpectedOut.ColumnEdit = this.repositoryItemMemoEdit2;
            this.ExpectedOut.FieldName = "ExpectedOut";
            this.ExpectedOut.Name = "ExpectedOut";
            this.ExpectedOut.Visible = true;
            this.ExpectedOut.VisibleIndex = 2;
            this.ExpectedOut.Width = 413;






            // 
            // EditYLGridDialog
            // 
            m_EditYLGridForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            m_EditYLGridForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            m_EditYLGridForm.ClientSize = new System.Drawing.Size(953, 652);
            m_EditYLGridForm.Controls.Add(this.btnCance);
            m_EditYLGridForm.Controls.Add(this.btnConfirm);
            m_EditYLGridForm.Controls.Add(this.splitContainer1);
            m_EditYLGridForm.Name = "EditYLGridDialog";
            m_EditYLGridForm.Text = "EditYLGridDialog";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            m_EditYLGridForm.ResumeLayout(false);
            m_EditYLGridForm.PerformLayout();
        }
        /// <summary>
        /// 确认事件，返回表格对象
        /// </summary>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //testGrid.Name = vGridControl1.GetCellValue(TestName, 0).ToString();
                //testGrid.TestType = vGridControl1.GetCellValue(TestType, 0).ToString();
                //testGrid.TestIdentify = vGridControl1.GetCellValue(TestIdentify, 0).ToString();
                //testGrid.TestPriority = testPrio_index;
                //testGrid.TraceRelationships = vGridControl1.GetCellValue(TraceRelationships, 0).ToString();
                //testGrid.TestContent = vGridControl1.GetCellValue(TestContent, 0).ToString();
                //testGrid.TestReqResolve = "";
                //testGrid.AdequacyRequirements = vGridControl1.GetCellValue(AdequacyRequirements, 0).ToString();
                //testGrid.TerminalCondition = vGridControl1.GetCellValue(TerminalCondition, 0).ToString();
                ylGrid.Name= vGridControl1.GetCellValue(YlNumber, 0).ToString();
                ylGrid.YlName= vGridControl1.GetCellValue(YlName, 0).ToString();
                ylGrid.YlIdentify = vGridControl1.GetCellValue(YlIdentify, 0).ToString();
                ylGrid.TraceRelationships = vGridControl1.GetCellValue(TraceRelationships, 0).ToString();
                ylGrid.YlSummarize = vGridControl1.GetCellValue(YlSummarize, 0).ToString();
                ylGrid.YlInitialize = vGridControl1.GetCellValue(YlInitialize, 0).ToString();
                ylGrid.PrerequisiteConstraints = vGridControl1.GetCellValue(PrerequisiteConstraints, 0).ToString();
                //ylGrid.TestProcedures = vGridControl1.GetCellValue(TestProcedures, 0).ToString();
                ylGrid.TerminalCondition = vGridControl1.GetCellValue(TerminalCondition, 0).ToString();
                ylGrid.PassCriteria = vGridControl1.GetCellValue(PassCriteria, 0).ToString();
                ylGrid.Designer = vGridControl1.GetCellValue(Designer, 0).ToString();
            }
            catch { }

            ylSubTable = ((DataView)gridView1.DataSource).ToTable();
            //窗体对话框结果
            m_EditYLGridForm.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_EditYLGridForm.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 右键弹出删除菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gridControl1.ContextMenuStrip = this.contextMenuStrip1;
                contextMenuStrip1.Show(MousePosition);
            }
        }


        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_Click(object sender, EventArgs e)
        {
            if (gridView1 == null || gridView1.SelectedRowsCount <= 0) return;
            DataRow[] dataRows = new DataRow[gridView1.SelectedRowsCount];

            for (var i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                dataRows[i] = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
            }
            gridView1.BeginSort();
            try
            {
                foreach (DataRow row in dataRows)
                {
                    row.Delete();
                }

            }
            catch { }

            finally
            {
                gridView1.EndSort();

            }
        }




        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowForm()
        {
            //追踪关系自动添加到表格
            try
            {
                
                StringBuilder strtmp = new StringBuilder();
                UInt16 count = 0;
                for (UInt16 i=0;i<3;i++)
                {
                    if (count == 0)
                    {
                        strtmp.Append("软件测试依据：测试需求规格说明");
                    }
                    else if(count == 1)
                    {
                        strtmp.Append("\r\n测试需求分析：" + TreeForm.treeform1.testTreeView.SelectedNode.Text);
                    }
                    else if(count == 2)
                    {
                        strtmp.Append("\r\n测试需求标识：");
                    }
                    count++;
                }
                //vGridControl1.SetCellValue(TraceRelationships, 0, TreeForm.treeform1.designTreeView.SelectedNode.Text);
                vGridControl1.SetCellValue(TraceRelationships, 0, strtmp);
            }
            catch
            {
                MessageBox.Show("请选择节点");
                return DialogResult.Cancel;
            }
            return m_EditYLGridForm.ShowDialog();
        }

    }

}
