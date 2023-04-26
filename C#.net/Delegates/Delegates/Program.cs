using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate void NotifyMe(string sInfo);
    internal class client
    {
        //Main creates the delegate, points it at a function implementation 
        //and invokes the delegate 
        static void Main(string[] args)
        {
            //use static function of Listener class for delegate call 
            //create instance of Notify delegate and point it at static function to call
            NotifyMe d = new NotifyMe(Listener.GetNotifiedAgain); 
            //invoke the delegate function 
            //notice function being called below takes a delegate that can point
            //to ANY function on any class - this is loosly coupled!
            InvokeDelegate(d);
            //invoke delegate using Instance function 
            //create listener instance 
            Listener lsnr = new Listener(); 
            //create delegate and point to listener instance method 
            NotifyMe d2 = new NotifyMe(lsnr.GetNotified); 
            //invoke just like before 
            InvokeDelegate(d2);
        }
        static void InvokeDelegate(NotifyMe d)
        { 
            d("You are late paying your bills!"); 
        }
    }
    class Listener
    { 
        //instance function that matches signature of delegate above 
         public void GetNotified(string sInfo)
         {    
            Console.WriteLine("I got notified with the following information {0}",sInfo); 
         } 
         //static function that matches signature of delegate above 
         public static void GetNotifiedAgain(string sInfo)
         { 
            Console.WriteLine("I got notified with the following information:{0}",sInfo); 
         } 
    }
}
