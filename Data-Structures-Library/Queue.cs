using System;
using System.Linq;

namespace Data_Structures_Library
{
    /// <summary>
    /// Class that represents a non-generic Queue, a FIFO (First In First Out) data structure, containing necessary methods to manipulate it. 
    /// Can be implemented as an array, or as a SinglyLinkedList.
    /// </summary>
    class Queue
    {
        /// <summary>
        /// Represents the Node (element) of the Queue, with attributes value and next (pointer to the next value in the queue), and a constructor.
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

        // Pointer to the last added element in the queue (top element)
        private Node head;
        // Number of elements in the queue
        private int counter = 0;
        // Elements in the queue, if the queue is implemented as an array
        object[] elements;
        // Size (bound) of queue
        int MAXSIZE;

        /// <summary>
        /// Constructor for Queue that is implemented as a Singly Linked List.
        /// </summary>
        public Queue() { }

        /// <summary>
        /// Constructor for Queue that is implemented as an array.
        /// </summary>
        public Queue(int size)
        {
            MAXSIZE = size;
            elements = new object[MAXSIZE];
        }

        /// <summary>
        /// Method that adds an element at the end of the queue. Time complexity: O(n).
        /// </summary>
        /// <param name="value">Value that the new element will be initialized with.</param>
        public void Enqueue(object value)
        {
            // If queue is implemented as SinglyLinkedList
            if(elements == null)
            {
                // Add a new element at the beginning
                head = new Node(value, head);
            }
            // If queue is implemented as an array
            else
            {
                // If queue is full, throw an exception
                if (counter == MAXSIZE)
                {
                    throw new InvalidOperationException("Error! Attempt to add to a full queue is made!");
                }
                // Move the data by one space forward in the array
                Array.Copy(elements, 0, elements, 1, elements.Length - 1);
                // Insert the new element
                elements[0] = value;
            }
            // Increase the number of elements in the queue
            counter++;
        }

        /*
        /// <summary>
        /// Method that deletes the first added element of the queue. Time complexity: O(1).
        /// </summary>
        /// <returns>Value of the object that is deleted, or throws an InvalidOperationException if an attempt to delete from an empty queue is made.</returns>
        public object Dequeue()
        {

        }

        /// <summary>
        /// Method that returns the value of the first added element of the queue. Time complexity: O(1).
        /// </summary>
        /// <returns>Value of the object that is at the beginning of the queue, or null if the queue is empty.</returns>
        public object Peek()
        {

        }
        */
        /// <summary>
        /// Method that shows if the queue is empty. Time complexity: O(1).
        /// </summary>
        /// <returns>True if the queue is empty, or false if it isn't.</returns>
        public bool IsEmpty()
        {
            return counter == 0;
        }
        /*
        /// <summary>
        /// Method that shows if the queue is full. Time complexity: O(1).
        /// </summary>
        /// <returns>True if the queue is full, or false if it isn't.</returns>
        public bool IsFull()
        {

        }

        /// <summary>
        /// Method that checks whether an element with the specified value exists in the queue.
        /// Time complexity: O(n).
        /// </summary>
        /// <param name="value">Value of the element that is searched for.</param>
        /// <returns>True if the element is in the queue, false if it doesn't.</returns>
        public bool Contains(object value)
        {

        }

        /// <summary>
        /// Method that prints out all the elements of the queue in the console. Time complexity: O(n).
        /// </summary>
        public void Print()
        {

        }
        */

        /// <summary>
        /// Getter for the number of elements in the queue.
        /// </summary>
        public int length
        {
            get
            {
                return counter;
            }
        }
        
        /// <summary>
        /// Method that deletes all the elements from the queue. Time complexity: O(1).
        /// </summary>
        /// <returns>False if the queue is already empty, true if the deleting was successful.</returns>
        public bool Clear()
        {
            // If queue is empty
            if (counter == 0) return false;

            // If queue is implemented as a SinglyLinkedList
            if(elements == null)
            {
                // Set the pointer to the first element to null
                head = null;
            }
            // If queue is implemented as an array
            else
            {
                // Clear the array
                Array.Clear(elements, 0, elements.Length);
            }

            // Set the number of elements to 0
            counter = 0;
            // Return true if the deleting was successful
            return true;
        }
    }
}
