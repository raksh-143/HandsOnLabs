using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneNumberValidation.BusinessLogic.Exceptions;
using PhoneNumberValidationLogic.Entities;
using PhoneNumberValidation.BusinessLogic;
using PhoneNumberValidationLogic;

namespace PhoneNumberValidation.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the employee mobile number: ");
                string PhoneNumber = Console.ReadLine();
                Employee emp = new Employee { Phone = PhoneNumber };
                Employee emp2 = new Employee();
                PhoneNumberValidator.ValidateOnlyDigits(emp2.Phone);
                PhoneNumberValidator.ValidateNumberOfDigits(emp.Phone);
                PhoneNumberValidator.ValidateTheFirstNumber(emp.Phone);
                Console.WriteLine("Phone Number in proper format");
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("Assign a phone number to the employee before validating it");
            }
            catch(InvalidMobileNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
