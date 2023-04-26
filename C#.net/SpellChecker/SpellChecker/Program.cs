using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpellChecker
{
    class Program
    {
        static void Main()
        {
            StreamReader reader = new StreamReader("Words.txt");
            StreamWriter writer = new StreamWriter("Suggestions.txt");
            try
            {
                Stopwatch sw = Stopwatch.StartNew();
                string input = reader.ReadToEnd();
                string[] myWords = input.Split('\n');
                foreach (string word in myWords)
                {
                    string data = word.Trim();
                    if (data != "")
                    {
                        writer.WriteLine($"{data}:");
                        writer.WriteLine();
                        List<string> list = GetSuitableWords.GetWords(data);
                        foreach (string suggestion in list)
                        {
                            writer.WriteLine(suggestion);
                        }
                        writer.WriteLine();
                    }
                }
                Console.WriteLine("Suggestions written to the file...\nCheck Suggestions.txt");
                Console.WriteLine(sw.ElapsedMilliseconds);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                reader.Close();
                writer.Close();
            }
        }
    }
}
