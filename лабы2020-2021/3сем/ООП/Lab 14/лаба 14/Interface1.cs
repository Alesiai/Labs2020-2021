using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_14
{
    interface InterfaceSerializer<T>
    {
        void Serializable(string path, T obj, string format);
        object DeSerializable(string path, T t, string format);
    }
}
