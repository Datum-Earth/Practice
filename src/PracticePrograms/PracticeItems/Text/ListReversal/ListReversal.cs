using PracticePrograms.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems.Text
{
    public class ListReversal : IPracticeProgram
    {
        public void Execute(string[] args)
        {
            var slist = new SinglyLinkedList<int>();
            slist.Add(0);
            slist.Add(1);
            slist.Add(2);
            slist.Add(3);
            slist.Add(4);

            var dList = new DoublyLinkedList<int>();
            dList.Add(0);
            dList.Add(1);
            dList.Add(2);
            dList.Add(3);
            dList.Add(4);

            //TraceList(list);
            //ReverseSinglyLinkedList<int>(slist);
            //TraceList(list.Where(x => x == 2));

            TraceList(dList);
        }

        void ReverseSinglyLinkedList<TElement>(SinglyLinkedList<TElement> list) where TElement : struct
        {
            TraceList(list);
            list.Reverse();
            TraceList(list);
        }

        void TraceList<TElement>(IEnumerable<TElement> enumerable) where TElement : struct
        {
            foreach (var t in enumerable)
            {
                Trace.WriteLine(t);
            }
        }

        void TraceList<TElement>(ICustomList<TElement> list) where TElement : struct
        {
            //Trace.WriteLine($"{String.Join("\r", list.Enumerate())}\r");

            foreach (var t in list.Enumerate())
            {
                Trace.WriteLine(t);
            }

            Trace.WriteLine(String.Empty);
        }
    }
}
