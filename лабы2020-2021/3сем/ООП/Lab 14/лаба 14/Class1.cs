using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;


namespace лаба_14
{
   
    class CustomSerealizble<T> : InterfaceSerializer<T>
    {
        public void Serializable(string path, T obj, string format)
        {
            format = format.ToUpper();
            if (format == "JSON")
            {
                StreamWriter writefile = new StreamWriter(path);
                writefile.Write(JsonConvert.SerializeObject(obj));
                writefile.Close();
            }
            else
            {
                using (FileStream file = new FileStream(path, FileMode.Create))
                {
                    if (format == "SOAP")
                    {
                        SoapFormatter formatter = new SoapFormatter();
                        formatter.Serialize(file, obj);
                    }
                    else if (format == "BINARY")
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(file, obj);
                    }
                    else if (format == "XML")
                    {
                        XmlSerializer xmlF = new XmlSerializer(typeof(T));
                        xmlF.Serialize(file, obj);
                    }
                    file.Close();
                }
            }            
        }
        public object DeSerializable(string path, T t, string format = "none")
        {
            if (format == "none")
            {
                format = Path.GetFileName(path);
                int dotIndex = format.IndexOf('.');
                if (dotIndex >= 0)
                {
                    format = format.Substring(dotIndex + 1, format.Length - dotIndex - 1).ToUpper();
                }
            }
            object obj = t;
            if (format == "JSON")
            {
                obj = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            }
            else
            {
                using (FileStream file = new FileStream(path, FileMode.Open))
                {
                    
                    if (format == "SOAP")
                    {
                        SoapFormatter formatter = new SoapFormatter();
                        obj = formatter.Deserialize(file);
                    }
                    else if (format == "BINARY")
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        obj = formatter.Deserialize(file);
                    }

                    else if (format == "XML")
                    {
                        XmlSerializer xmlF = new XmlSerializer(typeof(T));
                        obj = xmlF.Deserialize(file);
                    }
                    file.Close();
                }
            }
            return obj;
        }
    }
}
