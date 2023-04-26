using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode
{
    class Inheritance
    {
        static void Main()
        {
            //Shape s = new Shape();
            //s.Draw();
            //Console.WriteLine(s.CalculateArea(10, 10));
            //Rectangle rectangle = new Rectangle();
            //rectangle.Draw();
            //Console.WriteLine(rectangle.CalculateArea(10, 10));
            //Triangle triangle = new Triangle();
            //triangle.Draw();
            //Console.WriteLine(triangle.CalculateArea(10, 10));

            //Base class ref variable can hold derived type objects
            IShape s;
            s = new Triangle();
            Console.WriteLine(s.CalculateArea(10, 10));
            Console.ReadKey();
        }
    }
    interface IShape
    {
        //drawing a shape is not defined hence making it abstract, the child classes can use this method to implement drawing
        //a rectangle or triangle or any other shape
        void Draw();
        //{
        //    Console.WriteLine("Drawing shape...");
        //}
        double CalculateArea(double width, double height);
        //{
        //    Console.WriteLine("Calculating shape area...");
        //    return width * height;
        //}
    }
    class Rectangle : IShape
    {
        public double CalculateArea(double width, double height)
        {
            Console.WriteLine("Calculating Rectangle area...");
            return width * height;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing a rectangle...");
        }
    }
    class Triangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a triangle...");
        }

        //Without new keyword -> gives warning saying that the inherited method is suppressed (base class method)
        //When new keyword is added the warning is suppressed
        public double CalculateArea(double width, double height)
        {
            Console.WriteLine("Calculating triangle area...");
            return width * height / 2;
        }
    }
}
