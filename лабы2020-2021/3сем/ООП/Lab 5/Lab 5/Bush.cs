using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_5
{
    class Bush : Plant
    {
        int width;

        public int Width
        {
            get { return width; }
            set{ width = value; }
        }
       
        public override string ToString()
        {
            return $"вид: {Vid}\nвысота: {Hidth}\nвозраст: {Age}\nвысота{Width}";
        }

        /*public override string GetInfo()
       {
           string str;

           str = $"вид: {Vid}\nвысота: {Hidth}\nвозраст: {Age}\nвысота{Width}";

           return str;
       }*/
    }
}
