using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace FileIOHandsOn
{
    internal class SerializeDeserialize
    {
        static void Main()
        {
            try
            {
                //Object Creation
                ClsRadio clsRadio = new ClsRadio { Make = 2874, Model = "xyz" };
                ClsMaruthi clsMaruthi = new ClsMaruthi { HasPowerSteering = false };
                ClsCar clsCar = new ClsCar { ModelName = "A387", Make = 178, BodyColor = "Crimson", hasAC = false, Radio = clsRadio, clsMaruthi = clsMaruthi };

                //Binary Serialization
                Stream file = File.Create("binser.dat");
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, clsCar);
                file.Close();
                //Binary Deserialization
                Stream fileReader = File.OpenRead("binser.dat");
                clsCar = (ClsCar)bf.Deserialize(fileReader);
                Console.WriteLine($"{clsCar.ModelName} {clsCar.Make} {clsCar.BodyColor} {clsCar.hasAC}");

                //Soap Serialization
                file = File.Create("soapser.dat");
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(file, clsCar);
                file.Close();
                //Soap Deserialization
                fileReader = File.OpenRead("soapser.dat");
                clsCar = (ClsCar)sf.Deserialize(fileReader);
                Console.WriteLine($"{clsCar.ModelName} {clsCar.Make} {clsCar.BodyColor} {clsCar.hasAC}");

                //XML Serialization
                file = File.Create("xmlser.xml");
                XmlSerializer xmls = new XmlSerializer(typeof(ClsCar));
                xmls.Serialize(file, clsCar);
                file.Close();
                //XML Deserialization
                fileReader = File.OpenRead("xmlser.xml");
                clsCar = (ClsCar)xmls.Deserialize(fileReader);
                Console.WriteLine($"{clsCar.ModelName} {clsCar.Make} {clsCar.BodyColor} {clsCar.hasAC}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    [Serializable]
    public class ClsCar
    {
        public string ModelName;
        public ClsRadio Radio;
        public int Make;
        public string BodyColor;
        public bool hasAC;
        public ClsMaruthi clsMaruthi;
    }
    [Serializable]
    public class ClsRadio {
        public int Make;
        public string Model;
    }
    [Serializable]
    public class ClsMaruthi
    {
        public bool HasPowerSteering;
    }
}
