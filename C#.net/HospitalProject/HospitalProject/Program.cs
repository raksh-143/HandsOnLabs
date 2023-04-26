using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Hospital hospital = new Hospital();
            //Ward Ward1 = new Ward();
            //Ward1.WardName = "First";
            //Ward1.WardType = WardType.PadiatricUnit;
            //Ward1.BasicCost = 1000;
            //Ward Ward2 = new Ward();
            //Ward2.WardName = "Second";
            //Ward2.WardType = WardType.GeneralUnit;
            //Ward2.BasicCost = 700;
            //hospital.Wards.Add(Ward1);
            //hospital.Wards.Add(Ward2);
            //foreach(Ward ward in hospital.Wards)
            //{
            //    Console.WriteLine(ward.WardName + " = " + ward.GetWardCost());
            //}

            Hospital hospital = new Hospital();
            Ward ward = new Ward();
            ward.WardType = WardType.GeneralUnit;
            ward.BasicCost = 1000;
            ward.WardName = "General";
            hospital.Wards.Add(ward);
            Patient patient1 = new Patient { Name="Rakshitha",Gender='F',AdmittedDate=DateTime.Today,Age=21};
            ward.Patients.Add(patient1);
            Doctor doctor = new Doctor();
            doctor.Speciality = "Cardiology";
            doctor.Name = "My Doctor";
            hospital.Employees.Add(doctor);
            ConsultantDoctor consultant = new ConsultantDoctor();
            hospital.Employees.Add(consultant);

            Console.WriteLine(hospital.GetTotalDoctors());
            List<Doctor> doctors = hospital.GetDoctorBySpecialization("Cardiology");
            foreach (Doctor doctor1 in doctors)
            {
                Console.WriteLine(doctor1.Name);
            }
            Console.WriteLine(hospital.GetTotalConsultants());
            Console.WriteLine(hospital.GetTotalPatients());
            Console.WriteLine(hospital.GetTotalPatientsByWard(ward));
            Console.WriteLine(hospital.GetWardCostByType(WardType.GeneralUnit));

            Console.ReadKey();
        }
    }
}
