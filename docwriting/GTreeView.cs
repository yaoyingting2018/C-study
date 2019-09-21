using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace docWriting
{
    ///<summary>
    /// 导航树控件
    ///</summary>
    [DesignTimeVisible(true)]
    [Serializable]
    public class GTreeView : TreeView
    {
        #region 成员变量

        ///<summary>
        /// 存储多选时选择的节点
        ///</summary>
        private IList<TreeNode> selectedNodeList = new List<TreeNode>();

        ///<summary>
        /// 当前节点
        ///</summary>
        private TreeNode currentNode = null;

        #endregion

        #region 属性

        ///<summary>
        /// 是否是多选
        ///</summary>
        public bool IsMultiSelect { get; set; }

        ///<summary>   
        ///   选择的节点的集合
        ///</summary>
        public IList<TreeNode> SelectedNodeList
        {
            get { return selectedNodeList; }
        }

        #endregion

        #region Delegate & Event

        ///<summary>
        /// 节点被拖动后要处理事件的Delegate
        ///</summary>
        ///<param name="sourceNode">被拖动的节点</param>
        ///<param name="targetNode">目标节点</param>
        public delegate void OnDragNodeSucceed(TreeNode sourceNode, TreeNode targetNode);

        ///<summary>
        /// 判断目标节点是否接受拖动的Delegate
        ///</summary>
        ///<param name="targetNode"></param>
        ///<returns></returns>
        public delegate bool IsNodeCanAcceptDrag(TreeNode targetNode);

        ///<summary>
        /// 节点被拖动后要处理事件
        ///</summary>
        public event OnDragNodeSucceed TreeNodeCanAcceptDragedHandler;

        ///<summary>
        /// 判断目标节点是否接受拖动的事件处理
        ///</summary>
        public event IsNodeCanAcceptDrag IsNodeCanAcceptDragHandler;

        #endregion

        #region 类函数

        ///<summary>
        /// 构造函数
        ///</summary>
        public GTreeView()
            : base()
        {
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;
        }

        ///<summary>
        /// 鼠标单击事件
        ///</summary>
        ///<param name="e">TreeNodeMouseClickEventArgs对象类</param>
        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            this.SelectedNode = e.Node;
            var isSingleSelected = false;

            // 如果是多选，则根据按钮情况设置节点的选择状态
            if (IsMultiSelect)
            {
                if (!(SelectedNodeList.Count == 1 && SelectedNodeList[0] == SelectedNode))
                {
                    if ((Control.ModifierKeys & Keys.Control) != 0 || e.Button == MouseButtons.Right)
                    {
                        ctrlMultiSelectNodes(SelectedNode, e.Button == MouseButtons.Right);
                    }
                    else if ((Control.ModifierKeys & Keys.Shift) != 0)
                    {
                        shiftMultiSelectNodes(SelectedNode, e.Button == MouseButtons.Right);
                    }
                    else
                    {
                        isSingleSelected = true;
                        singleSelectNode(SelectedNode);
                    }
                }
                isSingleSelected = true;
            }
            else
            {
                singleSelectNode(SelectedNode);
                setCurrentNode(SelectedNode);
            }

            this.Invalidate();
        }


        ///<summary>
        /// 重绘,主要是在Checkbox/RadioButton前面有图片
        ///</summary>
        ///<param name="e">DrawTreeNodeEventArgs对象类</param>
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            if (e.Bounds.X == -1)
                return;

            e.DrawDefault = false;

            Font font = this.Font;
            if (e.Node.NodeFont != null) font = e.Node.NodeFont;

            Color color = this.ForeColor;

            if (SelectedNodeList.Contains(e.Node))
            {
                color = SystemColors.HighlightText;
            }
            else if (e.Node.ForeColor != Color.Empty)
            {
                color = e.Node.ForeColor;

            }


            Graphics g = e.Graphics;
            Rectangle textBounds = new Rectangle();

            //GTreeNode extNode = e.Node as GTreeNode;

            textBounds.X = e.Bounds.X;
            textBounds.Y = e.Bounds.Y;
            textBounds.Width = e.Bounds.Width;
            textBounds.Height = e.Bounds.Height;

            // 绘制节点的文本
            if (SelectedNodeList.Contains(e.Node))
            {
                g.FillRectangle(SystemBrushes.Highlight, textBounds);
                // ControlPaint.DrawFocusRectangle(g, textBounds, color, SystemColors.Highlight);
                TextRenderer.DrawText(g, e.Node.Text, font, textBounds, color, TextFormatFlags.Default);
            }
            else
            {
                // g.FillRectangle(SystemBrushes.Window, textBounds);
                TextRenderer.DrawText(g, e.Node.Text, font, textBounds, color, TextFormatFlags.Default);
            }
        }


        //控件初始化
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GTreeViewExt
            //
            this.Indent = 25;
            this.ItemHeight = 25;
            this.ResumeLayout(false);

        }

        #endregion

        #region 鼠标拖动节点移动

        ///<summary>
        /// 拖动节点移动,在鼠标拖放操作结束时发生
        ///</summary>
        ///<param name="drgevent">DragEventArgs对象</param>
        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);




            var moveNode = (TreeNode)drgevent.Data.GetData(typeof(TreeNode));

            //根据鼠标坐标确定要移动到的目标节点 
            Point point = this.PointToClient(new Point(drgevent.X, drgevent.Y));
            var targetNode = this.GetNodeAt(point);

            // 如果目标节点不接受拖动，则返回
            if (IsNodeCanAcceptDragHandler != null)
            {
                if (!IsNodeCanAcceptDragHandler(targetNode))
                {
                    return;
                }
            }

            // 确定落下的节点不是被拖拽节点本身或者被拖拽节点的子节点
            if (!moveNode.Equals(targetNode) && !containsNode(moveNode, targetNode))
            {
                var newMoveNode = (TreeNode)moveNode.Clone();
                targetNode.Nodes.Insert(targetNode.Index, newMoveNode);

                //更新当前拖动的节点选择 
                this.SelectedNode = newMoveNode;

                //移除拖放的节点 
                moveNode.Remove();
                moveNode = newMoveNode;
                newMoveNode.Expand();

                if (TreeNodeCanAcceptDragedHandler != null)
                {
                    TreeNodeCanAcceptDragedHandler(moveNode, targetNode);
                }
            }
        }

        ///<summary>
        /// 拖动节点移动,在用鼠标将某项拖动到该控件的工作区时发生
        ///</summary>
        ///<param name="drgevent">DragEventArgs对象</param>
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);

            if (drgevent.Data.GetDataPresent(typeof(TreeNode)))
            {
                drgevent.Effect = DragDropEffects.Move;
            }
            else
            {
                drgevent.Effect = DragDropEffects.None;
            }
        }

        ///<summary>
        /// 拖动节点移动，在用户开始拖动项时发生
        ///</summary>
        ///<param name="e">ItemDragEventArgs对象</param>
        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            base.OnItemDrag(e);

            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        #endregion 鼠标拖动节点移动

        #region Private Methods

        ///<summary>   
        ///   按ctrl键多选的方法 
        ///</summary>   
        ///<param   name="node"></param>   
        ///<param   name="mustSelect"></param>
        private void ctrlMultiSelectNodes(TreeNode node, bool mustSelect)
        {
            if (SelectedNodeList.Contains(node) && !mustSelect)
            {
                SelectedNodeList.Remove(node);
                setCurrentNode((TreeNode)SelectedNodeList[SelectedNodeList.Count - 1]);
            }
            else if (!mustSelect)
            {
                SelectedNodeList.Add(node);
                setCurrentNode(node);
            }

        }

        ///<summary>
        /// 按shift键多选的方法 
        ///</summary>
        ///<param name="node"></param>
        ///<param name="mustSelect"></param>
        private void shiftMultiSelectNodes(TreeNode node, bool mustSelect)
        {
            if (mustSelect)
            {
                return;
            }
            if (SelectedNodeList.Contains(node))
            {
                SelectedNodeList.Remove(node);
                setCurrentNode((TreeNode)SelectedNodeList[SelectedNodeList.Count - 1]);
            }
            else
            {
                if (node.Parent == currentNode.Parent)
                {

                    TreeNode addNode = node;
                    for (int i = System.Math.Abs(currentNode.Index - node.Index); i > 0; i--)
                    {
                        if (!SelectedNodeList.Contains(addNode))
                        {
                            SelectedNodeList.Add(addNode);
                        }

                        addNode = currentNode.Index > node.Index ? addNode.NextNode : addNode.PrevNode;
                    }

                    setCurrentNode(node);
                }
                else
                {
                    singleSelectNode(SelectedNode);
                }
            }


        }

        ///<summary>   
        /// single select   
        ///</summary>   
        ///<param   name="node"></param>
        private void singleSelectNode(TreeNode node)
        {
            SelectedNodeList.Clear();
            SelectedNodeList.Add(node);
            setCurrentNode(node);
        }

        ///<summary>   
        ///   Set current node   
        ///</summary>   
        ///<param   name="node"></param>
        private void setCurrentNode(TreeNode node)
        {
            //if (isMulSelect)
            //    SelectedNode = null;
            if (currentNode != node)
            {
                currentNode = node as TreeNode;
            }
        }


        ///<summary>
        /// 确定一个节点是否是另一个节点的祖先节点
        ///</summary>
        ///<param name="parentNode"></param>
        ///<param name="childNode"></param>
        ///<returns></returns>
        private bool containsNode(TreeNode parentNode, TreeNode childNode)
        {
            if (childNode.Parent == null) return false;
            if (childNode.Parent.Equals(parentNode)) return true;

            return containsNode(parentNode, childNode.Parent);
        }

        #endregion
    }
}
