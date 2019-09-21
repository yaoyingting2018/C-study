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
            this.splitContainer1.SplitterDistance = 322;
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
            this.vGridControl1.Size = new System.Drawing.Size(760, 322);
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
        private DevExpress.XtraVerticalGrid.Rows.EditorRow PId;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Id;
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
            this.PId = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Id = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
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
            this.PId,
            this.Id,
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


}
