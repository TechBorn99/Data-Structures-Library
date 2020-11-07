using System;

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

        /// <summary>
        /// Method that adds an element at the end of the Circular Linked List. Time complexity: O().
        /// </summary>
        /// <param name="value">Value that the new element will be initialized with.</param>
        public void Append(object value)
        {
            // Check if the list is empty
            if (head == null) Push(value);
            else
            {
                // Initialize a new element
                Node newNode = new Node(value, head);
                // Initialize a new element for iterating to the last element and
                // iterate to the end of the list
                Node current = head;
                do
                {
                    current = current.next;
                } while (current.next != head);
                // Set the pointers and increase the number of elements in the lsit
                current.next = newNode;
                tail = newNode;
                counter++;
            }
        }

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
        
        /// <summary>
        /// Method that deletes the forst element in the list. Time complexity: O(1).
        /// </summary>
        /// <returns>Value of the element that is deleted.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown if an attempt to delete from an empty list is made.</exception>
        public object Pop()
        {
            // Check if the list is empty
            if(counter == 0)
            {
                throw new InvalidOperationException("Error! Attempt to delete from an empty list!");
            }

            // Store the value of the element that will be deleted
            object toBeDeleted = head.value;

            // Check if there is only one element in the list
            if(counter == 1)
            {
                // Remove the pointers (set them to null)
                head = tail = null;
            }
            else
            {
                // Move the pointer
                head = head.next;
                tail.next = head;
            }
            // Decrease the number of elements in the list
            counter--;
            // Return the deleted value
            return toBeDeleted;
        }

        /// <summary>
        /// Method that deletes the element with the specified value from the list. Time complexity: O(n).
        /// </summary>
        /// <param name="value">Value of the element that is to be deleted.</param>
        /// <returns>True if the deleting was successful, else false.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown if an attempt to delete from an empty list is made.</exception>
        public bool Delete(object value)
        {
            // Check if the list is empty
            if(counter == 0)
            {
                throw new InvalidOperationException("Error! An attempt to delete from an empty list is made!");
            }

            // Check if the first element in the list is the element that needs to be deleted
            if(Equals(head.value, value))
            {
                Pop();
                return true;
            }

            // Initialize a new temporary variable for iterating through the list
            Node temp = head;

            //Iterate through the list, until the specified value is found, or the last element is reached
            while(temp.next != head)
            {
                // If the element is found
                if(Equals(temp.next.value, value))
                {
                    // Move the pointers
                    temp.next = temp.next.next;
                    // Decrease the number of elements
                    counter--;
                    return true;
                }
                // Go to the next element
                temp = temp.next;
            }

            // If the element was not found
            return false;
        }

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
        /// <exception cref="System.InvalidOperationException">Thrown if an attempt to read data from an empty list is made.</exception>
        public void Print()
        {
            // If list is empty
            if(counter == 0)
            {
                throw new InvalidOperationException("Error! Cannot read data from an empty list!");
            }

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
