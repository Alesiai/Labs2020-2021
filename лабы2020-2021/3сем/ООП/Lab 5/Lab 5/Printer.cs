using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_5
{
    class Printer
    {
        public void iAmPrinting(interface1 someobj)
        {
            Console.WriteLine(someobj.GetType());
            Console.WriteLine(someobj.ToString());
        }
    }
}
