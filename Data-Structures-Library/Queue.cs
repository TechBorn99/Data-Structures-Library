using System;

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

        
    }
}
