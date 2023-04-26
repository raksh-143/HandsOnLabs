using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode
{
    /*
    Using USES
    1. Invoking a static method -> IS-A HAS-A is not required
    2. Local Instantiation -> The object is needed in one method only and does not change memory requirement of the class
    3. Formal Argument Use -> When the object of one class is passed as an argument to a method in another class then the relationship
       between them is USES
    4. Return Type -> If the return type of a method in one class is the object of another class then the relationship between them is USES

    If we create a reference to a class outside (Customer c;) then it is a HAS-A relationship
    If we allocate the memory inside a method (c = new Customer();) then it is a USES relationship
     */
    internal class IsaHasaUses
    {

    }
    class A //12B alloted with HAS-A
    {
        int a1; //4B
        int a2; //4B
        //B b = new B(); //4B
        void Main()
        {
            B b1 = new B(); // 0B
        }
    }
    class B //4B alloted
    {
        int b1;
    }
}
