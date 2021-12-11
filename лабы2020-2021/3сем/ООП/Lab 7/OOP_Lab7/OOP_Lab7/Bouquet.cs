using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab7
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


    sealed partial class Bouquet : IController
    {
        public int MaxCount
        {
            get { return maxCount; }
            set { maxCount = value; }
        }

        public Bouquet()
        {
            this.byuerBudget = 10;
            this.maxCount = 20;
            flowers = new List<Flower>();
        }
        public Bouquet(float byuerBudget, int maxCount, params Flower[] flowers)
        {
            if (byuerBudget<=0)
            {
                throw new InvalidInputException("Недопустимый бюджет покупателя");
            }

            if (maxCount <= 0)
            {
                throw new InvalidInputException("Максимальное количество цветов в букете должно быть положительным числом");
            }

            this.byuerBudget = byuerBudget;
            this.maxCount = maxCount;
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
            if (flowers.Count != 0)
                for (int j = 0; j < flowers.Count; j++)
                    Console.WriteLine(flowers[j]);
            else
                throw new ZeroFlowersException();
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
                if (flowers[i].properties.color == color)
                    tempFlowers.Add(flowers[i]);

            return tempFlowers;
        }

        public void Add(Flower flower)
        {
            if (flowers.Count < maxCount)
            {
                flowers.Add(flower);
            }
            else
                throw new BouquetOverflowException(flowers.Count, maxCount);
        }

        public List<Flower> ByBouquet()
        {
            if (byuerBudget >= FullPrice())
                return flowers;
            else
                throw new ExpensiveException(byuerBudget, FullPrice());
        }

    }
}
