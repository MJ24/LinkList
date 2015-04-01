using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkList
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleLinkList<int> list = new SingleLinkList<int>();
            list.Append(1);
            list.Append(2);
            list.Reverse();
            //list.Append(2);
            list.Print();
            //Console.WriteLine(list.LocateElem(3));
            //list.InsertElem(1, 2342);
            //list.Append(1);
            //list.InsertElem(0, 2342);
            //list.Print();
            //list.InsertElem(1, 2);
            //list.Print();
            //list.InsertElem(2, 9);
            //list.Print();
            //list.InsertElem(77, 555);
            //list.Print();
            Console.ReadLine();
        }
    }
}
