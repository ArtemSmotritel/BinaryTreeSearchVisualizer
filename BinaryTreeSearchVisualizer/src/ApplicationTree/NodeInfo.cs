namespace BinaryTreeSearchVisualizer.src.ApplicationTree
{
    internal class NodeInfo
    {
        private const int NodeOffset = 70;

        public NodeInfo(TreeNode node, NodeInfo? parentNodeInfo) 
        {
            Node = node;
            ParentNodeInfo = parentNodeInfo;
            LeftChildNodeInfo = null;
            RightChildNodeInfo = null;
            DetermineWhatChild();
        }

        public TreeNode Node { get; private set; }
        public NodeInfo? ParentNodeInfo { get; private set; }
        public NodeInfo? LeftChildNodeInfo { get; set; }
        public NodeInfo? RightChildNodeInfo { get; set; }
        public bool IsRightChild {  get; private set; }
        public bool IsLeftChild {  get; private set; }
        public bool IsRoot {  get; private set; }
        public int CenterX { get; private set; }
        public int CenterY { get; private set; }
        public int Radius { get { return 30; } }

        public void DetermineCoordinates()
        {
            if (IsRoot)
            {
                CenterX = 650;
                CenterY = 150;
            }
            else if (IsLeftChild)
            {
                var nodeCountOffset = RightChildNodeInfo?.Node?.Size ?? 0;
                CenterX = ParentNodeInfo!.CenterX - (NodeOffset * (nodeCountOffset + 1));
                CenterY = ParentNodeInfo.CenterY + NodeOffset;
            }
            else if (IsRightChild)
            {
                var nodeCountOffset = LeftChildNodeInfo?.Node?.Size ?? 0;
                CenterX = ParentNodeInfo!.CenterX + (NodeOffset * (nodeCountOffset + 1));
                CenterY = ParentNodeInfo.CenterY + NodeOffset;
            }
        }

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

        public override string ToString()
        {
            return $"node {Node.ToString()}\n" +
                $"x: {CenterX}; y: {CenterY}\n" +
                $"root: {IsRoot}\n" +
                $"left: {IsLeftChild}";
        }
    }
}
