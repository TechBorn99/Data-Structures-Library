using System;

namespace Data_Structures_Library
{
    /// <summary>
    /// Implementation of Binary (Min/Max) Heap Data Structure.
    /// </summary>
    class Heap
    {
        // Number of elements in the Heap
        private int counter;
        // Elements of the Heap
        private object[] elements;
        // Boolean used for checking if the current Heap is Min or Max Heap
        private bool isMinHeap;
        // Variable used for setting the capacity of the Heap, if it is not provided
        private const int CAPACITY = 32;

        /// <summary>
        /// Constructor for the Heap, using only one argument.
        /// </summary>
        /// <param name="isMin">Boolean determining whether Heap is Min or Max Heap.</param>
        public Heap(bool isMin = true)
        {
            elements = new object[CAPACITY];
            isMinHeap = isMin;
            counter = 0;
        }

        /// <summary>
        /// Constructor for the Heap, using two arguments.
        /// </summary>
        /// <param name="array">Array of object values, used to prefill the Heap.</param>
        /// <param name="isMin">Boolean determining whether Heap is Min or Max Heap.</param>
        public Heap(object[] array, bool isMin = true)
        {
            elements = new object[array.Length];
            Array.Copy(array, elements, array.Length);
            isMinHeap = isMin;
            counter = array.Length;

            //BuildHeap();
        }

        /// <summary>
        /// Helper method used for constructing the Heap Data Structure when the constructor is called.
        /// </summary>
        private void BuildHeap()
        {
            for(int i = counter / 2; i >= 0; i++)
            {
                Heapify(i);
            }
        }
        
        /*
        private void Heapify(int parentIndex)
        {
            // Initialize the index of the child element
            int childIndex = -1;
            // Initialize the indices of left and right child element with the two formulas
            int leftChild = 2 * parentIndex + 1;
            int rightChild = leftChild + 1;


        }

        */
        /// <summary>
        /// Getter for the number of elements in the heap.
        /// </summary>
        public int Length
        {
            get
            {
                return counter;
            }
        }

        /// <summary>
        /// Method that prints out the values of all the elements in the Heap in the console.
        /// </summary>
        public void Print()
        {
            // Iterate through the array of elements and print out each value
            foreach(object element in elements)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
