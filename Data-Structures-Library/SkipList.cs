using System;
using System.Threading.Tasks;

namespace Data_Structures_Library
{
    public class SkipList
    {
        private class Node
        {
            internal static string pInf = "+oo";
            internal static string nInf = "-oo";

            internal Node next, prev, above, below;
            internal string key;
            internal object value;

            public Node(string key, object value)
            {
                this.key = key;
                this.value = value;

                next = prev = above = below = null;
            }

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

        private Node head;
        private Node tail;
        private int lvl;
        private int counter;
        RandomNumberGenerator random = new RandomNumberGenerator();
    }
}
