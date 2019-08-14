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



    public class ZongTree:BaseTree
    {

    }
    //xml文件对应的数据表，前端显示名称
    public class XmlSchema
    {
        public String m_sName;
        public System.Type m_Type;
       public String m_sCaption;//显示在前端界面的名字
        public Boolean m_bIsDisplay; //是否显示
        public Boolean m_bIsEditable; //是否编辑，id,parentid不可编辑
        public XmlSchema(String sName, Type type, String sCaption, Boolean bDisplay, Boolean bEditable)
        {
            m_sName = sName;
            m_Type = type;
            m_sCaption = sCaption;
            m_bIsDisplay = bDisplay;
            m_bIsEditable = bEditable;
        }
        //数据表字段信息，放入数组中
        public static XmlSchema[] m_aXmlParas =
        {
            new XmlSchema("PId",typeof(uint),"PID",true,false),
            new XmlSchema("Id",typeof(uint),"ID",true,false),
            //可编辑
            new XmlSchema("Name",typeof(string),"Name",true,true),
            //
            new XmlSchema("RichTextString",typeof(string),"RichText",true,true)

        };
    }
    //ICloneable拷贝
    public class DesignTree: BaseTree,ICloneable
    {
        private RichTextBox m_RichText;

        public string RichTextString
        {
            get
            {
                if (m_RichText == null)
                {
                    return "";
                }
                else
                {
                    return m_RichText.Rtf;
                }
               
            }
            set
            {
                m_RichText.Rtf = value;
            }
        }
        //子节点的信息
        private List<DesignTree> m_ChildrenDesignNode;
        public List<DesignTree> ChildrenDesignNode
        {
            get
            {
                return m_ChildrenDesignNode;
            }
            set
            {
                m_ChildrenDesignNode = value;
            }
        }
        //所有节点信息
        public static List<DesignTree> m_AllDesignNode = new List<DesignTree>();

        //空参构造方法
        public DesignTree()
        {
            m_ChildrenDesignNode = new List<DesignTree>();

        }

        //根据类的属性名字，获取属性值
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

        //浅拷贝，影响以前的数据
        public Object Clone()
        {
            return (this.MemberwiseClone());
        }

        //xml节点返回定义的类对象
        public DesignTree(XmlNode node)
        {

            m_RichText = new RichTextBox();
            m_ChildrenDesignNode = new List<DesignTree>();
            foreach(XmlSchema p in XmlSchema.m_aXmlParas)
            {

                try
                {
                    if (node[p.m_sName] != null)
                    {
                        //xml节点的InnerText转成字段相应的类型
                        this.SetValue(p.m_sName, System.Convert.ChangeType(node[p.m_sName].InnerText, p.m_Type));
                    }
                  
                }
                catch(System.Exception ex)
                {

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

       

        //所有节点信息根据父节点分组
        public Boolean AddToTreeList(ref List<DesignTree> list)
        {
            Boolean t_bResult = false;

            foreach (DesignTree tmpNode in list)
            {
                if (tmpNode.Id == PId)
                {
                    tmpNode.m_ChildrenDesignNode.Add(this);
                    t_bResult = true;
                }
                else
                {
                    t_bResult = AddToTreeList(ref tmpNode.m_ChildrenDesignNode);
                }
                if (t_bResult)
                {
                    break;
                }
            }

            return (t_bResult);
        }

    }

}
