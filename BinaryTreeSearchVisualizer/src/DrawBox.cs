using BinaryTreeSearchVisualizer.src.ApplicationTree;
using System.Drawing.Drawing2D;

namespace BinaryTreeSearchVisualizer.src
{
    internal class DrawBox : PictureBox
    {
        private Graphics? pathGraphics;
        public NodeInfo? lastHighlightedNode;
        public DrawBox()
        {
            pathGraphics = null;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public void DrawTree(BinaryTree binaryTree, Graphics graphics)
        {
            lastHighlightedNode = null;
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

        public void HideLastHighlight()
        {
            if (lastHighlightedNode != null)
            {
                GraphicUtils.HighlightNode(lastHighlightedNode, pathGraphics!, Color.Black);
                lastHighlightedNode = null;
            }
        }

        public void DrawPath(BinaryTree binaryTree, long value, Color findColor, Color missingColor)
        {
            if (binaryTree == null || binaryTree.root == null)
            {
                return;
            }
            pathGraphics = CreateGraphics();
            pathGraphics.SmoothingMode = SmoothingMode.AntiAlias;            
            RecursiveDrawPath(binaryTree.root, null, value, findColor, missingColor);
        }

        private void RecursiveDrawPath(ApplicationTree.TreeNode? node, NodeInfo? parentInfo, 
            long value, Color findColor, Color missingColor)
        {
            if (node == null)
            {
                return;
            }

            if (lastHighlightedNode != null)
            {
                Thread.Sleep(600);
                GraphicUtils.HighlightNode(lastHighlightedNode, pathGraphics!, Color.Black);
            }
            var nodeInfo = NodeInfo.Create(node, parentInfo);
            lastHighlightedNode = nodeInfo;

            if (value > node.Value)
            {
                if (nodeInfo.RightChildNodeInfo == null)
                {
                    GraphicUtils.HighlightNode(nodeInfo, pathGraphics!, missingColor);
                    lastHighlightedNode = null;
                    Thread.Sleep(600);
                }
                else
                {
                    GraphicUtils.HighlightNode(nodeInfo, pathGraphics!, Color.Blue);
                    RecursiveDrawPath(node.rightChild, nodeInfo, value, findColor, missingColor);
                }
            }
            else if (value < node.Value)
            {
                if (nodeInfo.LeftChildNodeInfo == null)
                {
                    GraphicUtils.HighlightNode(nodeInfo, pathGraphics!, missingColor);
                    lastHighlightedNode = null;
                    Thread.Sleep(600);
                }
                else
                {
                    GraphicUtils.HighlightNode(nodeInfo, pathGraphics!, Color.Blue);
                    RecursiveDrawPath(node.leftChild, nodeInfo, value, findColor, missingColor);
                }
            }
            else
            {
                GraphicUtils.HighlightNode(nodeInfo, pathGraphics!, findColor);
                Thread.Sleep(600);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
