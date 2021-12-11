using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_8
{
    interface Interface<T>
    {
        void Add(params T[] item);
        void RemoveEl(T item);
        void Print();
    }
}
