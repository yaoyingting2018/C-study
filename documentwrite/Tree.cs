using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;


namespace documentwrite
{
   public class BaseTree
    {
        private uint m_PId;
        private uint m_Id;
        private string m_Name;
        
        public uint PId
        {
            get { return m_PId; }
            set { m_PId = value; }
        }
        public uint Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }


    }

    public class BaseXmlSchema
    {
        public String m_sName;
        public System.Type m_Type;
        public String m_sCaption;//显示在前端界面的名字
        public Boolean m_bIsDisplay; //是否显示
        public Boolean m_bIsEditable; //是否编辑，id,parentid不可编辑
       // public BaseXmlSchema(String sName, Type type, String sCaption, Boolean bDisplay, Boolean bEditable)
       // {
       //     m_sName = sName;
       //     m_Type = type;
       //     m_sCaption = sCaption;
       //     m_bIsDisplay = bDisplay;
       //     m_bIsEditable = bEditable;
       // }
       // public static BaseXmlSchema[] m_aXmlParas =
       //{
       //     new BaseXmlSchema("PId",typeof(uint),"PID",true,false),
       //     new BaseXmlSchema("Id",typeof(uint),"ID",true,false),
       //     可编辑
       //     new BaseXmlSchema("Name",typeof(string),"Name",true,true)
       // };

    }



    public class ZongTree:BaseTree
    {

    }
    //xml文件对应的数据表，前端显示名称
    public class DeisgnXmlSchema: BaseXmlSchema
    {
        //public String m_sName;
        //public System.Type m_Type;
        //public String m_sCaption;//显示在前端界面的名字
        //public Boolean m_bIsDisplay; //是否显示
        //public Boolean m_bIsEditable; //是否编辑，id,parentid不可编辑
        public DeisgnXmlSchema(String sName, Type type, String sCaption, Boolean bDisplay, Boolean bEditable)
        {
            m_sName = sName;
            m_Type = type;
            m_sCaption = sCaption;
            m_bIsDisplay = bDisplay;
            m_bIsEditable = bEditable;
        }

        //数据表字段信息，放入数组中
        public static DeisgnXmlSchema[] m_aXmlParas =
        {
            new DeisgnXmlSchema("PId",typeof(uint),"PID",true,false),
            new DeisgnXmlSchema("Id",typeof(uint),"ID",true,false),
            //可编辑
            new DeisgnXmlSchema("Name",typeof(string),"Name",true,true),
            //
            new DeisgnXmlSchema("RichTextString",typeof(string),"RichText",true,true)

        };
    }





    //ICloneable拷贝
    public class DesignTree : BaseTree, ICloneable
    {
        private RichTextBox m_RichText;
        
        public string RichTextString
        {
            get
            {
                return m_RichText.Rtf;

            }
            set
            {
                m_RichText.Rtf = value;
            }
        }
        
        //所有节点信息
        public static List<DesignTree> m_AllDesignNode = new List<DesignTree>();

        //空参构造方法
        public DesignTree()
        {

        }

        //浅拷贝，影响以前的数据
        public Object Clone()
        {
            return (this.MemberwiseClone());
        }

        public object GetValue(String name)
        {
            object t_Obj = null;
            foreach (PropertyInfo pi in typeof(DesignTree).GetProperties())
            {
                if (pi.Name.ToLower() == name.ToLower())//should not use case
                {
                    t_Obj = (pi.GetValue(this, null));
                }
            }

            return (t_Obj);
        }

        //根据属性名字，设置属性值
        public void SetValue(String name, object val)
        {
            foreach (PropertyInfo pi in typeof(DesignTree).GetProperties())
            {
                if (pi.Name.ToLower() == name.ToLower())//should not use case
                {
                    pi.SetValue(this, val, null);
                }
            }
        }

        //xml节点返回定义的类对象
        public DesignTree(XmlNode node)
        {            
            m_RichText = new RichTextBox();
            //m_ChildrenDesignNode = new List<DesignTree>();
            foreach (DeisgnXmlSchema p in DeisgnXmlSchema.m_aXmlParas)
            {

                try
                {
                    if (node[p.m_sName] != null)
                    {
                        //xml节点的InnerText转成字段相应的类型
                        this.SetValue(p.m_sName, System.Convert.ChangeType(node[p.m_sName].InnerText, p.m_Type));
                    }

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            try
            {
                //特殊类型的处理，自己写转换方法
                if (node["RichTextString"] != null)
                {
                    m_RichText.Rtf = node["RichTextString"].InnerText.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        //加载XML文件,数据扔到类的成员allDesignNode
        public static Boolean LoadXMLFile(string sXmlFile)
        {
            //xml文档信息
            XmlDocument t_XmlDoc = new XmlDocument();
            try
            {
                File.Copy(sXmlFile, sXmlFile + ".bak", true);//create a backup-file
                t_XmlDoc.Load(sXmlFile);//use try to catch possible xml file format errors
                //选中表格名
                XmlNodeList nodelist = t_XmlDoc.SelectNodes("/*/designtable");

                DesignTree.m_AllDesignNode.Clear();
                foreach (XmlNode node in nodelist)
                {
                    DesignTree tmpNode = new DesignTree(node);

                    //if (tmpCmd.CMDParentId == 0)
                    DesignTree.m_AllDesignNode.Add(tmpNode);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }


    //测试表格字段
    //xml文件对应的数据表，前端显示名称
    public class TestXmlSchema : BaseXmlSchema
    {
        //public String m_sName;
        //public System.Type m_Type;
        //public String m_sCaption;//显示在前端界面的名字
        //public Boolean m_bIsDisplay; //是否显示
        //public Boolean m_bIsEditable; //是否编辑，id,parentid不可编辑
        public TestXmlSchema(String sName, Type type, String sCaption, Boolean bDisplay, Boolean bEditable)
        {
            m_sName = sName;
            m_Type = type;
            m_sCaption = sCaption;
            m_bIsDisplay = bDisplay;
            m_bIsEditable = bEditable;
        }

        //数据表字段信息，放入数组中
        public static TestXmlSchema[] m_aXmlParas =
        {
            new TestXmlSchema("PId",typeof(uint),"PID",true,false),
            new TestXmlSchema("Id",typeof(uint),"ID",true,false),
            new TestXmlSchema("Name",typeof(string),"Name",true,true),
            new TestXmlSchema("PIdText",typeof(string),"PIdText",true,true),
            //可编辑
            new TestXmlSchema("IdList",typeof(string),"IdList",true,true),
            //
            
            new TestXmlSchema("TestItendify",typeof(string),"TestItendify",true,true),
            new TestXmlSchema("TestPriority",typeof(string),"TestPriority",true,true),
            new TestXmlSchema("TraceRelationships",typeof(string),"TraceRelationships",true,true),
            new TestXmlSchema("TestContent",typeof(string),"TestContent",true,true),
            new TestXmlSchema("TestReqResolve",typeof(string),"TestReqResolve",true,true),
            new TestXmlSchema("AdequacyRequirements",typeof(string),"AdequacyRequirements",true,true),
            new TestXmlSchema("TerminalCondition",typeof(string),"TerminalCondition",true,true)
        };
    }

    // 测试树
    public class TestTree : BaseTree, ICloneable
    {
        private List<string> m_stringId; //存对应设计树的ID号，以，分割
        private string m_stestName; //测试项名称
        private string m_stestItendify; //测试项标识
        private string m_testPriority; //测试项优先级
        private RichTextBox m_TraceRelationships;  //测试项追踪关系
        private RichTextBox m_TestContent;  //测试内容
        private string m_TestReqResolve;  //测试需求分解
        private string m_AdequacyRequirements; //测试充分条件
        private string m_TerminalCondition; //测试终止条件

        //所有节点信息
        public static List<TestTree> m_AllTestNode = new List<TestTree>();

        public string IdList
        {
            //list转string
            get
            {
                string mId = "";
                try
                {
                    for (int i = 0; i < m_stringId.Count; i++)
                    {
                        if (i < m_stringId.Count - 1)
                        {
                            mId += m_stringId[i] + ",";
                        }
                        else { mId += m_stringId[i]; }


                    }
                }
                catch { }
                return mId;
            }
            //string转list
            set
            {
                string[] tmp = value.Split(new char[] { ',' });
                foreach (string tmpid in tmp)
                {
                    m_stringId.Add(tmpid);
                }
            }
        }


        public string TestName
        {
            get {return m_stestName; }
            set { m_stestName=value; }
        }
        public string TestSign
        {
            get {return m_stestItendify; }
            set { m_stestItendify=value; }
        }

        public string TestPrio
        {
            get {return m_testPriority; }
            set {m_testPriority=value; }
        }

        public string TraceRelationships
        {
            get
            {
                return m_TraceRelationships.Rtf;
            }
            set
            {
                m_TraceRelationships.Rtf = value;
            }
        }

        public string TestContent
        {
            get
            {
                return m_TestContent.Rtf;
            }
            set
            {
                m_TestContent.Rtf = value;
            }
        }


        public string TestReqResolve
        {
            get {return m_TestReqResolve ; }
            set { m_TestReqResolve = value; }
        }
        public string AdequacyRequirements
        {
            get {return m_AdequacyRequirements; }
            set {m_AdequacyRequirements=value ; }
        }
        public string TerminalCondition
        {
            get {return m_TerminalCondition; }
            set { m_TerminalCondition=value; }
        }


        //空参构造方法
        public TestTree()
        {

        }

        //浅拷贝，影响以前的数据
        public Object Clone()
        {
            return (this.MemberwiseClone());
        }

        public object GetValue(String name)
        {
            object t_Obj = null;
            foreach (PropertyInfo pi in typeof(TestTree).GetProperties())
            {
                if (pi.Name.ToLower() == name.ToLower())//should not use case
                {
                    t_Obj = (pi.GetValue(this, null));
                }
            }

            return (t_Obj);
        }

        //根据属性名字，设置属性值
        public void SetValue(String name, object val)
        {
            foreach (PropertyInfo pi in typeof(TestTree).GetProperties())
            {
                if (pi.Name.ToLower() == name.ToLower())//should not use case
                {
                    pi.SetValue(this, val, null);
                }
            }
        }

        //xml节点返回定义的类对象
        public TestTree(XmlNode node)
        {
            m_TraceRelationships = new RichTextBox();
            m_TestContent = new RichTextBox();
            //m_ChildrenDesignNode = new List<DesignTree>();
            foreach (DeisgnXmlSchema p in DeisgnXmlSchema.m_aXmlParas)
            {

                try
                {
                    if (node[p.m_sName] != null)
                    {
                        //xml节点的InnerText转成字段相应的类型
                        this.SetValue(p.m_sName, System.Convert.ChangeType(node[p.m_sName].InnerText, p.m_Type));
                    }

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            try
            {
                //特殊类型的处理，自己写转换方法
                if (node["TraceRelationships"] != null)
                {
                    m_TraceRelationships.Rtf = node["TraceRelationships"].InnerText.ToString();
                }
                if (node["TestContent"] != null)
                {
                    m_TestContent.Rtf = node["TestContent"].InnerText.ToString();
                }
                if (node["IdList"] != null)
                {
                    string[] tmp = node["IdList"].InnerText.ToString().Split(new char[] { ',' });
                    foreach (string tmpid in tmp)
                    {
                        m_stringId.Add(tmpid);
                    }

                }

            }
            catch (Exception ex)
            {

            }
        }

        //加载XML文件,数据扔到类的成员allTestNode
        public static Boolean LoadTestXMLFile(string sXmlFile)
        {
            //xml文档信息
            XmlDocument t_XmlDoc = new XmlDocument();
            try
            {
                File.Copy(sXmlFile, sXmlFile + ".bak", true);//create a backup-file
                t_XmlDoc.Load(sXmlFile);//use try to catch possible xml file format errors
                //选中表格名
                XmlNodeList nodelist = t_XmlDoc.SelectNodes("/*/testtable");

                TestTree.m_AllTestNode.Clear();
                foreach (XmlNode node in nodelist)
                {
                    TestTree tmpNode = new TestTree(node);

                    //if (tmpCmd.CMDParentId == 0)
                    TestTree.m_AllTestNode.Add(tmpNode);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }




        public enum TestPriority { 高, 中, 低 };
        public enum TestItendify { XQ_SA, XQ_SU, XQ_IO, XQ_BT, XQ_AC, XQ_SE, XQ_RE, XQ_YK, XQ_AT };
    }

}
