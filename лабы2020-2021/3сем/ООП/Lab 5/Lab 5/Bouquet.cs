using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_5
{
    class Bouquet : Flower
    {
        int kol;
        Flower[] flowers;
        public int Kol 
        {
            get => kol; 
            set { kol = value; } 
        }
        public Bouquet(int kol, string vid)
        {
            this.flowers = new Flower[kol];
            for(int i = 0; i < kol; i++)
            { 
               flowers[i]  = new Flower();
            }
            Kol = kol;
        }

        public override string ToString()
        {
            string str = "";
            for(int i= 0; i<Kol; i++)
            {
                str += flowers[i].ToString();
            }
            return str;
        }

    }
}
