using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems.Text
{
    class SinglyLinkedNode<TElement> where TElement : struct
    {
        public TElement Data { get; set; }
        public SinglyLinkedNode<TElement> Next { get; set; }

        public SinglyLinkedNode(TElement data)
        {
            this.Data = data;
        }
    }
}
