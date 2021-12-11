using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_8
{
    class Plant
    { 
        public virtual void rost()
        {

        }
        int hidth;
        string vid;
        DateTime age;

        public int Hidth
        {
            get { return hidth; }
            set { hidth = value; }
        }

        public string Vid
        {
            get
            {
                return vid;
            }
            set
            {
                vid = value;
            }
        }
        public DateTime Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public Plant()
        {
            hidth = 10;
            vid = "roza";
        }

        public override string ToString()
        {
            return $"вид: {Vid}\nвысота: {Hidth}\nвозраст: {Age}\n";
        }
        public virtual void zapah()
        {
            Console.WriteLine("я пахну");
        }
    }

}
