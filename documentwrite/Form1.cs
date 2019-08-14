﻿using System;
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
        string m_sDesignTreeFile = Environment.CurrentDirectory + "\\DesignTreeTest.xml";
        DataTable m_DesTreeDataTable;//存储设计树的信息
       
        //填充datagrid用
        DataTable newdt;

        public Form1()
        {
            InitializeComponent();
            tmpTree = zongTreeView;
            m_DesTreeDataTable = new DataTable("designtable");
           
            //表格初始化
            //InitDTreeDataSet(ref m_DesTreeDataTable);
           
           



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

        private void addRoot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //动态添加控件（控件放在窗体中）
            ftmp = new EditForm();
            //  ftmp.Flag = true;
            if (ftmp.ShowDialog() == DialogResult.OK)
            {
                //添加根节点到树节点集合中
                tmpTree.Nodes.Add(ftmp.NodeName);
            }
        }

        private void addNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 动态添加控件（控件放在窗体中）
            ftmp = new EditForm();
            TreeNode tmpNode = new TreeNode();
            DataRow dr = m_DesTreeDataTable.NewRow();
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
                    m_DesTreeDataTable.Rows.Add(dr);
                    tmpNode.Tag = dr["Id"];
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
        private void InitDTreeDataSet(ref DataTable table)
        {
            foreach(XmlSchema p in XmlSchema.m_aXmlParas)
            {
                table.Columns.Add(p.m_sName, p.m_Type);
            }
            //定义主键（并自增）m_DesTreeDataTable.Columns["Id"].AutoIncrement = true;

            table.PrimaryKey = new DataColumn[] { table.Columns["Id"] };
            m_DesTreeDataTable.Columns["Id"].AutoIncrement = true;
            newdt = new DataTable();
            newdt = table.Clone();
            dataGridView1.DataSource = newdt;
            //隐藏最后一列
            dataGridView1.Columns[3].Visible = false;
            //加入一个根节点
            DataRow root = table.NewRow();
            root["PId"] = 0;
            root["Id"] = 1;
            root["Name"] = "设计需求树";
            root["RichTextString"] = "";
            table.Rows.Add(root);

        }

        //设计表绑定树控件。树控件信息包括节点tag存ID号，节点的文本信息显示在树上
        private void InitDTreeView(ref TreeView treeView, DataTable dataTable)
        {
            // 连接DataTable的视图
            DataView dv = new DataView(dataTable);
            AddTree(ref treeView, dv, 0, (TreeNode)null);
            treeView.ExpandAll();
        }
          
        private void AddTree(ref TreeView treeView, DataView dv, int PID, TreeNode pNode)
        {
            //树控件上的节点
            TreeNode tn = new TreeNode();
            dv.RowFilter = "[PId]=" + PID;
            foreach (DataRowView row in dv)
            {
                //添加根节点
                if (pNode == null)
                {
                    tn.Tag = row["Id"].ToString();
                    tn.Text = row["Name"].ToString();
                    treeView.Nodes.Add(tn);
                    //tn.ExpandAll();
                    AddTree(ref treeView, dv, Int32.Parse(row["Id"].ToString()), tn);
                }
                else
                {
                    TreeNode tn2 = new TreeNode();
                    tn2.Tag = row["Id"].ToString();
                    tn2.Text = row["Name"].ToString();
                    pNode.Nodes.Add(tn2);
                    tn.ExpandAll();
                    AddTree(ref treeView, dv, Int32.Parse(row["Id"].ToString()), tn2);
                }
            }
        }


        private void BinTreeView()
        {
            //得到测试用的 DataTable  
            InitTestDataSet(ref m_DesTreeDataTable);
            //定义临时树节点  
            TreeNode tmpNd;
            //从DataTable中得到所有父节点为0的DataRow形成的数组  
            DataRow[] rows = m_DesTreeDataTable.Select("PId='0'");
            //遍历根节点数组  
            foreach (DataRow row in rows)
            {
                tmpNd = new TreeNode();
                //给根节点赋值 
                tmpNd.Name= row["id"].ToString();
                tmpNd.Text = row["name"].ToString();
                
                //将节点加入到树中  
                designTreeView.Nodes.Add(tmpNd);
                //递归加入此根节点的子节点  
                InitTreeView(tmpNd.Nodes, tmpNd.Name, m_DesTreeDataTable);
            }
        }

        private void InitTreeView(TreeNodeCollection treeNodeCollection, string p, DataTable dt)
        {
            TreeNode tmpNd;
            //取得以此节点为父节点的数据行  
            DataRow[] rows = dt.Select("PId='" + p + "'");
            foreach (DataRow row in rows)
            {
                tmpNd = new TreeNode();
                //给根节点赋值  
                tmpNd.Name = row["id"].ToString();
                tmpNd.Text = row["name"].ToString();
                //将节点加入到树中  
                treeNodeCollection.Add(tmpNd);
                //递归加入此节点的子节点  
                InitTreeView(tmpNd.Nodes, tmpNd.Name, dt);
            }
        }




        private void InitTestDataSet(ref DataTable table)
        {
            foreach (XmlSchema p in XmlSchema.m_aXmlParas)
            {
                table.Columns.Add(p.m_sName, p.m_Type);
            }
            table.PrimaryKey = new DataColumn[] { table.Columns["Id"] };
            m_DesTreeDataTable.Columns["Id"].AutoIncrement = true;
            newdt = new DataTable();
            newdt = table.Clone();
            dataGridView1.DataSource = newdt;
            //隐藏最后一列
            dataGridView1.Columns[3].Visible = false;

            DataRow root = table.NewRow();
            root["PId"] = 0;
            root["Id"] = 1;
            root["Name"] = "设计需求树";
            root["RichTextString"] = "";
            table.Rows.Add(root);
            root = table.NewRow();
            root["PId"] = 0;
            root["Id"] = 2;
            root["Name"] = "设计需";
            root["RichTextString"] = "";
            table.Rows.Add(root);
            root = table.NewRow();
            root["PId"] = 1;
            root["Id"] = 3;
            root["Name"] = "设计需求";
            root["RichTextString"] = "";
            table.Rows.Add(root);
            root = table.NewRow();
            root["PId"] = 0;
            root["Id"] = 4;
            root["Name"] = "设计需";
            root["RichTextString"] = "";
            table.Rows.Add(root);
            root = table.NewRow();
            root["PId"] = 4;
            root["Id"] = 5;
            root["Name"] = "设计需";
            root["RichTextString"] = "";
            table.Rows.Add(root);
            root = table.NewRow();
            root["PId"] = 3;
            root["Id"] = 6;
            root["Name"] = "设计需222";
            root["RichTextString"] = "";
            table.Rows.Add(root);


        }
        //读xml文件，信息读入绑定树控件的表中
        public void LoadDeTree(string sxmlFile)
        {
            if(DesignTree.LoadXMLFile(sxmlFile))
            {
                //清空节点
                designTreeView.Nodes.Clear();
                //清除表格所有的数据
                m_DesTreeDataTable.Clear();
                foreach(DesignTree node in DesignTree.m_AllDesignNode)
                {
                    AddDeNodeToDataSet(node, ref m_DesTreeDataTable);
                }
            }
        }

    

        //把对象信息加入表中
        public void AddDeNodeToDataSet(DesignTree node,ref DataTable table)
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
            DataRow dr = m_DesTreeDataTable.NewRow();
            // DesignTree node = new DesignTree();
            //dr.Delete();
            //m_DesTreeDataTable.Rows.
            //判断ID是否存在
            int tmpid= Convert.ToInt32(dataGridView1[1, 0].Value.ToString());
            DataRow[] rows = m_DesTreeDataTable.Select("Id='" + tmpid + "'");
            //判断ID是否存在,存在编辑原表格数据
            if (rows.Length>0)
            {

                rows[0].BeginEdit();
                rows[0]["Name"]= tmpTree.SelectedNode.Text;
                rows[0]["PId"] = Convert.ToInt32(dataGridView1[0, 0].Value.ToString());
                rows[0]["Id"] = Convert.ToInt32(dataGridView1[1, 0].Value.ToString());
                rows[0]["RichTextString"] = richTextBox1.Rtf;
                rows[0].EndEdit();
            }
            else
            {
                dr["Name"] = tmpTree.SelectedNode.Text;
                dr["PId"] = Convert.ToInt32(dataGridView1[0, 0].Value.ToString());
                dr["Id"] = Convert.ToInt32(dataGridView1[1, 0].Value.ToString());
                dr["RichTextString"] = richTextBox1.Rtf;
                //dr.EndEdit();
                m_DesTreeDataTable.Rows.Add(dr);
            }
            //dr.BeginEdit();
           
            

        }
      
        //保存整个树节点的信息，写入xml文件中
        private void saveButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_DesTreeDataTable.WriteXml(m_sDesignTreeFile, XmlWriteMode.IgnoreSchema);
        }

        //打开word文档导入到树控件
        private void openButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            

        }

        private void designTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            newdt.Rows.Clear();
            richTextBox1.Rtf = "";
            if (designTreeView.SelectedNode.Tag != null)
            {

                int id = Convert.ToInt32(designTreeView.SelectedNode.Tag);

                DataRow[] rows = m_DesTreeDataTable.Select("Id='" + id + "'");
                foreach (DataRow row in rows)
                {
                    newdt.Rows.Add(row.ItemArray);
                }
                richTextBox1.Rtf = newdt.Rows[0]["RichTextString"].ToString();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // LoadDeTree(m_sDesignTreeFile);
            //TreeView绑定表格
            // InitDTreeView(ref designTreeView, m_DesTreeDataTable);
            BinTreeView();              //绑定树控件  
            designTreeView.ExpandAll();      //展开所有节点  
        }

        //tree的信息怎么编排PID，ID信息，从上到下自动，ID固定不变的话，新插入的节点信息ID号跟着递增（自动编排，还是手动写）



    }
}