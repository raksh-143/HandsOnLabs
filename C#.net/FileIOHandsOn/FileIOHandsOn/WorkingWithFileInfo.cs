using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOHandsOn
{
    internal class WorkingWithFileInfo
    {
        static void Main()
        {
            FileInfo fileInfo = new FileInfo("Details.txt");
            try
            {
                Console.WriteLine(fileInfo.FullName);
                Console.WriteLine(fileInfo.Length);
                fileInfo.CopyTo("DetailsCopy.txt");
                fileInfo.MoveTo("C:\\Users\\Adnim\\source\\repos\\FileIOHandsOn\\FileIOHandsOn\\bin\\Details.txt");
                FileInfo fileInfo2 = new FileInfo("Details - Copy.txt");
                FileStream filedesc = fileInfo2.OpenRead();
                try
                {
                    byte[] buffer = new byte[1024];
                    filedesc.Read(buffer, 0, 1024);
                    Console.WriteLine(Encoding.UTF8.GetString(buffer));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    filedesc.Close();
                }
                StreamReader fileDesc2 = fileInfo2.OpenText();
                try
                {
                    while (!fileDesc2.EndOfStream)
                    {
                        Console.WriteLine(fileDesc2.ReadLine()); ;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    fileDesc2.Close();
                }
                fileInfo.GetAccessControl(System.Security.AccessControl.AccessControlSections.Owner);
                FileStream filedesc2 = fileInfo2.Open(FileMode.Open);
                try
                {
                    byte[] bytes = Encoding.ASCII.GetBytes("Hello World\n");
                    filedesc2.Write(bytes, 0, bytes.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    filedesc2.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
/*
 * 
 
 */
