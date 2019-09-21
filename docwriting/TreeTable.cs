using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docWriting
{
    public enum TestPriority { 高, 中, 低 };
    public enum TestItendify { XQ_SA_, XQ_SU_, XQ_IO_, XQ_BT_, XQ_AC_, XQ_SE_, XQ_RE_, XQ_YK_, XQ_AT_ };

    public enum TestType { 功能测试,性能测试,接口测试,边界测试,安全性测试,恢复性测试,强度测试,余量测试};



    class TreeTable
    {
    }
    /// <summary>
    /// 基类，树
    /// </summary>
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

    /// <summary>
    /// 基类xml字段信息内容
    /// </summary>
    public class BaseXmlSchema
    {
        public String m_sName;
        public System.Type m_Type;
                                

    }
    /// <summary>
    /// 设计表字段信息
    /// </summary>
    public class DeisgnXmlSchema : BaseXmlSchema
    {
        
        public DeisgnXmlSchema(String sName, Type type)
        {
            m_sName = sName;
            m_Type = type;
           
        }

        //数据表字段信息，放入数组中
        public static DeisgnXmlSchema[] m_aXmlParas =
        {
            new DeisgnXmlSchema("PId",typeof(uint)),
            new DeisgnXmlSchema("Id",typeof(uint)),            
            new DeisgnXmlSchema("Name",typeof(string)),
            new DeisgnXmlSchema("DesignContent",typeof(string))

        };
    }

    /// <summary>
    /// 测试表字段信息
    /// </summary>
    public class TestXmlSchema : BaseXmlSchema
    {
       
        public TestXmlSchema(String sName, Type type)
        {
            m_sName = sName;
            m_Type = type;            
        }

        //数据表字段信息，放入数组中
        public static TestXmlSchema[] m_aXmlParas =
        {
            new TestXmlSchema("PId",typeof(uint)),
            new TestXmlSchema("Id",typeof(uint)),
            new TestXmlSchema("TestType",typeof(string)), //测试类型固定，根据设计表新建的节点根据此规类到测试表树上
            new TestXmlSchema("IdList",typeof(string)), //根据此进行搜索        
            new TestXmlSchema("Name",typeof(string)),                
            new TestXmlSchema("TestIdentify",typeof(string)),
            new TestXmlSchema("TestPriority",typeof(int)),
            new TestXmlSchema("TraceRelationships",typeof(string)),
            new TestXmlSchema("TestContent",typeof(string)),
            new TestXmlSchema("TestReqResolve",typeof(string)),            
            new TestXmlSchema("AdequacyRequirements",typeof(string)),
            new TestXmlSchema("TerminalCondition",typeof(string))
        };

        //测试需求分解字段
        public static TestXmlSchema[] m_testSubXmlParas =
       {
            new TestXmlSchema("Id",typeof(uint)),
            new TestXmlSchema("SubId",typeof(uint)),
            new TestXmlSchema("TestSubReq",typeof(string)),
            new TestXmlSchema("SubReqAnalyse",typeof(string)),
            new TestXmlSchema("TestSubIdentify",typeof(string))
        };
    }

    /// <summary>
    /// 垂直表格对应的对象
    /// </summary>
   public class TestGridObject: BaseTree
    {
        private string m_TestType;
        private string m_TestIdentify;
        private int m_TestPriority;
        private string m_TraceRelationships;
        private string m_TestContent;
        private string m_TestReqResolve;
        private string m_AdequacyRequirements;
        private string m_TerminalCondition;

       // public List<TestSubGrid> ListTestSubGrid=new List<TestSubGrid>();

        public string TestType
        {
            get {return m_TestType; }
            set { m_TestType=value; }
        }
        public string TestIdentify
        {
            get { return m_TestIdentify; }
            set { m_TestIdentify = value; }
        }

        public int TestPriority
        {
            get { return m_TestPriority; }
            set { m_TestPriority = value; }
        }

        public string TraceRelationships
        {
            get { return m_TraceRelationships; }
            set { m_TraceRelationships = value; }
        }

        public string TestContent
        {
            get { return m_TestContent; }
            set { m_TestContent = value; }
        }

        public string TestReqResolve
        {
            get { return m_TestReqResolve; }
            set { m_TestReqResolve = value; }
        }

        public string AdequacyRequirements
        {
            get { return m_AdequacyRequirements; }
            set { m_AdequacyRequirements = value; }
        }

        public string TerminalCondition
        {
            get { return m_TerminalCondition; }
            set { m_TerminalCondition = value; }
        }
    }

    /// <summary>
    /// 测试子表对象
    /// </summary>
    public class TestSubGrid
    {
        private uint m_Id;
        private string m_TestSubReq;
        private string m_SubReqAnalyse;
        private string m_TestSubIdentify;


        public string TestSubReq
        {
            get { return m_TestSubReq; }
            set { m_TestSubReq = value; }
        }

        public string SubReqAnalyse
        {
            get {return m_SubReqAnalyse; }
            set { m_SubReqAnalyse=value; }
        }

        public string TestSubIdentify
        {
            get {return m_TestSubIdentify; }
            set { m_TestSubIdentify=value; }
        }

    }



}
