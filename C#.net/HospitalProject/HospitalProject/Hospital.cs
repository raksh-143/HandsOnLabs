using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject
{
    internal class Hospital
    {
        public string Name;
        public long Phone;
        public string Address;
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Ward> Wards { get; set; } = new List<Ward> ();

        public int GetTotalPatients()
        {
            int TotalPatients = 0;
            foreach(Ward ward in Wards)
            {
                TotalPatients += ward.GetTotalPatients();
            }
            return TotalPatients;
        }
        public int GetTotalPatientsByWard(Ward Ward)
        {
            return Ward.GetTotalPatients();
        }
        public int GetTotalDoctors()
        {
            int TotalDoctors = 0;
            foreach(Employee employee in Employees)
            {
                if(employee is Doctor)
                {
                    TotalDoctors++;
                }
            }
            return TotalDoctors;
        }
        //Doubt
        public List<Doctor> GetDoctorBySpecialization(string Specialization)
        {
            List<Doctor> doctors = new List<Doctor> ();
            foreach(Employee employee in Employees)
            {
                if(employee is Doctor)
                {
                    Doctor doctor = (Doctor) employee;
                    if(doctor.Speciality == Specialization)
                    {
                        doctors.Add(doctor);
                    }
                }
            }
            return doctors;
        }
        public int GetTotalConsultants()
        {
            int TotalConsultants = 0;
            foreach (Employee employee in Employees)
            {
                if (employee is Doctor)
                {
                    if(employee is ConsultantDoctor)
                    {
                        TotalConsultants++;
                    }
                }
            }
            return TotalConsultants;
        }
        public double GetWardCostByType(WardType WardType)
        {
            double TotalWardCost = 0;
            foreach(Ward ward in Wards)
            {
                if(ward.WardType == WardType)
                {
                    TotalWardCost += ward.GetWardCost();
                }
            }
            return TotalWardCost;
        }

    }
}
