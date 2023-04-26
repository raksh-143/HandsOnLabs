using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageEnhancementDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Extension methods
            //1. Should be public and static
            //2. Should take at least one parameter
            //3. First parameter should be of the same type that we are extending it to
            //4. Should belong to a static class
            string data = "some data";
            data.Encrypt(); //Downward pointing arrow -> extension method
            //data = SomeClass.Encrypt(data);
        }
        static void LocalReferenceType()
        {
            //local variable type inference
            //var -> can be used only within the method body (not as instance variables) and the value must be initialized
            //var cannot be used in parameters of a method or return type of a method
            var a = 10;
            //a = "hello"; //Gives Error
            object b = 10; //Usage of object is not advised
            b = "hello"; //Gives Error
            var str = "some data";
            var keyValuePairs = new Dictionary<int, List<int>>();
        }
        static void AnonymousTypes()
        {
            //Anonymous Types
            //Object to be created only once in a life time
            //Product p1 = new Product { Id=111,Name="IPhone14",Rate=99999}; //Not efficient
            var p2 = new { Id = 111, Name = "IPhone14", Rate = 99999 }; //Create, consume, destroy; We cannot return p2 out of the method
            var p3 = new { Id = 121, Name = "IPhone14 Pro", Rate = 19999.87 }; 
            var p4 = new { Id = 121, Name = "IPhone14 Pro", Rate = "kgfhfg" }; 
            Console.WriteLine($"{p2.Id} {p2.Name} {p2.Rate}");
            //Compiler creates the Product class by itself but name will be Anonymous_SomeSerialNumber
            //When we send p2 out of this method it can be received as an object but the receiver will have to typecast it
            //to some datatype which will be anonymous
        }
    }
    //class Product
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public double Rate { get; set; }
    //}
    //Utility class -> small functionality in a class
    static class SomeClass
    {
        //To apply it for any type use datatype object or for a selected set of classes then use it's immediate parent class
        public static string Encrypt(this string data) 
        {
            return ")(*&@#$%^&*&^%$";
        }
    }
}
