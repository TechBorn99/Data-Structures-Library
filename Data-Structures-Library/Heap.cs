using System;

namespace Data_Structures_Library
{
    
    class Heap
    {
        private int counter;
        private object[] elements;
        private bool isMinHeap;
        private const int CAPACITY = 32;

        public Heap(bool isMin = true)
        {
            elements = new object[CAPACITY];
            isMinHeap = isMin;
            counter = 0;
        }

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
