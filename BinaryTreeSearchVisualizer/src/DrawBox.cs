using BinaryTreeSearchVisualizer.src.ApplicationTree;
using System.Drawing.Drawing2D;

namespace BinaryTreeSearchVisualizer.src
{
    internal class DrawBox : PictureBox
    {
        public DrawBox() 
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public void DrawTree(BinaryTree binaryTree, Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var nodeInfos = binaryTree.GetNodesInfo();
            foreach (var node in nodeInfos)
            {
                GraphicUtils.DrawNode(node, graphics);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
