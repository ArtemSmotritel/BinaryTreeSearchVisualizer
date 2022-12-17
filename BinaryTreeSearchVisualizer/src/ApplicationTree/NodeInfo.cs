namespace BinaryTreeSearchVisualizer.src.ApplicationTree
{
    internal class NodeInfo
    {
        private const int NodeOffset = 70;

        public NodeInfo(TreeNode node, NodeInfo? parentNodeInfo) 
        {
            Node = node;
            ParentNodeInfo= parentNodeInfo;
            DetermineWhatChild();
            DetermineCoordinates();
        }

        public TreeNode Node { get; private set; }
        public NodeInfo? ParentNodeInfo { get; private set; }
        public bool IsRightChild {  get; private set; }
        public bool IsLeftChild {  get; private set; }
        public bool IsRoot {  get; private set; }
        public int CenterX { get; private set; }
        public int CenterY { get; private set; }
        public int Radius { get { return 25; } }

        private void DetermineWhatChild()
        {
            IsRightChild = false;
            IsLeftChild = false;
            IsRoot = false;
            if (ParentNodeInfo == null)
            {
                IsRoot = true;
                return;
            }
            var thisNode = Node; 
            var parentNode = ParentNodeInfo.Node;
            if (parentNode.rightChild == thisNode)
            {
                IsRightChild = true;              
            }
            else if (parentNode.leftChild == thisNode)
            {
                IsLeftChild = true;
            }
        }

        private void DetermineCoordinates()
        {
            if (IsRoot)
            {
                CenterX = 350;
                CenterY = 150;
            }
            else if (IsLeftChild)
            {
                CenterX = ParentNodeInfo!.CenterX - (NodeOffset * Node.Size);
                CenterY = ParentNodeInfo.CenterY + NodeOffset;
            }
            else if (IsRightChild)
            {
                CenterX = ParentNodeInfo!.CenterX + (NodeOffset * Node.Size);
                CenterY = ParentNodeInfo.CenterY + NodeOffset;
            }
        }

        public override string ToString()
        {
            return $"node {Node.ToString()}\n" +
                $"x: {CenterX}; y: {CenterY}\n" +
                $"root: {IsRoot}\n" +
                $"left: {IsLeftChild}";
        }
    }
}
