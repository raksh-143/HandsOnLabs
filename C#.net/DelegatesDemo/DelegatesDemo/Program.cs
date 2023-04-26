using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    //public class MyDelegate : Delegate //Throws error
    //{

    //}
    //1. Delegate declaration
    public delegate void MyDelegate(string str);
    internal class Program
    {
        static void Main(string[] args)
        {
            Greeting("Direct: Hello");//Direct method invocation
            //MyDelegate d = new MyDelegate();//No non-parametrized constructor in MyDelagate class
            //2. Delgate Instantiation and initialization
            MyDelegate d = new MyDelegate(Greeting);//Address of a method can be passed using the name of the method without the parantheses
            //Multicast delegates
            //Subscription
            Program p = new Program();
            d += p.Hi;
            d.Invoke("Hi");
            //Unsubscribe
            d -= Greeting;
            //3. Delagate Invocation
            d.Invoke("Invoke: Hello"); //Invokes both Greeting and Hi
            d("Without Invoke: Hello");
        }
        static void Greeting(string text)
        {
            //to invoke any method
            //1. which class
            //2. method name
            //3. parameters
            //4. static/instance methods
            Console.WriteLine($"Greeting: {text}");
        }
        public void Hi(string msg)
        {
            Console.WriteLine($"Hi: {msg}");
        }
    }
}
