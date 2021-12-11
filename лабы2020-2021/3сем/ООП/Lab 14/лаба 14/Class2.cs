using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_14
{
    [Serializable]
    abstract public class Plant
    {
        public virtual void hidt()
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
            get  { return vid;}
            set  { vid = value; }
        }
        public DateTime Age
        {
            get  { return age; }
            set  { age = value; }
        }
        public Plant()
        {  hidth = 0; }

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
    
    [Serializable]
    public class Flower : Plant
    {
        string color;
        public Flower()
        {

        }
        public Flower(DateTime Age)
        {
            this.Age = Age;
        }
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public override string GetInfo()
        {
            string str;

            str = $"вид: {Vid}\nвысота: {Hidth}\nЦвет: {Color}\nвозраст: {Age}\n";

            return str;
        }
        public override string ToString()
        {
            return GetInfo();
        }
    }
    
    [Serializable]
    class Flow : Flower
    {
        public string pole;
        public Flow()
        {

        }
    }
}
