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
    }
}
