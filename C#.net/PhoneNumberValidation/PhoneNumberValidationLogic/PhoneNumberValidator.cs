using PhoneNumberValidation.BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneNumberValidationLogic
{
    public class PhoneNumberValidator
    {
        public static void ValidateNumberOfDigits(string PhoneNumber)
        {
            if (PhoneNumber.Length != 10)
            {
                InvalidMobileNumberException imne = new InvalidMobileNumberException("Phone number should have 10 digits");
                throw imne;
            }
        }
        public static void ValidateOnlyDigits(string PhoneNumber)
        {
            string pattern = "^[0-9]+$";
            bool res = Regex.IsMatch(PhoneNumber, pattern);
            if (!res)
            {
                InvalidMobileNumberException imne = new InvalidMobileNumberException("Phone number should have only digits");
                throw imne;
            }
        }
        public static void ValidateTheFirstNumber(string PhoneNumber)
        {
            if (PhoneNumber[0] != '9')
            {
                InvalidMobileNumberException imne = new InvalidMobileNumberException("Phone number should begin with 9");
                throw imne;
            }
        }
    }
}
