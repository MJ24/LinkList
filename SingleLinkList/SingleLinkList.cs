using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkList
{
    public class SingleLinkList<T>
    {
        private Node<T> head;

        public Node<T> Head
        {
            get { return head; }
            set { head = value; }
        }

        public SingleLinkList()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public int GetLength()
        {
            int length = 0;
            Node<T> p = head;
            while (p != null)
            {
                length++;
                p = p.Next;
            }
            return length;
        }

        public void Clear()
        {
            head = null;
        }

        public void Append(T elem)
        {
            Node<T> node = new Node<T>(elem);
            if (head == null)
            {
                head = node;
            }
            else
            {
                Node<T> lastNode = head;
                //注意下面是lastNode.Next!=null而不是lastNode
                //否则head.Next是null这种情况下就会报错
                while (lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                }
                lastNode.Next = node;
            }
        }

        public T GetElem(int index)
        {
            T result = default(T);
            if (IsEmpty())
            {
                Console.WriteLine("链表为空！");
            }
            else
            {
                Node<T> p = head;
                int realIndex = 1;
                //这里要用p.Next!=null，用p的话当index超出length时realIndex == index
                while (p.Next != null && realIndex < index)
                {
                    p = p.Next;
                    realIndex++;
                }
                if (realIndex == index)
                {
                    result = p.Data;
                }
                //注意这里不能用判断index在1到GetLength()来做
                //因为GetLength又要遍历一遍list
                else
                {
                    Console.WriteLine("获取元素位置错误！");
                }
            }
            return result;
        }

        //在第index个元素之前插入元素，因此当只有3个元素时不允许index=4
        public void InsertElem(int index, T elem)
        {
            if (IsEmpty())
            {
                Console.WriteLine("链表为空！");
            }
            else if (index < 1)
            {
                Console.WriteLine("插入元素位置错误！");
            }
            else if (index == 1)
            {
                Node<T> node = new Node<T>(elem);
                node.Next = head;
                head = node;//插在第一个时记得改head指向
            }
            else
            {
                Node<T> afterIndexNode = head;
                Node<T> beforeIndexNode = new Node<T>();
                int realIndex = 1;
                while (afterIndexNode.Next != null && realIndex < index)
                {
                    beforeIndexNode = afterIndexNode;
                    afterIndexNode = afterIndexNode.Next;
                    realIndex++;
                }
                if (realIndex == index)
                {
                    Node<T> node = new Node<T>(elem);
                    beforeIndexNode.Next = node;
                    node.Next = afterIndexNode;
                }
                else
                {
                    Console.WriteLine("插入元素位置错误！");
                }
            }
        }

        public T DeleteElem(int index)
        {
            T result = default(T);
            if (IsEmpty())
            {
                Console.WriteLine("链表为空！");
            }
            else if (index < 1)
            {
                Console.WriteLine("删除元素位置错误！");
            }
            else if (index == 1)
            {
                result = head.Data;
                head = head.Next;
            }
            else
            {
                Node<T> afterIndexNode = head;
                Node<T> beforeIndexNode = new Node<T>();
                int realIndex = 1;
                while (afterIndexNode.Next != null && realIndex < index)
                {
                    beforeIndexNode = afterIndexNode;
                    afterIndexNode = afterIndexNode.Next;
                    realIndex++;
                }
                if (realIndex == index)
                {
                    result = afterIndexNode.Data;
                    beforeIndexNode.Next = afterIndexNode.Next;
                }
                else
                {
                    Console.WriteLine("删除元素位置错误！");
                }
            }
            return result;
        }

        public int LocateElem(T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("链表为空！");
                return -1;
            }
            int index = 1;
            Node<T> p = head;
            while (p != null && !p.Data.Equals(value))
            {
                p = p.Next;
                index++;
                if (p == null)
                {
                    Console.WriteLine("链表中不存在此元素！");
                    index = -1;
                }
            }
            return index;
        }

        //空链表、单节点链表也满足
        public void Reverse()
        {
            Node<T> p = head;
            Node<T> q = new Node<T>();
            Node<T> R = new Node<T>();
            while (p != null)
            {
                q = p;
                p = p.Next;
                q.Next = R.Next;
                R.Next = q;
            }
            head = R.Next;
            R = null;
        }

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("链表为空！");
            }
            else
            {
                Node<T> p = head;
                while (p != null)
                {
                    Console.WriteLine(p.Data);
                    p = p.Next;
                }
            }
        }
    }
}
