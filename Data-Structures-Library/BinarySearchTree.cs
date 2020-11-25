using System;
using System.Collections.Generic;

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

            /// <summary>
            /// Method for printing the values of the elements in the BST in increasing order.
            /// </summary>
            internal void InOrderTraversal()
            {
                // Check if there are more left nodes present in the tree
                if(lChild != null)
                {
                    // Using recursion go through the whole left subtree
                    lChild.InOrderTraversal();
                }

                // Then print out the value of the current  node
                Console.Write(value + " ");

                // Then go through the whole right subtree
                if(rChild != null)
                {
                    rChild.InOrderTraversal();
                }
            }

            /// <summary>
            /// Method for printing out the value of the root node first, then the whole left subtree, and the right subtree at the end.
            /// </summary>
            internal void PreOrderTraversal()
            {
                // Print out the value of the current node first
                Console.Write(value + " ");
                // Then go through the whole left subtree, printing out all the values
                if (lChild != null)
                {
                    lChild.PreOrderTraversal();
                }
                // And finally, go through the whole right subtree, printing out all the values
                if (rChild != null)
                {
                    rChild.PreOrderTraversal();
                }
            }

            /// <summary>
            /// Method for printing out the values of the whole left subtree first, then the right subtree, and the root node at the end. 
            /// </summary>
            internal void PostOrderTraversal()
            {
                // Go through the whole left subtree and print values of all the nodes first
                if (lChild != null)
                {
                    lChild.InOrderTraversal();
                }
                // Then, go through the whole right subtree and print values of all the nodes there
                if (rChild != null)
                {
                    rChild.InOrderTraversal();
                }
                // And finally, print the value of the current Node
                Console.Write(value + " ");
            }
        }

        // Pointer to the root element of the BST
        private Node root;
        // Comparer object used to compare two objects of type T in the BST
        Comparer<T> comparer = Comparer<T>.Default;

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

        /// <summary>
        /// Method that returns the value of the root element of the BST.
        /// </summary>
        /// <returns>Value of the root in BST.</returns>
        public T FindRoot()
        {
            return root.value;
        }

        /// <summary>
        /// Method for checking whether the element with the specified value is present within the BST.
        /// </summary>
        /// <param name="value">Value of the element that is to be checked for.</param>
        /// <returns>True if the element with the specified value is present within the BST, false if it doesn't.</returns>
        public bool Contains(T value)
        {
            // Element that will be used for checking whether the element is present and iterating the BST
            Node current = root;
            // Iterate through the tree, until the leaf nodes are reached
            while(current != null)
            {
                // If the values of the current and the specified element is found, return true
                if(comparer.Compare(current.value, value) == 0)
                {
                    return true;
                }
                // If the value of the current element is greater than the specified value, go to the left child node
                if (comparer.Compare(current.value, value) > 0)
                {
                    current = current.lChild;
                }
                // If the value of the current element is less than the specified value, go to the right child node
                else
                {
                    current = current.rChild;
                }
            }
            // Return false if the element is not found
            return false;
        }

        /// <summary>
        /// Method for printing out the value of the root node first, then the whole left subtree, and the right subtree at the end.
        /// </summary>
        public void PrintPreOrder()
        {
            // Check if the tree is empty (root is null)
            if (root != null)
            {
                root.PreOrderTraversal();
            }
            else
            {
                throw new InvalidOperationException("Error! Cannot print values of an empty tree!");
            }
        }

        /// <summary>
        /// Method for printing out the values of the whole left subtree first, then the right subtree, and the root node at the end. 
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown if an attempt to print an empty tree is made.</exception>

        public void PrintPostOrder()
        {
            // Check if the tree is empty (root is null)
            if (root != null)
            {
                root.PostOrderTraversal();
            }
            else
            {
                throw new InvalidOperationException("Error! Cannot print values of an empty tree!");
            }
        }

        /// <summary>
        /// Method for printing the values of the elements in the BST in increasing order.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown if an attempt to print an empty tree is made.</exception>
        public void PrintInOrder()
        {
            // Check if the tree is empty (root is null)
            if(root != null)
            {
                root.InOrderTraversal();
            }
            else
            {
                throw new InvalidOperationException("Error! Cannot print values of an empty tree!");
            }
        }
    }
}
