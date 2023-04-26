using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject
{
    internal class Ward
    {
        public string WardName;
        public WardType WardType;
        public double BasicCost;
        public List<Patient> Patients { get; set; } = new List<Patient>();
        public double GetWardCost()
        {
            return WardCostCalculator.FindWardCost(BasicCost, WardType);
        }
        public int GetTotalPatients()
        {
            return Patients.Count;
        }
    }
}
