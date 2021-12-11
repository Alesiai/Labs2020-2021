using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_5
{
    class Rose : Flower, interface1
    {
        public string Color2
        {
            get { return Color; }
            set { Color = value; }
        }


        string pole;
        public string Pole
        {
            get => pole;
            set { pole = value; }
        }
        public override string ToString()
        {
            return $"вид: {Vid}\nвысота: {Hidth}\nЦвет: {Color}\nвозраст: {Age}\n";
        }
        public override int GetHashCode() //возвращает высоту розы
        {            
            return Hidth;
        }
        public override bool Equals(object obj)
        {
            return true;
        }

        /*public override string GetInfo()
        {
            string str;

            str = $"вид: {Vid}\nвысота: {Hidth}\nЦвет: {Color}\nвозраст: {Age}\n";

            return str;
        }*/

        public override void zapah()
        {
            Console.WriteLine("я не пахну");
        }
    }
}
