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
        public Stack() { }

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
                // Move the data by one space forward in the array
                Array.Copy(elements, 0, elements, 1, elements.Length - 1);
                // Insert the new element
                elements[0] = value;
            }

            // Increase the number of elements
            counter++;
        }
        
        /// <summary>
        /// Method that deletes the top element of the stack. Time complexity: O(1).
        /// </summary>
        /// <returns>Value of the object that is deleted, or throws an InvalidOperationException if an attempt to delete from an empty stack is made.</returns>
        public object Pop()
        {
            // If the stack is empty, throw an exception
            if(counter == 0)
            {
                throw new InvalidOperationException("Error! An attempt to delete from an empty stack is made!");
            }

            // Declare a temporary container variable
            object toBeDeleted;

            // If stack is implemented as a list
            if (elements == null)
            {
                // Initialize with the value of the element that is to be deleted
                toBeDeleted = head.value;
                // Move the head pointer to the next element (if there are more elements in the Stack), or set it to null, if there is only one
                // element in the Stack
                head = counter == 1 ? null : head.next;
            }
            // If stack is implemented as an array
            else
            {
                // Initialize with the value of the element that is to be deleted
                toBeDeleted = elements[0];
                // Delete the element from an array (stack)
                Array.Copy(elements, 1, elements, 0, elements.Length - 1);
            }

            // Decrease the number of elements in the list by one
            counter--;
            // Return the value of the deleted element
            return toBeDeleted;
        }

        /// <summary>
        /// Method that returns the value of the top (last added) element of the stack. Time complexity: O(1).
        /// </summary>
        /// <returns>Value of the object that is at the top of the stack, or null if the stack is empty.</returns>
        public object Peek()
        {
            // If the stack is empty
            if (counter == 0) return null;
            // Return the value of the object at the top of the stack
            return elements == null ? head.value : elements[0];
        }

        /// <summary>
        /// Method that shows if the stack is empty. Time complexity: O(1).
        /// </summary>
        /// <returns>True if the stack is empty, or false if it isn't.</returns>
        public bool IsEmpty()
        {
            return counter == 0;
        }

        /// <summary>
        /// Method that shows if the stack is full. Time complexity: O(1).
        /// </summary>
        /// <returns>True if the stack is full, or false if it isn't.</returns>
        public bool IsFull()
        {
            // If the stack is implemented as a SinglyLinkedList, it cannot be  filled,
            // but return true if the stack that is implemented as an array is full
            return elements == null ? false : counter == MAXSIZE;
        }

        /// <summary>
        /// Method that checks whether an element with the specified value exists in the Stack.
        /// Time complexity: O(n).
        /// </summary>
        /// <param name="value">Value of the element that is searched for.</param>
        /// <returns>True if the element is in the Stack, false if it doesn't.</returns>
        public bool Contains(object value)
        {
            // If stack is empty return false
            if (counter == 0) return false;
            // If stack is implemented as a list
            if (elements == null)
            {
                // Initialize a new element for iterating through the Stack
                Node temp = head;
                // Iterate through the stack
                while(temp.next != null)
                {
                    // If the element with the specified valeu is found, return true
                    if (Equals(temp.value, value)) return true;
                    // Go to the next element
                    temp = temp.next;
                }
            }
            // If stack is implemented as an array
            else
            {
                if (elements.Contains(value)) return true;
            }
            // Return false if the element with the specified value is not found
            return false;
        }
    }  
}
