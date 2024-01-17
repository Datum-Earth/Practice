using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems.Text
{
    public class DoublyLinkedNode<TElement> where TElement : struct
    {
        public TElement Data;

        public DoublyLinkedNode<TElement> Previous;
        public DoublyLinkedNode<TElement> Next;

        public DoublyLinkedNode(TElement data)
        {
            this.Data = data;
        }
    }
}
