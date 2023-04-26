using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Mappings_Mountains
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MountainContext db = new MountainContext();
            var countries = db.Countries.ToList();
            foreach(var country in countries)
            {
                Console.WriteLine($"Country: {country.Name}");
                var mountains = country.Mountains.ToList();
                foreach(var mountain in mountains)
                {
                    Console.WriteLine($"Mountain: {mountain.Name}");
                    var peaks = mountain.Peaks.ToList();
                    foreach(var peak in peaks)
                    {
                        Console.WriteLine($"Peak: {peak.Name}");
                    }
                }
            }
        }

        private static void SeedingDataIntoDb()
        {
            Database.SetInitializer(new MountainsMigrationStrategy());
            Country3 c = new Country3
            {
                Code = "AB",
                Name = "Absurdistan"
            };
            Mountain m = new Mountain
            {
                Name = "Absurdistan"
            };
            m.Peaks.Add(new Peak
            {
                Name = "Great Peak",
                Mountain = m
            });
            m.Peaks.Add(new Peak
            {
                Name = "Small Peak",
                Mountain = m
            });
            c.Mountains.Add(m);
            MountainContext db = new MountainContext();
            db.Countries.Add(c);
            db.SaveChanges();
        }
    }
}
