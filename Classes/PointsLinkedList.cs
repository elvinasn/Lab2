using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    public sealed class PointsLinkedList
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
        private Node b;
        private Node c;

        public PointsLinkedList()
        {
            head = null;
            tail = null;
            a = null;
            b = null;
            c = null;
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

        public void BeginInner(Point p)
        {
            for (Node d = head; d != null; d = d.Link)
            {
                if (d.Data.Equals(p))
                {
                    b = d.Link;
                    return;
                }

            }
        }
        public void NextInner() => b = b.Link;
        public bool ExistInner() => b != null;

        public Point GetInner() => b.Data;
        public void BeginInnerInner(Point p)
        {
            for (Node d = head; d != null; d = d.Link)
            {
                if (d.Data.Equals(p))
                {
                    c = d.Link;
                    return;
                }

            }
        }
        public void NextInnerInner() => c = c.Link;
        public bool ExistInnerInner() => c != null;
        public Point GetInnerInner() => c.Data;
    }
}