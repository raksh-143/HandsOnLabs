using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutstandingPerson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[5];
            for(int i=0;i<5;i++)
            {
                Console.WriteLine("Is the person a student?");
                char choice = Convert.ToChar(Console.ReadLine());

                if(choice == 'Y' || choice == 'y')
                {
                    Console.WriteLine("Enter Student name: ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter the percentage: ");
                    double percentage = double.Parse(Console.ReadLine());

                    Person person1 = new Student(name, percentage);
                    persons[i] = person1;
                }
                else
                {
                    Console.WriteLine("Enter Professor name: ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter the number of books published: ");
                    int books = int.Parse(Console.ReadLine());

                    Person person1 = new Professor(name, books);
                    persons[i] = person1;
                }
            }
            
            foreach(Person person in persons)
            {
                if(person is Professor)
                {
                    Professor prof = (Professor)person;
                    if (prof.IsOutstanding())
                    {
                        prof.Print();
                    }
                }
                if (person is Student)
                {
                    Student stud = (Student)person;
                    if (stud.IsOutstanding())
                    {
                        stud.Display();
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
