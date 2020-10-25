﻿using System;

namespace Data_Structures_Library
{
    /// <summary>
    /// Class that represents non-generic Singly Linked List data structure.
    /// The class contains various methods for adding, deleting, swaping, reversing, printing elements etc.
    /// </summary>
    public class SinglyLinkedList
    {
        /// <summary>
        /// Class that models an element of the singly linked list (Node).
        /// The class contains two attributes: value, which represents the value of the element, and next, which represents the 
        /// (pointer to the) next element in the list.
        /// The class also contains a constructor for initializing an object of the class, which is used internaly inside
        /// the Singly Linked List class.
        /// </summary>
        private class Node
        {
            internal object value;
            internal Node next;

            public Node(object value, Node next)
            {
                this.value = value;
                this.next = next;
            }
        }

        // The pointer to the first element in the list
        private Node head;
        // The counter of the number of elements in the list
        private int counter = 0;

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
                while(i != index)
                {
                    temp = temp.next;
                    i++;
                }

                // Return the value found at the specified index
                return temp.value;
            }
        }

        /// <summary>
        /// Method that adds a new element at the <b>beginning</b> of the list, with specified value. 
        /// Time complexity: O(1).
        /// </summary>
        /// <param name="value">Value that the new element will be initialized with.</param>
        public void Push(object value)
        {
            // Initialize a new element with the specified value and pointer to the previously first element in the list
            head = new Node(value, head);
            // Increase the number of elements in the list by 1
            counter++;
        }

        /// <summary>
        /// Method that adds a new element at the <b>end</b> of the list, with specified value. 
        /// Time complexity: O(n).
        /// </summary>
        /// <param name="value">Value that the new element will be initialized with.</param>
        public void Append(object value)
        {
            // If the list is empty, add the new element at the beginning of the list
            if(counter == 0)
            {
                Push(value);
                return;
            }

            // Else, first initialize the new element
            Node newElement = new Node(value, null);
            // Initialize the temporary Node object used for iterating through the list
            Node temp = head;

            // Iterate to the last element
            while(temp.next != null)
            {
                temp = temp.next;
            }
            // Set the pointer of the last element to the new element
            temp.next = newElement;
            // Increase the number of the elements in the list
            counter++;
        }

        /// <summary>
        /// Method that deletes all the elements in the list. Time complexity: O(1).
        /// </summary>
        /// <returns>True if the list is successfully cleared, or false if the list was already empty.</returns>
        public bool Clear()
        {
            // Return false if the list is empty
            if(counter == 0)
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
            while(temp != null)
            {
                // Return true if the value of the current element is the same as the specified value
                if(Equals(temp.value, value))
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
            for(int i = 0; i < counter; i++, temp = temp.next)
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
        /// Method that deletes the first element in the list. Time complexity: O(1).
        /// </summary>
        /// <returns>The value of the deleted element, or throws an exception if an attempt to delete from an already empty list 
        /// is made.</returns>
        public object Pop()
        {
            // Throw an exception if the method is called when the list is already empty
            if (counter == 0)
            {
                throw new InvalidOperationException("Error! Trying to delete from an already empty list!");
            }

            // initialize a temporary container variable
            object toBeDeleted = head.value;

            // If there is only one element in the list
            if (counter == 1) head = null;
            // If there is more than one element in the list
            else head = head.next;

            // Decrease the number of elements in the list by one
            counter--;
            // Return the value of the deleted element
            return toBeDeleted;
        }

        /// <summary>
        /// Method that deletes the element of the list that is located at the specified index.
        /// Time complexity: O(n).
        /// </summary>
        /// <param name="index">Index at which the element that is to be deleted is located.</param>
        /// <returns>The value of the deleted element, or throws an IndexOutOfRangeException if the specified index 
        /// was greater than the number of the elements in the list.</returns>
        public object Delete(int index)
        {
            // If the value of the passed index is greater than the number of elements in the list, or lesser than 0, throw an exception
            if (index >= counter || index < 0)
            {
                throw new IndexOutOfRangeException("Error! Specified index was outside the bounds of the list!");
            }

            // Declare a temporary object that will store the value of the Node that is to be deleted
            object toBeDeleted_Value;

            // If the specified index was 0, Pop() method can be called to delete that element; the value of the deleted element
            // is then returned
            if (index == 0)
            {
                toBeDeleted_Value = Pop();
                return toBeDeleted_Value;
            }

            // Initialize temporary variables used for getting to the element at the specified index
            Node temp = head;
            int i = 0;

            // Iterate through the list to the specified index
            while (temp.next != null && i < index - 1)
            {
                temp = temp.next;
                i++;
            }

            // Set the value of the container variable to the value of the element that is to be deleted
            toBeDeleted_Value = temp.next.value;
            // Move the pointer (delete the element) - the garbage collector will delete the object from the memory
            temp.next = temp.next.next;
            // Decrease the number of elements in the list, and return the value of the deleted element
            counter--;
            return toBeDeleted_Value;
        }

        /// <summary>
        /// Method that reverses the position of all the elements in the list.
        /// </summary>
        /// <returns>True if the reversing of the list was successful, or false if it wasn't.</returns>
        public bool Reverse()
        {
            // If the list contains 0 or 1 element, it cannot be reversed, so return false
            if (counter == 0 || counter == 1) return false;

            // Initialize a new, temporary list
            SinglyLinkedList tempList = new SinglyLinkedList();

            // Empty the current list from the end, and add all the elements to the beginning of the temporary list
            while(length != 0)
            {
                tempList.Push(Delete(counter - 1));
            }
            // Empty the temporary list from the end, and add all it's elements to the beginning of the current list
            while(tempList.length != 0)
            {
                this.Push(tempList.Pop());
            }
            // Return true if the above is done (the list is reversed)
            return true;
        }

        /// <summary>
        /// Method that swaps the values of the elements at the specified indexes.
        /// </summary>
        /// <param name="first">Index of the first element that is to be swapped.</param>
        /// <param name="second">Index of the second element that is to be swapped.</param>
        /// <returns>True if the swap was successful, throws an IndexOutOfRangeException if one of the parameteres is outside the
        /// bounds of the list.</returns>
        public bool Swap(int first, int second)
        {
            // If one of the specified indexes is greater than the number of elements, or lesser than 0, throw an exception
            if(first >= counter || second >= counter || first < 0 || second < 0)
            {
                throw new IndexOutOfRangeException("Error! One of the specified indexes was outside the bounds of the list!");
            }

            // Initialize the elements that are about to be swapped
            Node firstElem = head;
            Node secondElem = head;

            // Find the first element
            while(first != 0)
            {
                firstElem = firstElem.next;
                first--;
            }
            // Find the second element
            while(second != 0)
            {
                secondElem = secondElem.next;
                second--;
            }

            // Swap the values of the elements
            object temp = firstElem.value;
            firstElem.value = secondElem.value;
            secondElem.value = temp;

            // Return true if the values of the elements are swapped
            return true;
        }

        /// <summary>
        /// Prints the values of all the elements from the list in the console. Time complexity: O(n).
        /// </summary>
        public void Print()
        {
            // // Initialize the temporary Node object used for iterating through the list
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
        /// Getter for the number of elements in the list.
        /// </summary>
        public int length
        {
            get
            {
                return counter;
            }
        }
    }
}
