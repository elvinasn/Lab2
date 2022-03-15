using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    public sealed class PointsLinkedList : IEnumerable
    {
        private sealed class Node
        {
            public Point Data { get; set; }
            public Node Link { get; set; }
            public Node() { }
            public Node(Point value, Node link)
            {
                Data = value;
                Link = link;
            }
        }

        private Node head;
        private Node tail;
        private Node a;

        public PointsLinkedList()
        {
            head = null;
            tail = null;
            a = null;
        }
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

        public void Begin() => a = head;
        public void Next() => a = a.Link;

        public bool Exist() => a != null;
        public Point Get() => a.Data;

        public IEnumerator GetEnumerator()
        {
            for (Node d = head; d != null; d = d.Link)
            {
                yield return d.Data;
            }
        }
    }
}