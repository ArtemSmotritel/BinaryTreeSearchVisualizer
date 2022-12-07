using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeSearchVisualizer.src.BinaryTree
{
    internal class BinaryTree
    {
        private TreeNode? root;

        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(int value)
        {
            root = new TreeNode(value, null);
        }

        public TreeNode Insert(int value)
        {
            return InsertTo(value, root);
        }

        public bool IsPresent(int value)
        {
            return IsPresenetIn(value, root);
        }

        public void Remove(int value)
        {
            RemoveFrom(value, root);
        }

        public TreeNode FindAt(int index)
        {
            return FindAt(index, root);
        }

        private TreeNode? InsertTo(int value, TreeNode? targetNode)
        {
            if (targetNode == null)
            {
                targetNode = new TreeNode(value, null); // todo fix
                return targetNode;
            }
            else if (value > targetNode.Value)
            {
                var node = InsertTo(value, targetNode.rightChild);
                if (node != null)
                {
                    targetNode.IncreaseWeight();
                }
                return node;
            }
            else if (value < targetNode.Value)
            {
                var node = InsertTo(value, targetNode.leftChild);
                if (node != null)
                {
                    targetNode.IncreaseWeight();
                }
                return node;
            }
            return null;
        }

        private bool IsPresenetIn(int value, TreeNode? targetNode)
        {
            if (targetNode == null)
            {
                return false;
            }
            if (value > targetNode.Value)
            {
                return IsPresenetIn(value, targetNode.rightChild);
            }
            if (value < targetNode.Value)
            {
                return IsPresenetIn(value, targetNode.leftChild);
            }
            return true;
        }

        private bool RemoveFrom(int value, TreeNode? targetNode)
        {
            if (targetNode == null)
            {
                return false;
            }
            if (value > targetNode.Value)
            {
                var isDeleted = RemoveFrom(value, targetNode.rightChild);
                if (isDeleted)
                {
                    targetNode.DecreaseWeight();
                }
                return isDeleted;
            }
            if (value < targetNode.Value)
            {
                var isDeleted = RemoveFrom(value, targetNode.leftChild);
                if (isDeleted)
                {
                    targetNode.DecreaseWeight();
                }
                return isDeleted;
            }
            RemoveNode(targetNode);
            return true;
        }

        private void RemoveNode(TreeNode targetNode)
        {
            if (targetNode.leftChild == null && targetNode.rightChild == null)
            {
                targetNode = null;
            }
            else if (targetNode.rightChild == null)
            {
                targetNode = targetNode.leftChild;
            }
            else if (targetNode.leftChild == null)
            {
                targetNode = targetNode.rightChild;
            }
            else
            {
                TreeNode smallest = FindSmallest(targetNode.rightChild);
                targetNode.Value = smallest.Value;
                smallest = smallest.rightChild;
            }
        }

        private TreeNode? FindSmallest(TreeNode? node)
        {
            var result = node;
            while (result != null)
            {
                result = result.leftChild;
            }
            return result;
        }

        private TreeNode? FindAt(int index, TreeNode? targetNode)
        {
            if (index > targetNode.Size || targetNode == null)
            {
                return null;
            }
            if (index == targetNode.Size)
            {
                return targetNode;
            }
            if (index < targetNode.leftChild.Size)
            {
                return FindAt(index, targetNode.leftChild);
            }
            return FindAt(index - targetNode.leftChild.Size, targetNode.rightChild);
        }
    }
}
