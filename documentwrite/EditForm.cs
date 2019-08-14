using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace documentwrite
{
    public partial class EditForm : Form
    {
        private string nodename;//节点名称

        public string NodeName
        {
            get { return nodename; }
            set { nodename = value; }
        }

        public EditForm()
        {
            InitializeComponent();
        }

        //获取form2窗口的富文本框
        public RichTextBox RichTextBox
        {
            get { return this.richTextBox; }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox.Text.Trim()))
            {
                nodename = "设计需求";
            }
            else
            {
                nodename = richTextBox.Text;
            }

            //窗体对话框结果
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
