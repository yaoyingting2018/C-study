using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;


namespace docWriting
{
    
    public partial class TreeForm : Form
    {

        public static TreeForm treeform1;
        UInt16 flag; //树控件标识位，根据不同的树控件，各种处理方法(加载控件，添加节点等)不同
        TreeView tmpTree;//根据选项卡不同选中的树控件
        EditDialog tmpDialog;//定义弹出的窗体类，主要是弹出文本框控件添加节点名称
        EditGridDialog tmpGridDialog; //定义弹出的窗体编辑表格

        string m_sDesignXmlFile = Environment.CurrentDirectory + "\\DesignTreeTest.xml";
        string m_sTestXmlFile = Environment.CurrentDirectory + "\\TestTreeTest.xml";
        string m_sYlXmlFile = Environment.CurrentDirectory + "\\YlTreeTest.xml";
        string m_sReportXmlFile = Environment.CurrentDirectory + "\\ReportTreeTest.xml";
        string m_sZongXmlFile = Environment.CurrentDirectory + "\\ZongTreeTest.xml";

        DataSet m_dataSet; //表格集
        DataTable m_ZongDataTable;//存储总树的信息

        DataTable m_DesignDataTable;//存储设计树的信息

        DataTable m_TestDataTable;//存储测试树的信息
        DataTable m_TestSubDataTable; //测试需求分解表格

        DataTable m_YLDataTable;//存储用例树的信息

        DataTable m_ReportDataTable;//存储报告树的信息


        DataTable tmpDesigndt;//绑定设计树的datagrid用        
        DataTable tmpTestdt;//绑定测试树的vgridcontrol用
        DataTable tmpTestSubdt;//绑定测试树的gridcontrol用

        int testPrio_index = 0;   //测试优先级0-高 1-中 2-低,默认加载为高

        uint tmpTag = 0; //记录上一次树节点的Tag值
        DataRow tmpdr;  //存储上一次点击节点修改的数据


        public TreeForm()
        {
            InitializeComponent();
            TreeNodeDoubleClick();//添加双击编辑事件
            Tree_AfterSelect(); //添加选中节点显示节点信息            
            TreeNodeAfterEdit();//添加节点编辑之后的事件
            save.ItemClick += saveButton_ItemClick; //工具栏的保存按钮

            tmpTree = zongTreeView;
            m_dataSet = new DataSet(); //测试需求表格集
            m_ZongDataTable = new DataTable("zongtable");
            m_DesignDataTable = new DataTable("designtable");
            m_TestDataTable = new DataTable("testtable");
            m_TestSubDataTable = new DataTable("testsubtable");
            m_YLDataTable = new DataTable("yltable");
            m_ReportDataTable = new DataTable("reporttable");

            //表格初始化，添加列
            InitDataSet(ref m_dataSet);
            treeform1 = this;
        }


        /// <summary>
        /// 初始化表格
        /// </summary>
        /// <param name="dataSet"></param>

        private void InitDataSet(ref DataSet dataSet)
        {
            foreach (DeisgnXmlSchema p in DeisgnXmlSchema.m_aXmlParas)
            {
                m_DesignDataTable.Columns.Add(p.m_sName, p.m_Type);

            }
            m_DesignDataTable.PrimaryKey = new DataColumn[] { m_DesignDataTable.Columns["Id"] };
            m_DesignDataTable.Columns["Id"].AutoIncrement = true;

            foreach (TestXmlSchema p in TestXmlSchema.m_aXmlParas)
            {
                m_TestDataTable.Columns.Add(p.m_sName, p.m_Type);
            }
            foreach (TestXmlSchema p in TestXmlSchema.m_testSubXmlParas)
            {
                m_TestSubDataTable.Columns.Add(p.m_sName, p.m_Type);
            }

            m_TestDataTable.PrimaryKey = new DataColumn[] { m_TestDataTable.Columns["Id"] };
            m_TestDataTable.Columns["Id"].AutoIncrement = true;

           // dataSet.Tables.Add(m_DesignDataTable);
            dataSet.Tables.Add(m_TestDataTable);
            dataSet.Tables.Add(m_TestSubDataTable);


        }

        /// <summary>
        /// 节点双击编辑事件
        /// </summary>
        private void TreeNodeDoubleClick()
        {
            zongTreeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            designTreeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            testTreeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            ylTreeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            reportTreeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
        }


        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tmpTree.LabelEdit = true;
            tmpTree.SelectedNode.BeginEdit();
        }

        /// <summary>
        /// 节点选中，显示其节点内容
        /// </summary>
        private void Tree_AfterSelect()
        {
            this.designTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            this.testTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
        }

        /// <summary>
        /// 节点编辑之后保存表格
        /// </summary>
        private void TreeNodeAfterEdit()
        {

            designTreeView.AfterLabelEdit += treeView_AfterLabelEdit;

        }

        /// <summary>
        /// 树节点编辑之后，Name字段数据存入表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            uint id = Convert.ToUInt32(e.Node.Tag);
            DataRow[] rows;
            //双击没有更改树节点文本标签时，e.Label=null
            if (e.Label != null)
            {
                switch (flag)
                {
                    case 0: break;
                    case 1:
                        rows = m_DesignDataTable.Select("Id='" + id + "'");
                        rows[0].BeginEdit();//写回去表格
                        rows[0]["Name"] = e.Label;
                        //rows[0]["Name"] = e.Node.Text;                      
                        rows[0].EndEdit();                        
                        dataGridView[2, 0].Value = e.Label;//界面上视图的改变
                        m_DesignDataTable.AcceptChanges();
                        break;
                    case 2:
                        rows= m_TestDataTable.Select("Id='" + id + "'");
                        //写回去表格
                        rows[0].BeginEdit();
                        rows[0]["Name"] = e.Label;
                        rows[0].EndEdit();                        
                       // vGridControl.SetCellValue(vGridControl.Rows["Name"], 0, e.Label);//界面上视图的改变
                        m_TestDataTable.AcceptChanges();
                        break;
                    case 3:break;
                    case 4:break;
                    default:
                        break;

                }
            }
        }

        /// <summary>
        /// 选项卡改变，选中不同的treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                flag = 0;
                tmpTree = zongTreeView;
                this.Controls.Remove(this.splitContainer); //移除控件
                this.Controls.Remove(this.splitContainer1); 
                //this.Controls.Remove(this.vGridControl);
                //this.Controls.Remove(this.gridControl1);

            }
            else if (tabControl.SelectedIndex == 1)
            {
                flag = 1;
                tmpTree = designTreeView;
                
                designTreeView.TreeNodeCanAcceptDragedHandler += (source, target) =>
                { 
                    MessageBox.Show("将" + source.Text + "拖动到了" + target.Text);
                };
                // this.Controls.Remove(this.vGridControl);
                //this.Controls.Remove(this.gridControl1);
                this.Controls.Remove(this.splitContainer1);
                CreatesplitContainer(); //创建控件，包含DataGridView和RichTextBox

                tmpDesigndt = new DataTable();
                foreach (DeisgnXmlSchema p in DeisgnXmlSchema.m_aXmlParas)
                {
                    tmpDesigndt.Columns.Add(p.m_sName, p.m_Type);
                }

                tmpdr = m_DesignDataTable.NewRow();

                dataGridView.DataSource = tmpDesigndt;
                dataGridView.Columns[3].Visible = false; //第四列不可见。测试内容绑定富文本框控件                
                dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//调整列宽填充整个控件                                                                                         
                dataGridView.RowHeadersVisible = true;  //包含行标题的列                
                dataGridView.Columns[0].ReadOnly = true;//PID.ID不可编辑
                dataGridView.Columns[1].ReadOnly = true;
                //richtextBox的Rtf属性绑定tmpDeisgndt表格的DesignContent字段
                richTextBox.DataBindings.Add(new Binding("Rtf", tmpDesigndt, "DesignContent"));
                dataGridView.CellMouseClick += dataGridView_CellMouseClick;
                dataGridView.CellValueChanged += dataGridView_CellValueChanged; //单元格值改变，保存到表格中
                richTextBox.Leave += richTextBox_MouseLeave;//焦点离开时保存表格
                



            }
            else if (tabControl.SelectedIndex == 2)
            {
                flag = 2;
                tmpTree = testTreeView;
                testTreeView.Nodes.Clear(); //清空测试节点
                InitTree(testTreeView.Nodes, "0", m_dataSet.Tables["testtable"]); //表格重新绑定树控件
                testTreeView.ExpandAll();
                this.Controls.Remove(this.splitContainer); //移除控件
                CreateGridControl(); //创建控件，包含垂直表格和测试子需求表格

                //把测试标识枚举类型加入到repositoryItemComboBox中
                for (int i = 0; i < Enum.GetNames(typeof(TestItendify)).Length; i++)
                {

                    string strTestItendify = Enum.GetName(typeof(TestItendify), i);

                    repositoryItemComboBox1.Items.Add(strTestItendify);
                }

                RadioGroupItem r1 = new RadioGroupItem(0, "高");
                RadioGroupItem r2 = new RadioGroupItem(1, "中");
                RadioGroupItem r3 = new RadioGroupItem(2, "低");
                repositoryItemRadioGroup1.Items.Add(r1);
                repositoryItemRadioGroup1.Items.Add(r2);
                repositoryItemRadioGroup1.Items.Add(r3);
                //单选按钮在值改变的时候获取选中的值
                repositoryItemRadioGroup1.SelectedIndexChanged += Testprio_SelectedIndexChanged;

                tmpTestdt = new DataTable();
                tmpTestSubdt = new DataTable();
                DataColumn[] cols = {
                    new DataColumn("PId", typeof(uint)),
                    new DataColumn("Id", typeof(uint)),
                    new DataColumn("Name", typeof(string)),
                    new DataColumn("TestIdentify", typeof(string)),
                    new DataColumn("TestPriority", typeof(int)),
                    new DataColumn("TraceRelationships", typeof(string)),
                    new DataColumn("TestContent", typeof(string)),
                    new DataColumn("TestReqResolve", typeof(string)),
                    new DataColumn("AdequacyRequirements", typeof(string)),
                    new DataColumn("TerminalCondition", typeof(string))
                };
                tmpTestdt.Columns.AddRange(cols);
                DataColumn[] cols2 = {
                    new DataColumn("SubId",typeof(uint)),
                    new DataColumn("TestSubReq",typeof(string)),
                    new DataColumn("SubReqAnalyse",typeof(string)),
                    new DataColumn("TestSubIdentify",typeof(string))
                };
                tmpTestSubdt.Columns.AddRange(cols2);

                vGridControl1.DataSource = tmpTestdt;
                gridControl1.DataSource = tmpTestSubdt;





            }
            else if (tabControl.SelectedIndex == 3)
            {
                flag = 3;
                tmpTree = ylTreeView;
                this.Controls.Remove(this.splitContainer); //移除控件
                this.Controls.Remove(this.splitContainer1);
                //this.Controls.Remove(this.vGridControl);
                //this.Controls.Remove(this.gridControl1);

            }
            else if (tabControl.SelectedIndex == 4)
            {
                flag = 4;
                tmpTree = reportTreeView;
                this.Controls.Remove(this.splitContainer); //移除控件
                this.Controls.Remove(this.splitContainer1);
                //this.Controls.Remove(this.vGridControl);
                //this.Controls.Remove(this.gridControl1);

            }
        }

        /// <summary>
        /// richTextBox焦点离开时保存表格  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox_MouseLeave(object sender, EventArgs e)
        {
            if (tmpTag != 0)
            {
                DataRow[] rows = m_DesignDataTable.Select("Id='" + tmpTag + "'");
                //写回去表格
                rows[0].BeginEdit();
                // rows[0]["Name"] = tmpTree.SelectedNode.Text;
                rows[0]["DesignContent"] = richTextBox.Rtf;
                rows[0].EndEdit();
            }
            //Console.WriteLine(richTextBox.Rtf);

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
            Console.WriteLine(testPrio_index);
            string str = repositoryItemRadioGroup1.Properties.Items.GetItemByValue(testPrio_index).Description;
            //放入所需的表格值中

            Console.WriteLine(str);
        }
        /// <summary>
        /// 添加根节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addRoot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tmpDialog = new EditDialog();//动态添加编辑控件（控件放在窗体中）
            TreeNode tmpNode = new TreeNode();
            UInt16 count; //Id=1的节点个数
            DataRow dr; //行数据
            DataRow[] rows; //多个行数据

            switch (flag)
            {
                case 0: break;
                case 1:
                    dr = m_DesignDataTable.NewRow();
                    rows = m_DesignDataTable.Select("Id='1'");
                    count = (UInt16)rows.Count<DataRow>();
                    //判断ID=1是否存在，定义开始的节点ID为1，ID和PID同时为0，树节点递归显示不出，无限循环
                    if (count == 0)
                    {
                        if (tmpDialog.Show() == DialogResult.OK)
                        {
                            //添加根节点到树节点集合中
                            tmpNode.Text = tmpDialog.NodeName;
                            dr["PId"] = 0;
                            dr["Id"] = 1;
                            dr["Name"] = tmpDialog.NodeName;
                            dr["DesignContent"] = "";
                            m_DesignDataTable.Rows.Add(dr);
                            tmpNode.Tag = dr["Id"];//object类型
                            tmpTree.Nodes.Add(tmpNode);
                        }
                    }
                    else
                    {
                        if (tmpDialog.Show() == DialogResult.OK)
                        {
                            //添加根节点到树节点集合中
                            tmpNode.Text = tmpDialog.NodeName;
                            dr["PId"] = 0;
                            dr["Name"] = tmpDialog.NodeName;
                            dr["DesignContent"] = "";
                            m_DesignDataTable.Rows.Add(dr);
                            tmpNode.Tag = dr["Id"];//object类型
                            tmpTree.Nodes.Add(tmpNode);
                        }
                    }
                    break;
                case 2:
                    dr = m_TestDataTable.NewRow();
                    rows = m_TestDataTable.Select("Id='1'");
                    count = (UInt16)rows.Count<DataRow>();

                    if (count == 0)
                    {
                        if (tmpDialog.Show() == DialogResult.OK)
                        {
                            //添加根节点到树节点集合中
                            tmpNode.Text = tmpDialog.NodeName;
                            dr["PId"] = 0;
                            dr["Id"] = 1;
                            dr["TestType"] = "";
                            dr["IdList"] = "";
                            dr["Name"] = tmpDialog.NodeName;
                            dr["TestIdentify"] = "";
                            dr["TestPriority"] = 0;
                            dr["TraceRelationships"] = "";
                            dr["TestContent"] = "";
                            dr["TestReqResolve"] = "";
                            dr["AdequacyRequirements"] = "";
                            dr["TerminalCondition"] = "";
                            m_TestDataTable.Rows.Add(dr);
                            tmpNode.Tag = dr["Id"];//object类型
                            tmpTree.Nodes.Add(tmpNode);
                        }
                    }
                    else
                    {
                        // DataRow dr1 = m_TestDataTable.NewRow();
                        if (tmpDialog.Show() == DialogResult.OK)
                        {
                            //添加根节点到树节点集合中
                            tmpNode.Text = tmpDialog.NodeName;
                            dr["PId"] = 0;
                            dr["TestType"] = "";
                            dr["IdList"] = "";
                            dr["Name"] = tmpDialog.NodeName;
                            dr["TestIdentify"] = "";
                            dr["TestPriority"] = 0;
                            dr["TraceRelationships"] = "";
                            dr["TestContent"] = "";
                            dr["TestReqResolve"] = "";
                            dr["AdequacyRequirements"] = "";
                            dr["TerminalCondition"] = "";
                            m_TestDataTable.Rows.Add(dr);
                            tmpNode.Tag = dr["Id"];//object类型
                            tmpTree.Nodes.Add(tmpNode);
                        }
                    }
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 添加子节点，并自动对PID,ID编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 动态添加控件（控件放在窗体中）
            // ftmp = new EditForm();
            tmpDialog = new EditDialog();
            TreeNode tmpNode = new TreeNode();
            DataRow dr; //行数据


            switch (flag)
            {
                case 0: break;
                case 1:
                    dr = m_DesignDataTable.NewRow();
                    if (tmpDialog.Show() == DialogResult.OK)
                    {
                        //添加子节点到树节点集合中,根据树不同，添加的表格不同
                        try
                        {
                            tmpNode.Text = tmpDialog.NodeName;
                            dr["PId"] = Convert.ToUInt32(tmpTree.SelectedNode.Tag);
                            dr["Name"] = tmpDialog.NodeName;
                            dr["DesignContent"] = "";
                            m_DesignDataTable.Rows.Add(dr);
                            tmpNode.Tag = dr["Id"];//object类型
                            tmpTree.SelectedNode.Nodes.Add(tmpNode);
                        }
                        catch
                        {
                            MessageBox.Show("请选择根节点");
                        }
                        //展开所有的树节点
                        tmpTree.ExpandAll();
                    }
                    break;
                case 2:
                    dr = m_TestDataTable.NewRow();
                    // ftmp.Flag = true;
                    if (tmpDialog.Show() == DialogResult.OK)
                    {
                        //添加子节点到树节点集合中,根据树不同，添加的表格不同
                        try
                        {
                            tmpNode.Text = tmpDialog.NodeName;

                            dr["PId"] = Convert.ToUInt32(tmpTree.SelectedNode.Tag);
                            dr["TestType"] = tmpTree.SelectedNode.Text;
                            dr["IdList"] = "";
                            dr["Name"] = tmpDialog.NodeName;
                            dr["TestIdentify"] = "";
                            dr["TestPriority"] = 0;
                            dr["TraceRelationships"] = "";
                            dr["TestContent"] = "";
                            dr["TestReqResolve"] = "";
                            dr["AdequacyRequirements"] = "";
                            dr["TerminalCondition"] = "";
                            m_TestDataTable.Rows.Add(dr);
                            tmpNode.Tag = dr["Id"];//object类型
                            tmpTree.SelectedNode.Nodes.Add(tmpNode);
                        }
                        catch
                        {
                            MessageBox.Show("请选择根节点");
                        }
                        //展开所有的树节点
                        tmpTree.ExpandAll();
                    }
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;


            }
        }

        /// <summary>
        /// 编辑节点,只改变节点Name字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tmpDialog = new EditDialog();
            DataRow[] rows;
            //树节点的富文本框添加现在选中节点的名字
            try
            {
                uint id = Convert.ToUInt32(tmpTree.SelectedNode.Tag);
                tmpDialog.RichTextBox.Text = tmpTree.SelectedNode.Text; //回填现在的节点名字

                if (tmpDialog.Show() == DialogResult.OK)
                {

                    tmpTree.SelectedNode.Text = tmpDialog.NodeName; //改变节点的名字
                }

                switch (flag)
                {
                    case 0: break;
                    case 1:
                        rows = m_DesignDataTable.Select("Id='" + id + "'");
                        rows[0].BeginEdit();
                        rows[0]["Name"] = tmpTree.SelectedNode.Text;
                        dataGridView[2, 0].Value = tmpTree.SelectedNode.Text;//界面上视图的改变
                        //rows[0]["DesignContent"] = richTextBox.Rtf; //先编辑内容，然后点击编辑节点，跟习惯的顺序不一致
                        rows[0].EndEdit();
                        break;
                    case 2:
                        rows = m_TestDataTable.Select("Id='" + id + "'");
                        rows[0].BeginEdit();
                        rows[0]["Name"] = tmpTree.SelectedNode.Text;
                       // vGridControl.SetCellValue(vGridControl.Rows["Name"], 0, tmpTree.SelectedNode.Text);//界面上视图的改变
                        //判断一下是否为空
                        //rows[0]["TestIdentify"] = vGridControl.GetCellValue(TestIdentify, 0).ToString();
                        //rows[0]["TestPriority"] = testPrio_index;
                        //rows[0]["TraceRelationships"] = vGridControl.GetCellValue(TraceRelationships, 0).ToString();
                        //rows[0]["TestContent"] = vGridControl.GetCellValue(TestContent, 0).ToString();
                        //rows[0]["TestReqResolve"] = vGridControl.GetCellValue(TestReqResolve, 0).ToString();
                        //rows[0]["AdequacyRequirements"] = vGridControl.GetCellValue(AdequacyRequirements, 0).ToString();
                        //rows[0]["TerminalCondition"] = vGridControl.GetCellValue(TerminalCondition, 0).ToString();
                        rows[0].EndEdit();
                        break;

                }

            }
            catch
            {
                MessageBox.Show("请选择节点");
            }
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                uint tmpId = Convert.ToUInt32(tmpTree.SelectedNode.Tag.ToString());
                DataRow[] rows;
                switch (flag)
                {
                    case 0: break;
                    case 1:
                        rows = m_DesignDataTable.Select("Id='" + tmpId + "'");
                        rows[0].Delete();
                        break;
                    case 2:
                        rows = m_TestDataTable.Select("Id='" + tmpId + "'");
                        rows[0].Delete();
                        break;

                }

                tmpTree.SelectedNode.Remove();
            }
            catch
            {
                MessageBox.Show("请选择节点");
            }
        }

        /// <summary>
        /// 清空节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearNodes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            tmpTree.Nodes.Clear();//清空节点
            switch (flag)
            {
                case 0: break;
                case 1:
                    m_DesignDataTable.Rows.Clear();
                    break;
                case 2:
                    m_TestDataTable.Rows.Clear();
                    break;
                default: break;

            }
        }

        /// <summary>
        /// 打开word文档，载入到树控件上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            designTreeView.Nodes.Clear();  //清除树上的节点           
            m_DesignDataTable.Rows.Clear(); //表格数据清除
            string fileName = "";
            if (OpenFile(out fileName, "word文件|*.docx|word文件|*.doc", "Load word file"))
            {
                if (LoadWordFile(fileName))
                {
                   //BinTreeView(ref designTreeView, m_DesignDataTable); //表格绑定树控件
                   InitTree(designTreeView.Nodes, "0", m_DesignDataTable);
                   designTreeView.ExpandAll();

                }
            }
        }

        /// <summary>
        /// 打开文件操作
        /// </summary>
        /// <param name="sFile"></param>
        /// <param name="sFilter"></param>
        /// <param name="sTitle"></param>
        /// <returns></returns>
        public Boolean OpenFile(out String sFile, String sFilter, String sTitle)
        {
            OpenFileDialog t_OpenFileDlg = new OpenFileDialog();
            t_OpenFileDlg.Filter = sFilter;
            t_OpenFileDlg.Multiselect = false;
            t_OpenFileDlg.Title = sTitle;
            t_OpenFileDlg.ShowDialog();
            if (!String.IsNullOrWhiteSpace(t_OpenFileDlg.FileName))
            {
                sFile = t_OpenFileDlg.FileName.Trim();
                if (File.Exists(sFile))
                {
                    return (true);
                }
            }
            sFile = null;
            return (false);
        }

        /// <summary>
        /// 载入word文档
        /// </summary>
        /// <param name="sWordFilePath"></param>
        /// <returns></returns>

        public Boolean LoadWordFile(string sWordFilePath)
        {
            Document doc = new Document();
            try
            {
                doc.LoadFromFile(sWordFilePath);
                //遍历文档中的section
                uint i = 0;
                DataRow tmpRow;
                uint tmpPId;
                foreach (Section section in doc.Sections)
                {
                    foreach (Paragraph paragraph in section.Paragraphs)
                    {
                        try
                        {
                            //判断段落标题名称
                            if (paragraph.StyleName == "Heading 1")
                            {
                                tmpRow = m_DesignDataTable.NewRow();
                                i++;
                                tmpRow["PId"] = 0;
                                tmpRow["Id"] = Convert.ToUInt32(i);
                                tmpRow["Name"] = paragraph.Text;
                                tmpRow["DesignContent"] = "";
                                m_DesignDataTable.Rows.Add(tmpRow);
                            }
                            if (paragraph.StyleName == "Heading 2")
                            {
                                tmpRow = m_DesignDataTable.NewRow();
                                i++;

                                if (GetParentId(0) == 100000)
                                {
                                    MessageBox.Show("一级标题的样式不对！");
                                    return false;
                                }
                                tmpRow["PId"] = GetParentId(0);
                                tmpRow["Id"] = Convert.ToUInt32(i);
                                tmpRow["Name"] = paragraph.Text;
                                tmpRow["DesignContent"] = "";
                                m_DesignDataTable.Rows.Add(tmpRow);
                            }
                            if (paragraph.StyleName == "Heading 3")
                            {
                                tmpRow = m_DesignDataTable.NewRow();
                                i++;
                               
                                tmpPId = GetParentId(0);
                                if (GetParentId(tmpPId) == 100000)
                                {
                                    MessageBox.Show("二级标题的样式不对！");
                                    return false;
                                }
                                tmpRow["PId"] = GetParentId(tmpPId);

                                tmpRow["Id"] = Convert.ToUInt32(i);
                                tmpRow["Name"] = paragraph.Text;
                                tmpRow["DesignContent"] = "";
                                m_DesignDataTable.Rows.Add(tmpRow);
                            }
                            if (paragraph.StyleName == "Heading 4")
                            {
                                tmpRow = m_DesignDataTable.NewRow();
                                i++;
                                tmpPId = GetParentId(0);
                                tmpPId = GetParentId(tmpPId);
                                if (GetParentId(tmpPId) == 100000)
                                {
                                    MessageBox.Show("三级标题的样式不对！");
                                    return false;
                                }
                                tmpRow["PId"] = GetParentId(tmpPId);
                                tmpRow["Id"] = Convert.ToUInt32(i);
                                tmpRow["Name"] = paragraph.Text;
                                tmpRow["DesignContent"] = "";
                                m_DesignDataTable.Rows.Add(tmpRow);
                            }
                            if (paragraph.StyleName == "Heading 5")
                            {
                                tmpRow = m_DesignDataTable.NewRow();
                                i++;
                                tmpPId = GetParentId(0);
                                tmpPId = GetParentId(tmpPId);
                                tmpPId = GetParentId(tmpPId);
                                if (GetParentId(tmpPId) == 100000)
                                {
                                    MessageBox.Show("四级标题的样式不对！");
                                    return false;
                                }
                                tmpRow["PId"] = GetParentId(tmpPId);
                                tmpRow["Id"] = Convert.ToUInt32(i);
                                tmpRow["Name"] = paragraph.Text;
                                tmpRow["DesignContent"] = "";
                                m_DesignDataTable.Rows.Add(tmpRow);
                            }
                            //找到离文本最近的标题，内容归在那个标题下
                        }
                        catch { }

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("关闭当前打开的word文档" + ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 找到最近的PID=id的最大Id数据行
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public uint GetParentId(uint id)
        {
            //标准的标题样式，不是标准的识别不出来
            DataRow[] drArr = m_DesignDataTable.Select("PId='" + id + "'");
            try
            {
                uint tmpPId = Convert.ToUInt32(drArr[drArr.Length - 1]["Id"]);
                return tmpPId;
            }
            catch
            {
                MessageBox.Show("标题样式不对!");
                return 100000;
            }

        }

        /// <summary>
        /// 表绑定到树
        /// </summary>
        /// <param name="Nds"></param>
        /// <param name="parentId"></param>
        /// <param name="dt"></param>
        private void InitTree(TreeNodeCollection Nds, string parentId, DataTable dt)
        {
            DataView dv = new DataView();
            TreeNode tmpNd;
            dv.Table = dt;
            dv.RowFilter = "PId='" + parentId + "'";
            foreach (DataRowView drv in dv)
            {
                tmpNd = new TreeNode();
                tmpNd.Tag = drv["Id"].ToString();
                tmpNd.Text = drv["Name"].ToString();
                Nds.Add(tmpNd);               
                InitTree(tmpNd.Nodes, tmpNd.Tag.ToString(), dt);
            }

        }

        /// <summary>
        /// 保存整个树节点的信息，写入xml文件中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //uint tmpid;
            //DataRow[] rows;
            try
            {
                //switch (flag)
                //{
                //    case 0: break;
                //    //编辑之后保存，更新表格
                //    case 1:
                //       tmpid = Convert.ToUInt32(dataGridView[1, 0].Value.ToString());
                      
                //        rows = m_DesignDataTable.Select("Id='" + tmpid + "'");
                //        //写回去表格
                //        rows[0].BeginEdit();
                //        rows[0]["Name"] = tmpTree.SelectedNode.Text;
                //        rows[0]["DesignContent"] = richTextBox.Rtf;
                //        rows[0].EndEdit();
                //        break;
                //    case 2:
                //        tmpid = Convert.ToUInt32(vGridControl.GetCellValue(Id, 0).ToString());
                //        rows = m_TestDataTable.Select("Id='" + tmpid + "'");
                //        int count = rows.Count<DataRow>();
                //        if (count != 0)
                //        {
                //            rows[0].BeginEdit();
                //            rows[0]["Name"] = tmpTree.SelectedNode.Text;
                //            //判断一下是否为空
                //            //rows[0]["TestIdentify"] = vGridControl.GetCellValue(TestIdentify, 0).ToString();
                //            //rows[0]["TestPriority"] = testPrio_index;
                //            //rows[0]["TraceRelationships"] = vGridControl.GetCellValue(TraceRelationships, 0).ToString();
                //            //rows[0]["TestContent"] = vGridControl.GetCellValue(TestContent, 0).ToString();
                //            //rows[0]["TestReqResolve"] = vGridControl.GetCellValue(TestReqResolve, 0).ToString();
                //            //rows[0]["AdequacyRequirements"] = vGridControl.GetCellValue(AdequacyRequirements, 0).ToString();
                //            //rows[0]["TerminalCondition"] = vGridControl.GetCellValue(TerminalCondition, 0).ToString();
                          
                //            rows[0].EndEdit();
                //        }

                //        break;
                //}
                File.Copy("DesignTreeTest.xml", "DesignTreeTest.xml.bak", true);

                File.Copy("TestTreeTest.xml", "TestTreeTest.xml.bak", true);
            }
            catch { }
            m_DesignDataTable.WriteXml(m_sDesignXmlFile, XmlWriteMode.IgnoreSchema);
            // m_TestDataTable.WriteXml(m_sTestXmlFile, XmlWriteMode.IgnoreSchema);
            m_dataSet.WriteXml(m_sTestXmlFile, XmlWriteMode.IgnoreSchema);
            statusBar.Caption = "保存XML成功";
        }

       /// <summary>
       /// 另存为
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void saveAsButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string fileName = "";
            switch (flag)
            {
                case 0: break;
                case 1:
                    //保存之前对上一次结果做备份//多个表格，载入的话可以用表格集
                    if (SaveFile(out fileName, "DesignTreeTest.xml", "xml file|*.xml|all file|*.*"))
                    {
                        File.Copy("DesignTreeTest.xml", "DesignTreeTest.xml.bak", true);
                        m_DesignDataTable.WriteXml(fileName, XmlWriteMode.IgnoreSchema);
                    }
                    break;

                case 2:
                    //保存之前对上一次结果做备份//多个表格，载入的话可以用表格集
                    if (SaveFile(out fileName, "TestTreeTest.xml", "xml file|*.xml|all file|*.*"))
                    {
                        File.Copy("TestTreeTest.xml", "TestTreeTest.xml.bak", true);
                        m_TestDataTable.WriteXml(fileName, XmlWriteMode.IgnoreSchema);
                    }
                    break;
                default: break;
            }
            statusBar.Caption = "保存XML成功";
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="sFile"></param>
        /// <param name="sDefaultName"></param>
        /// <param name="sFilter"></param>
        /// <returns></returns>
        public Boolean SaveFile(out String sFile, String sDefaultName, String sFilter)
        {
            if (!String.IsNullOrWhiteSpace(sDefaultName))
            {
                if (Directory.Exists(Path.GetDirectoryName(sDefaultName)))
                {
                    sFile = sDefaultName;
                    return true;
                }
            }

            SaveFileDialog t_SaveXMLDlg = new SaveFileDialog();
            t_SaveXMLDlg.FileName = sDefaultName;
            t_SaveXMLDlg.Filter = sFilter;
            t_SaveXMLDlg.ShowDialog();
            if (!String.IsNullOrWhiteSpace(t_SaveXMLDlg.FileName))
            {
                sFile = t_SaveXMLDlg.FileName.Trim();
                return (true);
            }

            sFile = null;
            return (false);
        }

        /// <summary>
        /// 载入操作，加载xml文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDesignXML(m_sDesignXmlFile);//xml节点信息存入表格
                InitTree(designTreeView.Nodes, "0", m_DesignDataTable);  //表格绑定树控件
                designTreeView.ExpandAll();
                LoadTestXML(m_sTestXmlFile);
                //InitTree(testTreeView.Nodes,"0" ,m_TestDataTable); //表格绑定树控件
                InitTree(testTreeView.Nodes, "0", m_dataSet.Tables["testtable"]); //表格绑定树控件
                testTreeView.ExpandAll();
            } 
            catch { }
        }
       /// <summary>
       /// 载入设计需求xml
       /// </summary>
       /// <param name="sxmlFile"></param>
       private void LoadDesignXML(string sxmlFile)
        {
            
            designTreeView.Nodes.Clear();//清空节点
            m_DesignDataTable.Clear(); //清除表格所有的数据
            m_DesignDataTable.ReadXml(m_sDesignXmlFile); //把xml数据读入表格

        }

        /// <summary>
        /// 载入测试需求xml
        /// </summary>
        /// <param name="sxmlFile"></param>
        public void LoadTestXML(string sxmlFile)
        {                        
            testTreeView.Nodes.Clear();//清空节点          
           // m_TestDataTable.Clear();  //清除表格所有的数据
            m_dataSet.Clear();
            // m_TestDataTable.ReadXml(m_sTestXmlFile);
            m_dataSet.ReadXml(m_sTestXmlFile);
        }

        /// <summary>
        /// 选中节点，内容显示在相应控件上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            statusBar.Caption = ""; //清空状态栏
            DataRow tmpRow;
            DataRow tmpSubRow;
            uint id;
            DataRow[] rows;
            DataRow[] subRows;
            switch (flag)
            {
                case 0: break;
                case 1:
                    
                    tmpDesigndt.Rows.Clear();//控件清空
                    tmpRow = tmpDesigndt.NewRow();
                    richTextBox.Rtf = "";
                    if (designTreeView.SelectedNode.Tag != null)
                    {

                        id = Convert.ToUInt32(designTreeView.SelectedNode.Tag);

                        rows = m_DesignDataTable.Select("Id='" + id + "'");
                        tmpRow.ItemArray = rows[0].ItemArray;
                        tmpDesigndt.Rows.Add(tmpRow);
                        //foreach (DataRow row in rows)
                        //{
                        //    tmpRow["PId"] = row["PId"];
                        //    tmpRow["Id"] = row["Id"];
                        //    tmpRow["Name"] = row["Name"];
                        //    tmpRow["DesignContent"] = row["DesignContent"];
                        //    tmpDesigndt.Rows.Add(tmpRow);

                        //}
                        // richTextBox.Rtf = rows[0]["DesignContent"].ToString();
                        //写回去表格                
                        tmpTag = id;
                    }
                    break;
                case 2:
                    //数据清空
                    tmpTestdt.Rows.Clear();
                    tmpTestSubdt.Rows.Clear();
                    
                    if (testTreeView.SelectedNode.Tag != null)
                    {

                        id = Convert.ToUInt32(testTreeView.SelectedNode.Tag);

                        rows = m_TestDataTable.Select("Id='" + id + "'");
                        subRows = m_TestSubDataTable.Select("Id='" + id + "'");
                        //tmpRow.ItemArray = rows[0].ItemArray;
                        // tmpTestdt.Rows.Add(tmpRow);
                        foreach (DataRow row in rows)
                        {
                            tmpRow = tmpTestdt.NewRow();
                            tmpRow["PId"] = row["PId"];
                            tmpRow["Id"] = row["Id"];
                            tmpRow["Name"] = row["Name"];
                            tmpRow["TestIdentify"] = row["TestIdentify"];
                            tmpRow["TestPriority"] = row["TestPriority"];
                            tmpRow["TraceRelationships"] = row["TraceRelationships"];
                            tmpRow["TestContent"] = row["TestContent"];
                            tmpRow["TestReqResolve"] = row["TestReqResolve"];
                            tmpRow["AdequacyRequirements"] = row["AdequacyRequirements"];
                            tmpRow["TerminalCondition"] = row["TerminalCondition"];
                            tmpTestdt.Rows.Add(tmpRow);

                        }
                        foreach(DataRow row in subRows)
                        {
                            tmpSubRow = tmpTestSubdt.NewRow();
                            tmpSubRow["SubId"] = row["SubId"];
                            tmpSubRow["TestSubReq"] = row["TestSubReq"];
                            tmpSubRow["SubReqAnalyse"] = row["SubReqAnalyse"];
                            tmpSubRow["TestSubIdentify"] = row["TestSubIdentify"];
                            tmpTestSubdt.Rows.Add(tmpSubRow);
                        }

                    }

                    break;
            }
        }

        /// <summary>
        /// 多选编辑，加入到datagrid控件中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void multiSelectButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            uint id;
            DataRow[] rows;
            DataRow tmpRow;
            IList<TreeNode> nodeList = designTreeView.SelectedNodeList;
            tmpDesigndt.Rows.Clear();//清空
            foreach (TreeNode node in nodeList)
            {
                // Console.WriteLine(node.Tag);
                tmpRow= tmpDesigndt.NewRow();
                id = Convert.ToUInt32(node.Tag);
                rows = m_DesignDataTable.Select("Id='" + id + "'");
                tmpRow.ItemArray = rows[0].ItemArray;
                tmpDesigndt.Rows.Add(tmpRow);
               // tmpTag = id;//写回去表格  
            }
        }

        /// <summary>
        /// 获取当前的行号对应的id号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            int index = dataGridView.CurrentRow.Index; //行号
            try
            {
                tmpTag = Convert.ToUInt32(tmpDesigndt.Rows[index]["Id"].ToString());
            }
            catch { }
        }

        /// <summary>
        /// 获取改变的name字段值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            uint tmpId= Convert.ToUInt32(tmpDesigndt.Rows[e.RowIndex]["Id"].ToString());
            IList<TreeNode> nodeList = designTreeView.SelectedNodeList;
            try
            {
                //object tmpstr = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                //Console.WriteLine(tmpstr);
                DataRow[] rows = m_DesignDataTable.Select("Id='" + tmpId + "'");
                rows[0].BeginEdit();//写回去表格
                rows[0]["Name"] = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                rows[0].EndEdit();
                foreach(TreeNode node in nodeList)
                {
                    if(Convert.ToUInt32(node.Tag)== tmpId)
                    {
                        node.Text= dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    }
                }
            }
            catch { }

        }

        /// <summary>
        /// 由设计需求建立测试需求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testRequireButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tmpGridDialog = new EditGridDialog(); //编辑表格对话框
            DataRow dr;
            DataRow subdr;
            UInt16 count=0;
            StringBuilder tmpIdList = new StringBuilder();
            if (tmpGridDialog.ShowForm()== DialogResult.OK)
            {
                dr = m_TestDataTable.NewRow();
                switch(tmpGridDialog.testGrid.TestType)
                {
                    case "功能测试":dr["PId"] = 1;break;
                    case "性能测试":dr["PId"] = 2; break;
                    case "接口测试": dr["PId"] = 3; break;
                    case "边界测试": dr["PId"] = 4; break;
                    case "安全性测试": dr["PId"] = 5; break;
                    case "恢复性测试": dr["PId"] = 6; break;
                    case "强度测试": dr["PId"] = 7; break;
                    case "余量测试": dr["PId"] = 8; break;
                    default:break;
                }
                foreach(TreeNode node in designTreeView.SelectedNodeList)
                {
                    if(count==0)
                    {
                        tmpIdList.Append(node.Tag);
                    }
                    else
                    {
                        tmpIdList.Append(","+node.Tag);
                    }
                    count++;
                }
                dr["IdList"] = tmpIdList;
                dr["Name"] = tmpGridDialog.testGrid.Name;
                dr["TestIdentify"] = tmpGridDialog.testGrid.TestIdentify;
                dr["TestPriority"] = tmpGridDialog.testGrid.TestPriority;
                dr["TraceRelationships"] = tmpGridDialog.testGrid.TraceRelationships;
                dr["TestContent"] = tmpGridDialog.testGrid.TestContent;
                dr["TestReqResolve"] = "见下表";
                dr["AdequacyRequirements"] = tmpGridDialog.testGrid.AdequacyRequirements;
                dr["TerminalCondition"] = tmpGridDialog.testGrid.TerminalCondition;
                m_TestDataTable.Rows.Add(dr);
                Console.WriteLine(dr["Id"]);
                foreach (DataRow row in tmpGridDialog.testSubTable.Rows)
                {
                    subdr = m_TestSubDataTable.NewRow();
                    subdr["Id"] = dr["Id"];
                    subdr["SubId"] = row["SubId"];
                    subdr["TestSubReq"] = row["TestSubReq"];
                    subdr["SubReqAnalyse"] = row["SubReqAnalyse"];
                    subdr["TestSubIdentify"] = row["TestSubIdentify"];                  
                    m_TestSubDataTable.Rows.Add(subdr);
                }

                //dr.
                //m_TestDataTable tmpGridDialog.testGrid
            }

          
        }
    }
}
