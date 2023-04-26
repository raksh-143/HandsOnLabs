using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsExercsie12
{
    internal class StreamWriterQuestion
    {
        static void Write(string filename, string message)
        {
            StreamWriter sw = new StreamWriter(filename);
            try
            {
                sw.WriteLine(message);
            }
            finally
            {
                sw.Close();
            }
        }
        static void Main()
        {
            try
            {
                Write("data.txt", "Good Morning.");
            }
            catch (IOException)
            {
                Console.WriteLine("Problem in writing to the file");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
