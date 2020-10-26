using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Library
{
    /// <summary>
    /// Class that represents non-generic Doubly Linked List data structure.
    /// </summary>
    public class DoublyLinkedList
    {
        /// <summary>
        /// Class that models an element of the doubly linked list (Node).
        /// The class contains three attributes: value, which represents the value of the element, prev(ious), which represents the (pointer to the) previous element in the list,
        /// and next, which represents the (pointer to the) next element in the list.
        /// The class also contains a constructor for initializing an object of the class, which is used internaly inside
        /// the Doubly Linked List class.
        /// </summary>
        private class Node
        {
            internal object value;
            internal Node next;
            internal Node prev;

            public Node(object value, Node prev, Node next)
            {
                this.value = value;
                this.prev = prev;
                this.next = next;
            }
        }

        // The pointer to the first element in the list
        private Node head;
        // The counter of the number of elements in the list
        private int counter = 0;

        /// <summary>
        /// Method that adds a new element at the <b>beginning</b> of the list, with specified value. 
        /// Time complexity: O(1).
        /// </summary>
        /// <param name="value">Value that the new element will be initialized with.</param>
        public void Push(object value)
        {
            // Initialize a new element with the specified value and pointer to the previously first element in the list
            head = new Node(value, null, head);
            // Increase the number of elements in the list by 1
            counter++;
        }

        /// <summary>
        /// Method that deletes all the elements in the list. Time complexity: O(1).
        /// </summary>
        /// <returns>True if the list is successfully cleared, or false if the list was already empty.</returns>
        public bool Clear()
        {
            // Return false if the list is empty
            if (counter == 0)
            {
                return false;
            }

            // Set the pointer of the head to the null, and the counter to 0 (the garbage collector in C# common language runtime (CLR)
            // will take care of the rest of the elements left in the memory)
            head = null;
            counter = 0;
            return true;
        }

        /// <summary>
        /// Method for checking if an element with the specified value is within the list. Time complexity: O(n).
        /// </summary>
        /// <param name="value">Value of the element it should be searched for.</param>
        /// <returns>True if the element with the specified value is in the list, or false if it does not.</returns>
        public bool Contains(object value)
        {
            // Initialize the temporary Node object used for iterating through the list
            Node temp = head;

            // Iterate through the list
            while (temp != null)
            {
                // Return true if the value of the current element is the same as the specified value
                if (Equals(temp.value, value))
                {
                    return true;
                }
                // Go to the next element in the list
                temp = temp.next;
            }

            // Return false if the element with the specified value is not found
            return false;
        }

        /// <summary>
        /// Method that returns the index of the element with the specified value, if the element is present in the list.
        /// Time complexity: O(n).
        /// </summary>
        /// <param name="value">Value of the element that is to be searched for.</param>
        /// <returns>Index of the element with the specified value, if the element is present in the list, otherwise -1.</returns>
        public int GetIndex(object value)
        {
            // Initialize the temporary Node object used for iterating through the list
            Node temp = head;

            // Iterate through the list
            for (int i = 0; i < counter; i++, temp = temp.next)
            {
                // Return the number of the iteration (current index) if the specified value is equal to the value of the current element
                if (Equals(temp.value, value))
                {
                    return i;
                }
            }

            // If the element is not in the list, return -1
            return -1;
        }

        /// <summary>
        /// Prints the values of all the elements from the list in the console. Time complexity: O(n).
        /// </summary>
        public void Print()
        {
            // // Initialize the temporary Node object used for iterating through the list
            Node temp = head;

            // Iterate through the list
            while (temp != null)
            {
                // Print the value of the current element
                Console.Write($"{temp.value} ");
                // Go to the next element
                temp = temp.next;
            }
        }

        /// <summary>
        /// Getter for the number of elements in the list.
        /// </summary>
        public int length
        {
            get
            {
                return counter;
            }
        }

        /// <summary>
        /// Getter for the list element at the specified index.
        /// </summary>
        /// <param name="index">Index of the element that is to be searched for.</param>
        /// <returns>Value of the element in the specified index, or throws an IndexOutOfRangeException if the specified index was outside
        /// the bounds of the list.</returns>
        public object this[int index]
        {
            get
            {
                // Throw an exception if the specified index is greater or equal to the number of elements in the list, or lesser than 0
                if (index >= counter || index < 0)
                {
                    throw new IndexOutOfRangeException("Error! Specified index was outside the bounds of the list!");
                }

                // Initialize temporary variables used for finding the element and iterating through the list
                int i = 0;
                Node temp = head;

                // Iterate through the list to the specified index
                while (i != index)
                {
                    temp = temp.next;
                    i++;
                }

                // Return the value found at the specified index
                return temp.value;
            }
        }

        /*
        public void Append(object value)
        {
            
        }
        */

        /*
        public object Pop()
        {
            
        }
        */

        /// <summary>
        /// Method that deleted the element od the list that has the same value as the one that is specified.
        /// Time complexity: O(n).
        /// </summary>
        /// <param name="value">Value of the object that is to be deleted.</param>
        /// <returns></returns>
        public object Delete(object value)
        {
            // If list is empty, throw an exception
            if(Equals(head, null))
            {
                throw new InvalidOperationException("Error! Cannot delete from an empty list!");
            }

            // Declare a container variable for the value of the object
            object toBeDeleted;

            // If the element that should be deleted is the first element in the list
            if(Equals(head.value, value))
            {
                toBeDeleted = head.value;
                head = head.next;
                counter--;
                return toBeDeleted;
            }

            // Initialize a temporary element that will be used to iterate through the list
            Node temp = head;

            // Iterate through the list, searching for the element that is to be deleted
            while (temp.next != null)
            {
                // If the value of the current element is the same as the specified value
                if (Equals(temp.next.value, value))
                {
                    // Move the pointer
                    toBeDeleted = temp.value;
                    temp.next = temp.next.next;
                    temp.prev = temp;
                    // Decrease the number of elements
                    counter--;
                    // Return the deleted value
                    return toBeDeleted;
                }
                // Go to the next element
                temp = temp.next;
            }

            // If the specified element is not found
            return null;
        }

        /*
        public bool Reverse()
        {
            
        }
        */

        /*
        public bool Swap(int first, int second)
        {
            
        }
        */
    }
}
