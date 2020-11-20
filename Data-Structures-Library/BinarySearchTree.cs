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

        /// <summary>
        /// Helper method that creates the Binary Search Tree.
        /// </summary>
        /// <param name="arr">Array of the elements that are added to the BST.</param>
        /// <param name="start">Start index of the specified array of elements.</param>
        /// <param name="end">End index of the specified array of elements.</param>
        /// <returns>Root of the BST created out of the specified array of elements.</returns>
        private Node CreateBinaryTree(T[] arr, int start, int end)
        {
            // Create the current Node
            Node current = null;
            // Check whether all elements are added
            if(start > end)
            {
                return null;
            }
            // Get the middle of the specified array
            int mid = (start + end) / 2;
            // Set the value of the current Node
            current = new Node(arr[mid]);
            // Create the left subtree
            current.lChild = CreateBinaryTree(arr, start, mid - 1);
            // Create the right subtree
            current.rChild = CreateBinaryTree(arr, mid + 1, end);
            // Return the current element (root of the subtree)
            return current;
        }
    }
}
