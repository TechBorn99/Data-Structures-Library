using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace Data_Structures_Library
{
    /// <summary>
    /// Class that models the non-generic Stack data structure, with LIFO (Last In First Out) principle. This class contains methods for manipulating the stack.
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

        // Pointer to the last added element in the stack (top element)
        private Node head;
        // Number of elements in the stack
        private int counter = 0;
        // Elements in the stack, if the stack is implemented as an array
        object[] elements;

        /// <summary>
        /// Constructor for Stack that is implemented through Singly Linked List.
        /// </summary>
        public Stack()
        {
            head = null;
        }

        public Stack(int MAXSIZE)
        {
            elements = new object[MAXSIZE];
        }

        /*/// <summary>
        /// Method that adds an element at the top of the stack. Time complexity: O().
        /// </summary>
        /// <param name="value">Value that the new element will be initialized with.</param>
        public void Push(object value)
        {

        }*/

        /*
            * 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Pop()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Peek()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {

        }

        */
    }  
}
