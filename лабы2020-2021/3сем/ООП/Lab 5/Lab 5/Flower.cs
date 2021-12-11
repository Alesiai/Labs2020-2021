using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_5
{
    class Flower : Plant
    {
        string color;

        public string Color
        {
            get { return color;}
            set { color = value;}
        }
        /*public override string GetInfo()
        {
            string str;

            str = $"вид: {Vid}\nвысота: {Hidth}\nЦвет: {Color}\nвозраст: {Age}\n";

            return str;
        }*/
        public override string ToString()
        {
            return $"вид: {Vid}\nвысота: {Hidth}\nЦвет: {Color}\nвозраст: {Age}\n";
        }
    }
    
}
