using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Library
{
    /// <summary>
    /// Class that models the Stack data structure, with FIFO (First In First Out) principle. This class contains methods for manipulating the stack.
    /// </summary>
    class Stack
    {
        /// <summary>
        /// Represents the Node (element) of the Stack, with attributes value and next (pointer to the next value in the stack), and a constructor.
        /// </summary>
        private class Node
        {
            // Attributes of the Node class
            internal object value;
            internal Node next;

            // Constructor for the Node class
            public Node(object value, Node next)
            {
                this.value = value;
                this.next = next;
            }
        }
    }
}
