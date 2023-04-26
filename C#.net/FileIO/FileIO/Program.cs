using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //File Handling
            //Get all drives
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine(drive.Name);
            }

            string[] files = Directory.GetFiles(@"C:\");
            foreach (string file in files) { 
                Console.WriteLine(file);
            }


            //Save data to file
            //Save();
            //Read all data at once
            //ReadAll();
            //read line by line
            //ReadLineByLine();


            //Store contact info into a file
            Contact c = new Contact { ID=111,Name="Sachin",EmailID="sachin@gmail.com",Location="Mumbai",Mobile="9876543210"};
            //Text format - structured data
            //Serialization
            //string csvData = $"{c.ID},{c.Name},{c.EmailID},{c.Location},{c.Mobile}";
            //StreamWriter sw = new StreamWriter("contacts.txt",true);
            //sw.WriteLine(csvData);
            //sw.Close();
            //StreamReader sr = new StreamReader("contacts.txt");
            //List<Contact> contacts = new List<Contact>();
            //while (!sr.EndOfStream)
            //{
            //    string line = sr.ReadLine();
            //    //convert line into contact obj
            //    string[] data = line.Split(',');
            //    //Deserialization
            //    c = new Contact();
            //    c.ID = int.Parse(data[0]);
            //    c.Name = data[1];
            //    c.EmailID = data[2];
            //    c.Location = data[3];
            //    c.Mobile = data[4];
            //    contacts.Add(c);
            //}
            ////Close the file 
            //sr.Close();
            //foreach (var c1 in contacts)
            //{
            //    Console.WriteLine($"{c1.Name}\t{c1.Mobile}");
            //}

            //Serialization
            Stream str = File.Create("contacts.dat");
            BinaryFormatter binary = new BinaryFormatter(); //More security and less file size
            binary.Serialize(str, c); //Need not be written object by object; can be dumped at once
            str.Close();

            //Deserialization
            str = File.OpenRead("contacts.dat");
            binary = new BinaryFormatter(); //More security and less file size
            Contact c2 = new Contact();
            c2 = (Contact)binary.Deserialize(str);
            Console.WriteLine(c.Name);
            str.Close();

            Console.ReadKey();
        }
        private static void Save()
        {
            //Save some info into a file
            string someData = "Some data";
            StreamWriter sw = new StreamWriter("sample.txt", true); //file created in bin/debug folder
            try
            {
                sw.WriteLine(someData);
            }
            finally
            {
                sw.Close();
            }
        }
        private static void ReadAll()
        {
            //Read from the file
            StreamReader sr = new StreamReader("sample.txt");
            //Read all data at once
            string allLines = sr.ReadToEnd();
            Console.WriteLine(allLines);
            //Close the file
            sr.Close();
        }
        private static void ReadLineByLine()
        {
            //Read from the file
            StreamReader sr = new StreamReader("contacts.txt");
            //Read line by line
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }
            //Close the file 
            sr.Close();
        }
    }
    [Serializable] //Making the class serializable -> else throws exception
    class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string EmailID { get; set; }
        public string Mobile { get; set; }
    }
}
