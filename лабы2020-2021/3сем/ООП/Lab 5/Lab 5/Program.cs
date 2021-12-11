/* ТЕХНИЧЕСКОЕ ЗАДАНИЕ 
1) Определить иерархию и композицию классов (в соответствии с вариантом),
реализовать классы. Если необходимо расширьте по своему усмотрению
иерархию для выполнения всех пунктов л.р.
Каждый класс должен иметь отражающее смысл название и
информативный состав. При кодировании должны быть использованы
соглашения об оформлении кода code convention.
В одном из классов переопределите все методы, унаследованные от
Object.
2) В проекте должен быть минимум один интерфейс и абстрактный класс.
Использовать виртуальные методы и переопределение.
3) Сделайте один из классов sealed;
4) Добавьте в интерфейсы (интерфейс) и абстрактный класс одноименные
методы. 
5) Написать демонстрационную программу, в которой создаются объекты
различных классов. Поработать с объектами через ссылки на абстрактные
классы и интерфейсы. В этом случае для идентификации типов объектов
использовать операторы is или as.
6) Во всех классах (иерархии) переопределить метод ToString(), который
выводит информацию о типе объекта и его текущих значениях.
7) Создайте дополнительный класс Printer c полиморфным методом
IAmPrinting( SomeAbstractClassorInterface someobj). Формальным
параметром метода должна быть ссылка на абстрактный класс или наиболее
общий интерфейс в вашей иерархии классов. В методе iIAmPrinting
определите тип объекта и вызовите ToString(). В демонстрационной
программе создайте массив, содержащий ссылки на разнотипные объекты
ваших классов по иерархии, а также объект класса Printer и последовательно
вызовите его метод IAmPrinting со всеми ссылками в качестве аргументов.
Растение, Куст, Цветок, Роза, Гладиолус, Кактус, Бумага, Букет
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //заполняем данные 
            Flower fl = new Flower();
            fl.Age = new DateTime(10, 10, 10);
            fl.Color = "white";
            fl.Hidth = 10;
            fl.Vid = "fialka";
            Console.WriteLine(fl.ToString());

            Gladiolus glad = new Gladiolus();
            glad.Age = new DateTime(11, 11, 11);
            glad.Color = "white";
            glad.Hidth = 11;
            glad.Vid = "Gladiolus One";
            glad.zapah();
            Console.WriteLine(glad.ToString());

            Gladiolus glad2 = new Gladiolus();
            glad.Age = new DateTime(11, 11, 11);
            glad.Color = "white";
            glad.Hidth = 11;
            glad.Vid = "Gladiolus two";
            Console.WriteLine(glad.ToString());


            Paper paper = new Paper("list");
            paper.Age = new DateTime(10, 10, 10);
            paper.Color = "white";
            paper.Hidth = 10;
            paper.Vid = "дуб";
            Console.WriteLine(paper.ToString());

            Cactus cactus = new Cactus(10, true, new DateTime(10, 10, 10));
            cactus.Age = new DateTime(10, 10, 10);            
            cactus.Hidth = 10;
            cactus.Vid = "неизвестный кактус";
            Console.WriteLine(cactus.ToString());

            Rose roza = new Rose();
            roza.Age = new DateTime(10, 10, 10);
            roza.Color = "white";
            roza.Hidth = 10;
            roza.Vid = "какая-то роза";
            roza.zapah();
            Console.WriteLine(roza.ToString());

            Bush bush = new Bush();
            bush.Age = new DateTime(10, 10, 10);           
            bush.Hidth = 10;
            bush.Vid = "куст";
            Console.WriteLine(bush.ToString());

            Flower rozaPlant = new Rose();
            
           ((Rose)rozaPlant).Pole = "поле";
            rozaPlant.Age = new DateTime(10, 10, 10);
            rozaPlant.Color = "white";
            rozaPlant.Hidth = 10;
            rozaPlant.Vid = "Роза из Plant";
            Console.WriteLine(rozaPlant.ToString());

            //проверки на принадлежность объектов к классам и наследникам
            Console.WriteLine("проверка на принадлежность rozaPlant is Rose:" + (rozaPlant is Rose));
            Console.WriteLine("проверка на принадлежность rozaPlant is Plant:" + (rozaPlant is Plant));
            Console.WriteLine("проверка на принадлежность rozaPlant is Flower:" + (rozaPlant is Flower));
            Console.WriteLine("проверка на принадлежность glad is Plant:" + (glad is Plant));
            Console.WriteLine("проверка на принадлежность glad is interface1:" + (glad is interface1));

            //работа с интерфейсом
            interface1[] arr = { glad, glad2, roza};
            Printer print = new Printer();
            for (int i = 0; i < arr.Length; i++)
            {
                print.iAmPrinting(arr[i]);
                Console.WriteLine();
            }
            glad.move();
            ((interface1)glad).move();
            Console.ReadKey();
        }
    }
}
