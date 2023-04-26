using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOHandsOn
{
    internal class WorkingWithDirectoryClass
    {
        static void Main()
        {
            try
            {
                Directory.CreateDirectory("C:\\Users\\Adnim\\Desktop\\Demo");
                Directory.CreateDirectory("C:\\Users\\Adnim\\Desktop\\Demo\\Directory1");
                Directory.CreateDirectory("C:\\Users\\Adnim\\Desktop\\Demo\\Directory2");
                foreach (var file in Directory.EnumerateDirectories("C:\\Users\\Adnim\\Desktop\\Demo"))
                {
                    Console.WriteLine(file);
                }
                Directory.Move("C:\\Users\\Adnim\\Desktop\\Demo", "C:\\Users\\Adnim\\Desktop\\Demo Moved");
                Directory.GetParent("C:\\Users\\Adnim\\Desktop\\Demo Moved");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
