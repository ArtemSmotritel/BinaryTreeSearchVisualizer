namespace BinaryTreeSearchVisualizer.src.ApplicationTree
{
    internal class BinaryTree
    {
        public TreeNode? root;

        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(long value)
        {
            root = new TreeNode(value);
        }

        public void Insert(long value)
        {
            var backupRoot = root;
            try
            {
                root = InsertTo(value, root);
            }
            catch (Exception)
            {
                root = backupRoot;
            }
        }

        public bool IsPresent(long value)
        {
            return IsPresenetIn(value, root);
        }

        public void Remove(long value)
        {
            var backupRoot = root;
            try
            {
                root = RemoveFrom(value, root);
            }
            catch (Exception)
            {
                root = backupRoot;
            }
        }

        public TreeNode? FindAt(int index)
        {
            return FindAt(index, root);
        }

        public int Count()
        {
            return CountNodes(root);
        }

        private int CountNodes(TreeNode? root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + CountNodes(root.leftChild) + CountNodes(root.rightChild);
        }

        private TreeNode? InsertTo(long  value, TreeNode? root)
        {
            if (root == null)
            {
                root = new TreeNode(value);
                return root;
            }
            if (value > root.Value)
            {
                root.rightChild = InsertTo(value, root.rightChild);
                root.IncreaseWeight();
            }
            else if (value < root.Value)
            {
                root.leftChild = InsertTo(value, root.leftChild);
                root.IncreaseWeight();
            }
            else if (value == root.Value)
            {
                throw new Exception();
            }
            return root;
        }

        private bool IsPresenetIn(long value, TreeNode? root)
        {
            if (root == null)
            {
                return false;
            }
            if (value > root.Value)
            {
                return IsPresenetIn(value, root.rightChild);
            }
            if (value < root.Value)
            {
                return IsPresenetIn(value, root.leftChild);
            }
            return true;
        }

        private TreeNode? RemoveFrom(long value, TreeNode? root)
        {
            if (root == null)
            {
                throw new Exception();
            }

            if (value > root.Value)
            {
                 root.rightChild = RemoveFrom(value, root.rightChild);
                 root.DecreaseWeight();
            }
            else if (value < root.Value)
            {
                root.leftChild = RemoveFrom(value, root.leftChild);
                root.DecreaseWeight();
            }
            else
            {
                if (root.rightChild == null)
                {
                    root.DecreaseWeight();
                    return root.leftChild;
                }
                if (root.leftChild == null)
                {
                    root.DecreaseWeight();
                    return root.rightChild;
                }
                root.Value = MinValue(root.rightChild);
                root.rightChild = RemoveFrom(root.Value, root.rightChild);
                root.DecreaseWeight();
            }
            return root;
        }

        private long MinValue(TreeNode root)
        {
            long minValue = root.Value;
            while (root.leftChild != null)
            {
                minValue = root.leftChild.Value;
                root = root.leftChild;
            }
            return minValue;
        }

        private TreeNode? FindAt(int index, TreeNode? root)
        {
            if (root == null || index > root.Size)
            {
                return null;
            }
            if (index == root.Size)
            {
                return root;
            }
            if (index < root.leftChild.Size)
            {
                return FindAt(index, root.leftChild);
            }
            return FindAt(index - root.leftChild.Size, root.rightChild);
        }

        public List<NodeInfo> GetNodesInfo()
        {
            if (root == null)
            {
                return Enumerable.Empty<NodeInfo>().ToList();
            }
            var result = new List<NodeInfo>(root.Size);
            AddNodeInfosToList(root, null, result);
            return result;
        }

        private void AddNodeInfosToList(TreeNode? node, NodeInfo? parentNodeInfo, List<NodeInfo> list) 
        {
            if (node == null)
            {
                return;
            }
            var nodeInfo = new NodeInfo(node, parentNodeInfo);
            if (node.rightChild != null) 
            {
                nodeInfo.RightChildNodeInfo = new NodeInfo(node.rightChild, nodeInfo);
            }
            if (node.leftChild != null)
            {
                nodeInfo.LeftChildNodeInfo = new NodeInfo(node.leftChild, nodeInfo);
            }
            nodeInfo.DetermineCoordinates();
            node.NodeInfo = nodeInfo;
            list.Add(nodeInfo); 
            AddNodeInfosToList(node.leftChild, nodeInfo, list);
            AddNodeInfosToList(node.rightChild, nodeInfo, list);
        }
    }
}
