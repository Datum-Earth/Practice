using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems.Text
{
    public class DoublyLinkedList<TElement> : ICustomList<TElement> where TElement : struct
    {
        DoublyLinkedNode<TElement> Head;
        DoublyLinkedNode<TElement> Tail;

        public void Add(TElement d)
        {
            //if (this.Head == null)
            //{
            //    this.Head = new DoublyLinkedNode<TElement>(d);
            //    this.Head.Next = this.Tail;
            //    this.Tail = this.Head;
            //    this.Tail.Previous = this.Head;
                
            //} else
            //{
            //    var prev = this.Tail;

            //    this.Tail = new DoublyLinkedNode<TElement>(d);
            //    this.Tail.Previous = prev;
            //}

        }

        public IEnumerable<TElement> Enumerate()
        {
            foreach (var e in Traverse(TraversalDirection.Forwards))
            {
                yield return e.Data;
            }
        }

        public IEnumerable<TElement> Where(Func<TElement, bool> comparator)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DoublyLinkedNode<TElement>> Traverse(TraversalDirection direction)
        {
            if (direction == TraversalDirection.Forwards)
            {
                var enumerator = this.Head;
                while (enumerator != null)
                {
                    yield return enumerator;
                    enumerator = enumerator.Next;
                }
            } else {
                var enumerator = this.Tail;
                while (enumerator != null)
                {
                    yield return enumerator;
                    enumerator = enumerator.Previous;
                }
            }
        }

        enum TraversalDirection
        {
            Forwards,
            Backwards
        }
    }
}
