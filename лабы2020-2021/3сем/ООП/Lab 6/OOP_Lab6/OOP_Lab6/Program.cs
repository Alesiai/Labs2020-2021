//1)К предыдущей лабораторной работе(л.р. 5) добавьте к существующим
//классам перечисление и структуру.
//2) Один из классов сделайте partial и разместите его в разных файлах.
//3) Определить класс-Контейнер(указан в вариантах жирным шрифтом)
//для хранения разных типов объектов(в пределах иерархии) в виде
//списка или массива(использовать абстрактный тип данных). Классконтейнер должен содержать методы get и set для управления
//списком/массивом, методы для добавления и удаления объектов в
//список/массив, метод для вывода списка на консоль.
//4) Определить управляющий класс-Контроллер, который управляет
//объектом- Контейнером и реализовать в нем запросы по варианту.При
//необходимости используйте стандартные интерфейсы (IComparable,
//ICloneable,….)
//Создать несколько объектов-цветов. Собрать Букет.
//Определить его стоимость.Провести сортировку цветов в
//букете на основе любого параметра.Найти цветок в букете,
//соответствующий заданному цвету.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab6
{
    public enum Ecolor
    {
        def,
        red,
        yellow,
        blue,
        orange,
        pink,
        white
    }

    public struct flowerProperties
    {
        public Ecolor color;
        public int petalsCount;
        public float stemLength;
        public float price;

        public flowerProperties(Ecolor color, int petalsCount, float stemLength, float price)
        {
            this.color = color;
            this.petalsCount = petalsCount;
            this.stemLength = stemLength;
            this.price = price;
        }
    }

    public class Flower: IComparable<Flower>
    {
        public flowerProperties properties;

        public Flower()
        {
            properties = new flowerProperties();
        }
        public Flower(Ecolor color, int petalsCount, float stemLength, float price)
        {
            properties = new flowerProperties(color, petalsCount, stemLength, price);
        }

        public int CompareTo(Flower flower)
        {
            return this.properties.petalsCount.CompareTo(flower.properties.petalsCount);
        }
    }

    public sealed class Rose : Flower       //роза
    {
        public Rose()
        {
            properties = new flowerProperties(Ecolor.red, 40, 20, 4.99f);
        }

        public override string ToString()
        {
            return $"Rose, \t\tColor: {properties.color}, \tPentals Count: {properties.petalsCount}, \tPrice: {properties.price}, \tStem length: {properties.stemLength}";
        }

    }          
    public sealed class Cornflower : Flower // василек
    {
        public Cornflower()
        {
            properties = new flowerProperties(Ecolor.blue, 18, 8, 0.99f);
        }

        public override string ToString()
        {
            return $"Cornflower, \tColor: {properties.color}, \tPentals Count: {properties.petalsCount}, \tPrice: {properties.price}, \tStem length: {properties.stemLength}";
        }

    }   

    public sealed class Lily : Flower       //лилия
    {
        public Lily()
        {
            properties = new flowerProperties(Ecolor.white, 18, 8, 0.99f);
        }

        public override string ToString()
        {
            return $"Lily, \t\tColor: {properties.color}, \tPentals Count: {properties.petalsCount}, \tPrice: {properties.price}, \tStem length: {properties.stemLength}";
        }
    }
    public sealed class Daisy : Flower      //ромашка
    {
        public Daisy()
        {
            properties = new flowerProperties(Ecolor.white, 32, 5, 0.59f);
        }

        public override string ToString()
        {
            return $"Daisy, \t\tColor: {properties.color}, \tPentals Count: {properties.petalsCount}, \tPrice: {properties.price}, \tStem length: {properties.stemLength}";
        }
    }
    public sealed class Forgot_me_not : Flower//незабудка
    {
        public Forgot_me_not()
        {
            properties = new flowerProperties(Ecolor.blue, 6, 8, 0.69f);
        }

        public override string ToString()
        {
            return $"Forgot-me-not, \tColor: {properties.color}, \tPentals Count: {properties.petalsCount}, \tPrice: {properties.price}, \tStem length: {properties.stemLength}";
        }
    }


    sealed partial class Bouquet
    {
        List<Flower> flowers;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rose rose = new Rose();
            Rose rose2 = new Rose();
            Rose rose3 = new Rose();
            Lily lily = new Lily();
            Cornflower cornFlower = new Cornflower();
            Daisy daisy = new Daisy();
            Forgot_me_not forgot_me_not = new Forgot_me_not();

            Bouquet bouquet = new Bouquet(rose, rose2, rose3, lily, cornFlower, daisy, forgot_me_not);

            bouquet.Flowers[0] = new Daisy();

            Console.WriteLine($"Full price of bouquet: {bouquet.FullPrice()}\n\nBouquet:");
            bouquet.Print();

            Console.WriteLine("\n\nBouquet sorted by Pentals Count:");
            bouquet.Sorted_Print();

            Console.WriteLine("\n\nOnly red flowers");
            List<Flower> onlyRedFlowers = bouquet.SortingByColor(Ecolor.red);
        }
    }
}
