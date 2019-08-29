using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace documentwrite
{

    partial class TreeForm
    {
        public SplitContainer splitContainer1;
        

        public void CreatesplitContainer()
        {
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
            splitContainer1.SuspendLayout();

            // splitContainer1
            // 
            splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            splitContainer1.Location = new System.Drawing.Point(433, 76);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            splitContainer1.Size = new System.Drawing.Size(603, 626);
            splitContainer1.SplitterDistance = 233;
            splitContainer1.TabIndex = 14;

            this.Controls.Add(splitContainer1);
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
            splitContainer1.ResumeLayout(false);
        }
    }

        //动态加载设计树的表格和富文本框
        class DesignControls: IDisposable
    {
        public DataGridView dataGridView1;
        public RichTextBox richTextBox1;
        

        public DesignControls(SplitContainer splitContainer)
        {
            dataGridView1 = new DataGridView();
            richTextBox1 = new RichTextBox();

            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(603, 238);
            dataGridView1.TabIndex = 0;
            // dataGridView换行设置
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;



            richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            richTextBox1.Location = new System.Drawing.Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(603, 395);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";

            // splitContainer1.Panel1
            // 
            splitContainer.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer.Panel2.Controls.Add(richTextBox1);
        
    }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        //释放托管资源
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~DesignControls() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    //编辑对话框
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
            // m_Config_form.FormBorderStyle = FormBorderStyle.Sizable;
            // m_Config_form.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            // m_Config_form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
}
