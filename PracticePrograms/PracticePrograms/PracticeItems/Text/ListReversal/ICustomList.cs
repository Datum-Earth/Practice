using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems.Text
{
    interface ICustomList<TElement> where TElement : struct
    {
        void Add(TElement d);
        IEnumerable<TElement> Where(Func<TElement, bool> comparator);
        IEnumerable<TElement> Enumerate();
    }
}
