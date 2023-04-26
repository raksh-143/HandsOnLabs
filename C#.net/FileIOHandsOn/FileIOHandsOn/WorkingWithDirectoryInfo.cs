using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOHandsOn
{
    internal class WorkingWithDirectoryInfo
    {
        static void Main()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Adnim\\Desktop\\Demo");
                dir.CreateSubdirectory("Directory1");
                dir.CreateSubdirectory("Directory2");
                foreach (var file in dir.EnumerateDirectories())
                {
                    Console.WriteLine(file.FullName);
                }
                dir.MoveTo("C:\\Users\\Adnim\\Desktop\\Demo Moved");
                Console.WriteLine(dir.Parent.FullName);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
