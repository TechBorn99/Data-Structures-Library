using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Library
{
    public class BinarySearchTree<T>
    {
        private class Node
        {
            internal Node lChild;
            internal Node rChild;
            internal T value;

            public Node(T value)
            {
                this.value = value;
                lChild = null;
                rChild = null;
            }

            public Node(T value, Node lc, Node rc)
            {
                this.value = value;
                lChild = lc;
                rChild = rc;
            }
        }

        private Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        public BinarySearchTree(T[] arr)
        {
            root = CreateBinaryTree(arr, 0, arr.Length - 1);
        }
    }
}
