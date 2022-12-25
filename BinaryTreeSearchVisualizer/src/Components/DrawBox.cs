using BinaryTreeSearchVisualizer.properties;
using BinaryTreeSearchVisualizer.src.ApplicationTree;
using System.Drawing.Drawing2D;

namespace BinaryTreeSearchVisualizer.src.Components
{
    internal class DrawBox : PictureBox
    {
        private static readonly Color traversalColor = Color.Blue;

        private Graphics? pathGraphics;
        public NodeInfo? lastHighlightedNode;
        public DrawBox() : base()
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

        public void DrawFindKthElementPath(BinaryTree binaryTree, long index)
        {
            HideLastHighlight();
            if (binaryTree == null || binaryTree.root == null)
            {
                return;
            }
            if (index > binaryTree.root.Size)
            {
                var size = binaryTree.root.Size;
                throw new Exception($"The tree has only {size} {(size == 1 ? "node" : "nodes")}. You cannot possibly find the {index} smallest element");
            }
            if (index < 1)
            {
                throw new Exception($"You cannot possibly find the {index} smallest element");
            }
            using (pathGraphics = CreateGraphics())
            {
                pathGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                DrawFindKthElementPath(binaryTree.root, index, null, Color.Green);
            }
        }

        private void DrawFindKthElementPath(ApplicationTree.TreeNode? node, long index, NodeInfo? parentNodeInfo, Color findColor)
        {
            Thread.Sleep(600);
            GraphicUtils.HighlightNode(parentNodeInfo, pathGraphics!, Color.Black);

            var nodeInfo = NodeInfo.Create(node!, parentNodeInfo);
            lastHighlightedNode = nodeInfo;

            var nodeCountInLeftChild = nodeInfo.LeftChildNodeInfo?.Node.Size ?? 0;

            if (index == nodeCountInLeftChild + 1)
            {
                GraphicUtils.HighlightNode(nodeInfo, pathGraphics!, findColor);
                Thread.Sleep(600);
                return;
            }

            GraphicUtils.HighlightNode(nodeInfo, pathGraphics!, traversalColor);
            if (index <= nodeCountInLeftChild)
            {
                DrawFindKthElementPath(node!.leftChild, index, nodeInfo, findColor);
            }
            else
            {
                var newIndex = index - (nodeCountInLeftChild + 1);
                DrawFindKthElementPath(node!.rightChild, newIndex, nodeInfo, findColor);
            }
        }

        private void DrawPath(ApplicationTree.TreeNode? node, long value, NodeInfo? parentNodeInfo, Color findColor, Color missingColor)
        {
            Thread.Sleep(VisualizerProperty.timeGap);
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
                Thread.Sleep(VisualizerProperty.timeGap);
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
    }
}
