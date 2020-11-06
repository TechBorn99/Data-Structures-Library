using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Data_Structures_Library
{
    /// <summary>
    /// Class that represents the Circular Linked List Data Structure, implemented through the Singly Linked List
    /// </summary>
    class CircularLinkedList
    {
        /// <summary>
        /// Private class that represents the Node element of a Circular Linked List, implemented through the Singly Linked List
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

        // Pointer to the first element in the list
        private Node head;
        // Pointer to the last element in the list
        private Node tail;
        // Number of elements in the list
        private int counter = 0;

        /// <summary>
        /// Method that adds an element at the start of Circular Linked List. Time complexity: O(1).
        /// </summary>
        /// <param name="value">Value that the new element will be initialized with.</param>
        public void Push(object value)
        {
            // Initialize a new element
            Node newNode = new Node(value, head);
            // If list is empty
            if(head == null)
            {
                // Set the pointers for head and tail, and connect those two
                head = newNode;
                tail = newNode;
                tail.next = head;
            }
            // If list is not empty
            else
            {
                // Set the pointers for head and tail, and connect those two
                Node temp = head;
                newNode.next = temp;
                head = newNode;
                tail.next = head;
            }
            // Increase the number of elements in the list
            counter++;
        }

        /*
        /// <summary>
        /// Method that adds an element at the end of the Circular Linked List. Time complexity: O().
        /// </summary>
        /// <param name="value">Value that the new element will be initialized with.</param>
        public void Append(object value)
        {

        }
        */
        /// <summary>
        /// Method that checks if the element with the specified value is present in the list. Time complexity: O(n).
        /// </summary>
        /// <param name="value">Value of the element for which will be searched for in the list.</param>
        /// <returns>True if the element is present in the list, false if it isn't.</returns>
        public bool Contains(object value)
        {
            // Initialize an element for iterating through the list
            Node temp = head;
            // Iterate through the list, until head is again found
            while(temp.next != head)
            {
                // If value of the current element is the same as the specified value
                if(Equals(temp.value, value))
                {
                    return true;
                }
                // Go to the next element
                temp = temp.next;
            }
            // If element is not found
            return false;
        }
        /*
        /// <summary>
        /// Method that deletes the forst element in the list. Time complexity: O(1).
        /// </summary>
        /// <returns>Value of the element that is deleted.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown if an attempt to delete from an empty list is made.</exception>
        public object Pop()
        {

        }

        /// <summary>
        /// Method that deletes the element with the specified value from the list. Time complexity: O(n).
        /// </summary>
        /// <param name="value">Value of the element that is to be deleted.</param>
        /// <returns>Value of the element, if it was successfully deleted, false if the element was not found in the list.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown if an attempt to delete from an empty list is made.</exception>
        public object Delete(object value)
        {

        }
        */
        /// <summary>
        /// Method that deletes all the elements from the list.
        /// </summary>
        /// <returns>True if the deletion was successful, false if the list was already empty.</returns>
        public bool Clear()
        {
            // Return false if the list is empty
            if (counter == 0)
            {
                return false;
            }

            // Set the pointers of the head and tail to the null, and the counter to 0, to delete all the elements in the list
            head = null;
            tail = null;
            counter = 0;
            return true;
        }

        /// <summary>
        /// Method that prints out values of all elements in the list in the console.
        /// </summary>
        public void Print()
        {
            // Initialize the temporary Node object used for iterating through the list
            Node temp = head;
            
            // Iterate through the list
            while(temp != null)
            {
                // Print the value of the current element
                Console.Write($"{temp.value} ");
                // Go to the next element
                temp = temp.next;
            }
        }

        /// <summary>
        /// Getter for the number of elements in the list
        /// </summary>
        public int Length
        {
            get
            {
                return counter;
            }
        }
    }
}
