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

        /*
        public object Search(string key)
        {

        }


        private Node Get(string key)
        {

        }


        public object Insert()
        {

        }

        private void InsertNextAbove()
        {

        }

        private void AddLayer()
        {

        }

        public object Remove(string key)
        {

        }

        public int Length
        {

        }

        public int Height
        {

        }

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
