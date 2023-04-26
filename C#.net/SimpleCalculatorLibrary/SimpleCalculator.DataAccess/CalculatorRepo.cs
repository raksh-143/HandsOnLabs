using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.DataAccess
{
    public class CalculatorRepo : ICalculatorRepo
    {
        public bool Save(string data)
        {
            //Logic to save data into data store
            File.WriteAllText("X:\\calculatorresult.txt", data); //Throws exception X: does not exist
            return true;
        }
    }
}
