using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    /// <summary>
    /// linked list class to store points
    /// </summary>
    public sealed class PointsLinkedList : IEnumerable
    {
        /// <summary>
        /// Node class of linked list
        /// </summary>
        private sealed class Node
        {
            public Point Data { get; set; }
            public Node Link { get; set; }

            /// <summary>
            /// constructor without parameters
            /// </summary>
            public Node() { }

            /// <summary>
            /// constructor with parameters
            /// </summary>
            /// <param name="value">given value(data)</param>
            /// <param name="link">link to other Node</param>
            public Node(Point value, Node link)
            {
                Data = value;
                Link = link;
            }
        }

        private Node head;
        private Node tail;
        private Node a;

        /// <summary>
        /// constructor
        /// </summary>
        public PointsLinkedList()
        {
            head = null;
            tail = null;
            a = null;
        }
        /// <summary>
        /// returns the count of objects in linked list
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;
                Node temp = head;
                while (temp != null)
                {
                    count++;
                    temp = temp.Link;
                }
                return count;
            }
        }
        /// <summary>
        /// adds point to the end of linked list
        /// </summary>
        /// <param name="point">given point to add</param>

        public void Add(Point point)
        {
            Node newNode = new Node(point, null);
            if(head!= null)
            {
                tail.Link = newNode;
                tail = newNode;

            }
            else
            {
                head = newNode;
                tail = newNode;
            }
        }

        /// <summary>
        /// begins the for cycle in the outside of class
        /// </summary>
        public void Begin() => a = head;

        /// <summary>
        /// moves to the next objec in for cycle in the outside of class
        /// </summary>
        public void Next() => a = a.Link;

        /// <summary>
        /// checks if it is not the end of the list in for cycle in the outside of class
        /// </summary>
        /// <returns></returns>
        public bool Exist() => a != null;
        /// <summary>
        /// gets current element in for cycle in the outside of class
        /// </summary>
        /// <returns></returns>
        public Point Get() => a.Data;

        /// <summary>
        /// implements foreach cycle in linked list
        /// </summary>
        /// <returns> enumerator</returns>
        public IEnumerator GetEnumerator()
        {
            for (Node d = head; d != null; d = d.Link)
            {
                yield return d.Data;
            }
        }
    }
}