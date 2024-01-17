using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems.Text
{
    public class SinglyLinkedList<TElement> : ICustomList<TElement> where TElement : struct
    {
        SinglyLinkedNode<TElement> Head;

        public void Add(TElement d)
        {
            if (this.Head == null)
            {
                this.Head = new SinglyLinkedNode<TElement>(d);
            }
            else
            {
                var last = GetLastNode();
                last.Next = new SinglyLinkedNode<TElement>(d);
            }
        }

        public void Reverse()
        {
            SinglyLinkedNode<TElement> iterator = this.Head;
            SinglyLinkedNode<TElement> prev = null;

            while (iterator != null)
            {
                var next = iterator.Next;
                iterator.Next = prev;
                prev = iterator;
                iterator = next;
            }

            this.Head = prev;
        }

        public IEnumerable<TElement> Where(Func<TElement, bool> comparator)
        {
            foreach (var n in Traverse())
            {
                if (comparator(n.Data))
                    yield return n.Data;
            }
        }

        public IEnumerable<TElement> Enumerate()
        {
            foreach (var n in Traverse())
            {
                yield return n.Data;
            }
        }

        IEnumerable<SinglyLinkedNode<TElement>> Traverse()
        {
            var iterator = this.Head;
            while (iterator != null)
            {
                yield return iterator;
                iterator = iterator.Next;
            }
        }

        SinglyLinkedNode<TElement> GetLastNode()
        {
            SinglyLinkedNode<TElement> iterator = null;
            foreach (var t in Traverse())
                iterator = t;

            return iterator;
        }
    }
}
