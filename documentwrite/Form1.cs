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
    public partial class Form1 : Form
    {
        TreeView tmpTree;
        EditForm ftmp;//定义弹出的窗体类，主要是弹出文本框控件
        //定义xml文件路径在应用程序下面的相对路径
        string path = Application.StartupPath + "\\test.xml";
        string m_sDesignXmlFile = Environment.CurrentDirectory + "\\DesignTreeTest.xml";
        DataTable m_DesignDataTable;//存储设计树的信息
       
        //填充datagrid用
        DataTable newdt;

        public Form1()
        {
            InitializeComponent();
            tmpTree = zongTreeView;
            m_DesignDataTable = new DataTable("designtable");
            //表格初始化，添加列
            InitDesignDataSet(ref m_DesignDataTable);


        }

       

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)//也可以判断tabControl1.SelectedTab.Text的值
            {
                //执行相应的操作
                tmpTree = zongTreeView;
                Console.WriteLine(3);
                
            }
            else if (tabControl.SelectedIndex == 1)
            {
                //执行相应的操作
                tmpTree = designTreeView;
                
            }
            else if (tabControl.SelectedIndex == 2)
            {
                tmpTree = testTreeView;
            }
            else if (tabControl.SelectedIndex == 3)
            {
                tmpTree = ylTreeView;
            }
            else if (tabControl.SelectedIndex == 4)
            {
                tmpTree = reportTreeView;
            }
        }
        
        //添加根节点
        private void addRoot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //动态添加控件（控件放在窗体中）
            ftmp = new EditForm();
            TreeNode tmpNode = new TreeNode();
            DataRow dr = m_DesignDataTable.NewRow();
            //  ftmp.Flag = true;
            if (ftmp.ShowDialog() == DialogResult.OK)
            {
                //添加根节点到树节点集合中
                tmpNode.Text = ftmp.NodeName;                
                dr["PId"] = 0;
                dr["Name"] = ftmp.NodeName;
                dr["RichTextString"] = "";
                m_DesignDataTable.Rows.Add(dr);
                tmpNode.Tag = dr["Id"];//object类型
                tmpTree.Nodes.Add(tmpNode);
            }
        }

        //添加子节点，并自动对PID,ID编号
        private void addNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 动态添加控件（控件放在窗体中）
            ftmp = new EditForm();
            TreeNode tmpNode = new TreeNode();
            DataRow dr = m_DesignDataTable.NewRow();
            // ftmp.Flag = true;
            if (ftmp.ShowDialog() == DialogResult.OK)
            {
                //添加子节点到树节点集合中
                try
                {
                    tmpNode.Text = ftmp.NodeName;
                    //tmpTree.SelectedNode.Nodes.Add(tmpNode);
                    dr["PId"] = Convert.ToUInt32(tmpTree.SelectedNode.Tag);
                    dr["Name"] = ftmp.NodeName;
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
        }

        private void editNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ftmp = new EditForm();
            //ftmp.Flag = false;
            //树节点的富文本框添加现在选中节点的名字
            try
            {
                ftmp.RichTextBox.Text = tmpTree.SelectedNode.Text;
            
                if (ftmp.ShowDialog() == DialogResult.OK)
                {

                    tmpTree.SelectedNode.Text = ftmp.NodeName;


                }
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
                DataRow[] rows = m_DesignDataTable.Select("Id='" + tmpId + "'");
                rows[0].Delete();
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
        }
        private void TreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = tmpTree.GetNodeAt(ClickPoint);
                if (CurrentNode != null)//判断你点的是不是一个节点
                {
                    tmpTree.SelectedNode = CurrentNode;//选中这个节点
                    tmpTree.LabelEdit = true;
                    tmpTree.SelectedNode.BeginEdit();
                }
            }
        }

        //为数据表添加列，并定义主键
        private void InitDesignDataSet(ref DataTable table)
        {
            foreach(XmlSchema p in XmlSchema.m_aXmlParas)
            {
                table.Columns.Add(p.m_sName, p.m_Type);
            }
            //定义主键（并自增）
            table.PrimaryKey = new DataColumn[] { table.Columns["Id"] };
            table.Columns["Id"].AutoIncrement = true;
            newdt = new DataTable();
            newdt = table.Clone();
            dataGridView1.DataSource = newdt;
            //PID.ID不可编辑，隐藏最后一列
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[3].Visible = false;          

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
                tmpNd.Tag = row["id"].ToString();
                tmpNd.Text = row["name"].ToString();

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
                tmpNd.Tag = row["id"].ToString();
                tmpNd.Text = row["name"].ToString();
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

       
        //把树节点的信息存入表格中
        private void saveTreeNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            //存入表格信息 树节点信息变类的所有节点信息，节点信息存入表格，(最后表格写入xml)
            //DataRow dr = m_DesignDataTable.NewRow();
            //判断ID是否存在
            int tmpid= Convert.ToInt32(dataGridView1[1, 0].Value.ToString());
            DataRow[] rows = m_DesignDataTable.Select("Id='" + tmpid + "'");
            //判断ID是否存在,存在编辑原表格数据
            //if (rows.Length>0)
            //{
                rows[0].BeginEdit();
                rows[0]["Name"]= tmpTree.SelectedNode.Text;
               // rows[0]["PId"] = Convert.ToInt32(dataGridView1[0, 0].Value.ToString());
               // rows[0]["Id"] = Convert.ToInt32(dataGridView1[1, 0].Value.ToString());
                rows[0]["RichTextString"] = richTextBox1.Rtf;
                rows[0].EndEdit();
                MessageBox.Show("保存节点信息成功");
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
      
        //保存整个树节点的信息，写入xml文件中
        private void saveButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string fileName = "";
            //保存之前对上一次结果做备份
            if (SaveFile(out fileName, "DesignTreeTest.xml", "xml file|*.xml|all file|*.*"))
            {
                File.Copy("DesignTreeTest.xml", "DesignTreeTest.xml.bak", true);
                m_DesignDataTable.WriteXml(m_sDesignXmlFile, XmlWriteMode.IgnoreSchema);
            }
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
                        //判断段落标题名称
                        if (paragraph.StyleName == "1")
                        {

                            tmpRow = m_DesignDataTable.NewRow();
                            i++;
                            tmpRow["PId"] = Convert.ToUInt32(paragraph.StyleName)-1;
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
                            uint tmpPId = GetParentId(0);
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
                            tmpRow["PId"] = GetParentId(tmpPId);
                            tmpRow["Id"] = Convert.ToUInt32(i);
                            tmpRow["Name"] = paragraph.Text;
                            tmpRow["RichTextString"] = "";
                            m_DesignDataTable.Rows.Add(tmpRow);
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("关闭当前打开的word文档");
                return false;
            }
        }


        public uint GetParentId(uint id)
        {
            DataRow[] drArr = m_DesignDataTable.Select("PId='" + id + "'");
            uint tmpPId = Convert.ToUInt32(drArr[drArr.Length - 1]["Id"]);
            return tmpPId;
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
        private void designTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            newdt.Rows.Clear();
            richTextBox1.Rtf = "";
            if (designTreeView.SelectedNode.Tag != null)
            {

                int id = Convert.ToInt32(designTreeView.SelectedNode.Tag);

                DataRow[] rows = m_DesignDataTable.Select("Id='" + id + "'");
                foreach (DataRow row in rows)
                {
                    newdt.Rows.Add(row.ItemArray);
                }
                richTextBox1.Rtf = newdt.Rows[0]["RichTextString"].ToString();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //xml节点信息存入表格
            LoadDesignXML(m_sDesignXmlFile);
            BinTreeView(ref designTreeView, m_DesignDataTable);              //表格绑定树控件  
           
        }

        



    }
}
