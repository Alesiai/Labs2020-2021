using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_5
{
    abstract class Plant 
    {
        public virtual void move()
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
            get { return vid; }
            set { vid = value; }
        }
        public DateTime Age
        {
            get{ return age;}
            set{ age = value;}
        } 
        public Plant()
        {
            hidth = 0;
        }

        public virtual string GetInfo()
        {
            string str;

            str = $"вид: {Vid}\nвысота: {Hidth}\nвозраст: {Age}\n";

            return str;
        }
        public virtual void zapah()
        {
            Console.WriteLine("я пахну");
        }
    }
       
} 
    
