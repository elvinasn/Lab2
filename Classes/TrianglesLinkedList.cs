using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    public class TrianglesLinkedList
    {
        private sealed class Node
        {
            public Triangle Data { get; set; }
            public Node Link { get; set; }
            public Node() { }
            public Node(Triangle value, Node link)
            {
                Data = value;
                Link = link;
            }
        }

        private Node head;
        private Node tail;
        private Node a;

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

        public TrianglesLinkedList()
        {
            head = null;
            tail = null;
        }

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
        public void Begin() => a = head;
        public void Next() => a = a.Link;

        public bool Exist() => a != null;
        public Triangle Get() => a.Data;
        public void Set(Triangle tri) => a.Data = tri;

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

      

    }
}