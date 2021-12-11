using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace лаба_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = Type.GetType(typeof(Flower).FullName);
            CustomSerealizble<Flower> serealiz = new CustomSerealizble<Flower>();
            Flower fl1 = new Flower();
            serealiz.Serializable("Binary.Binary", fl1, "Binary");
            Flower fl2 = (Flower)serealiz.DeSerializable("Binary.Binary", fl1, "Binary");
            serealiz.Serializable("SOAP.SOAP", fl1, "SOAP");
            fl2 = (Flower)serealiz.DeSerializable("SOAP.SOAP", fl1);
            serealiz.Serializable("JSON.JSON", fl1, "JSON");
            fl2 = (Flower)serealiz.DeSerializable("JSON.JSON", fl1, "JSON");
            serealiz.Serializable("XML.XML", fl1, "XML");
            fl2 = (Flower)serealiz.DeSerializable("XML.XML", fl1, "XML");
           
            DateTime newDate1 = new DateTime(2016, 12, 20);
            DateTime newDate2 = new DateTime(2017, 12, 20);
            DateTime newDate3 = new DateTime(2018, 12, 20);
            DateTime newDate4 = new DateTime(2019, 12, 20);

            Flower[] fl3 = new Flower[]
            {
                new Flower(newDate1),
                new Flower(newDate2),
                new Flower(newDate3),
                new Flower(newDate1),
            };
            Flower[] fl4 = new Flower[]
            {
                new Flower(),
                new Flower(),
                new Flower(),
                new Flower(),
            };
            List<Flower> list = new List<Flower>();
            foreach(var flow in fl3)
            {
                list.Add(flow);
            }
            List<Flower> list2 = new List<Flower>();
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream file = new FileStream("SOAP.SOAP", FileMode.OpenOrCreate))
            {               
                formatter.Serialize(file, fl3);
                
                file.Close();
            }
            using (FileStream file = new FileStream("SOAP.SOAP", FileMode.Open))
            {                
                Flower[] fl5 = (Flower[])formatter.Deserialize(file);
                file.Close();
            }
            BinaryFormatter formatter2 = new BinaryFormatter();
            using (FileStream file = new FileStream("Binary.Binary", FileMode.Create))
            {                
                formatter2.Serialize(file, fl3);
                file.Close();
            }
            using (FileStream file = new FileStream("Binary.Binary", FileMode.Open))
            {               
                fl4 = (Flower[])formatter2.Deserialize(file);
                file.Close();
            }
            XmlSerializer xmlF = new XmlSerializer(typeof(Flower[]));
            using (FileStream file = new FileStream("XML2.txt", FileMode.OpenOrCreate))
            {               
                xmlF.Serialize(file, fl3);
                file.Close();
            }
            using (FileStream file = new FileStream("XML2.txt", FileMode.Open))
            {                
                fl4 = (Flower[])xmlF.Deserialize(file);
                file.Close();
            }
            using (StreamWriter writefile = new StreamWriter("json.json"))
            {
                    writefile.Write(JsonConvert.SerializeObject(fl3));
                    writefile.Close();                    
            }
            
            fl4 = JsonConvert.DeserializeObject<Flower[]>(File.ReadAllText("json.json"));



            // XPath
            XmlDocument doc = new XmlDocument();
            doc.Load("XPath.xml");

            XmlNodeList nodeList;
            XmlNode root = doc.DocumentElement;

            nodeList = root.SelectNodes("descendant::book[author/last-name]");

            //Change the price on the books.
            foreach (XmlNode book in nodeList)
            {
                Console.WriteLine(book["author"].FirstChild.InnerText);
            }

            ///ling to xml 

            XElement flowers = new XElement("Flowers"
                   , new XElement("Flower", new XElement("Hidth", "92"), new XElement("Age", "2"), new XElement("Title", "Rose1"))
                   , new XElement("Flower", new XElement("Hidth", "92"), new XElement("Age", "3"), new XElement("Title", "Rose2"))
                   , new XElement("Flower", new XElement("Hidth", "92"), new XElement("Age", "5"), new XElement("Title", "Rose3"))
                   , new XElement("Flower", new XElement("Hidth", "92"), new XElement("Age", "8"), new XElement("Title", "Rose4")));


            var res = flowers.Descendants("Flower").Where(x => Int32.Parse(x.Element("Age").Value) >= 5)
                .Select(x => x.Element("Title").Value);
            foreach (var item in res)
                Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}
