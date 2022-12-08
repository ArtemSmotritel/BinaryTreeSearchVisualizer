using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeSearchVisualizer.src.BinaryTree
{
    internal class TreeNode
    {
        private long value;
        private int size;
        public TreeNode? parent;
        public TreeNode? leftChild;
        public TreeNode? rightChild;

        public TreeNode(long value, TreeNode? parent)
        {
            this.value = value;
            size = 1;
            leftChild = rightChild = null;
            this.parent = parent;
        }

        public long Value { get { return value; } set { this.value = value; } }

        public int Size { get { return size; } set { this.size = value; } }

        public void IncreaseWeight() { size += 1; }

        public void DecreaseWeight() { size -= 1; }
    }
}
