using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Library
{
    /// <summary>
    /// Class that represents the generic Binary Search Tree data structure, with methods for adding, deleting, searching, traversing etc.
    /// </summary>
    /// <typeparam name="T">Type of the variables that will be stored in the tree.</typeparam>
    public class BinarySearchTree<T>
    {
        /// <summary>
        /// Represents the elements of the Binary Tree. (Tree nodes)
        /// </summary>
        private class Node
        {
            // Left child
            internal Node lChild;
            // Right child
            internal Node rChild;
            // Value of the element
            internal T value;

            /// <summary>
            /// Constructor for the element of the Binary Search Tree.
            /// </summary>
            /// <param name="value">Value of the element.</param>
            public Node(T value)
            {
                this.value = value;
                lChild = null;
                rChild = null;
            }

            /// <summary>
            /// Constructor for the element of the Binary Search Tree.
            /// </summary>
            /// <param name="value">Value of the element.</param>
            /// <param name="lc">Left child of this Node.</param>
            /// <param name="rc">Right child for this Node.</param>
            public Node(T value, Node lc, Node rc)
            {
                this.value = value;
                lChild = lc;
                rChild = rc;
            }
        }

        // Pointer to the root element of the BST
        private Node root;

        /// <summary>
        /// BST constructor, initializes the Binary Search Tree.
        /// </summary>
        public BinarySearchTree()
        {
            root = null;
        }

        /// <summary>
        /// BST constructor, initializes the Binary Search Tree with the elements passed as a parameter, and creates the BST structure.
        /// </summary>
        /// <param name="arr">Elements of the BST.</param>
        public BinarySearchTree(T[] arr)
        {
            root = CreateBinaryTree(arr, 0, arr.Length - 1);
        }


    }
}
