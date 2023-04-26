using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOHandsOn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("details.txt");
            string newData = "";
            try
            {
                while(!sr.EndOfStream)
                {
                    string question = sr.ReadLine();
                    Console.Write(question);
                    string answer = Console.ReadLine();
                    newData += $"{question} {answer}\n";
                }
                Console.WriteLine("Information successfully entered");
            }
            catch (IOException)
            {
                Console.WriteLine("Could not read/write to the file");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
            }
            StreamWriter sw = new StreamWriter("details.txt");
            try
            {
                sw.WriteLine(newData);
            }
            catch (IOException)
            {
                Console.WriteLine("Could not write into the file");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
