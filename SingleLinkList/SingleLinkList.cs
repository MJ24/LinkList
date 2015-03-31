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

        public void InsertElem(int index, T elem)
        {
            Node<T> node = new Node<T>(elem);
            Node<T> p = head;
            int realIndex = 0;
            while (p.Next != null && realIndex < index)
            {
                p = p.Next;
                realIndex++;
            }
        }
    }
}
