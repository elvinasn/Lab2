﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    /// <summary>
    /// linked list class to store triangles
    /// </summary>
    public sealed class TrianglesLinkedList : IEnumerable
    {
        /// <summary>
        /// Node class of linked list
        /// </summary>
        private sealed class Node
        {
            public Triangle Data { get; set; }
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
            public Node(Triangle value, Node link)
            {
                Data = value;
                Link = link;
            }
        }

        private Node head;
        private Node tail;
        private Node a;

        /// <summary>
        /// gets the cound of objects in linked list
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;
                Node temp = head;
                while(temp != null)
                {
                    count++;
                    temp = temp.Link;
                }
                return count;
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public TrianglesLinkedList()
        {
            head = null;
            tail = null;
        }

        /// <summary>
        /// adds given triangle to the end of linked lsit
        /// </summary>
        /// <param name="triangle">triangle to add</param>
        public void Add(Triangle triangle)
        {
            Node newNode = new Node(triangle, null);
            if (head != null)
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
        public Triangle Get() => a.Data;

        /// <summary>
        /// removes current triangle from linked list
        /// </summary>
        public void Remove()
        {
            bool isTail = false;
            if (a == head)
                head = a.Link;
            else
            {
                if (a == tail)
                    isTail = true;
                Node d1;
                for(d1 = head; d1!= null; d1 = d1.Link)
                {
                    if (d1.Link == a)
                        break;
                }
                d1.Link = a.Link;
                a.Link = null;
                if (isTail)
                    tail = d1;
            }
        }
        /// <summary>
        /// sets current triangle to given triangle
        /// </summary>
        /// <param name="tri">given triangle</param>
        public void Set(Triangle tri) => a.Data = tri;

        /// <summary>
        /// sorts triangles by given comparator
        /// </summary>
        /// <param name="comparator">given comparator</param>
        public void Sort(TriangleComparator comparator)
        {
            for(Node d1 = head; d1!= null; d1 = d1.Link)
            {
                Node minv = d1;
                for(Node d2 = d1.Link; d2!= null; d2 = d2.Link)
                {
                    if (comparator.Compare(minv.Data, d2.Data) > 0)
                        minv = d2;
                }
                Triangle tri = d1.Data;
                d1.Data = minv.Data;
                minv.Data = tri;
            }
        }

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