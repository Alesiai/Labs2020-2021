using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_5
{
    sealed class Paper : Plant
    {
        string vidPaper;

        string color;

        public string Color
        {
            get => color;
            set {color = value;}
        }
        public string VidPaper
        {
            get { return vidPaper; }
            set { vidPaper = value; }
        }
        public Paper(string vidPaper)
        {
            VidPaper = vidPaper;
        }
        public Paper()
        {

        }
        public override string ToString()
        {
            return $"вид растения: {Vid}\nвид бумаги: {VidPaper}\nвысота: {Hidth}\nЦвет: {Color}\nвозраст растения: {Age}\n";
        }
        /*public override string GetInfo()
        {
            string str;
            str = $"вид растения: {Vid}\nвид бумаги: {VidPaper}\nвысота: {Hidth}\nЦвет: {Color}\nвозраст растения: {Age}\n";
            return str;
        }*/
    }
}
