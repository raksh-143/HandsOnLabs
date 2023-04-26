using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileIOHandsOn
{
    internal class WorkingWithFile
    {
        static void Main()
        {
            try
            {
                FileStream fd = File.Create("WorkingWithFile.txt");
                fd.Close();
                Console.WriteLine("File created");
                File.WriteAllText("WorkingWithFile.txt", "Hello World!\nHi World!");
                Console.WriteLine("File written");
                string[] content = File.ReadAllLines("WorkingWithFile.txt");
                foreach (string line in content)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("File read");
                File.Copy("WorkingWithFile.txt", "WorkingWithFile - Copy.txt");
                Console.WriteLine("File copied");
                File.Move("WorkingWithFile.txt", "C:\\Users\\Adnim\\source\\repos\\FileIOHandsOn\\FileIOHandsOn\\bin\\WorkingWithFile - Copy.txt");
                Console.WriteLine("File moved");
                File.Replace("WorkingWithFile - Copy.txt", "DetailsCopy.txt", "Details - Copy.txt");
                Console.WriteLine("File created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
