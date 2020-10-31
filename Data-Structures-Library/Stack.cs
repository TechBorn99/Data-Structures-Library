using System;
using System.Linq;

namespace Data_Structures_Library
{
    /// <summary>
    /// Class that models the non-generic Stack data structure, with LIFO (Last In First Out) principle. 
    /// This class contains methods for manipulating the stack.
    /// It can be implemented as a Singly Linked List or an array.
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
        // Size (bound) of stack
        int MAXSIZE;

        /// <summary>
        /// Constructor for Stack that is implemented as a Singly Linked List.
        /// </summary>
        public Stack()
        {
            head = null;
        }

        /// <summary>
        /// Constructor for Stack that is implemented as an array.
        /// </summary>
        public Stack(int size)
        {
            MAXSIZE = size;
            elements = new object[MAXSIZE];
        }

        /// <summary>
        /// Method that adds an element at the top of the stack. Time complexity: O(1).
        /// This method can be used no matter if the stack is implemented as a list or an array.
        /// </summary>
        /// <param name="value">Value that the new element will be initialized with.</param>
        public void Push(object value)
        {
            // If stack is implemented through the singly linked list
            if(elements == null)
            {
                // Add a new element at the beginning
                head = new Node(value, head);
            }
            // If stack is implemented through the array
            else
            {
                // If stack is full, throw an exception
                if ((MAXSIZE - elements.Count(s => s == null)) == MAXSIZE)
                {
                    throw new InvalidOperationException("Error! Attempt to add to a full stack is made!");
                }
                // Initialize a new array, containing the same elements
                object[] temp = elements;
                // Move the data by one place forward
                Array.Copy(temp, 0, elements, 1, temp.Length - 1);
                // Add the new element
                elements[0] = value;
            }

            // Increase the number of elements
            counter++;
        }

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
