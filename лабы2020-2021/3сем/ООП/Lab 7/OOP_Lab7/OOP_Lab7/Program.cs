//Создать иерархию классов исключений(собственных) – 3 типа и более.
//Сделать наследование пользовательских типов исключений от стандартных
//классов.Net(например, Exception, IndexOutofRange)

//Сгенерировать и обработать как минимум пять различных исключительных
//ситуаций на основе своих и стандартных исключений.Например, не позволять при
//инициализации объектов передавать неверные данные, обрабатывать ошибки при
//работе с памятью и ошибки работы с файлами, деление на ноль, неверный индекс,
//нулевой указатель и т.д.

//В конце поставить универсальный обработчик catch.
//Обработку исключений вынести в main.При обработке выводить
//специфическую информацию о месте, диагностику и причине исключения.
//Последним должен быть блок, который отлавливает все исключения (finally).

//Добавьте код в одной из функций макрос Assert.Объясните что он проверяет, как
//будет выполняться программа в случае не выполнения условия.Объясните
//назначение Assert.
//Ознакомьтесь с классами Debug и Debugger:

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab7
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

    public class Flower : IComparable<Flower>
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
        int maxCount;
        public float byuerBudget;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bouquet testBouquet = new Bouquet();

            try
            {
                testBouquet.MaxCount = 20;
                testBouquet.Add(new Rose());
                testBouquet.Add(new Rose());
                testBouquet.Add(new Rose());
                testBouquet.Add(new Rose());
                testBouquet.Add(new Rose());
                testBouquet.Add(new Rose());
                testBouquet.Print();
                testBouquet.ByBouquet();
                Bouquet testBouquet2 = new Bouquet(-2, -1, new Rose());
            }
            catch (ZeroFlowersException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.time.ToString());
                Console.WriteLine(ex.TargetSite);

            }
            catch (BouquetOverflowException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.time.ToString());
                Console.WriteLine(ex.TargetSite);

            }
            catch (ExpensiveException ex) when (testBouquet != null)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.time.ToString());
                Console.WriteLine(ex.TargetSite);

            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.time.ToString());
                Console.WriteLine(ex.TargetSite);
            }
            catch
            {
                Console.WriteLine("Возникла непредвиденная ошибка");
            }
            finally
            {
                Console.WriteLine("Конец проверок!");
            }

            int[] aa = null;
            Debug.Assert(aa != null, "Values array cannot be null");
            Console.WriteLine("Конец программы!");
        }
    }
}
