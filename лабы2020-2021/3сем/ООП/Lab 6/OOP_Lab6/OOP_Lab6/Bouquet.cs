using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab6
{
    public enum EsortKeys
    {
        byColor,
        byPetals,
        byStemLength,
        byPrice
    }

    public interface IController
    {
        void Print();
        float FullPrice();
        List<Flower> SortingByColor(Ecolor color);
    }


    sealed partial class Bouquet: IController
    {
        public Bouquet()
        {
            flowers = new List<Flower>();
        }
        public Bouquet(params Flower[] flowers)
        {
            this.flowers = new List<Flower>();
            for (int i = 0; i < flowers.Length; i++)
                this.flowers.Add(flowers[i]);
        }
        public List<Flower> Flowers
        {
            get { return this.flowers; }
            set { this.flowers = value; }
        }
        public void Print()
        {
            for (int j = 0; j < flowers.Count; j++)
            {
                Console.WriteLine(flowers[j]);
            }
        }

        public void Sorted_Print()
        {
            Flower[] tempFlowers = Flowers.ToArray();
            Array.Sort(tempFlowers);
            Flowers = tempFlowers.ToList();
            Print();
        }

        public float FullPrice()
        {
            float tempPrice = 0;
            for (int i = 0; i < flowers.Count; i++)
                tempPrice += flowers[i].properties.price;

            return tempPrice;
        }

        public List<Flower> SortingByColor(Ecolor color)
        {
            List<Flower> tempFlowers = new List<Flower>();
            for (int i = 0; i < flowers.Count; i++)
            {
               
                if (flowers[i].properties.color == color)
                { tempFlowers.Add(flowers[i]);
                    Console.WriteLine(flowers[i]);
                }

            }
            return tempFlowers;
        }

    }
}
