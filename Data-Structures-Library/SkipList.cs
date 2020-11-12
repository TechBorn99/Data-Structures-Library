using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Data_Structures_Library
{
    /// <summary>
    /// A method that represents a probabilistic data structure: Skip List, with better search time than the other lists in this library.
    /// </summary>
    public class SkipList
    {
        /// <summary>
        /// Class that models the elements of the Skip List. It contains two static attributes representing positive and negative infinity,
        /// pointers to their next, previous element, and also element above and below them, attribute value that stores the value of the Node, 
        /// attribute key for accessing the values of the element and two constructors.
        /// </summary>
        private class Node
        {
            // Positive infinity
            internal static string pInf = "+oo";
            // Negative infinity
            internal static string nInf = "-oo";

            // Pointers to the element above, below, next and previous of the current element
            internal Node next, prev, above, below;
            // Used for accessing the element
            internal string key;
            // Stores the value that the Node holds
            internal object value;

            /// <summary>
            /// Constructor for Node element, with two parameters.
            /// </summary>
            /// <param name="key">Key that the element will be accessed through.</param>
            /// <param name="value">Value of the element.</param>
            public Node(string key, object value)
            {
                this.key = key;
                this.value = value;

                next = prev = above = below = null;
            }


            /// <summary>
            /// Constructor for Node element, with 6 parameters.
            /// </summary>
            /// <param name="key">Key that the element will be accessed through.</param>
            /// <param name="value">Value of the element.</param>
            /// <param name="next">Pointer to the next element in the list.</param>
            /// <param name="prev">Pointer to the previous element in the list.</param>
            /// <param name="above">Pointer to the element that is above the current element.</param>
            /// <param name="below">Pointer to the element that is below the current element</param>
            public Node(string key, object value, Node next, Node prev, Node above, Node below)
            {
                this.key = key;
                this.value = value;
                this.next = next;
                this.prev = prev;
                this.above = above;
                this.below = below;
            }
        }

        // Pointer to the first element in the list
        private Node head;
        // Pointer to the last element in the list
        private Node tail;
        // Number of levels that the SkipList currently has
        private int lvl;
        // Number of elements currently in the list
        private int counter;
        // Used for randomly generating a number that will be used for determining the number of levels that the element will be put into
        RandomNumberGenerator random;

        /// <summary>
        /// Constructor for the Skip List that does basic preparations: sets the pointers, initializes the random machine and number of levels and elements in the list.
        /// </summary>
        public SkipList()
        {
            // Declare the start and end Node that will be used as head and tail
            Node startNode, endNode;
            // Initialzie the start and end Node
            startNode = new Node(Node.nInf, null);
            endNode = new Node(Node.pInf, null);
            // Connect start and end pointers of the list
            startNode.next = endNode;
            endNode.prev = startNode;
            // Set previously defined elements as head and tail of the Skip List
            head = startNode;
            tail = endNode;
            // Initialize the number of levels and elements in the list
            lvl = 0;
            counter = 0;
            // Initialize the RandomNumberGenerator, used for generating random numbers
            random = new RandomNumberGenerator(-294967296, 294967296);
        }

        /// <summary>
        /// Method that gets the value of the element with the specified key.
        /// </summary>
        /// <param name="key">Key of the element that is searched for.</param>
        /// <returns>Value of the element with the specified key, or null if the element with the specified key was not found in the list.</returns>
        public object Search(string key)
        {
            Node foundNode;
            foundNode = Get(key);
            return key.Equals(foundNode.key) ? foundNode.value : null;
        }

        /// <summary>
        /// Helper method that returns the element with the specified key from the bottom level list.
        /// </summary>
        /// <param name="key">Key for the element, used for searching for the element.</param>
        /// <returns>The element with the specified key, if it exists in the list, or the nearest smaller entry, if it doesn't exist.</returns>
        private Node Get(string key)
        {
            // Initialize a temporary element used for iterating through the list
            Node current = head;

            // Iterate throught the list, until the bottom level is reached
            while(true)
            {
                // While not at the end of the list, or not at the searched element, iterate through the next top layer
                while((Equals(current.next.key, Node.pInf)) && (current.next.key.CompareTo(key) <= 0))
                {
                    // Go to the next element at the same level
                    current = current.next;
                }

                // Check if there are more levels below the current element
                if(current.below != null)
                {
                    // If there are, go to the level of the list below
                    current = current.below;
                }
                // If the lowest level is reached
                else
                {
                    // Stop iterating, the closest or the searched element is found
                    break;
                }
            }
            // Return the found element
            return current;
        }

        /*
        public object Insert()
        {

        }
        */
        /// <summary>
        /// Helper method used only if the need to balance out the SkipList has occured.
        /// </summary>
        /// <param name="key">Key of the new element.</param>
        /// <param name="value">Value of the new element.</param>
        /// <param name="next">Pointer to the element after which the new element should be added.</param>
        /// <param name="above">Pointer to the element above which the new element should be added.</param>
        private void InsertNextAbove(string key, object value, Node after, Node above)
        {
            // Initialize the new element
            Node newNode = new Node(key, value, after.next, after, above.above, above);
            // Set the pointers for the element to be set to the right position
            after.next.prev = newNode;
            after.next = newNode;
            above.above = newNode;
        }
        /*
        private void AddLayer()
        {

        }

        public object Remove(string key)
        {

        }
        */
        /// <summary>
        /// Gets the number of elements at the bottom list level.
        /// </summary>
        public int Length
        {
            get
            {
                return counter;
            }
        }

        /// <summary>
        /// Gets the number of elements in the skip list.
        /// </summary>
        public int Height
        {
            get
            {
                return lvl;
            }
        }
        /*

        public void PrintVertical()
        {

        }


        private string GetOneColumn(Node toBePrinted)
        {

        }

        public void PrintHorizontal()
        {

        }

        private string GetOneRow(Node rowStart, int level)
        {

        }

        */
    }
}
