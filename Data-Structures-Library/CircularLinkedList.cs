using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Data_Structures_Library
{
    class CircularLinkedList
    {
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

        private Node head;
        private Node tail;
        private int counter = 0;

        /*

        public void Push(object value)
        {

        }

        public void Append(object value)
        {

        }

        public bool Contains(object value)
        {

        }

        public object Pop()
        {

        }

        public object Delete(object value)
        {

        }

        public bool Clear()
        {

        }

        public void Print()
        {

        }

        */
    }
}
