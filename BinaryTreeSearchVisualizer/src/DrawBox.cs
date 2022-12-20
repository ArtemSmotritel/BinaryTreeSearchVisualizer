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

        public static void DrawTree(BinaryTree binaryTree, Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var nodeInfos = binaryTree.GetNodesInfo();
            foreach (var nodeInfo in nodeInfos)
            {
                GraphicUtils.DrawConnectionToParent(nodeInfo, graphics);
            }
            foreach (var node in nodeInfos)
            {
                GraphicUtils.DrawNode(node, graphics);
            }
        }

        public void DrawPath(BinaryTree binaryTree, long value, Graphics graphics)
        {
            if (binaryTree == null || binaryTree.root == null)
            {
                return;
            }
            var g = CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            RecursiveDrawPath(binaryTree.root, null, value, g);
        }

        public void RecursiveDrawPath(ApplicationTree.TreeNode? node, NodeInfo? parentInfo, long value, Graphics graphics)
        {
            if (node == null)
            {
                return;
            }

            Thread.Sleep(1000);
            if (parentInfo != null)
            {
                GraphicUtils.HighlightNode(parentInfo, graphics, Color.Black);
            }
            var nodeInfo = NodeInfo.Create(node, parentInfo);

            if (value > nodeInfo.Node.Value)
            {
                if (nodeInfo.RightChildNodeInfo == null)
                {
                    GraphicUtils.HighlightNode(nodeInfo, graphics, Color.DarkRed);
                }
                else
                {
                    GraphicUtils.HighlightNode(nodeInfo, graphics, Color.Blue);
                    RecursiveDrawPath(node.rightChild, nodeInfo, value, graphics);
                }
            }
            else if (value < nodeInfo.Node.Value)
            {
                if (nodeInfo.LeftChildNodeInfo == null)
                {
                    GraphicUtils.HighlightNode(nodeInfo, graphics, Color.DarkRed);
                }
                else
                {
                    GraphicUtils.HighlightNode(nodeInfo, graphics, Color.Blue);
                    RecursiveDrawPath(node.leftChild, nodeInfo, value, graphics);
                }
            }
            else
            {
                GraphicUtils.HighlightNode(nodeInfo, graphics, Color.Green);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
