using BinaryTreeSearchVisualizer.src.ApplicationTree;
using System.Drawing.Drawing2D;

namespace BinaryTreeSearchVisualizer.src
{
    internal class DrawBox : PictureBox
    {
        private static Color traversalColor = Color.Blue;

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
                using (pathGraphics = CreateGraphics())
                {
                    GraphicUtils.HighlightNode(lastHighlightedNode, pathGraphics!, Color.Black);
                }
                lastHighlightedNode = null;
            }
        }

        public void DrawFindPath(BinaryTree binaryTree, long value)
        {
            HideLastHighlight();
            if (binaryTree == null || binaryTree.root == null)
            {
                return;
            }
            using (pathGraphics = CreateGraphics())
            {
                pathGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                DrawPath(binaryTree.root, value, null, Color.Green, Color.Red);
            }
        }

        public void DrawRemovePath(BinaryTree binaryTree, long value)
        {
            HideLastHighlight();
            if (binaryTree == null || binaryTree.root == null)
            {
                return;
            }
            using (pathGraphics = CreateGraphics())
            {
                pathGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                DrawPath(binaryTree.root, value, null, Color.Red, Color.Blue);
            }
        }

        public void DrawInsertPath(BinaryTree binaryTree, long value)
        {
            HideLastHighlight();
            if (binaryTree == null || binaryTree.root == null)
            {
                return;
            }
            using (pathGraphics = CreateGraphics())
            {
                pathGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                DrawPath(binaryTree.root, value, null, Color.Green, Color.Blue);
            }
        }

        public void DrawFindKthElementPath(BinaryTree binaryTree, long value)
        {

        }

        private void DrawPath(ApplicationTree.TreeNode? node, long value, NodeInfo? parentNodeInfo, Color findColor, Color missingColor)
        {
            Thread.Sleep(600);
            if (node == null)
            {
                lastHighlightedNode = parentNodeInfo;
                GraphicUtils.HighlightNode(parentNodeInfo, pathGraphics!, missingColor);
                return;
            }

            GraphicUtils.HighlightNode(parentNodeInfo, pathGraphics!, Color.Black);
            var nodeInfo = NodeInfo.Create(node, parentNodeInfo);
            lastHighlightedNode = nodeInfo;

            if (value == node.Value)
            {
                GraphicUtils.HighlightNode(nodeInfo, pathGraphics!, findColor);
                Thread.Sleep(600);
                return;
            }

            GraphicUtils.HighlightNode(nodeInfo, pathGraphics!, traversalColor);
            if (value > node.Value)
            {
                DrawPath(node.rightChild, value, nodeInfo, findColor, missingColor);
            }
            else
            {
                DrawPath(node.leftChild, value, nodeInfo, findColor, missingColor);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
