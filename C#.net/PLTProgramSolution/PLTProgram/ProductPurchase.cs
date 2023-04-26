using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    /*
    Write a pseudocode to do the following: 
    Accept the item code, description, qty and price of an item. Compute the total for 
    the item. 
    Accept the user’s choice. If the choice is ‘y’ then accept the next set of inputs for 
    a new item and compute the total. In this manner, compute the grand total for all 
    the items purchased by the customer. 
    If the grand total is more than Rs. 10,000/- then, the customer is allowed a 
    discount of 10%. 
    If the grand total is less than Rs. 1,000/- and the customer chooses to pay by card, 
    then a surcharge of 2.5% is levied on the grand total. 
    Display the grand total for the customer.
     */
    internal class ProductPurchase
    {
        static int itemCode,qty;
        static double itemPrice,grandTotal = 0.0;
        static string itemDesc;
        static char userChoice;
        static void CalculateGrandTotal()
        {
            grandTotal += qty * itemPrice;
        }
        static void CheckForSurcharge()
        {
            char isPaymentByCard;
            if(grandTotal < 1000)
            {
                Console.Write("Do you wish to pay by card?");
                isPaymentByCard = char.Parse(Console.ReadLine());
                if(isPaymentByCard == 'y' || isPaymentByCard == 'Y')
                {
                    grandTotal += 0.025 * grandTotal;
                }
            }
        }
        static void CheckForDiscount()
        {
            if (grandTotal > 10000)
            {
                grandTotal -= 0.1 * grandTotal;
            }
        }
        static void Main()
        {
            //Accept input from user
            do
            {
                Console.Write("Enter item code: ");
                itemCode = int.Parse(Console.ReadLine());
                Console.Write("Enter item description: ");
                itemDesc = Console.ReadLine();
                Console.Write("Enter item quantity: ");
                qty = int.Parse(Console.ReadLine());
                Console.Write("Enter item price: ");
                itemPrice = double.Parse(Console.ReadLine());
                //Calculate grand total
                CalculateGrandTotal();
                //Exit Condition
                Console.Write("Do you want to enter another product: ");
                userChoice = char.Parse(Console.ReadLine());

            } while (userChoice == 'y' || userChoice == 'Y');
            //Check <1000 and levi surcharge of 2.5%
            CheckForSurcharge();
            //Check >10000 and enable discount
            CheckForDiscount();
            //Display total payable amount
            Console.WriteLine("The total payable amount = " + grandTotal);
            Console.ReadKey();
        }
    }
}
