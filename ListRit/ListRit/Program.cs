using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListRit
{

    public class ListNode<T>
    {
        public readonly T Value;
        public readonly ListNode<T> Next;

        public ListNode(T value, ListNode<T> next)
        {
            Value = value;
            Next = next;
        }

 

        public void PrintElements()
        {
            ListNode<T> current = this;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
        public void ReplaceElement(ListNode<T> head, out ListNode<T> node, ListNode<T> replaceNode)
        {
            ListNode<T> current = head;
            while (current != null)
            {
                if (current.Next == this)
                {
                    break;
                }
                current = current.Next;
            }
            ListNode<T> tmp = replaceNode;
            replaceNode = new ListNode<T>(tmp.Value, this.Next);
            node = replaceNode;
        }
        public void LinkTwoLists(ListNode<T> firstHead, ListNode<T> secondHead)
        {
            ListNode<T> current = firstHead;
            while (current != null)
            {
                ListNode<T> tmp;
                if (current.Next != null)
                {
                    tmp = new ListNode<T>(current.Value, current.Next);
                }
                else
                {
                    tmp = new ListNode<T>(current.Value, secondHead);
                }

                current = current.Next;
            }
        }
    }

    public class Program
    {
        public static void Main()
        {

        }
    }
}
