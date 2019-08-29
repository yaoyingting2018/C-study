using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.IO;

namespace documentwrite
{
    public partial class TreeForm : Form
    {
        TreeView tmpTree;        
        EditDialog tmpDialog;//定义弹出的窗体类，主要是弹出文本框控件
        //定义xml文件路径在应用程序下面的相对路径
        string path = Application.StartupPath + "\\test.xml";

        string m_sDesignXmlFile = Environment.CurrentDirectory + "\\DesignTreeTest.xml";
        string m_sTestXmlFile = Environment.CurrentDirectory + "\\TestTreeTest.xml";
        string m_sYlXmlFile = Environment.CurrentDirectory + "\\YlTreeTest.xml";
        string m_sReportXmlFile = Environment.CurrentDirectory + "\\ReportTreeTest.xml";
        string m_sZongXmlFile = Environment.CurrentDirectory + "\\ZongTreeTest.xml";

        DataTable m_ZongDataTable;//存储总树的信息

        DataTable m_DesignDataTable;//存储设计树的信息
        //动态加载的DataGridView、RichTextBox控件
        DataGridView dataGridView;
        RichTextBox richTextBox;
        //填充设计树的datagrid用
        DataTable newdt;
       // UserTools tools = new UserTools();
        DesignControls designControls;

        //记录上一次节点的Tag值
        uint tmpTag = 0;

        DataTable m_TestDataTable;//存储测试树的信息
        DataTable m_YLDataTable;//存储用例树的信息
        DataTable m_ReportDataTable;//存储报告树的信息
        DataSet m_dataSet;



        //flag标志位，选中不同的树控件，对应不同的添加节点方法
        UInt16 flag = 0;
        //添加节点计数
        UInt16 count = 0;


        public TreeForm()
        {
            InitializeComponent();
            //添加双击编辑事件
            TreeNodeDoubleClick(); 
           
            tmpTree = zongTreeView;
            m_dataSet = new DataSet();
            m_ZongDataTable= new DataTable("zongtable");
            m_DesignDataTable = new DataTable("designtable");
            m_TestDataTable = new DataTable("testtable");
            m_YLDataTable = new DataTable("yltable");
            m_ReportDataTable = new DataTable("reporttable");

            //m_dataSet.Tables.Add(m_DesignDataTable);
            //m_dataSet.Tables.Add(m_TestDataTable);
            //m_dataSet.Tables.Add(m_YLDataTable);
            //m_dataSet.Tables.Add(m_ReportDataTable);
            //m_dataSet.Tables.Add(m_ZongDataTable);

            //表格初始化，添加列
            InitDataSet(ref m_dataSet);


        }



        private void TreeNodeDoubleClick()
        {
            zongTreeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            designTreeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            //designTreeView.MouseDoubleClick += TreeView_MouseDoubleClick;
            testTreeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            ylTreeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            reportTreeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
        }
        private void TreeNodeAfterEdit()
        {
            designTreeView.AfterLabelEdit += treeView_AfterLabelEdit;
        }
       



        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)//也可以判断tabControl1.SelectedTab.Text的值
            {
                //执行相应的操作
                flag = 0;
                tmpTree = zongTreeView;
                this.Controls.Remove(splitContainer1);
                //designControls.Dispose();释放了不能重新加载控件，关闭之后用
                // splitContainer1.Panel1.Controls.Remove(dataGridView);
                //splitContainer1.Panel2.Controls.Remove(richTextBox);
                // Console.WriteLine(3);

            }
            else if (tabControl.SelectedIndex == 1)
            {
                //执行相应的操作
                flag = 1;
                tmpTree = designTreeView;
              
                CreatesplitContainer();
                designControls = new DesignControls(splitContainer1);
                dataGridView = designControls.dataGridView1;

                richTextBox = designControls.richTextBox1;
                
                newdt = new DataTable();
                DataColumn[] cols = {new DataColumn("PId", typeof(uint)),
                                     new DataColumn("Id", typeof(uint)),
                                      new DataColumn("Name", typeof(string))};
                newdt.Columns.AddRange(cols);
                //newdt.Columns.Add("PId", typeof(uint));
                //newdt.Columns.Add("Id", typeof(uint));
                //newdt.Columns.Add("Name", typeof(string));
                dataGridView.DataSource = newdt;
                //调整列宽填充控件
                dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dataGridView.DataMember设计列表的名称
                //包含行标题的列
                dataGridView.RowHeadersVisible = true;
                //PID.ID不可编辑，隐藏最后一列
                dataGridView.Columns[0].ReadOnly = true;
                dataGridView.Columns[1].ReadOnly = true;
                

            }
            else if (tabControl.SelectedIndex == 2)
            {
                flag = 2;
                tmpTree = testTreeView;
                this.Controls.Remove(splitContainer1);
            }
            else if (tabControl.SelectedIndex == 3)
            {
                flag = 3;
                tmpTree = ylTreeView;
                this.Controls.Remove(splitContainer1);
            }
            else if (tabControl.SelectedIndex == 4)
            {
                flag = 4;
                tmpTree = reportTreeView;
                this.Controls.Remove(splitContainer1);
            }
        }


       

        //添加根节点
        private void addRoot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //动态添加控件（控件放在窗体中）           
            tmpDialog = new EditDialog();
            TreeNode tmpNode = new TreeNode();
            switch(flag)
            {
                case 0: break;
                case 1 :
                    //DataRow dr = m_DesignDataTable.NewRow();

                    ////  ftmp.Flag = true;
                    //if (tmpDialog.Show() == DialogResult.OK)
                    //{
                    //    //添加根节点到树节点集合中
                    //    tmpNode.Text = tmpDialog.NodeName;
                    //    dr["PId"] = 0;
                    //    dr["Name"] = tmpDialog.NodeName;
                    //    dr["RichTextString"] = "";
                    //    m_DesignDataTable.Rows.Add(dr);
                    //    tmpNode.Tag = dr["Id"];//object类型
                    //    tmpTree.Nodes.Add(tmpNode);
                    //}
                    DataRow dr = m_DesignDataTable.NewRow();
                    DataRow[] rows = m_DesignDataTable.Select("Id='1'");
                    int a = rows.Count<DataRow>();
                    if (a==0)
                    {
                        if (tmpDialog.Show() == DialogResult.OK)
                        {

                            //添加根节点到树节点集合中
                            tmpNode.Text = tmpDialog.NodeName;
                            dr["PId"] = 0;
                            dr["Id"] = 1;
                           
                            dr["Name"] = tmpDialog.NodeName;
                            dr["RichTextString"] = "";
                            m_DesignDataTable.Rows.Add(dr);
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
                            
                            dr["Name"] = tmpDialog.NodeName;
                            dr["RichTextString"] = "";
                            m_DesignDataTable.Rows.Add(dr);
                            tmpNode.Tag = dr["Id"];//object类型
                            tmpTree.Nodes.Add(tmpNode);
                        }
                    }
                    break;
                case 2:
                   // count++;

                    DataRow dr1 = m_TestDataTable.NewRow();
                    DataRow[] rows1 = m_TestDataTable.Select("Id='1'");
                    int b = rows1.Count<DataRow>();

                    if (b==0)
                    {
                        if (tmpDialog.Show() == DialogResult.OK)
                        {
                            
                            //添加根节点到树节点集合中
                            tmpNode.Text = tmpDialog.NodeName;
                            dr1["PId"] = 0;
                            dr1["Id"] = 1;
                            dr1["PIdText"] = "";
                            dr1["Name"] = tmpDialog.NodeName;
                            dr1["IdList"] = "";
                            dr1["TestItendify"] = "";
                            dr1["TestPriority"] = "";
                            dr1["TraceRelationships"] = "";
                            dr1["TestContent"] = "";
                            dr1["TestReqResolve"] = "";
                            dr1["AdequacyRequirements"] = "";
                            dr1["TerminalCondition"] = "";
                            m_TestDataTable.Rows.Add(dr1);
                            tmpNode.Tag = dr1["Id"];//object类型
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
                            dr1["PId"] = 0;
                            dr1["Name"] = tmpDialog.NodeName;
                            dr1["PIdText"] ="";
                            dr1["IdList"] = "";
                            dr1["TestItendify"] = "";
                            dr1["TestPriority"] = "";
                            dr1["TraceRelationships"] = "";
                            dr1["TestContent"] = "";
                            dr1["TestReqResolve"] = "";
                            dr1["AdequacyRequirements"] = "";
                            dr1["TerminalCondition"] = "";
                            m_TestDataTable.Rows.Add(dr1);
                            tmpNode.Tag = dr1["Id"];//object类型
                            tmpTree.Nodes.Add(tmpNode);
                        }
                    }
                  
                    break;
                case 3:; break;
                case 4:; break;
                default:break;
            }
            
        }

        //添加子节点，并自动对PID,ID编号
        private void addNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 动态添加控件（控件放在窗体中）
            // ftmp = new EditForm();
            tmpDialog = new EditDialog();
            TreeNode tmpNode = new TreeNode();
            switch (flag)
            {
                case 0:break;
                case 1:
                    DataRow dr = m_DesignDataTable.NewRow();
                    // ftmp.Flag = true;
                    if (tmpDialog.Show() == DialogResult.OK)
                    {
                        //添加子节点到树节点集合中,根据树不同，添加的表格不同
                        try
                        {
                            tmpNode.Text = tmpDialog.NodeName;
                            //tmpTree.SelectedNode.Nodes.Add(tmpNode);
                            dr["PId"] = Convert.ToUInt32(tmpTree.SelectedNode.Tag);
                            dr["Name"] = tmpDialog.NodeName;
                            dr["RichTextString"] = "";
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
                    DataRow dr1 = m_TestDataTable.NewRow();
                    // ftmp.Flag = true;
                    if (tmpDialog.Show() == DialogResult.OK)
                    {
                        //添加子节点到树节点集合中,根据树不同，添加的表格不同
                        try
                        {
                            tmpNode.Text = tmpDialog.NodeName;
                            //tmpTree.SelectedNode.Nodes.Add(tmpNode);
                            dr1["PId"] = Convert.ToUInt32(tmpTree.SelectedNode.Tag);
                            dr1["Name"] = tmpDialog.NodeName;
                            dr1["PIdText"] = tmpTree.SelectedNode.Text;
                            dr1["IdList"] = "";
                            dr1["TestItendify"] = "";
                            dr1["TestPriority"] = "";
                            dr1["TraceRelationships"] = "";
                            dr1["TestContent"] = "";
                            dr1["TestReqResolve"] = "";
                            dr1["AdequacyRequirements"] = "";
                            dr1["TerminalCondition"] = "";
                            m_TestDataTable.Rows.Add(dr1);
                            tmpNode.Tag = dr1["Id"];//object类型
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

                   
           
            }
        }

        private void editNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // ftmp = new EditForm();
            int id = Convert.ToInt32(tmpTree.SelectedNode.Tag);
            tmpDialog = new EditDialog();
            //ftmp.Flag = false;
            //树节点的富文本框添加现在选中节点的名字
            try
            {
                tmpDialog.RichTextBox.Text = tmpTree.SelectedNode.Text;

                if (tmpDialog.Show() == DialogResult.OK)
                {

                    tmpTree.SelectedNode.Text = tmpDialog.NodeName;
                }

                switch (flag)
                {
                    case 0:break;
                    case 1:
                        DataRow[] rows = m_DesignDataTable.Select("Id='" + id + "'");
                        rows[0].BeginEdit();
                        rows[0]["Name"] = tmpTree.SelectedNode.Text;
                        rows[0]["RichTextString"] = richTextBox.Rtf;
                        rows[0].EndEdit();
                        break;
                    case 2:
                        DataRow[] rows1 = m_TestDataTable.Select("Id='" + id + "'");
                        rows1[0].BeginEdit();
                        rows1[0]["Name"] = tmpTree.SelectedNode.Text;
                        
                        rows1[0].EndEdit();
                        break;

                }
                //tmpDialog.RichTextBox.Text = tmpTree.SelectedNode.Text;
            
                //if (tmpDialog.Show() == DialogResult.OK)
                //{

                //    tmpTree.SelectedNode.Text = tmpDialog.NodeName;
                //}
            }
            catch
            {
                MessageBox.Show("请选择节点");
            }
        }

        private void deleteNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                uint tmpId = Convert.ToUInt32(tmpTree.SelectedNode.Tag.ToString());
                switch(flag)
                {
                    case 0:break;
                    case 1:
                        DataRow[] rows = m_DesignDataTable.Select("Id='" + tmpId + "'");
                        rows[0].Delete();
                        break;
                    case 2:
                        DataRow[] rows1 = m_TestDataTable.Select("Id='" + tmpId + "'");
                        rows1[0].Delete();
                        break;
                    
                }
                //DataRow[] rows = m_DesignDataTable.Select("Id='" + tmpId + "'");
                //rows[0].Delete();
                tmpTree.SelectedNode.Remove();
            }
            catch
            {
                MessageBox.Show("请选择节点");
            }
                
        }

        private void deleteAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //清空节点
            tmpTree.Nodes.Clear();
            switch(flag)
            {
                case 0:break;
                case 1:
                    m_DesignDataTable.Rows.Clear();
                    break;
                case 2:
                    m_TestDataTable.Rows.Clear();
                    break;
                default:break;
       
            }
        }
        //private void TreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        Point ClickPoint = new Point(e.X, e.Y);
        //        TreeNode CurrentNode = tmpTree.GetNodeAt(ClickPoint);
        //        if (CurrentNode != null)//判断你点的是不是一个节点
        //        {

        //            tmpTree.SelectedNode = CurrentNode;//选中这个节点
        //           // UInt32 id = Convert.ToUInt32(tmpTree.SelectedNode.Tag);
        //            tmpTree.LabelEdit = true;
        //            tmpTree.SelectedNode.BeginEdit();
        //            tmpTree.SelectedNode.EndEdit(true);                 

        //        }
        //    }
        //}



        ////为数据表添加列，并定义主键
        //private void InitDesignDataSet(ref DataTable table)
        //{

        //    foreach (DeisgnXmlSchema p in DeisgnXmlSchema.m_aXmlParas)
        //    {
        //        table.Columns.Add(p.m_sName, p.m_Type);
        //    }
        //    //定义主键（并自增）
        //    table.PrimaryKey = new DataColumn[] { table.Columns["Id"] };
        //    table.Columns["Id"].AutoIncrement = true;
        //    // newdt = table.Clone();
        //    //dataGridView1.DataSource = newdt;
        //    ////PID.ID不可编辑，隐藏最后一列
        //    //dataGridView1.Columns[0].ReadOnly = true;
        //    //dataGridView1.Columns[1].ReadOnly = true;
        //    //dataGridView1.Columns[3].Visible = false;          

        //}

        private void InitDataSet(ref DataSet dataSet)
        {
            foreach (DeisgnXmlSchema p in DeisgnXmlSchema.m_aXmlParas)
            {
                m_DesignDataTable.Columns.Add(p.m_sName, p.m_Type);

            }
            m_DesignDataTable.PrimaryKey= new DataColumn[] { m_DesignDataTable.Columns["Id"] };
            m_DesignDataTable.Columns["Id"].AutoIncrement = true;

            foreach (TestXmlSchema p in TestXmlSchema.m_aXmlParas)
            {
                m_TestDataTable.Columns.Add(p.m_sName, p.m_Type);
            }
            m_TestDataTable.PrimaryKey = new DataColumn[] { m_TestDataTable.Columns["Id"] };
            m_TestDataTable.Columns["Id"].AutoIncrement = true;

            dataSet.Tables.Add(m_DesignDataTable);
            dataSet.Tables.Add(m_TestDataTable);


        }

        //设计表绑定树控件
        private void BinTreeView(ref TreeView treeView, DataTable dataTable)
        {
            //得到测试用的 DataTable  
            //InitTestDataSet(ref m_DesTreeDataTable);

            //定义临时树节点  
            TreeNode tmpNd;
            //从DataTable中得到所有父节点为0的DataRow形成的根节点数组  
            DataRow[] rows = dataTable.Select("PId='0'");
            //遍历根节点数组  
            foreach (DataRow row in rows)
            {
                tmpNd = new TreeNode();
                //给根节点赋值 
                tmpNd.Tag = row["Id"].ToString();
                tmpNd.Text = row["Name"].ToString();

                //将节点加入到树中  
                treeView.Nodes.Add(tmpNd);
                //递归加入此根节点的子节点  
                InitTreeView(tmpNd.Nodes, uint.Parse(tmpNd.Tag.ToString()), dataTable);
            }
            treeView.ExpandAll();
        }

        private void InitTreeView(TreeNodeCollection treeNodeCollection, uint p, DataTable dt)
        {
            TreeNode tmpNd;
            //取得以此节点为父节点的数据行  
            DataRow[] rows = dt.Select("PId='" + p + "'");
            foreach (DataRow row in rows)
            {
                tmpNd = new TreeNode();
                //给根节点赋值  
                tmpNd.Tag = row["Id"].ToString();
                tmpNd.Text = row["Name"].ToString();
                //将节点加入到树中  
                treeNodeCollection.Add(tmpNd);
                //递归加入此节点的子节点  
                InitTreeView(tmpNd.Nodes, uint.Parse(tmpNd.Tag.ToString()), dt);
            }
        }
  
     
        //读xml文件，信息读入绑定树控件的表中
        public void LoadDesignXML(string sxmlFile)
        {
            if(DesignTree.LoadXMLFile(sxmlFile))
            {
                //清空节点
                designTreeView.Nodes.Clear();
                //清除表格所有的数据
                m_DesignDataTable.Clear();
                foreach(DesignTree node in DesignTree.m_AllDesignNode)
                {
                    AddNodeToDataSet(node, ref m_DesignDataTable);
                }
            }
        }

        //读xml文件，信息读入绑定树控件的表中
        public void LoadTestXML(string sxmlFile)
        {
            if (TestTree.LoadTestXMLFile(sxmlFile))
            {
                //清空节点
                testTreeView.Nodes.Clear();
                //清除表格所有的数据
                m_TestDataTable.Clear();
                foreach (TestTree node in TestTree.m_AllTestNode)
                {
                    AddNodeToTestData(node, ref m_TestDataTable);
                }
            }
        }


        //把对象信息加入表中
        public void AddNodeToDataSet(DesignTree node,ref DataTable table)
        {
            object[] t_Object = new object[table.Columns.Count];

            foreach (DataColumn col in table.Columns)
            {
                t_Object[col.Ordinal] = node.GetValue(col.ColumnName);
            }

            table.Rows.Add(t_Object);
        }

        //把对象信息加入表中
        public void AddNodeToTestData(TestTree node, ref DataTable table)
        {
            object[] t_Object = new object[table.Columns.Count];

            foreach (DataColumn col in table.Columns)
            {
                t_Object[col.Ordinal] = node.GetValue(col.ColumnName);
            }

            table.Rows.Add(t_Object);
        }


        //把树节点的信息存入表格中
        private void saveTreeNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //存入表格信息 树节点信息变类的所有节点信息，节点信息存入表格，(最后表格写入xml)
            //DataRow dr = m_DesignDataTable.NewRow();
            //判断ID是否存在
            switch(flag)
            {
                case 0:break;
                case 1:
                    int tmpid = Convert.ToInt32(dataGridView[1, 0].Value.ToString());
                    DataRow[] rows = m_DesignDataTable.Select("Id='" + tmpid + "'");
                    rows[0].BeginEdit();
                    rows[0]["Name"] = tmpTree.SelectedNode.Text;
                    rows[0]["RichTextString"] = richTextBox.Rtf;
                    rows[0].EndEdit();
                    Status_bsti.Caption = "保存节点信息成功";
                    break;

            }
            //int tmpid= Convert.ToInt32(dataGridView[1, 0].Value.ToString());
            //DataRow[] rows = m_DesignDataTable.Select("Id='" + tmpid + "'");
            ////判断ID是否存在,存在编辑原表格数据
            ////if (rows.Length>0)
            ////{
            //    rows[0].BeginEdit();
            //    rows[0]["Name"]= tmpTree.SelectedNode.Text;
            //   // rows[0]["PId"] = Convert.ToInt32(dataGridView1[0, 0].Value.ToString());
            //   // rows[0]["Id"] = Convert.ToInt32(dataGridView1[1, 0].Value.ToString());
            //    rows[0]["RichTextString"] = richTextBox.Rtf;
            //    rows[0].EndEdit();
            //    Status_bsti.Caption = "保存节点信息成功";
                //MessageBox.Show("保存节点信息成功");
            // }
            //else
            //{
            //    dr["Name"] = tmpTree.SelectedNode.Text;
            //    dr["PId"] = Convert.ToInt32(dataGridView1[0, 0].Value.ToString());
            //    dr["Id"] = Convert.ToInt32(dataGridView1[1, 0].Value.ToString());
            //    dr["RichTextString"] = richTextBox1.Rtf;

            //    m_DesignDataTable.Rows.Add(dr);
            //}
        }
      
       

        //保存文件操作
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

        //打开word文档导入到树控件
        private void openButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //清除树上的节点
            designTreeView.Nodes.Clear();
            //表格数据清除
            m_DesignDataTable.Rows.Clear();
            string fileName = "";
            if (OpenFile(out fileName, "word文件|*.docx|word文件|*.doc", "Load word file"))
            {
                if (LoadWordFile(fileName))
                {
                    BinTreeView(ref designTreeView, m_DesignDataTable); //表格绑定树控件
                }
            }
        }

        //只对四级标题处理
        public Boolean LoadWordFile(string sWordFilePath)
        {
            Document doc = new Document();
            try
            {
                doc.LoadFromFile(sWordFilePath);
                //遍历文档中的section
                uint i = 0;
                DataRow tmpRow;
                foreach (Section section in doc.Sections)
                {
                    foreach (Paragraph paragraph in section.Paragraphs)
                    {
                        try
                        {
                            //判断段落标题名称
                            if (paragraph.StyleName == "1")
                            {

                                tmpRow = m_DesignDataTable.NewRow();
                                i++;
                                tmpRow["PId"] = Convert.ToUInt32(paragraph.StyleName) - 1;
                                tmpRow["Id"] = Convert.ToUInt32(i);
                                tmpRow["Name"] = paragraph.Text;
                                tmpRow["RichTextString"] = "";
                                m_DesignDataTable.Rows.Add(tmpRow);
                            }
                            if (paragraph.StyleName == "2")
                            {
                                tmpRow = m_DesignDataTable.NewRow();
                                i++;
                                //找到最近的PID=1的最大Id数据行

                                //DataRow[] drArr = m_zongTreeDataTable.Select("PId='1'");
                                // tmpRow["PId"] = drArr[drArr.Length - 1]["Id"];
                                //if(GetParentId(0)==100000)
                                //{
                                //    MessageBox.Show("一级标题的样式不对！");
                                //    return false;
                                //}
                                tmpRow["PId"] = GetParentId(0);
                                tmpRow["Id"] = Convert.ToUInt32(i);
                                tmpRow["Name"] = paragraph.Text;
                                tmpRow["RichTextString"] = "";
                                m_DesignDataTable.Rows.Add(tmpRow);
                            }
                            if (paragraph.StyleName == "3")
                            {
                                tmpRow = m_DesignDataTable.NewRow();
                                i++;
                                //找到最近的PID=1的最大Id数据行,得到二级标题的PId,再搜索最大Id数据行
                                //if (GetParentId(0) == 100000)
                                //{
                                //    return false;
                                //}
                                uint tmpPId = GetParentId(0);
                                //if (GetParentId(tmpPId) == 100000)
                                //{
                                //    MessageBox.Show("二级标题的样式不对！");
                                //    return false;
                                //}
                                tmpRow["PId"] = GetParentId(tmpPId);

                                tmpRow["Id"] = Convert.ToUInt32(i);
                                tmpRow["Name"] = paragraph.Text;
                                tmpRow["RichTextString"] = "";
                                m_DesignDataTable.Rows.Add(tmpRow);
                            }
                            if (paragraph.StyleName == "4")
                            {
                                tmpRow = m_DesignDataTable.NewRow();
                                i++;
                                uint tmpPId = GetParentId(0);
                                tmpPId = GetParentId(tmpPId);
                                //if (GetParentId(tmpPId) == 100000)
                                //{
                                //    MessageBox.Show("三级标题的样式不对！");
                                //    return false;
                                //}
                                tmpRow["PId"] = GetParentId(tmpPId);
                                tmpRow["Id"] = Convert.ToUInt32(i);
                                tmpRow["Name"] = paragraph.Text;
                                tmpRow["RichTextString"] = "";
                                m_DesignDataTable.Rows.Add(tmpRow);
                            }
                            if (paragraph.StyleName == "5")
                            {
                                tmpRow = m_DesignDataTable.NewRow();
                                i++;
                                uint tmpPId = GetParentId(0);
                                tmpPId = GetParentId(tmpPId);
                                tmpPId = GetParentId(tmpPId);
                                //if (GetParentId(tmpPId) == 100000)
                                //{
                                //    MessageBox.Show("四级标题的样式不对！");
                                //    return false;
                                //}
                                tmpRow["PId"] = GetParentId(tmpPId);
                                tmpRow["Id"] = Convert.ToUInt32(i);
                                tmpRow["Name"] = paragraph.Text;
                                tmpRow["RichTextString"] = "";
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
                MessageBox.Show("关闭当前打开的word文档"+ex.ToString());
                return false;
            }
        }


        public uint GetParentId(uint id)
        {
            //标准的标题样式，不是标准的识别不出来
            DataRow[] drArr = m_DesignDataTable.Select("PId='" + id + "'");
            //try {
                uint tmpPId = Convert.ToUInt32(drArr[drArr.Length - 1]["Id"]);
                return tmpPId;
           // }
            //catch
            //{
            //    //MessageBox.Show("标题样式不对!");
            //    return 100000;
            //}
            
        }

        //打开文件操作
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
        //单选显示节点信息
        private void designTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            newdt.Rows.Clear();
            DataRow tmpRow = newdt.NewRow();
            richTextBox.Rtf = "";
            if (designTreeView.SelectedNode.Tag != null)
            {

                int id = Convert.ToInt32(designTreeView.SelectedNode.Tag);

                DataRow[] rows = m_DesignDataTable.Select("Id='" + id + "'");
                foreach (DataRow row in rows)
                {
                    tmpRow["PId"] = row["PId"];
                    tmpRow["Id"]= row["Id"];
                    tmpRow["Name"] = row["Name"];
                    newdt.Rows.Add(tmpRow);

                }
                richTextBox.Rtf = rows[0]["RichTextString"].ToString();
                //写回去表格               
            }
            
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                LoadDesignXML(m_sDesignXmlFile);
                BinTreeView(ref designTreeView, m_DesignDataTable);              //表格绑定树控件
                LoadTestXML(m_sTestXmlFile);
                BinTreeView(ref testTreeView, m_TestDataTable);              //表格绑定树控件
            } //xml节点信息存入表格
            catch { }
           

        }

        //保存整个树节点的信息，写入xml文件中
        private void saveButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            switch(flag)
            {
                case 0:break;
                case 1:
                    int tmpid= Convert.ToInt32(dataGridView[1, 0].Value.ToString());
                  
                    DataRow[] rows = m_DesignDataTable.Select("Id='" + tmpid + "'");
                    //写回去表格
                    rows[0].BeginEdit();
                    rows[0]["Name"] = tmpTree.SelectedNode.Text;
                    rows[0]["RichTextString"] = richTextBox.Rtf;
                    rows[0].EndEdit();
                    break;
            }

            try
            {
                File.Copy("DesignTreeTest.xml", "DesignTreeTest.xml.bak", true);

                File.Copy("TestTreeTest.xml", "TestTreeTest.xml.bak", true);
            }
            catch { }
            m_DesignDataTable.WriteXml(m_sDesignXmlFile, XmlWriteMode.IgnoreSchema);
            m_TestDataTable.WriteXml(m_sTestXmlFile, XmlWriteMode.IgnoreSchema);

            //switch(flag)
            //{
            //    case 0:break;
            //    case 1:
            //        File.Copy("DesignTreeTest.xml", "DesignTreeTest.xml.bak", true);
            //        m_DesignDataTable.WriteXml(m_sDesignXmlFile, XmlWriteMode.IgnoreSchema);
            //        break;
            //    case 2:
            //        try { File.Copy("TestTreeTest.xml", "TestTreeTest.xml.bak", true); }
            //        catch { }
            //        //File.Copy("TestTreeTest.xml", "TestTreeTest.xml.bak", true);
            //        m_TestDataTable.WriteXml(m_sTestXmlFile, XmlWriteMode.IgnoreSchema);
            //        break;
            //    case 3: break;
            //    case 4: break;
            //    default:break;


            //}

            //File.Copy("DesignTreeTest.xml", "DesignTreeTest.xml.bak", true);
            //m_DesignDataTable.WriteXml(m_sDesignXmlFile, XmlWriteMode.IgnoreSchema);
            Status_bsti.Caption = "保存XML成功";

        }

        private void saveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string fileName = "";
            switch(flag)
            {
                case 0:break;
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
                default:break;
            }
            Status_bsti.Caption = "保存XML成功";

            ////保存之前对上一次结果做备份//多个表格，载入的话可以用表格集
            //if (SaveFile(out fileName, "DesignTreeTest.xml", "xml file|*.xml|all file|*.*"))
            //{
            //    File.Copy("DesignTreeTest.xml", "DesignTreeTest.xml.bak", true);
            //    m_DesignDataTable.WriteXml(fileName, XmlWriteMode.IgnoreSchema);
            //}
        }

        private void testRequire_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //private void designTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        //{
        //   // string nodeText=e.Label;
        //    int id = Convert.ToInt32(e.Node.Tag);

        //    DataRow[] rows = m_DesignDataTable.Select("Id='" + id + "'");
            
        //    //写回去表格
        //    rows[0].BeginEdit();
        //    rows[0]["Name"] = e.Label;
        //    //rows[0]["RichTextString"] = richTextBox.Rtf;
        //    rows[0].EndEdit();
        //    //界面上视图的改变
        //    dataGridView[2, 0].Value = e.Label;
        //    m_DesignDataTable.AcceptChanges();

        //    //dataGridView.Accept
        //    //dataGridView[2, 0].Value = nodeText;
        //    //Console.WriteLine(a);

        //}
        private void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            int id = Convert.ToInt32(e.Node.Tag);
            if(e.Label!=null)
            {
                switch (flag)
                {
                    case 0: break;
                    case 1:
                        DataRow[] rows = m_DesignDataTable.Select("Id='" + id + "'");
                        //写回去表格
                        rows[0].BeginEdit();
                        rows[0]["Name"] = e.Label;
                        //rows[0]["Name"] = e.Node.Text;
                        //rows[0]["RichTextString"] = richTextBox.Rtf;
                        rows[0].EndEdit();
                        //界面上视图的改变
                        dataGridView[2, 0].Value = e.Label;
                        m_DesignDataTable.AcceptChanges();
                        break;
                    case 2:
                        DataRow[] rows1 = m_TestDataTable.Select("Id='" + id + "'");
                        //写回去表格
                        rows1[0].BeginEdit();
                        rows1[0]["Name"] = e.Label;
                        //rows[0]["RichTextString"] = richTextBox.Rtf;
                        rows1[0].EndEdit();
                        //界面上视图的改变

                        m_TestDataTable.AcceptChanges();
                        break;
                    default:
                        break;

                }
            }

          
        }

        //private void designTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
           
        //    designTreeView.LabelEdit = true;
        //    designTreeView.SelectedNode.BeginEdit();
        //   // dataGridView[2, 0].Value = designTreeView.SelectedNode.Text;
        //   // Console.WriteLine(e.Node);
        //   //e.Node.BeginEdit();

        //}

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tmpTree.LabelEdit = true;
            tmpTree.SelectedNode.BeginEdit();
        }


    }
}
