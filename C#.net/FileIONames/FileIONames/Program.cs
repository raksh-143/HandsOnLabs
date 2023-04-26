using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIONames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:\\Users\\Adnim\\Documents\\Skill Assure Documents\\C# .Net\\File IO\\names.txt");
            try
            {
                string content = sr.ReadToEnd();
                string[] names = content.Split(',');
                Array.Sort(names,new Sort());
                int value = 0;
                for(int j=0;j<names.Length; j++)
                {
                    int partialValue = 0;
                    for(int i=1;i<names[j].Length-1;i++)
                    {
                        partialValue += Convert.ToInt32(names[j][i]) - 65 + 1;
                    }
                    Console.WriteLine($"{names[j]} = {partialValue}");
                    value += (j + 1) * partialValue;
                }
                Console.WriteLine($"Total value of all names in the file is {value}");
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            finally
            {
                sr.Close();
            }
        }
    }
    class Sort : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x.CompareTo(y);
        }
    }
}
