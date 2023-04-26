using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    /*
    A vendor offers software services to a client. Each resource is billed at some dollar rate 
    per hour. The total cost of the project for the client is therefore, the total number of 
    hours contributed by all the vendor resources * the dollar rate / hour. There are however 
    some variants. 
    The vendor might have purchased hardware/infrastructure or software licenses 
    needed for the project. 
    The vendor might have utilized external consultants for the project. 
    The client looks at the vendor as a one-stop solution and hence external resources 
    employed by the vendor need to be paid by the vendor. 
    It might however be possible that the vendor’s hardware and software 
    purchases are borne by the client. In this case, the client pays the vendor 
    30% of the hardware/infrastructure costs. In case of software licenses, the 
    client pays the vendor 50% of the cost, if they are commonly available and 
    used, or 100% if the software is infrequently used or is proprietary client 
    technology. 
    The external consultants employed by the vendor will come at a dollar rate per 
    hour. 
    Accept the suitable inputs and display the profits / loss realized by the vendor.
     */
    internal class VendorClass
    {
        static double hwSwPurchases, swLicenses, propClientTech, extCons,dollarPerHour,totalVendorCosts,totalClientCosts,profitLossPercentage;
        static void CalculateVendorCosts()
        {
            totalVendorCosts = hwSwPurchases + swLicenses + extCons * dollarPerHour;
        }
        static void CalculateClientCosts()
        {
            totalClientCosts = 0.3 * hwSwPurchases + 0.5 * swLicenses + propClientTech + extCons * dollarPerHour;
        }
        static void DisplayResult()
        {
            profitLossPercentage = totalClientCosts - totalVendorCosts;
            if(profitLossPercentage > 0)
            {
                Console.WriteLine("You have witnessed profit");
            }
            else
            {
                Console.WriteLine("You have witnessed loss");
            }
        }
        static void Main()
        {
            //Take inputs form vendor
            Console.Write("Amount spent on Hardware and Software purchases: ");
            hwSwPurchases = double.Parse(Console.ReadLine());
            Console.Write("Amount spent on Software Licenses: ");
            swLicenses = double.Parse(Console.ReadLine());
            Console.Write("Amount spent on Proprietary client technology: ");
            propClientTech = double.Parse(Console.ReadLine());
            Console.Write("Hours spent by External Consultants: ");
            extCons = double.Parse(Console.ReadLine());
            Console.Write("Enter the dollar rate per hour: ");
            dollarPerHour = double.Parse(Console.ReadLine());
            //Caluculate Vendor costs
            CalculateVendorCosts();
            //Calculate Client payable
            CalculateClientCosts();
            //Display profit or loss
            DisplayResult();
            Console.ReadKey();
        }
    }
}
