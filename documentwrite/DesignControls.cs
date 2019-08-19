using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace documentwrite
{
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
}
